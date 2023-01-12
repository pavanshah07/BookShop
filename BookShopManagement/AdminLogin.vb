Public Class AdminLogin
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim Obj = New Login()
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Application.Exit()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If PasswordTb.Text = "Admin" Then
            Dim Obj As New Books()
            Obj.Show()
            Me.Hide()
        Else
            MsgBox("Wrong Password..Contact Your Admin")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            PasswordTb.PasswordChar = ""
        Else
            PasswordTb.PasswordChar = "*"
        End If

    End Sub
End Class