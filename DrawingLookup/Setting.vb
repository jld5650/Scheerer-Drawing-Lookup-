Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.Common
Imports System.IO
Imports System.Data

Public Class Setting

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles dbFileBtn.Click
        dbFileDia.ShowDialog()
    End Sub

    Private Sub dbFileDia_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dbFileDia.FileOk
        dbFileTxt.Text = dbFileDia.FileName

    End Sub

    Private Sub dfFolder_OK(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dfFileDia.Disposed
        dfFileTxt.Text = dfFileDia.SelectedPath
    End Sub


    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Hide()
    End Sub

    Private Sub acceptBtn_Click(sender As Object, e As EventArgs) Handles acceptBtn.Click
        My.Settings.dbFileString = dbFileTxt.Text
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

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

        Dim dbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Password=;User ID=Admin;Data Source=" + dbFileTxt.Text + "")
        Dim canConnect As Boolean
        Try
            dbConn.Open()
        Catch
            'NOTHING NEEDED HERE
        Finally
            If dbConn.State = ConnectionState.Open Then
                canConnect = True
                dbConn.Close()
                dbConn.Dispose()
            Else
                dbConn.Dispose()
                canConnect = False

            End If
        End Try
        If canConnect = True Then
            MsgBox("Connection Successful!", MsgBoxStyle.OkOnly)

        Else
            MsgBox("Connection Failed", MsgBoxStyle.Exclamation)
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
End Class