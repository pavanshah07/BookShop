Imports System.Data.OleDb
Imports System.IO
Public Class Bills
    Dim Con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\.net\BookShopManagement\BookProject.mdb")
    Public Property UserName As String
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
        BookListDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Bills_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
        UnameLbl.Text = UserName
    End Sub
    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        Application.Exit()
    End Sub
    Private Sub Reset()
        key = 0
        QtyTb.Clear()
        PriceTb.Clear()
        ClientNmaeTb.Clear()
        BNameTb.Clear()
    End Sub

    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Reset()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString("BookShop", New Font("Century Gothic", 25), Brushes.MidnightBlue, New Point(350, 40))
        e.Graphics.DrawString("====Your Bill", New Font("Century Gothic", 16), Brushes.MidnightBlue, New Point(300, 70))
        Dim bm As New Bitmap(Me.BillDGV.Width, Me.BillDGV.Height)
        BillDGV.DrawToBitmap(bm, New Rectangle(0, 0, Me.BillDGV.Width, Me.BillDGV.Height))
        e.Graphics.DrawImage(bm, 60, 120)
        e.Graphics.DrawString("Total Amount Rs " + GrdTotal.ToString, New Font("Century Gothic", 15), Brushes.MidnightBlue, New Point(280, 500))
        e.Graphics.DrawString("===========Thanks For Buying In Our Shop==========", New Font("Century Gothic", 15), Brushes.MidnightBlue, New Point(150, 580))

    End Sub

    Private Sub PrintBtn_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        PrintPreviewDialog1.Show()
        AddBill()
    End Sub
    Private Sub AddBill()
        Try
            Con.Open()
            Dim query As String
            query = "insert into BillTbl values('" & UnameLbl.Text & "','" & ClientNmaeTb.Text & "' ," & GrdTotal & ")"
            Dim cmd As OleDbCommand
            cmd = New OleDbCommand(query, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Dim Obj = New Login()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub UpdateBook()
        Dim NewQty = Stock - Convert.ToInt32(QtyTb.Text)
        Con.Open()
        Dim cmd As New OleDb.OleDbCommand("UPDATE BookTbl set Quantity = ('" & NewQty & "') where Bid = " & key, Con)
        cmd.ExecuteNonQuery()
        MsgBox("Book Updated Successfully")
        Con.Close()
        populate()
    End Sub
    Dim key = 0, Stock = 0, i = 0, GrdTotal = 0
    Private Sub AddToBillBtn_Click(sender As Object, e As EventArgs) Handles AddToBillBtn.Click
        If PriceTb.Text = "" Or QtyTb.Text = "" Then
            MsgBox("Enter The Quantity")
        ElseIf BNameTb.Text = "" Then
            MsgBox("Select The Book")
        ElseIf Convert.ToInt32(QtyTb.Text) > Stock Then
            MsgBox("No Enough Stock")
        Else
            Dim rnum As Integer = BillDGV.Rows.Add()
            i = i + 1
            Dim total = Convert.ToInt32(QtyTb.Text) * Convert.ToInt32(PriceTb.Text)
            BillDGV.Rows.Item(rnum).Cells("Column1").Value = i
            BillDGV.Rows.Item(rnum).Cells("Column2").Value = BNameTb.Text
            BillDGV.Rows.Item(rnum).Cells("Column3").Value = PriceTb.Text
            BillDGV.Rows.Item(rnum).Cells("Column4").Value = QtyTb.Text
            BillDGV.Rows.Item(rnum).Cells("Column5").Value = total
            GrdTotal = GrdTotal + total
            Dim Tot As String
            Tot = "Rs" + Convert.ToString(GrdTotal)
            TotalLbl.Text = Tot
            UpdateBook()
        End If
    End Sub

    Private Sub BookListDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles BookListDGV.CellContentClick
        Dim row As DataGridViewRow = BookListDGV.Rows(e.RowIndex)
        BNameTb.Text = row.Cells(1).Value.ToString
        PriceTb.Text = row.Cells(5).Value.ToString
        Stock = Convert.ToInt32(row.Cells(4).Value.ToString)
        If BNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)

        End If
    End Sub
End Class