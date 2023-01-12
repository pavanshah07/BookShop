Imports System.Data.OleDb
Imports System.IO
Public Class Books
    Dim Con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\.net\BookShopManagement\BookProject.mdb")
    Private Sub populate()
        Con.Open()
        Dim sql = "Select * from BookTbl"
        Dim adapter As OleDbDataAdapter
        adapter = New OleDbDataAdapter(sql, Con)
        Dim builder As OleDbCommandBuilder
        builder = New OleDbCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        BooksDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Filter()
        Con.Open()
        Dim sql = "Select * from BookTbl where Category = '" & FilterCb.SelectedItem.ToString() & "'"
        Dim adapter As OleDbDataAdapter
        adapter = New OleDbDataAdapter(sql, Con)
        Dim builder As OleDbCommandBuilder
        builder = New OleDbCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        BooksDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Reset()
        BookIdTb.Clear()
        BookNameTb.Clear()
        AuthorTb.Clear()
        CatTb.SelectedIndex = -1
        QtyTb.Clear()
        PriceTb.Clear()
    End Sub
    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If BookNameTb.Text = "" Or AuthorTb.Text = "" Or CatTb.Text = "" Or QtyTb.Text = "" Or PriceTb.Text = "" Then
            MsgBox("Missing Infomation")
        Else
            Con.Open()
            Dim query As String
            query = "insert into BookTbl values('" & BookIdTb.Text & "','" & BookNameTb.Text & "' ,'" & AuthorTb.Text & "' ,'" & CatTb.SelectedItem.ToString & "' ,'" & QtyTb.Text & "','" & PriceTb.Text & "')"
            Dim cmd As New OleDb.OleDbCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Book Saved Successfully")
            Con.Close()
            populate()
            Reset()

        End If
    End Sub
    Dim key = 0
    Private Sub BooksDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles BooksDGV.CellMouseClick
        Dim row As DataGridViewRow = BooksDGV.Rows(e.RowIndex)
        BookIdTb.Text = row.Cells(0).Value.ToString
        BookNameTb.Text = row.Cells(1).Value.ToString
        AuthorTb.Text = row.Cells(2).Value.ToString
        CatTb.SelectedItem = row.Cells(3).Value.ToString
        QtyTb.Text = row.Cells(4).Value.ToString
        PriceTb.Text = row.Cells(5).Value.ToString
        If BookNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)

        End If
    End Sub
    Private Sub Books_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub

    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Reset()
    End Sub
    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If key = 0 Then
            MsgBox("Select The Book To Be Deleted")
        Else
            Con.Open()
            Dim query As String
            query = "Delete from BookTbl where Bid=" & key & ""
            Dim cmd As New OleDb.OleDbCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Book Deleted Successfully")
            Con.Close()
            populate()
            Reset()

        End If
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If BookIdTb.Text = "" Or BookNameTb.Text = "" Or AuthorTb.Text = "" Or CatTb.Text = "" Or QtyTb.Text = "" Or PriceTb.Text = "" Then
            MsgBox("Missing Infomation")
        Else
            Con.Open()
            Dim cmd As New OleDb.OleDbCommand("UPDATE BookTbl set Title = ('" & BookNameTb.Text & "'), Author = ('" & AuthorTb.Text & "'), Category = ('" & CatTb.SelectedItem.ToString & "'), Quantity = ('" & QtyTb.Text & "'), Price = ('" & PriceTb.Text & "') where Bid = " & BookIdTb.Text, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Book Updated Successfully")
            Con.Close()
            populate()
            Reset()
        End If
    End Sub

    Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles FilterCb.SelectionChangeCommitted
        Filter()
    End Sub

    Private Sub RefreshBtn_Click(sender As Object, e As EventArgs) Handles RefreshBtn.Click
        populate()
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        Application.Exit()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim Obj = New Users()
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