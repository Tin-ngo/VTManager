Imports System.Data.Common

Module InforConnection
    Public m_Connection As String
    Public m_OwnerId As String

    Dim m_PathImg As String
    Dim m_FolderPath As String

    Dim m_shopName As String
    Dim m_shopAddress As String

    ' Property cho MstrConnection
    Public Property MstrConnection() As String
        Get
            Return m_Connection
        End Get
        Set(value As String)
            m_Connection = value
        End Set
    End Property

    ' Property cho MstrOwnerId
    Public Property MstrOwnerId() As String
        Get
            Return m_OwnerId
        End Get
        Set(value As String)
            m_OwnerId = value
        End Set
    End Property

    ' Property cho pathImg - đường dẫn ảnh - lưu vào đường dẫn của web để dùng được ảnh cho cả 2 bên
    Public Property pathImg() As String
        Get
            Return m_PathImg
        End Get
        Set(value As String)
            m_PathImg = value
        End Set
    End Property

    ' Property cho pathImg - đường dẫn ảnh - lưu vào đường dẫn của web để dùng được ảnh cho cả 2 bên
    Public Property folderPath() As String
        Get
            Return m_FolderPath
        End Get
        Set(value As String)
            m_FolderPath = value
        End Set
    End Property

    ' lấy thông tin của admin
    Public Property shopName() As String
        Get
            Return m_shopName
        End Get
        Set(value As String)
            m_shopName = value
        End Set
    End Property

    Public Property shopAddress() As String
        Get
            Return m_shopAddress
        End Get
        Set(value As String)
            m_shopAddress = value
        End Set
    End Property
End Module
