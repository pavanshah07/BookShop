Imports System.Data.OleDb
Imports System.IO
Public Class Dashboard
    Dim Con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\.net\BookShopManagement\BookProject.mdb")
    Private Sub CountBook()
        Dim BookNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from BookTbl"
        Dim cmd As OleDbCommand
        cmd = New OleDbCommand(sql, Con)
        BookNum = cmd.ExecuteScalar
        BookTbl.Text = BookNum
        Con.Close()
    End Sub
    Private Sub CountUser()
        Dim UserNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from UserTbl"
        Dim cmd As OleDbCommand
        cmd = New OleDbCommand(sql, Con)
        UserNum = cmd.ExecuteScalar
        UserTbl.Text = UserNum
        Con.Close()
    End Sub
    Private Sub SumAmount()
        Dim Amount As Integer
        Con.Open()
        Dim sql = "select Sum(Amount) from BillTbl"
        Dim cmd As OleDbCommand
        cmd = New OleDbCommand(sql, Con)
        Amount = cmd.ExecuteScalar
        AmountLbl.Text = Amount
        Con.Close()
    End Sub
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CountBook()
        CountUser()
        SumAmount()

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        Application.Exit()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Dim Obj = New Books()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim Obj = New Users()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Dim Obj = New Login()
        Obj.Show()
        Me.Hide()
    End Sub
End Class