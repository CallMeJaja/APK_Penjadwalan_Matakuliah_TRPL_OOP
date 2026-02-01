Imports MySql.Data.MySqlClient

''' <summary>
''' Form input/edit Program Studi.
''' Inherit dari FrmBaseInput dengan konfigurasi khusus untuk tbl_prodi.
''' </summary>
Public Class FrmInputProdi

#Region "Override Properties"
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_prodi"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_prodi"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Program Studi"
        End Get
    End Property
#End Region

#Region "Override Methods - Initialization"
    ''' <summary>
    ''' Inisialisasi form: generate kode otomatis untuk mode tambah.
    ''' </summary>
    Protected Overrides Sub InitializeForm()
        If Not IsEditMode Then
            txtKodeProdi.Text = GenerateKodeProdi()
        End If

        txtKodeProdi.ReadOnly = True
        txtKodeProdi.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

    ''' <summary>
    ''' Load data ke form saat mode edit.
    ''' </summary>
    Protected Overrides Sub LoadFormData()
        Dim row As DataRow = LoadSingleRecord()
        If row IsNot Nothing Then
            txtKodeProdi.Text = NullToString(row("kd_prodi"))
            txtNamaProdi.Text = NullToString(row("nama_prodi"))
        End If
    End Sub

    ''' <summary>
    ''' Focus ke field nama saat form dibuka.
    ''' </summary>
    Protected Overrides Sub FocusFirstInput()
        txtNamaProdi.Focus()
    End Sub
#End Region

#Region "Override Methods - Validation"
    ''' <summary>
    ''' Validasi input sebelum save.
    ''' Menggunakan ProdiEntity untuk validasi OOP.
    ''' </summary>
    Protected Overrides Function ValidateInput() As Boolean
        Dim prodi As New ProdiEntity()

        Try
            prodi.Kode = txtKodeProdi.Text.Trim()
            prodi.NamaProdi = txtNamaProdi.Text.Trim()
        Catch ex As ArgumentException
            ShowError(ex.Message)
            Return False
        End Try

        If Not prodi.IsValid() Then
            ShowError(String.Join(vbCrLf, prodi.GetValidationErrors()))
            Return False
        End If

        If Not ValidateNoDuplicate("nama_prodi", txtNamaProdi.Text.Trim().ToUpper(), "Nama Program Studi") Then
            txtNamaProdi.Focus()
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Override Methods - Query"
    ''' <summary>
    ''' Query INSERT untuk Program Studi.
    ''' </summary>
    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_prodi (kd_prodi, nama_prodi) VALUES (@kd_prodi, @nama_prodi)"
    End Function

    ''' <summary>
    ''' Query UPDATE untuk Program Studi.
    ''' </summary>
    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_prodi SET nama_prodi = @nama_prodi WHERE kd_prodi = @kd_prodi"
    End Function

    ''' <summary>
    ''' Parameter untuk query INSERT/UPDATE.
    ''' </summary>
    Protected Overrides Function GetQueryParameters() As MySqlParameter()
        Return {
            New MySqlParameter("@kd_prodi", txtKodeProdi.Text.Trim()),
            New MySqlParameter("@nama_prodi", txtNamaProdi.Text.Trim().ToUpper())
        }
    End Function
#End Region

#Region "Override Methods - Form Reset"
    ''' <summary>
    ''' Clear form dan reset ke default.
    ''' </summary>
    Protected Overrides Sub ClearForm()
        txtKodeProdi.Text = GenerateKodeProdi()
        txtNamaProdi.Clear()
    End Sub
#End Region

End Class
