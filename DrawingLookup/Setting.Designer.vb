<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Setting))
        Me.dbFileBtn = New System.Windows.Forms.Button()
        Me.dbFileTxt = New System.Windows.Forms.TextBox()
        Me.dbFileDia = New System.Windows.Forms.OpenFileDialog()
        Me.dbFileLbl = New System.Windows.Forms.Label()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.acceptBtn = New System.Windows.Forms.Button()
        Me.dfFileBtn = New System.Windows.Forms.Button()
        Me.dfFileTxt = New System.Windows.Forms.TextBox()
        Me.dfFileLbl = New System.Windows.Forms.Label()
        Me.dfFileDia2 = New System.Windows.Forms.OpenFileDialog()
        Me.dfFileDia = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'dbFileBtn
        '
        Me.dbFileBtn.Location = New System.Drawing.Point(422, 33)
        Me.dbFileBtn.Name = "dbFileBtn"
        Me.dbFileBtn.Size = New System.Drawing.Size(123, 23)
        Me.dbFileBtn.TabIndex = 0
        Me.dbFileBtn.Text = "Browse..."
        Me.dbFileBtn.UseVisualStyleBackColor = True
        '
        'dbFileTxt
        '
        Me.dbFileTxt.Location = New System.Drawing.Point(107, 35)
        Me.dbFileTxt.Name = "dbFileTxt"
        Me.dbFileTxt.Size = New System.Drawing.Size(309, 20)
        Me.dbFileTxt.TabIndex = 1
        '
        'dbFileDia
        '
        '
        'dbFileLbl
        '
        Me.dbFileLbl.AutoSize = True
        Me.dbFileLbl.Location = New System.Drawing.Point(12, 38)
        Me.dbFileLbl.Name = "dbFileLbl"
        Me.dbFileLbl.Size = New System.Drawing.Size(75, 13)
        Me.dbFileLbl.TabIndex = 2
        Me.dbFileLbl.Text = "Database File:"
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(385, 167)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 3
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'acceptBtn
        '
        Me.acceptBtn.Location = New System.Drawing.Point(470, 167)
        Me.acceptBtn.Name = "acceptBtn"
        Me.acceptBtn.Size = New System.Drawing.Size(75, 23)
        Me.acceptBtn.TabIndex = 4
        Me.acceptBtn.Text = "Accept"
        Me.acceptBtn.UseVisualStyleBackColor = True
        '
        'dfFileBtn
        '
        Me.dfFileBtn.Location = New System.Drawing.Point(422, 103)
        Me.dfFileBtn.Name = "dfFileBtn"
        Me.dfFileBtn.Size = New System.Drawing.Size(123, 23)
        Me.dfFileBtn.TabIndex = 5
        Me.dfFileBtn.Text = "Browse..."
        Me.dfFileBtn.UseVisualStyleBackColor = True
        Me.dfFileBtn.Visible = False
        '
        'dfFileTxt
        '
        Me.dfFileTxt.Location = New System.Drawing.Point(107, 105)
        Me.dfFileTxt.Name = "dfFileTxt"
        Me.dfFileTxt.Size = New System.Drawing.Size(309, 20)
        Me.dfFileTxt.TabIndex = 6
        Me.dfFileTxt.Visible = False
        '
        'dfFileLbl
        '
        Me.dfFileLbl.AutoSize = True
        Me.dfFileLbl.Location = New System.Drawing.Point(12, 107)
        Me.dfFileLbl.Name = "dfFileLbl"
        Me.dfFileLbl.Size = New System.Drawing.Size(81, 13)
        Me.dfFileLbl.TabIndex = 7
        Me.dfFileLbl.Text = "Drawing Folder:"
        Me.dfFileLbl.Visible = False
        '
        'dfFileDia2
        '
        Me.dfFileDia2.FileName = "OpenFileDialog1"
        '
        'dfFileDia
        '
        '
        'Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 202)
        Me.ControlBox = False
        Me.Controls.Add(Me.dfFileLbl)
        Me.Controls.Add(Me.dfFileTxt)
        Me.Controls.Add(Me.dfFileBtn)
        Me.Controls.Add(Me.acceptBtn)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.dbFileLbl)
        Me.Controls.Add(Me.dbFileTxt)
        Me.Controls.Add(Me.dbFileBtn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(569, 241)
        Me.MinimumSize = New System.Drawing.Size(569, 241)
        Me.Name = "Setting"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dbFileBtn As System.Windows.Forms.Button
    Friend WithEvents dbFileTxt As System.Windows.Forms.TextBox
    Friend WithEvents dbFileDia As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dbFileLbl As System.Windows.Forms.Label
    Friend WithEvents cancelBtn As System.Windows.Forms.Button
    Friend WithEvents acceptBtn As System.Windows.Forms.Button
    Friend WithEvents dfFileBtn As System.Windows.Forms.Button
    Friend WithEvents dfFileTxt As System.Windows.Forms.TextBox
    Friend WithEvents dfFileLbl As System.Windows.Forms.Label
    Friend WithEvents dfFileDia2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dfFileDia As System.Windows.Forms.FolderBrowserDialog
End Class
