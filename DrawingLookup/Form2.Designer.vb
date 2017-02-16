<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.userTxt = New System.Windows.Forms.TextBox()
        Me.roleTxt = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.syncFrm = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(206, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Full View and Edit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'userTxt
        '
        Me.userTxt.Location = New System.Drawing.Point(12, 12)
        Me.userTxt.Name = "userTxt"
        Me.userTxt.ReadOnly = True
        Me.userTxt.Size = New System.Drawing.Size(100, 20)
        Me.userTxt.TabIndex = 1
        '
        'roleTxt
        '
        Me.roleTxt.Location = New System.Drawing.Point(118, 12)
        Me.roleTxt.Name = "roleTxt"
        Me.roleTxt.ReadOnly = True
        Me.roleTxt.Size = New System.Drawing.Size(100, 20)
        Me.roleTxt.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 67)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(206, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Full View"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 96)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(206, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Partial View"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 125)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(206, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Change Password"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'syncFrm
        '
        Me.syncFrm.Location = New System.Drawing.Point(12, 154)
        Me.syncFrm.Name = "syncFrm"
        Me.syncFrm.Size = New System.Drawing.Size(206, 23)
        Me.syncFrm.TabIndex = 6
        Me.syncFrm.Text = "Sync Files"
        Me.syncFrm.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(232, 212)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(8, 8)
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = CType(resources.GetObject("PictureBox1.ErrorImage"), System.Drawing.Image)
        Me.PictureBox1.Image = Global.DrawingLookup.My.Resources.Resources.ScheererBearing_PMSlogo1
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(58, 183)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(215, 100)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(227, 261)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.syncFrm)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.roleTxt)
        Me.Controls.Add(Me.userTxt)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(243, 300)
        Me.MinimumSize = New System.Drawing.Size(243, 300)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents userTxt As System.Windows.Forms.TextBox
    Friend WithEvents roleTxt As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents syncFrm As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
