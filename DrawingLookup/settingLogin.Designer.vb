<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settingLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(settingLogin))
        Me.userNameLbl = New System.Windows.Forms.Label()
        Me.passwordLbl = New System.Windows.Forms.Label()
        Me.userNameTxt = New System.Windows.Forms.TextBox()
        Me.passwordTxt = New System.Windows.Forms.TextBox()
        Me.logInBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'userNameLbl
        '
        Me.userNameLbl.AutoSize = True
        Me.userNameLbl.Location = New System.Drawing.Point(19, 13)
        Me.userNameLbl.Name = "userNameLbl"
        Me.userNameLbl.Size = New System.Drawing.Size(60, 13)
        Me.userNameLbl.TabIndex = 0
        Me.userNameLbl.Text = "User Name"
        '
        'passwordLbl
        '
        Me.passwordLbl.AutoSize = True
        Me.passwordLbl.Location = New System.Drawing.Point(19, 52)
        Me.passwordLbl.Name = "passwordLbl"
        Me.passwordLbl.Size = New System.Drawing.Size(53, 13)
        Me.passwordLbl.TabIndex = 1
        Me.passwordLbl.Text = "Password"
        '
        'userNameTxt
        '
        Me.userNameTxt.Location = New System.Drawing.Point(22, 29)
        Me.userNameTxt.Name = "userNameTxt"
        Me.userNameTxt.Size = New System.Drawing.Size(263, 20)
        Me.userNameTxt.TabIndex = 2
        '
        'passwordTxt
        '
        Me.passwordTxt.Location = New System.Drawing.Point(22, 68)
        Me.passwordTxt.Name = "passwordTxt"
        Me.passwordTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordTxt.Size = New System.Drawing.Size(263, 20)
        Me.passwordTxt.TabIndex = 3
        Me.passwordTxt.UseSystemPasswordChar = True
        '
        'logInBtn
        '
        Me.logInBtn.Location = New System.Drawing.Point(22, 105)
        Me.logInBtn.Name = "logInBtn"
        Me.logInBtn.Size = New System.Drawing.Size(263, 29)
        Me.logInBtn.TabIndex = 4
        Me.logInBtn.Text = "Log In"
        Me.logInBtn.UseVisualStyleBackColor = True
        '
        'settingLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 165)
        Me.Controls.Add(Me.logInBtn)
        Me.Controls.Add(Me.passwordTxt)
        Me.Controls.Add(Me.userNameTxt)
        Me.Controls.Add(Me.passwordLbl)
        Me.Controls.Add(Me.userNameLbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(335, 204)
        Me.MinimumSize = New System.Drawing.Size(335, 204)
        Me.Name = "settingLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log In"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents userNameLbl As System.Windows.Forms.Label
    Friend WithEvents passwordLbl As System.Windows.Forms.Label
    Friend WithEvents userNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents passwordTxt As System.Windows.Forms.TextBox
    Friend WithEvents logInBtn As System.Windows.Forms.Button


End Class
