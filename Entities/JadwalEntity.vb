''' <summary>
''' Entity class untuk data Jadwal Matakuliah berdasarkan tbl_jadwal_matkul di database.
''' Menerapkan prinsip ENCAPSULATION, INHERITANCE, dan POLYMORPHISM.
''' </summary>
Public Class JadwalEntity
    Inherits EntityBase

#Region "Private Fields"
    ''' <summary>
    ''' Kode pengampu sebagai Primary Key dan Foreign Key, maksimal 7 karakter.
    ''' </summary>
    Private _kdPengampu As String = ""

    ''' <summary>
    ''' ID hari sebagai Foreign Key, maksimal 5 karakter.
    ''' </summary>
    Private _idHari As String = ""

    ''' <summary>
    ''' Jam mulai kuliah dalam format TimeSpan.
    ''' </summary>
    Private _jamAwal As TimeSpan

    ''' <summary>
    ''' Jam selesai kuliah dalam format TimeSpan.
    ''' </summary>
    Private _jamAkhir As TimeSpan

    ''' <summary>
    ''' Kode ruangan sebagai Foreign Key, maksimal 5 karakter.
    ''' </summary>
    Private _kdRuangan As String = ""
#End Region

#Region "Properties"
    ''' <summary>
    ''' Kode Pengampu sebagai Primary Key dan Foreign Key dengan maksimal 7 karakter.
    ''' </summary>
    ''' <returns>String berisi kode pengampu</returns>
    Public Overrides Property Kode As String
        Get
            Return _kdPengampu
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Pengampu wajib dipilih!")
            End If
            If value.Length > 7 Then
                Throw New ArgumentException("Kode Pengampu maksimal 7 karakter!")
            End If
            _kdPengampu = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' ID Hari sebagai Foreign Key dengan maksimal 5 karakter.
    ''' </summary>
    ''' <returns>String berisi ID hari</returns>
    Public Property IdHari As String
        Get
            Return _idHari
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Hari wajib dipilih!")
            End If
            If value.Length > 5 Then
                Throw New ArgumentException("ID Hari maksimal 5 karakter!")
            End If
            _idHari = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Jam mulai kuliah dalam format TimeSpan.
    ''' </summary>
    ''' <returns>TimeSpan berisi jam mulai</returns>
    Public Property JamAwal As TimeSpan
        Get
            Return _jamAwal
        End Get
        Set(value As TimeSpan)
            _jamAwal = value
        End Set
    End Property

    ''' <summary>
    ''' Jam selesai kuliah yang harus lebih besar dari jam awal.
    ''' </summary>
    ''' <returns>TimeSpan berisi jam selesai</returns>
    Public Property JamAkhir As TimeSpan
        Get
            Return _jamAkhir
        End Get
        Set(value As TimeSpan)
            If value <= _jamAwal Then
                Throw New ArgumentException("Jam Akhir harus setelah Jam Awal!")
            End If
            _jamAkhir = value
        End Set
    End Property

    ''' <summary>
    ''' Kode Ruangan sebagai Foreign Key dengan maksimal 5 karakter.
    ''' </summary>
    ''' <returns>String berisi kode ruangan</returns>
    Public Property KdRuangan As String
        Get
            Return _kdRuangan
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Ruangan wajib dipilih!")
            End If
            If value.Length > 5 Then
                Throw New ArgumentException("Kode Ruangan maksimal 5 karakter!")
            End If
            _kdRuangan = value.Trim()
        End Set
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Nama untuk ditampilkan di komponen UI dalam format Hari Waktu.
    ''' </summary>
    ''' <returns>String berisi informasi jadwal</returns>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return $"{_idHari} {_jamAwal:hh\:mm}-{_jamAkhir:hh\:mm}"
        End Get
    End Property

    ''' <summary>
    ''' Melakukan validasi entity Jadwal sesuai constraint database.
    ''' </summary>
    Protected Overrides Sub ValidateEntity()
        ValidateRequired(_kdPengampu, "Pengampu")
        ValidateRequired(_idHari, "Hari")
        ValidateRequired(_kdRuangan, "Ruangan")

        If _kdPengampu.Length > 7 Then AddError("Kode Pengampu maksimal 7 karakter!")
        If _idHari.Length > 5 Then AddError("ID Hari maksimal 5 karakter!")
        If _kdRuangan.Length > 5 Then AddError("Kode Ruangan maksimal 5 karakter!")

        If _jamAkhir <= _jamAwal Then
            AddError("Jam Akhir harus setelah Jam Awal!")
        End If
    End Sub

    ''' <summary>
    ''' Menghasilkan informasi display dalam format Hari Waktu di Ruangan.
    ''' </summary>
    ''' <returns>String berisi informasi jadwal lengkap</returns>
    Public Overrides Function GetDisplayInfo() As String
        Return $"{_idHari} {_jamAwal:hh\:mm}-{_jamAkhir:hh\:mm} di {_kdRuangan}"
    End Function
#End Region

#Region "Business Methods"
    ''' <summary>
    ''' Menghitung durasi jadwal dalam satuan menit.
    ''' </summary>
    ''' <returns>Integer berisi durasi dalam menit</returns>
    Public Function HitungDurasi() As Integer
        Return CInt((_jamAkhir - _jamAwal).TotalMinutes)
    End Function

    ''' <summary>
    ''' Memeriksa apakah jadwal ini bentrok waktu dengan jadwal lain di hari yang sama.
    ''' </summary>
    ''' <param name="other">Entity jadwal lain yang akan dibandingkan</param>
    ''' <returns>True jika terjadi bentrok waktu, False jika tidak</returns>
    Public Function IsBentrokWaktu(other As JadwalEntity) As Boolean
        If _idHari <> other.IdHari Then Return False
        Return _jamAwal < other.JamAkhir AndAlso _jamAkhir > other.JamAwal
    End Function

    ''' <summary>
    ''' Memeriksa apakah jadwal ini bentrok ruangan dengan jadwal lain.
    ''' </summary>
    ''' <param name="other">Entity jadwal lain yang akan dibandingkan</param>
    ''' <returns>True jika terjadi bentrok ruangan, False jika tidak</returns>
    Public Function IsBentrokRuangan(other As JadwalEntity) As Boolean
        If _kdRuangan <> other.KdRuangan Then Return False
        Return IsBentrokWaktu(other)
    End Function
#End Region

End Class
