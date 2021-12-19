using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

#region "AUTENTICACION POR AZURE AD"
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
    .EnableTokenAcquisitionToCallDownstreamApi()
            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
            .AddInMemoryTokenCaches();
#endregion

#region "AUTORIZACION - POR DEFECTO TODO EN **[Authorize]**"
builder.Services.AddAuthorization(
    options =>
    {
        options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
        options
            .AddPolicy(
                "AdminOnly",
                policy => policy.RequireRole("admin")
            );

    });
#endregion

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

#region "SWAGGER"
builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Coloque sólo el token bearer en el cuadro de texto",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});
#endregion

#region "DEPENDENCY INJECTION"
//builder.Services.AddWebAPIServices();
builder.Services.AddHttpContextAccessor();
#endregion

#region "SEG: ELIMINAR HEADER DEL SERVER"
builder.WebHost.ConfigureKestrel(
    options =>
    {
        options.AddServerHeader = false;
    });
#endregion

var app = builder.Build();

app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
    #region "SWAGGER"
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Course API V1"); });
    var option = new RewriteOptions();
    option.AddRedirect("^$", "swagger");
    app.UseRewriter(option);
    #endregion
}

app.UseHttpsRedirection();

#region "AUTENTICACION Y AUTORIZACION"
app.UseAuthentication();
app.UseAuthorization();
#endregion

app.MapControllers();

#region "Administracion de Usuarios"
app.MapPost("api/admin/altaUsr/{myUser}", (DataObjs.Usuario myUser , HttpContext context,  GraphServiceClient graphServiceClient) =>
{
    if (!context.User.IsInRole("admin_sec"))
    {
        return Results.StatusCode(StatusCodes.Status401Unauthorized);
    }

    try
    {   
        //Verificar permiso Admin
        var user = new User
        {
            AccountEnabled = true,
            DisplayName = $"{System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(myUser.FirstName + myUser.LastName.First())}",
            MailNickname = $"{myUser.FirstName}{myUser.LastName.First()}",
            UserPrincipalName = $"{myUser.FirstName}.{myUser.LastName}@{  builder.Configuration["MyDomain"]  }",
            PasswordProfile = new PasswordProfile
            {
                ForceChangePasswordNextSignIn = false,
                Password = myUser.Password
            }
        };

        //Dar de alta el usuario
        var User = graphServiceClient.Users
                   .Request()
                   .AddAsync(user).GetAwaiter().GetResult();


       // return Results.StatusCode(StatusCodes.Status201Created);
        return  Results.Ok(user.UserPrincipalName);
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
#endregion

#region "COURSES"
#region "GET"
// Lista los usuarios activos
app.MapGet("api/course", ( HttpContext context) =>
{
    if (context.User.IsInRole("admin_sec"))
    {
        return Results.StatusCode(StatusCodes.Status401Unauthorized);
    }

    bool isAdmin_sec = context.User.IsInRole("admin_sec");
    bool isAdmin_plat = context.User.IsInRole("admin_plat");
    bool isUser = context.User.IsInRole("user");
    String userName = context.User.Identity.Name;

    string pausa_debug = "";

    try
    {
        Logica.CourseOps operaciones = new Logica.CourseOps(builder.Configuration["MyCXSQL.String"]);
        var courses = operaciones.Listar();

        if (courses != null)
        {
            return Results.Ok(courses);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status404NotFound);
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});

app.MapGet("api/course/{id}", (long  id , HttpContext context) =>
{
    if (context.User.IsInRole("admin_sec"))
    {
        return Results.StatusCode(StatusCodes.Status401Unauthorized);
    }

    try
    {
        Logica.CourseOps operaciones = new Logica.CourseOps(builder.Configuration["MyCXSQL.String"]);
        var course = operaciones.Buscar(id);

        if (course != null)
        {
            return Results.Ok(course);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status404NotFound);
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
#endregion

#region "POST - Alta"
//Alta 
app.MapPost("api/course/{course}", (DataObjs.Course course , HttpContext context) =>
{
    if (!context.User.IsInRole("admin_plat"))
    {
        return Results.StatusCode(StatusCodes.Status401Unauthorized);
    }

    try
    {
        Logica.CourseOps operaciones = new Logica.CourseOps(builder.Configuration["MyCXSQL.String"]);
        if (operaciones.Agregar(course))
        {
            return Results.StatusCode(StatusCodes.Status201Created);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status404NotFound);
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
#endregion

#region "PUT - Update"
app.MapPut("api/course/{course}", (DataObjs.Course course , HttpContext context) =>
{
    if (!context.User.IsInRole("admin_plat"))
    {
        return Results.StatusCode(StatusCodes.Status401Unauthorized);
    }

    try
    {
        Logica.CourseOps operaciones = new Logica.CourseOps(builder.Configuration["MyCXSQL.String"]);
        if (operaciones.Actualizar(course))
        {
            return Results.StatusCode(StatusCodes.Status202Accepted);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status404NotFound);
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
#endregion

#region "DEL"
app.MapDelete("api/course/{id}", (long id , HttpContext context) =>
{
    if (!context.User.IsInRole("admin_plat"))
    {
        return Results.StatusCode(StatusCodes.Status401Unauthorized);
    }

    try
    {
        Logica.CourseOps operaciones = new Logica.CourseOps(builder.Configuration["MyCXSQL.String"]);
        var courses = operaciones.Borrar(id);

        if (courses)
        {
            return Results.StatusCode(StatusCodes.Status200OK);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status404NotFound );
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
#endregion
#endregion

#region "Mapeo Captura de Errores"
app.Map("error", (HttpContext context) =>
{
    try
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>()!;
        var err = ((Microsoft.AspNetCore.Http.BadHttpRequestException)((Microsoft.AspNetCore.Diagnostics.ExceptionHandlerFeature)exceptionHandlerFeature).Error);
        if (err.StatusCode == StatusCodes.Status400BadRequest)
        {
            // return Results.Problem(new ProblemDetails { Detail = (err.InnerException != null) ? err.InnerException.Message : err.Message, Status = err.StatusCode });
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
        return Results.StatusCode(err.StatusCode);
    }
    catch
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
#endregion

app.Run();
