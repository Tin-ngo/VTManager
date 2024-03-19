<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCProduct
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
        Label1 = New Label()
        Panel1 = New Panel()
        btnNew = New Button()
        btnClear = New Button()
        btnSearch = New Button()
        txtProductName = New TextBox()
        Label3 = New Label()
        ComboBoxProductType = New ComboBox()
        Label2 = New Label()
        DGVProducts = New DataGridView()
        ownerId = New DataGridViewTextBoxColumn()
        productTypeId = New DataGridViewTextBoxColumn()
        productId = New DataGridViewTextBoxColumn()
        productTypeName = New DataGridViewTextBoxColumn()
        productName = New DataGridViewTextBoxColumn()
        productImage = New DataGridViewTextBoxColumn()
        unitPrice = New DataGridViewTextBoxColumn()
        tax = New DataGridViewTextBoxColumn()
        vatId = New DataGridViewTextBoxColumn()
        description = New DataGridViewTextBoxColumn()
        edit = New DataGridViewButtonColumn()
        delete = New DataGridViewButtonColumn()
        Panel1.SuspendLayout()
        CType(DGVProducts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.Highlight
        Label1.Location = New Point(2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(1190, 61)
        Label1.TabIndex = 1
        Label1.Text = "Danh Mục Sản Phẩm"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(btnNew)
        Panel1.Controls.Add(btnClear)
        Panel1.Controls.Add(btnSearch)
        Panel1.Controls.Add(txtProductName)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(ComboBoxProductType)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(3, 64)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1192, 54)
        Panel1.TabIndex = 2
        ' 
        ' btnNew
        ' 
        btnNew.BackColor = Color.White
        btnNew.FlatStyle = FlatStyle.Flat
        btnNew.Location = New Point(1096, 18)
        btnNew.Name = "btnNew"
        btnNew.Size = New Size(75, 23)
        btnNew.TabIndex = 7
        btnNew.Text = "Thêm mới"
        btnNew.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.White
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Location = New Point(914, 18)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 23)
        btnClear.TabIndex = 5
        btnClear.Text = "Làm mới"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.White
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.Location = New Point(1004, 18)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 4
        btnSearch.Text = "Tìm kiếm"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' txtProductName
        ' 
        txtProductName.Location = New Point(431, 15)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(188, 23)
        txtProductName.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(337, 18)
        Label3.Name = "Label3"
        Label3.Size = New Size(89, 17)
        Label3.TabIndex = 2
        Label3.Text = "Tên sản phẩm"
        ' 
        ' ComboBoxProductType
        ' 
        ComboBoxProductType.FormattingEnabled = True
        ComboBoxProductType.Location = New Point(106, 14)
        ComboBoxProductType.Name = "ComboBoxProductType"
        ComboBoxProductType.Size = New Size(188, 23)
        ComboBoxProductType.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(12, 17)
        Label2.Name = "Label2"
        Label2.Size = New Size(93, 17)
        Label2.TabIndex = 0
        Label2.Text = "Loại sản phẩm"
        ' 
        ' DGVProducts
        ' 
        DGVProducts.AllowUserToAddRows = False
        DGVProducts.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DGVProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DGVProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVProducts.Columns.AddRange(New DataGridViewColumn() {ownerId, productTypeId, productId, productTypeName, productName, productImage, unitPrice, tax, vatId, description, edit, delete})
        DGVProducts.EnableHeadersVisualStyles = False
        DGVProducts.Location = New Point(3, 124)
        DGVProducts.Name = "DGVProducts"
        DGVProducts.ReadOnly = True
        DGVProducts.RowHeadersVisible = False
        DGVProducts.RowTemplate.Height = 25
        DGVProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVProducts.Size = New Size(1189, 484)
        DGVProducts.TabIndex = 3
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
        productTypeId.HeaderText = "productTypeId"
        productTypeId.Name = "productTypeId"
        productTypeId.ReadOnly = True
        productTypeId.Visible = False
        productTypeId.Width = 50
        ' 
        ' productId
        ' 
        productId.DataPropertyName = "productId"
        productId.HeaderText = "Id SP"
        productId.Name = "productId"
        productId.ReadOnly = True
        ' 
        ' productTypeName
        ' 
        productTypeName.DataPropertyName = "productTypeName"
        productTypeName.HeaderText = "Loại sản phẩm"
        productTypeName.Name = "productTypeName"
        productTypeName.ReadOnly = True
        productTypeName.Width = 180
        ' 
        ' productName
        ' 
        productName.DataPropertyName = "productName"
        productName.HeaderText = "Tên sản phẩm"
        productName.Name = "productName"
        productName.ReadOnly = True
        productName.Width = 200
        ' 
        ' productImage
        ' 
        productImage.DataPropertyName = "productImage"
        productImage.HeaderText = "Hình ảnh"
        productImage.Name = "productImage"
        productImage.ReadOnly = True
        productImage.Width = 150
        ' 
        ' unitPrice
        ' 
        unitPrice.DataPropertyName = "unitPrice"
        unitPrice.HeaderText = "Đơn giá"
        unitPrice.Name = "unitPrice"
        unitPrice.ReadOnly = True
        unitPrice.Width = 130
        ' 
        ' tax
        ' 
        tax.DataPropertyName = "tax"
        tax.HeaderText = "Thuế"
        tax.Name = "tax"
        tax.ReadOnly = True
        tax.Width = 130
        ' 
        ' vatId
        ' 
        vatId.DataPropertyName = "vatId"
        vatId.HeaderText = "VAT ID"
        vatId.Name = "vatId"
        vatId.ReadOnly = True
        vatId.Visible = False
        ' 
        ' description
        ' 
        description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        description.DataPropertyName = "description"
        description.HeaderText = "Mô tả"
        description.Name = "description"
        description.ReadOnly = True
        ' 
        ' edit
        ' 
        edit.HeaderText = ""
        edit.Name = "edit"
        edit.ReadOnly = True
        edit.Resizable = DataGridViewTriState.True
        edit.SortMode = DataGridViewColumnSortMode.Automatic
        edit.Text = "Edit"
        edit.UseColumnTextForButtonValue = True
        edit.Width = 50
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
        ' UCProduct
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(DGVProducts)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        ForeColor = SystemColors.ControlText
        Name = "UCProduct"
        Size = New Size(1195, 611)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(DGVProducts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxProductType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DGVProducts As DataGridView
    Friend WithEvents btnNew As Button
    Friend WithEvents ownerId As DataGridViewTextBoxColumn
    Friend WithEvents productTypeId As DataGridViewTextBoxColumn
    Friend WithEvents productId As DataGridViewTextBoxColumn
    Friend WithEvents productTypeName As DataGridViewTextBoxColumn
    Friend WithEvents productName As DataGridViewTextBoxColumn
    Friend WithEvents productImage As DataGridViewTextBoxColumn
    Friend WithEvents unitPrice As DataGridViewTextBoxColumn
    Friend WithEvents tax As DataGridViewTextBoxColumn
    Friend WithEvents vatId As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents edit As DataGridViewButtonColumn
    Friend WithEvents delete As DataGridViewButtonColumn
End Class
