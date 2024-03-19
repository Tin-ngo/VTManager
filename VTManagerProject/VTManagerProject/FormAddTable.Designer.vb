<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddTable
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
        ComboBoxAddTable_AreaId = New ComboBox()
        txtAddTable_TableId = New TextBox()
        btnCancel = New Button()
        btnAdd = New Button()
        Label3 = New Label()
        Label4 = New Label()
        txtMax = New TextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 32)
        Label1.Name = "Label1"
        Label1.Size = New Size(50, 15)
        Label1.TabIndex = 0
        Label1.Text = "Khu vực"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 71)
        Label2.Name = "Label2"
        Label2.Size = New Size(43, 15)
        Label2.TabIndex = 1
        Label2.Text = "Số bàn"
        ' 
        ' ComboBoxAddTable_AreaId
        ' 
        ComboBoxAddTable_AreaId.FormattingEnabled = True
        ComboBoxAddTable_AreaId.Location = New Point(73, 29)
        ComboBoxAddTable_AreaId.Name = "ComboBoxAddTable_AreaId"
        ComboBoxAddTable_AreaId.Size = New Size(227, 23)
        ComboBoxAddTable_AreaId.TabIndex = 2
        ' 
        ' txtAddTable_TableId
        ' 
        txtAddTable_TableId.Location = New Point(73, 72)
        txtAddTable_TableId.Name = "txtAddTable_TableId"
        txtAddTable_TableId.ReadOnly = True
        txtAddTable_TableId.Size = New Size(227, 23)
        txtAddTable_TableId.TabIndex = 3
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(73, 159)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 4
        btnCancel.Text = "Hủy"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(183, 160)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 5
        btnAdd.Text = "Thêm"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(7, 87)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 15)
        Label3.TabIndex = 6
        Label3.Text = "(tự động)"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 124)
        Label4.Name = "Label4"
        Label4.Size = New Size(39, 15)
        Label4.TabIndex = 7
        Label4.Text = "Tối đa"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' txtMax
        ' 
        txtMax.Location = New Point(73, 118)
        txtMax.Name = "txtMax"
        txtMax.Size = New Size(227, 23)
        txtMax.TabIndex = 8
        ' 
        ' FormAddTable
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(315, 197)
        Controls.Add(txtMax)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(btnAdd)
        Controls.Add(btnCancel)
        Controls.Add(txtAddTable_TableId)
        Controls.Add(ComboBoxAddTable_AreaId)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "FormAddTable"
        Text = "VTManager - Thêm bàn"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBoxAddTable_AreaId As ComboBox
    Friend WithEvents txtAddTable_TableId As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMax As TextBox
End Class
