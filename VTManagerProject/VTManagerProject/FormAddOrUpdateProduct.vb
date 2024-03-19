Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO

Public Class FormAddOrUpdateProduct

    Private MstrHost As String
    Private MstrPort As String
    Private MstrDb As String
    Private MstrUser As String
    Private MstrPass As String
    Private MstrConnection As String
    Private MstrOwnerId As String

    Public productId As String
    Public productTypeName As String
    Public productTypeId As String
    Public productName As String
    Public productImage As String
    Public unitPrice As String
    Public description As String
    Public vatId As String

    Private isUpdate As Boolean

    'Dim pathImg As String = = "D:\1PROJECT_DACN\VTManager_web\public\images\menu\"
    Dim pathImg As String

    Private formProduct As UCProduct
    Public Sub New(parent As UCProduct)
        InitializeComponent()
        Me.formProduct = parent
    End Sub

    Private Sub FormAddOrUpdateProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


            pathImg = InforConnection.pathImg
            loadDataInComboboxProductType()
            loadDataInComboboxVat()

            If String.IsNullOrEmpty(productId) Then
                isUpdate = False
                txtProductId.Text = GetMaxProductId().ToString.PadLeft(6, "0")
                ComboBoxTax.SelectedValue = 0
            Else
                isUpdate = True
                txtProductId.Text = productId
                ComboBoxProductType.SelectedValue = productTypeId
                txtProductName.Text = If(productName, " ")
                txtImg.Text = If(productImage, " ")
                If Not String.IsNullOrWhiteSpace(productImage) Then
                    Try
                        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                        PictureBox1.Image = Image.FromFile(pathImg & productImage)
                    Catch ex As Exception
                        MessageBox.Show("Không tải được ảnh")
                    End Try
                Else
                    MessageBox.Show("lỗi ảnh")
                End If
                txtUnitPrice.Text = unitPrice
                txtDesc.Text = description
                ComboBoxTax.SelectedValue = vatId
            End If

        Catch ex As Exception
            MessageBox.Show("Form thêm Sản phẩm" & vbCrLf & ex.Message,
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Private Sub btnOpenImg_Click(sender As Object, e As EventArgs) Handles btnOpenImg.Click
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            txtImg.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName)

            Dim savePath As String = System.IO.Path.Combine(pathImg, txtImg.Text)
            If File.Exists(savePath) Then
                Dim fileNameWithoutExtension As String = Path.GetFileNameWithoutExtension(savePath)
                Dim fileExtension As String = Path.GetExtension(savePath)

                ' Tạo tên mới bằng cách thêm một số ngẫu nhiên vào cuối
                Dim newFileName As String = $"{fileNameWithoutExtension}_{DateTime.Now.Ticks}{fileExtension}"

                PictureBox1.Image.Save(newFileName, Imaging.ImageFormat.Png)
            Else
                PictureBox1.Image.Save(savePath, Imaging.ImageFormat.Png)
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        If formProduct IsNot Nothing Then
            formProduct.loadProducts()
        End If
    End Sub

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
            MessageBox.Show("loadDataInComboboxProductTypea" & vbCrLf & "Lỗi khi tải dữ liệu vào combobox. " & vbCrLf & ex.Message,
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub loadDataInComboboxVat()
        Dim Sql As String
        Dim Dt As New DataTable
        Try
            ' Thao tác với database
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)
                    ' Lệnh select SQL
                    Sql = "SELECT * FROM public.""MST_vat"""
                    Sql &= " ORDER BY ""vatId"" ASC"

                    adp.SelectCommand.CommandText = Sql
                    adp.Fill(Dt)

                    If Dt.Rows.Count <> 0 Then
                        Dt.Columns.Add("CombinedNameId", GetType(String), "vatName + ' - ' + [vatValue%] + '%'")

                        ComboBoxTax.DataSource = Dt
                        ComboBoxTax.DisplayMember = "CombinedNameId"
                        ComboBoxTax.ValueMember = "vatId"
                        ComboBoxTax.SelectedIndex = -1
                    End If

                End Using
                ConDb.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("loadDataInComboboxVat" & vbCrLf & "Lỗi khi tải dữ liệu vào combobox. " & vbCrLf & ex.Message,
               "Lỗi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error)
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


    Private Function GetMaxProductId() As Integer
        Dim Sql As String
        Dim Dt As New DataTable
        Dim MaxId As Integer
        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()
                Using adp As New NpgsqlDataAdapter("", ConDb)

                    Sql = "SELECT"
                    Sql &= " COALESCE(MAX(""productId""),'0') AS MaxId"
                    Sql &= " FROM public.""product"""
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


    Private Function InsertProduct() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand

        sql &= "INSERT INTO"
        sql &= " PUBLIC.""product"""
        sql &= " ("
        sql &= """ownerId"""
        sql &= " , ""productId"""
        sql &= " , ""productTypeId"""
        sql &= " , ""productName"""
        sql &= " , ""unitPrice"""
        sql &= " , ""description"""
        sql &= " , ""image"""
        sql &= " , ""vatId"""
        sql &= " )"
        sql &= " VALUES"
        sql &= " ("
        sql &= " :OWNER_ID"
        sql &= " , :PRODUCT_ID"
        sql &= " , :PRODUCTTYPE_ID"
        sql &= " , :PRODUCT_NAME"
        sql &= " , :UNIT_PRICE"
        sql &= " , :DESCRIPTION"
        sql &= " , :IMAGE"
        sql &= " , :VAT_ID"
        sql &= " );"

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb
                    .CommandText = sql
                    .Parameters.Add("OWNER_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("PRODUCT_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("PRODUCTTYPE_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("PRODUCT_NAME", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("UNIT_PRICE", NpgsqlTypes.NpgsqlDbType.Integer)
                    .Parameters.Add("DESCRIPTION", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("IMAGE", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("VAT_ID", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("OWNER_ID").Value = getOwnerId(MstrOwnerId).PadLeft(6, "0")
                    .Parameters.Item("PRODUCT_ID").Value = txtProductId.Text
                    .Parameters.Item("PRODUCTTYPE_ID").Value = ComboBoxProductType.SelectedValue
                    .Parameters.Item("PRODUCT_NAME").Value = txtProductName.Text
                    .Parameters.Item("UNIT_PRICE").Value = CInt(txtUnitPrice.Text)
                    .Parameters.Item("DESCRIPTION").Value = txtDesc.Text
                    .Parameters.Item("IMAGE").Value = txtImg.Text
                    .Parameters.Item("VAT_ID").Value = ComboBoxTax.SelectedValue

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

    Private Function updateProduct() As Boolean
        Dim sql As String = ""
        Dim cmd As New NpgsqlCommand
        Dim WhereProductId As String = ""

        sql &= "UPDATE"
        sql &= " PUBLIC.""product"""
        sql &= " SET "
        sql &= " ""productTypeId"" = :PRODUCTTYPE_ID"
        sql &= " , ""productName"" = :PRODUCT_NAME"
        sql &= " , ""unitPrice"" = :UNIT_PRICE"
        sql &= " , ""description"" = :DESCRIPTION"
        sql &= " , ""image"" = :IMAGE"
        sql &= " , ""vatId"" = :VAT_ID"
        sql &= " WHERE ""ownerId"" = " & MstrOwnerId

        Try
            Using ConDb As New NpgsqlConnection(MstrConnection)
                ConDb.Open()

                With cmd
                    .Connection = ConDb

                    .Parameters.Add("ProductId", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters("ProductId").Direction = ParameterDirection.Input
                    .Parameters("ProductId").Value = txtProductId.Text
                    WhereProductId = " AND ""productId"" = :ProductId"


                    sql &= WhereProductId
                    sql &= " ;"

                    .CommandText = sql

                    .Parameters.Add("PRODUCTTYPE_ID", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("PRODUCT_NAME", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("UNIT_PRICE", NpgsqlTypes.NpgsqlDbType.Integer)
                    .Parameters.Add("DESCRIPTION", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("IMAGE", NpgsqlTypes.NpgsqlDbType.Text)
                    .Parameters.Add("VAT_ID", NpgsqlTypes.NpgsqlDbType.Text)

                    .Parameters.Item("PRODUCTTYPE_ID").Value = ComboBoxProductType.SelectedValue
                    .Parameters.Item("PRODUCT_NAME").Value = txtProductName.Text
                    .Parameters.Item("UNIT_PRICE").Value = CInt(txtUnitPrice.Text)
                    .Parameters.Item("DESCRIPTION").Value = txtDesc.Text
                    .Parameters.Item("IMAGE").Value = txtImg.Text
                    .Parameters.Item("VAT_ID").Value = ComboBoxTax.SelectedValue

                    Dim a = sql

                    .ExecuteNonQuery()
                End With

                ConDb.Close()
            End Using
        Catch ex As NpgsqlException
            MessageBox.Show(ex.Message & "cập nhật products")
        Finally
            cmd = Nothing
        End Try

        Return True
    End Function

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If String.IsNullOrWhiteSpace(txtUnitPrice.Text) OrElse String.IsNullOrWhiteSpace(txtProductName.Text) OrElse ComboBoxProductType.SelectedIndex = -1 Then
            MessageBox.Show("Bạn chưa nhập đủ dữ liệu cần thiết !")
        Else

            Dim result As Boolean
            If isUpdate = False Then
                result = InsertProduct()
            Else
                result = updateProduct()
            End If
            If result = True Then
                MessageBox.Show("Hoàn thành")
                Me.Close()
                If formProduct IsNot Nothing Then
                    formProduct.loadProducts()
                End If
            Else
                MessageBox.Show("Lỗi")
                If formProduct IsNot Nothing Then
                    formProduct.loadProducts()
                End If
            End If
        End If

    End Sub
End Class