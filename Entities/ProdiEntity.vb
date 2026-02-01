''' <summary>
''' Entity class untuk data Program Studi berdasarkan tbl_prodi di database.
''' Menerapkan prinsip ENCAPSULATION, INHERITANCE, dan POLYMORPHISM.
''' </summary>
Public Class ProdiEntity
    Inherits EntityBase

#Region "Private Fields"
    ''' <summary>
    ''' Kode program studi sebagai Primary Key, maksimal 5 karakter.
    ''' </summary>
    Private _kdProdi As String = ""

    ''' <summary>
    ''' Nama program studi yang bersifat unique, maksimal 120 karakter.
    ''' </summary>
    Private _namaProdi As String = ""
#End Region

#Region "Properties"
    ''' <summary>
    ''' Kode Program Studi sebagai Primary Key dengan maksimal 5 karakter.
    ''' </summary>
    ''' <returns>String berisi kode prodi dalam format uppercase</returns>
    Public Overrides Property Kode As String
        Get
            Return _kdProdi
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Kode Prodi tidak boleh kosong!")
            End If
            If value.Length > 5 Then
                Throw New ArgumentException("Kode Prodi maksimal 5 karakter!")
            End If
            _kdProdi = value.Trim().ToUpper()
        End Set
    End Property

    ''' <summary>
    ''' Nama Program Studi dengan maksimal 120 karakter.
    ''' </summary>
    ''' <returns>String berisi nama prodi</returns>
    Public Property NamaProdi As String
        Get
            Return _namaProdi
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Nama Prodi tidak boleh kosong!")
            End If
            If value.Length > 120 Then
                Throw New ArgumentException("Nama Prodi maksimal 120 karakter!")
            End If
            _namaProdi = value.Trim()
        End Set
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Nama untuk ditampilkan di komponen UI.
    ''' </summary>
    ''' <returns>String berisi nama prodi</returns>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return _namaProdi
        End Get
    End Property

    ''' <summary>
    ''' Melakukan validasi entity Prodi sesuai constraint database.
    ''' </summary>
    Protected Overrides Sub ValidateEntity()
        ValidateRequired(_kdProdi, "Kode Prodi")
        ValidateRequired(_namaProdi, "Nama Prodi")

        If _kdProdi.Length > 5 Then AddError("Kode Prodi maksimal 5 karakter!")
        If _namaProdi.Length > 120 Then AddError("Nama Prodi maksimal 120 karakter!")
    End Sub
#End Region

End Class
