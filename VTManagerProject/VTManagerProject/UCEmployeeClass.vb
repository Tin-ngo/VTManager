Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql

Public Class UCEmployeeClass

    Private MstrConnection As String
    Private MstrOwnerId As String

    Public Sub UCWorkingTime_Load()

        MstrConnection = InforConnection.MstrConnection
        MstrOwnerId = InforConnection.MstrOwnerId


        InterfaceCustomize()

        loadEmployeeClass()
    End Sub

    Public Function InterfaceCustomize()
        DGVEmployeeClass.AutoGenerateColumns = False
        DGVEmployeeClass.RowHeadersVisible = False
        DGVEmployeeClass.AllowUserToAddRows = False
        DGVEmployeeClass.EnableHeadersVisualStyles = False
    End Function


    ' ============================================================ LOẠI NHÂN VIÊN =================================================

    Public Sub loadEmployeeClass()
        Dim Sql As String
        Dim Dt As New DataTable

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""employee_class"""
                    Sql &= " where ""employee_class"".""ownerId"" = " & MstrOwnerId
                    Sql &= " ORDER BY ""employeeClassId"" ASC"

                    ' Thêm câu lệnh SQL vào DataAdapter
                    adp.SelectCommand.CommandText = Sql
                    ' Thêm hoặc cập nhật các hàng trong DataTable để khớp với các hàng trong nguồn dữ liệu
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        ' Gán dữ liệu cho Form.DataGrid
                        DGVEmployeeClass.DataSource = Dt
                    Else
                        'Gán thuộc tính DataSource để duy trì các mục ColumnHeader ngay cả khi dữ liệu bằng 0
                        DGVEmployeeClass.DataSource = Dt
                        MessageBox.Show("Không tìm thấy dữ liệu")
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadEmployeeClass" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

        txtemployeeClassId1.Text = ""
        txtEmployeeClassName1.Text = ""
    End Sub


    Private Function updateEmployeeClass() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereEmployeeClassId As String = ""

        sql &= "UPDATE"
        sql &= " PUBLIC.""employee_class"""
        sql &= " SET "
        sql &= " ""employeeClassName"" = :EMPLOYEE_CLASS_NAME"
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("EmployeeClassId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("EmployeeClassId").Direction = ParameterDirection.Input
                    .Parameters("EmployeeClassId").Value = txtemployeeClassId1.Text.ToString.PadLeft(6, "0")
                    WhereEmployeeClassId = " AND ""employeeClassId"" = :EmployeeClassId"


                    sql &= WhereEmployeeClassId
                    sql &= " ;"

                    .CommandText = sql

                    .Parameters.Add("EMPLOYEE_CLASS_NAME", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("EMPLOYEE_CLASS_NAME").Value = txtEmployeeClassName1.Text

                    Dim a = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "cập nhật employee class")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Function deleteEmployeeClass(productTypeId) As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereEmployeeClassId As String = ""

        sql &= "DELETE FROM "
        sql &= " PUBLIC.""employee_class"""
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("EmployeeClassId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("EmployeeClassId").Direction = ParameterDirection.Input
                    .Parameters("EmployeeClassId").Value = productTypeId.PadLeft(6, "0")
                    WhereEmployeeClassId = " AND ""employeeClassId"" = :EmployeeClassId"

                    sql &= WhereEmployeeClassId
                    sql &= " ;"

                    .CommandText = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "productType delete lỗi - hãy liệu hệ với người quản trị hệ thống của bạn")
            Return False
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAddEmployeeClass.Click
        Dim AddEmployeeClass As New FormAddEmployeeClass(Me)

        Me.Cursor = Cursors.WaitCursor
        AddEmployeeClass.ShowDialog()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DGVEmployeeClass_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVEmployeeClass.CellClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = senderGrid.Rows(e.RowIndex)
            Dim columnName As String = senderGrid.Columns(e.ColumnIndex).Name
            If columnName = "delete" Then
                Dim idValue As Object = selectedRow.Cells("employeeClassId1").Value
                ' Hiển thị hộp thoại xác nhận
                Dim confirmResult As DialogResult = MessageBox.Show("Điều này có thể gây lỗi hệ thống - Bạn có chắc chắn muốn xóa bản ghi này không?",
                                                          "Xác nhận xóa",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question)
                If confirmResult = DialogResult.Yes Then
                    If idValue IsNot Nothing Then
                        Dim result = deleteEmployeeClass(idValue)
                        If result = True Then
                            MessageBox.Show("Xóa thành công")
                            loadEmployeeClass()
                        Else
                            MessageBox.Show("Xóa lỗi")
                            loadEmployeeClass()
                        End If
                    Else
                        MessageBox.Show("Giá trị id không tồn tại.")
                    End If
                End If



            Else
                    txtemployeeClassId1.Text = selectedRow.Cells("employeeClassId1").Value
                txtEmployeeClassName1.Text = selectedRow.Cells("employeeClassName1").Value
            End If
        End If
    End Sub

    Private Sub btnUpdateEmployeeClass_Click(sender As Object, e As EventArgs) Handles btnUpdateEmployeeClass.Click

        If String.IsNullOrWhiteSpace(txtEmployeeClassName1.Text) OrElse String.IsNullOrWhiteSpace(txtemployeeClassId1.Text) Then
            MessageBox.Show("Bạn chưa nhập đủ dữ liệu !")
        Else
            Dim result As Boolean = updateEmployeeClass()

            If result = True Then
                MessageBox.Show("Hoàn thành")
                loadEmployeeClass()
            Else
                MessageBox.Show("Lỗi")
                loadEmployeeClass()
            End If
        End If


    End Sub

    Private Sub DGVEmployeeClass_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGVEmployeeClass.DataBindingComplete
        If DGVEmployeeClass.SelectedRows.Count > 0 Then
            DGVEmployeeClass.SelectedRows(0).Selected = False
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtemployeeClassId1.Text = ""
        txtEmployeeClassName1.Text = ""
        loadEmployeeClass()
    End Sub
End Class
