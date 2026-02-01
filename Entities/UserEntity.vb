''' <summary>
''' Entity class untuk data User berdasarkan tbl_user di database.
''' Menerapkan prinsip ENCAPSULATION, INHERITANCE, dan POLYMORPHISM.
''' </summary>
Public Class UserEntity
    Inherits EntityBase

#Region "Private Fields"
    ''' <summary>
    ''' ID user sebagai Primary Key, maksimal 8 karakter.
    ''' </summary>
    Private _idUser As String = ""

    ''' <summary>
    ''' Nama user yang bersifat unique, maksimal 120 karakter.
    ''' </summary>
    Private _namaUser As String = ""

    ''' <summary>
    ''' Password user, maksimal 6 karakter.
    ''' </summary>
    Private _passUser As String = ""

    ''' <summary>
    ''' Level akses user, hanya menerima Administrator atau Dosen.
    ''' </summary>
    Private _levelUser As String = ""
#End Region

#Region "Properties"
    ''' <summary>
    ''' ID User sebagai Primary Key dengan maksimal 8 karakter.
    ''' </summary>
    ''' <returns>String berisi ID user</returns>
    Public Overrides Property Kode As String
        Get
            Return _idUser
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("ID User tidak boleh kosong!")
            End If
            If value.Length > 8 Then
                Throw New ArgumentException("ID User maksimal 8 karakter!")
            End If
            _idUser = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Nama User dengan maksimal 120 karakter.
    ''' </summary>
    ''' <returns>String berisi nama user</returns>
    Public Property NamaUser As String
        Get
            Return _namaUser
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Nama User tidak boleh kosong!")
            End If
            If value.Length > 120 Then
                Throw New ArgumentException("Nama User maksimal 120 karakter!")
            End If
            _namaUser = value.Trim()
        End Set
    End Property

    ''' <summary>
    ''' Password User dengan maksimal 6 karakter.
    ''' Password bersifat opsional untuk mode edit.
    ''' </summary>
    ''' <returns>String berisi password atau kosong</returns>
    Public Property PassUser As String
        Get
            Return _passUser
        End Get
        Set(value As String)
            If Not String.IsNullOrEmpty(value) Then
                If value.Length > 6 Then
                    Throw New ArgumentException("Password maksimal 6 karakter!")
                End If
            End If
            _passUser = If(value, "")
        End Set
    End Property

    ''' <summary>
    ''' Level akses User yang hanya menerima nilai Administrator atau Dosen.
    ''' </summary>
    ''' <returns>String berisi level user</returns>
    Public Property LevelUser As String
        Get
            Return _levelUser
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Level User tidak boleh kosong!")
            End If
            Dim validLevels As String() = {"Administrator", "Dosen"}
            If Not validLevels.Contains(value, StringComparer.OrdinalIgnoreCase) Then
                Throw New ArgumentException("Level User harus Administrator atau Dosen!")
            End If
            _levelUser = value.Trim()
        End Set
    End Property
#End Region

#Region "Override Methods"
    ''' <summary>
    ''' Nama untuk ditampilkan di komponen UI.
    ''' </summary>
    ''' <returns>String berisi nama user</returns>
    Public Overrides ReadOnly Property DisplayName As String
        Get
            Return _namaUser
        End Get
    End Property

    ''' <summary>
    ''' Melakukan validasi entity User sesuai constraint database.
    ''' Password bersifat opsional untuk mode edit dan divalidasi di form.
    ''' </summary>
    Protected Overrides Sub ValidateEntity()
        ValidateRequired(_idUser, "ID User")
        ValidateRequired(_namaUser, "Nama User")
        ValidateRequired(_levelUser, "Level User")

        If _idUser.Length > 8 Then AddError("ID User maksimal 8 karakter!")
        If _namaUser.Length > 120 Then AddError("Nama User maksimal 120 karakter!")
        If _passUser.Length > 6 Then AddError("Password maksimal 6 karakter!")
        If _levelUser.Length > 80 Then AddError("Level User maksimal 80 karakter!")
    End Sub

    ''' <summary>
    ''' Menghasilkan informasi display dalam format Nama User (Level).
    ''' </summary>
    ''' <returns>String berisi informasi user lengkap</returns>
    Public Overrides Function GetDisplayInfo() As String
        Return $"{_namaUser} ({_levelUser})"
    End Function
#End Region

#Region "Business Methods"
    ''' <summary>
    ''' Memeriksa apakah user memiliki level Administrator.
    ''' </summary>
    ''' <returns>True jika user adalah Administrator, False jika bukan</returns>
    Public Function IsAdministrator() As Boolean
        Return _levelUser.Equals("Administrator", StringComparison.OrdinalIgnoreCase)
    End Function
#End Region

End Class
