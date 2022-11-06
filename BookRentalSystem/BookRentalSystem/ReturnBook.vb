Imports System.Data.SqlClient

Public Class ReturnBook

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connection As SqlConnection = DataConnector.GetConnection()
        Dim mycommand1 As SqlCommand = New SqlCommand("select * from Booking where StudentID = '" + TextBox9.Text + "'")
        mycommand1.Connection = connection
        Dim dataReader As SqlDataReader = mycommand1.ExecuteReader()
        If (dataReader.HasRows) Then
            While (dataReader.Read())
                Label4.Text = dataReader("BookName")
                Label6.Text = dataReader("BookingDate")
            End While
            Dim fineDays As Integer = GetDaysForFine(Label6.Text)
            If (fineDays > 7) Then
                Dim fineDay As Integer = fineDays - 7
                Label3.Text = "RM " + (fineDay * 1).ToString() + ".00"
            End If
        Else
            MessageBox.Show("You haven't rented any book or check your student/staff id and try again.")
        End If
        

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connection As SqlConnection = DataConnector.GetConnection()
        Dim mycommand1 As SqlCommand = New SqlCommand("delete from Booking where BookName = '" + Label4.Text + "'")
        mycommand1.Connection = connection
        mycommand1.ExecuteNonQuery()
        MessageBox.Show("Book returned successfully.")
    End Sub

    Public Function GetDaysForFine(ByVal boookingDate As String) As Integer
        Dim ValidDate As Date = CDate(boookingDate)
        Dim date1 As New System.DateTime(ValidDate.Year, ValidDate.Month, ValidDate.Day)
        Dim date2 = Now
        Dim Diff1 As System.TimeSpan
        Diff1 = date2.Subtract(date1)
        Dim TotRemDays = (Int(Diff1.TotalDays))
        Return TotRemDays
    End Function
End Class