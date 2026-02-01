Imports MySql.Data.MySqlClient

''' <summary>
''' Module untuk menangani koneksi database MySQL.
''' Berisi konfigurasi server dan prosedur buka/tutup koneksi.
''' </summary>
Module ModKoneksi

#Region "Konfigurasi Server"
    ''' <summary>
    ''' Alamat server database MySQL.
    ''' </summary>
    Public Server As String = "localhost"

    ''' <summary>
    ''' Username untuk koneksi database.
    ''' </summary>
    Public User As String = "root"

    ''' <summary>
    ''' Password untuk koneksi database.
    ''' </summary>
    Public Password As String = ""

    ''' <summary>
    ''' Nama database yang digunakan.
    ''' </summary>
    Public Database As String = "db_penjadwalan_204021_2"

    ''' <summary>
    ''' Port server MySQL.
    ''' </summary>
    Public Port As String = "3310"
#End Region

#Region "Variabel Global Koneksi"
    ''' <summary>
    ''' Connection string untuk koneksi ke MySQL
    ''' </summary>
    Public StrKoneksi As String = String.Format("Server={0};UserId={1};Password={2};Database={3};Port={4}",
                                                Server, User, Password, Database, Port)

    ''' <summary>
    ''' Objek koneksi utama ke database
    ''' </summary>
    Public Conn As New MySqlConnection
#End Region

#Region "Prosedur Koneksi"
    ''' <summary>
    ''' Membuka koneksi ke database.
    ''' Menggunakan Try-Catch agar aplikasi tidak crash jika XAMPP mati.
    ''' </summary>
    Public Sub BukaKoneksi()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.ConnectionString = StrKoneksi
                Conn.Open()
            End If
        Catch ex As Exception
            MsgBox("Gagal terhubung ke Database!" & vbCrLf &
                   "Pesan Error: " & ex.Message,
                   MsgBoxStyle.Critical, "Error Koneksi")
        End Try
    End Sub

    ''' <summary>
    ''' Menutup koneksi ke database.
    ''' Wajib dipanggil setelah selesai operasi database.
    ''' </summary>
    Public Sub TutupKoneksi()
        Try
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Mengecek status koneksi ke server database tanpa menampilkan error (Silent Check).
    ''' Berguna untuk indikator status di StatusStrip.
    ''' </summary>
    ''' <returns>True jika server dapat diakses, False jika tidak</returns>
    Public Function CekStatusServer() As Boolean
        Try
            Using TempConn As New MySqlConnection(StrKoneksi)
                TempConn.Open()
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Membuat koneksi baru untuk operasi yang membutuhkan koneksi terpisah.
    ''' Caller bertanggung jawab untuk menutup koneksi ini.
    ''' </summary>
    ''' <returns>MySqlConnection baru yang sudah terbuka</returns>
    Public Function GetNewConnection() As MySqlConnection
        Dim newConn As New MySqlConnection(StrKoneksi)
        newConn.Open()
        Return newConn
    End Function
#End Region

End Module
