''' <summary>
''' Entity class untuk data Matakuliah berdasarkan tbl_matakuliah di database.
''' Menerapkan prinsip ENCAPSULATION dengan Private fields dan Property dengan validasi,
''' INHERITANCE dari EntityBase, dan POLYMORPHISM melalui override method.
''' Menyediakan business logic untuk perhitungan SKS dan durasi kuliah.
''' </summary>
Public Class MatakuliahEntity
    Inherits EntityBase

#Region "Private Fields"
    ''' <summary>
    ''' Kode matakuliah sebagai Primary Key, maksimal 7 karakter.
    ''' </summary>
    Private _kdMatkul As String = ""

    ''' <summary>
    ''' Nama matakuliah yang bersifat unique, maksimal 120 karakter.
    ''' </summary>
    Private _namaMatkul As String = ""

    ''' <summary>
    ''' Jumlah SKS teori untuk matakuliah ini.
    ''' </summary>
    Private _teoriMatkul As Integer = 0

    ''' <summary>
    ''' Jumlah SKS praktek untuk matakuliah ini.
    ''' </summary>
    Private _praktekMatkul As Integer = 0

    ''' <summary>
    ''' Semester dimana matakuliah ini diajarkan, nilai 1-8.
    ''' </summary>
    Private _semesterMatkul As Integer = 1

    ''' <summary>
    ''' Kode program studi sebagai Foreign Key opsional, maksimal 7 karakter.
    ''' </summary>
    Private _kdProdi As String = ""
#End Region

#Region "Properties"
    ''' <summary>
    ''' Kode Matakuliah sebagai Primary Key dengan maksimal 7 karakter.
    ''' </summary>
    ''' <returns>String berisi kode matakuliah dalam format uppercase</returns>
    Public Overrides Property Kode As String
        Get
            Return _kdMatkul
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Kode Matakuliah tidak boleh kosong!")
            End If
            If value.Length > 7 Then
                Throw New ArgumentException("Kode Matakuliah maksimal 7 karakter!")
            End If
            _kdMatkul = value.Trim().ToUpper()
        End Set
    End Property

    ''' <summary>
    ''' Nama Matakuliah dengan maksimal 120 karakter.
    ''' </summary>
    ''' <returns>String berisi nama matakuliah</returns>
    Public Property NamaMatkul As String
        Get
            Return _namaMatkul
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Nama Matakuliah tidak boleh kosong!")
            End If
            If value.Length > 120 Then
                Throw New ArgumentException("Nama Matakuliah maksimal 120 karakter!")
            End If
            _namaMatkul = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Total SKS yang dihitung otomatis dari penjumlahan SKS teori dan praktek.
    ''' </summary>
    ''' <returns>Integer berisi total SKS</returns>
    Public ReadOnly Property SksMatkul As Integer
        Get
            Return _teoriMatkul + _praktekMatkul
        End Get
    End Property

    ''' <summary>
    ''' Jumlah SKS Teori yang tidak boleh negatif.
    ''' </summary>
    ''' <returns>Integer berisi jumlah SKS teori</returns>
    Public Property TeoriMatkul As Integer
        Get
            Return _teoriMatkul
        End Get
        Set(value As Integer)
            If value < 0 Then
                Throw New ArgumentException("SKS Teori tidak boleh negatif!")
            End If
            _teoriMatkul = value
        End Set
    End Property

    ''' <summary>
    ''' Jumlah SKS Praktek yang tidak boleh negatif.
    ''' </summary>
    ''' <returns>Integer berisi jumlah SKS praktek</returns>
    Public Property PraktekMatkul As Integer
        Get
            Return _praktekMatkul
        End Get
        Set(value As Integer)
            If value < 0 Then
                Throw New ArgumentException("SKS Praktek tidak boleh negatif!")
            End If
            _praktekMatkul = value
        End Set
    End Property

    ''' <summary>
    ''' Semester dimana matakuliah diajarkan dengan nilai 1 sampai 8.
    ''' </summary>
    ''' <returns>Integer berisi nomor semester</returns>
    Public Property SemesterMatkul As Integer
        Get
            Return _semesterMatkul
        End Get
        Set(value As Integer)
            If value < 1 OrElse value > 8 Then
                Throw New ArgumentException("Semester harus antara 1-8!")
            End If
            _semesterMatkul = value
        End Set
    End Property

    ''' <summary>
    ''' Kode Program Studi sebagai Foreign Key opsional dengan maksimal 7 karakter.
    ''' </summary>
    ''' <returns>String berisi kode prodi atau kosong jika tidak diset</returns>
    Public Property KdProdi As String
        Get
            Return _kdProdi
        End Get
        Set(value As String)
            If Not String.IsNullOrWhiteSpace(value) AndAlso value.Length > 7 Then
                Throw New ArgumentException("Kode Prodi maksimal 7 karakter!")
            End If
            _kdProdi = If(value, "").Trim()
        End Set
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Nama untuk ditampilkan di komponen UI.
    ''' </summary>
    ''' <returns>String berisi nama matakuliah</returns>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return _namaMatkul
        End Get
    End Property

    ''' <summary>
    ''' Melakukan validasi entity Matakuliah sesuai constraint database dan business rules.
    ''' </summary>
    Protected Overrides Sub ValidateEntity()
        ValidateRequired(_kdMatkul, "Kode Matakuliah")
        ValidateRequired(_namaMatkul, "Nama Matakuliah")

        ValidateRange(_semesterMatkul, 1, 8, "Semester")
        ValidateNonNegative(_teoriMatkul, "SKS Teori")
        ValidateNonNegative(_praktekMatkul, "SKS Praktek")

        If _kdMatkul.Length > 7 Then AddError("Kode Matakuliah maksimal 7 karakter!")
        If _namaMatkul.Length > 120 Then AddError("Nama Matakuliah maksimal 120 karakter!")

        If SksMatkul <= 0 Then
            AddError("Total SKS harus lebih dari 0!")
        End If
    End Sub

    ''' <summary>
    ''' Menghasilkan informasi display dalam format Kode - Nama (SKS).
    ''' </summary>
    ''' <returns>String berisi informasi matakuliah lengkap</returns>
    Public Overrides Function GetDisplayInfo() As String
        Return $"{_kdMatkul} - {_namaMatkul} ({SksMatkul} SKS)"
    End Function
#End Region

#Region "Business Methods"
    ''' <summary>
    ''' Menghitung durasi teori dalam menit dengan standar 50 menit per SKS.
    ''' </summary>
    ''' <returns>Integer berisi durasi teori dalam menit</returns>
    Public Function HitungDurasiTeori() As Integer
        Return _teoriMatkul * 50
    End Function

    ''' <summary>
    ''' Menghitung durasi praktek dalam menit dengan standar 170 menit per SKS.
    ''' </summary>
    ''' <returns>Integer berisi durasi praktek dalam menit</returns>
    Public Function HitungDurasiPraktek() As Integer
        Return _praktekMatkul * 170
    End Function

    ''' <summary>
    ''' Menghitung total durasi kuliah dalam menit dari penjumlahan teori dan praktek.
    ''' </summary>
    ''' <returns>Integer berisi total durasi dalam menit</returns>
    Public Function HitungTotalDurasi() As Integer
        Return HitungDurasiTeori() + HitungDurasiPraktek()
    End Function

    ''' <summary>
    ''' Menentukan tipe semester berdasarkan nomor semester (Ganjil/Genap).
    ''' </summary>
    ''' <returns>String "Ganjil" untuk semester ganjil atau "Genap" untuk semester genap</returns>
    Public Function GetTipeSemester() As String
        Return If(_semesterMatkul Mod 2 = 1, "Ganjil", "Genap")
    End Function
#End Region

End Class
