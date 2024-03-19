Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql

Public Class UCProductType
    Private MstrConnection As String
    Private MstrOwnerId As String

    Public Sub UCProductType_Load()
        MstrConnection = InforConnection.MstrConnection
        MstrOwnerId = InforConnection.MstrOwnerId

        InterfaceCustomize()
        loadProductType()

        txtProductTypeId.Text = GetMaxProductTypeId().ToString.PadLeft(6, "0")
    End Sub


    Public Function InterfaceCustomize()
        DGVProductType.AutoGenerateColumns = False
        DGVProductType.RowHeadersVisible = False
        DGVProductType.AllowUserToAddRows = False
        DGVProductType.EnableHeadersVisualStyles = False
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



    Public Sub loadProductType()
        txtUpdateID.Text = ""
        txtUpdateName.Text = ""
        txtUpdateDesc.Text = ""
        Dim Sql As String
        Dim Dt As New DataTable

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""product_type"""
                    Sql &= " where ""product_type"".""ownerId"" = " & MstrOwnerId
                    Sql &= " ORDER BY ""productTypeId"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVProductType.DataSource = Dt
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVProductType.DataSource = Dt
                        MessageBox.Show("Không tìm thấy dữ liệu")
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadProductType" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
        clearForm()
    End Sub

    Private Function GetMaxProductTypeId() As Integer
        Dim Sql As String
        Dim Dt As New DataTable
        Dim MaxId As Integer
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    Sql = "SELECT"
                    Sql &= " COALESCE(MAX(""productTypeId""),'0') AS MaxId"
                    Sql &= " FROM public.""product_type"""
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

    Private Function InsertProductType() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand

        sql &= "INSERT INTO"
        sql &= " PUBLIC.""product_type"""
        sql &= " ("
        sql &= """ownerId"""
        sql &= " , ""productTypeId"""
        sql &= " , ""productTypeName"""
        sql &= " , ""description"""
        sql &= " )"
        sql &= " VALUES"
        sql &= " ("
        sql &= " :OWNER_ID"
        sql &= " , :PRODUCTTYPE_ID"
        sql &= " , :PRODUCTTYPE_NAME"
        sql &= " , :DESCRIPTION"
        sql &= " );"

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb
                    .CommandText = sql
                    .Parameters.Add("OWNER_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("PRODUCTTYPE_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("PRODUCTTYPE_NAME", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("DESCRIPTION", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("OWNER_ID").Value = getOwnerId(MstrOwnerId).PadLeft(6, "0")
                    .Parameters.Item("PRODUCTTYPE_ID").Value = txtProductTypeId.Text
                    .Parameters.Item("PRODUCTTYPE_NAME").Value = txtProductTypeName.Text
                    .Parameters.Item("DESCRIPTION").Value = txtDesc.Text

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


    Private Function deleteProductType(productTypeId) As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereProductTypeId As String = ""

        sql &= "DELETE FROM "
        sql &= " PUBLIC.""product_type"""
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("ProductTypeId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("ProductTypeId").Direction = ParameterDirection.Input
                    .Parameters("ProductTypeId").Value = productTypeId.PadLeft(6, "0")
                    WhereProductTypeId = " AND ""productTypeId"" = :ProductTypeId"


                    sql &= WhereProductTypeId
                    sql &= " ;"

                    .CommandText = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "productType delete - hãy liên hệ với người quản trị hệ thống")
            Return False
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function


    Private Function updateProductType() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereProductTypeId As String = ""

        sql &= "UPDATE"
        sql &= " PUBLIC.""product_type"""
        sql &= " SET "
        sql &= " ""productTypeId"" = :PRODUCTTYPE_ID"
        sql &= " , ""productTypeName"" = :PRODUCTTYPE_NAME"
        sql &= " , ""description"" = :DESCRIPTION"
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("ProductTypeId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("ProductTypeId").Direction = ParameterDirection.Input
                    .Parameters("ProductTypeId").Value = txtUpdateID.Text.ToString.PadLeft(6, "0")
                    WhereProductTypeId = " AND ""productTypeId"" = :ProductTypeId"


                    sql &= WhereProductTypeId
                    sql &= " ;"

                    .CommandText = sql

                    .Parameters.Add("PRODUCTTYPE_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("PRODUCTTYPE_NAME", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("DESCRIPTION", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("PRODUCTTYPE_ID").Value = txtUpdateID.Text.ToString.PadLeft(6, "0")
                    .Parameters.Item("PRODUCTTYPE_NAME").Value = txtUpdateName.Text
                    .Parameters.Item("DESCRIPTION").Value = txtUpdateDesc.Text

                    Dim a = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "cập nhật products type")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtDesc.Text) AndAlso String.IsNullOrWhiteSpace(txtProductTypeName.Text) Then
            MessageBox.Show("Chưa nhập đủ dữ liệu")
        Else

            Dim result As Boolean = InsertProductType()

            If result = True Then
                MessageBox.Show("Hoàn thành")
                loadProductType()
            Else
                MessageBox.Show("Lỗi")
                loadProductType()
            End If
        End If
    End Sub

    Private Sub DGVProductType_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVProductType.CellClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 Then
            ' Kiểm tra tên cột để phân biệt giữa hai cột button
            Dim selectedRow As DataGridViewRow = senderGrid.Rows(e.RowIndex)
            Dim columnName As String = senderGrid.Columns(e.ColumnIndex).Name
            If columnName = "delete" Then
                Dim idValue As Object = selectedRow.Cells("productTypeId").Value
                If idValue IsNot Nothing Then

                    ' Hiển thị hộp thoại xác nhận
                    Dim confirmResult As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?",
                   "Xác nhận xóa",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question)
                    If confirmResult = DialogResult.Yes Then

                        Dim result = deleteProductType(idValue)
                        If result = True Then
                            MessageBox.Show("Xóa thành công")
                            loadProductType()
                        Else
                            MessageBox.Show("Xóa lỗi")
                            loadProductType()
                        End If

                    End If

                Else
                    MessageBox.Show("Giá trị id không tồn tại.")
                End If
            Else
                txtUpdateID.Text = selectedRow.Cells("productTypeId").Value
                txtUpdateName.Text = selectedRow.Cells("productTypeName").Value
                txtUpdateDesc.Text = If(selectedRow.Cells("description").Value IsNot Nothing, selectedRow.Cells("description").Value.ToString(), "")
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If String.IsNullOrWhiteSpace(txtUpdateID.Text) OrElse String.IsNullOrWhiteSpace(txtUpdateName.Text) Then
            MessageBox.Show("Bạn chưa nhập đủ dữ liệu !")
        Else

            Dim result As Boolean = updateProductType()
            If result = True Then
                MessageBox.Show("Hoàn thành")
                loadProductType()
            Else
                MessageBox.Show("Lỗi")
                loadProductType()
            End If
        End If
    End Sub

    Private Sub DGVProductType_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVProductType.DataBindingComplete
        If DGVProductType.SelectedRows.Count > 0 Then
            DGVProductType.SelectedRows(0).Selected = False
        End If
    End Sub

    Private Sub clearForm()
        txtProductTypeId.Text = GetMaxProductTypeId().ToString.PadLeft(6, "0")
        txtProductTypeName.Text = ""
        txtDesc.Text = ""
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearForm()
    End Sub
End Class
