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



Public Class viewDrawingPartial
    Dim newFile As String
    Dim authCell = 12
    Dim partsQuery = "SELECT partnames.partID AS [ID], partnames.partName AS [Part Name], userInfo.userName AS [Author], partnames.drawingType As [Type], partnames.drawingDate AS [Date], partnames.drawingRevision AS [Revision], partnames.bookName AS [Book],  partnames.uploadUser AS [Upload User],  partnames.uploadDate AS [Upload Date], partnames.lastUpdateTime AS [Last Update], partnames.lastUpdateUser  AS [Last Update User],  partnames.fileName AS [File Path], userInfo.ID AS [User ID], partnames.drawingAuthor AS [Author ID] FROM userInfo RIGHT JOIN partnames ON userInfo.[ID] = partnames.[drawingAuthor]"
    Public Role = Login.Role
    Public User = Login.User
    Dim dsPartNames As New DataSet("PartNames")
    Dim dsUserNames As New DataSet("UserNames")
    Dim dbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=" + My.Settings.dbFileString + ";Jet OLEDB:Database Password=ad89sb;")
    Dim dbQuery As String
    Dim daUserNames As New OleDbDataAdapter("SELECT * FROM userinfo", dbConn)
    'Dim daPartNames As New OleDbDataAdapter("SELECT * FROM partNames", dbConn)
    Dim daPartNames As New OleDbDataAdapter(partsQuery, dbConn)
    'Dim daUsers As New OleDbDataAdapter(dbQuery, dbConn)
    Dim tables As DataTableCollection
    Dim userTables As DataTableCollection
    Dim drawingSelectionDataSet = New DataSet
    Dim pdfAvailable As Boolean
    'SELECT p.ID, p.partName, p.drawingType, p.drawingAuthor, p.drawingDate, p.drawingRevision, p.bookName, p.uploadDate,  p.drawingLink, u.ID
    'FROM partNames
    'INNER JOIN userInfo
    'ON p.ID=u.ID

    Dim id
    Dim UserId
    Dim filePath
    Dim partName
    Dim drawingType
    Dim drawingRevision
    Dim drawingDate
    Dim selectedType
    Dim selectedRev

    Dim file1 ' original file on record with extension included already
    Dim file2 ' original file concatenated with extension from drawing folder setting
    Dim file3 ' original file on record without extension or concatenation  

    'comboboxValues--
    Dim key As String
    Dim value As String
    '--

    Dim selectCellClickPartQuery As String = "Select * from partnames"
    Dim selectCellClickUserQuery As String
    Dim cmd = New OleDbCommand(selectCellClickPartQuery, dbConn)
    Dim userCmd = New OleDbCommand(selectCellClickUserQuery, dbConn)
    Dim dtUserSelected = New DataSet
    Dim drawingSelectionAdapter = New OleDbDataAdapter(cmd)
    Dim daUserSelected = New OleDbDataAdapter(userCmd)

    Dim selectRowQuery As String
    Dim selectUserQuery As String
    Private WithEvents mHook As New MouseHook
    Dim source1 As New BindingSource
    Dim loadCheck As Boolean
    Dim x As Integer
    Dim xy As Integer
    Dim currentFile

    'VVV==========================================FORM LOAD==============================================VVV
    Public Function ExtractTextFromPdf(ByVal path As String)

        Dim its As ITextExtractionStrategy = New iTextSharp.text.pdf.parser.LocationTextExtractionStrategy
        Dim reader As PdfReader
        ' path = "C:\Users\jorged\Downloads\pdf-test.pdf"

        If FileExists(path) = True Then
            Dim isDir As Boolean
            isDir = (System.IO.Directory.Exists(path))
            If isDir = False Then
                reader = New PdfReader(path)
                Using reader

                    Dim text As StringBuilder = New StringBuilder()

                    Dim i As Integer
                    For i = 1 To reader.NumberOfPages Step i + 1

                        Dim thePage As String = PdfTextExtractor.GetTextFromPage(reader, i, its)
                        Dim theLines As String()
                        theLines = thePage.Split("\n")

                        For Each theLine As String In theLines
                            text.AppendLine(theLine)
                        Next

                    Next

                    Return reader.NumberOfPages
                End Using
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function
    Private Sub viewDrawing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Try
        Me.MinimumSize = New System.Drawing.Size(Me.Width, Me.Height)
        ' no larger than screen size
        ' me.MaximumSize = new System.Drawing.Size((int)System.Windows.SystemParameters.PrimaryScreenWidth, (int)System.Windows.SystemParameters.PrimaryScreenHeight)
        Me.AutoSize = True
        Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.WindowState = FormWindowState.Maximized
        tables = dsPartNames.Tables
        daUserNames.Fill(dsUserNames)
        daPartNames.Fill(dsPartNames)
        cmd.CommandText = selectCellClickPartQuery
        drawingSelectionAdapter.Fill(drawingSelectionDataSet)
        Dim view As New DataView(tables(0))
        source1.DataSource = view
        DataGridView1.DataSource = source1

        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add("0", "--Select User--")
        For Each dr As DataRow In dsUserNames.Tables(0).Rows
            Dim Name = dr("userName")
            Dim Val = dr("ID")
            comboSource.Add(Val, Name)
        Next
        'Sets combobox Items/Values
        'authorCbx.SelectedInex = 0
        authorCbx.DataSource = New BindingSource(comboSource, Nothing)
        authorCbx.DisplayMember = "Value"
        authorCbx.ValueMember = "Key"
        key = DirectCast(authorCbx.SelectedItem, KeyValuePair(Of String, String)).Key
        value = DirectCast(authorCbx.SelectedItem, KeyValuePair(Of String, String)).Value
        authorCbx.SelectedIndex = 0 ' --Select User--
        loadCheck = True
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        '    'Finally
        '    '    SplitContainer1.Enabled = False
        '    'End Try
        If My.Settings.horizontalSplit IsNot "" And My.Settings.verticalSplit IsNot "" Then
            SplitContainer2.SplitterDistance = Convert.ToInt32(My.Settings.horizontalSplit)
            SplitContainer1.SplitterDistance = Convert.ToInt32(My.Settings.verticalSplit)
        Else
        End If

        SplitContainer2.IsSplitterFixed = False
        SplitContainer1.IsSplitterFixed = False

    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        Dim work = Screen.FromControl(Me).WorkingArea
        Me.Top = work.Top
        Me.Left = work.Left - work.Width / 6
        Me.Width = work.Width / 2
        Me.Height = work.Height
        MyBase.OnLoad(e)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub SplitContainer2_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer2.Panel1.Paint

    End Sub
    Private Function FileExists(ByVal sFileName As String) As Boolean
        Dim intReturn As Integer

        On Error GoTo FileExists_Error
        intReturn = GetAttr(sFileName)
        FileExists = True

        Exit Function
FileExists_Error:
        FileExists = False
    End Function
    Function IsRootFile(ByRef value As String) As Boolean
        Return Regex.IsMatch(value, "([A-Z][:][\\])")
    End Function
    Public Function driveFinder(ByVal file As String) As String
        Dim driveLetter = Regex.Match(My.Settings.drawingFolder, "([A-Z][:][\\])").Value

        Return Regex.Replace(file, "([A-Z][:][\\])", driveLetter)
    End Function

    Public Function getId(ByVal partId As String)
        id = partId
        selectCellClickPartQuery = "Select partID, drawingLink, drawingType, drawingRevision, partName, drawingType, drawingRevision, drawingDate, fileName from partnames where partId=" + id + ""

        Return partId
    End Function
    Public Function getUserId(ByVal useId As String)
        UserId = useId
        selectCellClickUserQuery = "SELECT ID from userinfo WHERE id =" + useId + ""
        Return useId
    End Function

    'SELECT DRAWING LOAD PDF
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        DataGridView1.BeginEdit(False)
        If (e.RowIndex <> -1) Then
            If (DataGridView1(0, e.RowIndex).Value Is DBNull.Value) Then
                DataGridView1.Enabled = False
                MsgBox("This row is empty", MsgBoxStyle.Critical)
                DataGridView1.Enabled = True
            Else
                getUserId(Me.DataGridView1(authCell, e.RowIndex).Value.ToString())
                getId(Me.DataGridView1(0, e.RowIndex).Value.ToString())

                cmd.CommandText = selectCellClickPartQuery
                dbConn.Open()
                If (UserId <> "") Then
                    userCmd.CommandText = selectCellClickUserQuery
                    userCmd.ExecuteNonQuery()
                    daUserSelected.Fill(dtUserSelected)
                    authorCbx.SelectedValue = UserId
                Else
                    authorCbx.SelectedIndex = 0
                End If
                cmd.ExecuteNonQuery()
                dbConn.Close()
                drawingSelectionDataSet.Clear()
                drawingSelectionAdapter.Fill(drawingSelectionDataSet)

                clearError()

                For Each dr As DataRow In drawingSelectionDataSet.Tables(0).Rows
                    currentFile = fileAssign(dr("fileName"))
                    'AxAcroPDF1.setCurrentPage("flag")
                    drawingType = dr("drawingType").ToString
                    drawingRevision = dr("drawingRevision").ToString
                    'selectedType = typeCbx.FindString(drawingType)
                    selectedType = drawingType
                    selectedRev = revCbx.FindString(drawingRevision)
                    partTxt.Text = dr("partName").ToString
                    typeCbx.Text = dr("drawingType").ToString 'selected Type
                    revCbx.Text = dr("drawingRevision").ToString 'selected Revison
                    DateTimePicker1.Value = dr("drawingDate").ToString
                Next

                DataGridView1.Rows(e.RowIndex).Cells(1).Selected = True
                DataGridView1.Select()

                DataGridView1.BeginEdit(True)
                Label9.Text = "Number of Pages: " + ExtractTextFromPdf(currentFile.ToString).ToString
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles pdfViewer1.Click

        If (SplitContainer1.Panel2Collapsed = True) Then

            SplitContainer1.Panel2Collapsed = False

        ElseIf (SplitContainer1.Panel2Collapsed = False) Then

            SplitContainer1.Panel2Collapsed = True
        End If
    End Sub

    Public Function searchText(ByVal search As String) As String
        If (search.Length < 2) Then
            Return partsQuery
        Else
            Dim sql As String = partsQuery
            sql &= " WHERE partNames.partName LIKE '%' + @search + '%' "
            Return sql
        End If

    End Function

    Private Sub browseBtn_Click(sender As Object, e As EventArgs)
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        fileTxtVD.Text = OpenFileDialog1.SafeFileName
    End Sub

   
    Private Sub AxAcroPDF2_OnError(sender As Object, e As EventArgs) Handles AxAcroPDF2.OnError

    End Sub

    Private Sub pdfViewer2_Click(sender As Object, e As EventArgs) Handles pdfViewer2.Click
        If AxAcroPDF2.Visible = True Then
            AxAcroPDF2.Hide()
            DataGridView1.Show()
            SplitContainer2.SplitterDistance = My.Settings.horizontalSplit
        ElseIf AxAcroPDF2.Visible = False Then
            AxAcroPDF2.Show()
            DataGridView1.Hide()
            SplitContainer2.SplitterDistance = My.Settings.horizontalSplit
        End If
    End Sub

    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        If (DataGridView1.CurrentCell IsNot Nothing) Then
            AxAcroPDF1.Enabled = False
            DataGridView1.Focus()
            Dim z As Integer
            Dim zy As Integer
            z = DataGridView1.CurrentCell.RowIndex
            If (DataGridView1(0, z).Value Is DBNull.Value) Then
                DataGridView1.Enabled = False
                MsgBox("This row is empty", MsgBoxStyle.Critical)
                DataGridView1.Enabled = True
            Else
                zy = DataGridView1.Rows(z).Cells(0).Value
                If zy = xy Then
                Else
                    x = DataGridView1.CurrentCell.RowIndex
                    xy = DataGridView1.Rows(x).Cells(0).Value

                    If (DataGridView1.Rows(x).Cells(0).Value <> -1) Then

                        getUserId(DataGridView1.Rows(x).Cells(authCell).Value.ToString())
                        getId(DataGridView1.Rows(x).Cells(0).Value.ToString())

                        cmd.CommandText = selectCellClickPartQuery
                        dbConn.Open() 'OPEN------------
                        If (UserId <> "") Then
                            userCmd.CommandText = selectCellClickUserQuery
                            userCmd.ExecuteNonQuery()
                            daUserSelected.Fill(dtUserSelected)
                            authorCbx.SelectedValue = UserId
                        Else
                            If authorCbx.SelectedIndex < 0 Then

                            Else
                                authorCbx.SelectedIndex = 0
                            End If
                        End If
                        cmd.ExecuteNonQuery()
                        dbConn.Close()
                        drawingSelectionDataSet.Clear()
                        drawingSelectionAdapter.Fill(drawingSelectionDataSet)
                        For Each dr As DataRow In drawingSelectionDataSet.Tables(0).Rows
                            fileAssign(dr("fileName"))
                            drawingType = dr("drawingType").ToString
                            drawingRevision = dr("drawingRevision").ToString
                            selectedType = drawingType
                            selectedRev = revCbx.FindString(drawingRevision)
                            partTxt.Text = dr("partName").ToString
                            typeCbx.Text = dr("drawingType").ToString 'selected Type
                            revCbx.Text = dr("drawingRevision").ToString 'selected Revison
                            DateTimePicker1.Value = dr("drawingDate").ToString
                        Next
                    End If
                End If
            End If
        End If

    End Sub
    Public Function fileAssign(ByVal drawingLink As String)

        If (IsRootFile(drawingLink) = True) Then
            file1 = driveFinder(drawingLink).ToString

            If FileExists(file1) = True Then 'Check if File Exist - with "P:" drive replacement
                pdfAvailable = AxAcroPDF1.LoadFile(file1)

                If pdfAvailable = True Then 'Check if PDF file is available
                    AxAcroPDF1.LoadFile(file1)

                    fileTxtVD.Text = file1
                    file2 = Nothing
                    file3 = Nothing
                    Return file1
                Else
                    AxAcroPDF1.LoadFile(file1)

                    fileTxtVD.Text = file1
                    file2 = ""
                    file3 = ""
                    fileTxtVD.Text = drawingLink.ToString
                    MsgBox("File exists but it is not available. It is either open in another" & vbCrLf & "application or it is not a pdf file '.pdf'", MsgBoxStyle.Critical)
                    Return file1
                End If
            Else
                file1 = drawingLink.ToString
                If FileExists(file1) = True Then 'Check if File Exist - without "P:" drive replacement
                    pdfAvailable = AxAcroPDF1.LoadFile(file1)

                    If pdfAvailable = True Then 'Check if PDF file is available
                        AxAcroPDF1.LoadFile(file1)

                        fileTxtVD.Text = file1
                        Return file1
                    Else
                        AxAcroPDF1.LoadFile(file1)

                        fileTxtVD.Text = file1
                        fileTxtVD.Text = drawingLink.ToString
                        MsgBox("File exists but it is not available. It is either open in another" & vbCrLf & "application or it is not a pdf file '.pdf'", MsgBoxStyle.Critical)
                        Return file1
                    End If

                Else
                    fileTxtVD.Text = drawingLink.ToString
                    AxAcroPDF1.LoadFile(file1)

                    MsgBox("File could not be found. Check file path.", MsgBoxStyle.Critical) ' No File Found
                    Return file1
                End If
            End If
        Else
            file2 = My.Settings.drawingFolder + "\" + drawingLink.ToString
            file3 = drawingLink.ToString
            file1 = Nothing
            If FileExists(file2) = True Then
                pdfAvailable = AxAcroPDF1.LoadFile(file2)

                If pdfAvailable = True Then 'Check if PDF file is available
                    AxAcroPDF1.LoadFile(file2)

                    fileTxtVD.Text = drawingLink.ToString
                    Return file2
                Else

                    AxAcroPDF1.LoadFile(file2)


                    fileTxtVD.Text = drawingLink.ToString
                    MsgBox("File exists but it is not available. It is either open in another" & vbCrLf & "application or it is not a pdf file '.pdf'", MsgBoxStyle.Critical)
                    Return file2
                End If
            Else
                AxAcroPDF1.LoadFile(file2)

                fileTxtVD.Text = drawingLink.ToString

                fileTxtVD.Text = drawingLink.ToString
                MsgBox("File could not be found. Check file path.", MsgBoxStyle.Critical)
                Return file2
            End If
        End If


    End Function
    Public Function fileUpdate(ByVal drawingLink As String)
        Dim isDir2 As Boolean
        Dim isDir As Boolean
        isDir2 = (System.IO.Directory.Exists(drawingLink))
        isDir = (System.IO.Directory.Exists(My.Settings.drawingFolder + "\" + drawingLink))

        If isDir = False And isDir2 = False Or drawingLink = "" Then
            If FileExists(My.Settings.drawingFolder + "\" + drawingLink) = True Or FileExists(drawingLink) = True Then
                Dim oldDate As DateTime = Me.DataGridView1(4, (DataGridView1.CurrentRow.Index)).Value
                Dim newDate As String = oldDate.Month.ToString("00") + oldDate.Day.ToString("00") + oldDate.ToString("yy")
                newFile = partTxt.Text + "-" + typeCbx.Text + "-" + newDate + "-REV" + revCbx.Text + ".pdf"
                If Me.DataGridView1(11, (DataGridView1.CurrentRow.Index)).Value = fileTxtVD.Text Then 'if record file is the same as file
                    ' Change "c:\test.txt" to the path and filename for the file that
                    ' you want to rename.
                    If IsRootFile(drawingLink) = False Then 'if record has a indvidual file and not a file path
                        Try
                            My.Computer.FileSystem.RenameFile(My.Settings.drawingFolder + "\" + Me.DataGridView1(11, (DataGridView1.CurrentRow.Index)).Value, newFile)
                            Return newFile
                        Catch ex As ArgumentNullException 'nothing in DB record and file input hasn't changed so no new file
                            newFile = Nothing
                            Return newFile
                        Catch ex As IOException ' SAME FILE but the its already just the file name so nothing changes

                            Return newFile
                        End Try
                    Else 'if its  a full file path
                        Try
                            My.Computer.FileSystem.RenameFile(Me.DataGridView1(11, (DataGridView1.CurrentRow.Index)).Value, newFile)
                            Return newFile
                        Catch ex As ArgumentNullException 'nothing in DB record and file input hasn't changed so no new file
                            newFile = Nothing
                            Return newFile
                        Catch ex As IOException ' SAME FILE so it replaces the filepath in the DB with just the file name
                            Return newFile
                        End Try
                    End If
                Else
                    If FileExists(My.Settings.drawingFolder + "\" + fileTxtVD.Text) = True Then
                        If IsRootFile(drawingLink) = False Then 'if record has an individual file and not a file path
                            Try
                                My.Computer.FileSystem.RenameFile(My.Settings.drawingFolder + "\" + Me.DataGridView1(11, (DataGridView1.CurrentRow.Index)).Value, fileTxtVD.Text)
                                Return newFile
                            Catch ex As ArgumentNullException 'nothing in DB record and file input has changed so no new file
                                Return newFile
                            Catch ex As FileNotFoundException
                                MsgBox("The file that was entered has not been found")
                                newFile = Nothing
                                Return newFile
                            Catch ex As IOException
                                MsgBox("The file that was entered already exists in the file system")
                                newFile = Nothing
                                Return newFile
                            End Try
                        Else
                            Try
                                My.Computer.FileSystem.RenameFile(Me.DataGridView1(11, (DataGridView1.CurrentRow.Index)).Value, fileTxtVD.Text)
                                Return newFile
                            Catch ex As ArgumentNullException 'nothing in DB record and file input has changed so no new file
                                Return newFile
                            Catch ex As FileNotFoundException
                                MsgBox("The file that was entered has not been found")
                                newFile = Nothing
                                Return newFile
                            Catch ex As IOException
                                MsgBox("The file that was entered already exists in the file system")
                                newFile = Nothing
                                Return newFile
                            End Try
                        End If
                    Else
                        MsgBox("The file entered does not exists in the Drawing Folder")
                        newFile = Nothing
                        Return newFile
                    End If
                End If
            Else
                MsgBox("The file does not exist and cannot be replaced")
                newFile = Nothing
                Return newFile
            End If
        Else
            newFile = Nothing
            Return newFile
        End If
    End Function
    Private Sub updateBtn_Click(sender As Object, e As EventArgs)
        If DataGridView1.SelectedCells.Count > 0 Then
            If checkNull(ErrorProvider1, partTxt, typeCbx, revCbx, fileTxtVD) Then
                Exit Sub
            Else
                Dim fileNameChanged As Boolean = False
                key = DirectCast(authorCbx.SelectedItem, KeyValuePair(Of String, String)).Key
                value = DirectCast(authorCbx.SelectedItem, KeyValuePair(Of String, String)).Value
                Dim id1 As Integer = (DataGridView1.CurrentRow.Index)
                Dim id As Integer = (DataGridView1.CurrentRow.Index)
                id = Me.DataGridView1(0, id).Value

                Dim oldDate As DateTime = Me.DataGridView1(4, (DataGridView1.CurrentRow.Index)).Value
                Dim newDate As String = oldDate.Month.ToString("00") + oldDate.Day.ToString("00") + oldDate.ToString("yy")
                newFile = partTxt.Text + "-" + typeCbx.Text + "-" + newDate + "-REV" + revCbx.Text + ".pdf"

                Dim date1 As String = CDate(Format(DateTimePicker1.Value, "M/d/yyyy"))
                If MessageBox.Show("Are you sure you want to update this record to: " & vbCrLf &
                  "Part Name: " & partTxt.Text & vbCrLf &
                  "Part Type: " & typeCbx.Text & vbCrLf &
                  "Revision: " & revCbx.Text & vbCrLf &
                  "Author: " & value & vbCrLf &
                  "Date: " & date1 & vbCrLf &
                  "File: " & newFile & vbCrLf & vbCrLf &
                  "From: " & vbCrLf & vbCrLf &
                   "Part Name: " & Me.DataGridView1(1, id1).Value & vbCrLf &
                   "Part Type: " & Me.DataGridView1(3, id1).Value & vbCrLf &
                    "Revision: " & Me.DataGridView1(5, id1).Value & vbCrLf &
                    "Author: " & Me.DataGridView1(2, id1).Value & vbCrLf &
                    "Date: " & Me.DataGridView1(4, id1).Value & vbCrLf &
                    "File: " & Me.DataGridView1(11, id1).Value & vbCrLf, "Update A Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

                    If fileUpdate(Me.DataGridView1(11, id1).Value) IsNot Nothing Then
                        If IsRootFile(newFile) = True Then
                            fileUpdate(newFile)
                        End If
                        selectRowQuery = "UPDATE [partnames] SET [partName] = ?, [drawingType] = ?, [drawingAuthor] =?, [fileName] = ?, [drawingRevision] = ?, [drawingDate] = ?, [lastUpdateTime] =?, [lastUpdateUser] = ? WHERE partID = @ID"
                        Dim cmd As New OleDbCommand(selectRowQuery, dbConn)
                        cmd.Parameters.AddWithValue("?", partTxt.Text)
                        cmd.Parameters.AddWithValue("?", typeCbx.Text)
                        If key = 0 Then
                            cmd.Parameters.AddWithValue("?", DBNull.Value)
                        Else
                            cmd.Parameters.AddWithValue("?", key)
                        End If
                        If Me.DataGridView1(11, id1).Value = fileTxtVD.Text Then
                            cmd.Parameters.AddWithValue("?", newFile)
                        Else
                            cmd.Parameters.AddWithValue("?", fileTxtVD.Text)
                        End If
                        cmd.Parameters.AddWithValue("?", revCbx.Text)
                        cmd.Parameters.AddWithValue("?", date1)
                        cmd.Parameters.AddWithValue("?", Date.Now.ToString)
                        cmd.Parameters.AddWithValue("?", My.Settings.Username)
                        cmd.Parameters.AddWithValue("@ID", id.ToString)

                        If file1 Is Nothing And file3 Is Nothing Then
                            MsgBox("A file path must be inserted before creating the record.", MsgBoxStyle.Exclamation)
                        Else
                            Dim match = drawingLinkMatch(file1, file3)
                            'if current drawingLink is equal to file1 or file3  (see file1/file3 instantiation)
                            If Me.DataGridView1(11, id1).Value = file1 Or Me.DataGridView1(11, id1).Value = file3 Then
                                If match = 1 Then
                                    'handle query
                                    Dim valls As String = Me.DataGridView1(11, id1).Value
                                    If newFile = valls Then 'if Drawing LINK text doesn't change
                                        dbConn.Open() 'OPEN------------
                                        cmd.ExecuteNonQuery()
                                        dbConn.Close()
                                    Else ' If it does change
                                        If IsRootFile(newFile) = True Then ' and its a root file --> (C://)
                                            Dim fileInput1 = driveFinder(newFile)
                                            Dim inputMatch = inputLinkMatch(fileInput1)
                                            If inputMatch = 1 Then 'if match was found in the db
                                                MsgBox("This file that you entered is a duplicate. Please insert a unique file path.", MsgBoxStyle.Exclamation)
                                            ElseIf inputLinkMatch(newFile) = 1 Then
                                                MsgBox("This file that you entered is a duplicate. Please insert a unique file path.", MsgBoxStyle.Exclamation)

                                            Else
                                                dbConn.Open() 'OPEN------------
                                                cmd.ExecuteNonQuery()
                                                dbConn.Close()
                                            End If

                                        Else 'if drawingLink text box was change and its not a root file 
                                            If inputLinkMatch(fileTxtVD.Text) = 1 Then
                                                MsgBox("This file that you entered is a duplicate. Please insert a unique file path.", MsgBoxStyle.Exclamation)
                                            Else
                                                dbConn.Open() 'OPEN------------
                                                cmd.ExecuteNonQuery()
                                                dbConn.Close()
                                            End If
                                        End If
                                    End If
                                Else
                                    dbConn.Open() 'OPEN------------
                                    cmd.ExecuteNonQuery()
                                    dbConn.Close()
                                End If
                            Else
                                If Me.DataGridView1(11, id1).Value <> file1 And Me.DataGridView1(11, id1).Value <> file3 Then
                                    If match = 0 Then
                                        dbConn.Open() 'OPEN------------
                                        cmd.ExecuteNonQuery()
                                        dbConn.Close()
                                    Else
                                        MsgBox("This file that you entered is a duplicate. Please insert a unique file path.", MsgBoxStyle.Exclamation)
                                    End If
                                End If

                            End If

                        End If

                        Dim cmd2 As New OleDbCommand
                        cmd2.Connection = dbConn
                        cmd2.CommandType = Data.CommandType.Text
                        cmd2.CommandText = partsQuery + " WHERE partName LIKE ?"
                        cmd2.Parameters.Add("@partName", OleDbType.VarChar).Value = partTxt.Text
                        Dim dsUsers2 As New DataSet("Users")
                        tables = dsUsers2.Tables
                        Dim daUsers2 As New OleDbDataAdapter(cmd2)
                        daUsers2.Fill(dsUsers2)
                        Dim view As New DataView(tables(0))
                        source1.DataSource = view
                        DataGridView1.DataSource = source1


                        For Each row As DataGridViewRow In DataGridView1.Rows
                            If DataGridView1.RowCount - 1 >= row.Index Then
                                Dim id2 = DataGridView1.Rows(row.Index).Cells(0).Value.ToString()
                                If id2 = id Then
                                    DataGridView1.Rows(row.Index).Selected = True
                                    fileAssign(DataGridView1.Rows(row.Index).Cells(11).Value.ToString())
                                    DataGridView1.CurrentCell = DataGridView1.Rows(row.Index).Cells(11)
                                    Exit For
                                End If
                            End If
                        Next
                    Else
                        MsgBox("newFile = nothing ")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If

            'DataGridView1.HorizontalScrollingOffset = DataGridView1.HorizontalScrollingOffset - 200
        Else
            MsgBox("No row selected", MsgBoxStyle.Exclamation)
        End If
        newFile = ""
    End Sub
    Public Function inputLinkMatch(ByVal matchQuery As String) As Integer
        Dim loginQuery = "SELECT Count(*) AS Expr1 FROM partnames WHERE drawingLink = @drawingLink"
        Dim loginCommand = New OleDbCommand(loginQuery, dbConn)
        If matchQuery Is Nothing Then
            matchQuery = "%%%%\w(?<!\w)%%%"
        End If
        loginCommand.Parameters.Add("@drawingLink", OleDbType.VarChar, 255).Value = matchQuery
        dbConn.Open() 'OPEN------------
        ' Execute Scalar command (hence: retrieves the single result from login query)
        Dim loginMatch = loginCommand.ExecuteScalar()
        dbConn.Close()
        Return loginMatch
    End Function

    Public Function drawingLinkMatch(ByVal matchQuery As String, ByVal matchQuery2 As String) As Integer
        Dim loginQuery = "SELECT Count(*) AS Expr1 FROM partnames WHERE drawingLink = @drawingLink or drawingLink = @drawingLink2"
        Dim loginCommand = New OleDbCommand(loginQuery, dbConn)
        Dim fileOne = matchQuery
        Dim fileThree = matchQuery2
        If matchQuery Is Nothing Then
            matchQuery = "%%%%\w(?<!\w)%%%"
        End If
        If matchQuery2 Is Nothing Then
            matchQuery2 = "%%\w(?<!\w)%%%%%"
        End If
        loginCommand.Parameters.Add("@drawingLink", OleDbType.VarChar, 255).Value = matchQuery
        loginCommand.Parameters.Add("@drawingLink2", OleDbType.VarChar, 255).Value = matchQuery2
        dbConn.Open() 'OPEN------------
        ' Execute Scalar command (hence: retrieves the single result from login query)
        Dim loginMatch = loginCommand.ExecuteScalar()
        dbConn.Close()
        If My.Settings.drawingFolder + file3 = fileOne Then
            loginMatch = loginMatch - 1
        End If
        Return loginMatch
    End Function

    Public Sub clearError()

        ErrorProvider1.SetError(partTxt, Nothing)
        ErrorProvider1.SetError(typeCbx, Nothing)
        ErrorProvider1.SetError(revCbx, Nothing)
        ErrorProvider1.SetError(fileTxtVD, Nothing)
    End Sub

    Public Function checkNull(ByVal err As ErrorProvider, ByVal ParamArray ct() As Control) As Boolean
        Dim str As String
        Dim i As Integer
        Dim b As Boolean
        For i = 0 To UBound(ct)
            If TypeOf ct(i) Is TextBox Or TypeOf ct(i) Is ComboBox Then
                If ct(i).Text = "" Then
                    str = ct(i).Name()
                    str = str.Remove(0, 3)
                    err.SetError(ct(i), "Field should not be empty")
                    ct(i).Focus()
                    b = True
                    Exit For
                Else
                    err.SetError(ct(i), Nothing)
                    b = False
                End If
            End If
        Next
        Return b


    End Function
    Private Sub createBtn_Click(sender As Object, e As EventArgs)

        If checkNull(ErrorProvider1, partTxt, typeCbx, revCbx, fileTxtVD) Then
            Exit Sub

        Else

            ' ErrorProvider1.SetError(fileTxtVD, IIf(.Text.Length = 0, "Required Field", ""))

            key = DirectCast(authorCbx.SelectedItem, KeyValuePair(Of String, String)).Key
            value = DirectCast(authorCbx.SelectedItem, KeyValuePair(Of String, String)).Value
            Dim loginQuery = "SELECT ID FROM userInfo WHERE [userName] = ?"
            Dim loginCommand = New OleDbCommand(loginQuery, dbConn)
            loginCommand.Parameters.AddWithValue("?", My.Settings.Username)
            dbConn.Open() 'OPEN------------
            Dim userId = loginCommand.ExecuteScalar()
            dbConn.Close()
            Dim date1 As String = CDate(Format(DateTimePicker1.Value, "M/d/yyyy"))
            Dim dateNow As String = CDate(Format(Date.Now, "M/d/yyyy"))
            Dim sql = "INSERT INTO partnames( partName, drawingType,  drawingAuthor, drawingLink, " & _
              "drawingRevision, drawingDate, uploadUser) " & _
              "VALUES (?, ?, ?, ?, ?, ?, ?)"

            If MessageBox.Show("Are you sure you want to create this record: " & vbCrLf &
                   "Part Name: " & partTxt.Text & vbCrLf &
                   "Part Type: " & typeCbx.Text & vbCrLf &
                   "Revision: " & revCbx.Text & vbCrLf &
                   "Author: " & value & vbCrLf &
                   "Date: " & date1 & vbCrLf &
                   "File: " & fileTxtVD.Text, "Create A Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

                Using cmd = New OleDb.OleDbCommand(sql, dbConn)
                    cmd.Parameters.AddWithValue("@p1", partTxt.Text)
                    cmd.Parameters.AddWithValue("@p2", typeCbx.Text)
                    If key = 0 Then
                        cmd.Parameters.AddWithValue("@p3", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@p3", key)
                    End If
                    cmd.Parameters.AddWithValue("@p4", fileTxtVD.Text)
                    cmd.Parameters.AddWithValue("@p5", revCbx.Text)
                    cmd.Parameters.AddWithValue("@p6", date1)
                    cmd.Parameters.AddWithValue("@p7", User)
                    'cmd.Parameters.AddWithValue("@p8", Date.Now)

                    'createForm.Show()
                    If fileTxtVD.Text = "" Then
                        MsgBox("A file path must be inserted before creating the record.", MsgBoxStyle.Exclamation)
                    Else
                        Dim fileInput1 = fileTxtVD.Text
                        ' Dim fileInput1 = driveFinder(fileTxtVD.Text)
                        Dim inputMatch = inputLinkMatch(fileInput1)
                        If inputMatch = 1 Then 'if match was found in the db
                            MsgBox("This file that you entered is a duplicate. Please insert a unique file path.", MsgBoxStyle.Exclamation)
                        Else
                            dbConn.Open() 'OPEN------------
                            cmd.ExecuteNonQuery()
                            dbConn.Close()

                            Dim cmd2 As New OleDbCommand
                            cmd2.Connection = dbConn
                            cmd2.CommandType = Data.CommandType.Text
                            cmd2.CommandText = partsQuery + " WHERE partName LIKE ?"
                            cmd2.Parameters.Add("@partName", OleDbType.VarChar).Value = partTxt.Text
                            Dim dsUsers2 As New DataSet("Users")
                            tables = dsUsers2.Tables
                            Dim daUsers2 As New OleDbDataAdapter(cmd2)
                            daUsers2.Fill(dsUsers2)
                            Dim view As New DataView(tables(0))
                            source1.DataSource = view
                            DataGridView1.DataSource = source1
                            'Catch ex As Exception
                            '    MsgBox(ex, MsgBoxStyle.Information)
                            'End Try
                            Dim MaxVal As Double = 0
                            For Each row As DataGridViewRow In DataGridView1.Rows
                                If row.Cells(0).Value > MaxVal Then
                                    MaxVal = row.Cells(0).Value
                                    DataGridView1.Rows(row.Index).Selected = True
                                End If
                            Next
                        End If
                    End If
                End Using
            Else
            End If
        End If
        Label9.Text = "Number of Pages: " + ExtractTextFromPdf(currentFile.ToString).ToString
    End Sub



    Private Sub SplitContainer1_Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles SplitContainer1.Panel2.MouseClick

        AxAcroPDF1.Enabled = False
        Me.ActiveControl = SplitContainer2.Panel2
        If e.Button = Windows.Forms.MouseButtons.Right Then
            nextPage.PerformClick()
        End If
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        AxAcroPDF1.Enabled = False
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs)

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick 'RIGHT CLICK FOR PDF
        If (e.RowIndex > -1) Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                DataGridView1.Rows(e.RowIndex).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(e.RowIndex).Cells(1)
                mnuCell.Show(DataGridView1, e.Location)
                mnuCell.Show(Cursor.Position)
            End If
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then 'If Right click on cell then...
            If (e.RowIndex <> -1) Then
                If (DataGridView1(0, e.RowIndex).Value Is DBNull.Value) Then
                    DataGridView1.Enabled = False
                    MsgBox("This row is empty", MsgBoxStyle.Critical)
                    DataGridView1.Enabled = True
                Else
                    getUserId(Me.DataGridView1(authCell, e.RowIndex).Value.ToString())
                    getId(Me.DataGridView1(0, e.RowIndex).Value.ToString())

                    cmd.CommandText = selectCellClickPartQuery
                    dbConn.Open()
                    If (UserId <> "") Then
                        userCmd.CommandText = selectCellClickUserQuery
                        userCmd.ExecuteNonQuery()
                        daUserSelected.Fill(dtUserSelected)
                        authorCbx.SelectedValue = UserId
                    Else
                        authorCbx.SelectedIndex = 0
                    End If
                    cmd.ExecuteNonQuery()
                    dbConn.Close()
                    drawingSelectionDataSet.Clear()
                    drawingSelectionAdapter.Fill(drawingSelectionDataSet)
                    clearError()

                    For Each dr As DataRow In drawingSelectionDataSet.Tables(0).Rows
                        currentFile = fileAssign(dr("fileName"))
                        drawingType = dr("drawingType").ToString
                        drawingRevision = dr("drawingRevision").ToString
                        'selectedType = typeCbx.FindString(drawingType)
                        selectedType = drawingType
                        selectedRev = revCbx.FindString(drawingRevision)
                        partTxt.Text = dr("partName").ToString
                        typeCbx.Text = dr("drawingType").ToString 'selected Type
                        revCbx.Text = dr("drawingRevision").ToString 'selected Revison
                        DateTimePicker1.Value = dr("drawingDate").ToString
                    Next
                End If
                Label9.Text = "Number of Pages: " + ExtractTextFromPdf(currentFile.ToString).ToString
            End If
        End If

    End Sub

    'Middle Mouse Click
    Private Sub DataGridView1_CellMouseDown_1(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown 'if scroll button is clicked
        If e.Button = Windows.Forms.MouseButtons.Middle Then
            If (e.RowIndex > -1) Then
                If (DataGridView1(0, e.RowIndex).Value Is DBNull.Value) Then
                    DataGridView1.Enabled = False
                    MsgBox("This row is empty", MsgBoxStyle.Critical)
                    DataGridView1.Enabled = True
                Else
                    Dim partId = Me.DataGridView1(0, e.RowIndex).Value.ToString()
                    dbConn.Open() 'OPEN------------
                    Dim selectPartQuery = "Select * From partnames WHERE partID=" + partId + ""
                    Dim partCmd = New OleDbCommand(selectPartQuery, dbConn)
                    partCmd.ExecuteNonQuery()
                    dbConn.Close() 'ClOSE----------
                    Dim dtPartSelected = New DataSet
                    Dim daPartSelected = New OleDbDataAdapter(partCmd)

                    daPartSelected.Fill(dtPartSelected)

                    For Each dr As DataRow In dtPartSelected.Tables(0).Rows
                        AxAcroPDF2.LoadFile(dr("fileName").ToString)
                        DataGridView1.Visible = False
                        AxAcroPDF2.Visible = True
                        If (IsRootFile(dr("fileName").ToString) = True) Then
                            Dim file12 = driveFinder(dr("fileName").ToString)

                            If FileExists(file12) = True Then 'Check if File Exist - with "P:" drive replacement
                                pdfAvailable = AxAcroPDF2.LoadFile(file12)

                                If pdfAvailable = True Then 'Check if PDF file is available
                                    AxAcroPDF2.LoadFile(file12)
                                    DataGridView1.Visible = False
                                    AxAcroPDF2.Visible = True
                                    Dim file22 = Nothing
                                    Dim file32 = Nothing

                                Else
                                    AxAcroPDF2.LoadFile(file12)
                                    DataGridView1.Visible = False
                                    AxAcroPDF2.Visible = True
                                    Dim file22 = ""
                                    Dim file32 = ""
                                    MsgBox("File exists but it is not available. It is either open in another" & vbCrLf & "application or it is not a pdf file '.pdf'", MsgBoxStyle.Critical)
                                End If

                            Else
                                file12 = dr("fileName").ToString
                                If FileExists(file12) = True Then 'Check if File Exist - without "P:" drive replacement
                                    pdfAvailable = AxAcroPDF2.LoadFile(file12)

                                    If pdfAvailable = True Then 'Check if PDF file is available
                                        AxAcroPDF2.LoadFile(file12)
                                        DataGridView1.Visible = False
                                        AxAcroPDF2.Visible = True

                                    Else
                                        AxAcroPDF2.LoadFile(file12)
                                        DataGridView1.Visible = False
                                        AxAcroPDF2.Visible = True
                                        MsgBox("File exists but it is not available. It is either open in another" & vbCrLf & "application or it is not a pdf file '.pdf'", MsgBoxStyle.Critical)
                                    End If

                                Else
                                    MsgBox("File could not be found. Check file path.", MsgBoxStyle.Critical) ' No File Found
                                End If

                            End If

                        Else
                            Dim file22 = My.Settings.drawingFolder + "\" + dr("fileName").ToString
                            Dim file32 = dr("fileName").ToString
                            Dim file12 = Nothing
                            If FileExists(file22) = True Then
                                pdfAvailable = AxAcroPDF2.LoadFile(file22)

                                If pdfAvailable = True Then 'Check if PDF file is available
                                    AxAcroPDF2.LoadFile(file22)
                                    DataGridView1.Visible = False
                                    AxAcroPDF2.Visible = True

                                Else
                                    AxAcroPDF2.LoadFile(file22)
                                    DataGridView1.Visible = False
                                    AxAcroPDF2.Visible = True
                                    MsgBox("File exists but it is not available. It is either open in another" & vbCrLf & "application or it is not a pdf file '.pdf'", MsgBoxStyle.Critical)
                                End If

                            Else
                                AxAcroPDF2.LoadFile(file22)
                                DataGridView1.Visible = False
                                AxAcroPDF2.Visible = True
                                MsgBox("File could not be found. Check file path.", MsgBoxStyle.Critical)
                            End If
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub mnuCell_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuCell.Opening
        '  If DataGridView1.Rows(index).IsNewRow Then
    End Sub
    'Search Text Changed >>
    Private Sub searchTxt_TextChanged_1(sender As Object, e As EventArgs) Handles searchTxt.TextChanged
        Timer1.Stop()
        Timer1.Start()

    End Sub
    'Search Text Changed Timer >>
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Cursor = Cursors.AppStarting
        Timer1.Stop()
        searchTxt.Enabled = False
        AxAcroPDF1.Enabled = False

        dbQuery = searchText(searchTxt.Text)
        Me.WindowState = FormWindowState.Maximized
        Dim dsUsers2 As New DataSet("Users")
        tables = dsUsers2.Tables
        Dim daUsers2 As New OleDbDataAdapter

        Dim searchCmd = New OleDb.OleDbCommand(dbQuery, dbConn)
        searchCmd.Parameters.AddWithValue("@search", searchTxt.Text)
        daUsers2.SelectCommand = searchCmd
        daUsers2.Fill(dsUsers2)
        Dim view As New DataView(tables(0))
        source1.DataSource = view
        DataGridView1.DataSource = source1
        '  If loadCheck = True Then
        If DataGridView1.CurrentCell IsNot Nothing Then
            Dim z As Integer
            Dim zy As Integer
            z = DataGridView1.CurrentCell.RowIndex
            zy = DataGridView1.Rows(z).Cells(0).Value
            If zy = xy Then
                'do nothing
            Else
                x = DataGridView1.CurrentCell.RowIndex
                xy = DataGridView1.Rows(x).Cells(0).Value
                If (DataGridView1.Rows(x).Cells(0).Value <> -1) Then
                    If (DataGridView1.Rows(x).Cells(0).Value Is DBNull.Value) Then
                        MsgBox("This row is empty", MsgBoxStyle.Critical)
                    Else
                        getUserId(DataGridView1.Rows(x).Cells(authCell).Value.ToString())
                        getId(DataGridView1.Rows(x).Cells(0).Value.ToString())
                        cmd.CommandText = selectCellClickPartQuery
                        dbConn.Open() 'OPEN------------
                        If (UserId <> "") Then
                            userCmd.CommandText = selectCellClickUserQuery
                            userCmd.ExecuteNonQuery()
                            daUserSelected.Fill(dtUserSelected)
                            authorCbx.SelectedValue = UserId
                        Else
                            If authorCbx.SelectedIndex < 0 Then

                            Else
                                authorCbx.SelectedIndex = 0
                            End If
                        End If
                        cmd.ExecuteNonQuery()
                        dbConn.Close()
                        drawingSelectionDataSet.Clear()
                        drawingSelectionAdapter.Fill(drawingSelectionDataSet)
                        For Each dr As DataRow In drawingSelectionDataSet.Tables(0).Rows
                            ' AxAcroPDF1.LoadFile(My.Settings.drawingFolder + dr("fileName").ToString)
                            If (IsRootFile(dr("fileName")) = True) Then
                                AxAcroPDF1.LoadFile(dr("fileName").ToString)
                            Else
                                AxAcroPDF1.LoadFile(My.Settings.drawingFolder + "\" + dr("fileName").ToString)
                            End If
                            fileAssign(dr("fileName").ToString)
                            fileTxtVD.Text = dr("fileName").ToString
                            drawingType = dr("drawingType").ToString
                            drawingRevision = dr("drawingRevision").ToString
                            'selectedType = typeCbx.FindString(drawingType)
                            selectedType = drawingType
                            selectedRev = revCbx.FindString(drawingRevision)
                            partTxt.Text = dr("partName").ToString
                            typeCbx.Text = dr("drawingType").ToString 'selected Type
                            revCbx.Text = dr("drawingRevision").ToString 'selected Revison
                            DateTimePicker1.Value = dr("drawingDate").ToString
                        Next
                        searchTxt.Enabled = True
                        Me.ActiveControl = Me.searchTxt
                        searchTxt.SelectionStart = searchTxt.TextLength
                        Cursor = Cursors.Arrow
                    End If
                End If
            End If
        Else
            searchTxt.Enabled = True
            Me.ActiveControl = Me.searchTxt
            searchTxt.SelectionStart = searchTxt.TextLength
            Cursor = Cursors.Arrow
        End If
        searchTxt.Enabled = True
        Me.ActiveControl = Me.searchTxt
        searchTxt.SelectionStart = searchTxt.TextLength
        Cursor = Cursors.Arrow
    End Sub

    Private Sub YeahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YeahToolStripMenuItem.Click
        Process.Start("explorer.exe", "/select," & currentFile)
    End Sub

    Private Sub DataGridView1_MouseHover(sender As Object, e As EventArgs) Handles DataGridView1.MouseHover
        If DataGridView1.Visible = True Then
            Me.ActiveControl = Me.DataGridView1
        End If
    End Sub
    Private Sub SplitContainer1_Panel2_MouseHover(sender As Object, e As EventArgs) Handles SplitContainer1.Panel2.MouseHover
        'ADMIN/FULL VIEWER RIGHTS
        AxAcroPDF1.Enabled = True
        Me.ActiveControl = Me.AxAcroPDF1
    End Sub
    Private Sub SplitContainer2_Panel2_MouseHover(sender As Object, e As EventArgs)
        'If DataGridView1.Visible = True Then
        'SplitContainer1.Panel2.Enabled = True
        'Me.ActiveControl = Me.AxAcroPDF1

        'End If
    End Sub
    Private Sub SplitContainer1_MouseHover(sender As Object, e As EventArgs) Handles SplitContainer1.MouseHover

    End Sub
    Private Sub SplitContainer1_Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles SplitContainer1.Panel2.MouseDown
        'SplitContainer1.Panel2.Enabled = False
        'Me.ActiveControl = Me.AxAcroPDF1

    End Sub

    Private Sub SplitContainer1_Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles SplitContainer1.Panel2.MouseUp
        ' SplitContainer1.Panel2.Enabled = True
        Me.ActiveControl = Me.AxAcroPDF1

    End Sub
    Private Sub SplitContainer1_Panel2_MouseEnter(sender As Object, e As EventArgs) Handles SplitContainer1.Panel2.MouseEnter
        SplitContainer1.Panel2.Enabled = True
        Me.ActiveControl = Me.AxAcroPDF1
        AxAcroPDF1.setShowToolbar(False)
        ' AxAcroPDFLib.AxAcroPDF.MouseButtons.Right()
    End Sub
    Private Sub SplitContainer2_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer2.SplitterMoved
        If (loadCheck = True) Then
            My.Settings.horizontalSplit = SplitContainer2.SplitterDistance.ToString

            My.Settings.Save()
        Else
            SplitContainer2.IsSplitterFixed = True
        End If
    End Sub
    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub
    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        If (loadCheck = True) Then
            My.Settings.verticalSplit = SplitContainer1.SplitterDistance.ToString
            My.Settings.Save()
        Else
            SplitContainer2.IsSplitterFixed = True
            SplitContainer1.IsSplitterFixed = True
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        AxAcroPDF1.gotoNextPage()
    End Sub

    Private Sub deleteBtn_Click(sender As Object, e As EventArgs)
        If DataGridView1.SelectedCells.Count > 0 Then

            Dim id1 As Integer = (DataGridView1.CurrentRow.Index)
            Dim id As Integer = (DataGridView1.CurrentRow.Index)
            id = Me.DataGridView1(0, id).Value

            Dim date1 As String = CDate(Format(DateTimePicker1.Value, "M/d/yyyy"))
            If MessageBox.Show("Are you sure you want to DELETE this record: " & vbCrLf &
              "Part Name: " & partTxt.Text & vbCrLf &
              "Part Type: " & typeCbx.Text & vbCrLf &
              "Revision: " & revCbx.Text & vbCrLf &
              "Author: " & value & vbCrLf &
              "Date: " & date1 & vbCrLf &
              "File: " & fileTxtVD.Text & vbCrLf & vbCrLf,
              "Delete A Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = MsgBoxResult.Yes Then

                Dim deleteRowQuery
                deleteRowQuery = "Delete * From partnames WHERE partID = @ID"
                DataGridView1.Refresh()
                Dim cmd As New OleDbCommand(deleteRowQuery, dbConn)

                cmd.Parameters.AddWithValue("@ID", id.ToString)

                dbConn.Open() 'OPEN------------
                cmd.ExecuteNonQuery()
                dbConn.Close()
                Dim cmd2 As New OleDbCommand
                cmd2.Connection = dbConn
                cmd2.CommandType = Data.CommandType.Text
                cmd2.CommandText = partsQuery '+ " WHERE partName LIKE ?"
                'cmd2.Parameters.Add("@partName", OleDbType.VarChar).Value = partTxt.Text
                Dim dsUsers2 As New DataSet("Users")
                tables = dsUsers2.Tables
                Dim daUsers2 As New OleDbDataAdapter(cmd2)
                daUsers2.Fill(dsUsers2)
                Dim view As New DataView(tables(0))
                source1.DataSource = view
                DataGridView1.DataSource = source1

                For Each row As DataGridViewRow In DataGridView1.Rows
                    If DataGridView1.RowCount - 1 >= row.Index Then
                        Dim id2 = DataGridView1.Rows(row.Index).Cells(0).Value.ToString()
                        If id2 = id + 1 Then
                            DataGridView1.Rows(row.Index).Selected = True
                            currentFile = fileAssign(DataGridView1.Rows(row.Index).Cells(11).Value.ToString())
                            DataGridView1.CurrentCell = DataGridView1.Rows(row.Index).Cells(11)
                            Exit For
                        End If
                    End If
                Next
                DataGridView1.Refresh()
                DataGridView1.ClearSelection()
            End If
            'DataGridView1.HorizontalScrollingOffset = DataGridView1.HorizontalScrollingOffset - 200

        Else
            MsgBox("No row selected", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub clearSrchBtn_Click(sender As Object, e As EventArgs) Handles clearSrchBtn.Click
        searchTxt.Clear()
        searchText("")
        Timer1.Stop()
        Timer1.Start()
    End Sub
    'Key Up (arrow key) Events>>
    Private Sub DataGridView1_KeyUp_1(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        If Me.DataGridView1.Focused = True Then
            Timer2.Start()
        End If
    End Sub
    'KeyUp Timer
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If (DataGridView1.CurrentCell IsNot Nothing) Then
            AxAcroPDF1.Enabled = False
            DataGridView1.Focus()
            Dim z As Integer
            Dim zy As Integer
            z = DataGridView1.CurrentCell.RowIndex
            If (DataGridView1(0, z).Value Is DBNull.Value) Then
                DataGridView1.Enabled = False
                MsgBox("This row is empty", MsgBoxStyle.Critical)
                DataGridView1.Enabled = True
            Else
                zy = DataGridView1.Rows(z).Cells(0).Value
                If zy = xy Then
                Else
                    x = DataGridView1.CurrentCell.RowIndex
                    xy = DataGridView1.Rows(x).Cells(0).Value

                    If (DataGridView1.Rows(x).Cells(0).Value <> -1) Then

                        getUserId(DataGridView1.Rows(x).Cells(authCell).Value.ToString())
                        getId(DataGridView1.Rows(x).Cells(0).Value.ToString())

                        cmd.CommandText = selectCellClickPartQuery
                        dbConn.Open() 'OPEN------------
                        If (UserId <> "") Then
                            userCmd.CommandText = selectCellClickUserQuery
                            userCmd.ExecuteNonQuery()
                            daUserSelected.Fill(dtUserSelected)
                            authorCbx.SelectedValue = UserId
                        Else
                            If authorCbx.SelectedIndex < 0 Then

                            Else
                                authorCbx.SelectedIndex = 0
                            End If
                        End If
                        cmd.ExecuteNonQuery()
                        dbConn.Close()
                        drawingSelectionDataSet.Clear()
                        drawingSelectionAdapter.Fill(drawingSelectionDataSet)
                        clearError()
                        For Each dr As DataRow In drawingSelectionDataSet.Tables(0).Rows
                            currentFile = fileAssign(dr("fileName"))
                            drawingType = dr("drawingType").ToString
                            drawingRevision = dr("drawingRevision").ToString
                            selectedType = drawingType
                            selectedRev = revCbx.FindString(drawingRevision)
                            partTxt.Text = dr("partName").ToString
                            typeCbx.Text = dr("drawingType").ToString 'selected Type
                            revCbx.Text = dr("drawingRevision").ToString 'selected Revison
                            DateTimePicker1.Value = dr("drawingDate").ToString
                        Next
                        Label9.Text = "Number of Pages: " + ExtractTextFromPdf(currentFile.ToString).ToString
                    End If
                End If
            End If
        End If
        Timer2.Stop()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If Me.DataGridView1.Focused = True Then
            Timer2.Stop()
        End If
    End Sub

    Private Sub SplitContainer2_Panel2_MouseEnter(sender As Object, e As EventArgs) Handles SplitContainer2.Panel2.MouseEnter

    End Sub

    Private Sub d(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub nextPage_Click(sender As Object, e As EventArgs) Handles nextPage.Click
        AxAcroPDF1.gotoNextPage()
    End Sub

    Private Sub prevPage_Click(sender As Object, e As EventArgs) Handles prevPage.Click
        AxAcroPDF1.gotoPreviousPage()
    End Sub

    Private Sub lastPageBtn_Click(sender As Object, e As EventArgs) Handles lastPageBtn.Click
        AxAcroPDF1.gotoLastPage()
    End Sub

    Private Sub firstPageBtn_Click(sender As Object, e As EventArgs) Handles firstPageBtn.Click
        AxAcroPDF1.gotoFirstPage()
    End Sub

    Private Sub AxAcroPDF1_MouseCaptureChanged(sender As Object, e As EventArgs) Handles AxAcroPDF1.MouseCaptureChanged

    End Sub

    Private Sub SplitContainer2_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer2.Panel2.Paint

    End Sub
End Class
Public Class Author2
    Public Name As String
    Public Value1 As Integer
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class

