<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fileSync
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fileSync))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.syncTxt = New System.Windows.Forms.TextBox()
        Me.pushTxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PushBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.SyncBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.LogBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.logTxt = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(317, 107)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Accept"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'syncTxt
        '
        Me.syncTxt.Location = New System.Drawing.Point(82, 14)
        Me.syncTxt.Name = "syncTxt"
        Me.syncTxt.Size = New System.Drawing.Size(229, 20)
        Me.syncTxt.TabIndex = 1
        '
        'pushTxt
        '
        Me.pushTxt.Location = New System.Drawing.Point(82, 39)
        Me.pushTxt.Name = "pushTxt"
        Me.pushTxt.Size = New System.Drawing.Size(229, 20)
        Me.pushTxt.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sync Folder"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Push Folder"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(317, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Browse"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(317, 37)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Browse"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(236, 107)
        Me.Button5.Name = "Button5"
        Me.Button5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "Cancel"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(317, 62)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Browse"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Log Folder"
        '
        'logTxt
        '
        Me.logTxt.Location = New System.Drawing.Point(82, 65)
        Me.logTxt.Name = "logTxt"
        Me.logTxt.Size = New System.Drawing.Size(230, 20)
        Me.logTxt.TabIndex = 9
        '
        'fileSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 142)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.logTxt)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pushTxt)
        Me.Controls.Add(Me.syncTxt)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(423, 181)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(423, 181)
        Me.Name = "fileSync"
        Me.Text = "Sync Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents syncTxt As System.Windows.Forms.TextBox
    Friend WithEvents pushTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PushBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SyncBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents LogBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents logTxt As System.Windows.Forms.TextBox
End Class
