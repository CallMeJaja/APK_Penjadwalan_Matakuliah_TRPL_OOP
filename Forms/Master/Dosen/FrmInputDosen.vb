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

#Region "Override Methods - Save Execution (Repository Pattern)"
    ''' <summary>
    ''' Eksekusi simpan menggunakan DosenRepository.
    ''' </summary>
    Protected Overrides Function ExecuteSave() As Boolean
        Dim repo As New DosenRepository()
        Dim dosen As DosenEntity = MapUItoEntity()

        If IsEditMode Then
            Return repo.Update(dosen)
        Else
            Return repo.Insert(dosen)
        End If
    End Function

    ''' <summary>
    ''' Helper untuk memetakan nilai dari UI ke objek Entity.
    ''' </summary>
    Private Function MapUItoEntity() As DosenEntity
        Dim dosen As New DosenEntity()
        dosen.Kode = txtKodeDosen.Text.Trim()
        dosen.KdProdi = If(cmbProdi.SelectedValue?.ToString(), "")
        dosen.NidnDosen = txtNidnDosen.Text.Trim()
        dosen.NamaDosen = txtNamaDosen.Text.Trim().ToUpper()

        If cmbJenisKemain.SelectedIndex > 0 Then
            dosen.JkDosen = cmbJenisKemain.SelectedItem.ToString()
        End If

        dosen.NoTelpDosen = txtNoTelpDosen.Text.Trim()
        dosen.EmailDosen = txtEmailDosen.Text.Trim().ToLower()

        Return dosen
    End Function
#End Region

#Region "Override Methods - Validation"
    ''' <summary>
    ''' Validasi input sebelum save.
    ''' Menggunakan DosenEntity untuk validasi dasar (OOP),
    ''' lalu validasi database untuk cek duplikat melalui Base Class.
    ''' </summary>
    Protected Overrides Function ValidateInput() As Boolean
        Dim dosen As DosenEntity

        Try
            dosen = MapUItoEntity()
        Catch ex As ArgumentException
            ShowError(ex.Message)
            Return False
        End Try

        ' Validasi entity menggunakan method IsValid() (Pilar Encapsulation)
        If Not dosen.IsValid() Then
            ShowError(String.Join(vbCrLf, dosen.GetValidationErrors()))
            Return False
        End If

        ' ===== VALIDASI DATABASE (CEK DUPLIKAT) =====
        ' Tetap menggunakan helper di FrmBaseInput karena bersifat infrastruktur pencarian
        If Not ValidateNoDuplicate("nidn_dosen", txtNidnDosen.Text.Trim(), "NIDN") Then
            txtNidnDosen.Focus()
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Override Methods - Query (Deprecated/Removed in favor of Repository)"
    ' Logika Query SQL telah dipindahkan ke DosenRepository.vb
    ' Mengapa? Sesuai prinsip Separation of Concerns (Pemisahan Tanggung Jawab)
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
