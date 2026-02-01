''' <summary>
''' Module untuk mengelola session user yang sedang login.
''' Menyimpan informasi user aktif dan menyediakan fungsi-fungsi terkait otorisasi.
''' </summary>
Module ModSesi

#Region "Session Variables"
    ''' <summary>
    ''' ID user yang sedang login
    ''' </summary>
    Public CurrentUserId As String = ""

    ''' <summary>
    ''' Nama user yang sedang login
    ''' </summary>
    Public CurrentUserName As String = ""

    ''' <summary>
    ''' Level/role user yang sedang login (Administrator atau Dosen).
    ''' </summary>
    Public CurrentLevel As String = ""

    ''' <summary>
    ''' Waktu login user
    ''' </summary>
    Public LoginTime As DateTime = Nothing
#End Region

#Region "Session Management"
    ''' <summary>
    ''' Set session setelah login berhasil.
    ''' </summary>
    ''' <param name="userId">ID user</param>
    ''' <param name="userName">Nama user</param>
    ''' <param name="level">Level/role user</param>
    Public Sub SetSession(userId As String, userName As String, level As String)
        CurrentUserId = userId
        CurrentUserName = userName
        CurrentLevel = level
        LoginTime = DateTime.Now
    End Sub

    ''' <summary>
    ''' Hapus session saat logout.
    ''' </summary>
    Public Sub ClearSession()
        CurrentUserId = ""
        CurrentUserName = ""
        CurrentLevel = ""
        LoginTime = Nothing
    End Sub

    ''' <summary>
    ''' Mengecek apakah user sudah login.
    ''' </summary>
    ''' <returns>True jika sudah login, False jika belum</returns>
    Public Function IsLoggedIn() As Boolean
        Return Not String.IsNullOrEmpty(CurrentUserId)
    End Function
#End Region

#Region "Authorization"
    ''' <summary>
    ''' Mengecek apakah user yang login adalah Administrator.
    ''' </summary>
    ''' <returns>True jika Administrator</returns>
    Public Function IsAdmin() As Boolean
        Return CurrentLevel.Equals("Administrator", StringComparison.OrdinalIgnoreCase)
    End Function

    ''' <summary>
    ''' Mengecek apakah user yang login adalah Dosen.
    ''' </summary>
    ''' <returns>True jika Dosen</returns>
    Public Function IsDosen() As Boolean
        Return CurrentLevel.Equals("Dosen", StringComparison.OrdinalIgnoreCase)
    End Function

    ''' <summary>
    ''' Mengecek apakah user memiliki level tertentu.
    ''' </summary>
    ''' <param name="level">Level yang dicek</param>
    ''' <returns>True jika sesuai</returns>
    Public Function HasLevel(level As String) As Boolean
        Return CurrentLevel.Equals(level, StringComparison.OrdinalIgnoreCase)
    End Function

    ''' <summary>
    ''' Mengecek apakah user memiliki salah satu dari level yang diberikan.
    ''' </summary>
    ''' <param name="levels">Array level yang diizinkan</param>
    ''' <returns>True jika user memiliki salah satu level</returns>
    Public Function HasAnyLevel(ParamArray levels() As String) As Boolean
        For Each level As String In levels
            If CurrentLevel.Equals(level, StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region

#Region "Session Info"
    ''' <summary>
    ''' Mendapatkan durasi login dalam format yang mudah dibaca.
    ''' </summary>
    ''' <returns>String durasi (contoh: "2 jam 30 menit")</returns>
    Public Function GetLoginDuration() As String
        If LoginTime = Nothing Then Return ""

        Dim duration As TimeSpan = DateTime.Now - LoginTime
        If duration.TotalHours >= 1 Then
            Return $"{Math.Floor(duration.TotalHours)} jam {duration.Minutes} menit"
        Else
            Return $"{duration.Minutes} menit"
        End If
    End Function

    ''' <summary>
    ''' Mendapatkan waktu login dalam format string.
    ''' </summary>
    Public Function GetLoginTimeString() As String
        If LoginTime = Nothing Then Return ""
        Return LoginTime.ToString("dd/MM/yyyy HH:mm:ss")
    End Function

    ''' <summary>
    ''' Mendapatkan informasi session lengkap untuk ditampilkan.
    ''' </summary>
    Public Function GetSessionInfo() As String
        If Not IsLoggedIn() Then Return "Belum login"
        Return $"User: {CurrentUserName} | Level: {CurrentLevel}"
    End Function
#End Region

End Module
