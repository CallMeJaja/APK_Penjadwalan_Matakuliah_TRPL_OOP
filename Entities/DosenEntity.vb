''' <summary>
''' Entity class untuk data Dosen berdasarkan tbl_dosen di database.
''' Menerapkan prinsip ENCAPSULATION dengan Private fields dan Property dengan validasi,
''' INHERITANCE dari EntityBase, dan POLYMORPHISM melalui override method.
''' </summary>
Public Class DosenEntity
    Inherits EntityBase

#Region "Private Fields"
    ''' <summary>
    ''' Kode dosen sebagai Primary Key, maksimal 6 karakter.
    ''' </summary>
    Private _kdDosen As String = ""

    ''' <summary>
    ''' Kode program studi sebagai Foreign Key, maksimal 5 karakter.
    ''' </summary>
    Private _kdProdi As String = ""

    ''' <summary>
    ''' NIDN dosen yang bersifat unique, harus tepat 10 digit.
    ''' </summary>
    Private _nidnDosen As String = ""

    ''' <summary>
    ''' Nama lengkap dosen yang bersifat unique, maksimal 120 karakter.
    ''' </summary>
    Private _namaDosen As String = ""

    ''' <summary>
    ''' Jenis kelamin dosen, hanya menerima LAKI-LAKI atau PEREMPUAN.
    ''' </summary>
    Private _jkDosen As String = ""

    ''' <summary>
    ''' Nomor telepon dosen yang bersifat unique dan opsional, maksimal 15 karakter.
    ''' </summary>
    Private _noTelpDosen As String = ""

    ''' <summary>
    ''' Email dosen yang bersifat unique dan opsional, maksimal 100 karakter.
    ''' </summary>
    Private _emailDosen As String = ""
#End Region

#Region "Properties"
    ''' <summary>
    ''' Kode Dosen sebagai Primary Key dengan maksimal 6 karakter.
    ''' </summary>
    ''' <returns>String berisi kode dosen</returns>
    Public Overrides Property Kode As String
        Get
            Return _kdDosen
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Kode Dosen tidak boleh kosong!")
            End If
            If value.Length > 6 Then
                Throw New ArgumentException("Kode Dosen maksimal 6 karakter!")
            End If
            _kdDosen = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Kode Program Studi sebagai Foreign Key dengan maksimal 5 karakter.
    ''' </summary>
    ''' <returns>String berisi kode prodi</returns>
    Public Property KdProdi As String
        Get
            Return _kdProdi
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Program Studi wajib dipilih!")
            End If
            If value.Length > 5 Then
                Throw New ArgumentException("Kode Prodi maksimal 5 karakter!")
            End If
            _kdProdi = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' NIDN Dosen yang harus tepat 10 digit.
    ''' </summary>
    ''' <returns>String berisi NIDN dosen</returns>
    Public Property NidnDosen As String
        Get
            Return _nidnDosen
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("NIDN tidak boleh kosong!")
            End If
            If value.Length <> 10 Then
                Throw New ArgumentException("NIDN harus tepat 10 digit!")
            End If
            _nidnDosen = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Nama lengkap Dosen dengan maksimal 120 karakter.
    ''' </summary>
    ''' <returns>String berisi nama dosen</returns>
    Public Property NamaDosen As String
        Get
            Return _namaDosen
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Nama Dosen tidak boleh kosong!")
            End If
            If value.Length > 120 Then
                Throw New ArgumentException("Nama Dosen maksimal 120 karakter!")
            End If
            _namaDosen = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Jenis Kelamin Dosen yang hanya menerima nilai LAKI-LAKI atau PEREMPUAN.
    ''' </summary>
    ''' <returns>String berisi jenis kelamin</returns>
    Public Property JkDosen As String
        Get
            Return _jkDosen
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Jenis Kelamin wajib dipilih!")
            End If
            Dim validValues = {"LAKI-LAKI", "PEREMPUAN"}
            If Not validValues.Contains(value.ToUpper()) Then
                Throw New ArgumentException("Jenis Kelamin harus LAKI-LAKI atau PEREMPUAN!")
            End If
            _jkDosen = value.ToUpper()
        End Set
    End Property

    ''' <summary>
    ''' Nomor Telepon Dosen yang bersifat opsional dengan maksimal 15 karakter.
    ''' </summary>
    ''' <returns>String berisi nomor telepon atau kosong jika tidak diisi</returns>
    Public Property NoTelpDosen As String
        Get
            Return _noTelpDosen
        End Get
        Set(value As String)
            If Not String.IsNullOrWhiteSpace(value) AndAlso value.Length > 15 Then
                Throw New ArgumentException("Nomor Telepon maksimal 15 karakter!")
            End If
            _noTelpDosen = If(value, "").Trim()
        End Set
    End Property

    ''' <summary>
    ''' Email Dosen yang bersifat opsional dengan maksimal 100 karakter dan format valid.
    ''' </summary>
    ''' <returns>String berisi email atau kosong jika tidak diisi</returns>
    Public Property EmailDosen As String
        Get
            Return _emailDosen
        End Get
        Set(value As String)
            If Not String.IsNullOrWhiteSpace(value) Then
                If value.Length > 100 Then
                    Throw New ArgumentException("Email maksimal 100 karakter!")
                End If
                If Not value.Contains("@") OrElse Not value.Contains(".") Then
                    Throw New ArgumentException("Format email tidak valid!")
                End If
            End If
            _emailDosen = If(value, "").Trim().ToLower()
        End Set
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Nama untuk ditampilkan di komponen UI.
    ''' </summary>
    ''' <returns>String berisi nama dosen</returns>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return _namaDosen
        End Get
    End Property

    ''' <summary>
    ''' Melakukan validasi entity Dosen sesuai constraint database.
    ''' </summary>
    Protected Overrides Sub ValidateEntity()
        ValidateRequired(_kdDosen, "Kode Dosen")
        ValidateRequired(_kdProdi, "Program Studi")
        ValidateRequired(_nidnDosen, "NIDN")
        ValidateRequired(_namaDosen, "Nama Dosen")
        ValidateRequired(_jkDosen, "Jenis Kelamin")

        If _kdDosen.Length > 6 Then AddError("Kode Dosen maksimal 6 karakter!")
        If _kdProdi.Length > 5 Then AddError("Kode Prodi maksimal 5 karakter!")
        If _nidnDosen.Length <> 10 Then AddError("NIDN harus tepat 10 digit!")
        If _namaDosen.Length > 120 Then AddError("Nama Dosen maksimal 120 karakter!")
    End Sub

    ''' <summary>
    ''' Menghasilkan informasi display dalam format NIDN - Nama Dosen.
    ''' </summary>
    ''' <returns>String berisi informasi dosen</returns>
    Public Overrides Function GetDisplayInfo() As String
        Return $"{_nidnDosen} - {_namaDosen}"
    End Function
#End Region

#Region "Business Methods"
    ''' <summary>
    ''' Menghasilkan tampilan jenis kelamin yang lebih mudah dibaca.
    ''' </summary>
    ''' <returns>String "Laki-laki" atau "Perempuan"</returns>
    Public Function GetGenderDisplay() As String
        Return If(_jkDosen = "LAKI-LAKI", "Laki-laki", "Perempuan")
    End Function
#End Region

End Class
