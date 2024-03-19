<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCWorkingTimeMaster
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        ComboBoxWorkingTime = New ComboBox()
        Label3 = New Label()
        ComboBoxDateOfWeek = New ComboBox()
        Label2 = New Label()
        btnSearch = New Button()
        btnClearSearch = New Button()
        DGVWorkingTime_Master = New DataGridView()
        ownerId = New DataGridViewTextBoxColumn()
        dateOfWeek = New DataGridViewTextBoxColumn()
        dateOfWeek_show = New DataGridViewTextBoxColumn()
        idWorkingTime = New DataGridViewTextBoxColumn()
        startTime = New DataGridViewTextBoxColumn()
        startTime_show = New DataGridViewTextBoxColumn()
        endTime = New DataGridViewTextBoxColumn()
        endTime_show = New DataGridViewTextBoxColumn()
        salaryId = New DataGridViewTextBoxColumn()
        salary = New DataGridViewTextBoxColumn()
        edit = New DataGridViewButtonColumn()
        delete = New DataGridViewButtonColumn()
        GroupBox2 = New GroupBox()
        lblDateOfWeek = New Label()
        txtDateOfWeek = New TextBox()
        Label6 = New Label()
        lblSalary = New Label()
        lblEndTime = New Label()
        lblStartTime = New Label()
        btnConfirm = New Button()
        btnClear = New Button()
        ComboBoxSalary = New ComboBox()
        Label9 = New Label()
        txtEndTime = New TextBox()
        Label8 = New Label()
        txtStartTime = New TextBox()
        Label5 = New Label()
        txtIdWorkingTime = New TextBox()
        Label4 = New Label()
        GroupBox3 = New GroupBox()
        btnReloadSalary = New Button()
        btnNewSalary = New Button()
        DGVSalary = New DataGridView()
        salaryId2 = New DataGridViewTextBoxColumn()
        salary2 = New DataGridViewTextBoxColumn()
        description2 = New DataGridViewTextBoxColumn()
        delete2 = New DataGridViewButtonColumn()
        GroupBox1.SuspendLayout()
        CType(DGVWorkingTime_Master, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        CType(DGVSalary, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.Highlight
        Label1.Location = New Point(3, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(1190, 61)
        Label1.TabIndex = 3
        Label1.Text = "CA LÀM VIỆC"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(ComboBoxWorkingTime)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(ComboBoxDateOfWeek)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(btnSearch)
        GroupBox1.Controls.Add(btnClearSearch)
        GroupBox1.Controls.Add(DGVWorkingTime_Master)
        GroupBox1.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox1.Location = New Point(3, 67)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(785, 541)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "Danh sách"
        ' 
        ' ComboBoxWorkingTime
        ' 
        ComboBoxWorkingTime.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxWorkingTime.FormattingEnabled = True
        ComboBoxWorkingTime.Location = New Point(268, 54)
        ComboBoxWorkingTime.Name = "ComboBoxWorkingTime"
        ComboBoxWorkingTime.Size = New Size(121, 25)
        ComboBoxWorkingTime.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(202, 56)
        Label3.Name = "Label3"
        Label3.Size = New Size(65, 19)
        Label3.TabIndex = 5
        Label3.Text = "Thời gian"
        ' 
        ' ComboBoxDateOfWeek
        ' 
        ComboBoxDateOfWeek.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxDateOfWeek.FormattingEnabled = True
        ComboBoxDateOfWeek.Location = New Point(63, 53)
        ComboBoxDateOfWeek.Name = "ComboBoxDateOfWeek"
        ComboBoxDateOfWeek.Size = New Size(121, 25)
        ComboBoxDateOfWeek.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(28, 56)
        Label2.Name = "Label2"
        Label2.Size = New Size(32, 19)
        Label2.TabIndex = 3
        Label2.Text = "Thứ"
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.White
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnSearch.Location = New Point(695, 56)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 2
        btnSearch.Text = "Tìm kiếm"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' btnClearSearch
        ' 
        btnClearSearch.BackColor = Color.White
        btnClearSearch.FlatStyle = FlatStyle.Flat
        btnClearSearch.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnClearSearch.Location = New Point(605, 56)
        btnClearSearch.Name = "btnClearSearch"
        btnClearSearch.Size = New Size(75, 23)
        btnClearSearch.TabIndex = 1
        btnClearSearch.Text = "Làm mới"
        btnClearSearch.UseVisualStyleBackColor = False
        ' 
        ' DGVWorkingTime_Master
        ' 
        DGVWorkingTime_Master.AllowUserToAddRows = False
        DGVWorkingTime_Master.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DGVWorkingTime_Master.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DGVWorkingTime_Master.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVWorkingTime_Master.Columns.AddRange(New DataGridViewColumn() {ownerId, dateOfWeek, dateOfWeek_show, idWorkingTime, startTime, startTime_show, endTime, endTime_show, salaryId, salary, edit, delete})
        DGVWorkingTime_Master.Location = New Point(6, 90)
        DGVWorkingTime_Master.Name = "DGVWorkingTime_Master"
        DGVWorkingTime_Master.ReadOnly = True
        DGVWorkingTime_Master.RowHeadersVisible = False
        DGVWorkingTime_Master.RowTemplate.Height = 25
        DGVWorkingTime_Master.Size = New Size(773, 439)
        DGVWorkingTime_Master.TabIndex = 0
        ' 
        ' ownerId
        ' 
        ownerId.DataPropertyName = "ownerId"
        DataGridViewCellStyle2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        ownerId.DefaultCellStyle = DataGridViewCellStyle2
        ownerId.HeaderText = "ownerId"
        ownerId.Name = "ownerId"
        ownerId.ReadOnly = True
        ownerId.Visible = False
        ' 
        ' dateOfWeek
        ' 
        dateOfWeek.DataPropertyName = "dateOfWeek"
        DataGridViewCellStyle3.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        dateOfWeek.DefaultCellStyle = DataGridViewCellStyle3
        dateOfWeek.HeaderText = "Thứ _ hide"
        dateOfWeek.Name = "dateOfWeek"
        dateOfWeek.ReadOnly = True
        dateOfWeek.Visible = False
        ' 
        ' dateOfWeek_show
        ' 
        dateOfWeek_show.DataPropertyName = "dateOfWeek_show"
        DataGridViewCellStyle4.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        dateOfWeek_show.DefaultCellStyle = DataGridViewCellStyle4
        dateOfWeek_show.HeaderText = "Thứ"
        dateOfWeek_show.Name = "dateOfWeek_show"
        dateOfWeek_show.ReadOnly = True
        ' 
        ' idWorkingTime
        ' 
        idWorkingTime.DataPropertyName = "idWorkingTime"
        DataGridViewCellStyle5.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        idWorkingTime.DefaultCellStyle = DataGridViewCellStyle5
        idWorkingTime.HeaderText = "ID"
        idWorkingTime.Name = "idWorkingTime"
        idWorkingTime.ReadOnly = True
        idWorkingTime.Width = 60
        ' 
        ' startTime
        ' 
        startTime.DataPropertyName = "startTime"
        DataGridViewCellStyle6.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        startTime.DefaultCellStyle = DataGridViewCellStyle6
        startTime.HeaderText = "Bắt đầu _ hide"
        startTime.Name = "startTime"
        startTime.ReadOnly = True
        startTime.Visible = False
        startTime.Width = 150
        ' 
        ' startTime_show
        ' 
        startTime_show.DataPropertyName = "startTime_show"
        DataGridViewCellStyle7.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        startTime_show.DefaultCellStyle = DataGridViewCellStyle7
        startTime_show.HeaderText = "Bắt đầu"
        startTime_show.Name = "startTime_show"
        startTime_show.ReadOnly = True
        startTime_show.Width = 150
        ' 
        ' endTime
        ' 
        endTime.DataPropertyName = "endTime"
        DataGridViewCellStyle8.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        endTime.DefaultCellStyle = DataGridViewCellStyle8
        endTime.HeaderText = "Kết thúc _ hide"
        endTime.Name = "endTime"
        endTime.ReadOnly = True
        endTime.Visible = False
        endTime.Width = 150
        ' 
        ' endTime_show
        ' 
        endTime_show.DataPropertyName = "endTime_show"
        DataGridViewCellStyle9.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        endTime_show.DefaultCellStyle = DataGridViewCellStyle9
        endTime_show.HeaderText = "kết thúc"
        endTime_show.Name = "endTime_show"
        endTime_show.ReadOnly = True
        endTime_show.Width = 150
        ' 
        ' salaryId
        ' 
        salaryId.DataPropertyName = "salaryId"
        DataGridViewCellStyle10.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        salaryId.DefaultCellStyle = DataGridViewCellStyle10
        salaryId.HeaderText = "salaryId"
        salaryId.Name = "salaryId"
        salaryId.ReadOnly = True
        salaryId.Visible = False
        ' 
        ' salary
        ' 
        salary.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        salary.DataPropertyName = "salary"
        DataGridViewCellStyle11.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        salary.DefaultCellStyle = DataGridViewCellStyle11
        salary.HeaderText = "Lương"
        salary.Name = "salary"
        salary.ReadOnly = True
        ' 
        ' edit
        ' 
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        edit.DefaultCellStyle = DataGridViewCellStyle12
        edit.HeaderText = ""
        edit.Name = "edit"
        edit.ReadOnly = True
        edit.Text = "edit"
        edit.UseColumnTextForButtonValue = True
        edit.Width = 60
        ' 
        ' delete
        ' 
        DataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle13.ForeColor = Color.Silver
        delete.DefaultCellStyle = DataGridViewCellStyle13
        delete.HeaderText = ""
        delete.Name = "delete"
        delete.ReadOnly = True
        delete.Text = "delete"
        delete.UseColumnTextForButtonValue = True
        delete.Width = 60
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(lblDateOfWeek)
        GroupBox2.Controls.Add(txtDateOfWeek)
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(lblSalary)
        GroupBox2.Controls.Add(lblEndTime)
        GroupBox2.Controls.Add(lblStartTime)
        GroupBox2.Controls.Add(btnConfirm)
        GroupBox2.Controls.Add(btnClear)
        GroupBox2.Controls.Add(ComboBoxSalary)
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Controls.Add(txtEndTime)
        GroupBox2.Controls.Add(Label8)
        GroupBox2.Controls.Add(txtStartTime)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(txtIdWorkingTime)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox2.ForeColor = SystemColors.ControlText
        GroupBox2.Location = New Point(794, 67)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(401, 316)
        GroupBox2.TabIndex = 5
        GroupBox2.TabStop = False
        GroupBox2.Text = "Chỉnh sửa"
        ' 
        ' lblDateOfWeek
        ' 
        lblDateOfWeek.AutoSize = True
        lblDateOfWeek.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        lblDateOfWeek.Location = New Point(324, 94)
        lblDateOfWeek.Name = "lblDateOfWeek"
        lblDateOfWeek.Size = New Size(69, 19)
        lblDateOfWeek.TabIndex = 25
        lblDateOfWeek.Text = "dateofeek"
        lblDateOfWeek.Visible = False
        ' 
        ' txtDateOfWeek
        ' 
        txtDateOfWeek.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        txtDateOfWeek.Location = New Point(86, 90)
        txtDateOfWeek.Name = "txtDateOfWeek"
        txtDateOfWeek.ReadOnly = True
        txtDateOfWeek.Size = New Size(236, 25)
        txtDateOfWeek.TabIndex = 24
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(41, 93)
        Label6.Name = "Label6"
        Label6.Size = New Size(41, 19)
        Label6.TabIndex = 23
        Label6.Text = "Ngày"
        ' 
        ' lblSalary
        ' 
        lblSalary.AutoSize = True
        lblSalary.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        lblSalary.Location = New Point(343, 220)
        lblSalary.Name = "lblSalary"
        lblSalary.Size = New Size(44, 19)
        lblSalary.TabIndex = 22
        lblSalary.Text = "salary"
        lblSalary.Visible = False
        ' 
        ' lblEndTime
        ' 
        lblEndTime.AutoSize = True
        lblEndTime.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        lblEndTime.Location = New Point(326, 176)
        lblEndTime.Name = "lblEndTime"
        lblEndTime.Size = New Size(61, 19)
        lblEndTime.TabIndex = 21
        lblEndTime.Text = "endTime"
        lblEndTime.Visible = False
        ' 
        ' lblStartTime
        ' 
        lblStartTime.AutoSize = True
        lblStartTime.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        lblStartTime.Location = New Point(326, 133)
        lblStartTime.Name = "lblStartTime"
        lblStartTime.Size = New Size(66, 19)
        lblStartTime.TabIndex = 20
        lblStartTime.Text = "startTime"
        lblStartTime.Visible = False
        ' 
        ' btnConfirm
        ' 
        btnConfirm.BackColor = Color.White
        btnConfirm.FlatStyle = FlatStyle.Flat
        btnConfirm.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnConfirm.Location = New Point(227, 269)
        btnConfirm.Name = "btnConfirm"
        btnConfirm.Size = New Size(75, 23)
        btnConfirm.TabIndex = 18
        btnConfirm.Text = "Xác nhận"
        btnConfirm.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.White
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnClear.Location = New Point(120, 269)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 23)
        btnClear.TabIndex = 17
        btnClear.Text = "Hủy"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' ComboBoxSalary
        ' 
        ComboBoxSalary.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxSalary.FormattingEnabled = True
        ComboBoxSalary.Location = New Point(86, 217)
        ComboBoxSalary.Name = "ComboBoxSalary"
        ComboBoxSalary.Size = New Size(234, 25)
        ComboBoxSalary.TabIndex = 16
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Location = New Point(35, 220)
        Label9.Name = "Label9"
        Label9.Size = New Size(48, 19)
        Label9.TabIndex = 15
        Label9.Text = "Lương"
        ' 
        ' txtEndTime
        ' 
        txtEndTime.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        txtEndTime.Location = New Point(86, 174)
        txtEndTime.Name = "txtEndTime"
        txtEndTime.Size = New Size(234, 25)
        txtEndTime.TabIndex = 14
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.Location = New Point(24, 177)
        Label8.Name = "Label8"
        Label8.Size = New Size(60, 19)
        Label8.TabIndex = 13
        Label8.Text = "Kết thúc"
        ' 
        ' txtStartTime
        ' 
        txtStartTime.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        txtStartTime.Location = New Point(85, 131)
        txtStartTime.Name = "txtStartTime"
        txtStartTime.Size = New Size(235, 25)
        txtStartTime.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(26, 134)
        Label5.Name = "Label5"
        Label5.Size = New Size(56, 19)
        Label5.TabIndex = 8
        Label5.Text = "Bắt đầu"
        ' 
        ' txtIdWorkingTime
        ' 
        txtIdWorkingTime.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        txtIdWorkingTime.Location = New Point(84, 51)
        txtIdWorkingTime.Name = "txtIdWorkingTime"
        txtIdWorkingTime.ReadOnly = True
        txtIdWorkingTime.Size = New Size(236, 25)
        txtIdWorkingTime.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(58, 55)
        Label4.Name = "Label4"
        Label4.Size = New Size(23, 19)
        Label4.TabIndex = 6
        Label4.Text = "ID"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(btnReloadSalary)
        GroupBox3.Controls.Add(btnNewSalary)
        GroupBox3.Controls.Add(DGVSalary)
        GroupBox3.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox3.Location = New Point(794, 389)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(393, 219)
        GroupBox3.TabIndex = 6
        GroupBox3.TabStop = False
        GroupBox3.Text = "Quản lý lương"
        ' 
        ' btnReloadSalary
        ' 
        btnReloadSalary.BackColor = Color.White
        btnReloadSalary.FlatStyle = FlatStyle.Flat
        btnReloadSalary.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnReloadSalary.Location = New Point(231, 23)
        btnReloadSalary.Name = "btnReloadSalary"
        btnReloadSalary.Size = New Size(75, 23)
        btnReloadSalary.TabIndex = 2
        btnReloadSalary.Text = "Làm mới"
        btnReloadSalary.UseVisualStyleBackColor = False
        ' 
        ' btnNewSalary
        ' 
        btnNewSalary.BackColor = Color.White
        btnNewSalary.FlatStyle = FlatStyle.Flat
        btnNewSalary.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnNewSalary.Location = New Point(312, 23)
        btnNewSalary.Name = "btnNewSalary"
        btnNewSalary.Size = New Size(75, 23)
        btnNewSalary.TabIndex = 1
        btnNewSalary.Text = "Thêm mới"
        btnNewSalary.UseVisualStyleBackColor = False
        ' 
        ' DGVSalary
        ' 
        DGVSalary.AllowUserToAddRows = False
        DGVSalary.AllowUserToDeleteRows = False
        DataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = SystemColors.Control
        DataGridViewCellStyle14.Font = New Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle14.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle14.SelectionForeColor = SystemColors.ControlText
        DataGridViewCellStyle14.WrapMode = DataGridViewTriState.True
        DGVSalary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        DGVSalary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVSalary.Columns.AddRange(New DataGridViewColumn() {salaryId2, salary2, description2, delete2})
        DataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = SystemColors.Window
        DataGridViewCellStyle19.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle19.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = DataGridViewTriState.False
        DGVSalary.DefaultCellStyle = DataGridViewCellStyle19
        DGVSalary.EnableHeadersVisualStyles = False
        DGVSalary.Location = New Point(6, 52)
        DGVSalary.Name = "DGVSalary"
        DGVSalary.ReadOnly = True
        DGVSalary.RowHeadersVisible = False
        DGVSalary.RowTemplate.Height = 25
        DGVSalary.Size = New Size(381, 161)
        DGVSalary.TabIndex = 0
        ' 
        ' salaryId2
        ' 
        salaryId2.DataPropertyName = "salaryId"
        DataGridViewCellStyle15.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        salaryId2.DefaultCellStyle = DataGridViewCellStyle15
        salaryId2.HeaderText = "ID"
        salaryId2.Name = "salaryId2"
        salaryId2.ReadOnly = True
        salaryId2.Width = 60
        ' 
        ' salary2
        ' 
        salary2.DataPropertyName = "salary"
        DataGridViewCellStyle16.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        salary2.DefaultCellStyle = DataGridViewCellStyle16
        salary2.HeaderText = "Lương"
        salary2.Name = "salary2"
        salary2.ReadOnly = True
        ' 
        ' description2
        ' 
        description2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        description2.DataPropertyName = "description"
        DataGridViewCellStyle17.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        description2.DefaultCellStyle = DataGridViewCellStyle17
        description2.HeaderText = "Mô tả"
        description2.Name = "description2"
        description2.ReadOnly = True
        ' 
        ' delete2
        ' 
        DataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        delete2.DefaultCellStyle = DataGridViewCellStyle18
        delete2.HeaderText = ""
        delete2.Name = "delete2"
        delete2.ReadOnly = True
        delete2.Text = "X"
        delete2.UseColumnTextForButtonValue = True
        delete2.Width = 30
        ' 
        ' UCWorkingTimeMaster
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(Label1)
        ForeColor = SystemColors.ControlText
        Name = "UCWorkingTimeMaster"
        Size = New Size(1195, 611)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGVWorkingTime_Master, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        CType(DGVSalary, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnClearSearch As Button
    Friend WithEvents DGVWorkingTime_Master As DataGridView
    Friend WithEvents ComboBoxWorkingTime As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxDateOfWeek As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents editSalary As DataGridViewButtonColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents txtIdWorkingTime As TextBox
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents ComboBoxSalary As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtEndTime As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtStartTime As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblSalary As Label
    Friend WithEvents lblEndTime As Label
    Friend WithEvents lblStartTime As Label
    Friend WithEvents txtDateOfWeek As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblDateOfWeek As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnNewSalary As Button
    Friend WithEvents DGVSalary As DataGridView
    Friend WithEvents btnReloadSalary As Button
    Friend WithEvents ownerId As DataGridViewTextBoxColumn
    Friend WithEvents dateOfWeek As DataGridViewTextBoxColumn
    Friend WithEvents dateOfWeek_show As DataGridViewTextBoxColumn
    Friend WithEvents idWorkingTime As DataGridViewTextBoxColumn
    Friend WithEvents startTime As DataGridViewTextBoxColumn
    Friend WithEvents startTime_show As DataGridViewTextBoxColumn
    Friend WithEvents endTime As DataGridViewTextBoxColumn
    Friend WithEvents endTime_show As DataGridViewTextBoxColumn
    Friend WithEvents salaryId As DataGridViewTextBoxColumn
    Friend WithEvents salary As DataGridViewTextBoxColumn
    Friend WithEvents edit As DataGridViewButtonColumn
    Friend WithEvents delete As DataGridViewButtonColumn
    Friend WithEvents salaryId2 As DataGridViewTextBoxColumn
    Friend WithEvents salary2 As DataGridViewTextBoxColumn
    Friend WithEvents description2 As DataGridViewTextBoxColumn
    Friend WithEvents delete2 As DataGridViewButtonColumn
End Class
