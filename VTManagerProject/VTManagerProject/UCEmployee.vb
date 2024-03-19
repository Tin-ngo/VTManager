Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql

Imports System.Globalization

Public Class UCEmployee
    Private MstrConnection As String
    Private MstrOwnerId As String

    Public Sub UCEmployee_Load()
        Dim xmlDoc As New XmlDocument()

        MstrConnection = InforConnection.MstrConnection
        MstrOwnerId = InforConnection.MstrOwnerId

        InterfaceCustomize()

        loadEmployee()
        loadDataInComboboxEmployeeClass()

    End Sub

    Public Function InterfaceCustomize()
        DGVEmployee.AutoGenerateColumns = False
        DGVEmployee.RowHeadersVisible = False
        DGVEmployee.AllowUserToAddRows = False
        DGVEmployee.EnableHeadersVisualStyles = False
    End Function


    '============================================================ NHÂN VIÊN ========================================================

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
            MessageBox.Show("loadDataInComboboxProductType" & vbCrLf & "Lỗi khi tải dữ liệu vào combobox. " & vbCrLf & ex.Message,
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

    End Sub


    Public Sub loadEmployee()
        Dim Sql As String
        Dim Dt As New DataTable
        Dim whereEmployeeClassId As String
        Dim whereEmployeeName As String

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)


                    If ComboBoxEmployeeClass.SelectedIndex <> -1 Then
                        adp.SelectCommand.Parameters.Add("EmployeeClassId", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("EmployeeClassId").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("EmployeeClassId").Value = ComboBoxEmployeeClass.SelectedValue
                        whereEmployeeClassId = " AND ""employee"".""employeeClassId"" = :EmployeeClassId"
                    End If

                    If txtEmployeeName.TextLength <> 0 Then
                        adp.SelectCommand.Parameters.Add("EmployeeName", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("EmployeeName").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("EmployeeName").Value = "%" & txtEmployeeName.Text & "%"
                        whereEmployeeName = " AND ""employee"".""employeeName"" LIKE :EmployeeName"
                    End If

                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""employee"""
                    Sql &= " LEFT JOIN PUBLIC.""employee_class"" "
                    Sql &= " ON ""employee"".""employeeClassId"" = ""employee_class"".""employeeClassId"""
                    Sql &= " where ""employee"".""ownerId"" = " & MstrOwnerId & " AND ""employee_class"".""ownerId"" = " & MstrOwnerId
                    Sql &= whereEmployeeClassId & whereEmployeeName
                    Sql &= " ORDER BY ""employee"".""employeeId"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVEmployee.DataSource = SetData(Dt)
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVEmployee.DataSource = SetData(Dt)
                        MessageBox.Show("Không tìm thấy dữ liệu")
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("load employee" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function SetData(data As DataTable) As DataTable
        Dim DataResult As New DataTable
        DataResult.Columns.Add("ownerId", GetType(String))
        DataResult.Columns.Add("employeeId", GetType(String))
        DataResult.Columns.Add("employeeClassId", GetType(String))
        DataResult.Columns.Add("employeeClassName", GetType(String))
        DataResult.Columns.Add("employeeName", GetType(String))
        DataResult.Columns.Add("birthday", GetType(String))
        DataResult.Columns.Add("startDate", GetType(String))
        DataResult.Columns.Add("password", GetType(String))
        'DataResult.Columns.Add("endDate", GetType(String))

        For indexId As Integer = 0 To data.Rows.Count() - 1
            Dim newRow As DataRow = DataResult.NewRow()
            newRow("ownerId") = data(indexId)("ownerId")
            newRow("employeeId") = data(indexId)("employeeId")
            newRow("employeeClassId") = data(indexId)("employeeClassId")
            newRow("employeeClassName") = data(indexId)("employeeClassName")
            newRow("employeeName") = data(indexId)("employeeName")
            newRow("birthday") = DateTime.ParseExact(data(indexId)("birthday").ToString(), "ddMMyyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy")
            newRow("startDate") = DateTime.ParseExact(data(indexId)("startDate").ToString(), "ddMMyyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy")
            'newRow("endDate") = If(Not String.IsNullOrEmpty(data(indexId)("endDate").ToString()),
            '          DateTime.ParseExact(data(indexId)("endDate").ToString(), "ddMMyyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"), "")

            newRow("password") = data(indexId)("password")
            DataResult.Rows.Add(newRow)
        Next
        Return DataResult
    End Function


    Private Function deleteEmployeeAction(employeeId) As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereEmployeeId As String = ""

        sql &= "DELETE FROM "
        sql &= " PUBLIC.""employee"""
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("EmployeeId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("EmployeeId").Direction = ParameterDirection.Input
                    .Parameters("EmployeeId").Value = employeeId.PadLeft(6, "0")
                    WhereEmployeeId = " AND ""employeeId"" = :EmployeeId"

                    sql &= WhereEmployeeId
                    sql &= " ;"

                    .CommandText = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "productType delete")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function



    Private Sub btnAddEmployee_Click(sender As Object, e As EventArgs) Handles btnAddEmployee.Click
        Dim FormAddOrUpdateEmployee As New FormAddOrUpdateEmployee(Me)

        Me.Cursor = Cursors.WaitCursor
        FormAddOrUpdateEmployee.ShowDialog()

        Me.Cursor = Cursors.Default
    End Sub




    Private Sub DGVEmployee_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVEmployee.CellClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = senderGrid.Rows(e.RowIndex)
            Dim columnName As String = senderGrid.Columns(e.ColumnIndex).Name
            If columnName = "deleteEmployee" Then
                ' Hiển thị hộp thoại xác nhận
                Dim confirmResult As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?",
                                                          "Xác nhận xóa",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question)
                If confirmResult = DialogResult.Yes Then
                    Dim idValue As Object = selectedRow.Cells("employeeId").Value
                    If idValue IsNot Nothing Then
                        Dim result = deleteEmployeeAction(idValue)
                        If result = True Then
                            MessageBox.Show("Xóa thành công")
                            loadEmployee()
                        Else
                            MessageBox.Show("Xóa lỗi")
                            loadEmployee()
                        End If
                    Else
                        MessageBox.Show("Giá trị id không tồn tại.")
                    End If
                End If
            Else
                If columnName = "updateEmployee" Then
                    Dim FormAddOrUpdateEmployee As New FormAddOrUpdateEmployee(Me)
                    FormAddOrUpdateEmployee.employeeId = selectedRow.Cells("employeeId").Value
                    FormAddOrUpdateEmployee.employeeClassId = selectedRow.Cells("employeeClassId").Value
                    FormAddOrUpdateEmployee.employeeName = selectedRow.Cells("employeeName").Value
                    FormAddOrUpdateEmployee.birthday = selectedRow.Cells("birthday").Value.Replace("/", "")
                    FormAddOrUpdateEmployee.startDate = selectedRow.Cells("startDate").Value.Replace("/", "")
                    FormAddOrUpdateEmployee.password = selectedRow.Cells("password").Value
                    'FormAddOrUpdateEmployee.endDate = selectedRow.Cells("endDate").Value.Replace("/", "")
                    Me.Cursor = Cursors.WaitCursor
                    FormAddOrUpdateEmployee.ShowDialog()

                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        loadEmployee()
    End Sub

    Private Sub btnCLear_Click(sender As Object, e As EventArgs) Handles btnCLear.Click
        txtEmployeeName.Text = ""
        ComboBoxEmployeeClass.SelectedValue = -1
        loadEmployee()
    End Sub

    Private Sub DGVEmployee_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVEmployee.DataBindingComplete
        If DGVEmployee.SelectedRows.Count > 0 Then
            DGVEmployee.SelectedRows(0).Selected = False
        End If
    End Sub


End Class
