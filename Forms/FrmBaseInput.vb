Imports MySql.Data.MySqlClient

''' <summary>
''' Base class untuk form input/edit data.
''' Menyediakan fungsionalitas umum seperti validasi, save, dan mode edit.
''' Child class harus override methods yang diperlukan.
''' </summary>
Public Class FrmBaseInput

#Region "Public Properties"
    ''' <summary>
    ''' Mode form: True = Edit, False = Tambah baru
    ''' </summary>
    Public Property IsEditMode As Boolean = False

    ''' <summary>
    ''' ID record yang sedang diedit (hanya digunakan jika IsEditMode = True)
    ''' </summary>
    Public Property RecordId As String = ""
#End Region

#Region "Overridable Properties"
    ''' <summary>
    ''' Nama tabel utama di database. Wajib di-override.
    ''' </summary>
    Protected Overridable ReadOnly Property TableName As String
        Get
            Return ""
        End Get
    End Property

    ''' <summary>
    ''' Nama kolom primary key. Wajib di-override.
    ''' </summary>
    Protected Overridable ReadOnly Property PrimaryKey As String
        Get
            Return ""
        End Get
    End Property

    ''' <summary>
    ''' Nama modul untuk ditampilkan di judul. Wajib di-override.
    ''' </summary>
    Protected Overridable ReadOnly Property ModuleName As String
        Get
            Return "Data"
        End Get
    End Property
#End Region

#Region "Form Events"
    Private Sub FrmBaseInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        UpdateTitle()

        If IsEditMode Then
            LoadFormData()
        End If

        SetupForm()
    End Sub

    Private Sub FrmBaseInput_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FocusFirstInput()
    End Sub
#End Region

#Region "Initialization"
    ''' <summary>
    ''' Inisialisasi form (isi combo, set default value, dll).
    ''' Override di child class untuk custom initialization.
    ''' </summary>
    Protected Overridable Sub InitializeForm()
        ' Override di child class
    End Sub

    ''' <summary>
    ''' Setup form setelah initialization dan data loading.
    ''' Override di child class untuk setup tambahan.
    ''' </summary>
    Protected Overridable Sub SetupForm()
        ' Override di child class
    End Sub

    ''' <summary>
    ''' Update judul form berdasarkan mode.
    ''' </summary>
    Private Sub UpdateTitle()
        Dim modeText As String = If(IsEditMode, "EDIT", "TAMBAH")
        Me.Text = $"{modeText} {ModuleName}"
        lblJudul.Text = $"FORM {modeText} {ModuleName.ToUpper()}"
    End Sub

    ''' <summary>
    ''' Focus ke control input pertama.
    ''' Override untuk custom focus.
    ''' </summary>
    Protected Overridable Sub FocusFirstInput()
        FocusFirstControl(pnlMain)
    End Sub
#End Region

#Region "Data Loading (Edit Mode)"
    ''' <summary>
    ''' Load data ke form saat mode edit.
    ''' Wajib di-override di child class.
    ''' </summary>
    Protected Overridable Sub LoadFormData()
        ' Override di child class untuk load data berdasarkan RecordId
    End Sub

    ''' <summary>
    ''' Helper untuk load data single record.
    ''' </summary>
    Protected Function LoadSingleRecord() As DataRow
        If String.IsNullOrEmpty(RecordId) Then Return Nothing

        Dim query As String = $"SELECT * FROM {TableName} WHERE {PrimaryKey} = @id"
        Dim dt As DataTable = LoadDataWithParams(query, New MySqlParameter("@id", RecordId))

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Return dt.Rows(0)
        End If

        Return Nothing
    End Function
#End Region

#Region "Validation"
    ''' <summary>
    ''' Validasi semua input sebelum save.
    ''' Wajib di-override di child class.
    ''' </summary>
    ''' <returns>True jika valid, False jika tidak valid</returns>
    Protected Overridable Function ValidateInput() As Boolean
        Return True
    End Function

    ''' <summary>
    ''' Helper untuk validasi field wajib TextBox.
    ''' </summary>
    Protected Function ValidateRequired(txt As TextBox, fieldName As String) As Boolean
        If Not IsNotEmpty(txt.Text) Then
            ShowError($"{fieldName} wajib diisi!")
            txt.Focus()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Helper untuk validasi field wajib ComboBox.
    ''' </summary>
    Protected Function ValidateRequired(cmb As ComboBox, fieldName As String) As Boolean
        If Not IsComboBoxSelected(cmb) Then
            ShowError($"{fieldName} wajib dipilih!")
            cmb.Focus()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Helper untuk validasi panjang string.
    ''' </summary>
    Protected Function ValidateLength(txt As TextBox, fieldName As String, minLen As Integer, maxLen As Integer) As Boolean
        If Not IsValidLength(txt.Text, minLen, maxLen) Then
            ShowError($"{fieldName} harus antara {minLen} - {maxLen} karakter!")
            txt.Focus()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Helper untuk validasi duplikat.
    ''' </summary>
    Protected Function ValidateNoDuplicate(columnName As String, value As String, fieldName As String) As Boolean
        Dim excludeId As String = If(IsEditMode, RecordId, "")
        If IsDuplicate(TableName, columnName, value, PrimaryKey, excludeId) Then
            ShowError($"{fieldName} sudah ada di database!")
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Save Operations"
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        PerformSave()
    End Sub

    ''' <summary>
    ''' Eksekusi proses save.
    ''' </summary>
    Protected Sub PerformSave()
        Try
            ' Validasi input
            If Not ValidateInput() Then Return

            Cursor = Cursors.WaitCursor

            ' Jalankan before save hook
            If Not BeforeSave() Then Return

            ' Dapatkan query dan parameter
            Dim query As String
            If IsEditMode Then
                query = GetUpdateQuery()
            Else
                query = GetInsertQuery()
            End If

            Dim params() As MySqlParameter = GetQueryParameters()

            ' Execute query
            If ExecuteQuery(query, params) Then
                ' Jalankan after save hook
                AfterSave()

                Dim actionText As String = If(IsEditMode, "diubah", "disimpan")
                ShowSuccess($"Data {ModuleName} berhasil {actionText}!")

                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If

        Catch ex As Exception
            ShowError($"Gagal menyimpan data: {ex.Message}")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' Hook yang dijalankan sebelum save. Override untuk custom logic.
    ''' Return False untuk membatalkan save.
    ''' </summary>
    Protected Overridable Function BeforeSave() As Boolean
        Return True
    End Function

    ''' <summary>
    ''' Hook yang dijalankan setelah save berhasil. Override untuk custom logic.
    ''' </summary>
    Protected Overridable Sub AfterSave()
        ' Override di child class jika diperlukan
    End Sub
#End Region

#Region "Query Building - WAJIB OVERRIDE"
    ''' <summary>
    ''' Query INSERT. Wajib di-override di child class.
    ''' </summary>
    Protected Overridable Function GetInsertQuery() As String
        Return ""
    End Function

    ''' <summary>
    ''' Query UPDATE. Wajib di-override di child class.
    ''' </summary>
    Protected Overridable Function GetUpdateQuery() As String
        Return ""
    End Function

    ''' <summary>
    ''' Parameter untuk query INSERT/UPDATE. Wajib di-override di child class.
    ''' </summary>
    Protected Overridable Function GetQueryParameters() As MySqlParameter()
        Return {}
    End Function
#End Region

#Region "Form Clear & Reset"
    ''' <summary>
    ''' Clear semua input field dan reset ke default.
    ''' Override di child class untuk clear custom controls.
    ''' </summary>
    Protected Overridable Sub ClearForm()
        ClearTextBoxes(pnlMain)
        ResetComboBoxes(pnlMain)
    End Sub

    ''' <summary>
    ''' Reset form untuk input data baru (dalam mode tambah).
    ''' </summary>
    Protected Sub ResetForNewEntry()
        ClearForm()
        InitializeForm()
        FocusFirstInput()
    End Sub
#End Region

#Region "Cancel & Close"
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        If HasUnsavedChanges() Then
            Dim result As DialogResult = ShowConfirmCancel("Ada perubahan yang belum disimpan. Simpan sebelum keluar?")
            Select Case result
                Case DialogResult.Yes
                    PerformSave()
                Case DialogResult.No
                    Me.DialogResult = DialogResult.Cancel
                    Me.Close()
                Case DialogResult.Cancel
                    ' Do nothing, stay on form
            End Select
        Else
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' Cek apakah ada perubahan yang belum disimpan.
    ''' Override untuk custom check.
    ''' </summary>
    Protected Overridable Function HasUnsavedChanges() As Boolean
        ' Default: tidak ada pengecekan (langsung tutup)
        ' Override di child class untuk implementasi yang lebih proper
        Return False
    End Function

    Private Sub FrmBaseInput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Cleanup jika diperlukan
    End Sub
#End Region

#Region "Keyboard Shortcuts"
    Private Sub FrmBaseInput_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnBatal.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            e.Handled = True
            btnSimpan.PerformClick()
        End If
    End Sub
#End Region

End Class