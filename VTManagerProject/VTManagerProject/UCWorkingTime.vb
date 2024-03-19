Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql


Public Class UCWorkingTime
    Private MstrConnection As String
    Private MstrOwnerId As String

    Private isUpdate As Boolean

    Public Sub UCWorkingTime_Load()
        MstrConnection = InforConnection.MstrConnection
        MstrOwnerId = InforConnection.MstrOwnerId

        InterfaceCustomize()
        loadWorkingTime()
    End Sub

    Public Function InterfaceCustomize()
        DGVWorkingTime.AutoGenerateColumns = False
        DGVWorkingTime.RowHeadersVisible = False
        DGVWorkingTime.AllowUserToAddRows = False
        DGVWorkingTime.EnableHeadersVisualStyles = False
        loadDataInComboboxDateOfWeek()
        loadDataInComboboxWorkingTime()
        loadComboboxEmployee()

        loadDataInComboboxWorkingTime2()
        loadDataInComboboxDateOfWeek2()
    End Function

    Private Sub loadDataInComboboxDateOfWeek()
        Dim dt As New DataTable()

        ' Tạo các cột cho DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("num", GetType(Integer))

        ' Thêm dữ liệu thủ công
        Dim row1 As DataRow = dt.NewRow()
        row1("num") = 0
        row1("text") = "Chủ nhật"
        dt.Rows.Add(row1)

        Dim row2 As DataRow = dt.NewRow()
        row2("num") = 1
        row2("text") = "Thứ 2"
        dt.Rows.Add(row2)

        Dim row3 As DataRow = dt.NewRow()
        row3("num") = 2
        row3("text") = "Thứ 3"
        dt.Rows.Add(row3)

        Dim row4 As DataRow = dt.NewRow()
        row4("num") = 3
        row4("text") = "Thứ 4"
        dt.Rows.Add(row4)

        Dim row5 As DataRow = dt.NewRow()
        row5("num") = 4
        row5("text") = "Thứ 5"
        dt.Rows.Add(row5)

        Dim row6 As DataRow = dt.NewRow()
        row6("num") = 5
        row6("text") = "Thứ 6"
        dt.Rows.Add(row6)

        Dim row7 As DataRow = dt.NewRow()
        row7("num") = 6
        row7("text") = "Thứ 7"
        dt.Rows.Add(row7)

        If dt.Rows.Count <> 0 Then
            ComboBoxDateOfWeek.DataSource = dt
            ComboBoxDateOfWeek.DisplayMember = "text"
            ComboBoxDateOfWeek.ValueMember = "num"
            ComboBoxDateOfWeek.SelectedIndex = -1
        End If
    End Sub

    Private Sub loadDataInComboboxDateOfWeek2()
        Dim dt As New DataTable()

        ' Tạo các cột cho DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("num", GetType(Integer))

        ' Thêm dữ liệu thủ công
        Dim row1 As DataRow = dt.NewRow()
        row1("num") = 0
        row1("text") = "Chủ nhật"
        dt.Rows.Add(row1)

        Dim row2 As DataRow = dt.NewRow()
        row2("num") = 1
        row2("text") = "Thứ 2"
        dt.Rows.Add(row2)

        Dim row3 As DataRow = dt.NewRow()
        row3("num") = 2
        row3("text") = "Thứ 3"
        dt.Rows.Add(row3)

        Dim row4 As DataRow = dt.NewRow()
        row4("num") = 3
        row4("text") = "Thứ 4"
        dt.Rows.Add(row4)

        Dim row5 As DataRow = dt.NewRow()
        row5("num") = 4
        row5("text") = "Thứ 5"
        dt.Rows.Add(row5)

        Dim row6 As DataRow = dt.NewRow()
        row6("num") = 5
        row6("text") = "Thứ 6"
        dt.Rows.Add(row6)

        Dim row7 As DataRow = dt.NewRow()
        row7("num") = 6
        row7("text") = "Thứ 7"
        dt.Rows.Add(row7)

        If dt.Rows.Count <> 0 Then

            ComboBoxDateOfWeek2.DataSource = dt
            ComboBoxDateOfWeek2.DisplayMember = "text"
            ComboBoxDateOfWeek2.ValueMember = "num"
            ComboBoxDateOfWeek2.SelectedIndex = -1
        End If
    End Sub

    Public Sub loadDataInComboboxWorkingTime()
        Dim Sql As String
        Dim Dt As New DataTable
        Try
            ' Thao tác với database
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT ""startTime"", ""endTime"", MAX(""ownerId"") AS ""ownerId"", MAX(""idWorkingTime"") AS ""idWorkingTime"", MAX(""dateOfWeek"") AS ""dateOfWeek"""
                    Sql &= " FROM public.working_time_master"
                    Sql &= " GROUP BY ""startTime"", ""endTime"""
                    Sql &= " ORDER BY ""ownerId"" ASC, ""idWorkingTime"" ASC, ""dateOfWeek"" ASC"

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Thực hiện định dạng chuỗi trong DataTable
                        Dt.Columns.Add("FormattedTimeDisplay", GetType(String), "SUBSTRING(startTime, 1, 2) + ':' + SUBSTRING(startTime, 3, 2) + ' - ' + SUBSTRING(endTime, 1, 2) + ':' + SUBSTRING(endTime, 3, 2)")

                        ' Sử dụng cột mới trong DisplayMember
                        ComboBoxWorkingTime.DataSource = Dt
                        ComboBoxWorkingTime.DisplayMember = "FormattedTimeDisplay"
                        ComboBoxWorkingTime.ValueMember = "idWorkingTime"
                        ComboBoxWorkingTime.SelectedIndex = -1
                    End If
                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadDataInComboboxWorkingTime" & vbCrLf & "Lỗi khi tải dữ liệu vào combobox. " & vbCrLf & ex.Message,
        "Lỗi",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub loadDataInComboboxWorkingTime2()
        Dim Sql As String
        Dim Dt As New DataTable
        Try
            ' Thao tác với database
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT ""startTime"", ""endTime"", MAX(""ownerId"") AS ""ownerId"", MAX(""idWorkingTime"") AS ""idWorkingTime"", MAX(""dateOfWeek"") AS ""dateOfWeek"""
                    Sql &= " FROM public.working_time_master"
                    Sql &= " GROUP BY ""startTime"", ""endTime"""
                    Sql &= " ORDER BY ""ownerId"" ASC, ""idWorkingTime"" ASC, ""dateOfWeek"" ASC"

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Thực hiện định dạng chuỗi trong DataTable
                        Dt.Columns.Add("FormattedTimeDisplay", GetType(String), "SUBSTRING(startTime, 1, 2) + ':' + SUBSTRING(startTime, 3, 2) + ' - ' + SUBSTRING(endTime, 1, 2) + ':' + SUBSTRING(endTime, 3, 2)")

                        ' Sử dụng cột mới trong DisplayMember
                        ComboBoxWorkingTime2.DataSource = Dt
                        ComboBoxWorkingTime2.DisplayMember = "FormattedTimeDisplay"
                        ComboBoxWorkingTime2.ValueMember = "idWorkingTime"
                        ComboBoxWorkingTime2.SelectedIndex = -1
                    End If
                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadDataInComboboxWorkingTime" & vbCrLf & "Lỗi khi tải dữ liệu vào combobox. " & vbCrLf & ex.Message,
        "Lỗi",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub loadComboboxEmployee()
        Dim Sql As String
        Dim Dt As New DataTable
        Try
            ' Thao tác với database
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""employee"""
                    Sql &= " where ""employee"".""ownerId"" = " & MstrOwnerId

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then

                        ' Sử dụng cột mới trong DisplayMember
                        ComboBoxEmployee.DataSource = Dt
                        ComboBoxEmployee.DisplayMember = "employeeName"
                        ComboBoxEmployee.ValueMember = "employeeId"
                        ComboBoxEmployee.SelectedIndex = -1

                        ' Loại bỏ cột cũ nếu cần
                        ' Dt.Columns.Remove("CombinedTime")
                    End If
                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadDataIn ComboBoxEmployee" & vbCrLf & "Lỗi khi tải dữ liệu vào ComboBoxEmployee. " & vbCrLf & ex.Message,
        "Lỗi",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub loadWorkingTime()

        Dim Sql As String
        Dim Dt As New DataTable
        Dim whereEmployeeName As String
        Dim whereDateOfWeek As String
        Dim whereIdWorkingTime As String

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    If txtEmployeeName.TextLength <> 0 Then
                        adp.SelectCommand.Parameters.Add("EmployeeName", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("EmployeeName").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("EmployeeName").Value = "%" & txtEmployeeName.Text & "%"
                        whereEmployeeName = " AND ""employee"".""employeeName"" LIKE :EmployeeName"
                    End If

                    If ComboBoxDateOfWeek.SelectedIndex <> -1 Then
                        adp.SelectCommand.Parameters.Add("DateOfWeek", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("DateOfWeek").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("DateOfWeek").Value = ComboBoxDateOfWeek.SelectedValue.ToString
                        whereDateOfWeek = " AND ""working_time"".""dateOfWeek"" = :DateOfWeek"
                    End If

                    If ComboBoxWorkingTime.SelectedIndex <> -1 Then
                        adp.SelectCommand.Parameters.Add("IdWorkingTime", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("IdWorkingTime").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("IdWorkingTime").Value = ComboBoxWorkingTime.SelectedValue
                        whereIdWorkingTime = " AND ""working_time"".""idWorkingTime"" = :IdWorkingTime"
                    End If

                    'If ComboBoxProductType.SelectedIndex <> -1 Then
                    '    adp.SelectCommand.Parameters.Add("ProductType", NpgsqlTypes.NpgsqlDbType.Text)
                    '    adp.SelectCommand.Parameters("ProductType").Direction = ParameterDirection.Input
                    '    adp.SelectCommand.Parameters("ProductType").Value = ComboBoxProductType.SelectedValue
                    '    whereProductType = " AND ""product"".""productTypeId"" = :ProductType"
                    'End If

                    'If txtProductName.TextLength <> 0 Then
                    '    adp.SelectCommand.Parameters.Add("ProductName", NpgsqlTypes.NpgsqlDbType.Text)
                    '    adp.SelectCommand.Parameters("ProductName").Direction = ParameterDirection.Input
                    '    adp.SelectCommand.Parameters("ProductName").Value = "%" & txtProductName.Text & "%"
                    '    whereProductName = " AND ""product"".""productName"" LIKE :ProductName"
                    'End If


                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""working_time"""
                    Sql &= " LEFT JOIN PUBLIC.""employee"""
                    Sql &= " ON ""working_time"".""employeeId"" = ""employee"".""employeeId"""
                    Sql &= " LEFT JOIN PUBLIC.""working_time_master"""
                    Sql &= " ON ""working_time"".""idWorkingTime"" = ""working_time_master"".""idWorkingTime"""
                    Sql &= " AND ""working_time"".""dateOfWeek"" = ""working_time_master"".""dateOfWeek"""
                    Sql &= " LEFT JOIN PUBLIC.""salary"""
                    Sql &= " ON ""working_time_master"".""salaryId"" = ""salary"".""salaryId"""
                    Sql &= " where ""working_time"".""ownerId"" = " & MstrOwnerId & " AND ""working_time_master"".""ownerId"" = " & MstrOwnerId & " AND ""salary"".""ownerId"" = " & MstrOwnerId & " AND ""employee"".""ownerId"" = " & MstrOwnerId
                    Sql &= whereEmployeeName & whereDateOfWeek & whereIdWorkingTime
                    Sql &= " ORDER BY ""working_time"".""dateOfWeek"" ASC , ""working_time"".""idWorkingTime"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVWorkingTime.DataSource = SetData(Dt)
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVWorkingTime.DataSource = SetData(Dt)
                        MessageBox.Show("Không tìm thấy dữ liệu")
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadWorkingTime" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

    End Sub


    Private Function SetData(data As DataTable) As DataTable
        Dim DataResult As New DataTable
        DataResult.Columns.Add("idWorkingTime", GetType(String))
        DataResult.Columns.Add("dateOfWeek", GetType(String))
        DataResult.Columns.Add("dateOfWeek_Show", GetType(String))
        DataResult.Columns.Add("startTime", GetType(String))
        DataResult.Columns.Add("startTime_Show", GetType(String))
        DataResult.Columns.Add("endTime", GetType(String))
        DataResult.Columns.Add("endTime_Show", GetType(String))
        DataResult.Columns.Add("salaryId", GetType(String))
        DataResult.Columns.Add("salary", GetType(String))
        DataResult.Columns.Add("employeeId", GetType(String))
        DataResult.Columns.Add("employeeName", GetType(String))

        For indexId As Integer = 0 To data.Rows.Count() - 1
            Dim newRow As DataRow = DataResult.NewRow()

            newRow("idWorkingTime") = data(indexId)("idWorkingTime")
            newRow("dateOfWeek") = data(indexId)("dateOfWeek")
            newRow("dateOfWeek_Show") = setTextDateOfWeek(data(indexId)("dateOfWeek"))
            newRow("startTime") = data(indexId)("startTime")
            newRow("startTime_Show") = formatTime(data(indexId)("startTime"))
            newRow("endTime") = data(indexId)("endTime")
            newRow("endTime_Show") = formatTime(data(indexId)("endTime"))
            newRow("salaryId") = data(indexId)("salaryId")
            newRow("salary") = CInt(data(indexId)("salary")).ToString("N0")
            newRow("employeeId") = data(indexId)("employeeId")
            newRow("employeeName") = data(indexId)("employeeName")

            DataResult.Rows.Add(newRow)
        Next
        Return DataResult
    End Function

    Private Function formatTime(timeString)
        ' Chuyển đổi chuỗi thành đối tượng DateTime
        Dim time As DateTime = DateTime.ParseExact(timeString, "HHmm", Nothing)
        ' Chuyển đổi lại thành chuỗi định dạng 24 giờ
        Dim formattedTime As String = time.ToString("HH:mm")
        Return formattedTime
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

    Private Function setTextDateOfWeek(number)
        If number = 0 Then
            Return "Chủ nhật"
        ElseIf number = 1 Then
            Return "Thứ 2"
        ElseIf number = 2 Then
            Return "Thứ 3"
        ElseIf number = 3 Then
            Return "Thứ 4"
        ElseIf number = 4 Then
            Return "Thứ 5"
        ElseIf number = 5 Then
            Return "Thứ 6"
        ElseIf number = 6 Then
            Return "Thứ 7"
        End If
    End Function

    Private Function updateWorkingTime()
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereIdWorkingTime As String = ""
        Dim WhereDateOfWeek As String = ""
        Dim WhereEmployeeId As String = ""

        sql &= "UPDATE"
        sql &= " PUBLIC.""working_time"""
        sql &= " SET"
        sql &= " ""employeeId"" = :EMPLOYEE_ID"
        sql &= " , ""idWorkingTime"" = :ID_WORKING_TIME"
        sql &= " , ""dateOfWeek"" = :DATE_OF_WEEK"
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("IdWorkingTime", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("IdWorkingTime").Direction = ParameterDirection.Input
                    .Parameters("IdWorkingTime").Value = lblWorkingTime_Old.Text 'ComboBoxWorkingTime2.SelectedValue.ToString.PadLeft(6, "0")
                    WhereIdWorkingTime = " AND ""idWorkingTime"" = :IdWorkingTime"


                    .Parameters.Add("DateOfWeek", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("DateOfWeek").Direction = ParameterDirection.Input
                    .Parameters("DateOfWeek").Value = lblDateOfWeek_Old.Text ' ComboBoxDateOfWeek2.SelectedValue.ToString
                    WhereDateOfWeek = " AND ""dateOfWeek"" = :DateOfWeek"

                    .Parameters.Add("EmployeeId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("EmployeeId").Direction = ParameterDirection.Input
                    .Parameters("EmployeeId").Value = lblEmployeeId_Old.Text
                    WhereEmployeeId = " AND ""employeeId"" = :EmployeeId"


                    sql &= WhereIdWorkingTime & WhereDateOfWeek & WhereEmployeeId
                    sql &= " ;"

                    .CommandText = sql

                    .Parameters.Add("EMPLOYEE_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("ID_WORKING_TIME", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("DATE_OF_WEEK", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("EMPLOYEE_ID").Value = ComboBoxEmployee.SelectedValue.ToString.PadLeft(6, "0")
                    .Parameters.Item("ID_WORKING_TIME").Value = ComboBoxWorkingTime2.SelectedValue.ToString.PadLeft(6, "0")
                    .Parameters.Item("DATE_OF_WEEK").Value = ComboBoxDateOfWeek2.SelectedValue.ToString

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "updateWorkingTime")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function


    Private Function InsertWorkingTime() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand

        sql &= "INSERT INTO"
        sql &= " PUBLIC.""working_time"""
        sql &= " ("
        sql &= """ownerId"""
        sql &= " , ""dateOfWeek"""
        sql &= " , ""idWorkingTime"""
        sql &= " , ""employeeId"""
        sql &= " )"
        sql &= " VALUES"
        sql &= " ("
        sql &= " :OWNER_ID"
        sql &= " , :DATE_OF_WEEK"
        sql &= " , :ID_WORKING_TIME"
        sql &= " , :EMPLOYEE_ID"
        sql &= " );"

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb
                    .CommandText = sql
                    .Parameters.Add("OWNER_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("DATE_OF_WEEK", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("ID_WORKING_TIME", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("EMPLOYEE_ID", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("OWNER_ID").Value = getOwnerId(MstrOwnerId).PadLeft(6, "0")
                    .Parameters.Item("DATE_OF_WEEK").Value = ComboBoxDateOfWeek2.SelectedValue.ToString   'txtDateOfWeek.Text
                    .Parameters.Item("ID_WORKING_TIME").Value = ComboBoxWorkingTime2.SelectedValue.ToString.PadLeft(6, "0") ' txtIdWorkingTime.Text
                    .Parameters.Item("EMPLOYEE_ID").Value = ComboBoxEmployee.SelectedValue

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

    Private Function deleteWorkingTime(idWorkingTime, dateOfWeek, employeeId) As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereIdWorkingTime As String = ""
        Dim WhereDateOfWeek As String = ""
        Dim WhereEmployeeId As String = ""

        sql &= "DELETE FROM "
        sql &= " PUBLIC.""working_time"""
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("IdWorkingTime", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("IdWorkingTime").Direction = ParameterDirection.Input
                    .Parameters("IdWorkingTime").Value = idWorkingTime.PadLeft(6, "0")
                    WhereIdWorkingTime = " AND ""idWorkingTime"" = :IdWorkingTime"

                    .Parameters.Add("DateOfWeek", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("DateOfWeek").Direction = ParameterDirection.Input
                    .Parameters("DateOfWeek").Value = dateOfWeek
                    WhereDateOfWeek = " AND ""dateOfWeek"" = :DateOfWeek"

                    .Parameters.Add("EmployeeId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("EmployeeId").Direction = ParameterDirection.Input
                    .Parameters("EmployeeId").Value = employeeId.PadLeft(6, "0")
                    WhereEmployeeId = " AND ""employeeId"" = :EmployeeId"


                    sql &= WhereIdWorkingTime & WhereDateOfWeek & WhereEmployeeId
                    sql &= " ;"

                    .CommandText = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "workingTime delete")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        loadWorkingTime()
    End Sub

    Private Sub btnClearList_Click(sender As Object, e As EventArgs) Handles btnClearList.Click
        ComboBoxDateOfWeek.SelectedIndex = -1
        ComboBoxWorkingTime.SelectedIndex = -1
        txtEmployeeName.Text = ""
        loadWorkingTime()
    End Sub

    Private Sub DGVWorkingTime_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVWorkingTime.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If e.RowIndex >= 0 Then
            ' Kiểm tra tên cột để phân biệt giữa hai cột button
            Dim selectedRow As DataGridViewRow = senderGrid.Rows(e.RowIndex)
            Dim columnName As String = senderGrid.Columns(e.ColumnIndex).Name

            If columnName = "edit" Then

                ' Thực hiện các tác vụ cần thiết cho cột 1
                isUpdate = True
                btnUpdate.Text = "Cập nhật"

                lblEmployeeId_Old.Text = selectedRow.Cells("employeeId").Value
                lblDateOfWeek_Old.Text = selectedRow.Cells("dateOfWeek").Value
                lblWorkingTime_Old.Text = selectedRow.Cells("idWorkingTime").Value
                ComboBoxEmployee.SelectedValue = selectedRow.Cells("employeeId").Value
                ComboBoxDateOfWeek2.SelectedValue = selectedRow.Cells("dateOfWeek").Value
                ComboBoxWorkingTime2.SelectedValue = selectedRow.Cells("idWorkingTime").Value
                'txtStartTime.Text = selectedRow.Cells("startTime").Value
                'txtEndTime.Text = selectedRow.Cells("endTime").Value


            ElseIf columnName = "addNew" Then
                isUpdate = False
                btnUpdate.Text = "Thêm mới"

                ComboBoxEmployee.SelectedValue = -1
                'txtDateOfWeek.Text = selectedRow.Cells("dateOfWeek").Value
                ComboBoxDateOfWeek2.SelectedValue = selectedRow.Cells("dateOfWeek").Value
                ' txtIdWorkingTime.Text = selectedRow.Cells("idWorkingTime").Value
                ComboBoxWorkingTime2.SelectedValue = selectedRow.Cells("idWorkingTime").Value
                'txtStartTime.Text = selectedRow.Cells("startTime").Value
                'txtEndTime.Text = selectedRow.Cells("endTime").Value

            ElseIf columnName = "delete" Then
                Dim confirmResult As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?",
                              "Xác nhận xóa",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question)
                If confirmResult = DialogResult.Yes Then
                    ' Thực hiện xóa
                    Dim idWorkingTime As Object = selectedRow.Cells("idWorkingTime").Value
                    Dim dateOfWeek As Object = selectedRow.Cells("dateOfWeek").Value
                    Dim employeeId As Object = selectedRow.Cells("employeeId").Value
                    If idWorkingTime IsNot Nothing And dateOfWeek IsNot Nothing And employeeId IsNot Nothing Then
                        Dim result = deleteWorkingTime(idWorkingTime, dateOfWeek, employeeId)
                        If result = True Then
                            MessageBox.Show("Xóa thành công")
                            loadWorkingTime()
                        Else
                            MessageBox.Show("Xóa lỗi")
                            loadWorkingTime()
                        End If
                    Else
                        MessageBox.Show("Giá trị id không tồn tại.")
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If ComboBoxDateOfWeek2.SelectedIndex = -1 OrElse ComboBoxWorkingTime2.SelectedIndex = -1 OrElse ComboBoxEmployee.SelectedIndex = -1 Then
            MessageBox.Show("Bạn chưa nhập đủ dữ liệu !")
        Else

            Dim result As Boolean
            If isUpdate = True Then
                result = updateWorkingTime()
            Else
                result = InsertWorkingTime()
            End If

            If result = True Then
                MessageBox.Show("Hoàn thành")
                resetFormHandle()
            Else
                MessageBox.Show("Lỗi")
                resetFormHandle()
            End If

        End If

    End Sub

    Private Sub DGVWorkingTime_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVWorkingTime.DataBindingComplete
        If DGVWorkingTime.SelectedRows.Count > 0 Then
            DGVWorkingTime.SelectedRows(0).Selected = False
        End If
    End Sub

    Private Sub resetFormHandle()
        ComboBoxEmployee.SelectedIndex = -1
        'txtEndTime.Text = ""
        'txtStartTime.Text = ""
        ComboBoxDateOfWeek2.SelectedIndex = -1
        ComboBoxWorkingTime2.SelectedIndex = -1
        loadWorkingTime()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        resetFormHandle()
    End Sub
End Class
