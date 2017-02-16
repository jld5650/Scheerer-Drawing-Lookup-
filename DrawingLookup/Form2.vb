Public Class Form2
    Dim session As frmLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ChildForm As New viewDrawing
        ChildForm.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.userTxt.Text = Login.User
        Me.roleTxt.Text = Login.Role
        My.Settings.drawingFolder = My.Settings.pushFolder
        ' My.Settings.drawingFolder = "\\sbengsvr\ScheererEngineering\Digitized Drawings"
        My.Settings.Save()

    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ChildForm As New viewDrawingPartial
        ChildForm.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ChildForm As New viewDrawingSales
        ChildForm.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        settingLogin.Show()
    End Sub

    Private Sub syncFrm_Click(sender As Object, e As EventArgs) Handles syncFrm.Click
        syncForm.Show()
    End Sub
End Class