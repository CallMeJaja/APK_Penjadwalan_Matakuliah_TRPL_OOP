''' <summary>
''' Interface generik untuk Repository.
''' Menyediakan kontrak standar untuk operasi CRUD.
''' </summary>
''' <typeparam name="T">Tipe entity yang dikelola.</typeparam>
Public Interface IRepository(Of T As Class)

    ''' <summary>
    ''' Mendapatkan semua data entity.
    ''' </summary>
    ''' <returns>List berisi semua entity.</returns>
    Function GetAll() As List(Of T)

    ''' <summary>
    ''' Mendapatkan entity berdasarkan ID/Kode.
    ''' </summary>
    ''' <param name="id">ID entity yang dicari.</param>
    ''' <returns>Entity jika ditemukan, Nothing jika tidak.</returns>
    Function GetById(id As String) As T

    ''' <summary>
    ''' Menyimpan entity baru.
    ''' </summary>
    ''' <param name="entity">Entity yang akan disimpan.</param>
    ''' <returns>True jika berhasil, False jika gagal.</returns>
    Function Insert(entity As T) As Boolean

    ''' <summary>
    ''' Mengupdate entity yang ada.
    ''' </summary>
    ''' <param name="entity">Entity dengan data yang diupdate.</param>
    ''' <returns>True jika berhasil, False jika gagal.</returns>
    Function Update(entity As T) As Boolean

    ''' <summary>
    ''' Menghapus entity berdasarkan ID.
    ''' </summary>
    ''' <param name="id">ID entity yang akan dihapus.</param>
    ''' <returns>True jika berhasil, False jika gagal.</returns>
    Function Delete(id As String) As Boolean

    ''' <summary>
    ''' Mengecek apakah ID sudah ada.
    ''' </summary>
    ''' <param name="id">ID yang akan dicek.</param>
    ''' <returns>True jika sudah ada, False jika belum.</returns>
    Function Exists(id As String) As Boolean

End Interface
