<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCTableArea
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
        Label1 = New Label()
        GroupBoxArea = New GroupBox()
        txtAreaId = New TextBox()
        Label6 = New Label()
        btnUpdateArea = New Button()
        btnDeleteArea = New Button()
        btnAddArea = New Button()
        DGVArea = New DataGridView()
        ownerId = New DataGridViewTextBoxColumn()
        areaId = New DataGridViewTextBoxColumn()
        areaName = New DataGridViewTextBoxColumn()
        txtAreaName = New TextBox()
        Label2 = New Label()
        GroupBoxTable = New GroupBox()
        lbAreaIdHidden = New Label()
        txtMaxCapacity = New TextBox()
        Label7 = New Label()
        lbltableIdHidden = New Label()
        btnUpdateTable = New Button()
        btnDeleteTable = New Button()
        btnAddTable = New Button()
        DGVTable = New DataGridView()
        ownerIdTable = New DataGridViewTextBoxColumn()
        table_areaId = New DataGridViewTextBoxColumn()
        table_areaName = New DataGridViewTextBoxColumn()
        tableId = New DataGridViewTextBoxColumn()
        maxCapacity = New DataGridViewTextBoxColumn()
        ComboBoxAreaName = New ComboBox()
        txtTableId = New TextBox()
        Label5 = New Label()
        Label4 = New Label()
        GroupBoxArea.SuspendLayout()
        CType(DGVArea, ComponentModel.ISupportInitialize).BeginInit()
        GroupBoxTable.SuspendLayout()
        CType(DGVTable, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.Highlight
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(1190, 54)
        Label1.TabIndex = 1
        Label1.Text = "DANH MỤC BÀN"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' GroupBoxArea
        ' 
        GroupBoxArea.Controls.Add(txtAreaId)
        GroupBoxArea.Controls.Add(Label6)
        GroupBoxArea.Controls.Add(btnUpdateArea)
        GroupBoxArea.Controls.Add(btnDeleteArea)
        GroupBoxArea.Controls.Add(btnAddArea)
        GroupBoxArea.Controls.Add(DGVArea)
        GroupBoxArea.Controls.Add(txtAreaName)
        GroupBoxArea.Controls.Add(Label2)
        GroupBoxArea.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBoxArea.Location = New Point(3, 57)
        GroupBoxArea.Name = "GroupBoxArea"
        GroupBoxArea.Size = New Size(542, 554)
        GroupBoxArea.TabIndex = 4
        GroupBoxArea.TabStop = False
        GroupBoxArea.Text = "Quản lý khu vực"
        ' 
        ' txtAreaId
        ' 
        txtAreaId.Location = New Point(90, 43)
        txtAreaId.Name = "txtAreaId"
        txtAreaId.ReadOnly = True
        txtAreaId.Size = New Size(163, 35)
        txtAreaId.TabIndex = 7
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(22, 50)
        Label6.Name = "Label6"
        Label6.Size = New Size(67, 17)
        Label6.TabIndex = 6
        Label6.Text = "Id khu vực"
        ' 
        ' btnUpdateArea
        ' 
        btnUpdateArea.BackColor = Color.Blue
        btnUpdateArea.Font = New Font("Segoe UI Black", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnUpdateArea.ForeColor = Color.Snow
        btnUpdateArea.Location = New Point(132, 503)
        btnUpdateArea.Name = "btnUpdateArea"
        btnUpdateArea.Size = New Size(182, 41)
        btnUpdateArea.TabIndex = 5
        btnUpdateArea.Text = "Sửa khu vực đã chọn"
        btnUpdateArea.UseVisualStyleBackColor = False
        ' 
        ' btnDeleteArea
        ' 
        btnDeleteArea.BackColor = Color.Red
        btnDeleteArea.Font = New Font("Segoe UI Black", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnDeleteArea.ForeColor = Color.Snow
        btnDeleteArea.Location = New Point(326, 503)
        btnDeleteArea.Name = "btnDeleteArea"
        btnDeleteArea.Size = New Size(182, 41)
        btnDeleteArea.TabIndex = 4
        btnDeleteArea.Text = "Xóa khu vực đã chọn"
        btnDeleteArea.UseVisualStyleBackColor = False
        ' 
        ' btnAddArea
        ' 
        btnAddArea.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        btnAddArea.Font = New Font("Segoe UI Black", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddArea.ForeColor = Color.Snow
        btnAddArea.Location = New Point(6, 503)
        btnAddArea.Name = "btnAddArea"
        btnAddArea.Size = New Size(111, 41)
        btnAddArea.TabIndex = 3
        btnAddArea.Text = "Thêm khu vực"
        btnAddArea.UseVisualStyleBackColor = False
        ' 
        ' DGVArea
        ' 
        DGVArea.AllowUserToAddRows = False
        DGVArea.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = Color.White
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DGVArea.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DGVArea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVArea.Columns.AddRange(New DataGridViewColumn() {ownerId, areaId, areaName})
        DGVArea.Location = New Point(6, 86)
        DGVArea.Name = "DGVArea"
        DGVArea.ReadOnly = True
        DGVArea.RowTemplate.Height = 25
        DGVArea.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVArea.Size = New Size(530, 411)
        DGVArea.TabIndex = 2
        ' 
        ' ownerId
        ' 
        ownerId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ownerId.HeaderText = "ownerId"
        ownerId.Name = "ownerId"
        ownerId.ReadOnly = True
        ownerId.Visible = False
        ' 
        ' areaId
        ' 
        areaId.DataPropertyName = "areaId"
        DataGridViewCellStyle2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        areaId.DefaultCellStyle = DataGridViewCellStyle2
        areaId.HeaderText = "Id Khu Vực"
        areaId.Name = "areaId"
        areaId.ReadOnly = True
        areaId.Width = 200
        ' 
        ' areaName
        ' 
        areaName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        areaName.DataPropertyName = "areaName"
        DataGridViewCellStyle3.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        areaName.DefaultCellStyle = DataGridViewCellStyle3
        areaName.HeaderText = "Tên khu vực"
        areaName.Name = "areaName"
        areaName.ReadOnly = True
        ' 
        ' txtAreaName
        ' 
        txtAreaName.Location = New Point(359, 43)
        txtAreaName.Name = "txtAreaName"
        txtAreaName.Size = New Size(163, 35)
        txtAreaName.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(279, 49)
        Label2.Name = "Label2"
        Label2.Size = New Size(76, 17)
        Label2.TabIndex = 0
        Label2.Text = "Tên khu vực"
        ' 
        ' GroupBoxTable
        ' 
        GroupBoxTable.Controls.Add(lbAreaIdHidden)
        GroupBoxTable.Controls.Add(txtMaxCapacity)
        GroupBoxTable.Controls.Add(Label7)
        GroupBoxTable.Controls.Add(lbltableIdHidden)
        GroupBoxTable.Controls.Add(btnUpdateTable)
        GroupBoxTable.Controls.Add(btnDeleteTable)
        GroupBoxTable.Controls.Add(btnAddTable)
        GroupBoxTable.Controls.Add(DGVTable)
        GroupBoxTable.Controls.Add(ComboBoxAreaName)
        GroupBoxTable.Controls.Add(txtTableId)
        GroupBoxTable.Controls.Add(Label5)
        GroupBoxTable.Controls.Add(Label4)
        GroupBoxTable.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBoxTable.Location = New Point(551, 57)
        GroupBoxTable.Name = "GroupBoxTable"
        GroupBoxTable.Size = New Size(639, 554)
        GroupBoxTable.TabIndex = 5
        GroupBoxTable.TabStop = False
        GroupBoxTable.Text = "Quản lý bàn"
        ' 
        ' lbAreaIdHidden
        ' 
        lbAreaIdHidden.AutoSize = True
        lbAreaIdHidden.Font = New Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point)
        lbAreaIdHidden.Location = New Point(361, 19)
        lbAreaIdHidden.Name = "lbAreaIdHidden"
        lbAreaIdHidden.Size = New Size(28, 11)
        lbAreaIdHidden.TabIndex = 11
        lbAreaIdHidden.Text = "Label8"
        lbAreaIdHidden.Visible = False
        ' 
        ' txtMaxCapacity
        ' 
        txtMaxCapacity.Location = New Point(485, 40)
        txtMaxCapacity.Name = "txtMaxCapacity"
        txtMaxCapacity.Size = New Size(127, 35)
        txtMaxCapacity.TabIndex = 10
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(438, 52)
        Label7.Name = "Label7"
        Label7.Size = New Size(45, 17)
        Label7.TabIndex = 9
        Label7.Text = "Tối đa"
        ' 
        ' lbltableIdHidden
        ' 
        lbltableIdHidden.AutoSize = True
        lbltableIdHidden.Font = New Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point)
        lbltableIdHidden.Location = New Point(419, 19)
        lbltableIdHidden.Name = "lbltableIdHidden"
        lbltableIdHidden.Size = New Size(28, 11)
        lbltableIdHidden.TabIndex = 8
        lbltableIdHidden.Text = "Label7"
        lbltableIdHidden.Visible = False
        ' 
        ' btnUpdateTable
        ' 
        btnUpdateTable.BackColor = Color.Blue
        btnUpdateTable.Font = New Font("Segoe UI Black", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnUpdateTable.ForeColor = Color.Snow
        btnUpdateTable.Location = New Point(134, 504)
        btnUpdateTable.Name = "btnUpdateTable"
        btnUpdateTable.Size = New Size(182, 41)
        btnUpdateTable.TabIndex = 7
        btnUpdateTable.Text = "Sửa bàn đã chọn"
        btnUpdateTable.UseVisualStyleBackColor = False
        ' 
        ' btnDeleteTable
        ' 
        btnDeleteTable.BackColor = Color.Red
        btnDeleteTable.Font = New Font("Segoe UI Black", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnDeleteTable.ForeColor = Color.Snow
        btnDeleteTable.Location = New Point(332, 504)
        btnDeleteTable.Name = "btnDeleteTable"
        btnDeleteTable.Size = New Size(182, 41)
        btnDeleteTable.TabIndex = 6
        btnDeleteTable.Text = "Xóa bàn đã chọn"
        btnDeleteTable.UseVisualStyleBackColor = False
        ' 
        ' btnAddTable
        ' 
        btnAddTable.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        btnAddTable.Font = New Font("Segoe UI Black", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddTable.ForeColor = Color.Snow
        btnAddTable.Location = New Point(6, 504)
        btnAddTable.Name = "btnAddTable"
        btnAddTable.Size = New Size(111, 41)
        btnAddTable.TabIndex = 5
        btnAddTable.Text = "Thêm bàn"
        btnAddTable.UseVisualStyleBackColor = False
        ' 
        ' DGVTable
        ' 
        DGVTable.AllowUserToAddRows = False
        DGVTable.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = SystemColors.Control
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle4.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = Color.White
        DataGridViewCellStyle4.SelectionForeColor = Color.White
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        DGVTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        DGVTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVTable.Columns.AddRange(New DataGridViewColumn() {ownerIdTable, table_areaId, table_areaName, tableId, maxCapacity})
        DGVTable.Location = New Point(6, 86)
        DGVTable.Name = "DGVTable"
        DGVTable.ReadOnly = True
        DGVTable.RowTemplate.Height = 25
        DGVTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVTable.Size = New Size(627, 412)
        DGVTable.TabIndex = 3
        ' 
        ' ownerIdTable
        ' 
        ownerIdTable.HeaderText = "ownerId"
        ownerIdTable.Name = "ownerIdTable"
        ownerIdTable.ReadOnly = True
        ownerIdTable.Visible = False
        ' 
        ' table_areaId
        ' 
        table_areaId.DataPropertyName = "areaId"
        table_areaId.HeaderText = "areaId"
        table_areaId.Name = "table_areaId"
        table_areaId.ReadOnly = True
        table_areaId.Visible = False
        ' 
        ' table_areaName
        ' 
        table_areaName.DataPropertyName = "areaName"
        DataGridViewCellStyle5.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        table_areaName.DefaultCellStyle = DataGridViewCellStyle5
        table_areaName.HeaderText = "Tên khu vực"
        table_areaName.Name = "table_areaName"
        table_areaName.ReadOnly = True
        table_areaName.Width = 200
        ' 
        ' tableId
        ' 
        tableId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        tableId.DataPropertyName = "tableId"
        DataGridViewCellStyle6.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        tableId.DefaultCellStyle = DataGridViewCellStyle6
        tableId.HeaderText = "Số Bàn"
        tableId.Name = "tableId"
        tableId.ReadOnly = True
        ' 
        ' maxCapacity
        ' 
        maxCapacity.DataPropertyName = "maxCapacity"
        DataGridViewCellStyle7.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        maxCapacity.DefaultCellStyle = DataGridViewCellStyle7
        maxCapacity.HeaderText = "Tối đa"
        maxCapacity.Name = "maxCapacity"
        maxCapacity.ReadOnly = True
        ' 
        ' ComboBoxAreaName
        ' 
        ComboBoxAreaName.FormattingEnabled = True
        ComboBoxAreaName.Location = New Point(71, 39)
        ComboBoxAreaName.Name = "ComboBoxAreaName"
        ComboBoxAreaName.Size = New Size(127, 38)
        ComboBoxAreaName.TabIndex = 3
        ' 
        ' txtTableId
        ' 
        txtTableId.Location = New Point(280, 41)
        txtTableId.Name = "txtTableId"
        txtTableId.Size = New Size(127, 35)
        txtTableId.TabIndex = 2
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(229, 52)
        Label5.Name = "Label5"
        Label5.Size = New Size(48, 17)
        Label5.TabIndex = 1
        Label5.Text = "Số Bàn"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(12, 50)
        Label4.Name = "Label4"
        Label4.Size = New Size(54, 17)
        Label4.TabIndex = 0
        Label4.Text = "Khu vực"
        ' 
        ' UCTableArea
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(GroupBoxTable)
        Controls.Add(GroupBoxArea)
        Controls.Add(Label1)
        ForeColor = SystemColors.ControlText
        Name = "UCTableArea"
        Size = New Size(1195, 611)
        GroupBoxArea.ResumeLayout(False)
        GroupBoxArea.PerformLayout()
        CType(DGVArea, ComponentModel.ISupportInitialize).EndInit()
        GroupBoxTable.ResumeLayout(False)
        GroupBoxTable.PerformLayout()
        CType(DGVTable, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBoxArea As GroupBox
    Friend WithEvents txtAreaId As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnUpdateArea As Button
    Friend WithEvents btnDeleteArea As Button
    Friend WithEvents btnAddArea As Button
    Friend WithEvents DGVArea As DataGridView
    Friend WithEvents ownerId As DataGridViewTextBoxColumn
    Friend WithEvents areaId As DataGridViewTextBoxColumn
    Friend WithEvents areaName As DataGridViewTextBoxColumn
    Friend WithEvents txtAreaName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBoxTable As GroupBox
    Friend WithEvents lbAreaIdHidden As Label
    Friend WithEvents txtMaxCapacity As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lbltableIdHidden As Label
    Friend WithEvents btnUpdateTable As Button
    Friend WithEvents btnDeleteTable As Button
    Friend WithEvents btnAddTable As Button
    Friend WithEvents DGVTable As DataGridView
    Friend WithEvents ownerIdTable As DataGridViewTextBoxColumn
    Friend WithEvents table_areaId As DataGridViewTextBoxColumn
    Friend WithEvents table_areaName As DataGridViewTextBoxColumn
    Friend WithEvents tableId As DataGridViewTextBoxColumn
    Friend WithEvents maxCapacity As DataGridViewTextBoxColumn
    Friend WithEvents ComboBoxAreaName As ComboBox
    Friend WithEvents txtTableId As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
End Class
