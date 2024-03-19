Imports System.Xml
Imports Npgsql


Public Class Main

    Private MstrHost As String
    Private MstrPort As String
    Private MstrDb As String
    Private MstrUser As String
    Private MstrPass As String
    Private MstrConnection As String
    Private MstrOwnerId As String

    Private openedForms As New List(Of Form)

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load("Config.xml")
        MstrHost = xmlDoc.DocumentElement.SelectSingleNode("DB_HOST").InnerText()
        MstrPort = xmlDoc.DocumentElement.SelectSingleNode("DB_PORT").InnerText()
        MstrDb = xmlDoc.DocumentElement.SelectSingleNode("DB_DATABASE").InnerText()
        MstrUser = xmlDoc.DocumentElement.SelectSingleNode("DB_USERNAME").InnerText()
        MstrPass = xmlDoc.DocumentElement.SelectSingleNode("DB_PASSWORD").InnerText()
        MstrConnection = "Server=" & MstrHost & "; Port=" & MstrPort & "; User Id=" & MstrUser & ";Password=" & MstrPass & ";Database=" & MstrDb
        MstrOwnerId = xmlDoc.DocumentElement.SelectSingleNode("OWNER_ID").InnerText()

        InforConnection.MstrConnection = MstrConnection
        InforConnection.MstrOwnerId = MstrOwnerId

        'đường dẫn ảnh và đường dẫn pdf
        InforConnection.pathImg = "D:\1PROJECT_DATN\VTManager_web\public\images\menu\"
        'InforConnection.folderPath = "D:\1PROJECT_DACN\VTManagerProject\VTManagerProject\public\PDF\"
        InforConnection.folderPath = "C:\VTManager_HoaDon\"
        'set shoppAdress và shopName
        GetAdminInfor()

        UcTableArea1.Visible = False
        UcProduct1.Visible = False
        UcProductType1.Visible = False
        UcEmployee1.Visible = False
        UcEmployeeClass1.Visible = False
        UcWorkingTime1.Visible = False
        UcWorkingTimeMaster1.Visible = False
        UcStatistic1.Visible = False
        Home1.Home_Load()

    End Sub

    Public Sub GetAdminInfor()
        Dim Sql As String
        Dim Dt As New DataTable
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT * FROM ""MST_admin"""
                    Sql &= " where ""ownerId"" = " & MstrOwnerId

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        InforConnection.shopName = Dt.Rows(0)("shopName").ToString()
                        InforConnection.shopAddress = Dt.Rows(0)("shopAddress").ToString()
                    Else

                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("load admin infor" & vbCrLf & "Xin vui lòng liên hệ với quản trị hệ thống của bạn." & vbCrLf & ex.Message,
               "lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SetActivePanel(ByVal control As UserControl)
        UcTableArea1.Visible = False
        UcProduct1.Visible = False
        UcProductType1.Visible = False
        UcEmployee1.Visible = False
        UcEmployeeClass1.Visible = False
        UcWorkingTime1.Visible = False
        UcWorkingTimeMaster1.Visible = False
        Home1.Visible = False
        UcStatistic1.Visible = False

        control.Visible = True
    End Sub

    Private Sub btnManageTableArea_Click(sender As Object, e As EventArgs) Handles btnManageTableArea.Click
        UcTableArea1.UCTableArea_Load()
        SetActivePanel(UcTableArea1)
    End Sub

    Private Sub btnManageProduct_Click(sender As Object, e As EventArgs) Handles btnManageProduct.Click
        UcProduct1.UCProduct_Load()
        SetActivePanel(UcProduct1)
    End Sub

    Private Sub btnProductType_Click(sender As Object, e As EventArgs) Handles btnProductType.Click
        UcProductType1.UCProductType_Load()
        SetActivePanel(UcProductType1)
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        UcEmployee1.UCEmployee_Load()
        SetActivePanel(UcEmployee1)
    End Sub

    Private Sub btnEmployeeClass_Click(sender As Object, e As EventArgs) Handles btnEmployeeClass.Click
        UcEmployeeClass1.UCWorkingTime_Load()
        SetActivePanel(UcEmployeeClass1)
    End Sub

    Private Sub btnWorkingTime_Click(sender As Object, e As EventArgs) Handles btnWorkingTime.Click
        UcWorkingTime1.UCWorkingTime_Load()
        SetActivePanel(UcWorkingTime1)
    End Sub

    Private Sub btnWorkingTimeMaster_Click(sender As Object, e As EventArgs) Handles btnWorkingTimeMaster.Click
        UcWorkingTimeMaster1.UCWorkingTimeMaster_Load()
        SetActivePanel(UcWorkingTimeMaster1)
    End Sub

    Private Sub btnStatistic_Click(sender As Object, e As EventArgs) Handles btnStatistic.Click
        UcStatistic1.UCStatistic_Load()
        SetActivePanel(UcStatistic1)
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        SetActivePanel(Home1)
        Home1.Home_Load()
    End Sub

    Private Sub Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        For Each form In openedForms
            form.Close()
        Next
    End Sub
    Public Sub AddOpenedForm(form As Form)
        openedForms.Add(form)
    End Sub
End Class