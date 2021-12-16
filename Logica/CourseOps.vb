Public Class CourseOps
    Private _cx As String

    Public Sub New(ByVal CX As String)
        _cx = CX
    End Sub

    'GET-POST-PUT-DELETE
    Public Function Agregar(ByVal Course As DataObjs.Course) As Boolean
        Dim dataAdd As New DataAxs.database(_cx)

        Return dataAdd.Insert(Course)
    End Function

    Public Function Actualizar(ByVal Course As DataObjs.Course) As Boolean
        Dim dataAdd As New DataAxs.database(_cx)

        Return dataAdd.Update(Course)
    End Function

    Public Function Borrar(ByVal CourseID As Long) As Boolean
        Dim dataAdd As New DataAxs.database(_cx)

        Return dataAdd.Delete(CourseID)
    End Function

    Public Function Buscar(ByVal CourseID As Long) As DataObjs.Course
        Dim dataAdd As New DataAxs.database(_cx)

        Return dataAdd.GetData(CourseID)
    End Function

    Public Function Listar() As List(Of DataObjs.Course)
        Dim dataAdd As New DataAxs.database(_cx)

        Return dataAdd.Listar()
    End Function


End Class
