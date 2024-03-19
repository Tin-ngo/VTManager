Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class UCStatistic
    Private MstrConnection As String
    Private MstrOwnerId As String

    Public Sub UCStatistic_Load()
        MstrConnection = InforConnection.MstrConnection
        MstrOwnerId = InforConnection.MstrOwnerId

        InterfaceCustomize()
        loadStatistics()

        LblDate.Text = loadDataDate()
        LblMonth.Text = loadDataMonth()
        LblYear.Text = loadDataMonth(2)
    End Sub

    Public Function InterfaceCustomize()
        DGVStatisficProduct.AutoGenerateColumns = False
        DGVStatisficProduct.RowHeadersVisible = False
        DGVStatisficProduct.AllowUserToAddRows = False
        DGVStatisficProduct.EnableHeadersVisualStyles = False

        Dim currentYear As Integer = DateTime.Now.Year
        Dim startYear As Integer = 2000
        For year As Integer = currentYear To startYear Step -1
            ComboBoxYear_month.Items.Add(year.ToString())
            ComboBoxYear.Items.Add(year.ToString())
        Next
        ComboBoxYear_month.SelectedItem = currentYear.ToString()
        ComboBoxYear.SelectedItem = currentYear.ToString()

        For month As Integer = 1 To 12
            ComboBoxMonth.Items.Add(month.ToString("00"))
        Next
        ComboBoxMonth.SelectedIndex = DateTime.Now.Month - 1

    End Function

    ' load danh sách bàn
    Public Sub loadStatistics()
        Dim Sql As String
        Dim Dt As New DataTable

        Dim DateOrderFrom As String
        Dim DateOrderTo As String
        Dim OrderByDESC As String
        Dim OrderByASC As String
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    If DateTimePickerFrom.Value <> DateTime.MinValue Then
                        adp.SelectCommand.Parameters.Add("DateOrder", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("DateOrder").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("DateOrder").Value = DateTimePickerFrom.Text.Replace("-", "")
                        DateOrderFrom = " AND TO_DATE(""order"".""dateOrder"", 'DDMMYYYY') >= TO_DATE(:DateOrder, 'DDMMYYYY')"
                    End If

                    If DateTimePickerFrom.Value <> DateTime.MinValue Then
                        adp.SelectCommand.Parameters.Add("DateOrderTo", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("DateOrderTo").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("DateOrderTo").Value = DateTimePickerTo.Text.Replace("-", "")
                        DateOrderTo = " AND TO_DATE(""order"".""dateOrder"", 'DDMMYYYY') <= TO_DATE(:DateOrderTo, 'DDMMYYYY')"
                    End If

                    If RadioButtonDown.Checked Then
                        OrderByASC = " ORDER BY quantitySold DESC "
                    End If

                    If RadioButtonUp.Checked Then
                        OrderByDESC = " ORDER BY quantitySold ASC "
                    End If

                    ' Lệnh select SQL
                    Sql = "SELECT "
                    Sql &= """order"".""ownerId"", ""order"".""productId"", ""product"".""productName"", ""product"".""unitPrice"", COUNT(""order"".""dateOrder"") AS quantitySold "
                    Sql &= "FROM ""order"" "
                    Sql &= "LEFT JOIN PUBLIC.""product"" "
                    Sql &= "ON ""order"".""productId"" = ""product"".""productId"" "
                    Sql &= "WHERE ""order"".""ownerId"" = " & MstrOwnerId & DateOrderFrom & DateOrderTo
                    Sql &= "GROUP BY ""order"".""ownerId"", ""order"".""productId"", ""product"".""productName"", ""product"".""unitPrice"" "
                    Sql &= OrderByASC & OrderByDESC
                    'Sql &= " ORDER BY ""table"".""areaId"" ASC , ""table"".""tableId"" ASC"

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        DGVStatisficProduct.DataSource = SetData(Dt)
                    Else
                        DGVStatisficProduct.DataSource = SetData(Dt)
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadStatistics" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function SetData(data As DataTable) As DataTable
        Dim DataResult As New DataTable
        DataResult.Columns.Add("ownerId", GetType(String))
        DataResult.Columns.Add("productId", GetType(String))
        DataResult.Columns.Add("productName", GetType(String))
        DataResult.Columns.Add("unitPrice", GetType(String))
        DataResult.Columns.Add("quantitySold", GetType(String))
        DataResult.Columns.Add("total", GetType(String))

        For indexId As Integer = 0 To data.Rows.Count() - 1
            Dim newRow As DataRow = DataResult.NewRow()

            newRow("ownerId") = data(indexId)("ownerId")
            newRow("productId") = data(indexId)("productId")
            newRow("productName") = data(indexId)("productName")
            Dim unitPrice As Decimal = Convert.ToDecimal(data(indexId)("unitPrice"))
            newRow("unitPrice") = unitPrice.ToString("N0")
            newRow("quantitySold") = data(indexId)("quantitySold")
            Dim total As Decimal = CInt(data(indexId)("unitPrice")) * CInt(data(indexId)("quantitySold"))
            newRow("total") = total.ToString("N0")

            DataResult.Rows.Add(newRow)
        Next
        Return DataResult
    End Function

    Public Function loadDataDate() As String
        Dim Sql As String
        Dim Dt As New DataTable

        Dim DateOrderFrom As String
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    If DateTimePicker1.Value <> DateTime.MinValue Then
                        adp.SelectCommand.Parameters.Add("DateOrder", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("DateOrder").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("DateOrder").Value = DateTimePicker1.Text.Replace("-", "")
                        DateOrderFrom = " AND TO_DATE(""bill"".""dateOfPayment"", 'DDMMYYYY') = TO_DATE(:DateOrder, 'DDMMYYYY')"
                    End If

                    ' Lệnh select SQL
                    Sql = "SELECT *"
                    Sql &= "FROM ""bill"" "
                    Sql &= "WHERE ""bill"".""ownerId"" = " & MstrOwnerId & DateOrderFrom
                    'Select Case*
                    'FROM "bill"
                    'WHERE "bill"."ownerId" = '000001'
                    ' And TO_DATE("bill"."dateOfPayment",'DDMMYYYY') = TO_DATE('18112023', 'DDMMYYYY')

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        Dim sum As Decimal = 0
                        For Each row As DataRow In Dt.Rows
                            sum += Convert.ToDecimal(row("totalPayment"))
                        Next
                        Return sum.ToString("N0")
                    End If
                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadStatistics" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
        Return 0
    End Function


    Public Function loadDataMonth(Optional flag As Integer = 1) As String
        Dim Sql As String
        Dim Dt As New DataTable

        Dim MonthBill As String
        Dim YearBill As String
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    If flag = 1 Then
                        If ComboBoxMonth.SelectedIndex <> -1 Then
                            adp.SelectCommand.Parameters.Add("Month", NpgsqlTypes.NpgsqlDbType.Integer)
                            adp.SelectCommand.Parameters("Month").Direction = ParameterDirection.Input
                            adp.SelectCommand.Parameters("Month").Value = ComboBoxMonth.SelectedIndex + 1
                            MonthBill = " AND EXTRACT(MONTH FROM TO_DATE(""bill"".""dateOfPayment"", 'ddMMyyyy')) = :Month"
                        End If

                        If ComboBoxYear_month.SelectedIndex <> -1 Then
                            adp.SelectCommand.Parameters.Add("Year", NpgsqlTypes.NpgsqlDbType.Integer)
                            adp.SelectCommand.Parameters("Year").Direction = ParameterDirection.Input
                            adp.SelectCommand.Parameters("Year").Value = Convert.ToInt32(ComboBoxYear_month.Text)
                            YearBill = " AND EXTRACT(YEAR FROM TO_DATE(""bill"".""dateOfPayment"", 'ddMMyyyy')) = :Year"
                        End If
                    Else
                        If ComboBoxYear.SelectedIndex <> -1 Then
                            adp.SelectCommand.Parameters.Add("Year", NpgsqlTypes.NpgsqlDbType.Integer)
                            adp.SelectCommand.Parameters("Year").Direction = ParameterDirection.Input
                            adp.SelectCommand.Parameters("Year").Value = Convert.ToInt32(ComboBoxYear.Text)
                            YearBill = " AND EXTRACT(YEAR FROM TO_DATE(""bill"".""dateOfPayment"", 'ddMMyyyy')) = :Year"
                        End If
                    End If

                    ' Lệnh select SQL
                    Sql = "SELECT *"
                    Sql &= "FROM ""bill"" "
                    Sql &= "WHERE ""bill"".""ownerId"" = " & MstrOwnerId & MonthBill & YearBill

                    'Select *
                    'FROM "bill"
                    'WHERE "bill"."ownerId" = '000001'
                    '    And EXTRACT(MONTH FROM TO_DATE("bill"."dateOfPayment", 'ddMMyyyy')) = 11;

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        Dim sum As Decimal = 0
                        For Each row As DataRow In Dt.Rows
                            sum += Convert.ToDecimal(row("totalPayment"))
                        Next
                        Return sum.ToString("N0")
                    End If
                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadStatistics" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

        Return 0
    End Function


    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        loadStatistics()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        LblDate.Text = loadDataDate()
    End Sub

    Private Sub ComboBoxMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxMonth.SelectedIndexChanged
        LblMonth.Text = loadDataMonth()
    End Sub

    Private Sub ComboBoxYear_month_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxYear_month.SelectedIndexChanged
        LblMonth.Text = loadDataMonth()
    End Sub

    Private Sub ComboBoxYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxYear.SelectedIndexChanged
        LblYear.Text = loadDataMonth(2)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DateTimePicker1.Value = DateTime.Now

        Dim currentYear As Integer = DateTime.Now.Year
        ComboBoxYear_month.SelectedItem = currentYear.ToString()
        ComboBoxYear.SelectedItem = currentYear.ToString()

        ComboBoxMonth.SelectedIndex = DateTime.Now.Month - 1
    End Sub
End Class
