<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Login))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        txtUserID = New TextBox()
        txtPassword = New TextBox()
        btnCancel = New Button()
        btnLogin = New Button()
        Label4 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(569, 66)
        Label1.Name = "Label1"
        Label1.Size = New Size(104, 45)
        Label1.TabIndex = 0
        Label1.Text = "Login"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(483, 148)
        Label2.Name = "Label2"
        Label2.Size = New Size(61, 21)
        Label2.TabIndex = 1
        Label2.Text = "User ID"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(483, 197)
        Label3.Name = "Label3"
        Label3.Size = New Size(76, 21)
        Label3.TabIndex = 2
        Label3.Text = "Password"
        ' 
        ' txtUserID
        ' 
        txtUserID.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtUserID.Location = New Point(569, 145)
        txtUserID.Name = "txtUserID"
        txtUserID.Size = New Size(233, 29)
        txtUserID.TabIndex = 3
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtPassword.Location = New Point(569, 194)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(233, 29)
        txtPassword.TabIndex = 4
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.LightGray
        btnCancel.Location = New Point(700, 258)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(102, 36)
        btnCancel.TabIndex = 5
        btnCancel.Text = "Clear"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.LightGray
        btnLogin.FlatAppearance.BorderColor = Color.White
        btnLogin.Location = New Point(569, 258)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(102, 36)
        btnLogin.TabIndex = 6
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.Image = CType(resources.GetObject("Label4.Image"), Image)
        Label4.Location = New Point(12, 11)
        Label4.Name = "Label4"
        Label4.Size = New Size(469, 401)
        Label4.TabIndex = 7
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(837, 421)
        Controls.Add(Label4)
        Controls.Add(btnLogin)
        Controls.Add(btnCancel)
        Controls.Add(txtPassword)
        Controls.Add(txtUserID)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Login"
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnLogin As Button
    Friend WithEvents Label4 As Label
End Class
