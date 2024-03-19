<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddSalary
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
        txtSalaryId = New TextBox()
        txtSalary = New TextBox()
        txtDescSalary = New TextBox()
        Label4 = New Label()
        btnCancel = New Button()
        btnAdd = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(23, 59)
        Label1.Name = "Label1"
        Label1.Size = New Size(50, 15)
        Label1.TabIndex = 0
        Label1.Text = "slalaryId"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(24, 93)
        Label2.Name = "Label2"
        Label2.Size = New Size(43, 15)
        Label2.TabIndex = 1
        Label2.Text = "Số tiền"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(24, 127)
        Label3.Name = "Label3"
        Label3.Size = New Size(38, 15)
        Label3.TabIndex = 2
        Label3.Text = "Mô tả"
        ' 
        ' txtSalaryId
        ' 
        txtSalaryId.Location = New Point(96, 56)
        txtSalaryId.Name = "txtSalaryId"
        txtSalaryId.ReadOnly = True
        txtSalaryId.Size = New Size(163, 23)
        txtSalaryId.TabIndex = 3
        ' 
        ' txtSalary
        ' 
        txtSalary.Location = New Point(96, 90)
        txtSalary.Name = "txtSalary"
        txtSalary.Size = New Size(163, 23)
        txtSalary.TabIndex = 4
        ' 
        ' txtDescSalary
        ' 
        txtDescSalary.Location = New Point(96, 124)
        txtDescSalary.Multiline = True
        txtDescSalary.Name = "txtDescSalary"
        txtDescSalary.Size = New Size(163, 57)
        txtDescSalary.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(23, 9)
        Label4.Name = "Label4"
        Label4.Size = New Size(236, 27)
        Label4.TabIndex = 6
        Label4.Text = "Thêm tiền lương mới"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(38, 194)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Hủy"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(156, 194)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 8
        btnAdd.Text = "Thêm"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' FormAddSalary
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(291, 229)
        Controls.Add(btnAdd)
        Controls.Add(btnCancel)
        Controls.Add(Label4)
        Controls.Add(txtDescSalary)
        Controls.Add(txtSalary)
        Controls.Add(txtSalaryId)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "FormAddSalary"
        Text = "FormAddSalary"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSalaryId As TextBox
    Friend WithEvents txtSalary As TextBox
    Friend WithEvents txtDescSalary As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAdd As Button
End Class
