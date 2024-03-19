<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCStatistic
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(UCStatistic))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        Button1 = New Button()
        RadioButtonDown = New RadioButton()
        RadioButtonUp = New RadioButton()
        DGVStatisficProduct = New DataGridView()
        ownerId = New DataGridViewTextBoxColumn()
        productId = New DataGridViewTextBoxColumn()
        productName = New DataGridViewTextBoxColumn()
        unitPrice = New DataGridViewTextBoxColumn()
        quantitySold = New DataGridViewTextBoxColumn()
        total = New DataGridViewTextBoxColumn()
        ButtonSearch = New Button()
        DateTimePickerTo = New DateTimePicker()
        DateTimePickerFrom = New DateTimePicker()
        Label3 = New Label()
        Label2 = New Label()
        GroupBox2 = New GroupBox()
        ComboBoxYear_month = New ComboBox()
        Button2 = New Button()
        DateTimePicker1 = New DateTimePicker()
        FlowLayoutPanel3 = New FlowLayoutPanel()
        LblYear = New Label()
        Label12 = New Label()
        FlowLayoutPanel2 = New FlowLayoutPanel()
        LblMonth = New Label()
        Label10 = New Label()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        LblDate = New Label()
        Label8 = New Label()
        ComboBoxYear = New ComboBox()
        Label6 = New Label()
        ComboBoxMonth = New ComboBox()
        Label5 = New Label()
        Label4 = New Label()
        NpgsqlCommand1 = New Npgsql.NpgsqlCommand()
        GroupBox1.SuspendLayout()
        CType(DGVStatisficProduct, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        FlowLayoutPanel3.SuspendLayout()
        FlowLayoutPanel2.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.Highlight
        Label1.Location = New Point(2, 2)
        Label1.Name = "Label1"
        Label1.Size = New Size(1190, 61)
        Label1.TabIndex = 2
        Label1.Text = "THỐNG KÊ"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(RadioButtonDown)
        GroupBox1.Controls.Add(RadioButtonUp)
        GroupBox1.Controls.Add(DGVStatisficProduct)
        GroupBox1.Controls.Add(ButtonSearch)
        GroupBox1.Controls.Add(DateTimePickerTo)
        GroupBox1.Controls.Add(DateTimePickerFrom)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox1.Location = New Point(3, 71)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(654, 537)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Sản phẩm"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Button1.Location = New Point(583, 46)
        Button1.Name = "Button1"
        Button1.Size = New Size(65, 30)
        Button1.TabIndex = 14
        Button1.Text = "Tất cả"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' RadioButtonDown
        ' 
        RadioButtonDown.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        RadioButtonDown.Image = CType(resources.GetObject("RadioButtonDown.Image"), Image)
        RadioButtonDown.Location = New Point(397, 44)
        RadioButtonDown.Name = "RadioButtonDown"
        RadioButtonDown.Size = New Size(40, 30)
        RadioButtonDown.TabIndex = 13
        RadioButtonDown.TabStop = True
        RadioButtonDown.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonUp
        ' 
        RadioButtonUp.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        RadioButtonUp.Image = CType(resources.GetObject("RadioButtonUp.Image"), Image)
        RadioButtonUp.Location = New Point(447, 44)
        RadioButtonUp.Name = "RadioButtonUp"
        RadioButtonUp.Size = New Size(40, 32)
        RadioButtonUp.TabIndex = 12
        RadioButtonUp.TabStop = True
        RadioButtonUp.UseVisualStyleBackColor = True
        ' 
        ' DGVStatisficProduct
        ' 
        DGVStatisficProduct.AllowUserToAddRows = False
        DGVStatisficProduct.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DGVStatisficProduct.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DGVStatisficProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGVStatisficProduct.Columns.AddRange(New DataGridViewColumn() {ownerId, productId, productName, unitPrice, quantitySold, total})
        DGVStatisficProduct.EnableHeadersVisualStyles = False
        DGVStatisficProduct.Location = New Point(6, 80)
        DGVStatisficProduct.Name = "DGVStatisficProduct"
        DGVStatisficProduct.ReadOnly = True
        DGVStatisficProduct.RowHeadersVisible = False
        DGVStatisficProduct.RowTemplate.Height = 25
        DGVStatisficProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVStatisficProduct.Size = New Size(642, 451)
        DGVStatisficProduct.TabIndex = 11
        ' 
        ' ownerId
        ' 
        ownerId.DataPropertyName = "ownerId"
        ownerId.HeaderText = "ownerId"
        ownerId.Name = "ownerId"
        ownerId.ReadOnly = True
        ownerId.Visible = False
        ' 
        ' productId
        ' 
        productId.DataPropertyName = "productId"
        DataGridViewCellStyle2.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        productId.DefaultCellStyle = DataGridViewCellStyle2
        productId.HeaderText = "productId"
        productId.Name = "productId"
        productId.ReadOnly = True
        productId.Visible = False
        ' 
        ' productName
        ' 
        productName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        productName.DataPropertyName = "productName"
        DataGridViewCellStyle3.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        productName.DefaultCellStyle = DataGridViewCellStyle3
        productName.HeaderText = "Tên sản phẩm"
        productName.Name = "productName"
        productName.ReadOnly = True
        ' 
        ' unitPrice
        ' 
        unitPrice.DataPropertyName = "unitPrice"
        DataGridViewCellStyle4.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        unitPrice.DefaultCellStyle = DataGridViewCellStyle4
        unitPrice.HeaderText = "Đơn giá"
        unitPrice.Name = "unitPrice"
        unitPrice.ReadOnly = True
        unitPrice.Width = 150
        ' 
        ' quantitySold
        ' 
        quantitySold.DataPropertyName = "quantitySold"
        DataGridViewCellStyle5.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        quantitySold.DefaultCellStyle = DataGridViewCellStyle5
        quantitySold.HeaderText = "SL Bán"
        quantitySold.Name = "quantitySold"
        quantitySold.ReadOnly = True
        ' 
        ' total
        ' 
        total.DataPropertyName = "total"
        DataGridViewCellStyle6.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        total.DefaultCellStyle = DataGridViewCellStyle6
        total.HeaderText = "Tổng tiền"
        total.Name = "total"
        total.ReadOnly = True
        total.Width = 150
        ' 
        ' ButtonSearch
        ' 
        ButtonSearch.BackColor = Color.White
        ButtonSearch.FlatStyle = FlatStyle.Flat
        ButtonSearch.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonSearch.Location = New Point(501, 46)
        ButtonSearch.Name = "ButtonSearch"
        ButtonSearch.Size = New Size(74, 30)
        ButtonSearch.TabIndex = 10
        ButtonSearch.Text = "Tìm kiếm"
        ButtonSearch.UseVisualStyleBackColor = False
        ' 
        ' DateTimePickerTo
        ' 
        DateTimePickerTo.CustomFormat = "dd-MM-yyyy"
        DateTimePickerTo.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        DateTimePickerTo.Format = DateTimePickerFormat.Custom
        DateTimePickerTo.Location = New Point(250, 46)
        DateTimePickerTo.Name = "DateTimePickerTo"
        DateTimePickerTo.Size = New Size(107, 25)
        DateTimePickerTo.TabIndex = 8
        ' 
        ' DateTimePickerFrom
        ' 
        DateTimePickerFrom.CustomFormat = "dd-MM-yyyy"
        DateTimePickerFrom.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        DateTimePickerFrom.Format = DateTimePickerFormat.Custom
        DateTimePickerFrom.Location = New Point(95, 46)
        DateTimePickerFrom.Name = "DateTimePickerFrom"
        DateTimePickerFrom.Size = New Size(108, 25)
        DateTimePickerFrom.TabIndex = 7
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(214, 50)
        Label3.Name = "Label3"
        Label3.Size = New Size(32, 19)
        Label3.TabIndex = 6
        Label3.Text = "đến"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(8, 50)
        Label2.Name = "Label2"
        Label2.Size = New Size(83, 19)
        Label2.TabIndex = 5
        Label2.Text = "Thống kê từ"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(ComboBoxYear_month)
        GroupBox2.Controls.Add(Button2)
        GroupBox2.Controls.Add(DateTimePicker1)
        GroupBox2.Controls.Add(FlowLayoutPanel3)
        GroupBox2.Controls.Add(FlowLayoutPanel2)
        GroupBox2.Controls.Add(FlowLayoutPanel1)
        GroupBox2.Controls.Add(ComboBoxYear)
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(ComboBoxMonth)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox2.Location = New Point(663, 71)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(525, 537)
        GroupBox2.TabIndex = 4
        GroupBox2.TabStop = False
        GroupBox2.Text = "Doanh thu"
        ' 
        ' ComboBoxYear_month
        ' 
        ComboBoxYear_month.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxYear_month.FormattingEnabled = True
        ComboBoxYear_month.Location = New Point(169, 230)
        ComboBoxYear_month.Name = "ComboBoxYear_month"
        ComboBoxYear_month.Size = New Size(78, 29)
        ComboBoxYear_month.TabIndex = 13
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.White
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Button2.Location = New Point(223, 436)
        Button2.Name = "Button2"
        Button2.Size = New Size(74, 30)
        Button2.TabIndex = 12
        Button2.Text = "Làm mới"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CustomFormat = "dd-MM-yyyy"
        DateTimePicker1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.Location = New Point(102, 124)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(145, 29)
        DateTimePicker1.TabIndex = 11
        ' 
        ' FlowLayoutPanel3
        ' 
        FlowLayoutPanel3.Controls.Add(LblYear)
        FlowLayoutPanel3.Controls.Add(Label12)
        FlowLayoutPanel3.FlowDirection = FlowDirection.BottomUp
        FlowLayoutPanel3.Location = New Point(266, 319)
        FlowLayoutPanel3.Margin = New Padding(3, 3, 3, 10)
        FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        FlowLayoutPanel3.Size = New Size(263, 51)
        FlowLayoutPanel3.TabIndex = 10
        ' 
        ' LblYear
        ' 
        LblYear.AutoSize = True
        LblYear.Font = New Font("Yu Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblYear.ForeColor = Color.LightSalmon
        LblYear.Location = New Point(3, 13)
        LblYear.Name = "LblYear"
        LblYear.Size = New Size(186, 38)
        LblYear.TabIndex = 6
        LblYear.Text = "100.000.111"
        LblYear.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label12
        ' 
        Label12.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label12.Location = New Point(195, 17)
        Label12.Name = "Label12"
        Label12.RightToLeft = RightToLeft.No
        Label12.Size = New Size(43, 34)
        Label12.TabIndex = 7
        Label12.Text = "VND"
        Label12.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' FlowLayoutPanel2
        ' 
        FlowLayoutPanel2.Controls.Add(LblMonth)
        FlowLayoutPanel2.Controls.Add(Label10)
        FlowLayoutPanel2.FlowDirection = FlowDirection.BottomUp
        FlowLayoutPanel2.Location = New Point(266, 210)
        FlowLayoutPanel2.Margin = New Padding(3, 3, 3, 10)
        FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        FlowLayoutPanel2.Size = New Size(263, 51)
        FlowLayoutPanel2.TabIndex = 9
        ' 
        ' LblMonth
        ' 
        LblMonth.AutoSize = True
        LblMonth.Font = New Font("Yu Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblMonth.ForeColor = Color.LightSalmon
        LblMonth.Location = New Point(3, 13)
        LblMonth.Name = "LblMonth"
        LblMonth.Size = New Size(186, 38)
        LblMonth.TabIndex = 6
        LblMonth.Text = "100.000.111"
        LblMonth.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label10
        ' 
        Label10.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label10.Location = New Point(195, 17)
        Label10.Name = "Label10"
        Label10.RightToLeft = RightToLeft.No
        Label10.Size = New Size(43, 34)
        Label10.TabIndex = 7
        Label10.Text = "VND"
        Label10.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Controls.Add(LblDate)
        FlowLayoutPanel1.Controls.Add(Label8)
        FlowLayoutPanel1.FlowDirection = FlowDirection.BottomUp
        FlowLayoutPanel1.Location = New Point(266, 102)
        FlowLayoutPanel1.Margin = New Padding(3, 3, 3, 10)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(263, 51)
        FlowLayoutPanel1.TabIndex = 8
        ' 
        ' LblDate
        ' 
        LblDate.AutoSize = True
        LblDate.Font = New Font("Yu Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblDate.ForeColor = Color.LightSalmon
        LblDate.Location = New Point(3, 13)
        LblDate.Name = "LblDate"
        LblDate.Size = New Size(186, 38)
        LblDate.TabIndex = 6
        LblDate.Text = "100.000.111"
        LblDate.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label8
        ' 
        Label8.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label8.Location = New Point(195, 17)
        Label8.Name = "Label8"
        Label8.RightToLeft = RightToLeft.No
        Label8.Size = New Size(43, 34)
        Label8.TabIndex = 7
        Label8.Text = "VND"
        Label8.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ComboBoxYear
        ' 
        ComboBoxYear.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxYear.FormattingEnabled = True
        ComboBoxYear.Location = New Point(102, 339)
        ComboBoxYear.Name = "ComboBoxYear"
        ComboBoxYear.Size = New Size(145, 29)
        ComboBoxYear.TabIndex = 5
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(39, 337)
        Label6.Name = "Label6"
        Label6.Size = New Size(60, 30)
        Label6.TabIndex = 4
        Label6.Text = "Năm"
        ' 
        ' ComboBoxMonth
        ' 
        ComboBoxMonth.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ComboBoxMonth.FormattingEnabled = True
        ComboBoxMonth.Location = New Point(102, 230)
        ComboBoxMonth.Name = "ComboBoxMonth"
        ComboBoxMonth.Size = New Size(61, 29)
        ComboBoxMonth.TabIndex = 3
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(24, 228)
        Label5.Name = "Label5"
        Label5.Size = New Size(75, 30)
        Label5.TabIndex = 2
        Label5.Text = "Tháng"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(34, 123)
        Label4.Name = "Label4"
        Label4.Size = New Size(65, 30)
        Label4.TabIndex = 0
        Label4.Text = "Ngày"
        ' 
        ' NpgsqlCommand1
        ' 
        NpgsqlCommand1.AllResultTypesAreUnknown = False
        NpgsqlCommand1.Transaction = Nothing
        NpgsqlCommand1.UnknownResultTypeList = Nothing
        ' 
        ' UCStatistic
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(Label1)
        ForeColor = SystemColors.ControlText
        Name = "UCStatistic"
        Size = New Size(1195, 611)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DGVStatisficProduct, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        FlowLayoutPanel3.ResumeLayout(False)
        FlowLayoutPanel3.PerformLayout()
        FlowLayoutPanel2.ResumeLayout(False)
        FlowLayoutPanel2.PerformLayout()
        FlowLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePickerFrom As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePickerTo As DateTimePicker
    Friend WithEvents DGVStatisficProduct As DataGridView
    Friend WithEvents RadioButtonDown As RadioButton
    Friend WithEvents RadioButtonUp As RadioButton
    Friend WithEvents ButtonSearch As Button
    Friend WithEvents ownerId As DataGridViewTextBoxColumn
    Friend WithEvents productId As DataGridViewTextBoxColumn
    Friend WithEvents productName As DataGridViewTextBoxColumn
    Friend WithEvents unitPrice As DataGridViewTextBoxColumn
    Friend WithEvents quantitySold As DataGridViewTextBoxColumn
    Friend WithEvents total As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents NpgsqlCommand1 As Npgsql.NpgsqlCommand
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBoxYear As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBoxMonth As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LblDate As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label8 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents LblYear As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents LblMonth As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboBoxYear_month As ComboBox
End Class
