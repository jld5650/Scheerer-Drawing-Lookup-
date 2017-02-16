Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.Common
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D.LinearGradientBrush
Imports System.Drawing.Drawing2D
Imports Org.apache.pdfbox.pdmodel
Imports Org.apache.pdfbox.util
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports System.Text
Imports System.Runtime.InteropServices
Public Class ChangePassword
    Public Role = Login.Role
    Public User = Login.User
    Dim dsUserNames As New DataSet("UserNames")
    Dim daUserNames As New OleDbDataAdapter("SELECT * FROM userinfo", dbConn)
    Dim dbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=" + My.Settings.dbFileString + ";Jet OLEDB:Database Password=ad89sb;")
    Dim userTables As DataTableCollection
    Dim selectRowQuery
    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  
    End Sub

    Private Sub newPasswordTxt_TextChanged(sender As Object, e As EventArgs) Handles newPasswordTxt.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If newPasswordTxt.Text = passwordConfirmTxt.Text Then
            selectRowQuery = "UPDATE [userInfo] SET [userPassword] = ? WHERE userName = @ID"
            Dim cmd As New OleDbCommand(selectRowQuery, dbConn)
            cmd.Parameters.AddWithValue("?", newPasswordTxt.Text)
            cmd.Parameters.AddWithValue("@ID", User.ToString)
            If newPasswordTxt.Text.Length >= 4 Then
                dbConn.Open() 'OPEN------------
                cmd.ExecuteNonQuery()
                dbConn.Close()
                MsgBox("Password Changed!", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Password should be at least 4 characters.", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Passwords don't match.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class