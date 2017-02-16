<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewDrawing
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewDrawing))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.AxAcroPDF2 = New AxAcroPDFLib.AxAcroPDF()
        Me.firstPageBtn = New System.Windows.Forms.Button()
        Me.lastPageBtn = New System.Windows.Forms.Button()
        Me.prevPage = New System.Windows.Forms.Button()
        Me.nextPage = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.clearSrchBtn = New System.Windows.Forms.Button()
        Me.searchTxt = New System.Windows.Forms.MaskedTextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.pdfViewer2 = New System.Windows.Forms.Button()
        Me.updateBtn = New System.Windows.Forms.Button()
        Me.createBtn = New System.Windows.Forms.Button()
        Me.deleteBtn = New System.Windows.Forms.Button()
        Me.disableChk = New System.Windows.Forms.CheckBox()
        Me.fileTxtVD = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.browseBtn = New System.Windows.Forms.Button()
        Me.authorCbx = New System.Windows.Forms.ComboBox()
        Me.revCbx = New System.Windows.Forms.ComboBox()
        Me.typeCbx = New System.Windows.Forms.ComboBox()
        Me.partTxt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pdfViewer1 = New System.Windows.Forms.Button()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.mnuCell = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.YeahToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.AxAcroPDF2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuCell.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(56, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Eras Demi ITC", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(56, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowHeadersWidth = 20
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(738, 76)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.VirtualMode = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel2.Controls.Add(Me.AxAcroPDF1)
        Me.SplitContainer1.Panel2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SplitContainer1.Size = New System.Drawing.Size(1270, 491)
        Me.SplitContainer1.SplitterDistance = 744
        Me.SplitContainer1.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DataGridView1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.AxAcroPDF2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer2.Panel2.Controls.Add(Me.firstPageBtn)
        Me.SplitContainer2.Panel2.Controls.Add(Me.lastPageBtn)
        Me.SplitContainer2.Panel2.Controls.Add(Me.prevPage)
        Me.SplitContainer2.Panel2.Controls.Add(Me.nextPage)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer2.Panel2.Controls.Add(Me.clearSrchBtn)
        Me.SplitContainer2.Panel2.Controls.Add(Me.searchTxt)
        Me.SplitContainer2.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.pdfViewer2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.updateBtn)
        Me.SplitContainer2.Panel2.Controls.Add(Me.createBtn)
        Me.SplitContainer2.Panel2.Controls.Add(Me.deleteBtn)
        Me.SplitContainer2.Panel2.Controls.Add(Me.disableChk)
        Me.SplitContainer2.Panel2.Controls.Add(Me.fileTxtVD)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer2.Panel2.Controls.Add(Me.browseBtn)
        Me.SplitContainer2.Panel2.Controls.Add(Me.authorCbx)
        Me.SplitContainer2.Panel2.Controls.Add(Me.revCbx)
        Me.SplitContainer2.Panel2.Controls.Add(Me.typeCbx)
        Me.SplitContainer2.Panel2.Controls.Add(Me.partTxt)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.pdfViewer1)
        Me.SplitContainer2.Panel2.ForeColor = System.Drawing.SystemColors.InfoText
        Me.SplitContainer2.Size = New System.Drawing.Size(740, 483)
        Me.SplitContainer2.SplitterDistance = 78
        Me.SplitContainer2.TabIndex = 1
        '
        'AxAcroPDF2
        '
        Me.AxAcroPDF2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxAcroPDF2.Enabled = True
        Me.AxAcroPDF2.Location = New System.Drawing.Point(0, 0)
        Me.AxAcroPDF2.Name = "AxAcroPDF2"
        Me.AxAcroPDF2.OcxState = CType(resources.GetObject("AxAcroPDF2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF2.Size = New System.Drawing.Size(738, 76)
        Me.AxAcroPDF2.TabIndex = 1
        '
        'firstPageBtn
        '
        Me.firstPageBtn.Location = New System.Drawing.Point(443, 85)
        Me.firstPageBtn.Name = "firstPageBtn"
        Me.firstPageBtn.Size = New System.Drawing.Size(28, 28)
        Me.firstPageBtn.TabIndex = 28
        Me.firstPageBtn.Text = "<<"
        Me.firstPageBtn.UseVisualStyleBackColor = True
        '
        'lastPageBtn
        '
        Me.lastPageBtn.Location = New System.Drawing.Point(545, 85)
        Me.lastPageBtn.Name = "lastPageBtn"
        Me.lastPageBtn.Size = New System.Drawing.Size(28, 28)
        Me.lastPageBtn.TabIndex = 27
        Me.lastPageBtn.Text = ">>"
        Me.lastPageBtn.UseVisualStyleBackColor = True
        '
        'prevPage
        '
        Me.prevPage.Location = New System.Drawing.Point(477, 85)
        Me.prevPage.Name = "prevPage"
        Me.prevPage.Size = New System.Drawing.Size(28, 28)
        Me.prevPage.TabIndex = 26
        Me.prevPage.Text = "<"
        Me.prevPage.UseVisualStyleBackColor = True
        '
        'nextPage
        '
        Me.nextPage.Location = New System.Drawing.Point(511, 85)
        Me.nextPage.Name = "nextPage"
        Me.nextPage.Size = New System.Drawing.Size(28, 28)
        Me.nextPage.TabIndex = 25
        Me.nextPage.Text = ">"
        Me.nextPage.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(461, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Number of Pages: "
        '
        'clearSrchBtn
        '
        Me.clearSrchBtn.Location = New System.Drawing.Point(177, 53)
        Me.clearSrchBtn.Name = "clearSrchBtn"
        Me.clearSrchBtn.Size = New System.Drawing.Size(93, 23)
        Me.clearSrchBtn.TabIndex = 23
        Me.clearSrchBtn.Text = "Clear/Refresh"
        Me.clearSrchBtn.UseVisualStyleBackColor = True
        '
        'searchTxt
        '
        Me.searchTxt.Location = New System.Drawing.Point(10, 27)
        Me.searchTxt.Name = "searchTxt"
        Me.searchTxt.Size = New System.Drawing.Size(262, 20)
        Me.searchTxt.TabIndex = 22
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "mm-dd-yyyy"
        Me.DateTimePicker1.Location = New System.Drawing.Point(124, 244)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 21
        '
        'pdfViewer2
        '
        Me.pdfViewer2.Location = New System.Drawing.Point(416, 19)
        Me.pdfViewer2.Name = "pdfViewer2"
        Me.pdfViewer2.Size = New System.Drawing.Size(89, 34)
        Me.pdfViewer2.TabIndex = 20
        Me.pdfViewer2.Text = "DataGrid/ PDFViewer"
        Me.pdfViewer2.UseVisualStyleBackColor = True
        '
        'updateBtn
        '
        Me.updateBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.updateBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updateBtn.ForeColor = System.Drawing.SystemColors.Info
        Me.updateBtn.Location = New System.Drawing.Point(389, 314)
        Me.updateBtn.Name = "updateBtn"
        Me.updateBtn.Size = New System.Drawing.Size(182, 33)
        Me.updateBtn.TabIndex = 19
        Me.updateBtn.Text = "Update"
        Me.updateBtn.UseVisualStyleBackColor = False
        '
        'createBtn
        '
        Me.createBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.createBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.createBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createBtn.ForeColor = System.Drawing.Color.White
        Me.createBtn.Location = New System.Drawing.Point(201, 314)
        Me.createBtn.Name = "createBtn"
        Me.createBtn.Size = New System.Drawing.Size(182, 33)
        Me.createBtn.TabIndex = 18
        Me.createBtn.Text = "Add"
        Me.createBtn.UseVisualStyleBackColor = False
        '
        'deleteBtn
        '
        Me.deleteBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.deleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.deleteBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteBtn.ForeColor = System.Drawing.Color.White
        Me.deleteBtn.Location = New System.Drawing.Point(13, 314)
        Me.deleteBtn.Name = "deleteBtn"
        Me.deleteBtn.Size = New System.Drawing.Size(182, 33)
        Me.deleteBtn.TabIndex = 17
        Me.deleteBtn.Text = "Delete"
        Me.deleteBtn.UseVisualStyleBackColor = False
        '
        'disableChk
        '
        Me.disableChk.AutoSize = True
        Me.disableChk.Location = New System.Drawing.Point(10, 96)
        Me.disableChk.Name = "disableChk"
        Me.disableChk.Size = New System.Drawing.Size(112, 17)
        Me.disableChk.TabIndex = 16
        Me.disableChk.Text = "Disable Edit Mode"
        Me.disableChk.UseVisualStyleBackColor = True
        '
        'fileTxtVD
        '
        Me.fileTxtVD.Location = New System.Drawing.Point(124, 272)
        Me.fileTxtVD.Name = "fileTxtVD"
        Me.fileTxtVD.Size = New System.Drawing.Size(285, 20)
        Me.fileTxtVD.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 273)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "File:"
        '
        'browseBtn
        '
        Me.browseBtn.Location = New System.Drawing.Point(428, 270)
        Me.browseBtn.Name = "browseBtn"
        Me.browseBtn.Size = New System.Drawing.Size(130, 23)
        Me.browseBtn.TabIndex = 13
        Me.browseBtn.Text = "Browse..."
        Me.browseBtn.UseVisualStyleBackColor = True
        '
        'authorCbx
        '
        Me.authorCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.authorCbx.FormattingEnabled = True
        Me.authorCbx.Location = New System.Drawing.Point(124, 212)
        Me.authorCbx.Name = "authorCbx"
        Me.authorCbx.Size = New System.Drawing.Size(121, 21)
        Me.authorCbx.TabIndex = 12
        '
        'revCbx
        '
        Me.revCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.revCbx.FormattingEnabled = True
        Me.revCbx.Items.AddRange(New Object() {"0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N"})
        Me.revCbx.Location = New System.Drawing.Point(124, 184)
        Me.revCbx.Name = "revCbx"
        Me.revCbx.Size = New System.Drawing.Size(121, 21)
        Me.revCbx.TabIndex = 11
        '
        'typeCbx
        '
        Me.typeCbx.AutoCompleteCustomSource.AddRange(New String() {"Assembly", "Machine", "Customer", "Finish", "Cage", "Roller", "Vendor"})
        Me.typeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.typeCbx.FormattingEnabled = True
        Me.typeCbx.Items.AddRange(New Object() {"Assembly", "Component", "Machine", "Customer", "Finish", "Cage", "Roller", "Vendor"})
        Me.typeCbx.Location = New System.Drawing.Point(124, 157)
        Me.typeCbx.Name = "typeCbx"
        Me.typeCbx.Size = New System.Drawing.Size(122, 21)
        Me.typeCbx.TabIndex = 10
        '
        'partTxt
        '
        Me.partTxt.Location = New System.Drawing.Point(124, 130)
        Me.partTxt.Name = "partTxt"
        Me.partTxt.Size = New System.Drawing.Size(183, 20)
        Me.partTxt.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Revision:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Drawing Type:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 213)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Author:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 242)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Part-Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Search part name..."
        '
        'pdfViewer1
        '
        Me.pdfViewer1.Location = New System.Drawing.Point(511, 19)
        Me.pdfViewer1.Name = "pdfViewer1"
        Me.pdfViewer1.Size = New System.Drawing.Size(87, 34)
        Me.pdfViewer1.TabIndex = 0
        Me.pdfViewer1.Text = "Show/Hide Preview"
        Me.pdfViewer1.UseVisualStyleBackColor = True
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(3, 3)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(514, 483)
        Me.AxAcroPDF1.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "Select file"
        Me.OpenFileDialog1.Filter = "PDF files|*.pdf|AllFiles|*.*"
        '
        'mnuCell
        '
        Me.mnuCell.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.YeahToolStripMenuItem})
        Me.mnuCell.Name = "ContextMenuStrip1"
        Me.mnuCell.Size = New System.Drawing.Size(239, 26)
        '
        'YeahToolStripMenuItem
        '
        Me.YeahToolStripMenuItem.Name = "YeahToolStripMenuItem"
        Me.YeahToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.YeahToolStripMenuItem.Text = "Open file in containing folder..."
        '
        'Timer1
        '
        Me.Timer1.Interval = 1050
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Timer2
        '
        Me.Timer2.Interval = 450
        '
        'viewDrawing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1270, 491)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "viewDrawing"
        Me.Text = "Scheerer Drawing Manager"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.AxAcroPDF2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuCell.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents pdfViewer1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents browseBtn As System.Windows.Forms.Button
    Friend WithEvents authorCbx As System.Windows.Forms.ComboBox
    Friend WithEvents revCbx As System.Windows.Forms.ComboBox
    Friend WithEvents typeCbx As System.Windows.Forms.ComboBox
    Friend WithEvents partTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents fileTxtVD As System.Windows.Forms.TextBox
    Friend WithEvents disableChk As System.Windows.Forms.CheckBox
    Friend WithEvents updateBtn As System.Windows.Forms.Button
    Friend WithEvents createBtn As System.Windows.Forms.Button
    Friend WithEvents deleteBtn As System.Windows.Forms.Button
    Friend WithEvents AxAcroPDF2 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents mnuCell As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents pdfViewer2 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents searchTxt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents YeahToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents clearSrchBtn As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents nextPage As System.Windows.Forms.Button
    Friend WithEvents prevPage As System.Windows.Forms.Button
    Friend WithEvents firstPageBtn As System.Windows.Forms.Button
    Friend WithEvents lastPageBtn As System.Windows.Forms.Button
End Class
