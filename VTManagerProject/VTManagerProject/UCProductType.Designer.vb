<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCProductType
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
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        btnAdd = New Button()
        btnClear = New Button()
        txtDesc = New TextBox()
        txtProductTypeName = New TextBox()
        txtProductTypeId = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        GroupBox2 = New GroupBox()
        btnUpdate = New Button()
        txtUpdateDesc = New TextBox()
        txtUpdateName = New TextBox()
        txtUpdateID = New TextBox()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        DGVProductType = New DataGridView()
        ownerId = New DataGridViewTextBoxColumn()
        productTypeId = New DataGridViewTextBoxColumn()
        productTypeName = New DataGridViewTextBoxColumn()
        description = New DataGridViewTextBoxColumn()
        delete = New DataGridViewButtonColumn()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(DGVProductType, ComponentModel.ISupportInitialize).BeginInit()
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
        Label1.Text = "Danh Mục Loại Sản Phẩm"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnAdd)
        GroupBox1.Controls.Add(btnClear)
        GroupBox1.Controls.Add(txtDesc)
        GroupBox1.Controls.Add(txtProductTypeName)
        GroupBox1.Controls.Add(txtProductTypeId)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox1.Location = New Point(677, 64)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(510, 547)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Thêm Loại Sản Phẩm"
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.White
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnAdd.Location = New Point(309, 370)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 12
        btnAdd.Text = "Thêm mới"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.White
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        btnClear.Location = New Point(112, 370)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 23)
        btnClear.TabIndex = 11
        btnClear.Text = "Làm mới"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' txtDesc
        ' 
        txtDesc.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        txtDesc.Location = New Point(158, 219)
        txtDesc.Multiline = True
        txtDesc.Name = "txtDesc"
        txtDesc.Size = New Size(306, 90)
        txtDesc.TabIndex = 10
        ' 
        ' txtProductTypeName
        ' 
        txtProductTypeName.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        txtProductTypeName.Location = New Point(158, 163)
        txtProductTypeName.Name = "txtProductTypeName"
        txtProductTypeName.Size = New Size(306, 23)
        txtProductTypeName.TabIndex = 9
        ' 
        ' txtProductTypeId
        ' 
        txtProductTypeId.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        txtProductTypeId.Location = New Point(158, 105)
        txtProductTypeId.Name = "txtProductTypeId"
        txtProductTypeId.ReadOnly = True
        txtProductTypeId.Size = New Size(306, 23)
        txtProductTypeId.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(37, 222)
        Label4.Name = "Label4"
        Label4.Size = New Size(43, 17)
        Label4.TabIndex = 2
        Label4.Text = "Mô tả"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(35, 166)
        Label3.Name = "Label3"
        Label3.Size = New Size(114, 17)
        Label3.TabIndex = 1
        Label3.Text = "Tên loại sản phẩm"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(35, 108)
        Label2.Name = "Label2"
        Label2.Size = New Size(109, 17)
        Label2.TabIndex = 0
        Label2.Text = "ID Loại sản phẩm"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(btnUpdate)
        GroupBox2.Controls.Add(txtUpdateDesc)
        GroupBox2.Controls.Add(txtUpdateName)
        GroupBox2.Controls.Add(txtUpdateID)
        GroupBox2.Controls.Add(Label7)
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(DGVProductType)
        GroupBox2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox2.Location = New Point(3, 64)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(668, 547)
        GroupBox2.TabIndex = 4
        GroupBox2.TabStop = False
        GroupBox2.Text = "Hiển Thị Loại Sản Phẩm"
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.White
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnUpdate.Location = New Point(582, 49)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(75, 25)
        btnUpdate.TabIndex = 7
        btnUpdate.Text = "Cập nhật"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' txtUpdateDesc
        ' 
        txtUpdateDesc.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtUpdateDesc.Location = New Point(318, 49)
        txtUpdateDesc.Name = "txtUpdateDesc"
        txtUpdateDesc.Size = New Size(241, 25)
        txtUpdateDesc.TabIndex = 6
        ' 
        ' txtUpdateName
        ' 
        txtUpdateName.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtUpdateName.Location = New Point(148, 51)
        txtUpdateName.Name = "txtUpdateName"
        txtUpdateName.Size = New Size(118, 25)
        txtUpdateName.TabIndex = 5
        ' 
        ' txtUpdateID
        ' 
        txtUpdateID.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtUpdateID.Location = New Point(34, 51)
        txtUpdateID.Name = "txtUpdateID"
        txtUpdateID.ReadOnly = True
        txtUpdateID.Size = New Size(67, 25)
        txtUpdateID.TabIndex = 4
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(117, 54)
        Label7.Name = "Label7"
        Label7.Size = New Size(28, 17)
        Label7.TabIndex = 3
        Label7.Text = "Tên"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(273, 54)
        Label6.Name = "Label6"
        Label6.Size = New Size(43, 17)
        Label6.TabIndex = 2
        Label6.Text = "Mô tả"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(9, 54)
        Label5.Name = "Label5"
        Label5.Size = New Size(20, 17)
        Label5.TabIndex = 1
        Label5.Text = "ID"
        ' 
        ' DGVProductType
        ' 
        DGVProductType.AllowUserToAddRows = False
        DGVProductType.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DGVProductType.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DGVProductType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVProductType.Columns.AddRange(New DataGridViewColumn() {ownerId, productTypeId, productTypeName, description, delete})
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = SystemColors.Window
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle5.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.False
        DGVProductType.DefaultCellStyle = DataGridViewCellStyle5
        DGVProductType.EnableHeadersVisualStyles = False
        DGVProductType.Location = New Point(6, 92)
        DGVProductType.Name = "DGVProductType"
        DGVProductType.ReadOnly = True
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = SystemColors.Control
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        DataGridViewCellStyle6.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = Color.White
        DataGridViewCellStyle6.SelectionForeColor = SystemColors.Desktop
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        DGVProductType.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        DGVProductType.RowHeadersVisible = False
        DGVProductType.RowTemplate.Height = 25
        DGVProductType.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVProductType.Size = New Size(651, 436)
        DGVProductType.TabIndex = 0
        ' 
        ' ownerId
        ' 
        ownerId.DataPropertyName = "ownerId"
        ownerId.HeaderText = "ownerId"
        ownerId.Name = "ownerId"
        ownerId.ReadOnly = True
        ownerId.Visible = False
        ' 
        ' productTypeId
        ' 
        productTypeId.DataPropertyName = "productTypeId"
        DataGridViewCellStyle2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        productTypeId.DefaultCellStyle = DataGridViewCellStyle2
        productTypeId.HeaderText = "ID"
        productTypeId.Name = "productTypeId"
        productTypeId.ReadOnly = True
        productTypeId.Width = 60
        ' 
        ' productTypeName
        ' 
        productTypeName.DataPropertyName = "productTypeName"
        DataGridViewCellStyle3.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        productTypeName.DefaultCellStyle = DataGridViewCellStyle3
        productTypeName.HeaderText = "Tên loại sản phẩm"
        productTypeName.Name = "productTypeName"
        productTypeName.ReadOnly = True
        productTypeName.Width = 250
        ' 
        ' description
        ' 
        description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        description.DataPropertyName = "description"
        DataGridViewCellStyle4.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        description.DefaultCellStyle = DataGridViewCellStyle4
        description.HeaderText = "Mô tả"
        description.Name = "description"
        description.ReadOnly = True
        ' 
        ' delete
        ' 
        delete.HeaderText = ""
        delete.Name = "delete"
        delete.ReadOnly = True
        delete.Text = "delete"
        delete.UseColumnTextForButtonValue = True
        delete.Width = 50
        ' 
        ' UCProductType
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(Label1)
        ForeColor = SystemColors.ControlText
        Name = "UCProductType"
        Size = New Size(1190, 611)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(DGVProductType, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtProductTypeId As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents txtProductTypeName As TextBox
    Friend WithEvents DGVProductType As DataGridView
    Friend WithEvents ownerId As DataGridViewTextBoxColumn
    Friend WithEvents productTypeId As DataGridViewTextBoxColumn
    Friend WithEvents productTypeName As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents delete As DataGridViewButtonColumn
    Friend WithEvents txtUpdateID As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtUpdateDesc As TextBox
    Friend WithEvents txtUpdateName As TextBox
End Class
