Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.Common
Imports System.IO
Imports System.Data
Imports System.Drawing.Drawing2D.LinearGradientBrush
'Global User As String
Public Class settingLogin

    Public User As String
    Public Role As String
    Public Id As Integer
    Dim passwordTrials As Integer
    Public userRoleMatch As String
    Dim currProfile As New frmLogin()
    ' Dim JdbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; User ID=Admin;Data Source=" + My.Settings.dbFileString + ";Jet OLEDB:Database Password=ad89sb;")
    Private Sub logInBtn_Click(sender As Object, e As EventArgs) Handles logInBtn.Click
        Dim dbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; User ID=Admin;Data Source=" + My.Settings.dbFileString + ";Jet OLEDB:Database Password=ad89sb;")
        If My.Settings.dbFileString <> vbNullString Then
            Try
                ' Dim login = Me.UserInfoTableAdapter1.UserNameInputString(userNameTxt.Text, passwordTxt.Text)

                'Define the table containing the mapped columns

                'dbConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password =ad89sbb; User ID=Admin;Data Source=" + My.Settings.dbFileString + ""
                ' dbConn.Properties("Jet OLEDB:Database Password") = "ad89sb"
                Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM userInfo", dbConn)
                Dim dcmID As New DataColumnMapping("ID", "ID")
                Dim dcmUserName As New DataColumnMapping("userName", "userName")
                Dim dcmUserPassword As New DataColumnMapping("userPassword", "userPassword")
                Dim dcmUserRole As New DataColumnMapping("userRole", "userRole")
                Dim dtmUsers As New DataTableMapping("Table", "userInfo")
                dtmUsers.ColumnMappings.Add(dcmID)
                dtmUsers.ColumnMappings.Add(dcmUserName)
                dtmUsers.ColumnMappings.Add(dcmUserPassword)
                dtmUsers.ColumnMappings.Add(dcmUserRole)

                da.TableMappings.Add(dtmUsers)

                Dim dsUsers As DataSet = New DataSet()
                da.Fill(dsUsers)


            Catch ex As OleDbException

                MsgBox(ex.Message + " Check Connection Setting")

            Catch ex As Exception
                MsgBox(ex.Message + "")
                Stop
            End Try
        Else
            MsgBox("Connection String is Empty")

        End If
        'This will specify that we are passing query from application
        Try
            dbConn.Open()
            'case insensitive login query, just using for testing
            'Dim loginQuery = "SELECT COUNT(*) AS Result, userName, userPassword, userRole FROM userInfo GROUP BY userName, userPassword, userRole HAVING (userName = @userName) AND (userPassword = @userPass) AND (COUNT(*) = 1)"
            'case sensitive login query
            Dim loginQuery = "SELECT COUNT(*) AS Result, userName, userPassword, userRole FROM userInfo GROUP BY userName, userPassword, userRole HAVING StrComp(userName, @userName, 0)=0 AND StrComp(userPassword, @userPass, 0)=0 AND (COUNT(*) = 1)"
            Dim loginCommand = New OleDbCommand(loginQuery, dbConn)
            loginCommand.Parameters.Add("@userName", OleDbType.VarChar, 255).Value = userNameTxt.Text.Trim()
            loginCommand.Parameters.Add("@userPass", OleDbType.VarChar, 255).Value = passwordTxt.Text.Trim()

            ' Execute Scalar command (hence: retrieves the single result from login query)
            Dim loginMatch = loginCommand.ExecuteScalar()

            If (loginMatch = 0) Then
                MsgBox("Wrong User Crendentials", MsgBoxStyle.Critical)
                userNameTxt.Text = ""
                passwordTxt.Text = ""
                passwordTrials = passwordTrials + 1
                If passwordTrials > 3 Then
                    MsgBox("Access Denied", MsgBoxStyle.Critical)

                End If
            Else

                MsgBox("Access Granted", MsgBoxStyle.Information)
                Dim userTypeQuery = "SELECT userRole FROM userInfo WHERE (userName = @userName) AND (userPassword = @userPass)"
                Dim userTypeCommand = New OleDbCommand(userTypeQuery, dbConn)
                userTypeCommand.Parameters.Add("@userName", OleDbType.VarChar, 255).Value = userNameTxt.Text.Trim()
                userTypeCommand.Parameters.Add("@userPass", OleDbType.VarChar, 255).Value = passwordTxt.Text.Trim()
                Dim frm As frmLogin = New frmLogin
                'Execute Scalar command (hence: retrieves the single result from user query)
                userRoleMatch = userTypeCommand.ExecuteScalar()

                frm.currentLogin(userNameTxt.Text, userRoleMatch)

                'Admin Form Open
                If (userRoleMatch = "Admin") Then

                    User = userNameTxt.Text
                    Role = userRoleMatch
                    My.Settings.Username = User
                    My.Settings.Role = Role
                    Setting2.dfFileTxt.Enabled = True
                    Setting2.dfFileBtn.Enabled = True
                    Setting2.dfFileLbl.Enabled = True
                    Setting2.dfFileTxt.Text = My.Settings.drawingFolder
                    Me.Hide()
                    ChangePassword.Show()

                ElseIf (userRoleMatch = "Vice Admin") Then

                    User = userNameTxt.Text
                    Role = userRoleMatch

                    My.Settings.Username = User
                    My.Settings.Role = Role

                    Me.Hide()
                    ChangePassword.Show()
                    Setting2.dfFileTxt.Enabled = True
                    Setting2.dfFileBtn.Enabled = True
                    Setting2.dfFileLbl.Enabled = True
                    Setting2.dfFileTxt.Text = My.Settings.drawingFolder

                ElseIf (userRoleMatch = "Sales") Then
                    User = userNameTxt.Text
                    Role = userRoleMatch
                 
                    My.Settings.Username = User
                    My.Settings.Role = Role

                    Me.Hide()
                    ChangePassword.Show()
                    Setting2.dfFileTxt.Enabled = False
                    Setting2.dfFileBtn.Enabled = False
                    Setting2.dfFileLbl.Enabled = False
                End If

            End If
            dbConn.Close()

        Catch ex As Exception
            MsgBox(ex.Message + "")

        Finally
            dbConn.Dispose()
        End Try
    End Sub

    Private Sub EnterClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode.Equals(Keys.Enter) Then
            Me.logInBtn.PerformClick()
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AcceptButton = logInBtn
    End Sub


End Class
