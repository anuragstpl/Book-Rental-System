Imports System.Data.SqlClient

Public Class Renting

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim bookData As Book = GetBooks().Where(Function(o) o.name = ComboBox1.SelectedItem.ToString()).Select(Function(p) p).FirstOrDefault()
        Label3.Text = "RM " + bookData.price.ToString()
    End Sub

    Function GetBooks() As IEnumerable(Of Book)
        Return New List(Of Book) From
            {
             New Book("3 Idiots", "50.00"),
             New Book("Harry Potter", "30.30"),
             New Book("Narnia", "10.60"),
             New Book("Shawshank Redemption", "33.50"),
             New Book("Hugo", "50.80"),
             New Book("Julias Cesar", "5.90"),
             New Book("Fadi", "6.50")
            }
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connection As SqlConnection = DataConnector.GetConnection()
        Dim mycommand1 As SqlCommand = New SqlCommand("select * from Booking where BookName = '" + ComboBox1.SelectedItem.ToString() + "'")
        mycommand1.Connection = connection
        Dim dataReader As SqlDataReader = mycommand1.ExecuteReader()
        If (dataReader.HasRows) Then
            MessageBox.Show("This book is already rented out.")
        Else
            mycommand1.Dispose()
            connection.Close()
            Dim bookData As Book = GetBooks().Where(Function(o) o.name = ComboBox1.SelectedItem.ToString()).Select(Function(p) p).FirstOrDefault()
            Dim TotalPaid As Double = Convert.ToDouble(TextBox1.Text) * 0.1 + Convert.ToDouble(TextBox2.Text) * 0.2 + Convert.ToDouble(TextBox3.Text) * 0.5 + Convert.ToDouble(TextBox6.Text) * 1 + Convert.ToDouble(TextBox5.Text) * 5 + Convert.ToDouble(TextBox4.Text) * 10 + Convert.ToDouble(TextBox8.Text) * 20 + Convert.ToDouble(TextBox7.Text) * 50
            If (TotalPaid >= Convert.ToDouble(bookData.price)) Then
                Label13.Text = "RM " + (TotalPaid - Convert.ToDouble(bookData.price)).ToString()
                connection = DataConnector.GetConnection()
                Dim mycommand As SqlCommand = New SqlCommand("insert into Booking values('" + TextBox9.Text + "','" + ComboBox1.SelectedItem.ToString() + "','" + bookData.price.ToString() + "','" + DateAndTime.Now.ToShortDateString() + "')")
                mycommand.Connection = connection
                mycommand.ExecuteNonQuery()
                MessageBox.Show("Booking completed successfully.")
                connection.Close()
            Else
                MessageBox.Show("Please pay the Full amount.")
            End If
        End If
    End Sub
End Class

Public Class Book
    Public Property name As String
    Public Property price As Double
    Public Sub New(ByVal BookName As String,
                       ByVal BookPrice As String)
        name = BookName
        price = BookPrice
    End Sub
End Class