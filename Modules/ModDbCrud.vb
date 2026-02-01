Imports MySql.Data.MySqlClient

''' <summary>
''' Module untuk operasi CRUD (Create, Read, Update, Delete) database.
''' Menyediakan helper functions yang dapat digunakan di semua form.
''' </summary>
Module ModDbCrud

#Region "Read Operations"
    ''' <summary>
    ''' Mengambil data dari database dan mengembalikan DataTable.
    ''' </summary>
    ''' <param name="query">Query SELECT yang akan dieksekusi</param>
    ''' <returns>DataTable berisi hasil query</returns>
    Public Function LoadData(query As String) As DataTable
        Dim dt As New DataTable()
        Try
            BukaKoneksi()
            Using da As New MySqlDataAdapter(query, Conn)
                da.Fill(dt)
            End Using
        Catch ex As Exception
            ShowError("Gagal mengambil data: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Mengambil data dengan parameter untuk mencegah SQL Injection.
    ''' </summary>
    ''' <param name="query">Query SELECT dengan placeholder @param</param>
    ''' <param name="params">Array MySqlParameter</param>
    ''' <returns>DataTable berisi hasil query</returns>
    Public Function LoadDataWithParams(query As String, ParamArray params() As MySqlParameter) As DataTable
        Dim dt As New DataTable()
        Try
            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            ShowError("Gagal mengambil data: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Mengambil nilai tunggal dari query (untuk COUNT, MAX, SUM, dll).
    ''' </summary>
    ''' <param name="query">Query yang mengembalikan nilai tunggal</param>
    ''' <returns>Object hasil query, Nothing jika gagal</returns>
    Public Function GetScalarValue(query As String) As Object
        Dim result As Object = Nothing
        Try
            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                result = cmd.ExecuteScalar()
            End Using
        Catch ex As Exception
            ShowError("Gagal mengambil nilai: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
        Return result
    End Function

    ''' <summary>
    ''' Mengambil nilai tunggal dengan parameter.
    ''' </summary>
    ''' <param name="query">Query yang mengembalikan nilai tunggal.</param>
    ''' <param name="params">Array MySqlParameter untuk query.</param>
    ''' <returns>Object hasil query, Nothing jika gagal.</returns>
    Public Function GetScalarValueWithParams(query As String, ParamArray params() As MySqlParameter) As Object
        Dim result As Object = Nothing
        Try
            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                result = cmd.ExecuteScalar()
            End Using
        Catch ex As Exception
            ShowError("Gagal mengambil nilai: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
        Return result
    End Function
#End Region

#Region "Write Operations"
    ''' <summary>
    ''' Mengeksekusi query INSERT, UPDATE, atau DELETE dengan parameter.
    ''' </summary>
    ''' <param name="query">Query dengan placeholder @param</param>
    ''' <param name="params">Array MySqlParameter</param>
    ''' <returns>True jika berhasil (affected rows > 0)</returns>
    Public Function ExecuteQuery(query As String, ParamArray params() As MySqlParameter) As Boolean
        Try
            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Dim affectedRows As Integer = cmd.ExecuteNonQuery()
                Return affectedRows > 0
            End Using
        Catch ex As MySqlException
            Select Case ex.Number
                Case 1062
                    ShowError("Data sudah ada di database (duplikat)!")
                Case 1451
                    ShowError("Data tidak dapat dihapus karena masih digunakan di tabel lain!")
                Case 1452
                    ShowError("Data referensi tidak valid!")
                Case Else
                    ShowError("Gagal menyimpan data: " & ex.Message)
            End Select
            Return False
        Catch ex As Exception
            ShowError("Gagal menyimpan data: " & ex.Message)
            Return False
        Finally
            TutupKoneksi()
        End Try
    End Function

    ''' <summary>
    ''' Mengeksekusi query INSERT, UPDATE, atau DELETE tanpa parameter.
    ''' PERHATIAN: Rentan SQL Injection, gunakan hanya untuk query statis.
    ''' </summary>
    ''' <param name="query">Query yang akan dieksekusi.</param>
    ''' <returns>True jika berhasil (affected rows > 0).</returns>
    Public Function ExecuteNonQuery(query As String) As Boolean
        Try
            BukaKoneksi()
            Using cmd As New MySqlCommand(query, Conn)
                Dim affectedRows As Integer = cmd.ExecuteNonQuery()
                Return affectedRows > 0
            End Using
        Catch ex As Exception
            ShowError("Gagal mengeksekusi query: " & ex.Message)
            Return False
        Finally
            TutupKoneksi()
        End Try
    End Function
#End Region

#Region "ComboBox Helpers"
    ''' <summary>
    ''' Mengisi ComboBox dengan data dari database.
    ''' </summary>
    ''' <param name="cmb">ComboBox yang akan diisi</param>
    ''' <param name="query">Query SELECT untuk mengambil data</param>
    ''' <param name="displayMember">Nama kolom untuk ditampilkan</param>
    ''' <param name="valueMember">Nama kolom untuk nilai</param>
    ''' <param name="placeholder">Text placeholder di index 0 (opsional)</param>
    Public Sub IsiComboBox(cmb As ComboBox, query As String, displayMember As String, valueMember As String,
                           Optional placeholder As String = "-- Pilih --")
        Try
            Dim dt As DataTable = LoadData(query)

            If Not String.IsNullOrEmpty(placeholder) Then
                If Not dt.Columns.Contains(displayMember) Then dt.Columns.Add(displayMember)
                If Not dt.Columns.Contains(valueMember) Then dt.Columns.Add(valueMember)

                Dim placeholderRow As DataRow = dt.NewRow()
                placeholderRow(displayMember) = placeholder
                placeholderRow(valueMember) = ""
                dt.Rows.InsertAt(placeholderRow, 0)
            End If

            cmb.DataSource = dt
            cmb.DisplayMember = displayMember
            cmb.ValueMember = valueMember

            If cmb.Items.Count > 0 Then
                cmb.SelectedIndex = 0
            End If

        Catch ex As Exception
            ShowError("Gagal mengisi ComboBox: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Mengisi ComboBox dengan array string manual (tanpa database).
    ''' </summary>
    ''' <param name="cmb">ComboBox yang akan diisi</param>
    ''' <param name="items">Array string untuk items</param>
    ''' <param name="placeholder">Text placeholder di index 0 (opsional)</param>
    Public Sub IsiComboBoxManual(cmb As ComboBox, items As String(), Optional placeholder As String = "-- Pilih --")
        Try
            cmb.Items.Clear()

            If Not String.IsNullOrEmpty(placeholder) Then
                cmb.Items.Add(placeholder)
            End If

            For Each item As String In items
                cmb.Items.Add(item)
            Next

            cmb.SelectedIndex = 0

        Catch ex As Exception
            ShowError("Gagal mengisi ComboBox: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Set selected value ComboBox berdasarkan value.
    ''' </summary>
    ''' <param name="cmb">ComboBox yang akan di-set.</param>
    ''' <param name="value">Value yang akan dipilih.</param>
    Public Sub SetComboBoxValue(cmb As ComboBox, value As String)
        Try
            If String.IsNullOrEmpty(value) Then
                cmb.SelectedIndex = 0
            Else
                cmb.SelectedValue = value
            End If
        Catch ex As Exception
            cmb.SelectedIndex = 0
        End Try
    End Sub
#End Region

#Region "DataGridView Helpers"
    ''' <summary>
    ''' Mengisi DataGridView dengan data dari query.
    ''' </summary>
    ''' <param name="dgv">DataGridView yang akan diisi.</param>
    ''' <param name="query">Query SELECT untuk mengambil data.</param>
    Public Sub IsiDataGridView(dgv As DataGridView, query As String)
        Try
            dgv.DataSource = LoadData(query)
        Catch ex As Exception
            ShowError("Gagal mengisi DataGridView: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Mengambil nilai cell dari baris yang dipilih di DataGridView.
    ''' </summary>
    ''' <param name="dgv">DataGridView sumber</param>
    ''' <param name="columnName">Nama kolom</param>
    ''' <returns>Nilai cell sebagai string, empty string jika tidak ada yang dipilih</returns>
    Public Function GetSelectedCellValue(dgv As DataGridView, columnName As String) As String
        Try
            If dgv.SelectedRows.Count > 0 Then
                Return NullToString(dgv.SelectedRows(0).Cells(columnName).Value)
            ElseIf dgv.CurrentRow IsNot Nothing Then
                Return NullToString(dgv.CurrentRow.Cells(columnName).Value)
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    ''' <summary>
    ''' Menghitung jumlah baris di DataGridView.
    ''' </summary>
    ''' <param name="dgv">DataGridView sumber.</param>
    ''' <returns>Jumlah baris dalam DataGridView.</returns>
    Public Function GetRowCount(dgv As DataGridView) As Integer
        Return dgv.RowCount
    End Function
#End Region

End Module
