<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setting2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Setting2))
        Me.dbFileDia = New System.Windows.Forms.OpenFileDialog()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.acceptBtn = New System.Windows.Forms.Button()
        Me.dfFileBtn = New System.Windows.Forms.Button()
        Me.dfFileTxt = New System.Windows.Forms.TextBox()
        Me.dfFileLbl = New System.Windows.Forms.Label()
        Me.dfFileDia2 = New System.Windows.Forms.OpenFileDialog()
        Me.dfFileDia = New System.Windows.Forms.FolderBrowserDialog()
        Me.changePass = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(334, 84)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 3
        Me.cancelBtn.Text = "Exit"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'acceptBtn
        '
        Me.acceptBtn.Location = New System.Drawing.Point(253, 84)
        Me.acceptBtn.Name = "acceptBtn"
        Me.acceptBtn.Size = New System.Drawing.Size(75, 23)
        Me.acceptBtn.TabIndex = 4
        Me.acceptBtn.Text = "Accept"
        Me.acceptBtn.UseVisualStyleBackColor = True
        '
        'dfFileBtn
        '
        Me.dfFileBtn.Location = New System.Drawing.Point(286, 10)
        Me.dfFileBtn.Name = "dfFileBtn"
        Me.dfFileBtn.Size = New System.Drawing.Size(123, 20)
        Me.dfFileBtn.TabIndex = 5
        Me.dfFileBtn.Text = "Browse..."
        Me.dfFileBtn.UseVisualStyleBackColor = True
        '
        'dfFileTxt
        '
        Me.dfFileTxt.Location = New System.Drawing.Point(111, 11)
        Me.dfFileTxt.Name = "dfFileTxt"
        Me.dfFileTxt.Size = New System.Drawing.Size(168, 20)
        Me.dfFileTxt.TabIndex = 6
        '
        'dfFileLbl
        '
        Me.dfFileLbl.AutoSize = True
        Me.dfFileLbl.Location = New System.Drawing.Point(12, 13)
        Me.dfFileLbl.Name = "dfFileLbl"
        Me.dfFileLbl.Size = New System.Drawing.Size(81, 13)
        Me.dfFileLbl.TabIndex = 7
        Me.dfFileLbl.Text = "Drawing Folder:"
        '
        'dfFileDia2
        '
        Me.dfFileDia2.FileName = "OpenFileDialog1"
        '
        'dfFileDia
        '
        '
        'changePass
        '
        Me.changePass.Location = New System.Drawing.Point(12, 84)
        Me.changePass.Name = "changePass"
        Me.changePass.Size = New System.Drawing.Size(123, 23)
        Me.changePass.TabIndex = 8
        Me.changePass.Text = "Change Password"
        Me.changePass.UseVisualStyleBackColor = True
        '
        'Setting2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 119)
        Me.ControlBox = False
        Me.Controls.Add(Me.changePass)
        Me.Controls.Add(Me.dfFileLbl)
        Me.Controls.Add(Me.dfFileTxt)
        Me.Controls.Add(Me.dfFileBtn)
        Me.Controls.Add(Me.acceptBtn)
        Me.Controls.Add(Me.cancelBtn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(437, 158)
        Me.MinimumSize = New System.Drawing.Size(437, 158)
        Me.Name = "Setting2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dbFileDia As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cancelBtn As System.Windows.Forms.Button
    Friend WithEvents acceptBtn As System.Windows.Forms.Button
    Friend WithEvents dfFileBtn As System.Windows.Forms.Button
    Friend WithEvents dfFileTxt As System.Windows.Forms.TextBox
    Friend WithEvents dfFileLbl As System.Windows.Forms.Label
    Friend WithEvents dfFileDia2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dfFileDia As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents changePass As System.Windows.Forms.Button
End Class
