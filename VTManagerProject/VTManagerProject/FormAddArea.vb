Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql

Public Class FormAddArea
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


    Private Sub FormAddArea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Catch ex As Exception
            MessageBox.Show("Form thêm khu vực" & vbCrLf & ex.Message,
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


    Private Function GetMaxSeq() As Integer
        Dim Sql As String
        Dim Dt As New DataTable
        Dim Seq As Integer
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    Sql = "SELECT"
                    Sql &= " COALESCE(MAX(""areaId""),'0') AS MaxId"
                    Sql &= " FROM public.""area"""
                    Sql &= " WHERE ""ownerId"" = " & MstrOwnerId


                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    Seq = If(CInt(Dt.Rows(0).Item("MaxId")) = 0, 1, CInt(Dt.Rows(0).Item("MaxId")) + 1)

                End Using
                ConDb.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show("Xin vui lòng liên hệ với quản trị hệ thống của bạn",
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

        Return Seq

    End Function



    Private Function InsertArea() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim maxId = GetMaxSeq()

        sql &= "INSERT INTO"
        sql &= " PUBLIC.""area"""
        sql &= " ("
        sql &= """ownerId"""
        sql &= " , ""areaId"""
        sql &= " , ""areaName"""
        sql &= " )"
        sql &= " VALUES"
        sql &= " ("
        sql &= " :OWNER_ID"
        sql &= " , :AREA_ID"
        sql &= " , :AREA_NAME"
        sql &= " );"


        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb
                    .CommandText = sql
                    .Parameters.Add("OWNER_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("AREA_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("AREA_NAME", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("OWNER_ID").Value = getOwnerId(MstrOwnerId).PadLeft(6, "0")
                    .Parameters.Item("AREA_ID").Value = maxId.ToString.PadLeft(6, "0")
                    .Parameters.Item("AREA_NAME").Value = txtAddArea.Text

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            txtAddArea.Text = ex.Message
            MessageBox.Show(ex.Message)
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Sub btnAddArea_Click(sender As Object, e As EventArgs) Handles btnAddArea.Click
        If String.IsNullOrWhiteSpace(txtAddArea.Text) Then
            MessageBox.Show("Bạn chưa nhập khu vực !")
        Else
            Dim result = InsertArea()
            If result = True Then
                MessageBox.Show("Đăng ký thành công")
                Me.Close()
                If formTableView IsNot Nothing Then
                    'formTableView.loadAreas()
                    formTableView.reloadAllData()
                End If
            Else
                MessageBox.Show("Đăng ký lỗi")
            End If
        End If
    End Sub

    Private Sub btnCancelAddArea_Click(sender As Object, e As EventArgs) Handles btnCancelAddArea.Click
        Me.Close()

        If formTableView IsNot Nothing Then
            'formTableView.loadAreas()
            formTableView.reloadAllData()
        End If
    End Sub
End Class