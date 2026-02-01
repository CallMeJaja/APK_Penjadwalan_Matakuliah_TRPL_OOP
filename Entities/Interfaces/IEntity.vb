''' <summary>
''' Interface untuk semua entity dalam sistem penjadwalan.
''' Mendefinisikan kontrak fungsi utama yang harus diimplementasikan oleh setiap entity.
''' Menerapkan prinsip ABSTRACTION untuk OOP.
''' </summary>
Public Interface IEntity

    ''' <summary>
    ''' Memeriksa apakah data entity valid untuk disimpan ke database.
    ''' </summary>
    ''' <returns>True jika data valid, False jika terdapat error</returns>
    Function IsValid() As Boolean

    ''' <summary>
    ''' Mengambil daftar pesan error jika validasi gagal.
    ''' </summary>
    ''' <returns>List berisi pesan-pesan error validasi</returns>
    Function GetValidationErrors() As List(Of String)

    ''' <summary>
    ''' Menghasilkan informasi untuk ditampilkan di komponen UI.
    ''' </summary>
    ''' <returns>String berisi informasi display entity</returns>
    Function GetDisplayInfo() As String

End Interface
