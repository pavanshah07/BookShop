<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Splash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Progress = New Guna.UI2.WinForms.Guna2CircleProgressBar()
        Me.PercentageLBL = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Progress.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(143, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 35)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Book Shop  Software"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(144, 274)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(280, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "PoweredByPavanShah@2022"
        '
        'Progress
        '
        Me.Progress.Controls.Add(Me.PercentageLBL)
        Me.Progress.FillColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Progress.FillThickness = 12
        Me.Progress.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Progress.ForeColor = System.Drawing.Color.White
        Me.Progress.Location = New System.Drawing.Point(207, 76)
        Me.Progress.Minimum = 0
        Me.Progress.Name = "Progress"
        Me.Progress.ProgressColor = System.Drawing.Color.Red
        Me.Progress.ProgressColor2 = System.Drawing.Color.Red
        Me.Progress.ProgressThickness = 12
        Me.Progress.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Progress.Size = New System.Drawing.Size(165, 165)
        Me.Progress.TabIndex = 2
        Me.Progress.Text = "Guna2CircleProgressBar1"
        '
        'PercentageLBL
        '
        Me.PercentageLBL.AutoSize = True
        Me.PercentageLBL.Font = New System.Drawing.Font("Microsoft YaHei", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PercentageLBL.ForeColor = System.Drawing.Color.White
        Me.PercentageLBL.Location = New System.Drawing.Point(65, 65)
        Me.PercentageLBL.Name = "PercentageLBL"
        Me.PercentageLBL.Size = New System.Drawing.Size(35, 31)
        Me.PercentageLBL.TabIndex = 3
        Me.PercentageLBL.Text = "%"
        '
        'Timer1
        '
        '
        'Splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.ClientSize = New System.Drawing.Size(575, 320)
        Me.Controls.Add(Me.Progress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Splash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Progress.ResumeLayout(False)
        Me.Progress.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Progress As Guna.UI2.WinForms.Guna2CircleProgressBar
    Friend WithEvents PercentageLBL As Label
    Friend WithEvents Timer1 As Timer
End Class
