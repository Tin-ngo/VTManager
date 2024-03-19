<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCEmployeeClass
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
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        btnAddEmployeeClass = New Button()
        DGVEmployeeClass = New DataGridView()
        btnUpdateEmployeeClass = New Button()
        txtEmployeeClassName1 = New TextBox()
        Label5 = New Label()
        txtemployeeClassId1 = New TextBox()
        Label4 = New Label()
        GroupBox2 = New GroupBox()
        btnClear = New Button()
        ownerId1 = New DataGridViewTextBoxColumn()
        employeeClassId1 = New DataGridViewTextBoxColumn()
        employeeClassName1 = New DataGridViewTextBoxColumn()
        delete = New DataGridViewButtonColumn()
        GroupBox1.SuspendLayout()
        CType(DGVEmployeeClass, ComponentModel.ISupportInitialize).BeginInit()
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
        Label1.Text = "DANH MỤC LOẠI NHÂN VIÊN"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnAddEmployeeClass)
        GroupBox1.Controls.Add(DGVEmployeeClass)
        GroupBox1.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox1.Location = New Point(3, 64)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(663, 547)
        GroupBox1.TabIndex = 6
        GroupBox1.TabStop = False
        GroupBox1.Text = "Loại nhân viên"
        ' 
        ' btnAddEmployeeClass
        ' 
        btnAddEmployeeClass.BackColor = Color.White
        btnAddEmployeeClass.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddEmployeeClass.Location = New Point(563, 514)
        btnAddEmployeeClass.Name = "btnAddEmployeeClass"
        btnAddEmployeeClass.Size = New Size(75, 23)
        btnAddEmployeeClass.TabIndex = 9
        btnAddEmployeeClass.Text = "Thêm mới"
        btnAddEmployeeClass.UseVisualStyleBackColor = False
        ' 
        ' DGVEmployeeClass
        ' 
        DGVEmployeeClass.AllowUserToAddRows = False
        DGVEmployeeClass.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DGVEmployeeClass.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DGVEmployeeClass.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVEmployeeClass.Columns.AddRange(New DataGridViewColumn() {ownerId1, employeeClassId1, employeeClassName1, delete})
        DGVEmployeeClass.EnableHeadersVisualStyles = False
        DGVEmployeeClass.Location = New Point(-1, 42)
        DGVEmployeeClass.Name = "DGVEmployeeClass"
        DGVEmployeeClass.ReadOnly = True
        DGVEmployeeClass.RowHeadersVisible = False
        DGVEmployeeClass.RowTemplate.Height = 25
        DGVEmployeeClass.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVEmployeeClass.Size = New Size(658, 463)
        DGVEmployeeClass.TabIndex = 8
        ' 
        ' btnUpdateEmployeeClass
        ' 
        btnUpdateEmployeeClass.BackColor = Color.White
        btnUpdateEmployeeClass.FlatStyle = FlatStyle.Flat
        btnUpdateEmployeeClass.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnUpdateEmployeeClass.Location = New Point(275, 243)
        btnUpdateEmployeeClass.Name = "btnUpdateEmployeeClass"
        btnUpdateEmployeeClass.Size = New Size(75, 23)
        btnUpdateEmployeeClass.TabIndex = 7
        btnUpdateEmployeeClass.Text = "Cập nhật"
        btnUpdateEmployeeClass.UseVisualStyleBackColor = False
        ' 
        ' txtEmployeeClassName1
        ' 
        txtEmployeeClassName1.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmployeeClassName1.Location = New Point(157, 170)
        txtEmployeeClassName1.Name = "txtEmployeeClassName1"
        txtEmployeeClassName1.Size = New Size(222, 23)
        txtEmployeeClassName1.TabIndex = 6
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(128, 172)
        Label5.Name = "Label5"
        Label5.Size = New Size(28, 17)
        Label5.TabIndex = 5
        Label5.Text = "Tên"
        ' 
        ' txtemployeeClassId1
        ' 
        txtemployeeClassId1.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        txtemployeeClassId1.Location = New Point(157, 129)
        txtemployeeClassId1.Name = "txtemployeeClassId1"
        txtemployeeClassId1.ReadOnly = True
        txtemployeeClassId1.Size = New Size(222, 23)
        txtemployeeClassId1.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(133, 132)
        Label4.Name = "Label4"
        Label4.Size = New Size(20, 17)
        Label4.TabIndex = 1
        Label4.Text = "ID"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(btnClear)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(txtemployeeClassId1)
        GroupBox2.Controls.Add(btnUpdateEmployeeClass)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(txtEmployeeClassName1)
        GroupBox2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox2.Location = New Point(672, 64)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(520, 541)
        GroupBox2.TabIndex = 7
        GroupBox2.TabStop = False
        GroupBox2.Text = "Cập nhật"
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.White
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnClear.Location = New Point(163, 243)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 23)
        btnClear.TabIndex = 8
        btnClear.Text = "Làm mới"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' ownerId1
        ' 
        ownerId1.DataPropertyName = "ownerId"
        ownerId1.HeaderText = "ownerId"
        ownerId1.Name = "ownerId1"
        ownerId1.ReadOnly = True
        ownerId1.Visible = False
        ' 
        ' employeeClassId1
        ' 
        employeeClassId1.DataPropertyName = "employeeClassId"
        DataGridViewCellStyle2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        employeeClassId1.DefaultCellStyle = DataGridViewCellStyle2
        employeeClassId1.HeaderText = "ID"
        employeeClassId1.Name = "employeeClassId1"
        employeeClassId1.ReadOnly = True
        employeeClassId1.Width = 60
        ' 
        ' employeeClassName1
        ' 
        employeeClassName1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        employeeClassName1.DataPropertyName = "employeeClassName"
        DataGridViewCellStyle3.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        employeeClassName1.DefaultCellStyle = DataGridViewCellStyle3
        employeeClassName1.HeaderText = "Tên loại nhân viên"
        employeeClassName1.Name = "employeeClassName1"
        employeeClassName1.ReadOnly = True
        ' 
        ' delete
        ' 
        delete.DataPropertyName = "delete"
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        delete.DefaultCellStyle = DataGridViewCellStyle4
        delete.HeaderText = ""
        delete.Name = "delete"
        delete.ReadOnly = True
        delete.Text = "delete"
        delete.UseColumnTextForButtonValue = True
        delete.Width = 50
        ' 
        ' UCEmployeeClass
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(Label1)
        Name = "UCEmployeeClass"
        Size = New Size(1195, 611)
        GroupBox1.ResumeLayout(False)
        CType(DGVEmployeeClass, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAddEmployeeClass As Button
    Friend WithEvents DGVEmployeeClass As DataGridView
    Friend WithEvents btnUpdateEmployeeClass As Button
    Friend WithEvents txtEmployeeClassName1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtemployeeClassId1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnClear As Button
    Friend WithEvents ownerId1 As DataGridViewTextBoxColumn
    Friend WithEvents employeeClassId1 As DataGridViewTextBoxColumn
    Friend WithEvents employeeClassName1 As DataGridViewTextBoxColumn
    Friend WithEvents delete As DataGridViewButtonColumn
End Class
