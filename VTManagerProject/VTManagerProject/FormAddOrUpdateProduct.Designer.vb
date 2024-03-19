<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddOrUpdateProduct
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
        Label1 = New Label()
        Label2 = New Label()
        txtProductId = New TextBox()
        txtDesc = New TextBox()
        txtUnitPrice = New TextBox()
        txtProductName = New TextBox()
        Label3 = New Label()
        ComboBoxProductType = New ComboBox()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        NpgsqlCommand1 = New Npgsql.NpgsqlCommand()
        PictureBox1 = New PictureBox()
        btnCancel = New Button()
        btnConfirm = New Button()
        btnOpenImg = New Button()
        OpenFileDialog1 = New OpenFileDialog()
        txtImg = New TextBox()
        Label8 = New Label()
        ComboBoxTax = New ComboBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(411, 41)
        Label1.TabIndex = 0
        Label1.Text = "Thêm sản phẩm"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(23, 74)
        Label2.Name = "Label2"
        Label2.Size = New Size(63, 15)
        Label2.TabIndex = 1
        Label2.Text = "ID product"
        ' 
        ' txtProductId
        ' 
        txtProductId.Location = New Point(126, 74)
        txtProductId.Name = "txtProductId"
        txtProductId.ReadOnly = True
        txtProductId.Size = New Size(237, 23)
        txtProductId.TabIndex = 2
        ' 
        ' txtDesc
        ' 
        txtDesc.Location = New Point(126, 329)
        txtDesc.Multiline = True
        txtDesc.Name = "txtDesc"
        txtDesc.Size = New Size(237, 75)
        txtDesc.TabIndex = 3
        ' 
        ' txtUnitPrice
        ' 
        txtUnitPrice.Location = New Point(126, 283)
        txtUnitPrice.Name = "txtUnitPrice"
        txtUnitPrice.Size = New Size(237, 23)
        txtUnitPrice.TabIndex = 5
        ' 
        ' txtProductName
        ' 
        txtProductName.Location = New Point(126, 163)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(237, 23)
        txtProductName.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(23, 120)
        Label3.Name = "Label3"
        Label3.Size = New Size(84, 15)
        Label3.TabIndex = 7
        Label3.Text = "Loại sản phẩm"
        ' 
        ' ComboBoxProductType
        ' 
        ComboBoxProductType.FormattingEnabled = True
        ComboBoxProductType.Location = New Point(126, 117)
        ComboBoxProductType.Name = "ComboBoxProductType"
        ComboBoxProductType.Size = New Size(237, 23)
        ComboBoxProductType.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(23, 166)
        Label4.Name = "Label4"
        Label4.Size = New Size(80, 15)
        Label4.TabIndex = 9
        Label4.Text = "Tên sản phẩm"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(23, 226)
        Label5.Name = "Label5"
        Label5.Size = New Size(56, 15)
        Label5.TabIndex = 10
        Label5.Text = "Hỉnh ảnh"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(23, 286)
        Label6.Name = "Label6"
        Label6.Size = New Size(48, 15)
        Label6.TabIndex = 11
        Label6.Text = "Đơn giá"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(23, 329)
        Label7.Name = "Label7"
        Label7.Size = New Size(38, 15)
        Label7.TabIndex = 12
        Label7.Text = "Mô tả"
        ' 
        ' NpgsqlCommand1
        ' 
        NpgsqlCommand1.AllResultTypesAreUnknown = False
        NpgsqlCommand1.Transaction = Nothing
        NpgsqlCommand1.UnknownResultTypeList = Nothing
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(126, 222)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(87, 55)
        PictureBox1.TabIndex = 14
        PictureBox1.TabStop = False
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(48, 470)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 15
        btnCancel.Text = "Hủy"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnConfirm
        ' 
        btnConfirm.Location = New Point(257, 471)
        btnConfirm.Name = "btnConfirm"
        btnConfirm.Size = New Size(75, 23)
        btnConfirm.TabIndex = 16
        btnConfirm.Text = "Xác nhận"
        btnConfirm.UseVisualStyleBackColor = True
        ' 
        ' btnOpenImg
        ' 
        btnOpenImg.Location = New Point(126, 193)
        btnOpenImg.Name = "btnOpenImg"
        btnOpenImg.Size = New Size(75, 23)
        btnOpenImg.TabIndex = 17
        btnOpenImg.Text = "Chọn ảnh"
        btnOpenImg.UseVisualStyleBackColor = True
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' txtImg
        ' 
        txtImg.Location = New Point(207, 193)
        txtImg.Name = "txtImg"
        txtImg.Size = New Size(156, 23)
        txtImg.TabIndex = 18
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(23, 426)
        Label8.Name = "Label8"
        Label8.Size = New Size(55, 15)
        Label8.TabIndex = 19
        Label8.Text = "Thuế VAT"
        ' 
        ' ComboBoxTax
        ' 
        ComboBoxTax.FormattingEnabled = True
        ComboBoxTax.Location = New Point(126, 422)
        ComboBoxTax.Name = "ComboBoxTax"
        ComboBoxTax.Size = New Size(237, 23)
        ComboBoxTax.TabIndex = 21
        ' 
        ' FormAddOrUpdateProduct
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(412, 504)
        Controls.Add(ComboBoxTax)
        Controls.Add(Label8)
        Controls.Add(txtImg)
        Controls.Add(btnOpenImg)
        Controls.Add(btnConfirm)
        Controls.Add(btnCancel)
        Controls.Add(PictureBox1)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(ComboBoxProductType)
        Controls.Add(Label3)
        Controls.Add(txtProductName)
        Controls.Add(txtUnitPrice)
        Controls.Add(txtDesc)
        Controls.Add(txtProductId)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "FormAddOrUpdateProduct"
        Text = "Quản lý sản phẩm"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtProductId As TextBox
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents txtUnitPrice As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxProductType As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents NpgsqlCommand1 As Npgsql.NpgsqlCommand
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnOpenImg As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txtImg As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBoxTax As ComboBox
End Class
