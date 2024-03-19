Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql

Public Class UCProduct
    Private MstrConnection As String
    Private MstrOwnerId As String

    'Dim pathImg As String = "D:\1PROJECT_DACN\VTManagerProject\VTManagerProject\public\images\menu"
    'Dim pathImg As String = "D:\1PROJECT_DACN\VTManager_web\public\images\menu\"
    Dim pathImg As String
    Public Sub UCProduct_Load()
        MstrConnection = InforConnection.MstrConnection
        MstrOwnerId = InforConnection.MstrOwnerId
        pathImg = InforConnection.pathImg

        InterfaceCustomize()
        loadDataInComboboxProductType()
        loadProducts()
    End Sub


    Public Function InterfaceCustomize()
        DGVProducts.AutoGenerateColumns = False
        DGVProducts.RowHeadersVisible = False
        DGVProducts.AllowUserToAddRows = False
        DGVProducts.EnableHeadersVisualStyles = False
    End Function


    Public Sub loadDataInComboboxProductType()
        Dim Sql As String
        Dim Dt As New DataTable
        Try
            ' Thao tác với database
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT * FROM public.""product_type"""
                    Sql &= " where ""ownerId"" = " & MstrOwnerId
                    Sql &= " ORDER BY ""productTypeId"" ASC"

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ComboBoxProductType.DataSource = Dt
                        ComboBoxProductType.DisplayMember = "productTypeName"
                        ComboBoxProductType.ValueMember = "productTypeId"
                        ComboBoxProductType.SelectedIndex = -1
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


    Public Sub loadProducts()
        Dim Sql As String
        Dim Dt As New DataTable
        Dim whereProductType As String
        Dim whereProductName As String
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    If ComboBoxProductType.SelectedIndex <> -1 Then
                        adp.SelectCommand.Parameters.Add("ProductType", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("ProductType").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("ProductType").Value = ComboBoxProductType.SelectedValue
                        whereProductType = " AND ""product"".""productTypeId"" = :ProductType"
                    End If

                    If txtProductName.TextLength <> 0 Then
                        adp.SelectCommand.Parameters.Add("ProductName", NpgsqlTypes.NpgsqlDbType.Text)
                        adp.SelectCommand.Parameters("ProductName").Direction = ParameterDirection.Input
                        adp.SelectCommand.Parameters("ProductName").Value = "%" & txtProductName.Text & "%"
                        whereProductName = " AND ""product"".""productName"" LIKE :ProductName"
                    End If

                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""product"""
                    Sql &= " LEFT JOIN PUBLIC.""product_type"""
                    Sql &= " ON ""product"".""productTypeId"" = ""product_type"".""productTypeId"""
                    Sql &= " LEFT JOIN PUBLIC.""MST_vat"""
                    Sql &= " ON ""product"".""vatId"" = ""MST_vat"".""vatId"""
                    Sql &= " where ""product"".""ownerId"" = " & MstrOwnerId & " AND ""product_type"".""ownerId"" = " & MstrOwnerId
                    Sql &= whereProductType & whereProductName
                    Sql &= " ORDER BY ""product"".""productId"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVProducts.DataSource = SetDataProduct(Dt)
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVProducts.DataSource = SetDataProduct(Dt)
                        MessageBox.Show("Không tìm thấy dữ liệu")
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadProducts" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function SetDataProduct(data As DataTable) As DataTable
        Dim DataResult As New DataTable
        DataResult.Columns.Add("ownerId", GetType(String))
        DataResult.Columns.Add("productTypeId", GetType(String))
        DataResult.Columns.Add("productId", GetType(String))
        DataResult.Columns.Add("productTypeName", GetType(String))
        DataResult.Columns.Add("productName", GetType(String))
        DataResult.Columns.Add("productImage", GetType(String))
        DataResult.Columns.Add("unitPrice", GetType(String))
        DataResult.Columns.Add("description", GetType(String))
        DataResult.Columns.Add("tax", GetType(String))
        DataResult.Columns.Add("vatId", GetType(String))
        For indexId As Integer = 0 To data.Rows.Count() - 1
            Dim newRow As DataRow = DataResult.NewRow()

            newRow("ownerId") = data(indexId)("ownerId")
            newRow("productTypeId") = data(indexId)("productTypeId")
            newRow("productId") = data(indexId)("productId")
            newRow("productTypeName") = data(indexId)("productTypeName")
            newRow("productName") = data(indexId)("productName")
            newRow("productImage") = data(indexId)("image")
            newRow("unitPrice") = CInt(data(indexId)("unitPrice")).ToString("N0")
            newRow("description") = data(indexId)("description")
            newRow("tax") = data(indexId)("vatName").ToString + " - " + data(indexId)("vatValue%").ToString + "%"
            newRow("vatId") = data(indexId)("vatId")

            DataResult.Rows.Add(newRow)
        Next
        Return DataResult
    End Function


    Private Function deleteProduct(productId) As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereProductId As String = ""

        sql &= "DELETE FROM "
        sql &= " PUBLIC.""product"""
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("ProductId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("ProductId").Direction = ParameterDirection.Input
                    .Parameters("ProductId").Value = productId.PadLeft(6, "0")
                    WhereProductId = " AND ""productId"" = :ProductId"


                    sql &= WhereProductId
                    sql &= " ;"

                    .CommandText = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "product delete")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ComboBoxProductType.SelectedIndex = -1
        txtProductName.Text = ""
        loadProducts()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        loadProducts()
    End Sub

    Private Sub DVGProducts_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVProducts.DataBindingComplete
        If DGVProducts.SelectedRows.Count > 0 Then
            DGVProducts.SelectedRows(0).Selected = False
        End If
    End Sub

    Private Sub DGVProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVProducts.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If e.RowIndex >= 0 Then
            ' Kiểm tra tên cột để phân biệt giữa hai cột button
            Dim selectedRow As DataGridViewRow = senderGrid.Rows(e.RowIndex)
            Dim columnName As String = senderGrid.Columns(e.ColumnIndex).Name

            If columnName = "edit" Then

                Dim formAddOrUpdate As New FormAddOrUpdateProduct(Me)

                formAddOrUpdate.productId = selectedRow.Cells("productId").Value
                formAddOrUpdate.productTypeName = selectedRow.Cells("productTypeName").Value
                formAddOrUpdate.productTypeId = selectedRow.Cells("productTypeId").Value
                formAddOrUpdate.productName = selectedRow.Cells("productName").Value
                formAddOrUpdate.productImage = selectedRow.Cells("productImage").Value
                formAddOrUpdate.unitPrice = selectedRow.Cells("unitPrice").Value
                formAddOrUpdate.description = selectedRow.Cells("description").Value
                formAddOrUpdate.vatId = selectedRow.Cells("vatId").Value

                Me.Cursor = Cursors.WaitCursor
                formAddOrUpdate.ShowDialog()

                Me.Cursor = Cursors.Default

                ' Thực hiện các tác vụ cần thiết cho cột 1
            ElseIf columnName = "delete" Then

                ' Hiển thị hộp thoại xác nhận
                Dim confirmResult As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?",
                                                          "Xác nhận xóa",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question)
                If confirmResult = DialogResult.Yes Then
                    ' Thực hiện xóa
                    Dim idValue As Object = selectedRow.Cells("productId").Value
                    If idValue IsNot Nothing Then
                        Dim result = deleteProduct(idValue)
                        If result = True Then
                            MessageBox.Show("Xóa thành công")
                            loadProducts()
                        Else
                            MessageBox.Show("Xóa lỗi")
                            loadProducts()
                        End If
                    Else
                        MessageBox.Show("Giá trị id không tồn tại.")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DGVProducts_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVProducts.CellFormatting
        ' Kiểm tra cột hiện tại có phải là cột 'myImage' và không phải dòng tiêu đề
        'If DGVProducts.Columns(e.ColumnIndex).Name = "productImage" AndAlso e.RowIndex >= 0 Then
        '    ' Lấy giá trị ban đầu từ ô dữ liệu
        '    Dim originalValue As Object = e.Value

        '    ' Kiểm tra giá trị ban đầu không rỗng
        '    If originalValue IsNot Nothing Then
        '        ' Nối đường dẫn đầy đủ vào giá trị ban đầu
        '        e.Value = pathImg & originalValue.ToString()
        '    End If

        '    ' Đánh dấu sự kiện đã được xử lý, để tránh xử lý lại ở sự kiện CellFormatting
        '    e.FormattingApplied = True
        'End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim AddOrUpdateProduct As New FormAddOrUpdateProduct(Me)

        Me.Cursor = Cursors.WaitCursor
        AddOrUpdateProduct.ShowDialog()

        Me.Cursor = Cursors.Default
    End Sub
End Class
