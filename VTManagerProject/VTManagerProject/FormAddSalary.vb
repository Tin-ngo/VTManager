Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql

Public Class FormAddSalary

    Private MstrHost As String
    Private MstrPort As String
    Private MstrDb As String
    Private MstrUser As String
    Private MstrPass As String
    Private MstrConnection As String
    Private MstrOwnerId As String

    Private formWorkingTimeMaster As UCWorkingTimeMaster

    Public Sub New(parent As UCWorkingTimeMaster)
        InitializeComponent()
        Me.formWorkingTimeMaster = parent
    End Sub


    Private Sub FormAddSalary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            txtSalaryId.Text = GetMaxID().ToString.PadLeft(6, "0")

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


    Private Function GetMaxID() As Integer
        Dim Sql As String
        Dim Dt As New DataTable
        Dim IDMax As Integer
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    Sql = "SELECT"
                    Sql &= " COALESCE(MAX(""salaryId""),'0') AS MaxId"
                    Sql &= " FROM public.""salary"""
                    Sql &= " WHERE ""ownerId"" = " & MstrOwnerId


                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    IDMax = If(CInt(Dt.Rows(0).Item("MaxId")) = 0, 1, CInt(Dt.Rows(0).Item("MaxId")) + 1)

                End Using
                ConDb.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show("Xin vui lòng liên hệ với quản trị hệ thống của bạn",
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try

        Return IDMax

    End Function


    Private Function InsertSalary() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand

        sql &= "INSERT INTO"
        sql &= " PUBLIC.""salary"""
        sql &= " ("
        sql &= """ownerId"""
        sql &= " , ""salaryId"""
        sql &= " , ""salary"""
        sql &= " , ""description"""
        sql &= " )"
        sql &= " VALUES"
        sql &= " ("
        sql &= " :OWNER_ID"
        sql &= " , :SALARY_ID"
        sql &= " , :SALARY"
        sql &= " , :DESC"
        sql &= " );"


        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb
                    .CommandText = sql
                    .Parameters.Add("OWNER_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("SALARY_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("SALARY", NpgsqlTypes.NpgsqlDbType.Integer)
                    .Parameters.Add("DESC", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("OWNER_ID").Value = getOwnerId(MstrOwnerId).PadLeft(6, "0")
                    .Parameters.Item("SALARY_ID").Value = txtSalaryId.Text
                    .Parameters.Item("SALARY").Value = CInt(txtSalary.Text)
                    .Parameters.Item("DESC").Value = txtDescSalary.Text

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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim result = InsertSalary()
        If result = True Then
            MessageBox.Show("Đăng ký thành công")
            Me.Close()
            If formWorkingTimeMaster IsNot Nothing Then
                'formTableView.loadAreas()
                formWorkingTimeMaster.loadSalary()
            End If
        Else
            MessageBox.Show("Đăng ký lỗi")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

        If formWorkingTimeMaster IsNot Nothing Then
            formWorkingTimeMaster.loadSalary()
        End If
    End Sub
End Class