

Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql

Public Class UCTableArea
    Private MstrConnection As String
    Private MstrOwnerId As String

    Public Sub UCTableArea_Load()
        MstrConnection = InforConnection.MstrConnection
        MstrOwnerId = InforConnection.MstrOwnerId

        InterfaceCustomize()
        loadDataInComboboxArea()
        loadAreas()
        loadTable()
        'Catch ex As Exception
        '    MessageBox.Show("TablesView_Load" & vbCrLf & ex.Message,
        '       "Lỗi",
        '       MessageBoxButtons.OK,
        '       MessageBoxIcon.Error)
        '    End
        'End Try
    End Sub

    Public Function InterfaceCustomize()
        DGVArea.AutoGenerateColumns = False
        DGVArea.RowHeadersVisible = False
        DGVArea.AllowUserToAddRows = False
        DGVArea.EnableHeadersVisualStyles = False

        DGVTable.AutoGenerateColumns = False
        DGVTable.RowHeadersVisible = False
        DGVTable.AllowUserToAddRows = False
        DGVTable.EnableHeadersVisualStyles = False
    End Function

    Public Sub reloadAllData()
        loadDataInComboboxArea()
        loadTable()
        loadAreas()
    End Sub



    '======================================== TABLE ==============================================================


    ' để hiển thị dữ liệu cho combobox area ở quản lý table
    Public Sub loadDataInComboboxArea()
        Dim Sql As String
        Dim Dt As New DataTable
        Try
            ' Thao tác với database
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT * FROM public.""area"""
                    Sql &= " where ""ownerId"" = " & MstrOwnerId
                    Sql &= " ORDER BY ""areaId"" ASC"

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ComboBoxAreaName.DataSource = Dt
                        ComboBoxAreaName.DisplayMember = "areaName"
                        ComboBoxAreaName.ValueMember = "areaId"
                        ComboBoxAreaName.SelectedIndex = -1
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadDataInComboboxArea" & vbCrLf & "Lỗi khi tải dữ liệu vào combobox. " & vbCrLf & ex.Message,
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

    End Sub



    ' load danh sách bàn
    Public Sub loadTable()

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
                        DGVTable.DataSource = Dt
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVTable.DataSource = Dt
                        MessageBox.Show("Không tìm thấy dữ liệu của Bàn")
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




    ' =====================================   AREA   =============================================================


    ' load danh sách khu vực
    Public Sub loadAreas()

        Dim Sql As String
        Dim Dt As New DataTable

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    ' Lệnh select SQL
                    Sql = "SELECT * FROM public.""area"""
                    Sql &= " where ""ownerId"" = " & MstrOwnerId
                    Sql &= " ORDER BY ""areaId"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVArea.DataSource = Dt
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVArea.DataSource = Dt
                        MessageBox.Show("Không tìm thấy dữ liệu của khu vực")
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadAreas" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

    End Sub


    Private Function updateArea() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereAreaId As String = ""

        sql &= "UPDATE"
        sql &= " PUBLIC.""area"""
        sql &= " SET"
        sql &= " ""areaName"" = :AREA_NAME"
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("AreaId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("AreaId").Direction = ParameterDirection.Input
                    .Parameters("AreaId").Value = txtAreaId.Text
                    WhereAreaId = " AND ""areaId"" = :AreaId"


                    sql &= WhereAreaId
                    sql &= " ;"

                    .CommandText = sql

                    .Parameters.Add("AREA_NAME", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("AREA_NAME").Value = txtAreaName.Text

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "TemplateUpdate")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Function deleteArea() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereAreaId As String = ""

        sql &= "DELETE FROM "
        sql &= " PUBLIC.""area"""
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("AreaId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("AreaId").Direction = ParameterDirection.Input
                    .Parameters("AreaId").Value = txtAreaId.Text
                    WhereAreaId = " AND ""areaId"" = :AreaId"


                    sql &= WhereAreaId
                    sql &= " ;"

                    .CommandText = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "Liên hệ với người quản trị hệ thống của bạn")
            Return False
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function


    Private Sub DGVArea_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVArea.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DGVArea.Rows(e.RowIndex)

            ' Lấy dữ liệu từ các cột trong hàng
            Dim areaId As Object = selectedRow.Cells("areaId").Value
            Dim areaName As Object = selectedRow.Cells("areaName").Value

            txtAreaId.Text = areaId
            txtAreaName.Text = areaName
        End If
    End Sub

    Private Sub btnUpdateArea_Click(sender As Object, e As EventArgs) Handles btnUpdateArea.Click
        If String.IsNullOrWhiteSpace(txtAreaName.Text) AndAlso String.IsNullOrWhiteSpace(txtAreaId.Text) Then
            MessageBox.Show("Bạn chưa chọn dữ liệu nào !")
        Else
            Dim result = updateArea()
            If result = True Then
                MessageBox.Show("Cập nhật thành công")
                txtAreaId.Text = ""
                txtAreaName.Text = ""
                'loadAreas()
                reloadAllData()
            Else
                MessageBox.Show("Cập nhật không thành công")
                txtAreaId.Text = ""
                txtAreaName.Text = ""
            End If
        End If



    End Sub

    Private Sub DGVArea_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVArea.DataBindingComplete
        If DGVArea.SelectedRows.Count > 0 Then
            DGVArea.SelectedRows(0).Selected = False
        End If
    End Sub

    Private Sub btnDeleteArea_Click(sender As Object, e As EventArgs) Handles btnDeleteArea.Click
        If String.IsNullOrWhiteSpace(txtAreaName.Text) AndAlso String.IsNullOrWhiteSpace(txtAreaId.Text) Then
            MessageBox.Show("Bạn chưa chọn dữ liệu nào !")
        Else
            ' Hiển thị hộp thoại xác nhận
            Dim confirmResult As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?",
                                          "Xác nhận xóa",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question)
            If confirmResult = DialogResult.Yes Then
                Dim result = deleteArea()
                If result = True Then
                    MessageBox.Show("Xóa thành công")
                    txtAreaId.Text = ""
                    txtAreaName.Text = ""
                    'loadAreas()
                    reloadAllData()
                Else
                    MessageBox.Show("Xóa không thành công")
                    txtAreaId.Text = ""
                    txtAreaName.Text = ""
                End If
            End If

        End If
    End Sub

    Private Sub btnAddArea_Click(sender As Object, e As EventArgs) Handles btnAddArea.Click
        Dim addArea As New FormAddArea(Me)

        Me.Cursor = Cursors.WaitCursor
        addArea.ShowDialog()

        Me.Cursor = Cursors.Default
    End Sub




    '================================= TABLE action =========================

    Private Sub DGVTable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVTable.CellClick
        If e.RowIndex >= 0 Then ' Đảm bảo người dùng đã chọn một hàng hợp lệ
            Dim selectedAreaId As String = DGVTable.Rows(e.RowIndex).Cells("table_areaId").Value.ToString()
            If selectedAreaId <> -1 Then
                ComboBoxAreaName.SelectedValue = selectedAreaId
            End If
            'MessageBox.Show("Giá trị đã chọn: " & ComboBoxAreaName.Text)
            Dim selectedtableId As String = DGVTable.Rows(e.RowIndex).Cells("tableId").Value.ToString()
            Dim selectedareaIdHidden As String = DGVTable.Rows(e.RowIndex).Cells("table_areaId").Value.ToString()
            If Not String.IsNullOrEmpty(selectedtableId) <> 0 Then
                txtTableId.Text = selectedtableId
                lbltableIdHidden.Text = selectedtableId    ' đây là để lưu trữ tableId để thực hiện thêm, xóa, sửa
                lbAreaIdHidden.Text = selectedareaIdHidden    ' đây là để lưu trữ tableId để thực hiện thêm, xóa, sửa
            End If
            Dim selectTedMaxCapacity As String = DGVTable.Rows(e.RowIndex).Cells("maxCapacity").Value.ToString()
            If Not String.IsNullOrEmpty(selectTedMaxCapacity) <> 0 Then
                txtMaxCapacity.Text = selectTedMaxCapacity
            End If
        End If
    End Sub

    ' để không chọn hàng đầu tiên khi mới mở form
    Private Sub DGVTable_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVTable.DataBindingComplete
        If DGVTable.SelectedRows.Count > 0 Then
            DGVTable.SelectedRows(0).Selected = False
        End If
    End Sub

    ' cập nhật table
    Private Function updateTable() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereTableId As String = ""
        Dim WhereAreaId As String = ""

        sql &= "UPDATE"
        sql &= " PUBLIC.""table"""
        sql &= " SET"
        sql &= " ""tableId"" = :TABLE_ID"
        sql &= ", ""areaId"" = :AREA_ID"
        sql &= ", ""maxCapacity"" = :MAX_CAPACITY"
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("TableId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("TableId").Direction = ParameterDirection.Input
                    .Parameters("TableId").Value = lbltableIdHidden.Text
                    WhereTableId = " AND ""tableId"" = :TableId"

                    .Parameters.Add("AreaId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("AreaId").Direction = ParameterDirection.Input
                    .Parameters("AreaId").Value = lbAreaIdHidden.Text
                    WhereAreaId = " AND ""areaId"" = :AreaId"


                    sql &= WhereTableId & WhereAreaId
                    sql &= " ;"

                    .CommandText = sql

                    .Parameters.Add("TABLE_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("AREA_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("MAX_CAPACITY", NpgsqlTypes.NpgsqlDbType.Integer)

                    .Parameters.Item("TABLE_ID").Value = txtTableId.Text
                    .Parameters.Item("AREA_ID").Value = ComboBoxAreaName.SelectedValue
                    .Parameters.Item("MAX_CAPACITY").Value = CInt(txtMaxCapacity.Text)

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "TemplateUpdate")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Sub btnUpdateTable_Click(sender As Object, e As EventArgs) Handles btnUpdateTable.Click
        If String.IsNullOrWhiteSpace(txtTableId.Text) OrElse String.IsNullOrWhiteSpace(txtMaxCapacity.Text) OrElse ComboBoxAreaName.SelectedIndex = -1 Then
            MessageBox.Show("Bạn chưa nhập đủ dữ liệu !")
        Else
            Dim result = updateTable()
            If result = True Then
                MessageBox.Show("Cập nhật bàn thành công ")
                txtMaxCapacity.Text = ""
                txtTableId.Text = ""
                ComboBoxAreaName.SelectedIndex = -1
                'loadTable()
                reloadAllData()
            Else
                MessageBox.Show("Cập nhật bàn không thành công")
            End If
        End If
    End Sub

    Private Function deleteTable() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereTableId As String = ""
        Dim WhereAreaId As String = ""

        sql &= "DELETE FROM "
        sql &= " PUBLIC.""table"""
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("TableId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("TableId").Direction = ParameterDirection.Input
                    .Parameters("TableId").Value = txtTableId.Text
                    WhereTableId = " AND ""tableId"" = :TableId"

                    .Parameters.Add("AreaId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("AreaId").Direction = ParameterDirection.Input
                    .Parameters("AreaId").Value = ComboBoxAreaName.SelectedValue
                    WhereAreaId = " AND ""areaId"" = :AreaId"

                    sql &= WhereTableId & WhereAreaId
                    sql &= " ;"

                    .CommandText = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "Hãy liên hệ với người quản trị hệ thống")
            Return False
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Sub btnDeleteTable_Click(sender As Object, e As EventArgs) Handles btnDeleteTable.Click
        If String.IsNullOrWhiteSpace(txtTableId.Text) AndAlso String.IsNullOrWhiteSpace(txtMaxCapacity.Text) AndAlso ComboBoxAreaName.SelectedIndex = -1 Then
            MessageBox.Show("Bạn chưa chọn dữ liệu nào !")
        Else


            ' Hiển thị hộp thoại xác nhận
            Dim confirmResult As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?",
                                  "Xác nhận xóa",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question)
            If confirmResult = DialogResult.Yes Then
                Dim result = deleteTable()
                If result = True Then
                    MessageBox.Show("Xóa bàn thành công")
                    txtMaxCapacity.Text = ""
                    txtTableId.Text = ""
                    ComboBoxAreaName.SelectedIndex = -1
                    'loadTable()
                    reloadAllData()
                Else
                    MessageBox.Show("Xóa bàn không thành công")
                    txtMaxCapacity.Text = ""
                    txtTableId.Text = ""
                    ComboBoxAreaName.SelectedIndex = -1
                End If
            End If

        End If
    End Sub

    Private Sub btnAddTable_Click(sender As Object, e As EventArgs) Handles btnAddTable.Click
        Dim addTable As New FormAddTable(Me)

        Me.Cursor = Cursors.WaitCursor
        addTable.ShowDialog()

        Me.Cursor = Cursors.Default
    End Sub

End Class
