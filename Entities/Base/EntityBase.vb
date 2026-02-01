''' <summary>
''' Kelas abstrak dasar untuk semua entity dalam sistem.
''' Mengimplementasikan IEntity dan menyediakan fungsionalitas validasi umum.
''' Menerapkan prinsip ABSTRACTION (MustInherit) dan INHERITANCE untuk OOP.
''' </summary>
Public MustInherit Class EntityBase
    Implements IEntity

    ''' <summary>
    ''' Daftar pesan error validasi yang dikumpulkan saat proses validasi.
    ''' </summary>
    Protected _validationErrors As New List(Of String)

#Region "Abstract Properties"
    ''' <summary>
    ''' Kode/ID unik entity. Wajib di-override oleh child class.
    ''' </summary>
    Public MustOverride Property Kode As String

    ''' <summary>
    ''' Nama entity untuk ditampilkan di UI. Wajib di-override oleh child class.
    ''' </summary>
    Public MustOverride ReadOnly Property DisplayName As String
#End Region

#Region "Abstract Methods"
    ''' <summary>
    ''' Melakukan validasi spesifik untuk entity.
    ''' Wajib di-override oleh child class untuk implementasi validasi sesuai kebutuhan.
    ''' </summary>
    Protected MustOverride Sub ValidateEntity()
#End Region

#Region "IEntity Implementation"
    ''' <summary>
    ''' Memeriksa apakah entity valid berdasarkan aturan validasi yang ditentukan.
    ''' </summary>
    ''' <returns>True jika entity valid, False jika terdapat error validasi</returns>
    Public Function IsValid() As Boolean Implements IEntity.IsValid
        _validationErrors.Clear()
        ValidateEntity()
        Return _validationErrors.Count = 0
    End Function

    ''' <summary>
    ''' Mengambil daftar pesan error validasi yang ditemukan.
    ''' </summary>
    ''' <returns>List berisi pesan-pesan error validasi</returns>
    Public Function GetValidationErrors() As List(Of String) Implements IEntity.GetValidationErrors
        Return _validationErrors
    End Function

    ''' <summary>
    ''' Menghasilkan informasi display untuk ditampilkan di UI.
    ''' Dapat di-override untuk kustomisasi format tampilan.
    ''' </summary>
    ''' <returns>String berisi informasi display dalam format "Kode - DisplayName"</returns>
    Public Overridable Function GetDisplayInfo() As String Implements IEntity.GetDisplayInfo
        Return $"{Kode} - {DisplayName}"
    End Function
#End Region

#Region "Helper Methods"
    ''' <summary>
    ''' Menambahkan pesan error ke daftar validasi.
    ''' </summary>
    ''' <param name="message">Pesan error yang akan ditambahkan</param>
    Protected Sub AddError(message As String)
        _validationErrors.Add(message)
    End Sub

    ''' <summary>
    ''' Memvalidasi bahwa field wajib tidak boleh kosong.
    ''' </summary>
    ''' <param name="value">Nilai yang akan divalidasi</param>
    ''' <param name="fieldName">Nama field untuk pesan error</param>
    ''' <returns>True jika valid, False jika kosong</returns>
    Protected Function ValidateRequired(value As String, fieldName As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then
            AddError($"{fieldName} wajib diisi!")
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Memvalidasi bahwa nilai berada dalam rentang yang ditentukan.
    ''' </summary>
    ''' <param name="value">Nilai yang akan divalidasi</param>
    ''' <param name="minVal">Nilai minimum yang diperbolehkan</param>
    ''' <param name="maxVal">Nilai maksimum yang diperbolehkan</param>
    ''' <param name="fieldName">Nama field untuk pesan error</param>
    ''' <returns>True jika valid, False jika di luar rentang</returns>
    Protected Function ValidateRange(value As Integer, minVal As Integer, maxVal As Integer, fieldName As String) As Boolean
        If value < minVal OrElse value > maxVal Then
            AddError($"{fieldName} harus antara {minVal} dan {maxVal}!")
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Memvalidasi bahwa nilai tidak boleh negatif.
    ''' </summary>
    ''' <param name="value">Nilai yang akan divalidasi</param>
    ''' <param name="fieldName">Nama field untuk pesan error</param>
    ''' <returns>True jika valid, False jika negatif</returns>
    Protected Function ValidateNonNegative(value As Integer, fieldName As String) As Boolean
        If value < 0 Then
            AddError($"{fieldName} tidak boleh negatif!")
            Return False
        End If
        Return True
    End Function
#End Region

End Class
