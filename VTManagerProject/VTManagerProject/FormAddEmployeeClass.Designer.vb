<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddEmployeeClass
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
        txtEmployeeClassId = New TextBox()
        Label2 = New Label()
        txtEmployeeClassName = New TextBox()
        Label4 = New Label()
        Label1 = New Label()
        btnCancel = New Button()
        btnAdd = New Button()
        SuspendLayout()
        ' 
        ' txtEmployeeClassId
        ' 
        txtEmployeeClassId.Location = New Point(54, 62)
        txtEmployeeClassId.Name = "txtEmployeeClassId"
        txtEmployeeClassId.ReadOnly = True
        txtEmployeeClassId.Size = New Size(227, 23)
        txtEmployeeClassId.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(15, 65)
        Label2.Name = "Label2"
        Label2.Size = New Size(18, 15)
        Label2.TabIndex = 5
        Label2.Text = "ID"
        ' 
        ' txtEmployeeClassName
        ' 
        txtEmployeeClassName.Location = New Point(54, 103)
        txtEmployeeClassName.Name = "txtEmployeeClassName"
        txtEmployeeClassName.Size = New Size(227, 23)
        txtEmployeeClassName.TabIndex = 10
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(13, 106)
        Label4.Name = "Label4"
        Label4.Size = New Size(25, 15)
        Label4.TabIndex = 9
        Label4.Text = "Tên"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(0, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(296, 39)
        Label1.TabIndex = 11
        Label1.Text = "Thêm loại nhân viên"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(54, 153)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 12
        btnCancel.Text = "Hủy"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(164, 153)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 13
        btnAdd.Text = "Thêm"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' FormAddEmployeeClass
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(297, 197)
        Controls.Add(btnAdd)
        Controls.Add(btnCancel)
        Controls.Add(Label1)
        Controls.Add(txtEmployeeClassName)
        Controls.Add(Label4)
        Controls.Add(txtEmployeeClassId)
        Controls.Add(Label2)
        Name = "FormAddEmployeeClass"
        Text = "FormAddEmployeeClass"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtEmployeeClassId As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmployeeClassName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAdd As Button
End Class
