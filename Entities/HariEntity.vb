''' <summary>
''' Entity class untuk data Hari berdasarkan tbl_hari di database.
''' Menerapkan prinsip ENCAPSULATION, INHERITANCE, dan POLYMORPHISM.
''' </summary>
Public Class HariEntity
    Inherits EntityBase

#Region "Private Fields"
    ''' <summary>
    ''' ID hari sebagai Primary Key, maksimal 5 karakter.
    ''' </summary>
    Private _idHari As String = ""

    ''' <summary>
    ''' Nama hari yang bersifat unique, maksimal 120 karakter.
    ''' </summary>
    Private _namaHari As String = ""
#End Region

#Region "Properties"
    ''' <summary>
    ''' ID Hari sebagai Primary Key dengan maksimal 5 karakter.
    ''' </summary>
    ''' <returns>String berisi ID hari</returns>
    Public Overrides Property Kode As String
        Get
            Return _idHari
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("ID Hari tidak boleh kosong!")
            End If
            If value.Length > 5 Then
                Throw New ArgumentException("ID Hari maksimal 5 karakter!")
            End If
            _idHari = value.Trim().ToUpper()
        End Set
    End Property

    ''' <summary>
    ''' Nama Hari dengan maksimal 120 karakter.
    ''' </summary>
    ''' <returns>String berisi nama hari</returns>
    Public Property NamaHari As String
        Get
            Return _namaHari
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Nama Hari tidak boleh kosong!")
            End If
            If value.Length > 120 Then
                Throw New ArgumentException("Nama Hari maksimal 120 karakter!")
            End If
            _namaHari = value.Trim().ToUpper()
        End Set
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Nama untuk ditampilkan di komponen UI.
    ''' </summary>
    ''' <returns>String berisi nama hari</returns>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return _namaHari
        End Get
    End Property

    ''' <summary>
    ''' Melakukan validasi entity Hari sesuai constraint database.
    ''' </summary>
    Protected Overrides Sub ValidateEntity()
        ValidateRequired(_idHari, "ID Hari")
        ValidateRequired(_namaHari, "Nama Hari")

        If _idHari.Length > 5 Then AddError("ID Hari maksimal 5 karakter!")
        If _namaHari.Length > 120 Then AddError("Nama Hari maksimal 120 karakter!")
    End Sub
#End Region

End Class
