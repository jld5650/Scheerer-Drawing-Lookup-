<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings
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
        Me.dbStringDia = New System.Windows.Forms.OpenFileDialog()
        Me.dataFileBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'dataFileBtn
        '
        Me.dataFileBtn.Location = New System.Drawing.Point(356, 168)
        Me.dataFileBtn.Name = "dataFileBtn"
        Me.dataFileBtn.Size = New System.Drawing.Size(110, 23)
        Me.dataFileBtn.TabIndex = 0
        Me.dataFileBtn.Text = "Choose Data File"
        Me.dataFileBtn.UseVisualStyleBackColor = True
        '
        'settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 373)
        Me.Controls.Add(Me.dataFileBtn)
        Me.Name = "settings"
        Me.Text = "Form3"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dbStringDia As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dataFileBtn As System.Windows.Forms.Button
End Class
