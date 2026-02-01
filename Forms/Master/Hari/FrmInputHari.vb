Imports MySql.Data.MySqlClient

''' <summary>
''' Form input/edit Hari.
''' Inherit dari FrmBaseInput dengan konfigurasi khusus untuk tbl_hari.
''' </summary>
Public Class FrmInputHari

#Region "Override Properties"
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_hari"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "id_hari"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Hari"
        End Get
    End Property
#End Region

#Region "Override Methods - Initialization"
    ''' <summary>
    ''' Inisialisasi form: generate kode otomatis untuk mode tambah.
    ''' </summary>
    Protected Overrides Sub InitializeForm()
        If Not IsEditMode Then
            txtKodeHari.Text = GenerateIdHari()
        End If

        txtKodeHari.ReadOnly = True
        txtKodeHari.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

    ''' <summary>
    ''' Load data ke form saat mode edit.
    ''' </summary>
    Protected Overrides Sub LoadFormData()
        Dim row As DataRow = LoadSingleRecord()
        If row IsNot Nothing Then
            txtKodeHari.Text = NullToString(row("id_hari"))
            txtNamaHari.Text = NullToString(row("nama_hari"))
        End If
    End Sub

    ''' <summary>
    ''' Focus ke field nama saat form dibuka.
    ''' </summary>
    Protected Overrides Sub FocusFirstInput()
        txtNamaHari.Focus()
    End Sub
#End Region

#Region "Override Methods - Save Execution (Repository Pattern)"
    ''' <summary>
    ''' Eksekusi simpan menggunakan HariRepository.
    ''' </summary>
    Protected Overrides Function ExecuteSave() As Boolean
        Dim repo As New HariRepository()
        Dim hari As New HariEntity()
        hari.Kode = txtKodeHari.Text.Trim()
        hari.NamaHari = txtNamaHari.Text.Trim().ToUpper()

        If IsEditMode Then
            Return repo.Update(hari)
        Else
            Return repo.Insert(hari)
        End If
    End Function
#End Region

#Region "Override Methods - Validation"
    ''' <summary>
    ''' Validasi input sebelum save.
    ''' Menggunakan HariEntity untuk validasi OOP.
    ''' </summary>
    Protected Overrides Function ValidateInput() As Boolean
        Dim hari As New HariEntity()

        Try
            hari.Kode = txtKodeHari.Text.Trim()
            hari.NamaHari = txtNamaHari.Text.Trim()
        Catch ex As ArgumentException
            ShowError(ex.Message)
            Return False
        End Try

        If Not hari.IsValid() Then
            ShowError(String.Join(vbCrLf, hari.GetValidationErrors()))
            Return False
        End If

        If Not ValidateNoDuplicate("nama_hari", txtNamaHari.Text.Trim().ToUpper(), "Nama Hari") Then
            txtNamaHari.Focus()
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Override Methods - Query (Removed in favor of Repository)"
    ' Logika SQL dipindahkan ke HariRepository.vb
#End Region

#Region "Override Methods - Form Reset"
    ''' <summary>
    ''' Clear form dan reset ke default.
    ''' </summary>
    Protected Overrides Sub ClearForm()
        txtKodeHari.Text = GenerateIdHari()
        txtNamaHari.Clear()
    End Sub
#End Region

End Class
