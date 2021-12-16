using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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



app.MapGet("api/admin/altaUsr", (HttpContext context, GraphServiceClient graphServiceClient) =>
{
    try
    {
        StreamReader sr = new StreamReader(context.Request.Body);
        DataObjs.Usuario myUser = JsonConvert.DeserializeObject<DataObjs.Usuario>(sr.ReadToEnd());

        var user = new User
        {
            AccountEnabled = true,
            DisplayName = $"{System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(myUser.FirstName + myUser.LastName.First())}",
            MailNickname = $"{myUser.FirstName}{myUser.LastName.First()}",
            UserPrincipalName = $"{myUser.FirstName}.{myUser.LastName}@{  builder.Configuration["ConnectionStrings:Courses"]  }",
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


        return Results.StatusCode(StatusCodes.Status201Created);
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});




#region "COURSES"
#region "GET"
// Lista los usuarios activos
app.MapGet("api/course", () =>
{

    try
    {
        Logica.CourseOps operaciones = new Logica.CourseOps(builder.Configuration["MyCXSQL.String"]);
        var courses = operaciones.Listar();

        return Results.Ok(courses);
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});

app.MapGet("api/course/{id}", (HttpContext context, String id) =>
{
    try
    {
    
        if (long.TryParse(id, out long courseID))
        {
            Logica.CourseOps operaciones = new Logica.CourseOps(builder.Configuration["MyCXSQL.String"]);
            var courses = operaciones.Buscar(courseID);

            return Results.Ok(courses);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});

#endregion

#region "POST"
//Alta 
app.MapPost("api/course", (HttpContext context) =>
{
    try
    {
        StreamReader sr = new StreamReader(context.Request.Body);
        DataObjs.Course data = JsonConvert.DeserializeObject<DataObjs.Course>(sr.ReadToEnd());

        Logica.CourseOps operaciones = new Logica.CourseOps(builder.Configuration["MyCXSQL.String"]);
        if (operaciones.Agregar(data))
        {
            return Results.StatusCode(StatusCodes.Status201Created);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});

#endregion

#region "PUT"
app.MapPut("api/course", (HttpContext context) =>
{
    try
    {
        StreamReader sr = new StreamReader(context.Request.Body);
        DataObjs.Course data = JsonConvert.DeserializeObject<DataObjs.Course>(sr.ReadToEnd());

        Logica.CourseOps operaciones = new Logica.CourseOps(builder.Configuration["MyCXSQL.String"]);
        if (operaciones.Actualizar(data))
        {
            return Results.StatusCode(StatusCodes.Status201Created);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
#endregion

#region "DEL"
app.MapDelete("api/course/{id}", (HttpContext context) =>
{
    try
    {
        StreamReader sr = new StreamReader(context.Request.Body);
        String data = JsonConvert.DeserializeObject<String>(sr.ReadToEnd());
        if (long.TryParse(data, out long courseID))
        {
            Logica.CourseOps operaciones = new Logica.CourseOps(builder.Configuration["MyCXSQL.String"]);
            var courses = operaciones.Borrar(courseID);

            return Results.Ok(courses);
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
});
#endregion
#endregion



app.Run();
