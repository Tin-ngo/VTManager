Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Globalization

Public Class FormAddOrUpdateEmployee

    Private MstrHost As String
    Private MstrPort As String
    Private MstrDb As String
    Private MstrUser As String
    Private MstrPass As String
    Private MstrConnection As String
    Private MstrOwnerId As String

    Public employeeId As String
    Public employeeClassId As String
    Public employeeName As String
    Public birthday As String
    Public startDate As String
    Public password As String
    'Public endDate As String

    Public isUpdate As Boolean

    Private formEmployee As UCEmployee
    Public Sub New(parent As UCEmployee)
        InitializeComponent()
        Me.formEmployee = parent
    End Sub

    Private Sub FormAddOrUpdateEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            loadDataInComboboxEmployeeClass()

            If String.IsNullOrEmpty(employeeId) Then
                isUpdate = False
                txtEmployeeId.Text = GetMaxEmployeeId.ToString.PadLeft(6, "0")
            Else
                isUpdate = True
                txtEmployeeId.Text = employeeId
                txtEmployeeName.Text = employeeName
                ComboBoxEmployeeClass.SelectedValue = employeeClassId
                DateTimePickerBirthday.Value = DateTime.ParseExact(birthday, "ddMMyyyy", CultureInfo.InvariantCulture)
                DateTimePickerStart.Value = DateTime.ParseExact(startDate, "ddMMyyyy", CultureInfo.InvariantCulture)
                txtPass.Text = password
                'If Not String.IsNullOrEmpty(endDate) Then
                '    DateTimePickerEnd.Value = DateTime.ParseExact(endDate, "ddMMyyyy", CultureInfo.InvariantCulture)
                'Else
                '    'DateTimePickerEnd.Value = DateTime.ParseExact("01013000", "ddMMyyyy", CultureInfo.InvariantCulture)
                '    Label7.Visible = False
                '    DateTimePickerEnd.Visible = False
                'End If
            End If

            If isUpdate = True Then
                Label1.Text = "Sửa Nhân Viên"
            End If


        Catch ex As Exception
            MessageBox.Show("Form thêm Nhân viên" & vbCrLf & ex.Message,
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Public Sub loadDataInComboboxEmployeeClass()
        Dim Sql As String
        Dim Dt As New DataTable
        Try
            ' Thao tác với database
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT * FROM public.""employee_class"""
                    Sql &= " where ""ownerId"" = " & MstrOwnerId

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ComboBoxEmployeeClass.DataSource = Dt
                        ComboBoxEmployeeClass.DisplayMember = "employeeClassName"
                        ComboBoxEmployeeClass.ValueMember = "employeeClassId"
                        ComboBoxEmployeeClass.SelectedIndex = -1
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadDataInComboboxEmployeeClass" & vbCrLf & "Lỗi khi tải dữ liệu vào combobox. " & vbCrLf & ex.Message,
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function GetMaxEmployeeId() As Integer
        Dim Sql As String
        Dim Dt As New DataTable
        Dim MaxId As Integer
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    Sql = "SELECT"
                    Sql &= " COALESCE(MAX(""employeeId""),'0') AS MaxId"
                    Sql &= " FROM public.""employee"""
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

    Public Function getOwnerId(str)
        Dim result As String = ""

        For Each c As Char In str
            If Char.IsDigit(c) Then
                result += c
            End If
        Next
        Return result
    End Function


    Private Function InsertEmployee() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand

        sql &= "INSERT INTO"
        sql &= " PUBLIC.""employee"""
        sql &= " ("
        sql &= """ownerId"""
        sql &= " , ""employeeId"""
        sql &= " , ""employeeClassId"""
        sql &= " , ""employeeName"""
        sql &= " , ""birthday"""
        sql &= " , ""startDate"""
        sql &= " , ""password"""
        'sql &= " , ""endDate"""
        sql &= " )"
        sql &= " VALUES"
        sql &= " ("
        sql &= " :OWNER_ID"
        sql &= " , :EMPLOYEE_ID"
        sql &= " , :EMPLOYEE_CLASS_ID"
        sql &= " , :EMPLOYEE_NAME"
        sql &= " , :BIRTHDAY"
        sql &= " , :START_DATE"
        sql &= " , :PASSWORD"
        'sql &= " , :END_DATE"
        sql &= " );"

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb
                    .CommandText = sql
                    .Parameters.Add("OWNER_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("EMPLOYEE_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("EMPLOYEE_CLASS_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("EMPLOYEE_NAME", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("BIRTHDAY", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("START_DATE", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("PASSWORD", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("OWNER_ID").Value = getOwnerId(MstrOwnerId).PadLeft(6, "0")
                    .Parameters.Item("EMPLOYEE_ID").Value = txtEmployeeId.Text
                    .Parameters.Item("EMPLOYEE_CLASS_ID").Value = ComboBoxEmployeeClass.SelectedValue
                    .Parameters.Item("EMPLOYEE_NAME").Value = txtEmployeeName.Text
                    .Parameters.Item("BIRTHDAY").Value = DateTimePickerBirthday.Text.Replace("-", "")
                    .Parameters.Item("START_DATE").Value = DateTimePickerStart.Text.Replace("-", "")
                    .Parameters.Item("PASSWORD").Value = txtPass.Text

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message.ToString())
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Function updateEmployee() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereEmployeeId As String = ""

        sql &= "UPDATE"
        sql &= " PUBLIC.""employee"""
        sql &= " SET "
        sql &= " ""employeeClassId"" = :EMPLOYEE_CLASS_ID"
        sql &= " , ""employeeName"" = :EMPLOYEE_NAME"
        sql &= " , ""birthday"" = :BIRTHDAY"
        sql &= " , ""startDate"" = :START_DATE"
        sql &= " , ""password"" = :PASSWORD"
        'sql &= " , ""endDate"" = :END_DATE"
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("EmployeeId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("EmployeeId").Direction = ParameterDirection.Input
                    .Parameters("EmployeeId").Value = txtEmployeeId.Text
                    WhereEmployeeId = " AND ""employeeId"" = :EmployeeId"


                    sql &= WhereEmployeeId
                    sql &= " ;"

                    .CommandText = sql

                    .Parameters.Add("EMPLOYEE_CLASS_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("EMPLOYEE_NAME", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("BIRTHDAY", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("START_DATE", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("PASSWORD", NpgsqlTypes.NpgsqlDbType.Text)
                    '.Parameters.Add("END_DATE", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("EMPLOYEE_CLASS_ID").Value = ComboBoxEmployeeClass.SelectedValue
                    .Parameters.Item("EMPLOYEE_NAME").Value = txtEmployeeName.Text
                    .Parameters.Item("BIRTHDAY").Value = DateTimePickerBirthday.Text.Replace("-", "")
                    .Parameters.Item("START_DATE").Value = DateTimePickerStart.Text.Replace("-", "")
                    .Parameters.Item("PASSWORD").Value = txtPass.Text
                    '.Parameters.Item("END_DATE").Value = DateTimePickerEnd.Text.Replace("-", "")

                    Dim a = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "cập nhật nhân viên")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        If formEmployee IsNot Nothing Then
            formEmployee.loadEmployee()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtEmployeeId.Text) OrElse String.IsNullOrWhiteSpace(txtEmployeeName.Text) OrElse String.IsNullOrWhiteSpace(txtPass.Text) OrElse ComboBoxEmployeeClass.SelectedIndex = -1 Then
            MessageBox.Show("Bạn chưa nhập đủ dữ liệu !")
        Else
            Dim result As Boolean
            If isUpdate = False Then
                result = InsertEmployee()
            Else
                result = updateEmployee()
            End If
            If result = True Then
                MessageBox.Show("Hoàn thành")
                Me.Close()
                If formEmployee IsNot Nothing Then
                    formEmployee.loadEmployee()
                End If
            Else
                MessageBox.Show("Lỗi")
                If formEmployee IsNot Nothing Then
                    formEmployee.loadEmployee()
                End If
            End If
        End If

    End Sub
End Class