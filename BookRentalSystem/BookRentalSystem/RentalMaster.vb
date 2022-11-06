Public Class RentalMaster

    Private Sub RentBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RentBookToolStripMenuItem.Click
        Dim renting As Renting = New Renting()
        renting.MdiParent = Me
        renting.Show()
    End Sub

    Private Sub ReturnBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnBookToolStripMenuItem.Click
        Dim retBook As ReturnBook = New ReturnBook()
        retBook.MdiParent = Me
        retBook.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Dim form1 As Form1 = New Form1()
        form1.Show()
        Me.Hide()
    End Sub
End Class