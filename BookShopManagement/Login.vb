Imports System.Data.OleDb
Imports System.IO
Public Class Login
    Dim Con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\.net\BookShopManagement\BookProject.mdb")
    Dim cmd As OleDbCommand

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            PasswordTb.PasswordChar = ""
        Else
            PasswordTb.PasswordChar = "*"
        End If
    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        If UserNameTb.Text = "" Or PasswordTb.Text = "" Then
            MsgBox("Enter The User Name and Password")
        Else
            Con.Open()
            Dim Query = "select * from UserTbl where Name = '" & UserNameTb.Text & "' And Password='" & PasswordTb.Text & "'"
            Dim cmd As New OleDb.OleDbCommand(Query, Con)
            Dim da As OleDb.OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MsgBox("Wrong UserName Or Password")
            Else
                Dim Bill = New Bills
                Bill.UserName = UserNameTb.Text
                Bill.Show()
                Me.Hide()
            End If
            Con.Close()
        End If

    End Sub

    Private Sub AdminLink_Click(sender As Object, e As EventArgs) Handles AdminLink.Click
        Dim Adm As New AdminLogin
        Adm.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Application.Exit()
    End Sub


End Class