Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql


Public Class UCWorkingTimeMaster

    Private MstrConnection As String
    Private MstrOwnerId As String


    Public Sub UCWorkingTimeMaster_Load()

        MstrConnection = InforConnection.MstrConnection
        MstrOwnerId = InforConnection.MstrOwnerId

        InterfaceCustomize()
        loadWorkingTimeMaster()
        loadDataInComboboxDateOfWeek()
        loadDataInComboboxWorkingTime()
        loadComboboxSalary()
        loadSalary()
    End Sub

    Public Function InterfaceCustomize()
        DGVWorkingTime_Master.AutoGenerateColumns = False
        DGVWorkingTime_Master.RowHeadersVisible = False
        DGVWorkingTime_Master.AllowUserToAddRows = False
        DGVWorkingTime_Master.EnableHeadersVisualStyles = False

        DGVSalary.AutoGenerateColumns = False
        DGVSalary.RowHeadersVisible = False
        DGVSalary.AllowUserToAddRows = False
        DGVSalary.EnableHeadersVisualStyles = False
    End Function

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

    Public Sub loadComboboxSalary()
        Dim Sql As String
        Dim Dt As New DataTable
        Try
            ' Thao tác với database
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""salary"""
                    Sql &= " where ""salary"".""ownerId"" = " & MstrOwnerId

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then

                        ' Sử dụng cột mới trong DisplayMember
                        ComboBoxSalary.DataSource = Dt
                        ComboBoxSalary.DisplayMember = "salary"
                        ComboBoxSalary.ValueMember = "salaryId"
                        ComboBoxSalary.SelectedIndex = -1

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


    Private Sub loadWorkingTimeMaster()

        Dim Sql As String
        Dim Dt As New DataTable
        Dim whereDateOfWeek As String
        Dim whereIdWorkingTime As String

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)


                    If ComboBoxDateOfWeek.SelectedIndex <> -1 Then
                        adp.SelectCommand.Parameters.Add("DateOfWeek", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("DateOfWeek").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("DateOfWeek").Value = ComboBoxDateOfWeek.SelectedValue.ToString
                        whereDateOfWeek = " AND ""working_time_master"".""dateOfWeek"" = :DateOfWeek"
                    End If

                    If ComboBoxWorkingTime.SelectedIndex <> -1 Then
                        adp.SelectCommand.Parameters.Add("IdWorkingTime", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("IdWorkingTime").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("IdWorkingTime").Value = ComboBoxWorkingTime.SelectedValue
                        whereIdWorkingTime = " AND ""working_time_master"".""idWorkingTime"" = :IdWorkingTime"
                    End If


                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""working_time_master"""
                    Sql &= " LEFT JOIN PUBLIC.""salary"""
                    Sql &= " ON ""working_time_master"".""salaryId"" = ""salary"".""salaryId"""
                    Sql &= " where ""working_time_master"".""ownerId"" = " & MstrOwnerId & " AND ""salary"".""ownerId"" = " & MstrOwnerId
                    Sql &= whereDateOfWeek & whereIdWorkingTime
                    Sql &= " ORDER BY ""working_time_master"".""dateOfWeek"" ASC , ""working_time_master"".""idWorkingTime"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVWorkingTime_Master.DataSource = SetData(Dt)
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVWorkingTime_Master.DataSource = SetData(Dt)
                        MessageBox.Show("Không tìm thấy dữ liệu của wokringTimeMaster")
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("wokringTimeMaster" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub loadSalary()

        Dim Sql As String
        Dim Dt As New DataTable

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)


                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""salary"""
                    Sql &= " where ""salary"".""ownerId"" = " & MstrOwnerId

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVSalary.DataSource = Dt
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVSalary.DataSource = Dt
                        MessageBox.Show("Không tìm thấy dữ liệu của salary")
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadSalary" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

        loadComboboxSalary()

    End Sub

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

    Private Function formatTime(timeString)
        Dim time As DateTime = DateTime.ParseExact(timeString, "HHmm", Nothing)
        Dim formattedTime As String = time.ToString("HH:mm")
        Return formattedTime
    End Function


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

            DataResult.Rows.Add(newRow)
        Next
        Return DataResult
    End Function


    Private Function updateWorkingTimeMaster()
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereIdWorkingTime As String = ""
        Dim WhereDateOfWeek As String = ""

        sql &= "UPDATE"
        sql &= " PUBLIC.""working_time_master"""
        sql &= " SET"
        sql &= " ""startTime"" = :START_TIME"
        sql &= " , ""endTime"" = :END_TIME"
        sql &= " , ""dateOfWeek"" = :DATE_OF_WEEK"
        sql &= " , ""salaryId"" = :SALARY_ID"
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("IdWorkingTime", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("IdWorkingTime").Direction = ParameterDirection.Input
                    .Parameters("IdWorkingTime").Value = txtIdWorkingTime.Text 'ComboBoxWorkingTime2.SelectedValue.ToString.PadLeft(6, "0")
                    WhereIdWorkingTime = " AND ""idWorkingTime"" = :IdWorkingTime"


                    .Parameters.Add("DateOfWeek", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("DateOfWeek").Direction = ParameterDirection.Input
                    .Parameters("DateOfWeek").Value = txtDateOfWeek.Text ' ComboBoxDateOfWeek2.SelectedValue.ToString
                    WhereDateOfWeek = " AND ""dateOfWeek"" = :DATE_OF_WEEK"



                    sql &= WhereIdWorkingTime & WhereDateOfWeek
                    sql &= " ;"

                    .CommandText = sql

                    .Parameters.Add("START_TIME", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("END_TIME", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("DATE_OF_WEEK", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("SALARY_ID", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("START_TIME").Value = txtStartTime.Text
                    .Parameters.Item("END_TIME").Value = txtEndTime.Text
                    .Parameters.Item("DATE_OF_WEEK").Value = lblDateOfWeek.Text
                    .Parameters.Item("SALARY_ID").Value = ComboBoxSalary.SelectedValue.ToString

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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        loadWorkingTimeMaster()
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        ComboBoxDateOfWeek.SelectedIndex = -1
        ComboBoxWorkingTime.SelectedIndex = -1
        loadWorkingTimeMaster()
    End Sub

    Private Sub DGVWorkingTime_Master_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVWorkingTime_Master.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If e.RowIndex >= 0 Then
            ' Kiểm tra tên cột để phân biệt giữa hai cột button
            Dim selectedRow As DataGridViewRow = senderGrid.Rows(e.RowIndex)
            Dim columnName As String = senderGrid.Columns(e.ColumnIndex).Name

            If columnName = "edit" Then

                'formAddOrUpdate.productId = selectedRow.Cells("productId").Value
                txtIdWorkingTime.Text = selectedRow.Cells("idWorkingTime").Value
                txtStartTime.Text = selectedRow.Cells("startTime").Value
                txtEndTime.Text = selectedRow.Cells("endTime").Value
                ComboBoxSalary.SelectedValue = selectedRow.Cells("salaryId").Value
                txtDateOfWeek.Text = selectedRow.Cells("dateOfWeek_show").Value
                lblDateOfWeek.Text = selectedRow.Cells("dateOfWeek").Value


            ElseIf columnName = "delete" Then
                '' Thực hiện xóa
                'Dim idWorkingTime As Object = selectedRow.Cells("idWorkingTime").Value
                'Dim dateOfWeek As Object = selectedRow.Cells("dateOfWeek").Value
                'Dim employeeId As Object = selectedRow.Cells("employeeId").Value
                'If idWorkingTime IsNot Nothing And dateOfWeek IsNot Nothing And employeeId IsNot Nothing Then
                '    Dim result = deleteWorkingTime(idWorkingTime, dateOfWeek, employeeId)
                '    If result = True Then
                '        MessageBox.Show("Xóa thành công")
                '        loadWorkingTime()
                '    Else
                '        MessageBox.Show("Xóa lỗi")
                '        loadWorkingTime()
                '    End If
                'Else
                '    MessageBox.Show("Giá trị id không tồn tại.")
                'End If
            End If
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If String.IsNullOrWhiteSpace(txtIdWorkingTime.Text) OrElse String.IsNullOrWhiteSpace(txtDateOfWeek.Text) OrElse String.IsNullOrWhiteSpace(txtStartTime.Text) OrElse String.IsNullOrWhiteSpace(txtEndTime.Text) OrElse ComboBoxSalary.SelectedIndex = -1 Then
            MessageBox.Show("Bạn chưa nhập đủ dữ liệu !")
        Else

            Dim result As Boolean = updateWorkingTimeMaster()
            If result = True Then
                MessageBox.Show("Hoàn thành")
                loadWorkingTimeMaster()
            Else
                MessageBox.Show("Lỗi")
                loadWorkingTimeMaster()
            End If

        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtIdWorkingTime.Text = ""
        txtStartTime.Text = ""
        txtEndTime.Text = ""
        ComboBoxSalary.SelectedIndex = -1
        txtDateOfWeek.Text = ""
        lblDateOfWeek.Text = ""
        loadWorkingTimeMaster()
    End Sub

    Private Function deletSalary(salaryId) As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereSalaryId As String = ""

        sql &= "DELETE FROM "
        sql &= " PUBLIC.""salary"""
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("SalaryId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("SalaryId").Direction = ParameterDirection.Input
                    .Parameters("SalaryId").Value = salaryId.PadLeft(6, "0")
                    WhereSalaryId = " AND ""salaryId"" = :SalaryId"

                    sql &= WhereSalaryId
                    sql &= " ;"

                    .CommandText = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "salary delete lỗi - hãy liên hệ với người quản trị của bạn")
            Return False
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Sub DGVSalary_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVSalary.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If e.RowIndex >= 0 Then
            ' Kiểm tra tên cột để phân biệt giữa hai cột button
            Dim selectedRow As DataGridViewRow = senderGrid.Rows(e.RowIndex)
            Dim columnName As String = senderGrid.Columns(e.ColumnIndex).Name
            If columnName = "delete2" Then
                Dim confirmResult As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?",
                              "Xác nhận xóa",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question)
                If confirmResult = DialogResult.Yes Then
                    Dim salaryId As Object = selectedRow.Cells("salaryId2").Value
                    If salaryId IsNot Nothing Then
                        Dim result = deletSalary(salaryId)
                        If result = True Then
                            MessageBox.Show("Xóa thành công")
                            loadSalary()
                            loadComboboxSalary()
                        Else
                            MessageBox.Show("Xóa lỗi")
                            loadSalary()
                            loadComboboxSalary()
                        End If
                    Else
                        MessageBox.Show("Giá trị id không tồn tại.")
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub btnReloadSalary_Click(sender As Object, e As EventArgs) Handles btnReloadSalary.Click
        loadComboboxSalary()
        loadSalary()
    End Sub

    Private Sub btnNewSalary_Click(sender As Object, e As EventArgs) Handles btnNewSalary.Click
        Dim addSalary As New FormAddSalary(Me)

        Me.Cursor = Cursors.WaitCursor
        addSalary.ShowDialog()

        Me.Cursor = Cursors.Default
    End Sub
End Class
