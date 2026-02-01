''' <summary>
''' Entity class untuk data Ruang Kelas berdasarkan tbl_ruangkelas di database.
''' Menerapkan prinsip ENCAPSULATION, INHERITANCE, dan POLYMORPHISM.
''' </summary>
Public Class RuangkelasEntity
    Inherits EntityBase

#Region "Private Fields"
    ''' <summary>
    ''' Kode ruangan sebagai Primary Key, maksimal 5 karakter.
    ''' </summary>
    Private _kdRuangan As String = ""

    ''' <summary>
    ''' Nama ruangan yang bersifat unique, maksimal 120 karakter.
    ''' </summary>
    Private _namaRuangan As String = ""

    ''' <summary>
    ''' Kapasitas ruangan dalam jumlah kursi.
    ''' </summary>
    Private _kapasitas As Integer = 0
#End Region

#Region "Properties"
    ''' <summary>
    ''' Kode Ruangan sebagai Primary Key dengan maksimal 5 karakter.
    ''' </summary>
    ''' <returns>String berisi kode ruangan dalam format uppercase</returns>
    Public Overrides Property Kode As String
        Get
            Return _kdRuangan
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Kode Ruangan tidak boleh kosong!")
            End If
            If value.Length > 5 Then
                Throw New ArgumentException("Kode Ruangan maksimal 5 karakter!")
            End If
            _kdRuangan = value.Trim().ToUpper()
        End Set
    End Property

    ''' <summary>
    ''' Nama Ruangan dengan maksimal 120 karakter.
    ''' </summary>
    ''' <returns>String berisi nama ruangan</returns>
    Public Property NamaRuangan As String
        Get
            Return _namaRuangan
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Nama Ruangan tidak boleh kosong!")
            End If
            If value.Length > 120 Then
                Throw New ArgumentException("Nama Ruangan maksimal 120 karakter!")
            End If
            _namaRuangan = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Kapasitas ruangan yang harus lebih dari 0.
    ''' </summary>
    ''' <returns>Integer berisi jumlah kapasitas</returns>
    Public Property Kapasitas As Integer
        Get
            Return _kapasitas
        End Get
        Set(value As Integer)
            If value <= 0 Then
                Throw New ArgumentException("Kapasitas harus lebih dari 0!")
            End If
            _kapasitas = value
        End Set
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Nama untuk ditampilkan di komponen UI.
    ''' </summary>
    ''' <returns>String berisi nama ruangan</returns>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return _namaRuangan
        End Get
    End Property

    ''' <summary>
    ''' Melakukan validasi entity Ruangkelas sesuai constraint database.
    ''' </summary>
    Protected Overrides Sub ValidateEntity()
        ValidateRequired(_kdRuangan, "Kode Ruangan")
        ValidateRequired(_namaRuangan, "Nama Ruangan")

        If _kdRuangan.Length > 5 Then AddError("Kode Ruangan maksimal 5 karakter!")
        If _namaRuangan.Length > 120 Then AddError("Nama Ruangan maksimal 120 karakter!")
        If _kapasitas <= 0 Then AddError("Kapasitas harus lebih dari 0!")
    End Sub

    ''' <summary>
    ''' Menghasilkan informasi display dalam format Nama Ruangan (Kapasitas).
    ''' </summary>
    ''' <returns>String berisi informasi ruangan lengkap</returns>
    Public Overrides Function GetDisplayInfo() As String
        Return $"{_namaRuangan} (Kapasitas: {_kapasitas})"
    End Function
#End Region

End Class
