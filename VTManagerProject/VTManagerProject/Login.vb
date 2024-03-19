Imports System.Xml
Imports Npgsql

Public Class Login
    Private MstrHost As String
    Private MstrPort As String
    Private MstrDb As String
    Private MstrUser As String
    Private MstrPass As String
    Private MstrConnection As String
    Private MstrOwnerId As String
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load("Config.xml")
        MstrHost = xmlDoc.DocumentElement.SelectSingleNode("DB_HOST").InnerText()
        MstrPort = xmlDoc.DocumentElement.SelectSingleNode("DB_PORT").InnerText()
        MstrDb = xmlDoc.DocumentElement.SelectSingleNode("DB_DATABASE").InnerText()
        MstrUser = xmlDoc.DocumentElement.SelectSingleNode("DB_USERNAME").InnerText()
        MstrPass = xmlDoc.DocumentElement.SelectSingleNode("DB_PASSWORD").InnerText()

        MstrConnection = "Server=" & MstrHost & "; Port=" & MstrPort & "; User Id=" & MstrUser & ";Password=" & MstrPass & ";Database=" & MstrDb

        MstrOwnerId = xmlDoc.DocumentElement.SelectSingleNode("OWNER_ID").InnerText()
    End Sub

    Public Sub login()
        Dim Sql As String
        Dim Dt As New DataTable
        Dim whereUserID As String
        Dim whereUserPassword As String
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    If txtUserID.TextLength <> 0 Then
                        adp.SelectCommand.Parameters.Add("UserID", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("UserID").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("UserID").Value = txtUserID.Text
                        whereUserID = " AND ""MST_admin"".""adminId"" = :UserID"
                    End If

                    If txtPassword.TextLength <> 0 Then
                        adp.SelectCommand.Parameters.Add("UserPassword", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("UserPassword").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("UserPassword").Value = txtPassword.Text
                        whereUserPassword = " AND ""MST_admin"".""adminPassword"" = :UserPassword"
                    End If

                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""MST_admin"""
                    Sql &= " where ""MST_admin"".""ownerId"" = " & MstrOwnerId
                    Sql &= whereUserID & whereUserPassword

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        MessageBox.Show("Đăng nhập thành công")
                        Dim mainForm As New Main()
                        mainForm.AddOpenedForm(Me)
                        mainForm.Show()

                        ' Đóng form đăng nhập hiện tại
                        Me.Hide()
                    Else
                        MessageBox.Show("Không tìm thấy tài khoản - hãy liên hệ với quản trị hệ thống của bạn")
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("login" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        login()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtPassword.Text = ""
        txtUserID.Text = ""
    End Sub

End Class