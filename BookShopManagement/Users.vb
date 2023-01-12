Imports System.Data.OleDb
Imports System.IO
Public Class Users
    Dim Con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\.net\BookShopManagement\BookProject.mdb")
    Private Sub populate()
        Con.Open()
        Dim sql = "Select * from UserTbl"
        Dim adapter As OleDbDataAdapter
        adapter = New OleDbDataAdapter(sql, Con)
        Dim builder As OleDbCommandBuilder
        builder = New OleDbCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        UsersDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Reset()
        IdTb.Text = ""
        UnameTb.Text = ""
        PhoneTb.Text = ""
        AddressTb.Text = ""
        PasswordTb.Text = ""
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If IdTb.Text = "" Or UnameTb.Text = "" Or PhoneTb.Text = "" Or AddressTb.Text = "" Or PasswordTb.Text = "" Then
            MsgBox("Missing Infomation")
        Else
            Con.Open()
            Dim query As String
            query = "insert into UserTbl values(" & IdTb.Text & " ,'" & UnameTb.Text & "' ,'" & PhoneTb.Text & "' ,'" & AddressTb.Text & "' ," & PasswordTb.Text & ")"
            Dim cmd As New OleDb.OleDbCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("User Saved Successfully")
            Con.Close()
            populate()
            Reset()

        End If
    End Sub

    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub
    Dim key = 0
    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If key = 0 Then
            MsgBox("Select The User To Be Deleted")
        Else
            Con.Open()
            Dim query As String
            query = "Delete from UserTbl where Id=" & key & ""
            Dim cmd As New OleDb.OleDbCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("User Saved Successfully")
            Con.Close()
            populate()
            Reset()

        End If
    End Sub
    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Reset()
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If IdTb.Text = "" Or UnameTb.Text = "" Or PhoneTb.Text = "" Or AddressTb.Text = "" Or PasswordTb.Text = "" Then
            MsgBox("Missing Infomation")
        Else
            Con.Open()
            Dim cmd As New OleDb.OleDbCommand("UPDATE UserTbl set Name = ('" & UnameTb.Text & "'), Phone = ('" & PhoneTb.Text & "'), Address = ('" & AddressTb.Text & "') where Id = " & IdTb.Text, Con)
            cmd.ExecuteNonQuery()
            MsgBox("User Updated Successfully")
            Con.Close()
            populate()
            Reset()
        End If
    End Sub
    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles CloseTb.Click
        Application.Exit()
    End Sub

    Private Sub UsersDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles UsersDGV.CellMouseClick
        Dim row As DataGridViewRow = UsersDGV.Rows(e.RowIndex)
        IdTb.Text = row.Cells(0).Value.ToString
        UnameTb.Text = row.Cells(1).Value.ToString
        PhoneTb.Text = row.Cells(2).Value.ToString
        AddressTb.Text = row.Cells(3).Value.ToString
        PasswordTb.Text = row.Cells(4).Value.ToString
        If UnameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)

        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Dim Obj = New Books()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Dim Obj = New Dashboard()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Dim Obj = New Login()
        Obj.Show()
        Me.Hide()
    End Sub
End Class