Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FormAddEmployeeClass
    Private MstrHost As String
    Private MstrPort As String
    Private MstrDb As String
    Private MstrUser As String
    Private MstrPass As String
    Private MstrConnection As String
    Private MstrOwnerId As String

    'Private formEmployee As UCEmployee
    Private formEmployee As UCEmployeeClass
    Public Sub New(parent As UCEmployeeClass)
        InitializeComponent()
        Me.formEmployee = parent
    End Sub

    Private Sub FormAddEmployeeClass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim xmlDoc As New XmlDocument()

            xmlDoc.Load("Config.xml")

            MstrHost = xmlDoc.DocumentElement.SelectSingleNode("DB_HOST").InnerText()
            MstrPort = xmlDoc.DocumentElement.SelectSingleNode("DB_PORT").InnerText()
            MstrDb = xmlDoc.DocumentElement.SelectSingleNode("DB_DATABASE").InnerText()
            MstrUser = xmlDoc.DocumentElement.SelectSingleNode("DB_USERNAME").InnerText()
            MstrPass = xmlDoc.DocumentElement.SelectSingleNode("DB_PASSWORD").InnerText()

            MstrConnection = "Server=" & MstrHost & "; Port=" & MstrPort & "; User Id=" & MstrUser & ";Password=" & MstrPass & ";Database=" & MstrDb

            MstrOwnerId = xmlDoc.DocumentElement.SelectSingleNode("OWNER_ID").InnerText()

            txtEmployeeClassId.Text = GetMaxEmployeeClassId().ToString.PadLeft(6, "0")
        Catch ex As Exception
            MessageBox.Show("Form thêm Sản phẩm" & vbCrLf & ex.Message,
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
            End
        End Try
    End Sub



    Public Function getOwnerId(str)
        Dim result As String = ""

        For Each c As Char In str
            If Char.IsDigit(c) Then
                result += c
            End If
        Next
        Return result
    End Function


    Private Function GetMaxEmployeeClassId() As Integer
        Dim Sql As String
        Dim Dt As New DataTable
        Dim MaxId As Integer
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    Sql = "SELECT"
                    Sql &= " COALESCE(MAX(""employeeClassId""),'0') AS MaxId"
                    Sql &= " FROM public.""employee_class"""
                    Sql &= " WHERE ""ownerId"" = " & MstrOwnerId

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    MaxId = If(CInt(Dt.Rows(0).Item("MaxId")) = 0, 1, CInt(Dt.Rows(0).Item("MaxId")) + 1)
                    Dim a = MaxId
                End Using
                ConDb.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show("Xin vui lòng liên hệ với quản trị hệ thống của bạn",
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

        Return MaxId
    End Function


    Private Function InsertEmployeeClass() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand

        sql &= "INSERT INTO"
        sql &= " PUBLIC.""employee_class"""
        sql &= " ("
        sql &= """ownerId"""
        sql &= " , ""employeeClassId"""
        sql &= " , ""employeeClassName"""
        sql &= " )"
        sql &= " VALUES"
        sql &= " ("
        sql &= " :OWNER_ID"
        sql &= " , :EMPLOYEE_CLASS_ID"
        sql &= " , :EMPLOYEEC_CLASS_NAME"
        sql &= " );"

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb
                    .CommandText = sql
                    .Parameters.Add("OWNER_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("EMPLOYEE_CLASS_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("EMPLOYEEC_CLASS_NAME", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("OWNER_ID").Value = getOwnerId(MstrOwnerId).PadLeft(6, "0")
                    .Parameters.Item("EMPLOYEE_CLASS_ID").Value = txtEmployeeClassId.Text.PadLeft(6, "0")
                    .Parameters.Item("EMPLOYEEC_CLASS_NAME").Value = txtEmployeeClassName.Text

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message)
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        If formEmployee IsNot Nothing Then
            formEmployee.loadEmployeeClass()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtEmployeeClassId.Text) OrElse String.IsNullOrWhiteSpace(txtEmployeeClassName.Text) Then
            MessageBox.Show("Bạn chưa nhập đủ dữ liệu !")
        Else

            Dim result As Boolean = InsertEmployeeClass()

            If result = True Then
                MessageBox.Show("Hoàn thành")
                Me.Close()
                If formEmployee IsNot Nothing Then
                    formEmployee.loadEmployeeClass()
                End If
            Else
                MessageBox.Show("Lỗi")
                If formEmployee IsNot Nothing Then
                    formEmployee.loadEmployeeClass()
                End If
            End If
        End If

    End Sub
End Class