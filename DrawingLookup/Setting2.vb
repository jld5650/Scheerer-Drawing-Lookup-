Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.Common
Imports System.IO
Imports System.Data

Public Class Setting2

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        dbFileDia.ShowDialog()
    End Sub

   
    Private Sub dfFolder_OK(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dfFileDia.Disposed
        dfFileTxt.Text = dfFileDia.SelectedPath
    End Sub


    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Hide()
    End Sub

    Private Sub acceptBtn_Click(sender As Object, e As EventArgs) Handles acceptBtn.Click

        My.Settings.drawingFolder = dfFileTxt.Text
        My.Settings.Save()
        Me.Close()


    End Sub

    Private Sub dfFileBtn_Click(sender As Object, e As EventArgs) Handles dfFileBtn.Click
        dfFileDia.Description = "Select the Digitized Drawing folder"
        dfFileDia.ShowDialog(Me)
        If dfFileDia.SelectedPath <> Nothing Then
            dfFileTxt.Text = dfFileDia.SelectedPath
        End If
    End Sub

    
    Private Sub dfFileDia_HelpRequest(sender As Object, e As EventArgs) Handles dfFileDia.HelpRequest

    End Sub

    Private Sub Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Setting_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub drawFolderBtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub changePass_Click(sender As Object, e As EventArgs) Handles changePass.Click
        ChangePassword.ShowDialog()

    End Sub

    Private Sub dfFileTxt_TextChanged(sender As Object, e As EventArgs) Handles dfFileTxt.TextChanged

    End Sub
End Class