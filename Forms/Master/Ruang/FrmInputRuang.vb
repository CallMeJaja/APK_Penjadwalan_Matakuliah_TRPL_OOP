Imports MySql.Data.MySqlClient

''' <summary>
''' Form input/edit Ruang Kelas.
''' Inherit dari FrmBaseInput dengan konfigurasi khusus untuk tbl_ruangkelas.
''' </summary>
Public Class FrmInputRuang

#Region "Override Properties"
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_ruangkelas"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_ruangan"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Ruang Kelas"
        End Get
    End Property
#End Region

#Region "Override Methods - Initialization"
    ''' <summary>
    ''' Inisialisasi form: generate kode dan set default kapasitas.
    ''' </summary>
    Protected Overrides Sub InitializeForm()
        If Not IsEditMode Then
            txtIdRuangan.Text = GenerateKodeRuangan()
            nudKapasitas.Value = 30
        End If

        txtIdRuangan.ReadOnly = True
        txtIdRuangan.BackColor = Color.FromArgb(240, 240, 240)

        nudKapasitas.Minimum = 1
        nudKapasitas.Maximum = 500
    End Sub

    ''' <summary>
    ''' Load data ke form saat mode edit.
    ''' </summary>
    Protected Overrides Sub LoadFormData()
        Dim row As DataRow = LoadSingleRecord()
        If row IsNot Nothing Then
            txtIdRuangan.Text = NullToString(row("kd_ruangan"))
            txtNamaRuangan.Text = NullToString(row("nama_ruangan"))
            nudKapasitas.Value = NullToInt(row("kapasitas"), 30)
        End If
    End Sub

    ''' <summary>
    ''' Focus ke field nama saat form dibuka.
    ''' </summary>
    Protected Overrides Sub FocusFirstInput()
        txtNamaRuangan.Focus()
    End Sub
#End Region

#Region "Override Methods - Validation"
    ''' <summary>
    ''' Validasi input sebelum save.
    ''' Menggunakan RuangkelasEntity untuk validasi OOP.
    ''' </summary>
    Protected Overrides Function ValidateInput() As Boolean
        Dim ruang As New RuangkelasEntity()

        Try
            ruang.Kode = txtIdRuangan.Text.Trim()
            ruang.NamaRuangan = txtNamaRuangan.Text.Trim()
            ruang.Kapasitas = CInt(nudKapasitas.Value)
        Catch ex As ArgumentException
            ShowError(ex.Message)
            Return False
        End Try

        If Not ruang.IsValid() Then
            ShowError(String.Join(vbCrLf, ruang.GetValidationErrors()))
            Return False
        End If

        If Not ValidateNoDuplicate("nama_ruangan", txtNamaRuangan.Text.Trim().ToUpper(), "Nama Ruangan") Then
            txtNamaRuangan.Focus()
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Override Methods - Query"
    ''' <summary>
    ''' Query INSERT untuk Ruang Kelas.
    ''' </summary>
    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_ruangkelas (kd_ruangan, nama_ruangan, kapasitas) VALUES (@kd_ruangan, @nama_ruangan, @kapasitas)"
    End Function

    ''' <summary>
    ''' Query UPDATE untuk Ruang Kelas.
    ''' </summary>
    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_ruangkelas SET nama_ruangan = @nama_ruangan, kapasitas = @kapasitas WHERE kd_ruangan = @kd_ruangan"
    End Function

    ''' <summary>
    ''' Parameter untuk query INSERT/UPDATE.
    ''' </summary>
    Protected Overrides Function GetQueryParameters() As MySqlParameter()
        Return {
            New MySqlParameter("@kd_ruangan", txtIdRuangan.Text.Trim()),
            New MySqlParameter("@nama_ruangan", txtNamaRuangan.Text.Trim().ToUpper()),
            New MySqlParameter("@kapasitas", CInt(nudKapasitas.Value))
        }
    End Function
#End Region

#Region "Override Methods - Form Reset"
    ''' <summary>
    ''' Clear form dan reset ke default.
    ''' </summary>
    Protected Overrides Sub ClearForm()
        txtIdRuangan.Text = GenerateKodeRuangan()
        txtNamaRuangan.Clear()
        nudKapasitas.Value = 30
    End Sub
#End Region

End Class
