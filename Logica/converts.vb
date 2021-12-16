Public Class converts
    Public Function ValidarPrecio(ByVal Precio As String) As Decimal
        Dim salida As Decimal = -1


        Try
            salida = CDec(Precio)
        Catch ex As Exception

        End Try


        Return salida
    End Function

    Public Function VadilaFecha(ByVal Fecha As String) As DateTime
        Dim salida As DateTime

        Try
            salida = DateTime.Parse(Fecha)
        Catch ex As Exception
            salida = DateSerial(1900, 1, 1)
        End Try

        Return salida
    End Function
End Class
