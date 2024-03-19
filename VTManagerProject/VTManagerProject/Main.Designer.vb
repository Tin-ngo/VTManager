<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Main))
        Panel1 = New Panel()
        btnStatistic = New Button()
        btnManageTableArea = New Button()
        btnHome = New Button()
        btnWorkingTimeMaster = New Button()
        btnWorkingTime = New Button()
        btnEmployeeClass = New Button()
        btnEmployee = New Button()
        btnProductType = New Button()
        btnManageProduct = New Button()
        Label1 = New Label()
        PanelController = New Panel()
        UcStatistic1 = New UCStatistic()
        Home1 = New Home()
        UcWorkingTimeMaster1 = New UCWorkingTimeMaster()
        UcWorkingTime1 = New UCWorkingTime()
        UcEmployeeClass1 = New UCEmployeeClass()
        UcEmployee1 = New UCEmployee()
        UcProductType1 = New UCProductType()
        UcProduct1 = New UCProduct()
        UcTableArea1 = New UCTableArea()
        Panel1.SuspendLayout()
        PanelController.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.Controls.Add(btnStatistic)
        Panel1.Controls.Add(btnManageTableArea)
        Panel1.Controls.Add(btnHome)
        Panel1.Controls.Add(btnWorkingTimeMaster)
        Panel1.Controls.Add(btnWorkingTime)
        Panel1.Controls.Add(btnEmployeeClass)
        Panel1.Controls.Add(btnEmployee)
        Panel1.Controls.Add(btnProductType)
        Panel1.Controls.Add(btnManageProduct)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(12, 1)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1190, 62)
        Panel1.TabIndex = 1
        ' 
        ' btnStatistic
        ' 
        btnStatistic.FlatAppearance.BorderSize = 0
        btnStatistic.FlatStyle = FlatStyle.Flat
        btnStatistic.Image = CType(resources.GetObject("btnStatistic.Image"), Image)
        btnStatistic.ImageAlign = ContentAlignment.TopCenter
        btnStatistic.Location = New Point(228, 10)
        btnStatistic.Name = "btnStatistic"
        btnStatistic.Size = New Size(107, 50)
        btnStatistic.TabIndex = 10
        btnStatistic.TabStop = False
        btnStatistic.Text = "Thống kê"
        btnStatistic.TextAlign = ContentAlignment.BottomCenter
        btnStatistic.UseVisualStyleBackColor = True
        ' 
        ' btnManageTableArea
        ' 
        btnManageTableArea.FlatAppearance.BorderSize = 0
        btnManageTableArea.FlatStyle = FlatStyle.Flat
        btnManageTableArea.Image = CType(resources.GetObject("btnManageTableArea.Image"), Image)
        btnManageTableArea.ImageAlign = ContentAlignment.TopCenter
        btnManageTableArea.Location = New Point(349, 10)
        btnManageTableArea.Name = "btnManageTableArea"
        btnManageTableArea.Size = New Size(107, 50)
        btnManageTableArea.TabIndex = 9
        btnManageTableArea.TabStop = False
        btnManageTableArea.Text = "Khu vực và Bàn"
        btnManageTableArea.TextAlign = ContentAlignment.BottomCenter
        btnManageTableArea.UseVisualStyleBackColor = True
        ' 
        ' btnHome
        ' 
        btnHome.BackColor = SystemColors.ActiveCaption
        btnHome.BackgroundImageLayout = ImageLayout.None
        btnHome.FlatAppearance.BorderSize = 0
        btnHome.FlatStyle = FlatStyle.Flat
        btnHome.Image = CType(resources.GetObject("btnHome.Image"), Image)
        btnHome.ImageAlign = ContentAlignment.TopCenter
        btnHome.Location = New Point(122, 10)
        btnHome.Name = "btnHome"
        btnHome.Size = New Size(107, 50)
        btnHome.TabIndex = 8
        btnHome.Text = "Trạng thái"
        btnHome.TextAlign = ContentAlignment.BottomCenter
        btnHome.UseVisualStyleBackColor = False
        ' 
        ' btnWorkingTimeMaster
        ' 
        btnWorkingTimeMaster.FlatAppearance.BorderSize = 0
        btnWorkingTimeMaster.FlatStyle = FlatStyle.Flat
        btnWorkingTimeMaster.Image = CType(resources.GetObject("btnWorkingTimeMaster.Image"), Image)
        btnWorkingTimeMaster.ImageAlign = ContentAlignment.TopCenter
        btnWorkingTimeMaster.Location = New Point(1066, 10)
        btnWorkingTimeMaster.Name = "btnWorkingTimeMaster"
        btnWorkingTimeMaster.Size = New Size(107, 50)
        btnWorkingTimeMaster.TabIndex = 7
        btnWorkingTimeMaster.TabStop = False
        btnWorkingTimeMaster.Text = "Ca làm"
        btnWorkingTimeMaster.TextAlign = ContentAlignment.BottomCenter
        btnWorkingTimeMaster.UseVisualStyleBackColor = True
        ' 
        ' btnWorkingTime
        ' 
        btnWorkingTime.FlatAppearance.BorderSize = 0
        btnWorkingTime.FlatStyle = FlatStyle.Flat
        btnWorkingTime.Image = CType(resources.GetObject("btnWorkingTime.Image"), Image)
        btnWorkingTime.ImageAlign = ContentAlignment.TopCenter
        btnWorkingTime.Location = New Point(959, 10)
        btnWorkingTime.Name = "btnWorkingTime"
        btnWorkingTime.Size = New Size(107, 50)
        btnWorkingTime.TabIndex = 6
        btnWorkingTime.TabStop = False
        btnWorkingTime.Text = "Thời gian làm"
        btnWorkingTime.TextAlign = ContentAlignment.BottomCenter
        btnWorkingTime.UseVisualStyleBackColor = True
        ' 
        ' btnEmployeeClass
        ' 
        btnEmployeeClass.FlatAppearance.BorderSize = 0
        btnEmployeeClass.FlatStyle = FlatStyle.Flat
        btnEmployeeClass.Image = CType(resources.GetObject("btnEmployeeClass.Image"), Image)
        btnEmployeeClass.ImageAlign = ContentAlignment.TopCenter
        btnEmployeeClass.Location = New Point(840, 10)
        btnEmployeeClass.Name = "btnEmployeeClass"
        btnEmployeeClass.Size = New Size(107, 50)
        btnEmployeeClass.TabIndex = 5
        btnEmployeeClass.TabStop = False
        btnEmployeeClass.Text = "Loại nhân viên"
        btnEmployeeClass.TextAlign = ContentAlignment.BottomCenter
        btnEmployeeClass.UseVisualStyleBackColor = True
        ' 
        ' btnEmployee
        ' 
        btnEmployee.FlatAppearance.BorderSize = 0
        btnEmployee.FlatStyle = FlatStyle.Flat
        btnEmployee.Image = CType(resources.GetObject("btnEmployee.Image"), Image)
        btnEmployee.ImageAlign = ContentAlignment.TopCenter
        btnEmployee.Location = New Point(719, 10)
        btnEmployee.Name = "btnEmployee"
        btnEmployee.Size = New Size(107, 50)
        btnEmployee.TabIndex = 4
        btnEmployee.TabStop = False
        btnEmployee.Text = "Nhân viên"
        btnEmployee.TextAlign = ContentAlignment.BottomCenter
        btnEmployee.UseVisualStyleBackColor = True
        ' 
        ' btnProductType
        ' 
        btnProductType.FlatAppearance.BorderSize = 0
        btnProductType.FlatStyle = FlatStyle.Flat
        btnProductType.Image = CType(resources.GetObject("btnProductType.Image"), Image)
        btnProductType.ImageAlign = ContentAlignment.TopCenter
        btnProductType.Location = New Point(597, 10)
        btnProductType.Name = "btnProductType"
        btnProductType.Size = New Size(107, 50)
        btnProductType.TabIndex = 3
        btnProductType.TabStop = False
        btnProductType.Text = "Loại sản phẩm"
        btnProductType.TextAlign = ContentAlignment.BottomCenter
        btnProductType.UseVisualStyleBackColor = True
        ' 
        ' btnManageProduct
        ' 
        btnManageProduct.FlatAppearance.BorderSize = 0
        btnManageProduct.FlatStyle = FlatStyle.Flat
        btnManageProduct.Image = CType(resources.GetObject("btnManageProduct.Image"), Image)
        btnManageProduct.ImageAlign = ContentAlignment.TopCenter
        btnManageProduct.Location = New Point(472, 10)
        btnManageProduct.Name = "btnManageProduct"
        btnManageProduct.Size = New Size(107, 50)
        btnManageProduct.TabIndex = 2
        btnManageProduct.TabStop = False
        btnManageProduct.Text = "Sản phẩm"
        btnManageProduct.TextAlign = ContentAlignment.BottomCenter
        btnManageProduct.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ImageAlign = ContentAlignment.TopCenter
        Label1.Location = New Point(16, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(100, 30)
        Label1.TabIndex = 1
        Label1.Text = "Danh Mục"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PanelController
        ' 
        PanelController.Controls.Add(UcStatistic1)
        PanelController.Controls.Add(Home1)
        PanelController.Controls.Add(UcWorkingTimeMaster1)
        PanelController.Controls.Add(UcWorkingTime1)
        PanelController.Controls.Add(UcEmployeeClass1)
        PanelController.Controls.Add(UcEmployee1)
        PanelController.Controls.Add(UcProductType1)
        PanelController.Controls.Add(UcProduct1)
        PanelController.Controls.Add(UcTableArea1)
        PanelController.Location = New Point(12, 63)
        PanelController.Name = "PanelController"
        PanelController.Size = New Size(1190, 611)
        PanelController.TabIndex = 3
        ' 
        ' UcStatistic1
        ' 
        UcStatistic1.BackColor = SystemColors.GradientActiveCaption
        UcStatistic1.Dock = DockStyle.Fill
        UcStatistic1.ForeColor = SystemColors.ControlText
        UcStatistic1.Location = New Point(0, 0)
        UcStatistic1.Name = "UcStatistic1"
        UcStatistic1.Size = New Size(1190, 611)
        UcStatistic1.TabIndex = 8
        ' 
        ' Home1
        ' 
        Home1.Dock = DockStyle.Fill
        Home1.Location = New Point(0, 0)
        Home1.Name = "Home1"
        Home1.Size = New Size(1190, 611)
        Home1.TabIndex = 7
        ' 
        ' UcWorkingTimeMaster1
        ' 
        UcWorkingTimeMaster1.Dock = DockStyle.Fill
        UcWorkingTimeMaster1.ForeColor = SystemColors.ControlText
        UcWorkingTimeMaster1.Location = New Point(0, 0)
        UcWorkingTimeMaster1.Name = "UcWorkingTimeMaster1"
        UcWorkingTimeMaster1.Size = New Size(1190, 611)
        UcWorkingTimeMaster1.TabIndex = 6
        ' 
        ' UcWorkingTime1
        ' 
        UcWorkingTime1.Dock = DockStyle.Fill
        UcWorkingTime1.ForeColor = SystemColors.ControlText
        UcWorkingTime1.Location = New Point(0, 0)
        UcWorkingTime1.Name = "UcWorkingTime1"
        UcWorkingTime1.Size = New Size(1190, 611)
        UcWorkingTime1.TabIndex = 5
        ' 
        ' UcEmployeeClass1
        ' 
        UcEmployeeClass1.Dock = DockStyle.Fill
        UcEmployeeClass1.Location = New Point(0, 0)
        UcEmployeeClass1.Name = "UcEmployeeClass1"
        UcEmployeeClass1.Size = New Size(1190, 611)
        UcEmployeeClass1.TabIndex = 4
        ' 
        ' UcEmployee1
        ' 
        UcEmployee1.Dock = DockStyle.Fill
        UcEmployee1.Location = New Point(0, 0)
        UcEmployee1.Name = "UcEmployee1"
        UcEmployee1.Size = New Size(1190, 611)
        UcEmployee1.TabIndex = 3
        UcEmployee1.Visible = False
        ' 
        ' UcProductType1
        ' 
        UcProductType1.Dock = DockStyle.Fill
        UcProductType1.ForeColor = SystemColors.ControlText
        UcProductType1.Location = New Point(0, 0)
        UcProductType1.Name = "UcProductType1"
        UcProductType1.Size = New Size(1190, 611)
        UcProductType1.TabIndex = 2
        UcProductType1.Visible = False
        ' 
        ' UcProduct1
        ' 
        UcProduct1.Dock = DockStyle.Fill
        UcProduct1.ForeColor = SystemColors.ControlText
        UcProduct1.Location = New Point(0, 0)
        UcProduct1.Name = "UcProduct1"
        UcProduct1.Size = New Size(1190, 611)
        UcProduct1.TabIndex = 1
        UcProduct1.Visible = False
        ' 
        ' UcTableArea1
        ' 
        UcTableArea1.Dock = DockStyle.Fill
        UcTableArea1.ForeColor = SystemColors.ControlText
        UcTableArea1.Location = New Point(0, 0)
        UcTableArea1.Name = "UcTableArea1"
        UcTableArea1.Size = New Size(1190, 611)
        UcTableArea1.TabIndex = 0
        UcTableArea1.Visible = False
        ' 
        ' Main
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(1213, 681)
        Controls.Add(PanelController)
        Controls.Add(Panel1)
        Name = "Main"
        Text = "VTManager - Restaurant management"
        Panel1.ResumeLayout(False)
        PanelController.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents UserControl21 As UCProduct
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnEmployee As Button
    Friend WithEvents btnProductType As Button
    Friend WithEvents btnManageProduct As Button
    Friend WithEvents PanelController As Panel
    Friend WithEvents UcTableArea As UCTableArea
    Friend WithEvents UcTableArea1 As UCTableArea
    Friend WithEvents UcProduct1 As UCProduct
    Friend WithEvents UcProductType1 As UCProductType
    Friend WithEvents UcEmployee1 As UCEmployee
    Friend WithEvents btnEmployeeClass As Button
    Friend WithEvents UcEmployeeClass1 As UCEmployeeClass
    Friend WithEvents UcWorkingTime1 As UCWorkingTime
    Friend WithEvents btnWorkingTime As Button
    Friend WithEvents UcWorkingTimeMaster1 As UCWorkingTimeMaster
    Friend WithEvents btnWorkingTimeMaster As Button
    Friend WithEvents Home1 As Home
    Friend WithEvents btnHome As Button
    Friend WithEvents btnManageTableArea As Button
    Friend WithEvents btnStatistic As Button
    Friend WithEvents UcStatistic1 As UCStatistic
End Class
