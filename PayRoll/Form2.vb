Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Newform As New Form1
        Newform.Show
        Me.Hide()

    End Sub
End Class