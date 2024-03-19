Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FormAddTable

    Private MstrHost As String
    Private MstrPort As String
    Private MstrDb As String
    Private MstrUser As String
    Private MstrPass As String
    Private MstrConnection As String
    Private MstrOwnerId As String

    Private formTableView As UCTableArea

    Public Sub New(parent As UCTableArea)
        InitializeComponent()
        Me.formTableView = parent
    End Sub

    Private Sub FormAddTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            loadDataInComboboxArea()
        Catch ex As Exception
            MessageBox.Show("Form thêm bàn" & vbCrLf & ex.Message,
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
            End
        End Try
    End Sub


    Public Function getOwnerId(str)
        Dim result As String = ""

        For Each c As Char In str
            If Char.IsDigit(c) Then
                result += c
            End If
        Next
        Return result
    End Function


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
                        ComboBoxAddTable_AreaId.DataSource = Dt
                        ComboBoxAddTable_AreaId.DisplayMember = "areaName"
                        ComboBoxAddTable_AreaId.ValueMember = "areaId"
                        ComboBoxAddTable_AreaId.SelectedIndex = -1
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

    Private Function GetMaxTableId(areaId) As Integer
        Dim Sql As String
        Dim Dt As New DataTable
        Dim MaxId As Integer
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    Sql = "SELECT"
                    Sql &= " COALESCE(MAX(""tableId""),'0') AS MaxId"
                    Sql &= " FROM public.""table"""
                    Sql &= " WHERE ""ownerId"" = " & MstrOwnerId & " AND ""areaId"" = " & areaId

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    MaxId = If(CInt(Dt.Rows(0).Item("MaxId")) = 0, 1, CInt(Dt.Rows(0).Item("MaxId")) + 1)

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

    Private Sub ComboBoxAddTable_AreaId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAddTable_AreaId.SelectedIndexChanged
        If ComboBoxAddTable_AreaId.SelectedIndex <> -1 Then
            Dim selectedValue As String = ComboBoxAddTable_AreaId.SelectedValue.ToString()
            Dim maxTableId = GetMaxTableId("'" & selectedValue & "'")
            txtAddTable_TableId.Text = maxTableId.ToString.PadLeft(6, "0")
        Else
            txtAddTable_TableId.Text = ""
        End If

    End Sub

    Private Function InsertTable() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand

        sql &= "INSERT INTO"
        sql &= " PUBLIC.""table"""
        sql &= " ("
        sql &= """ownerId"""
        sql &= " , ""areaId"""
        sql &= " , ""tableId"""
        sql &= " , ""status"""
        sql &= " , ""maxCapacity"""
        sql &= " )"
        sql &= " VALUES"
        sql &= " ("
        sql &= " :OWNER_ID"
        sql &= " , :AREA_ID"
        sql &= " , :TABLE_ID"
        sql &= " , :STATUS"
        sql &= " , :MAX_CAPACITY"
        sql &= " );"


        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb
                    .CommandText = sql
                    .Parameters.Add("OWNER_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("AREA_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("TABLE_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("STATUS", NpgsqlTypes.NpgsqlDbType.Integer)
                    .Parameters.Add("MAX_CAPACITY", NpgsqlTypes.NpgsqlDbType.Integer)

                    .Parameters.Item("OWNER_ID").Value = getOwnerId(MstrOwnerId).PadLeft(6, "0")
                    .Parameters.Item("AREA_ID").Value = ComboBoxAddTable_AreaId.SelectedValue
                    .Parameters.Item("TABLE_ID").Value = txtAddTable_TableId.Text
                    .Parameters.Item("STATUS").Value = 0
                    .Parameters.Item("MAX_CAPACITY").Value = If(String.IsNullOrEmpty(txtMax.Text), 0, Integer.Parse(txtMax.Text))

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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        If formTableView IsNot Nothing Then
            formTableView.loadTable()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If ComboBoxAddTable_AreaId.SelectedIndex = -1 Then
            MessageBox.Show("Bạn chưa nhập đủ dữ liệu !")
        Else
            Dim result = InsertTable()
            If result = True Then
                MessageBox.Show("Đăng ký thành công")
                Me.Close()
                If formTableView IsNot Nothing Then
                    'formTableView.loadTable()
                    formTableView.reloadAllData()
                End If
            Else
                MessageBox.Show("Đăng ký lỗi")
                If formTableView IsNot Nothing Then
                    formTableView.reloadAllData()
                End If
            End If
        End If
    End Sub
End Class