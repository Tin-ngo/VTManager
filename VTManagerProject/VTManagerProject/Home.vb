Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql
Imports System.Globalization
Imports System.Reflection.Metadata

'print

Imports System.IO
Imports iText.Kernel.Pdf
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports iTextSharp.tool.xml
Imports Document = iTextSharp.text.Document
Imports PdfWriter = iTextSharp.text.pdf.PdfWriter
Imports iTextSharp.tool.xml.css
Imports iText.Forms

'cài thư viện để in pdf Install-Package itext7

Public Class Home
    Private MstrConnection As String
    Private MstrOwnerId As String

    Private datatableOrderBill As DataTable

    Private WithEvents dataCheckTimer As New Timer()
    Dim folderPath As String

    Public Sub Home_Load()
        MstrConnection = InforConnection.MstrConnection
        MstrOwnerId = InforConnection.MstrOwnerId
        folderPath = InforConnection.folderPath

        ' Đặt khoảng thời gian giữa các lần kiểm tra (ví dụ: 5 giây)
        dataCheckTimer.Interval = 5000
        ' Khi Timer đến thời gian, sẽ kích hoạt sự kiện Tick
        AddHandler dataCheckTimer.Tick, AddressOf DataCheckTimer_Tick
        ' Bắt đầu Timer
        dataCheckTimer.Start()

        InterfaceCustomize()
        loadTableStatus()
        loadEmployeetatus()
        loadBill()
        loadProblems()
    End Sub

    Private Sub DataCheckTimer_Tick(sender As Object, e As EventArgs)
        loadTableStatus()
        loadProblems()
    End Sub

    Public Function InterfaceCustomize()
        DGVTableStatus.AutoGenerateColumns = False
        DGVTableStatus.RowHeadersVisible = False
        DGVTableStatus.AllowUserToAddRows = False
        DGVTableStatus.EnableHeadersVisualStyles = False

        DGVOrderStatus.AutoGenerateColumns = False
        DGVOrderStatus.RowHeadersVisible = False
        DGVOrderStatus.AllowUserToAddRows = False
        DGVOrderStatus.EnableHeadersVisualStyles = False

        DGVEmployeeStatus.AutoGenerateColumns = False
        DGVEmployeeStatus.RowHeadersVisible = False
        DGVEmployeeStatus.AllowUserToAddRows = False
        DGVEmployeeStatus.EnableHeadersVisualStyles = False

        DGVProblem.AutoGenerateColumns = False
        DGVProblem.RowHeadersVisible = False
        DGVProblem.AllowUserToAddRows = False
        DGVProblem.EnableHeadersVisualStyles = False

        DGVBill.AutoGenerateColumns = False
        DGVBill.RowHeadersVisible = False
        DGVBill.AllowUserToAddRows = False
        DGVBill.EnableHeadersVisualStyles = False

        lblCurrent.Text = (DateTime.Now).ToString("dd-MM-yyyy")  'lấy ngày tháng năm
        lblCurrentNum.Text = CInt((DateTime.Now).DayOfWeek)
        'lblCurrent.Text = (DateTime.Now).DayOfWeek.ToString   'lấy thứ dạng text (Sunday, ...)
        'lblCurrent.Text = CInt((DateTime.Now).DayOfWeek)  'lấy thứ dạng số 0 -> 6

        'If DateTimePickerSearchBill.MinDate > DateTime.MinValue Then
        '    DateTimePickerSearchBill.Value = DateTimePickerSearchBill.MinDate
        'Else
        '    DateTimePickerSearchBill.Value = DateTime.MinValue.AddDays(1) ' Hoặc một giá trị khác nằm trong khoảng hợp lệ
        'End If

    End Function

    Public Sub loadTableStatus()

        Dim Sql As String
        Dim Dt As New DataTable

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""table"""
                    Sql &= " LEFT JOIN PUBLIC.""area"""
                    Sql &= " ON ""table"".""areaId"" = ""area"".""areaId"""
                    Sql &= " where ""table"".""ownerId"" = " & MstrOwnerId & " AND ""area"".""ownerId"" = " & MstrOwnerId
                    Sql &= " ORDER BY ""table"".""areaId"" ASC , ""table"".""tableId"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVTableStatus.DataSource = SetData(Dt)
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVTableStatus.DataSource = SetData(Dt)
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadTables" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
    End Sub



    Public Sub loadBill()

        Dim Sql As String
        Dim Dt As New DataTable
        Dim whereDateOfPayment As String

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    If DateTimePickerSearchBill.Value <> DateTime.MinValue Then
                        adp.SelectCommand.Parameters.Add("DateOfPayment", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("DateOfPayment").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("DateOfPayment").Value = DateTimePickerSearchBill.Text.Replace("-", "")
                        whereDateOfPayment = " AND TO_DATE(""bill"".""dateOfPayment"", 'DDMMYYYY') = TO_DATE(:DateOfPayment, 'DDMMYYYY')"
                    End If

                    'Select *
                    'FROM "bill"
                    'Left Join
                    ' (SELECT MAX("orderId") AS "orderId",
                    '   MAX("ownerId") As "ownerId",
                    '   MAX("tableId") As "tableId",
                    '   MAX("areaId") As "areaId"
                    '  FROM "order"
                    '        GROUP BY "orderId") AS "order" ON "bill"."ownerId" = "order"."ownerId"
                    'INNER Join area ON "order"."ownerId" = "area"."ownerId" And "order"."areaId" = "area"."areaId"
                    'And "bill"."orderId" = "order"."orderId"

                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""bill"""
                    Sql &= " LEFT JOIN (SELECT MAX(""orderId"") AS ""orderId"", MAX(""ownerId"") As ""ownerId"", MAX(""tableId"") As ""tableId"", MAX(""areaId"") As ""areaId"" FROM ""order"" GROUP BY ""orderId"") AS ""order"" ON ""bill"".""ownerId"" = ""order"".""ownerId"" "
                    Sql &= " INNER Join area ON ""order"".""ownerId"" = ""area"".""ownerId"" And ""order"".""areaId"" = ""area"".""areaId"" And ""bill"".""orderId"" = ""order"".""orderId"" "
                    Sql &= " where ""bill"".""ownerId"" = " & MstrOwnerId & " AND ""order"".""ownerId"" = " & MstrOwnerId
                    Sql &= whereDateOfPayment
                    Sql &= " ORDER BY ""bill"".""dateOfPayment"" DESC , ""bill"".""timeOfPayment"" DESC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVBill.DataSource = setDataBill(Dt)
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVBill.DataSource = setDataBill(Dt)
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadTables" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub loadProblems()
        Dim Sql As String
        Dim Dt As New DataTable
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    ' Lệnh select SQL
                    Sql = "SELECT ""ownerId"", ""productId"", ""productName"", ""productStatus"" "
                    Sql &= "FROM ""product"""
                    Sql &= " where ""product"".""ownerId"" = " & MstrOwnerId & " AND ""product"".""productStatus"" = '1'"
                    Sql &= " ORDER BY ""product"".""productId"" DESC"

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        DGVProblem.DataSource = setDataProblem(Dt)
                    Else
                        DGVProblem.DataSource = setDataProblem(Dt)
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadTables" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function updateArea(ownerId, productId) As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereAreaId As String = ""

        sql &= "UPDATE"
        sql &= " PUBLIC.""product"""
        sql &= " SET"
        sql &= " ""productStatus"" = :PRODUCT_STATUS"
        sql &= " WHERE ""ownerId"" = '" & ownerId & "' AND ""productId"" = '" & productId & "' "

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb
                    sql &= " ;"

                    .CommandText = sql

                    .Parameters.Add("PRODUCT_STATUS", NpgsqlTypes.NpgsqlDbType.Integer)

                    .Parameters.Item("PRODUCT_STATUS").Value = 0

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "update product status")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Public Sub loadEmployeetatus()

        Dim Sql As String
        Dim Dt As New DataTable

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""working_time"""
                    Sql &= " LEFT JOIN PUBLIC.""working_time_master"""
                    Sql &= " ON ""working_time"".""idWorkingTime"" = ""working_time_master"".""idWorkingTime"""
                    Sql &= " AND ""working_time"".""dateOfWeek"" = ""working_time_master"".""dateOfWeek"""
                    Sql &= " AND ""working_time"".""ownerId"" = ""working_time_master"".""ownerId"""
                    Sql &= " LEFT JOIN PUBLIC.""employee"""
                    Sql &= " ON ""working_time"".""employeeId"" = ""employee"".""employeeId"""
                    Sql &= " where ""working_time"".""ownerId"" = " & MstrOwnerId & " AND ""employee"".""ownerId"" = " & MstrOwnerId & " AND ""working_time_master"".""ownerId"" = " & MstrOwnerId
                    Sql &= " AND ""working_time"".""dateOfWeek"" = " & "'" & lblCurrentNum.Text.ToString & "'"
                    Sql &= " ORDER BY ""working_time_master"".""startTime"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVEmployeeStatus.DataSource = setDataEmployeeStatus(Dt)
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVEmployeeStatus.DataSource = setDataEmployeeStatus(Dt)
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("load employee Status" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function SetData(data As DataTable) As DataTable
        Dim DataResult As New DataTable
        DataResult.Columns.Add("areaId", GetType(String))
        DataResult.Columns.Add("areaName", GetType(String))
        DataResult.Columns.Add("tableId", GetType(String))
        DataResult.Columns.Add("status", GetType(String))
        DataResult.Columns.Add("status_show", GetType(String))
        DataResult.Columns.Add("maxCapacity", GetType(String))

        For indexId As Integer = 0 To data.Rows.Count() - 1
            Dim newRow As DataRow = DataResult.NewRow()

            newRow("areaId") = data(indexId)("areaId")
            newRow("areaName") = data(indexId)("areaName")
            newRow("tableId") = data(indexId)("tableId")
            newRow("status") = data(indexId)("status")
            newRow("status_show") = setStatusText(data(indexId)("status"))
            newRow("maxCapacity") = data(indexId)("maxCapacity")

            DataResult.Rows.Add(newRow)
        Next
        Return DataResult
    End Function

    Private Function setDataProblem(data As DataTable) As DataTable
        Dim DataResult As New DataTable
        DataResult.Columns.Add("problemProductName", GetType(String))
        DataResult.Columns.Add("problemProductId", GetType(String))
        DataResult.Columns.Add("problemOwnerId", GetType(String))

        For indexId As Integer = 0 To data.Rows.Count() - 1
            Dim newRow As DataRow = DataResult.NewRow()

            newRow("problemProductName") = data(indexId)("productName")
            newRow("problemProductId") = data(indexId)("productId")
            newRow("problemOwnerId") = data(indexId)("ownerId")

            DataResult.Rows.Add(newRow)
        Next
        Return DataResult
    End Function

    Private Function setDataBill(data As DataTable) As DataTable
        Dim DataResult As New DataTable
        DataResult.Columns.Add("orderId", GetType(String))
        DataResult.Columns.Add("dateOfPayment", GetType(String))
        DataResult.Columns.Add("timeOfPayment", GetType(String))
        DataResult.Columns.Add("paymentType", GetType(String))
        DataResult.Columns.Add("totalPayment", GetType(String))
        DataResult.Columns.Add("billId", GetType(String))
        DataResult.Columns.Add("billAreaName", GetType(String))
        DataResult.Columns.Add("billTableId", GetType(String))

        For indexId As Integer = 0 To data.Rows.Count() - 1
            Dim newRow As DataRow = DataResult.NewRow()

            newRow("billId") = data(indexId)("billId")
            newRow("orderId") = data(indexId)("orderId")
            newRow("billAreaName") = data(indexId)("areaName")
            newRow("billTableId") = data(indexId)("tableId")

            newRow("dateOfPayment") =
            If(Not String.IsNullOrEmpty(data(indexId)("dateOfPayment").ToString()),
          DateTime.ParseExact(data(indexId)("dateOfPayment").ToString(), "ddMMyyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"), "")

            newRow("timeOfPayment") = formatTime(data(indexId)("timeOfPayment"))
            newRow("paymentType") = setTextPaymentType(data(indexId)("paymentType"))
            newRow("totalPayment") = CInt(data(indexId)("totalPayment")).ToString("N0")

            DataResult.Rows.Add(newRow)
        Next
        Return DataResult
    End Function

    Private Function setDataEmployeeStatus(data As DataTable) As DataTable
        Dim DataResult As New DataTable
        DataResult.Columns.Add("dateOfWeek", GetType(String))
        DataResult.Columns.Add("dateOfWeek_show", GetType(String))
        DataResult.Columns.Add("startTime", GetType(String))
        DataResult.Columns.Add("endTime", GetType(String))
        DataResult.Columns.Add("employeeName", GetType(String))
        DataResult.Columns.Add("statusWork", GetType(String))

        For indexId As Integer = 0 To data.Rows.Count() - 1
            Dim newRow As DataRow = DataResult.NewRow()

            newRow("dateOfWeek") = data(indexId)("dateOfWeek")
            newRow("dateOfWeek_show") = setTextDateOfWeek(data(indexId)("dateOfWeek"))
            newRow("startTime") = formatTime(data(indexId)("startTime"))
            newRow("endTime") = formatTime(data(indexId)("endTime"))
            newRow("employeeName") = data(indexId)("employeeName")
            newRow("statusWork") = "Hoạt động"

            DataResult.Rows.Add(newRow)
        Next
        Return DataResult
    End Function


    Private Function SetDataOrder(data As DataTable) As DataTable
        Dim DataResult As New DataTable
        DataResult.Columns.Add("productName", GetType(String))
        DataResult.Columns.Add("quantity", GetType(String))
        DataResult.Columns.Add("unitPrice", GetType(String))
        DataResult.Columns.Add("dateOrder", GetType(String))
        DataResult.Columns.Add("timeOrder", GetType(String))
        DataResult.Columns.Add("statusOrder", GetType(String))

        For indexId As Integer = 0 To data.Rows.Count() - 1
            Dim newRow As DataRow = DataResult.NewRow()

            newRow("productName") = data(indexId)("productName")
            newRow("quantity") = data(indexId)("quantity")
            newRow("unitPrice") = data(indexId)("unitPrice")
            newRow("dateOrder") =
            If(Not String.IsNullOrEmpty(data(indexId)("dateOrder").ToString()),
                      DateTime.ParseExact(data(indexId)("dateOrder").ToString(), "ddMMyyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"), "")
            newRow("timeOrder") = formatTime(data(indexId)("timeOrder"))
            newRow("statusOrder") = setTextStatusOrder(data(indexId)("status"))

            DataResult.Rows.Add(newRow)
        Next
        Return DataResult
    End Function
    Private Function setTextStatusOrder(number)
        If number = 0 Then
            Return "Đã đặt"
        ElseIf number = 1 Then
            Return "Đã nấu"
        ElseIf number = 2 Then
            Return "Đã phục vụ"
        End If
    End Function

    Private Function setTextPaymentType(number)
        If number = 0 Then
            Return "Tien mat"
        ElseIf number = 1 Then
            Return "Chuyen khoan"
        End If
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

    Private Function formatTime(timeString)
        timeString = timeString.Substring(0, 4)
        Dim time As DateTime = DateTime.ParseExact(timeString, "HHmm", Nothing)
        Dim formattedTime As String = time.ToString("HH:mm")
        Return formattedTime
    End Function

    Private Function setStatusText(status)
        If status = 0 Then
            Return "Trống"
        Else
            Return "Bận"
        End If
    End Function

    Public Sub loadOrdertatus(tableId, areaId)

        Dim Sql As String
        Dim Dt As New DataTable

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""order"""
                    Sql &= " LEFT JOIN PUBLIC.""product"""
                    Sql &= " ON ""order"".""productId"" = ""product"".""productId"""
                    Sql &= " AND ""order"".""ownerId"" = ""product"".""ownerId"""
                    Sql &= " where ""order"".""tableId"" = " & "'" & tableId & "'"
                    Sql &= " AND ""order"".""ownerId"" = " & MstrOwnerId & " AND ""product"".""ownerId"" = " & MstrOwnerId
                    Sql &= " AND ""order"".""isPaid"" = '0' AND ""order"".""tableId"" = " & "'" & tableId & "'" & "AND ""order"".""areaId"" = " & "'" & areaId & "'"
                    Sql &= " ORDER BY ""order"".""dateOrder"" ASC , ""order"".""timeOrder"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVOrderStatus.DataSource = SetDataOrder(Dt)
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVOrderStatus.DataSource = SetDataOrder(Dt)
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadTables" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
    End Sub


    Public Function loadOrderBill(orderId) As DataTable

        Dim Sql As String
        Dim Dt As New DataTable

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT "
                    Sql &= " ""product"".""productName"", ""order"".""quantity"", ""product"".""unitPrice"", ""MST_vat"".""vatValue%"" "
                    Sql &= "FROM ""order"""
                    Sql &= " LEFT JOIN PUBLIC.""product"""
                    Sql &= " ON ""order"".""productId"" = ""product"".""productId"""
                    Sql &= " AND ""order"".""ownerId"" = ""product"".""ownerId"""
                    Sql &= " LEFT JOIN PUBLIC.""MST_vat"""
                    Sql &= " ON ""product"".""vatId"" = ""MST_vat"".""vatId"""
                    Sql &= " where ""order"".""ownerId"" = " & MstrOwnerId
                    Sql &= " AND ""order"".""orderId"" = " & "'" & orderId & "'"
                    Sql &= " ORDER BY ""order"".""dateOrder"" ASC , ""order"".""timeOrder"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadTables" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

        Return Dt
    End Function

    Private Sub DGVTableStatus_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVTableStatus.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = senderGrid.Rows(e.RowIndex)
            Dim columnName As String = senderGrid.Columns(e.ColumnIndex).Name

            If columnName = "details" Then

                loadOrdertatus(selectedRow.Cells("tableId").Value.ToString.PadLeft(6, "0"), selectedRow.Cells("areaId").Value.ToString.PadLeft(6, "0"))

            End If
        End If
    End Sub

    Private Sub btnReloadTableStatus_Click(sender As Object, e As EventArgs) Handles btnReloadTableStatus.Click
        loadTableStatus()
    End Sub

    Private Sub btnReloadEmployeeStatus_Click(sender As Object, e As EventArgs) Handles btnReloadEmployeeStatus.Click
        loadEmployeetatus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearchBill.Click
        loadBill()
    End Sub

    Private Sub btnClearBill_Click(sender As Object, e As EventArgs) Handles btnClearBill.Click
        'If DateTimePickerSearchBill.MinDate > DateTime.MinValue Then
        '    DateTimePickerSearchBill.Value = DateTimePickerSearchBill.MinDate
        'Else
        '    DateTimePickerSearchBill.Value = DateTime.MinValue.AddDays(1) ' Hoặc một giá trị khác nằm trong khoảng hợp lệ
        'End If
        DateTimePickerSearchBill.Value = DateTime.Now
        loadBill()
    End Sub

    Private Sub DGVBill_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVBill.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If e.RowIndex >= 0 Then
            ' Kiểm tra tên cột để phân biệt giữa hai cột button
            Dim selectedRow As DataGridViewRow = senderGrid.Rows(e.RowIndex)
            Dim columnName As String = senderGrid.Columns(e.ColumnIndex).Name

            If columnName = "printBill" Then

                Dim orderId = selectedRow.Cells("orderId").Value.ToString.PadLeft(6, "0")
                Dim dateOfPayment = selectedRow.Cells("dateOfPayment").Value
                Dim timeOfPayment = selectedRow.Cells("timeOfPayment").Value
                Dim paymentType = selectedRow.Cells("paymentType").Value
                Dim totalPayment = selectedRow.Cells("totalPayment").Value
                Dim billId = selectedRow.Cells("billId").Value
                Dim billAreaName = selectedRow.Cells("billAreaName").Value
                Dim billTableId = selectedRow.Cells("billTableId").Value
                datatableOrderBill = loadOrderBill(orderId)
                PrintBillAction(orderId, dateOfPayment, timeOfPayment, paymentType, totalPayment, billId, billAreaName, billTableId)
                'lblEmployeeId_Old.Text = selectedRow.Cells("employeeId").Value
                'lblDateOfWeek_Old.Text = selectedRow.Cells("dateOfWeek").Value
                'lblWorkingTime_Old.Text = selectedRow.Cells("idWorkingTime").Value
                'ComboBoxEmployee.SelectedValue = selectedRow.Cells("employeeId").Value
                'ComboBoxDateOfWeek2.SelectedValue = selectedRow.Cells("dateOfWeek").Value
                'ComboBoxWorkingTime2.SelectedValue = selectedRow.Cells("idWorkingTime").Value
            End If
        End If

    End Sub


    Private Sub PrintBillAction(orderId, dateOfPayment, timeOfPayment, paymentType, totalPayment, billId, billAreaName, billTableId)

        Dim html As String = " <div style='border: 1px solid #ccc; padding: 20px; max-width: 80%; margin: 0 auto; font-family: Times New Roman, Times, serif; color: #71E3F9; font-size: 30px !important;'> "
        html &= " <div style='text-align: center;'> "
        html &= " <h2 style='margin: 0; color: red; margin-bottom: 0px; padding-bottom: 0px;'>Hóa Đơn</h2> "
        html &= " <h3 style=' margin-bottom: 0px; margin-top: 8px; padding-bottom: 0px;' > " & InforConnection.shopName & "</h3> "
        html &= " <h5 style=' margin-top: 0px; margin-bottom: 8px; padding-bottom: 0px;'>" & InforConnection.shopAddress & "</h5> "
        html &= "  </div> "

        html &= " <div style='margin-top: 0px;'> "
        html &= " <p style='margin: 0;'><strong><span style='display: inline-block; width: 400px !important;'>Số hóa đơn:</span> " & billId.ToString().PadLeft(6, "0") & "</strong></p>"
        html &= " <p style='margin: 0;'><strong>Khu vực:" & billAreaName & "</strong></p> "
        html &= " <p style='margin: 0;'><strong>Số bàn:" & billTableId & "</strong></p> "
        html &= " <p style='margin: 0;'><strong>Thời gian:" & dateOfPayment & " - " & timeOfPayment & "</strong></p> "
        html &= " <p style='margin: 0;'><strong>Hình thức:" & paymentType & "</strong></p> "
        html &= " </div> "

        html &= " <table style='width: 100%; border-collapse: collapse; margin-top: 20px; font-size: 30px !important'> "
        html &= " <thead> "
        html &= "  <tr> "
        html &= " <th style='width: 5% !important; border: 1px solid #ddd; padding: 10px; text-align: left; font-family: Times New Roman, Times, serif;'>STT</th> "
        html &= " <th style='width: 20% !important; border: 1px solid #ddd; padding: 10px; text-align: left; font-family: Times New Roman, Times, serif;'>Món ăn</th> "
        html &= " <th style='width: 4% !important; border: 1px solid #ddd; padding: 10px; text-align: left; font-family: Times New Roman, Times, serif;'>SL</th> "
        html &= " <th style='width: 12% !important; border: 1px solid #ddd; padding: 10px; text-align: left; font-family: Times New Roman, Times, serif;'>Đơn giá</th> "
        html &= " <th style='width: 12% !important; border: 1px solid #ddd; padding: 10px; text-align: left; font-family: Times New Roman, Times, serif;'>Tổng</th> "
        html &= " <th style='width: 12% !important; border: 1px solid #ddd; padding: 10px; text-align: left; font-family: Times New Roman, Times, serif;'>VAT</th> "
        html &= " <th style='width: 12% !important; border: 1px solid #ddd; padding: 10px; text-align: left; font-family: Times New Roman, Times, serif;'>Tổng thuế</th> "
        html &= " <th style='width: 12% !important; border: 1px solid #ddd; padding: 10px; text-align: left; font-family: Times New Roman, Times, serif;'>Thành tiền</th> "
        html &= " </tr> "
        html &= " </thead> "

        html &= " <tbody> "

        'thêm column total vào datatableOrderBill
        If Not datatableOrderBill.Columns.Contains("Total") Then
            datatableOrderBill.Columns.Add("Total", GetType(Double))
        End If

        If Not datatableOrderBill.Columns.Contains("TotalVAT") Then
            datatableOrderBill.Columns.Add("TotalVAT", GetType(Double))
        End If

        If Not datatableOrderBill.Columns.Contains("TotalPayment") Then
            datatableOrderBill.Columns.Add("TotalPayment", GetType(Double))
        End If

        Dim stt As Integer = 1
        Dim totalPreTaxMoney As Double = 0
        Dim totalTaxMoney As Double = 0
        Dim totalPaymentAmount As Double = 0
        For Each row As DataRow In datatableOrderBill.Rows
            ' Lấy giá trị từ hai cột để tính tổng
            Dim quantity As Double = Convert.ToDouble(row("quantity"))
            Dim unitPrice As Double = Convert.ToDouble(row("unitPrice"))
            Dim vatValue As Double = Convert.ToDouble(row("vatValue%"))
            row("Total") = quantity * unitPrice
            row("TotalVAT") = (row("Total") * vatValue) / 100
            row("TotalPayment") = row("Total") + row("TotalVAT")
            html &= "<tr>"

            totalPreTaxMoney += CInt(row("Total"))
            totalTaxMoney += CInt(row("TotalVAT"))
            totalPaymentAmount += CInt(row("TotalPayment"))

            html &= "<td style='border: 1px solid #ddd; padding: 10px; text-align: left;'>" & stt & "</td>"
            html &= "<td style='border: 1px solid #ddd; padding: 10px; text-align: left;'>" & row("productName") & "</td>"
            html &= "<td style='border: 1px solid #ddd; padding: 10px; text-align: left;'>" & row("quantity") & "</td>"
            html &= "<td style='border: 1px solid #ddd; padding: 10px; text-align: left;'>" & CInt(row("unitPrice")).ToString("N0") & "</td>"
            html &= "<td style='border: 1px solid #ddd; padding: 10px; text-align: left;'>" & CInt(row("Total")).ToString("N0") & "</td>"
            html &= "<td style='border: 1px solid #ddd; padding: 10px; text-align: left;'>" & CInt(row("vatValue%")).ToString("N0") & " %</td>"
            html &= "<td style='border: 1px solid #ddd; padding: 10px; text-align: left;'>" & CInt(row("TotalVAT")).ToString("N0") & "</td>"
            html &= "<td style='border: 1px solid #ddd; padding: 10px; text-align: left;'>" & CInt(row("TotalPayment")).ToString("N0") & "</td>"
            'For Each column As DataColumn In datatableOrderBill.Columns
            '    Dim cellValue As String = RemoveDiacritics(row(column).ToString())
            '    html &= "<td style='border: 1px solid #ddd; padding: 10px; text-align: left;'>" & cellValue & "</td>"
            'Next

            html &= "</tr>"
            stt += 1
        Next


        html &= " <tr> "
        html &= " <td style='border: 1px solid #ddd; padding: 10px; text-align: left;' colspan='8'> "
        html &= " <div style='float: Right; padding: 6px 0'> "
        html &= " <span style='display: inline-block; text-align: Right;'> "
        html &= "  Tổng tiền trước thuế: "
        html &= " </span> "
        html &= " <span style='display: inline-block; width:  100px; text-align: Right;'> "
        html &= totalPreTaxMoney.ToString("N0")
        html &= " VND </span> "
        html &= "  </div> "
        html &= " </td> "
        html &= " </tr> "
        html &= " <tr> "
        html &= " <td style='border: 1px solid #ddd; padding: 10px; text-align: left;' colspan='8'> "
        html &= " <div style='float: Right; padding: 6px 0''> "
        html &= " <span style='display: inline-block; text-align: Right;'> "
        html &= " Tổng tiền thuế: "
        html &= " </span> "
        html &= " <span style='display: inline-block; width:  100px; text-align: Right;'> "
        html &= totalTaxMoney.ToString("N0")
        html &= " VND </span> "
        html &= " </div> "
        html &= " </td> "
        html &= "  </tr> "
        html &= " <tr> "
        html &= " <td style='border: 1px solid #ddd; padding: 10px; text-align: left;' colspan='8'> "
        html &= " <div style='float: Right; padding: 6px 0''> "
        html &= " <span style='display: inline-block; text-align: Right;'> "
        html &= " Tổng thanh toán: "
        html &= " </span> "
        html &= " <span style='display: inline-block; width:  100px; text-align: Right;'> "
        html &= totalPaymentAmount.ToString("N0")
        html &= " VND </span> "
        html &= " </div> "
        html &= " </td> "
        html &= " </tr> "
        html &= " </tbody> "
        html &= "  </table> "
        html &= " </div> "


        'Dim html As String = " <strong style='font-family: Times New Roman, Times, serif;'> Hệ thống bửu bão </strong>"

        'Creating Folder for saving PDF.
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        'Exporting HTML to PDF file.
        Using stream As FileStream = New FileStream(folderPath & "Invoice_" & orderId.ToString.PadLeft(6, "0") & ".pdf", FileMode.Create)
            Dim pdfDoc As Document = New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            ' Đăng ký encoding 'windows-1252'
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
            Dim windows1252Encoding As Encoding = Encoding.GetEncoding(1252)
            Dim baseFont As BaseFont = BaseFont.CreateFont("C:\Users\ngoph\AppData\Local\Microsoft\Windows\Fonts\vuArial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
            Dim customFont As New Font(baseFont)

            ' Áp dụng font và màu sắc cho đối tượng Paragraph
            Dim para As New Paragraph()
            para.Font = customFont

            ' Tạo đối tượng StringReader từ HTML
            Dim sr As StringReader = New StringReader(html)

            ' Tạo MemoryStream từ StringReader
            Dim ms As New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(ms)
            sw.Write(sr.ReadToEnd())
            sw.Flush()
            ms.Position = 0


            ' Sử dụng XMLWorkerHelper để chuyển đổi HTML thành PDF với font được áp dụng
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, ms, Nothing, Encoding.UTF8, New XMLWorkerFontProvider())

            ' Thêm Paragraph vào tài liệu PDF
            pdfDoc.Add(para)

            pdfDoc.Close()
            stream.Close()
        End Using
    End Sub


    ' Hàm chuyển đổi ký tự có dấu sang ký tự không dấu
    Function RemoveDiacritics(input As String) As String
        Dim normalizedString As String = input.Normalize(NormalizationForm.FormD)
        Dim stringBuilder As New StringBuilder()

        For Each c As Char In normalizedString
            Dim unicodeCategory As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c)
            If unicodeCategory <> UnicodeCategory.NonSpacingMark Then
                stringBuilder.Append(c)
            End If
        Next

        Return stringBuilder.ToString().Normalize(NormalizationForm.FormC)


    End Function

    Private Sub DGVTableStatus_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVTableStatus.DataBindingComplete
        If DGVTableStatus.SelectedRows.Count > 0 Then
            DGVTableStatus.SelectedRows(0).Selected = False
        End If
    End Sub

    Private Sub DGVOrderStatus_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVOrderStatus.DataBindingComplete
        If DGVOrderStatus.SelectedRows.Count > 0 Then
            DGVOrderStatus.SelectedRows(0).Selected = False
        End If
    End Sub

    Private Sub DGVEmployeeStatus_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVEmployeeStatus.DataBindingComplete
        If DGVEmployeeStatus.SelectedRows.Count > 0 Then
            DGVEmployeeStatus.SelectedRows(0).Selected = False
        End If
    End Sub

    Private Sub DGVBill_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVBill.DataBindingComplete
        If DGVBill.SelectedRows.Count > 0 Then
            DGVBill.SelectedRows(0).Selected = False
        End If
    End Sub

    Private Sub DGVProblem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVProblem.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = senderGrid.Rows(e.RowIndex)
            Dim columnName As String = senderGrid.Columns(e.ColumnIndex).Name
            If columnName = "btnConfirm" Then
                Dim ownerId = selectedRow.Cells("problemOwnerId").Value.ToString.PadLeft(6, "0")
                Dim productId = selectedRow.Cells("problemProductId").Value
                Dim result As DialogResult = MessageBox.Show("Bạn xác nhận đã mua đủ nguyên liệu để món ăn có thể được phục vụ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    updateArea(ownerId, productId)
                    loadProblems()
                End If
            End If
        End If
    End Sub

End Class
