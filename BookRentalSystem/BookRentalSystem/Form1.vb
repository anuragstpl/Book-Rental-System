Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "admin" And TextBox2.Text = "123456" Then
            Dim RentingMaster As RentalMaster = New RentalMaster()
            RentingMaster.Show()
            Me.Hide()
        Else
            MessageBox.Show("Incorrect Userid or password.Try Again.")
        End If

    End Sub
End Class
