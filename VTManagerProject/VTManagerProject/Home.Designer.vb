<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
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
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DGVTableStatus = New DataGridView()
        DGVEmployeeStatus = New DataGridView()
        dateOfWeek = New DataGridViewTextBoxColumn()
        dateOfWeek_show = New DataGridViewTextBoxColumn()
        startTime = New DataGridViewTextBoxColumn()
        endTime = New DataGridViewTextBoxColumn()
        employeeName = New DataGridViewTextBoxColumn()
        statusWork = New DataGridViewTextBoxColumn()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        DGVOrderStatus = New DataGridView()
        productName = New DataGridViewTextBoxColumn()
        quantity = New DataGridViewTextBoxColumn()
        unitPrice = New DataGridViewTextBoxColumn()
        dateOrder = New DataGridViewTextBoxColumn()
        timeOrder = New DataGridViewTextBoxColumn()
        statusOrder = New DataGridViewTextBoxColumn()
        btnReloadTableStatus = New Button()
        DGVBill = New DataGridView()
        orderId = New DataGridViewTextBoxColumn()
        billId = New DataGridViewTextBoxColumn()
        billAreaName = New DataGridViewTextBoxColumn()
        billTableId = New DataGridViewTextBoxColumn()
        dateOfPayment = New DataGridViewTextBoxColumn()
        timeOfPayment = New DataGridViewTextBoxColumn()
        paymentType = New DataGridViewTextBoxColumn()
        totalPayment = New DataGridViewTextBoxColumn()
        printBill = New DataGridViewButtonColumn()
        Label4 = New Label()
        Label5 = New Label()
        btnSearchBill = New Button()
        btnClearBill = New Button()
        lblCurrent = New Label()
        lblCurrentNum = New Label()
        btnReloadEmployeeStatus = New Button()
        DateTimePickerSearchBill = New DateTimePicker()
        Label6 = New Label()
        Label7 = New Label()
        DGVProblem = New DataGridView()
        problemOwnerId = New DataGridViewTextBoxColumn()
        problemProductId = New DataGridViewTextBoxColumn()
        problemProductName = New DataGridViewTextBoxColumn()
        btnConfirm = New DataGridViewButtonColumn()
        areaId = New DataGridViewTextBoxColumn()
        areaName = New DataGridViewTextBoxColumn()
        tableId = New DataGridViewTextBoxColumn()
        status = New DataGridViewTextBoxColumn()
        status_show = New DataGridViewTextBoxColumn()
        maxCapacity = New DataGridViewTextBoxColumn()
        details = New DataGridViewButtonColumn()
        CType(DGVTableStatus, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGVEmployeeStatus, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGVOrderStatus, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGVBill, ComponentModel.ISupportInitialize).BeginInit()
        CType(DGVProblem, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DGVTableStatus
        ' 
        DGVTableStatus.AllowUserToAddRows = False
        DGVTableStatus.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlDarkDark
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DGVTableStatus.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DGVTableStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVTableStatus.Columns.AddRange(New DataGridViewColumn() {areaId, areaName, tableId, status, status_show, maxCapacity, details})
        DGVTableStatus.EnableHeadersVisualStyles = False
        DGVTableStatus.Location = New Point(3, 94)
        DGVTableStatus.Name = "DGVTableStatus"
        DGVTableStatus.ReadOnly = True
        DGVTableStatus.RowHeadersVisible = False
        DGVTableStatus.RowTemplate.Height = 25
        DGVTableStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVTableStatus.Size = New Size(399, 271)
        DGVTableStatus.TabIndex = 0
        ' 
        ' DGVEmployeeStatus
        ' 
        DGVEmployeeStatus.AllowUserToAddRows = False
        DGVEmployeeStatus.AllowUserToDeleteRows = False
        DGVEmployeeStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVEmployeeStatus.Columns.AddRange(New DataGridViewColumn() {dateOfWeek, dateOfWeek_show, startTime, endTime, employeeName, statusWork})
        DGVEmployeeStatus.EnableHeadersVisualStyles = False
        DGVEmployeeStatus.Location = New Point(3, 415)
        DGVEmployeeStatus.Name = "DGVEmployeeStatus"
        DGVEmployeeStatus.ReadOnly = True
        DGVEmployeeStatus.RowHeadersVisible = False
        DGVEmployeeStatus.RowTemplate.Height = 25
        DGVEmployeeStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVEmployeeStatus.Size = New Size(520, 193)
        DGVEmployeeStatus.TabIndex = 2
        ' 
        ' dateOfWeek
        ' 
        dateOfWeek.DataPropertyName = "dateOfWeek"
        DataGridViewCellStyle8.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        dateOfWeek.DefaultCellStyle = DataGridViewCellStyle8
        dateOfWeek.HeaderText = "Thứ_hide"
        dateOfWeek.Name = "dateOfWeek"
        dateOfWeek.ReadOnly = True
        dateOfWeek.Visible = False
        ' 
        ' dateOfWeek_show
        ' 
        dateOfWeek_show.DataPropertyName = "dateOfWeek_show"
        DataGridViewCellStyle9.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        dateOfWeek_show.DefaultCellStyle = DataGridViewCellStyle9
        dateOfWeek_show.HeaderText = "Thứ"
        dateOfWeek_show.Name = "dateOfWeek_show"
        dateOfWeek_show.ReadOnly = True
        ' 
        ' startTime
        ' 
        startTime.DataPropertyName = "startTime"
        DataGridViewCellStyle10.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        startTime.DefaultCellStyle = DataGridViewCellStyle10
        startTime.HeaderText = "Bắt đầu"
        startTime.Name = "startTime"
        startTime.ReadOnly = True
        ' 
        ' endTime
        ' 
        endTime.DataPropertyName = "endTime"
        DataGridViewCellStyle11.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        endTime.DefaultCellStyle = DataGridViewCellStyle11
        endTime.HeaderText = "Kết thúc"
        endTime.Name = "endTime"
        endTime.ReadOnly = True
        ' 
        ' employeeName
        ' 
        employeeName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        employeeName.DataPropertyName = "employeeName"
        DataGridViewCellStyle12.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        employeeName.DefaultCellStyle = DataGridViewCellStyle12
        employeeName.HeaderText = "Nhân viên"
        employeeName.Name = "employeeName"
        employeeName.ReadOnly = True
        ' 
        ' statusWork
        ' 
        statusWork.DataPropertyName = "statusWork"
        DataGridViewCellStyle13.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        statusWork.DefaultCellStyle = DataGridViewCellStyle13
        statusWork.HeaderText = "Trạng thái"
        statusWork.Name = "statusWork"
        statusWork.ReadOnly = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(3, 61)
        Label1.Name = "Label1"
        Label1.Size = New Size(149, 21)
        Label1.TabIndex = 3
        Label1.Text = "Trạng thái các bàn"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(407, 61)
        Label2.Name = "Label2"
        Label2.Size = New Size(98, 21)
        Label2.TabIndex = 4
        Label2.Text = "Chi tiết bàn"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(3, 384)
        Label3.Name = "Label3"
        Label3.Size = New Size(167, 21)
        Label3.TabIndex = 5
        Label3.Text = "Trạng thái nhân viên"
        ' 
        ' DGVOrderStatus
        ' 
        DGVOrderStatus.AllowUserToAddRows = False
        DGVOrderStatus.AllowUserToDeleteRows = False
        DataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = SystemColors.Control
        DataGridViewCellStyle14.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle14.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle14.SelectionForeColor = SystemColors.Desktop
        DataGridViewCellStyle14.WrapMode = DataGridViewTriState.True
        DGVOrderStatus.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        DGVOrderStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVOrderStatus.Columns.AddRange(New DataGridViewColumn() {productName, quantity, unitPrice, dateOrder, timeOrder, statusOrder})
        DGVOrderStatus.EnableHeadersVisualStyles = False
        DGVOrderStatus.Location = New Point(408, 93)
        DGVOrderStatus.Name = "DGVOrderStatus"
        DGVOrderStatus.ReadOnly = True
        DGVOrderStatus.RowHeadersVisible = False
        DGVOrderStatus.RowTemplate.Height = 25
        DGVOrderStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVOrderStatus.Size = New Size(548, 272)
        DGVOrderStatus.TabIndex = 1
        ' 
        ' productName
        ' 
        productName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        productName.DataPropertyName = "productName"
        DataGridViewCellStyle15.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        productName.DefaultCellStyle = DataGridViewCellStyle15
        productName.HeaderText = "Tên món"
        productName.Name = "productName"
        productName.ReadOnly = True
        ' 
        ' quantity
        ' 
        quantity.DataPropertyName = "quantity"
        DataGridViewCellStyle16.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        quantity.DefaultCellStyle = DataGridViewCellStyle16
        quantity.HeaderText = "Số lượng"
        quantity.Name = "quantity"
        quantity.ReadOnly = True
        ' 
        ' unitPrice
        ' 
        unitPrice.DataPropertyName = "unitPrice"
        DataGridViewCellStyle17.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        unitPrice.DefaultCellStyle = DataGridViewCellStyle17
        unitPrice.HeaderText = "Đơn giá _ tạm hide"
        unitPrice.Name = "unitPrice"
        unitPrice.ReadOnly = True
        unitPrice.Visible = False
        ' 
        ' dateOrder
        ' 
        dateOrder.DataPropertyName = "dateOrder"
        DataGridViewCellStyle18.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        dateOrder.DefaultCellStyle = DataGridViewCellStyle18
        dateOrder.HeaderText = "Ngày"
        dateOrder.Name = "dateOrder"
        dateOrder.ReadOnly = True
        ' 
        ' timeOrder
        ' 
        timeOrder.DataPropertyName = "timeOrder"
        DataGridViewCellStyle19.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        timeOrder.DefaultCellStyle = DataGridViewCellStyle19
        timeOrder.HeaderText = "Giờ"
        timeOrder.Name = "timeOrder"
        timeOrder.ReadOnly = True
        timeOrder.Width = 80
        ' 
        ' statusOrder
        ' 
        statusOrder.DataPropertyName = "statusOrder"
        DataGridViewCellStyle20.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        statusOrder.DefaultCellStyle = DataGridViewCellStyle20
        statusOrder.HeaderText = "Trạng thái"
        statusOrder.Name = "statusOrder"
        statusOrder.ReadOnly = True
        statusOrder.Width = 120
        ' 
        ' btnReloadTableStatus
        ' 
        btnReloadTableStatus.Location = New Point(327, 61)
        btnReloadTableStatus.Name = "btnReloadTableStatus"
        btnReloadTableStatus.Size = New Size(75, 23)
        btnReloadTableStatus.TabIndex = 6
        btnReloadTableStatus.Text = "Tải lại"
        btnReloadTableStatus.UseVisualStyleBackColor = True
        btnReloadTableStatus.Visible = False
        ' 
        ' DGVBill
        ' 
        DGVBill.AllowUserToAddRows = False
        DGVBill.AllowUserToDeleteRows = False
        DGVBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVBill.Columns.AddRange(New DataGridViewColumn() {orderId, billId, billAreaName, billTableId, dateOfPayment, timeOfPayment, paymentType, totalPayment, printBill})
        DGVBill.EnableHeadersVisualStyles = False
        DGVBill.Location = New Point(529, 415)
        DGVBill.Name = "DGVBill"
        DGVBill.ReadOnly = True
        DGVBill.RowHeadersVisible = False
        DGVBill.RowTemplate.Height = 25
        DGVBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVBill.Size = New Size(658, 193)
        DGVBill.TabIndex = 7
        ' 
        ' orderId
        ' 
        orderId.DataPropertyName = "orderId"
        DataGridViewCellStyle21.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        orderId.DefaultCellStyle = DataGridViewCellStyle21
        orderId.HeaderText = "ID order"
        orderId.Name = "orderId"
        orderId.ReadOnly = True
        ' 
        ' billId
        ' 
        billId.DataPropertyName = "billId"
        billId.HeaderText = "billId"
        billId.Name = "billId"
        billId.ReadOnly = True
        billId.Visible = False
        ' 
        ' billAreaName
        ' 
        billAreaName.DataPropertyName = "billAreaName"
        billAreaName.HeaderText = "billAreaName"
        billAreaName.Name = "billAreaName"
        billAreaName.ReadOnly = True
        billAreaName.Visible = False
        ' 
        ' billTableId
        ' 
        billTableId.DataPropertyName = "billTableId"
        billTableId.HeaderText = "billTableId"
        billTableId.Name = "billTableId"
        billTableId.ReadOnly = True
        billTableId.Visible = False
        ' 
        ' dateOfPayment
        ' 
        dateOfPayment.DataPropertyName = "dateOfPayment"
        DataGridViewCellStyle22.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        dateOfPayment.DefaultCellStyle = DataGridViewCellStyle22
        dateOfPayment.HeaderText = "Ngày tt"
        dateOfPayment.Name = "dateOfPayment"
        dateOfPayment.ReadOnly = True
        dateOfPayment.Width = 160
        ' 
        ' timeOfPayment
        ' 
        timeOfPayment.DataPropertyName = "timeOfPayment"
        DataGridViewCellStyle23.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        timeOfPayment.DefaultCellStyle = DataGridViewCellStyle23
        timeOfPayment.HeaderText = "Giờ tt"
        timeOfPayment.Name = "timeOfPayment"
        timeOfPayment.ReadOnly = True
        ' 
        ' paymentType
        ' 
        paymentType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        paymentType.DataPropertyName = "paymentType"
        DataGridViewCellStyle24.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        paymentType.DefaultCellStyle = DataGridViewCellStyle24
        paymentType.HeaderText = "Loại"
        paymentType.Name = "paymentType"
        paymentType.ReadOnly = True
        ' 
        ' totalPayment
        ' 
        totalPayment.DataPropertyName = "totalPayment"
        DataGridViewCellStyle25.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        totalPayment.DefaultCellStyle = DataGridViewCellStyle25
        totalPayment.HeaderText = "Tổng"
        totalPayment.Name = "totalPayment"
        totalPayment.ReadOnly = True
        ' 
        ' printBill
        ' 
        DataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle26.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        printBill.DefaultCellStyle = DataGridViewCellStyle26
        printBill.HeaderText = ""
        printBill.Name = "printBill"
        printBill.ReadOnly = True
        printBill.Text = "In"
        printBill.UseColumnTextForButtonValue = True
        printBill.Width = 60
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(529, 384)
        Label4.Name = "Label4"
        Label4.Size = New Size(238, 21)
        Label4.TabIndex = 8
        Label4.Text = "Lịch sử đơn hàng (in hóa đơn)"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(781, 385)
        Label5.Name = "Label5"
        Label5.Size = New Size(68, 17)
        Label5.TabIndex = 9
        Label5.Text = "Ngày mua"
        ' 
        ' btnSearchBill
        ' 
        btnSearchBill.BackColor = Color.White
        btnSearchBill.FlatStyle = FlatStyle.Flat
        btnSearchBill.Location = New Point(1110, 381)
        btnSearchBill.Name = "btnSearchBill"
        btnSearchBill.Size = New Size(75, 23)
        btnSearchBill.TabIndex = 11
        btnSearchBill.Text = "Tìm kiếm"
        btnSearchBill.UseVisualStyleBackColor = False
        ' 
        ' btnClearBill
        ' 
        btnClearBill.BackColor = Color.White
        btnClearBill.FlatStyle = FlatStyle.Flat
        btnClearBill.Location = New Point(1029, 382)
        btnClearBill.Name = "btnClearBill"
        btnClearBill.Size = New Size(75, 23)
        btnClearBill.TabIndex = 12
        btnClearBill.Text = "Làm mới"
        btnClearBill.UseVisualStyleBackColor = False
        ' 
        ' lblCurrent
        ' 
        lblCurrent.AutoSize = True
        lblCurrent.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        lblCurrent.Location = New Point(187, 387)
        lblCurrent.Name = "lblCurrent"
        lblCurrent.Size = New Size(108, 17)
        lblCurrent.TabIndex = 13
        lblCurrent.Text = "Thời gian hiện tại"
        ' 
        ' lblCurrentNum
        ' 
        lblCurrentNum.AutoSize = True
        lblCurrentNum.Location = New Point(356, 388)
        lblCurrentNum.Name = "lblCurrentNum"
        lblCurrentNum.Size = New Size(32, 15)
        lblCurrentNum.TabIndex = 14
        lblCurrentNum.Text = "num"
        lblCurrentNum.Visible = False
        ' 
        ' btnReloadEmployeeStatus
        ' 
        btnReloadEmployeeStatus.Location = New Point(439, 385)
        btnReloadEmployeeStatus.Name = "btnReloadEmployeeStatus"
        btnReloadEmployeeStatus.Size = New Size(75, 23)
        btnReloadEmployeeStatus.TabIndex = 15
        btnReloadEmployeeStatus.Text = "Tải lại"
        btnReloadEmployeeStatus.UseVisualStyleBackColor = True
        btnReloadEmployeeStatus.Visible = False
        ' 
        ' DateTimePickerSearchBill
        ' 
        DateTimePickerSearchBill.CustomFormat = "dd-MM-yyyy"
        DateTimePickerSearchBill.Format = DateTimePickerFormat.Custom
        DateTimePickerSearchBill.Location = New Point(851, 382)
        DateTimePickerSearchBill.Name = "DateTimePickerSearchBill"
        DateTimePickerSearchBill.Size = New Size(170, 23)
        DateTimePickerSearchBill.TabIndex = 16
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label6.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.ForeColor = SystemColors.Highlight
        Label6.Location = New Point(0, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(1190, 61)
        Label6.TabIndex = 17
        Label6.Text = "TRẠNG THÁI"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.Location = New Point(963, 62)
        Label7.Name = "Label7"
        Label7.Size = New Size(132, 21)
        Label7.TabIndex = 18
        Label7.Text = "Hết nguyên liệu"
        ' 
        ' DGVProblem
        ' 
        DGVProblem.AllowUserToAddRows = False
        DGVProblem.AllowUserToDeleteRows = False
        DataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = SystemColors.Control
        DataGridViewCellStyle27.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle27.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle27.SelectionForeColor = SystemColors.Desktop
        DataGridViewCellStyle27.WrapMode = DataGridViewTriState.True
        DGVProblem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        DGVProblem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVProblem.Columns.AddRange(New DataGridViewColumn() {problemOwnerId, problemProductId, problemProductName, btnConfirm})
        DGVProblem.EnableHeadersVisualStyles = False
        DGVProblem.Location = New Point(962, 94)
        DGVProblem.Name = "DGVProblem"
        DGVProblem.ReadOnly = True
        DGVProblem.RowHeadersVisible = False
        DataGridViewCellStyle29.BackColor = Color.LightCoral
        DataGridViewCellStyle29.ForeColor = Color.White
        DataGridViewCellStyle29.SelectionBackColor = Color.Red
        DataGridViewCellStyle29.SelectionForeColor = Color.White
        DGVProblem.RowsDefaultCellStyle = DataGridViewCellStyle29
        DGVProblem.RowTemplate.Height = 25
        DGVProblem.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVProblem.Size = New Size(223, 272)
        DGVProblem.TabIndex = 19
        ' 
        ' problemOwnerId
        ' 
        problemOwnerId.DataPropertyName = "problemOwnerId"
        problemOwnerId.HeaderText = "problemOwnerId"
        problemOwnerId.Name = "problemOwnerId"
        problemOwnerId.ReadOnly = True
        problemOwnerId.Visible = False
        ' 
        ' problemProductId
        ' 
        problemProductId.DataPropertyName = "problemProductId"
        problemProductId.HeaderText = "problemProductId"
        problemProductId.Name = "problemProductId"
        problemProductId.ReadOnly = True
        problemProductId.Visible = False
        ' 
        ' problemProductName
        ' 
        problemProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        problemProductName.DataPropertyName = "problemProductName"
        DataGridViewCellStyle28.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        problemProductName.DefaultCellStyle = DataGridViewCellStyle28
        problemProductName.HeaderText = "Tên món"
        problemProductName.Name = "problemProductName"
        problemProductName.ReadOnly = True
        ' 
        ' btnConfirm
        ' 
        btnConfirm.DataPropertyName = "btnConfirm"
        btnConfirm.HeaderText = ""
        btnConfirm.Name = "btnConfirm"
        btnConfirm.ReadOnly = True
        btnConfirm.Text = "..."
        btnConfirm.UseColumnTextForButtonValue = True
        btnConfirm.Width = 30
        ' 
        ' areaId
        ' 
        areaId.DataPropertyName = "areaId"
        DataGridViewCellStyle2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        areaId.DefaultCellStyle = DataGridViewCellStyle2
        areaId.HeaderText = "areaId"
        areaId.Name = "areaId"
        areaId.ReadOnly = True
        areaId.Visible = False
        areaId.Width = 60
        ' 
        ' areaName
        ' 
        areaName.DataPropertyName = "areaName"
        DataGridViewCellStyle3.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        areaName.DefaultCellStyle = DataGridViewCellStyle3
        areaName.HeaderText = " Khu vực"
        areaName.Name = "areaName"
        areaName.ReadOnly = True
        ' 
        ' tableId
        ' 
        tableId.DataPropertyName = "tableId"
        DataGridViewCellStyle4.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        tableId.DefaultCellStyle = DataGridViewCellStyle4
        tableId.HeaderText = "Bàn"
        tableId.Name = "tableId"
        tableId.ReadOnly = True
        tableId.Width = 60
        ' 
        ' status
        ' 
        status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        status.DataPropertyName = "status"
        DataGridViewCellStyle5.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        status.DefaultCellStyle = DataGridViewCellStyle5
        status.HeaderText = "Trạng thái _hide"
        status.Name = "status"
        status.ReadOnly = True
        status.Visible = False
        ' 
        ' status_show
        ' 
        status_show.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        status_show.DataPropertyName = "status_show"
        DataGridViewCellStyle6.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        status_show.DefaultCellStyle = DataGridViewCellStyle6
        status_show.HeaderText = "Trạng thái"
        status_show.Name = "status_show"
        status_show.ReadOnly = True
        ' 
        ' maxCapacity
        ' 
        maxCapacity.DataPropertyName = "maxCapacity"
        maxCapacity.HeaderText = "Tối đa"
        maxCapacity.Name = "maxCapacity"
        maxCapacity.ReadOnly = True
        maxCapacity.Width = 80
        ' 
        ' details
        ' 
        details.DataPropertyName = "details"
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        details.DefaultCellStyle = DataGridViewCellStyle7
        details.HeaderText = ""
        details.Name = "details"
        details.ReadOnly = True
        details.Text = "..."
        details.UseColumnTextForButtonValue = True
        details.Width = 30
        ' 
        ' Home
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(DGVProblem)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(DateTimePickerSearchBill)
        Controls.Add(btnReloadEmployeeStatus)
        Controls.Add(lblCurrentNum)
        Controls.Add(lblCurrent)
        Controls.Add(btnClearBill)
        Controls.Add(btnSearchBill)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(DGVBill)
        Controls.Add(btnReloadTableStatus)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(DGVEmployeeStatus)
        Controls.Add(DGVOrderStatus)
        Controls.Add(DGVTableStatus)
        Name = "Home"
        Size = New Size(1190, 611)
        CType(DGVTableStatus, ComponentModel.ISupportInitialize).EndInit()
        CType(DGVEmployeeStatus, ComponentModel.ISupportInitialize).EndInit()
        CType(DGVOrderStatus, ComponentModel.ISupportInitialize).EndInit()
        CType(DGVBill, ComponentModel.ISupportInitialize).EndInit()
        CType(DGVProblem, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DGVTableStatus As DataGridView
    Friend WithEvents DGVEmployeeStatus As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DGVOrderStatus As DataGridView
    Friend WithEvents productName As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents unitPrice As DataGridViewTextBoxColumn
    Friend WithEvents dateOrder As DataGridViewTextBoxColumn
    Friend WithEvents timeOrder As DataGridViewTextBoxColumn
    Friend WithEvents statusOrder As DataGridViewTextBoxColumn
    Friend WithEvents btnReloadTableStatus As Button
    Friend WithEvents DGVBill As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSearchBill As Button
    Friend WithEvents btnClearBill As Button
    Friend WithEvents lblCurrent As Label
    Friend WithEvents present As DataGridViewButtonColumn
    Friend WithEvents absent As DataGridViewButtonColumn
    Friend WithEvents lblCurrentNum As Label
    Friend WithEvents dateOfWeek As DataGridViewTextBoxColumn
    Friend WithEvents dateOfWeek_show As DataGridViewTextBoxColumn
    Friend WithEvents startTime As DataGridViewTextBoxColumn
    Friend WithEvents endTime As DataGridViewTextBoxColumn
    Friend WithEvents employeeName As DataGridViewTextBoxColumn
    Friend WithEvents statusWork As DataGridViewTextBoxColumn
    Friend WithEvents btnReloadEmployeeStatus As Button
    Friend WithEvents DateTimePickerSearchBill As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DGVProblem As DataGridView
    Friend WithEvents problemOwnerId As DataGridViewTextBoxColumn
    Friend WithEvents problemProductId As DataGridViewTextBoxColumn
    Friend WithEvents problemProductName As DataGridViewTextBoxColumn
    Friend WithEvents btnConfirm As DataGridViewButtonColumn
    Friend WithEvents orderId As DataGridViewTextBoxColumn
    Friend WithEvents billId As DataGridViewTextBoxColumn
    Friend WithEvents billAreaName As DataGridViewTextBoxColumn
    Friend WithEvents billTableId As DataGridViewTextBoxColumn
    Friend WithEvents dateOfPayment As DataGridViewTextBoxColumn
    Friend WithEvents timeOfPayment As DataGridViewTextBoxColumn
    Friend WithEvents paymentType As DataGridViewTextBoxColumn
    Friend WithEvents totalPayment As DataGridViewTextBoxColumn
    Friend WithEvents printBill As DataGridViewButtonColumn
    Friend WithEvents areaId As DataGridViewTextBoxColumn
    Friend WithEvents areaName As DataGridViewTextBoxColumn
    Friend WithEvents tableId As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents status_show As DataGridViewTextBoxColumn
    Friend WithEvents maxCapacity As DataGridViewTextBoxColumn
    Friend WithEvents details As DataGridViewButtonColumn
End Class
