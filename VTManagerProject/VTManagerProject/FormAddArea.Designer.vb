<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddArea
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
        txtAddArea = New TextBox()
        btnCancelAddArea = New Button()
        btnAddArea = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 34)
        Label1.Name = "Label1"
        Label1.Size = New Size(70, 15)
        Label1.TabIndex = 0
        Label1.Text = "Tên khu vực"
        ' 
        ' txtAddArea
        ' 
        txtAddArea.Location = New Point(88, 31)
        txtAddArea.Name = "txtAddArea"
        txtAddArea.Size = New Size(223, 23)
        txtAddArea.TabIndex = 1
        ' 
        ' btnCancelAddArea
        ' 
        btnCancelAddArea.Location = New Point(53, 73)
        btnCancelAddArea.Name = "btnCancelAddArea"
        btnCancelAddArea.Size = New Size(75, 23)
        btnCancelAddArea.TabIndex = 2
        btnCancelAddArea.Text = "Hủy"
        btnCancelAddArea.UseVisualStyleBackColor = True
        ' 
        ' btnAddArea
        ' 
        btnAddArea.Location = New Point(186, 73)
        btnAddArea.Name = "btnAddArea"
        btnAddArea.Size = New Size(75, 23)
        btnAddArea.TabIndex = 3
        btnAddArea.Text = "Đăng ký"
        btnAddArea.UseVisualStyleBackColor = True
        ' 
        ' FormAddArea
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(327, 113)
        Controls.Add(btnAddArea)
        Controls.Add(btnCancelAddArea)
        Controls.Add(txtAddArea)
        Controls.Add(Label1)
        Name = "FormAddArea"
        Text = "Thêm khu vực"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtAddArea As TextBox
    Friend WithEvents btnCancelAddArea As Button
    Friend WithEvents btnAddArea As Button
End Class
