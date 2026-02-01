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

#Region "Override Methods - Query"
    ''' <summary>
    ''' Query INSERT untuk Hari.
    ''' </summary>
    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_hari (id_hari, nama_hari) VALUES (@id_hari, @nama_hari)"
    End Function

    ''' <summary>
    ''' Query UPDATE untuk Hari.
    ''' </summary>
    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_hari SET nama_hari = @nama_hari WHERE id_hari = @id_hari"
    End Function

    ''' <summary>
    ''' Parameter untuk query INSERT/UPDATE.
    ''' </summary>
    Protected Overrides Function GetQueryParameters() As MySqlParameter()
        Return {
            New MySqlParameter("@id_hari", txtKodeHari.Text.Trim()),
            New MySqlParameter("@nama_hari", txtNamaHari.Text.Trim().ToUpper())
        }
    End Function
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
