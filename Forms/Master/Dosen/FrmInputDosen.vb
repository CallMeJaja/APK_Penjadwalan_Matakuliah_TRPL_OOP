Imports MySql.Data.MySqlClient

''' <summary>
''' Form input/edit Dosen.
''' Inherit dari FrmBaseInput dengan validasi email, phone, NIDN, dan FK ke Prodi.
''' Kolom database: kd_dosen, kd_prodi, nidn_dosen, nama_dosen, jk_dosen, no_telp_dosen, email_dosen
''' </summary>
Public Class FrmInputDosen

#Region "Override Properties"
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_dosen"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_dosen"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Dosen"
        End Get
    End Property
#End Region

#Region "Override Methods - Initialization"
    ''' <summary>
    ''' Inisialisasi form: generate kode, isi combo, set default.
    ''' </summary>
    Protected Overrides Sub InitializeForm()
        IsiComboBox(cmbProdi, "SELECT kd_prodi, nama_prodi FROM tbl_prodi ORDER BY nama_prodi",
                    "nama_prodi", "kd_prodi", "-- Pilih Program Studi --")
        AutoWidthDropDown(cmbProdi)

        IsiComboBoxManual(cmbJenisKemain, {"LAKI-LAKI", "PEREMPUAN"}, "-- Pilih --")
        AutoWidthDropDown(cmbJenisKemain)

        If Not IsEditMode Then
            txtKodeDosen.Text = GenerateKodeDosen()
        End If

        txtKodeDosen.ReadOnly = True
        txtKodeDosen.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

    ''' <summary>
    ''' Load data ke form saat mode edit.
    ''' </summary>
    Protected Overrides Sub LoadFormData()
        Dim row As DataRow = LoadSingleRecord()
        If row IsNot Nothing Then
            txtKodeDosen.Text = NullToString(row("kd_dosen"))
            txtNidnDosen.Text = NullToString(row("nidn_dosen"))
            txtNamaDosen.Text = NullToString(row("nama_dosen"))
            SetComboBoxValue(cmbProdi, NullToString(row("kd_prodi")))

            Dim gender As String = NullToString(row("jk_dosen"))
            For i As Integer = 0 To cmbJenisKemain.Items.Count - 1
                If cmbJenisKemain.Items(i).ToString().Equals(gender, StringComparison.OrdinalIgnoreCase) Then
                    cmbJenisKemain.SelectedIndex = i
                    Exit For
                End If
            Next

            txtNoTelpDosen.Text = NullToString(row("no_telp_dosen"))

            txtEmailDosen.Text = NullToString(row("email_dosen"))
        End If
    End Sub

    ''' <summary>
    ''' Focus ke field NIDN saat form dibuka.
    ''' </summary>
    Protected Overrides Sub FocusFirstInput()
        txtNidnDosen.Focus()
    End Sub
#End Region

#Region "Override Methods - Validation"
    ''' <summary>
    ''' Validasi input sebelum save.
    ''' Menggunakan DosenEntity untuk validasi dasar (OOP),
    ''' lalu validasi database untuk cek duplikat.
    ''' </summary>
    Protected Overrides Function ValidateInput() As Boolean
        Dim dosen As New DosenEntity()

        Try
            dosen.Kode = txtKodeDosen.Text.Trim()
            dosen.KdProdi = If(cmbProdi.SelectedValue?.ToString(), "")
            dosen.NidnDosen = txtNidnDosen.Text.Trim()
            dosen.NamaDosen = txtNamaDosen.Text.Trim()

            If cmbJenisKemain.SelectedIndex > 0 Then
                dosen.JkDosen = cmbJenisKemain.SelectedItem.ToString()
            Else
                dosen.JkDosen = ""
            End If

            dosen.NoTelpDosen = txtNoTelpDosen.Text.Trim()
            dosen.EmailDosen = txtEmailDosen.Text.Trim()

        Catch ex As ArgumentException
            ShowError(ex.Message)
            Return False
        End Try

        ' Validasi entity menggunakan method IsValid()
        If Not dosen.IsValid() Then
            ShowError(String.Join(vbCrLf, dosen.GetValidationErrors()))
            Return False
        End If

        ' ===== VALIDASI DATABASE (CEK DUPLIKAT) =====
        ' Validasi duplikat NIDN
        If Not ValidateNoDuplicate("nidn_dosen", txtNidnDosen.Text.Trim(), "NIDN") Then
            txtNidnDosen.Focus()
            Return False
        End If

        ' Validasi duplikat nomor telepon (jika diisi)
        Dim noTelp As String = txtNoTelpDosen.Text.Trim()
        If Not String.IsNullOrEmpty(noTelp) Then
            If Not ValidateNoDuplicate("no_telp_dosen", noTelp, "Nomor Telepon") Then
                txtNoTelpDosen.Focus()
                Return False
            End If
        End If

        ' Validasi duplikat email (jika diisi)
        If Not String.IsNullOrWhiteSpace(txtEmailDosen.Text) Then
            If Not ValidateNoDuplicate("email_dosen", txtEmailDosen.Text.Trim(), "Email") Then
                txtEmailDosen.Focus()
                Return False
            End If
        End If

        Return True
    End Function
#End Region

#Region "Override Methods - Query"
    ''' <summary>
    ''' Query INSERT untuk Dosen.
    ''' Kolom: kd_dosen, kd_prodi, nidn_dosen, nama_dosen, jk_dosen, no_telp_dosen, email_dosen
    ''' </summary>
    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_dosen (kd_dosen, kd_prodi, nidn_dosen, nama_dosen, jk_dosen, no_telp_dosen, email_dosen) " &
               "VALUES (@kd_dosen, @kd_prodi, @nidn_dosen, @nama_dosen, @jk_dosen, @no_telp_dosen, @email_dosen)"
    End Function

    ''' <summary>
    ''' Query UPDATE untuk Dosen.
    ''' </summary>
    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_dosen SET kd_prodi = @kd_prodi, nidn_dosen = @nidn_dosen, nama_dosen = @nama_dosen, " &
               "jk_dosen = @jk_dosen, no_telp_dosen = @no_telp_dosen, email_dosen = @email_dosen " &
               "WHERE kd_dosen = @kd_dosen"
    End Function

    ''' <summary>
    ''' Parameter untuk query INSERT/UPDATE.
    ''' </summary>
    Protected Overrides Function GetQueryParameters() As MySqlParameter()
        Dim noTelp As Object = DBNull.Value
        If Not String.IsNullOrWhiteSpace(txtNoTelpDosen.Text) Then
            noTelp = txtNoTelpDosen.Text.Trim()
        End If

        Dim gender As String = ""
        If cmbJenisKemain.SelectedIndex > 0 Then
            gender = cmbJenisKemain.SelectedItem.ToString()
        End If

        Return {
            New MySqlParameter("@kd_dosen", txtKodeDosen.Text.Trim()),
            New MySqlParameter("@kd_prodi", If(cmbProdi.SelectedValue, DBNull.Value)),
            New MySqlParameter("@nidn_dosen", txtNidnDosen.Text.Trim()),
            New MySqlParameter("@nama_dosen", txtNamaDosen.Text.Trim().ToUpper()),
            New MySqlParameter("@jk_dosen", gender),
            New MySqlParameter("@no_telp_dosen", noTelp),
            New MySqlParameter("@email_dosen", If(String.IsNullOrWhiteSpace(txtEmailDosen.Text), DBNull.Value, txtEmailDosen.Text.Trim().ToLower()))
        }
    End Function
#End Region

#Region "Override Methods - Form Reset"
    ''' <summary>
    ''' Clear form dan reset ke default.
    ''' </summary>
    Protected Overrides Sub ClearForm()
        txtKodeDosen.Text = GenerateKodeDosen()
        txtNidnDosen.Clear()
        txtNamaDosen.Clear()
        cmbProdi.SelectedIndex = 0
        cmbJenisKemain.SelectedIndex = 0
        txtNoTelpDosen.Clear()
        txtEmailDosen.Clear()
    End Sub
#End Region

End Class
