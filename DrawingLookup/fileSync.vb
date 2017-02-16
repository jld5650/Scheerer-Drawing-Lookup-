Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.Common
Imports System.IO
Imports System.Data
Public Class fileSync
   

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim isDir2 = (System.IO.Directory.Exists(pushTxt.Text))
        Dim isDir1 = (System.IO.Directory.Exists(syncTxt.Text))
        If (isDir2 = False) Or (isDir1 = False) Then
            MsgBox("Both text boxes must have a valid folder")
        Else
            My.Settings.pushFolder = pushTxt.Text
            My.Settings.syncFolder = syncTxt.Text
            My.Settings.logFolder = logTxt.Text
            My.Settings.Save()
            Me.Close()

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub fileSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pushTxt.Text = My.Settings.pushFolder
        syncTxt.Text = My.Settings.syncFolder
        logTxt.Text = My.Settings.logFolder
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LogBrowserDialog.Description = "Select the folder to send the text logs(errors) to"
        LogBrowserDialog.ShowDialog(Me)
        If LogBrowserDialog.SelectedPath <> Nothing Then
            logTxt.Text = LogBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SyncBrowserDialog.Description = "Select the folder to sync from"
        SyncBrowserDialog.ShowDialog(Me)
        If SyncBrowserDialog.SelectedPath <> Nothing Then
            syncTxt.Text = SyncBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PushBrowserDialog.Description = "Select the folder to push bad files to"
        PushBrowserDialog.ShowDialog(Me)
        If PushBrowserDialog.SelectedPath <> Nothing Then
            pushTxt.Text = PushBrowserDialog.SelectedPath
        End If
    End Sub
End Class
