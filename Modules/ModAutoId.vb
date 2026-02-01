Imports MySql.Data.MySqlClient

''' <summary>
''' Module untuk generate ID/Kode otomatis.
''' Menyediakan fungsi-fungsi untuk membuat ID unik berdasarkan prefix dan format tertentu.
''' </summary>
Module ModAutoId

#Region "Generic ID Generator"
    ''' <summary>
    ''' Generate ID berikutnya berdasarkan prefix dan panjang digit.
    ''' Contoh: GetNextId("tbl_prodi", "kd_prodi", "PR", 3) → "PR005"
    ''' </summary>
    ''' <param name="tableName">Nama tabel</param>
    ''' <param name="pkColumn">Nama kolom primary key</param>
    ''' <param name="prefix">Prefix ID (contoh: "PR", "DSN", "MK")</param>
    ''' <param name="digitLength">Jumlah digit angka (contoh: 3 → 001, 4 → 0001)</param>
    ''' <returns>ID baru dengan format [prefix][digit]</returns>
    Public Function GetNextId(tableName As String, pkColumn As String, prefix As String, digitLength As Integer) As String
        Try
            Dim query As String = $"SELECT {pkColumn} FROM {tableName} WHERE {pkColumn} LIKE '{prefix}%' ORDER BY {pkColumn} DESC LIMIT 1"

            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                Dim result = cmd.ExecuteScalar()

                Dim nextNumber As Integer = 1

                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    Dim lastId As String = result.ToString()
                    Dim numericPart As String = lastId.Substring(prefix.Length)
                    If Integer.TryParse(numericPart, nextNumber) Then
                        nextNumber += 1
                    End If
                End If

                Return prefix & nextNumber.ToString().PadLeft(digitLength, "0"c)
            End Using
        Catch ex As Exception
            ShowError("Gagal generate ID: " & ex.Message)
            Return prefix & "1".PadLeft(digitLength, "0"c)
        Finally
            TutupKoneksi()
        End Try
    End Function

    ''' <summary>
    ''' Generate ID numerik berikutnya (tanpa prefix).
    ''' Contoh: GetNextNumericId("tbl_user", "id_user", 3) → "003"
    ''' </summary>
    Public Function GetNextNumericId(tableName As String, pkColumn As String, digitLength As Integer) As String
        Try
            Dim query As String = $"SELECT MAX(CAST({pkColumn} AS UNSIGNED)) FROM {tableName}"

            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                Dim result = cmd.ExecuteScalar()

                Dim nextNumber As Integer = 1

                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    nextNumber = Convert.ToInt32(result) + 1
                End If

                Return nextNumber.ToString().PadLeft(digitLength, "0"c)
            End Using
        Catch ex As Exception
            ShowError("Gagal generate ID: " & ex.Message)
            Return "1".PadLeft(digitLength, "0"c)
        Finally
            TutupKoneksi()
        End Try
    End Function
#End Region

#Region "Specific ID Generators"
    ''' <summary>
    ''' Generate kode Program Studi berikutnya.
    ''' Format: PR001, PR002, ...
    ''' </summary>
    Public Function GenerateKodeProdi() As String
        Return GetNextId("tbl_prodi", "kd_prodi", "PR", 3)
    End Function

    ''' <summary>
    ''' Generate kode Dosen berikutnya.
    ''' Format: 130001, 130002, ... (6 digit)
    ''' Khusus: Jika kode terakhir 139999, skip ke 140001 (bukan 140000).
    ''' </summary>
    Public Function GenerateKodeDosen() As String
        Try
            Dim query As String = "SELECT MAX(CAST(kd_dosen AS UNSIGNED)) FROM tbl_dosen"

            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                Dim result = cmd.ExecuteScalar()

                ' Default pertama
                Dim nextNumber As Integer = 130001

                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    Dim lastNumber As Integer = Convert.ToInt32(result)
                    nextNumber = lastNumber + 1

                    If nextNumber = 140000 Then
                        nextNumber = 140001
                    End If
                End If

                Return nextNumber.ToString()
            End Using
        Catch ex As Exception
            ShowError("Gagal generate kode dosen: " & ex.Message)
            Return "130001"
        Finally
            TutupKoneksi()
        End Try
    End Function

    ''' <summary>
    ''' Generate kode Mata Kuliah berikutnya berdasarkan prodi.
    ''' Format: TRPL101, TRPL102, ... atau MKU101, MKK101
    ''' </summary>
    ''' <param name="prefix">Prefix prodi (TRPL, MKU, MKK, dll)</param>
    Public Function GenerateKodeMatkul(prefix As String) As String
        Return GetNextId("tbl_matakuliah", "kd_matkul", prefix, 3)
    End Function

    ''' <summary>
    ''' Generate ID Hari berikutnya.
    ''' Format: HR001, HR002, ...
    ''' </summary>
    Public Function GenerateIdHari() As String
        Return GetNextId("tbl_hari", "id_hari", "HR", 3)
    End Function

    ''' <summary>
    ''' Generate kode Ruangan berikutnya.
    ''' Format: R0001, R0002, ...
    ''' </summary>
    Public Function GenerateKodeRuangan() As String
        Return GetNextId("tbl_ruangkelas", "kd_ruangan", "R", 4)
    End Function

    ''' <summary>
    ''' Generate ID User berikutnya.
    ''' Format: 001, 002, ... (3 digit numerik)
    ''' </summary>
    Public Function GenerateIdUser() As String
        Return GetNextNumericId("tbl_user", "id_user", 3)
    End Function

    ''' <summary>
    ''' Generate kode Pengampu berikutnya.
    ''' Format: PMK0001, PMK0002, ...
    ''' </summary>
    Public Function GenerateKodePengampu() As String
        Return GetNextId("tbl_dosen_pengampu_matkul", "kd_pengampu", "PMK", 4)
    End Function
#End Region

#Region "Utility"
    ''' <summary>
    ''' Mengecek apakah ID sudah ada di database.
    ''' </summary>
    ''' <param name="tableName">Nama tabel.</param>
    ''' <param name="pkColumn">Nama kolom primary key.</param>
    ''' <param name="idValue">Nilai ID yang akan dicek.</param>
    ''' <returns>True jika ID sudah ada, False jika belum.</returns>
    Public Function IsIdExists(tableName As String, pkColumn As String, idValue As String) As Boolean
        Try
            Dim query As String = $"SELECT COUNT(*) FROM {tableName} WHERE {pkColumn} = @id"

            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@id", idValue)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch ex As Exception
            Return False
        Finally
            TutupKoneksi()
        End Try
    End Function
#End Region

End Module
