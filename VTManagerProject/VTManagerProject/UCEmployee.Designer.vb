<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCEmployee
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
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Label1 = New Label()
        Panel1 = New Panel()
        btnSearch = New Button()
        btnCLear = New Button()
        txtEmployeeName = New TextBox()
        Label3 = New Label()
        ComboBoxEmployeeClass = New ComboBox()
        Label2 = New Label()
        DGVEmployee = New DataGridView()
        GroupBox2 = New GroupBox()
        btnAddEmployee = New Button()
        ownerId = New DataGridViewTextBoxColumn()
        employeeId = New DataGridViewTextBoxColumn()
        employeeClassId = New DataGridViewTextBoxColumn()
        employeeClassName = New DataGridViewTextBoxColumn()
        employeeName = New DataGridViewTextBoxColumn()
        password = New DataGridViewTextBoxColumn()
        birthday = New DataGridViewTextBoxColumn()
        startDate = New DataGridViewTextBoxColumn()
        deleteEmployee = New DataGridViewButtonColumn()
        updateEmployee = New DataGridViewButtonColumn()
        Panel1.SuspendLayout()
        CType(DGVEmployee, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.Highlight
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(1190, 61)
        Label1.TabIndex = 2
        Label1.Text = "Danh Mục Nhân Viên"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(btnSearch)
        Panel1.Controls.Add(btnCLear)
        Panel1.Controls.Add(txtEmployeeName)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(ComboBoxEmployeeClass)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(6, 49)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1175, 46)
        Panel1.TabIndex = 3
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.White
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnSearch.Location = New Point(739, 13)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 5
        btnSearch.Text = "Tìm kiếm"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' btnCLear
        ' 
        btnCLear.BackColor = Color.White
        btnCLear.FlatStyle = FlatStyle.Flat
        btnCLear.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnCLear.Location = New Point(645, 13)
        btnCLear.Name = "btnCLear"
        btnCLear.Size = New Size(75, 23)
        btnCLear.TabIndex = 4
        btnCLear.Text = "Làm mới"
        btnCLear.UseVisualStyleBackColor = False
        ' 
        ' txtEmployeeName
        ' 
        txtEmployeeName.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmployeeName.Location = New Point(384, 13)
        txtEmployeeName.Name = "txtEmployeeName"
        txtEmployeeName.Size = New Size(184, 23)
        txtEmployeeName.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(295, 18)
        Label3.Name = "Label3"
        Label3.Size = New Size(87, 17)
        Label3.TabIndex = 2
        Label3.Text = "Tên nhân viên"
        ' 
        ' ComboBoxEmployeeClass
        ' 
        ComboBoxEmployeeClass.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxEmployeeClass.FormattingEnabled = True
        ComboBoxEmployeeClass.Location = New Point(110, 13)
        ComboBoxEmployeeClass.Name = "ComboBoxEmployeeClass"
        ComboBoxEmployeeClass.Size = New Size(151, 23)
        ComboBoxEmployeeClass.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(17, 16)
        Label2.Name = "Label2"
        Label2.Size = New Size(91, 17)
        Label2.TabIndex = 0
        Label2.Text = "Loại nhân viên"
        ' 
        ' DGVEmployee
        ' 
        DGVEmployee.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DGVEmployee.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DGVEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVEmployee.Columns.AddRange(New DataGridViewColumn() {ownerId, employeeId, employeeClassId, employeeClassName, employeeName, password, birthday, startDate, deleteEmployee, updateEmployee})
        DGVEmployee.Location = New Point(6, 101)
        DGVEmployee.Name = "DGVEmployee"
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = SystemColors.Control
        DataGridViewCellStyle11.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle11.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.True
        DGVEmployee.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        DGVEmployee.RowHeadersVisible = False
        DGVEmployee.RowTemplate.Height = 25
        DGVEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVEmployee.Size = New Size(1181, 406)
        DGVEmployee.TabIndex = 4
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(btnAddEmployee)
        GroupBox2.Controls.Add(Panel1)
        GroupBox2.Controls.Add(DGVEmployee)
        GroupBox2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox2.Location = New Point(0, 64)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(1187, 547)
        GroupBox2.TabIndex = 6
        GroupBox2.TabStop = False
        GroupBox2.Text = "Nhân viên"
        ' 
        ' btnAddEmployee
        ' 
        btnAddEmployee.BackColor = Color.White
        btnAddEmployee.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddEmployee.Location = New Point(1104, 515)
        btnAddEmployee.Name = "btnAddEmployee"
        btnAddEmployee.Size = New Size(75, 23)
        btnAddEmployee.TabIndex = 5
        btnAddEmployee.Text = "Thêm mới"
        btnAddEmployee.UseVisualStyleBackColor = False
        ' 
        ' ownerId
        ' 
        ownerId.DataPropertyName = "ownerId"
        ownerId.HeaderText = "ownerId"
        ownerId.Name = "ownerId"
        ownerId.Visible = False
        ' 
        ' employeeId
        ' 
        employeeId.DataPropertyName = "employeeId"
        DataGridViewCellStyle2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        employeeId.DefaultCellStyle = DataGridViewCellStyle2
        employeeId.HeaderText = "ID"
        employeeId.Name = "employeeId"
        employeeId.Width = 60
        ' 
        ' employeeClassId
        ' 
        employeeClassId.DataPropertyName = "employeeClassId"
        DataGridViewCellStyle3.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        employeeClassId.DefaultCellStyle = DataGridViewCellStyle3
        employeeClassId.HeaderText = "Phân loại ID"
        employeeClassId.Name = "employeeClassId"
        employeeClassId.Visible = False
        employeeClassId.Width = 200
        ' 
        ' employeeClassName
        ' 
        employeeClassName.DataPropertyName = "employeeClassName"
        DataGridViewCellStyle4.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        employeeClassName.DefaultCellStyle = DataGridViewCellStyle4
        employeeClassName.HeaderText = "Phân loại"
        employeeClassName.Name = "employeeClassName"
        employeeClassName.Width = 200
        ' 
        ' employeeName
        ' 
        employeeName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        employeeName.DataPropertyName = "employeeName"
        DataGridViewCellStyle5.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        employeeName.DefaultCellStyle = DataGridViewCellStyle5
        employeeName.HeaderText = "Tên nhân viên"
        employeeName.Name = "employeeName"
        ' 
        ' password
        ' 
        password.DataPropertyName = "password"
        DataGridViewCellStyle6.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        password.DefaultCellStyle = DataGridViewCellStyle6
        password.HeaderText = "Mật khẩu"
        password.Name = "password"
        password.Width = 150
        ' 
        ' birthday
        ' 
        birthday.DataPropertyName = "birthday"
        DataGridViewCellStyle7.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        birthday.DefaultCellStyle = DataGridViewCellStyle7
        birthday.HeaderText = "Ngày sinh"
        birthday.Name = "birthday"
        birthday.Width = 160
        ' 
        ' startDate
        ' 
        startDate.DataPropertyName = "startDate"
        DataGridViewCellStyle8.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        startDate.DefaultCellStyle = DataGridViewCellStyle8
        startDate.HeaderText = "Bắt đầu"
        startDate.Name = "startDate"
        startDate.Width = 160
        ' 
        ' deleteEmployee
        ' 
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        deleteEmployee.DefaultCellStyle = DataGridViewCellStyle9
        deleteEmployee.HeaderText = ""
        deleteEmployee.Name = "deleteEmployee"
        deleteEmployee.Text = "delete"
        deleteEmployee.UseColumnTextForButtonValue = True
        deleteEmployee.Width = 50
        ' 
        ' updateEmployee
        ' 
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        updateEmployee.DefaultCellStyle = DataGridViewCellStyle10
        updateEmployee.HeaderText = ""
        updateEmployee.Name = "updateEmployee"
        updateEmployee.Text = "update"
        updateEmployee.UseColumnTextForButtonValue = True
        updateEmployee.Width = 55
        ' 
        ' UCEmployee
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(GroupBox2)
        Controls.Add(Label1)
        Name = "UCEmployee"
        Size = New Size(1190, 611)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(DGVEmployee, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnCLear As Button
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxEmployeeClass As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DGVEmployee As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnAddEmployee As Button
    Friend WithEvents ownerId As DataGridViewTextBoxColumn
    Friend WithEvents employeeId As DataGridViewTextBoxColumn
    Friend WithEvents employeeClassId As DataGridViewTextBoxColumn
    Friend WithEvents employeeClassName As DataGridViewTextBoxColumn
    Friend WithEvents employeeName As DataGridViewTextBoxColumn
    Friend WithEvents password As DataGridViewTextBoxColumn
    Friend WithEvents birthday As DataGridViewTextBoxColumn
    Friend WithEvents startDate As DataGridViewTextBoxColumn
    Friend WithEvents deleteEmployee As DataGridViewButtonColumn
    Friend WithEvents updateEmployee As DataGridViewButtonColumn
End Class
