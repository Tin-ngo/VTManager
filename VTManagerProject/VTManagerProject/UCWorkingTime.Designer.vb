<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCWorkingTime
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
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        ComboBoxDateOfWeek = New ComboBox()
        Label9 = New Label()
        ComboBoxWorkingTime = New ComboBox()
        txtEmployeeName = New TextBox()
        btnSearch = New Button()
        btnClearList = New Button()
        Label8 = New Label()
        Label7 = New Label()
        DGVWorkingTime = New DataGridView()
        idWorkingTime = New DataGridViewTextBoxColumn()
        dateOfWeek = New DataGridViewTextBoxColumn()
        dateOfWeek_Show = New DataGridViewTextBoxColumn()
        startTime = New DataGridViewTextBoxColumn()
        startTime_Show = New DataGridViewTextBoxColumn()
        endTime = New DataGridViewTextBoxColumn()
        endTime_Show = New DataGridViewTextBoxColumn()
        salaryId = New DataGridViewTextBoxColumn()
        salary = New DataGridViewTextBoxColumn()
        employeeId = New DataGridViewTextBoxColumn()
        employeeName = New DataGridViewTextBoxColumn()
        edit = New DataGridViewButtonColumn()
        delete = New DataGridViewButtonColumn()
        addNew = New DataGridViewButtonColumn()
        Label2 = New Label()
        Label3 = New Label()
        Label6 = New Label()
        ComboBoxEmployee = New ComboBox()
        btnClear = New Button()
        btnUpdate = New Button()
        ComboBoxWorkingTime2 = New ComboBox()
        ComboBoxDateOfWeek2 = New ComboBox()
        GroupBox2 = New GroupBox()
        lblDateOfWeek_Old = New Label()
        lblWorkingTime_Old = New Label()
        lblEmployeeId_Old = New Label()
        GroupBox1.SuspendLayout()
        CType(DGVWorkingTime, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.Highlight
        Label1.Location = New Point(2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(1190, 61)
        Label1.TabIndex = 2
        Label1.Text = "THỜI GIAN LÀM VIỆC"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(ComboBoxDateOfWeek)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Controls.Add(ComboBoxWorkingTime)
        GroupBox1.Controls.Add(txtEmployeeName)
        GroupBox1.Controls.Add(btnSearch)
        GroupBox1.Controls.Add(btnClearList)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Controls.Add(DGVWorkingTime)
        GroupBox1.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox1.Location = New Point(3, 64)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(820, 544)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Hiển Thị Thời Gian Làm"
        ' 
        ' ComboBoxDateOfWeek
        ' 
        ComboBoxDateOfWeek.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxDateOfWeek.FormattingEnabled = True
        ComboBoxDateOfWeek.Location = New Point(233, 47)
        ComboBoxDateOfWeek.Name = "ComboBoxDateOfWeek"
        ComboBoxDateOfWeek.Size = New Size(95, 23)
        ComboBoxDateOfWeek.TabIndex = 8
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Location = New Point(201, 51)
        Label9.Name = "Label9"
        Label9.Size = New Size(30, 17)
        Label9.TabIndex = 7
        Label9.Text = "Thứ"
        ' 
        ' ComboBoxWorkingTime
        ' 
        ComboBoxWorkingTime.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxWorkingTime.FormattingEnabled = True
        ComboBoxWorkingTime.Location = New Point(405, 48)
        ComboBoxWorkingTime.Name = "ComboBoxWorkingTime"
        ComboBoxWorkingTime.Size = New Size(121, 23)
        ComboBoxWorkingTime.TabIndex = 6
        ' 
        ' txtEmployeeName
        ' 
        txtEmployeeName.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmployeeName.Location = New Point(82, 48)
        txtEmployeeName.Name = "txtEmployeeName"
        txtEmployeeName.Size = New Size(100, 23)
        txtEmployeeName.TabIndex = 5
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.White
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnSearch.Location = New Point(631, 49)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 4
        btnSearch.Text = "Tìm kiếm"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' btnClearList
        ' 
        btnClearList.BackColor = Color.White
        btnClearList.FlatStyle = FlatStyle.Flat
        btnClearList.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnClearList.Location = New Point(550, 49)
        btnClearList.Name = "btnClearList"
        btnClearList.Size = New Size(75, 23)
        btnClearList.TabIndex = 3
        btnClearList.Text = "Làm mới"
        btnClearList.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.Location = New Point(342, 51)
        Label8.Name = "Label8"
        Label8.Size = New Size(62, 17)
        Label8.TabIndex = 2
        Label8.Text = "Thời gian"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(15, 51)
        Label7.Name = "Label7"
        Label7.Size = New Size(66, 17)
        Label7.TabIndex = 1
        Label7.Text = "Nhân viên"
        ' 
        ' DGVWorkingTime
        ' 
        DGVWorkingTime.AllowUserToAddRows = False
        DGVWorkingTime.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DGVWorkingTime.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DGVWorkingTime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVWorkingTime.Columns.AddRange(New DataGridViewColumn() {idWorkingTime, dateOfWeek, dateOfWeek_Show, startTime, startTime_Show, endTime, endTime_Show, salaryId, salary, employeeId, employeeName, edit, delete, addNew})
        DGVWorkingTime.EnableHeadersVisualStyles = False
        DGVWorkingTime.Location = New Point(6, 90)
        DGVWorkingTime.Name = "DGVWorkingTime"
        DGVWorkingTime.ReadOnly = True
        DGVWorkingTime.RowHeadersVisible = False
        DGVWorkingTime.RowTemplate.Height = 25
        DGVWorkingTime.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVWorkingTime.Size = New Size(808, 442)
        DGVWorkingTime.TabIndex = 0
        ' 
        ' idWorkingTime
        ' 
        idWorkingTime.DataPropertyName = "idWorkingTime"
        DataGridViewCellStyle2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        idWorkingTime.DefaultCellStyle = DataGridViewCellStyle2
        idWorkingTime.HeaderText = "ID"
        idWorkingTime.Name = "idWorkingTime"
        idWorkingTime.ReadOnly = True
        idWorkingTime.Width = 60
        ' 
        ' dateOfWeek
        ' 
        dateOfWeek.DataPropertyName = "dateOfWeek"
        DataGridViewCellStyle3.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        dateOfWeek.DefaultCellStyle = DataGridViewCellStyle3
        dateOfWeek.HeaderText = "Thứ"
        dateOfWeek.Name = "dateOfWeek"
        dateOfWeek.ReadOnly = True
        dateOfWeek.Visible = False
        ' 
        ' dateOfWeek_Show
        ' 
        dateOfWeek_Show.DataPropertyName = "dateOfWeek_Show"
        DataGridViewCellStyle4.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        dateOfWeek_Show.DefaultCellStyle = DataGridViewCellStyle4
        dateOfWeek_Show.HeaderText = "Thứ"
        dateOfWeek_Show.Name = "dateOfWeek_Show"
        dateOfWeek_Show.ReadOnly = True
        ' 
        ' startTime
        ' 
        startTime.DataPropertyName = "startTime"
        DataGridViewCellStyle5.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        startTime.DefaultCellStyle = DataGridViewCellStyle5
        startTime.HeaderText = "Bắt đầu"
        startTime.Name = "startTime"
        startTime.ReadOnly = True
        startTime.Visible = False
        ' 
        ' startTime_Show
        ' 
        startTime_Show.DataPropertyName = "startTime_Show"
        DataGridViewCellStyle6.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        startTime_Show.DefaultCellStyle = DataGridViewCellStyle6
        startTime_Show.HeaderText = "Bắt đầu"
        startTime_Show.Name = "startTime_Show"
        startTime_Show.ReadOnly = True
        ' 
        ' endTime
        ' 
        endTime.DataPropertyName = "endTime"
        DataGridViewCellStyle7.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        endTime.DefaultCellStyle = DataGridViewCellStyle7
        endTime.HeaderText = "Kết thúc"
        endTime.Name = "endTime"
        endTime.ReadOnly = True
        endTime.Visible = False
        ' 
        ' endTime_Show
        ' 
        endTime_Show.DataPropertyName = "endTime_Show"
        DataGridViewCellStyle8.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        endTime_Show.DefaultCellStyle = DataGridViewCellStyle8
        endTime_Show.HeaderText = "Kết thúc"
        endTime_Show.Name = "endTime_Show"
        endTime_Show.ReadOnly = True
        ' 
        ' salaryId
        ' 
        salaryId.DataPropertyName = "salaryId"
        salaryId.HeaderText = "salaryId"
        salaryId.Name = "salaryId"
        salaryId.ReadOnly = True
        salaryId.Visible = False
        salaryId.Width = 60
        ' 
        ' salary
        ' 
        salary.DataPropertyName = "salary"
        DataGridViewCellStyle9.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        salary.DefaultCellStyle = DataGridViewCellStyle9
        salary.HeaderText = "Lương"
        salary.Name = "salary"
        salary.ReadOnly = True
        ' 
        ' employeeId
        ' 
        employeeId.DataPropertyName = "employeeId"
        employeeId.HeaderText = "ID NV"
        employeeId.Name = "employeeId"
        employeeId.ReadOnly = True
        employeeId.Visible = False
        employeeId.Width = 60
        ' 
        ' employeeName
        ' 
        employeeName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        employeeName.DataPropertyName = "employeeName"
        DataGridViewCellStyle10.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        employeeName.DefaultCellStyle = DataGridViewCellStyle10
        employeeName.HeaderText = "Tên NV"
        employeeName.Name = "employeeName"
        employeeName.ReadOnly = True
        ' 
        ' edit
        ' 
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        edit.DefaultCellStyle = DataGridViewCellStyle11
        edit.HeaderText = ""
        edit.Name = "edit"
        edit.ReadOnly = True
        edit.Text = "edit"
        edit.UseColumnTextForButtonValue = True
        edit.Width = 60
        ' 
        ' delete
        ' 
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        delete.DefaultCellStyle = DataGridViewCellStyle12
        delete.HeaderText = ""
        delete.Name = "delete"
        delete.ReadOnly = True
        delete.Text = "delete"
        delete.UseColumnTextForButtonValue = True
        delete.Width = 60
        ' 
        ' addNew
        ' 
        DataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        addNew.DefaultCellStyle = DataGridViewCellStyle13
        addNew.HeaderText = ""
        addNew.Name = "addNew"
        addNew.ReadOnly = True
        addNew.Text = "add"
        addNew.UseColumnTextForButtonValue = True
        addNew.Width = 50
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(0, 212)
        Label2.Name = "Label2"
        Label2.Size = New Size(78, 17)
        Label2.TabIndex = 0
        Label2.Text = "ID Thời gian"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(47, 158)
        Label3.Name = "Label3"
        Label3.Size = New Size(30, 17)
        Label3.TabIndex = 1
        Label3.Text = "Thứ"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(12, 265)
        Label6.Name = "Label6"
        Label6.Size = New Size(66, 17)
        Label6.TabIndex = 4
        Label6.Text = "Nhân viên"
        ' 
        ' ComboBoxEmployee
        ' 
        ComboBoxEmployee.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxEmployee.FormattingEnabled = True
        ComboBoxEmployee.Location = New Point(81, 262)
        ComboBoxEmployee.Name = "ComboBoxEmployee"
        ComboBoxEmployee.Size = New Size(211, 23)
        ComboBoxEmployee.TabIndex = 9
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.White
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnClear.Location = New Point(83, 323)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 23)
        btnClear.TabIndex = 10
        btnClear.Text = "Hủy"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.White
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnUpdate.Location = New Point(204, 323)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(75, 23)
        btnUpdate.TabIndex = 11
        btnUpdate.Text = "Cập nhật"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' ComboBoxWorkingTime2
        ' 
        ComboBoxWorkingTime2.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxWorkingTime2.FormattingEnabled = True
        ComboBoxWorkingTime2.Location = New Point(81, 209)
        ComboBoxWorkingTime2.Name = "ComboBoxWorkingTime2"
        ComboBoxWorkingTime2.Size = New Size(211, 23)
        ComboBoxWorkingTime2.TabIndex = 17
        ' 
        ' ComboBoxDateOfWeek2
        ' 
        ComboBoxDateOfWeek2.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxDateOfWeek2.FormattingEnabled = True
        ComboBoxDateOfWeek2.Location = New Point(80, 155)
        ComboBoxDateOfWeek2.Name = "ComboBoxDateOfWeek2"
        ComboBoxDateOfWeek2.Size = New Size(212, 23)
        ComboBoxDateOfWeek2.TabIndex = 18
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(lblDateOfWeek_Old)
        GroupBox2.Controls.Add(lblWorkingTime_Old)
        GroupBox2.Controls.Add(lblEmployeeId_Old)
        GroupBox2.Controls.Add(ComboBoxDateOfWeek2)
        GroupBox2.Controls.Add(ComboBoxWorkingTime2)
        GroupBox2.Controls.Add(btnUpdate)
        GroupBox2.Controls.Add(btnClear)
        GroupBox2.Controls.Add(ComboBoxEmployee)
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox2.Location = New Point(829, 64)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(363, 544)
        GroupBox2.TabIndex = 4
        GroupBox2.TabStop = False
        GroupBox2.Text = "Chỉnh Sửa"
        ' 
        ' lblDateOfWeek_Old
        ' 
        lblDateOfWeek_Old.AutoSize = True
        lblDateOfWeek_Old.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        lblDateOfWeek_Old.Location = New Point(299, 157)
        lblDateOfWeek_Old.Name = "lblDateOfWeek_Old"
        lblDateOfWeek_Old.Size = New Size(47, 15)
        lblDateOfWeek_Old.TabIndex = 21
        lblDateOfWeek_Old.Text = "Label10"
        lblDateOfWeek_Old.Visible = False
        ' 
        ' lblWorkingTime_Old
        ' 
        lblWorkingTime_Old.AutoSize = True
        lblWorkingTime_Old.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        lblWorkingTime_Old.Location = New Point(300, 211)
        lblWorkingTime_Old.Name = "lblWorkingTime_Old"
        lblWorkingTime_Old.Size = New Size(47, 15)
        lblWorkingTime_Old.TabIndex = 20
        lblWorkingTime_Old.Text = "Label10"
        lblWorkingTime_Old.Visible = False
        ' 
        ' lblEmployeeId_Old
        ' 
        lblEmployeeId_Old.AutoSize = True
        lblEmployeeId_Old.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        lblEmployeeId_Old.Location = New Point(300, 267)
        lblEmployeeId_Old.Name = "lblEmployeeId_Old"
        lblEmployeeId_Old.Size = New Size(47, 15)
        lblEmployeeId_Old.TabIndex = 19
        lblEmployeeId_Old.Text = "Label10"
        lblEmployeeId_Old.Visible = False
        ' 
        ' UCWorkingTime
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(Label1)
        ForeColor = SystemColors.ControlText
        Name = "UCWorkingTime"
        Size = New Size(1195, 611)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGVWorkingTime, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DGVWorkingTime As DataGridView
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnClearList As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBoxWorkingTime As ComboBox
    Friend WithEvents ComboBoxDateOfWeek As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBoxEmployee As ComboBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents ComboBoxWorkingTime2 As ComboBox
    Friend WithEvents ComboBoxDateOfWeek2 As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblEmployeeId_Old As Label
    Friend WithEvents lblDateOfWeek_Old As Label
    Friend WithEvents lblWorkingTime_Old As Label
    Friend WithEvents idWorkingTime As DataGridViewTextBoxColumn
    Friend WithEvents dateOfWeek As DataGridViewTextBoxColumn
    Friend WithEvents dateOfWeek_Show As DataGridViewTextBoxColumn
    Friend WithEvents startTime As DataGridViewTextBoxColumn
    Friend WithEvents startTime_Show As DataGridViewTextBoxColumn
    Friend WithEvents endTime As DataGridViewTextBoxColumn
    Friend WithEvents endTime_Show As DataGridViewTextBoxColumn
    Friend WithEvents salaryId As DataGridViewTextBoxColumn
    Friend WithEvents salary As DataGridViewTextBoxColumn
    Friend WithEvents employeeId As DataGridViewTextBoxColumn
    Friend WithEvents employeeName As DataGridViewTextBoxColumn
    Friend WithEvents edit As DataGridViewButtonColumn
    Friend WithEvents delete As DataGridViewButtonColumn
    Friend WithEvents addNew As DataGridViewButtonColumn
End Class
