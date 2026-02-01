Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

''' <summary>
''' Module untuk validasi data sebelum disimpan ke database.
''' Menyediakan fungsi-fungsi validasi umum yang reusable.
''' </summary>
Module ModValidasi

#Region "Database Validation"
    ''' <summary>
    ''' Mengecek apakah nilai sudah ada di database (untuk validasi unique constraint).
    ''' </summary>
    ''' <param name="tableName">Nama tabel</param>
    ''' <param name="columnName">Nama kolom yang dicek</param>
    ''' <param name="value">Nilai yang dicek</param>
    ''' <param name="pkColumn">Nama kolom primary key (opsional, untuk mode edit)</param>
    ''' <param name="excludeId">ID yang dikecualikan (opsional, untuk mode edit)</param>
    ''' <returns>True jika duplikat, False jika unik</returns>
    Public Function IsDuplicate(tableName As String, columnName As String, value As String,
                                Optional pkColumn As String = "", Optional excludeId As String = "") As Boolean
        Try
            Dim query As String
            If String.IsNullOrEmpty(pkColumn) OrElse String.IsNullOrEmpty(excludeId) Then
                query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value"
            Else
                query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value AND {pkColumn} <> @excludeId"
            End If

            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@value", value)
                If Not String.IsNullOrEmpty(excludeId) Then
                    cmd.Parameters.AddWithValue("@excludeId", excludeId)
                End If
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch ex As Exception
            ShowError("Gagal mengecek duplikasi: " & ex.Message)
            Return False
        Finally
            TutupKoneksi()
        End Try
    End Function

    ''' <summary>
    ''' Mengecek duplikasi dengan custom condition (WHERE clause).
    ''' </summary>
    ''' <param name="tableName">Nama tabel</param>
    ''' <param name="whereClause">Kondisi WHERE (tanpa keyword WHERE)</param>
    ''' <returns>True jika ada record yang memenuhi kondisi</returns>
    Public Function IsDuplicate(tableName As String, whereClause As String) As Boolean
        Return IsDuplicate(tableName, whereClause, New MySqlParameter() {})
    End Function

    ''' <summary>
    ''' Mengecek duplikasi dengan custom condition (WHERE clause) dan parameter.
    ''' </summary>
    ''' <param name="tableName">Nama tabel</param>
    ''' <param name="whereClause">Kondisi WHERE (tanpa keyword WHERE)</param>
    ''' <param name="params">Array parameter MySql</param>
    ''' <returns>True jika ada record yang memenuhi kondisi</returns>
    Public Function IsDuplicate(tableName As String, whereClause As String, params As MySqlParameter()) As Boolean
        Try
            Dim query As String = $"SELECT COUNT(*) FROM {tableName} WHERE {whereClause}"

            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch ex As Exception
            ShowError("Gagal mengecek duplikasi parameterized: " & ex.Message)
            Return False
        Finally
            TutupKoneksi()
        End Try
    End Function

    ''' <summary>
    ''' Mengecek apakah record memiliki child records (untuk validasi sebelum delete).
    ''' </summary>
    ''' <param name="childTable">Nama tabel child</param>
    ''' <param name="fkColumn">Nama kolom foreign key</param>
    ''' <param name="fkValue">Nilai foreign key yang dicek</param>
    ''' <returns>True jika memiliki child, False jika tidak</returns>
    Public Function HasChildRecords(childTable As String, fkColumn As String, fkValue As String) As Boolean
        Try
            Dim query As String = $"SELECT COUNT(*) FROM {childTable} WHERE {fkColumn} = @fkValue"

            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@fkValue", fkValue)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch ex As Exception
            ShowError("Gagal mengecek relasi: " & ex.Message)
            Return False
        Finally
            TutupKoneksi()
        End Try
    End Function

    ''' <summary>
    ''' Mengecek apakah record dengan ID tertentu ada di database.
    ''' </summary>
    ''' <param name="tableName">Nama tabel.</param>
    ''' <param name="pkColumn">Nama kolom primary key.</param>
    ''' <param name="pkValue">Nilai primary key yang dicek.</param>
    ''' <returns>True jika record ada, False jika tidak.</returns>
    Public Function RecordExists(tableName As String, pkColumn As String, pkValue As String) As Boolean
        Try
            Dim query As String = $"SELECT COUNT(*) FROM {tableName} WHERE {pkColumn} = @pkValue"

            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                cmd.Parameters.AddWithValue("@pkValue", pkValue)
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

#Region "String Validation"
    ''' <summary>
    ''' Mengecek apakah string tidak kosong atau whitespace.
    ''' </summary>
    ''' <param name="value">String yang akan dicek.</param>
    ''' <returns>True jika tidak kosong, False jika kosong atau whitespace.</returns>
    Public Function IsNotEmpty(value As String) As Boolean
        Return Not String.IsNullOrWhiteSpace(value)
    End Function

    ''' <summary>
    ''' Mengecek apakah panjang string dalam range yang valid.
    ''' </summary>
    ''' <param name="value">String yang akan dicek.</param>
    ''' <param name="minLen">Panjang minimum.</param>
    ''' <param name="maxLen">Panjang maksimum.</param>
    ''' <returns>True jika panjang dalam range, False jika tidak.</returns>
    Public Function IsValidLength(value As String, minLen As Integer, maxLen As Integer) As Boolean
        If String.IsNullOrEmpty(value) Then Return minLen = 0
        Return value.Length >= minLen AndAlso value.Length <= maxLen
    End Function

    ''' <summary>
    ''' Mengecek apakah string hanya berisi angka.
    ''' </summary>
    ''' <param name="value">String yang akan dicek.</param>
    ''' <returns>True jika hanya berisi angka, False jika tidak.</returns>
    Public Function IsNumericOnly(value As String) As Boolean
        If String.IsNullOrEmpty(value) Then Return False
        Return Regex.IsMatch(value, "^\d+$")
    End Function

    ''' <summary>
    ''' Mengecek apakah string hanya berisi huruf.
    ''' </summary>
    ''' <param name="value">String yang akan dicek.</param>
    ''' <returns>True jika hanya berisi huruf, False jika tidak.</returns>
    Public Function IsAlphaOnly(value As String) As Boolean
        If String.IsNullOrEmpty(value) Then Return False
        Return Regex.IsMatch(value, "^[a-zA-Z]+$")
    End Function

    ''' <summary>
    ''' Mengecek apakah string hanya berisi huruf dan angka.
    ''' </summary>
    ''' <param name="value">String yang akan dicek.</param>
    ''' <returns>True jika hanya huruf dan angka, False jika tidak.</returns>
    Public Function IsAlphanumeric(value As String) As Boolean
        If String.IsNullOrEmpty(value) Then Return False
        Return Regex.IsMatch(value, "^[a-zA-Z0-9]+$")
    End Function
#End Region

#Region "Format Validation"
    ''' <summary>
    ''' Mengecek apakah format email valid.
    ''' </summary>
    ''' <param name="email">Email yang akan divalidasi.</param>
    ''' <returns>True jika format valid, False jika tidak.</returns>
    Public Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False
        Try
            Dim pattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
            Return Regex.IsMatch(email, pattern)
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Mengecek apakah format nomor telepon Indonesia valid.
    ''' Format yang diterima: 08xxxxxxxxxx (10-13 digit dimulai dengan 08).
    ''' </summary>
    ''' <param name="phone">Nomor telepon yang akan divalidasi.</param>
    ''' <returns>True jika format valid, False jika tidak.</returns>
    Public Function IsValidPhone(phone As String) As Boolean
        If String.IsNullOrWhiteSpace(phone) Then Return False
        Dim pattern As String = "^08[0-9]{8,11}$"
        Return Regex.IsMatch(phone, pattern)
    End Function

    ''' <summary>
    ''' Mengecek apakah format NIDN valid (10 digit angka).
    ''' </summary>
    ''' <param name="nidn">NIDN yang akan divalidasi.</param>
    ''' <returns>True jika format valid, False jika tidak.</returns>
    Public Function IsValidNIDN(nidn As String) As Boolean
        If String.IsNullOrWhiteSpace(nidn) Then Return False
        Return Regex.IsMatch(nidn, "^\d{10}$")
    End Function
#End Region

#Region "Numeric Validation"
    ''' <summary>
    ''' Mengecek apakah nilai integer dalam range yang valid.
    ''' </summary>
    ''' <param name="value">Nilai yang dicek.</param>
    ''' <param name="minVal">Nilai minimum.</param>
    ''' <param name="maxVal">Nilai maksimum.</param>
    ''' <returns>True jika dalam range, False jika tidak.</returns>
    Public Function IsInRange(value As Integer, minVal As Integer, maxVal As Integer) As Boolean
        Return value >= minVal AndAlso value <= maxVal
    End Function

    ''' <summary>
    ''' Mengecek apakah nilai lebih besar dari nol.
    ''' </summary>
    ''' <param name="value">Nilai yang dicek.</param>
    ''' <returns>True jika positif, False jika tidak.</returns>
    Public Function IsPositive(value As Integer) As Boolean
        Return value > 0
    End Function

    ''' <summary>
    ''' Mengecek apakah nilai tidak negatif.
    ''' </summary>
    ''' <param name="value">Nilai yang dicek.</param>
    ''' <returns>True jika >= 0, False jika negatif.</returns>
    Public Function IsNotNegative(value As Integer) As Boolean
        Return value >= 0
    End Function

    ''' <summary>
    ''' Mencoba parse string ke integer dengan aman.
    ''' </summary>
    ''' <param name="value">String yang akan di-parse.</param>
    ''' <param name="result">Output hasil parse.</param>
    ''' <returns>True jika berhasil parse, False jika gagal.</returns>
    Public Function TryParseInt(value As String, ByRef result As Integer) As Boolean
        Return Integer.TryParse(value, result)
    End Function
#End Region

#Region "ComboBox Validation"
    ''' <summary>
    ''' Mengecek apakah ComboBox sudah dipilih (bukan placeholder).
    ''' </summary>
    ''' <param name="cmb">ComboBox yang dicek.</param>
    ''' <returns>True jika sudah dipilih item valid, False jika belum.</returns>
    Public Function IsComboBoxSelected(cmb As ComboBox) As Boolean
        If cmb.SelectedIndex <= 0 Then Return False
        If cmb.SelectedValue Is Nothing Then Return False
        If String.IsNullOrEmpty(cmb.SelectedValue.ToString()) Then Return False
        Return True
    End Function
#End Region

End Module
