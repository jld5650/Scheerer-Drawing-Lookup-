Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.Common
Imports System.IO
Imports System.Data

Public Class syncForm
    Dim Month As String
    Dim Day As String
    Dim Year As String
    Public dateString As String
    Public finalDate As String
    Public drawingType As String
    Dim ocmdAboutVBCommand As OleDbCommand
    Dim odtrAboutVBDataReader As OleDbDataReader
    Public drawing As String
    Public files As String
    Dim errorCount

    Public Sub DisplayOleDbErrorCollection(exception As OleDbException)
        Dim i As Integer

        For i = 0 To exception.Errors.Count - 1
            Console.WriteLine("Index #" + i.ToString() + ControlChars.Cr _
               + "Message: " + exception.Errors(i).Message + ControlChars.Cr _
               + "Native: " + exception.Errors(i).NativeError.ToString() + ControlChars.Cr _
               + "Source: " + exception.Errors(i).Source + ControlChars.Cr _
               + "SQL: " + exception.Errors(i).SQLState + ControlChars.Cr)
        Next i
    End Sub
    Function IsAssembly(ByRef value As String) As Boolean
        Return Regex.IsMatch(value, "[-][A][D][-]\d{6}[-][R][E][V][ABCDEFGHIJKLMN0][.](?i)[p][d][f](?-i)")
    End Function
    Function IsComponent(ByRef value As String) As Boolean
        Return Regex.IsMatch(value, "[-][P][D][-]\d{6}[-][R][E][V][ABCDEFGHIJKLMN0][.](?i)[p][d][f](?-i)")
    End Function
    Function IsRoller(ByRef value As String) As Boolean
        Return Regex.IsMatch(value, "[-][R][D][-]\d{6}[-][R][E][V][ABCDEFGHIJKLMN0][.](?i)[p][d][f](?-i)")
    End Function
    Function IsVendor(ByRef value As String) As Boolean
        Return Regex.IsMatch(value, "[-][V][D][-]\d{6}[-][R][E][V][ABCDEFGHIJKLMN0][.](?i)[p][d][f](?-i)")
    End Function
    Function IsCage(ByRef value As String) As Boolean
        Return Regex.IsMatch(value, "[-][X][D][-]\d{6}[-][R][E][V][ABCDEFGHIJKLMN0][.](?i)[p][d][f](?-i)")
    End Function
    Function IsFinish(ByRef value As String) As Boolean
        Return Regex.IsMatch(value, "[-][F][D][-]\d{6}[-][R][E][V][ABCDEFGHIJKLMN0][.](?i)[p][d][f](?-i)")
    End Function
    Function IsMachine(ByRef value As String) As Boolean
        Return Regex.IsMatch(value, "[-][M][D][-]\d{6}[-][R][E][V][ABCDEFGHIJKLMN0][.](?i)[p][d][f](?-i)")
    End Function
    Function IsCustomer(ByRef value As String) As Boolean
        Return Regex.IsMatch(value, "[-][C][D][-]\d{6}[-][R][E][V][ABCDEFGHIJKLMN0][.](?i)[p][d][f](?-i)")
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Settings.syncFolder = Nothing Then
            MsgBox("All sync settings must have a folder")
        ElseIf My.Settings.pushFolder = Nothing Then
            MsgBox("All sync settings must have a folder")
        ElseIf My.Settings.logFolder = Nothing Then
            MsgBox("All sync settings must have a folder")
        Else
            Button1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
            Button2.Enabled = True
            settingBtn.Enabled = False
            Label1.Visible = True
        End If
    End Sub

    Private Sub settingBtn_Click(sender As Object, e As EventArgs) Handles settingBtn.Click
        fileSync.Show()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'System.IO.File.WriteAllText("C:\Users\owner\Desktop\log.txt", "")

        My.Settings.newLogFile = My.Settings.logFolder + "\" + "drawingSync--" + DateTime.Now.ToString("yyyyMMdd") & "_" & DateTime.Now.ToString("HHmmss")
        My.Settings.Save()
        System.IO.File.WriteAllText(My.Settings.newLogFile + ".txt", "")
        'Data Source=\\sbcfs1\data\DB BE\Database2_be_be_be.mdb;

        Dim dsUsers As New DataSet("Users")
        Dim dbConn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;User ID=Admin;Jet OLEDB:Database Password=ad89sb;Data Source=" + My.Settings.dbFileString + ";")
        Dim daUsers As New OleDbDataAdapter("SELECT * FROM partnames", dbConn)
        'Data Source=\\sbcfs1\data\DB BE\Database2_be_be_be.mdb;")
        ' C:\Users\jorged\Desktop\DatabaseScheerer_be_be
        ' Jet OLEDB:Database Password=ad89sb;
        'Define each column to map
        Dim dcmID As New DataColumnMapping("partID", "partID")
        Dim dcmPartName As New DataColumnMapping("partName", "partName")
        Dim dcmType As New DataColumnMapping("drawingType", "drawingType")
        Dim dcmLink As New DataColumnMapping("drawingLink", "drawingLink")
        Dim dcmRevision As New DataColumnMapping("drawingRevision", "drawingRevision")
        Dim dcmDate As New DataColumnMapping("drawingDate", "drawingDate")
        Dim dcmBook As New DataColumnMapping("bookName", "bookName")
        Dim dcmfile As New DataColumnMapping("fileName", "fileName")

        'Define the table containing the mapped columns
        Dim dtmUsers As New DataTableMapping("Table", "partnames")
        dtmUsers.ColumnMappings.Add(dcmID)
        dtmUsers.ColumnMappings.Add(dcmPartName)
        dtmUsers.ColumnMappings.Add(dcmType)
        dtmUsers.ColumnMappings.Add(dcmLink)
        dtmUsers.ColumnMappings.Add(dcmRevision)
        dtmUsers.ColumnMappings.Add(dcmDate)
        dtmUsers.ColumnMappings.Add(dcmBook)
        dtmUsers.ColumnMappings.Add(dcmfile)

        'Activate the mapping mechanism
        daUsers.TableMappings.Add(dtmUsers)

        'Fill the dataset
        daUsers.Fill(dsUsers)

        ' Declare a command builder to create SQL instructions
        ' to create and updat   e records.
        Dim cb As New OleDbCommandBuilder(daUsers)

        'Getting all files within a folder
        'Dim sDirectory = "\\sbengsvr\ScheererEngineering\Digitized Drawings"
        Dim sDirectory = My.Settings.syncFolder
        'sNextFile = Dir$(sDirectory + "\s \*.PDF")

        Dim drawings() As String = System.IO.Directory.GetFiles( _
                           sDirectory, _
                           "*.PDF", _
                           System.IO.SearchOption.AllDirectories)

        Dim con As New OleDb.OleDbConnection

        'Looping Through Each File
        'While sNextFile <> ""
        Dim drawingCount = 0
        errorCount = 0
        For Each drawing As String In drawings
            ' ProgressBar1.Maximum = drawings.Length
            drawingCount += 1
            BackgroundWorker1.ReportProgress((drawingCount / drawings.Length) * 100)
            files = drawing
            If (IsCustomer(drawing) = True OrElse IsComponent(drawing) OrElse IsMachine(drawing) = True OrElse IsVendor(drawing) = True OrElse IsRoller(drawing) = True OrElse IsFinish(drawing) = True OrElse IsAssembly(drawing) = True OrElse IsCage(drawing) = True) Then

                'GETTING THE DIRECTORY THAT CONTAINS THE FILE THUS GETTING THE BOOK NUMBER
                Dim drawingFile = Path.GetFileNameWithoutExtension(drawing)
                Dim sFullPath = sDirectory + "\" + drawingFile
                Dim drawingName = drawingFile + ".pdf"
                'Dim split As String() = drawing.Split("\")
                'Dim parentFolder As String = split(split.Length - 2)
                ''Console.WriteLine("THIS IS BOOK : " + parentFolder)

                'Dim drawingName As String = split(split.Length - 1)
                ''Console.WriteLine("THIS IS BOOK : " + parentFolder)
                'Dim parentPath = "\" + parentFolder + "\" + drawingName

                ' Console.WriteLine(IsMachine(drawing))
                '  Console.WriteLine("FILE NAME: " + drawing)
                '  Console.WriteLine(Rev)
                If IsMachine(drawing) = True Then drawingType = "Machine"
                If IsFinish(drawing) = True Then drawingType = "Finish"
                If IsAssembly(drawing) = True Then drawingType = "Assembly"
                If IsCage(drawing) = True Then drawingType = "Cage"
                If IsVendor(drawing) = True Then drawingType = "Vendor"
                If IsRoller(drawing) = True Then drawingType = "Roller"
                If IsCustomer(drawing) = True Then drawingType = "Customer"
                If IsComponent(drawing) = True Then drawingType = "Component"

                'Regex Algorithms
                '---------------------------------------------------------------------------------------------------------------------------------
                Dim Revision As Match = Regex.Match(drawing, "(?<=(REV))[ABCDEFGHIJKLMN0]")
                Dim Rev As String = Revision.Value
                Dim match As Match = Regex.Match(drawingName, "^.*(?=[-][AMVRXCPF][D][-]\d{6}[-][R][E][V][ABCDEFGHIJKLMN0][.](?i)[p][d][f](?-i))")
                Dim dateTrim As Match = Regex.Match(drawingName, "[-][AMVXRCFP][D][-]\d{6}[-][R][E][V][ABCDEFGHIJKLMN0]")
                Dim dateMatch As Match = Regex.Match(dateTrim.Value, "\d{6}")
                dateString = dateMatch.Value
                'Spacing Dates into segments
                '----------------------------------------------------------------------------------------------------------------------------------
                Dim parts(dateString.Length \ 2 - 1) As String
                For x As Integer = 0 To dateString.Length - 1 Step 2
                    parts(x \ 2) = dateString.Substring(x, 2)
                Next
                dateString = String.Join(" ", parts)

                'Splitting MM/DD/YY into array using Regex
                Dim dateArray() As String = Regex.Split(dateString, "\D+")
                Month = dateArray(0)
                Day = dateArray(1)

                If dateArray(2) >= 0 And dateArray(2) < 16 Then
                    Year = 20 & dateArray(2)
                Else
                    Year = 19 & dateArray(2)
                End If

                Try
                    finalDate = New DateTime(Year, Month, Day, 0, 0, 0)
                Catch ex As System.ArgumentOutOfRangeException
                    DirAppend.ErrorHandler(ex.ToString, drawing, dateArray, finalDate)
                    errorCount += 1
                    '  ProgressBar1.Value += 1

                End Try
                'DirAppend.Main()
                '-----------------------------------------------------------------------------------------------------------------------
                'Inserting Data Into Access
                If match.Success Then
                    Try
                        Dim sql = "INSERT INTO partnames( partName, drawingType, " & _
                    "drawingRevision, drawingDate, fileName) " & _
                    "VALUES (?, ?, ?, ?, ?)"

                        Using cmd = New OleDb.OleDbCommand(sql, dbConn)
                            cmd.Parameters.AddWithValue("@p1", match.Value)
                            cmd.Parameters.AddWithValue("@p2", drawingType)
                            cmd.Parameters.AddWithValue("@p3", Rev)
                            cmd.Parameters.AddWithValue("@p4", finalDate)
                            cmd.Parameters.AddWithValue("@p5", drawingName)

                            'cmd.Parameters.AddWithValue("@p8", Date.Now)
                            dbConn.Open() 'OPEN------------
                            cmd.ExecuteNonQuery()
                            dbConn.Close()
                            Try
                                My.Computer.FileSystem.MoveFile(My.Settings.syncFolder + "\" + drawingName, My.Settings.pushFolder + "\" + drawingName, False)
                            Catch ex As Exception
                                DirAppend.ErrorHandler(ex.ToString, drawing, dateArray, finalDate)
                                errorCount += 1
                            End Try

                        End Using

                    Catch ex As OleDbException
                        'This is a method created in syncForm'
                        'DisplayOleDbErrorCollection(ex)
                        DirAppend.ErrorHandler(ex.ToString, drawing.ToString, dateArray.ToString, finalDate.ToString)
                        errorCount += 1
                        dbConn.Close()
                    End Try
                    ' ProgressBar1.Value += 1
                    dateArray = Nothing
                End If
                '------------------------------------------------------------------------------------------------------------------------
            Else
                Dim ex As String = "FilePath doesn't match required pattern"
                DirAppend.ErrorHandlerNoDate(ex.ToString, drawing)
                errorCount += 1
                'ProgressBar1.Value += 1

            End If

            'drawing = Dir$()

            finalDate = Nothing
        Next
        My.Settings.drawingFolder = My.Settings.pushFolder
        ' My.Settings.drawingFolder = "\\sbengsvr\ScheererEngineering\Digitized Drawings"
        My.Settings.Save()
        'Console.ReadKey()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage

        Label1.Text = e.ProgressPercentage.ToString() + "%"

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled = True Then
            MsgBox("Sync cancelled")
            ProgressBar1.Value = 0
            If errorCount = 0 Then
            ElseIf errorCount = 1 Then
                MsgBox("There is " + errorCount.ToString + " error. Check the log file for more info.")
            Else
                MsgBox("There are " + errorCount.ToString + " errors. Check the log file for more info.")
            End If

        ElseIf e.Error IsNot Nothing Then
            MessageBox.Show(e.Error.Message)
        Else
            If errorCount = 0 Then
                MsgBox("Sync complete")
            ElseIf errorCount = 1 Then
                MsgBox("Sync complete. There is " + errorCount.ToString + " error. Check the log file for more info.")
            Else
                MsgBox("Sync complete. There are " + errorCount.ToString + " errors. Check the log file for more info.")
            End If
        End If
        Button1.Enabled = True
        Button2.Enabled = False
        settingBtn.Enabled = True

    End Sub

    Private Sub syncForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Visible = False
        Button2.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BackgroundWorker1.CancelAsync()
    End Sub
End Class
Class DirAppend
    Public Shared Sub Main()
        Using w As StreamWriter = File.AppendText(My.Settings.newLogFile + ".txt")
            'Log(syncForm.drawing, syncForm.finalDate, w)

        End Using
        'Using r As StreamReader = File.OpenText("log.txt")
        '    DumpLog(r)
        'End Using
    End Sub
    Public Shared Sub ErrorHandler(ex, fileName, dateString, fileDate)

        Using w As StreamWriter = File.AppendText(My.Settings.newLogFile + ".txt")
            errorLog(fileName, dateString, fileDate, w, ex)
        End Using

        'Using r As StreamReader = File.OpenText("log.txt")
        '    DumpLog(r)
        'End Using
    End Sub
    Public Shared Sub ErrorHandlerNoDate(ex, fileName)

        Using w As StreamWriter = File.AppendText(My.Settings.newLogFile + ".txt")
            errorLogNoDate(ex, fileName, w)
        End Using

        'Using r As StreamReader = File.OpenText("log.txt")
        '    DumpLog(r)
        'End Using
    End Sub
    Public Shared Sub errorLog(fileName As String, dateString As String, fileDate As String, w As TextWriter, ex As String)
        w.Write(vbCrLf + "Log Entry : ")
        w.WriteLine("{0}", DateTime.Now.ToLongTimeString())
        w.WriteLine(" File Path :{0}", fileName)
        w.WriteLine(" Drawing Date :{0}", fileDate)
        w.WriteLine(" Error: {0}", ex)
        w.WriteLine("-------------------------------")
    End Sub
    Public Shared Sub errorLogNoDate(ex As String, fileName As String, w As TextWriter)
        w.Write(vbCrLf + "Log Entry : ")
        w.WriteLine("{0}", DateTime.Now.ToLongTimeString())
        w.WriteLine(" File Path :{0}", fileName)
        w.WriteLine(" Error: {0}", ex)
        w.WriteLine("-------------------------------")
    End Sub
    

    Public Shared Sub DumpLog(r As StreamReader)
        Dim line As String
        line = r.ReadLine()
        While Not (line Is Nothing)
            Console.WriteLine(line)
            line = r.ReadLine()
        End While
    End Sub
End Class
