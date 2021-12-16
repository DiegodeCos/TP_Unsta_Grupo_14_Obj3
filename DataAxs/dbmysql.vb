Imports System.Data

Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class database

    Private _cxString As String
    Private _Conectado
    Private _conexion As MySqlConnection
    Private _cx As String

    Private _lastMSG As String = ""

    Public Sub New(ByVal CX As String)
        _Conectado = False
        _cx = CX
    End Sub

    Private Function Conectar() As Boolean
        Dim salida As Boolean = False
        _lastMSG = ""
        Try
            _conexion = New MySqlConnection()
            _conexion.ConnectionString = _cx
            _conexion.Open()
            salida = True
        Catch ex As Exception
            salida = False
            _lastMSG = ex.Message
        End Try
        Return salida
    End Function

    Private Function Desconectar() As Boolean
        Dim salida As Boolean = False
        _lastMSG = ""

        Try
            _conexion.Close()
            salida = True
        Catch ex As Exception
            salida = False
            _lastMSG = ex.Message
        End Try
        Return salida
    End Function


    Public Function Insert(ByVal _Course As DataObjs.Course) As Boolean
        Dim salida As Boolean = False
        _lastMSG = ""

        If Conectar() Then
            Dim cmd As New MySqlCommand

            cmd.Connection = _conexion
            cmd.CommandText = "sp_course_insert"
            cmd.CommandType = CommandType.StoredProcedure

            Normalizar(_Course)

            cmd.Parameters.AddWithValue("@_Nombre", _Course.Nombre)
            cmd.Parameters("@_Nombre").Direction = ParameterDirection.Input

            cmd.Parameters.AddWithValue("@_Descripcion", _Course.Descripcion)
            cmd.Parameters("@_Descripcion").Direction = ParameterDirection.Input

            cmd.Parameters.AddWithValue("@_Precio", _Course.Precio)
            cmd.Parameters("@_Precio").Direction = ParameterDirection.Input

            cmd.Parameters.AddWithValue("@_Fecha", _Course.Fecha)
            cmd.Parameters("@_Fecha").Direction = ParameterDirection.Input

            Try
                cmd.ExecuteNonQuery()
                salida = True
                Desconectar()
            Catch ex As Exception
                salida = False
                _lastMSG = ex.Message
            End Try

        End If

        Return salida
    End Function

    Public Function Update(ByVal _Course As DataObjs.Course) As Boolean
        Dim salida As Boolean = False
        _lastMSG = ""

        If Conectar() Then
            Dim cmd As New MySqlCommand

            cmd.Connection = _conexion
            cmd.CommandText = "sp_course_update"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@_Courseid", _Course.Courseid)
            cmd.Parameters("@_Courseid").Direction = ParameterDirection.Input

            cmd.Parameters.AddWithValue("@_Nombre", _Course.Nombre)
            cmd.Parameters("@_Nombre").Direction = ParameterDirection.Input

            cmd.Parameters.AddWithValue("@_Descripcion", _Course.Descripcion)
            cmd.Parameters("@_Descripcion").Direction = ParameterDirection.Input

            cmd.Parameters.AddWithValue("@_Precio", _Course.Precio)
            cmd.Parameters("@_Precio").Direction = ParameterDirection.Input

            cmd.Parameters.AddWithValue("@_Fecha", _Course.Fecha)
            cmd.Parameters("@_Fecha").Direction = ParameterDirection.Input

            cmd.Parameters.AddWithValue("@_Activo", _Course.Activo)
            cmd.Parameters("@_Activo").Direction = ParameterDirection.Input

            Try
                cmd.ExecuteNonQuery()
                salida = True
                Desconectar()
            Catch ex As Exception
                salida = False
                _lastMSG = ex.Message
            End Try

        End If

        Return salida
    End Function

    Public Function Delete(ByVal _CourseID As Long) As Boolean
        Dim salida As Boolean = False
        _lastMSG = ""

        If Conectar() Then
            Dim cmd As New MySqlCommand

            cmd.Connection = _conexion
            cmd.CommandText = "sp_course_delete"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@_Courseid", _CourseID)
            cmd.Parameters("@_Courseid").Direction = ParameterDirection.Input

            Try
                cmd.ExecuteNonQuery()
                salida = True
                Desconectar()
            Catch ex As Exception
                salida = False
                _lastMSG = ex.Message
            End Try

        End If

        Return salida
    End Function

    Public Function GetData(ByVal _CourseID) As DataObjs.Course
        Dim salidaDato As DataObjs.Course
        _lastMSG = ""

        If Conectar() Then
            Dim cmd As New MySqlCommand

            cmd.Connection = _conexion
            cmd.CommandText = "sp_course_select"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@_Courseid", _CourseID)
            cmd.Parameters("@_Courseid").Direction = ParameterDirection.Input


            Try
                Dim datar As MySql.Data.MySqlClient.MySqlDataReader

                datar = cmd.ExecuteReader()
                If datar.HasRows Then
                    datar.Read()
                    salidaDato = New DataObjs.Course

                    salidaDato.Activo = datar.Item("Activo")
                    salidaDato.Courseid = datar.Item("Courseid")

                    salidaDato.Descripcion = datar.Item("Descripcion")
                    salidaDato.Fecha = datar.Item("Fecha")
                    salidaDato.Nombre = datar.Item("Nombre")
                    salidaDato.Precio = datar.Item("Precio")

                End If
                Desconectar()
            Catch ex As Exception
                Desconectar()
                _lastMSG = ex.Message
            End Try
        End If

        Return salidaDato
    End Function

    Public Function Listar() As List(Of DataObjs.Course)
        Dim salida As New List(Of DataObjs.Course)
        Dim dato As DataObjs.Course

        _lastMSG = ""

        If Conectar() Then
            Dim cmd As New MySqlCommand

            cmd.Connection = _conexion
            cmd.CommandText = "sp_course_list"
            cmd.CommandType = CommandType.StoredProcedure

            Try
                Dim datar As MySql.Data.MySqlClient.MySqlDataReader

                datar = cmd.ExecuteReader()
                If datar.HasRows Then
                    While datar.Read()
                        dato = New DataObjs.Course
                        dato.Activo = datar.Item("Activo")
                        dato.Courseid = datar.Item("Courseid")

                        dato.Descripcion = datar.Item("Descripcion")
                        dato.Fecha = datar.Item("Fecha")
                        dato.Nombre = datar.Item("Nombre")
                        dato.Precio = datar.Item("Precio")
                        salida.Add(dato)
                    End While
                End If

                'Parse DetData

                Desconectar()
            Catch ex As Exception
                _lastMSG = ex.Message
            End Try
        End If

        Return salida
    End Function

    '    Dim myConnection As MySqlConnection
    '    Dim myDataAdapter As MySqlDataAdapter
    '    Dim myDataSet As DataSet
    '    Dim strSQL As String
    '    Dim iRecordCount As Integer
    '    myConnection = New MySqlConnection("server=localhost; user id=15secs; password=Test12; database=mydatabase; pooling=false;")
    '    strSQL = "SELECT * FROM mytable;"
    '    myDataAdapter = New MySqlDataAdapter(strSQL, myConnection)
    '    myDataSet = New DataSet()
    '    myDataAdapter.Fill(myDataSet, "mytable")

    Private Sub Normalizar(ByRef _course As DataObjs.Course)

        If IsNothing(_course.Nombre) Then
            _course.Nombre = ""
        Else
            If _course.Nombre.Length > 64 Then _course.Nombre.Substring(1, 64)
        End If


        If IsNothing(_course.Descripcion) Then
            _course.Descripcion = ""
        Else
            If _course.Descripcion.Length > 256 Then _course.Descripcion.PadLeft(256)
        End If


    End Sub

End Class
