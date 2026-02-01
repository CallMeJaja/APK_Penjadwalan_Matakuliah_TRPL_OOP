''' <summary>
''' Entity class untuk data Dosen Pengampu Matakuliah berdasarkan tbl_dosen_pengampu_matkul di database.
''' Menerapkan prinsip ENCAPSULATION, INHERITANCE, dan POLYMORPHISM.
''' </summary>
Public Class PengampuEntity
    Inherits EntityBase

#Region "Private Fields"
    ''' <summary>
    ''' Kode pengampu sebagai Primary Key, maksimal 7 karakter.
    ''' </summary>
    Private _kdPengampu As String = ""

    ''' <summary>
    ''' Kode dosen sebagai Foreign Key, maksimal 6 karakter.
    ''' </summary>
    Private _kdDosen As String = ""

    ''' <summary>
    ''' Kode matakuliah sebagai Foreign Key, maksimal 7 karakter.
    ''' </summary>
    Private _kdMatkul As String = ""

    ''' <summary>
    ''' Nama kelas untuk identifikasi kelas paralel, maksimal 120 karakter.
    ''' </summary>
    Private _namaKelas As String = ""

    ''' <summary>
    ''' Tahun akademik dalam format YYYY/YYYY, maksimal 11 karakter.
    ''' </summary>
    Private _tahunAkademik As String = ""
#End Region

#Region "Properties"
    ''' <summary>
    ''' Kode Pengampu sebagai Primary Key dengan maksimal 7 karakter.
    ''' </summary>
    ''' <returns>String berisi kode pengampu dalam format uppercase</returns>
    Public Overrides Property Kode As String
        Get
            Return _kdPengampu
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Kode Pengampu tidak boleh kosong!")
            End If
            If value.Length > 7 Then
                Throw New ArgumentException("Kode Pengampu maksimal 7 karakter!")
            End If
            _kdPengampu = value.Trim().ToUpper()
        End Set
    End Property

    ''' <summary>
    ''' Kode Dosen sebagai Foreign Key dengan maksimal 6 karakter.
    ''' </summary>
    ''' <returns>String berisi kode dosen</returns>
    Public Property KdDosen As String
        Get
            Return _kdDosen
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Dosen wajib dipilih!")
            End If
            If value.Length > 6 Then
                Throw New ArgumentException("Kode Dosen maksimal 6 karakter!")
            End If
            _kdDosen = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Kode Matakuliah sebagai Foreign Key dengan maksimal 7 karakter.
    ''' </summary>
    ''' <returns>String berisi kode matakuliah</returns>
    Public Property KdMatkul As String
        Get
            Return _kdMatkul
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Matakuliah wajib dipilih!")
            End If
            If value.Length > 7 Then
                Throw New ArgumentException("Kode Matakuliah maksimal 7 karakter!")
            End If
            _kdMatkul = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Nama Kelas untuk identifikasi kelas paralel dengan maksimal 120 karakter.
    ''' </summary>
    ''' <returns>String berisi nama kelas</returns>
    Public Property NamaKelas As String
        Get
            Return _namaKelas
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Nama Kelas tidak boleh kosong!")
            End If
            If value.Length > 120 Then
                Throw New ArgumentException("Nama Kelas maksimal 120 karakter!")
            End If
            _namaKelas = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Tahun Akademik dalam format YYYY/YYYY dengan maksimal 11 karakter.
    ''' </summary>
    ''' <returns>String berisi tahun akademik</returns>
    Public Property TahunAkademik As String
        Get
            Return _tahunAkademik
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Tahun Akademik tidak boleh kosong!")
            End If
            If value.Length > 11 Then
                Throw New ArgumentException("Tahun Akademik maksimal 11 karakter!")
            End If
            _tahunAkademik = value.Trim()
        End Set
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Nama untuk ditampilkan di komponen UI dalam format Kode Matakuliah - Nama Kelas.
    ''' </summary>
    ''' <returns>String berisi informasi display</returns>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return $"{_kdMatkul} - {_namaKelas}"
        End Get
    End Property

    ''' <summary>
    ''' Melakukan validasi entity Pengampu sesuai constraint database.
    ''' </summary>
    Protected Overrides Sub ValidateEntity()
        ValidateRequired(_kdPengampu, "Kode Pengampu")
        ValidateRequired(_kdDosen, "Dosen")
        ValidateRequired(_kdMatkul, "Matakuliah")
        ValidateRequired(_namaKelas, "Nama Kelas")
        ValidateRequired(_tahunAkademik, "Tahun Akademik")

        If _kdPengampu.Length > 7 Then AddError("Kode Pengampu maksimal 7 karakter!")
        If _kdDosen.Length > 6 Then AddError("Kode Dosen maksimal 6 karakter!")
        If _kdMatkul.Length > 7 Then AddError("Kode Matakuliah maksimal 7 karakter!")
        If _namaKelas.Length > 120 Then AddError("Nama Kelas maksimal 120 karakter!")
        If _tahunAkademik.Length > 11 Then AddError("Tahun Akademik maksimal 11 karakter!")
    End Sub

    ''' <summary>
    ''' Menghasilkan informasi display dalam format lengkap.
    ''' </summary>
    ''' <returns>String berisi informasi pengampu lengkap</returns>
    Public Overrides Function GetDisplayInfo() As String
        Return $"{_kdPengampu} - {_kdMatkul} ({_namaKelas}) - {_tahunAkademik}"
    End Function
#End Region

End Class
