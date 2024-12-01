Imports System.Diagnostics.Eventing.Reader
Imports System.Drawing.Printing
Imports System.Data

Imports MySql.Data.MySqlClient
Imports MySql.Data


Public Class Form1


    Dim gender As String

    Dim ans As Integer
    Dim deduc As Integer
    Dim tax As Integer
    Dim phil As Integer
    Dim s As Integer
    Dim net As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ans = ((HourPerday.Text * NumberofDayWork.Text) * (RatePerHour.Text))

        GrossSalary1.Text = ans
        GrossSalary2.Text = ans
        tax = ans * 0.15
        MonthlyWage.Text = tax
        phil = ans * 0.05
        PhilHealth.Text = phil
        s = ans * 0.02

        SSS.Text = s
        deduc = tax + phil + s

        TotalDeduction.Text = deduc
        Deduction.Text = deduc

        net = GrossSalary2.Text - Deduction.Text
        NexSalary.Text = net



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.Text = ""
        RatePerHour.Text = ""
        HourPerday.Text = ""
        NumberofDayWork.Text = ""
        MonthlyWage.Text = ""
        PhilHealth.Text = ""
        SSS.Text = ""
        GrossSalary2.Text = ""
        Deduction.Text = ""
        GrossSalary1.Text = ""
        TotalDeduction.Text = ""
        NexSalary.Text = ""




    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        openCon()
        MsgBox("Connected")
        con.Close()



        Me.Text = "Print Dialog Example " 'set title form
        Button1.Text = "COMPUTE"
        Button2.Text = "CLEAR"

        PrintDialog1.Document = PrintDocument1



    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'print

        TextBoxyeah.Text = " "
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)

        TextBoxyeah.AppendText(vbTab + vbTab + vbTab & "PAYSLIP MO BE :) " + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("Employee Name : " + vbTab + TextBox1.Text + vbTab + vbTab + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)

        TextBoxyeah.AppendText("Basic Salary : " + vbTab + NexSalary.Text + vbTab + vbTab + vbNewLine)
        TextBoxyeah.AppendText("Gross Amount : " + vbTab + GrossSalary2.Text + vbTab + vbTab + vbNewLine)

        TextBoxyeah.AppendText("-------------------------------------------------------------------------------------------------------------" + vbNewLine)

        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText(vbTab + vbTab + vbTab & " DEDUCTION " + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText(" W\Tax : " + vbTab + MonthlyWage.Text + vbTab + vbTab + vbNewLine)

        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("Total Deduction : " + vbTab + TotalDeduction.Text + vbTab + vbTab & " NetSalary :" + vbTab & NexSalary.Text + vbNewLine)
        TextBoxyeah.AppendText("-------------------------------------------------------------------------------------------------------------" + vbNewLine)
        TextBoxyeah.AppendText(vbTab & "Due Date : " + Today + vbTab + vbTab & " Time " & TimeOfDay + vbNewLine)
        TextBoxyeah.AppendText("-------------------------------------------------------------------------------------------------------------" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText(vbTab + "Recieve by :" + vbNewLine)
        TextBoxyeah.AppendText(vbTab + vbTab + vbTab + "_____________________" + vbNewLine)
        TextBoxyeah.AppendText(vbTab + vbTab + vbTab + TextBox1.Text + vbNewLine)
        TextBoxyeah.AppendText(vbTab + vbTab + vbTab + "          Employee" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)
        TextBoxyeah.AppendText("" + vbNewLine)

    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim font As New Font("Arial", 24, FontStyle.Bold) 'set the font to display
        e.Graphics.DrawString(RichTextBox1.Text, font, Brushes.DeepSkyBlue, 100, 100) 'The Drawstring() function is used to print letters.

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If RichTextBox1.Text = " " Then
            MsgBox(" ")

        Else
            PrintDialog1.ShowDialog()


        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        openCon()

        Try

            cmd.Connection = con
            cmd.CommandText = "INSERT INTO payrollem (`EmpName`,`rate_per_hour`,`hours_per_day`,`number_of_day`) values('" &
                TextBox1.Text & "', '" & RatePerHour.Text & "', '" & HourPerday.Text & "', '" & NumberofDayWork.Text & "' )"
            cmd.ExecuteNonQuery()
            MsgBox("Successfully Add")
            con.Close()
            TextBox1.Clear()
            RatePerHour.Clear()
            HourPerday.Clear()
            NumberofDayWork.Clear()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
End Class
