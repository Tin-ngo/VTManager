<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddOrUpdateEmployee
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
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        txtEmployeeId = New TextBox()
        txtEmployeeName = New TextBox()
        ComboBoxEmployeeClass = New ComboBox()
        DateTimePickerBirthday = New DateTimePicker()
        DateTimePickerStart = New DateTimePicker()
        btnCancel = New Button()
        btnAdd = New Button()
        Label7 = New Label()
        txtPass = New TextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(1, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(411, 41)
        Label1.TabIndex = 1
        Label1.Text = "Thêm nhân viên"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(19, 63)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 15)
        Label2.TabIndex = 2
        Label2.Text = "id Nhân viên"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(37, 104)
        Label3.Name = "Label3"
        Label3.Size = New Size(56, 15)
        Label3.TabIndex = 3
        Label3.Text = "Phân loại"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(13, 144)
        Label4.Name = "Label4"
        Label4.Size = New Size(80, 15)
        Label4.TabIndex = 4
        Label4.Text = "Tên nhân viên"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(33, 225)
        Label5.Name = "Label5"
        Label5.Size = New Size(60, 15)
        Label5.TabIndex = 5
        Label5.Text = "Ngày sinh"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(15, 266)
        Label6.Name = "Label6"
        Label6.Size = New Size(78, 15)
        Label6.TabIndex = 6
        Label6.Text = "Ngày bắt đầu"
        ' 
        ' txtEmployeeId
        ' 
        txtEmployeeId.Location = New Point(108, 60)
        txtEmployeeId.Name = "txtEmployeeId"
        txtEmployeeId.ReadOnly = True
        txtEmployeeId.Size = New Size(262, 23)
        txtEmployeeId.TabIndex = 8
        ' 
        ' txtEmployeeName
        ' 
        txtEmployeeName.Location = New Point(108, 141)
        txtEmployeeName.Name = "txtEmployeeName"
        txtEmployeeName.Size = New Size(262, 23)
        txtEmployeeName.TabIndex = 9
        ' 
        ' ComboBoxEmployeeClass
        ' 
        ComboBoxEmployeeClass.FormattingEnabled = True
        ComboBoxEmployeeClass.Location = New Point(108, 101)
        ComboBoxEmployeeClass.Name = "ComboBoxEmployeeClass"
        ComboBoxEmployeeClass.Size = New Size(262, 23)
        ComboBoxEmployeeClass.TabIndex = 10
        ' 
        ' DateTimePickerBirthday
        ' 
        DateTimePickerBirthday.CustomFormat = "dd-MM-yyyy"
        DateTimePickerBirthday.Format = DateTimePickerFormat.Custom
        DateTimePickerBirthday.Location = New Point(108, 219)
        DateTimePickerBirthday.Name = "DateTimePickerBirthday"
        DateTimePickerBirthday.Size = New Size(262, 23)
        DateTimePickerBirthday.TabIndex = 11
        ' 
        ' DateTimePickerStart
        ' 
        DateTimePickerStart.CustomFormat = "dd-MM-yyyy"
        DateTimePickerStart.Format = DateTimePickerFormat.Custom
        DateTimePickerStart.Location = New Point(108, 261)
        DateTimePickerStart.Name = "DateTimePickerStart"
        DateTimePickerStart.Size = New Size(262, 23)
        DateTimePickerStart.TabIndex = 12
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(108, 319)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 14
        btnCancel.Text = "Hủy"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(224, 319)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 15
        btnAdd.Text = "Xác nhận"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(32, 184)
        Label7.Name = "Label7"
        Label7.Size = New Size(57, 15)
        Label7.TabIndex = 16
        Label7.Text = "Mật khẩu"
        ' 
        ' txtPass
        ' 
        txtPass.Location = New Point(108, 180)
        txtPass.Name = "txtPass"
        txtPass.Size = New Size(262, 23)
        txtPass.TabIndex = 17
        ' 
        ' FormAddOrUpdateEmployee
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(415, 357)
        Controls.Add(txtPass)
        Controls.Add(Label7)
        Controls.Add(btnAdd)
        Controls.Add(btnCancel)
        Controls.Add(DateTimePickerStart)
        Controls.Add(DateTimePickerBirthday)
        Controls.Add(ComboBoxEmployeeClass)
        Controls.Add(txtEmployeeName)
        Controls.Add(txtEmployeeId)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "FormAddOrUpdateEmployee"
        Text = "FormAddOrUpdateEmployee"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmployeeId As TextBox
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents ComboBoxEmployeeClass As ComboBox
    Friend WithEvents DateTimePickerBirthday As DateTimePicker
    Friend WithEvents DateTimePickerStart As DateTimePicker
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPass As TextBox
End Class
