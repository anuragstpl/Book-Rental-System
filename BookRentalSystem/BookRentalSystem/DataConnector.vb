Imports System.Data.SqlClient

Public Class DataConnector
    Public Shared Function GetConnection() As SqlConnection
        Dim connection As SqlConnection = New SqlConnection()
        connection.ConnectionString = "Data Source=(local);Initial Catalog=APUBookShop;Integrated Security=SSPI;"
        connection.Open()
        Return connection
    End Function
End Class
