Imports MySql.Data.MySqlClient

''' <summary>
''' Form input/edit Mata Kuliah.
''' Kolom database: kd_matkul, nama_matkul, sks_matkul, teori_matkul, praktek_matkul, semester_matkul, kd_prodi
''' </summary>
Public Class FrmInputMataKuliah

#Region "Override Properties"
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_matakuliah"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "kd_matkul"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "Mata Kuliah"
        End Get
    End Property
#End Region

#Region "Override Methods - Initialization"
    ''' <summary>
    ''' Inisialisasi form: isi combo, set default, setup events.
    ''' </summary>
    Protected Overrides Sub InitializeForm()
        IsiComboBox(cmbProdi, "SELECT kd_prodi, nama_prodi FROM tbl_prodi ORDER BY nama_prodi",
                    "nama_prodi", "kd_prodi", "-- Pilih Program Studi --")
        AutoWidthDropDown(cmbProdi)

        IsiComboBoxManual(cmbTipeSemester, {"Ganjil", "Genap"}, "-- Pilih --")
        AutoWidthDropDown(cmbTipeSemester)

        cmbSemester.Items.Clear()
        cmbSemester.Items.Add("-- Pilih --")
        cmbSemester.SelectedIndex = 0

        nudSksTeori.Minimum = 0
        nudSksTeori.Maximum = 24
        nudSksPraktek.Minimum = 0
        nudSksPraktek.Maximum = 24
        nudTotalSks.Minimum = 0
        nudTotalSks.Maximum = 24

        nudTotalSks.ReadOnly = True
        nudTotalSks.Enabled = False
        nudTotalSks.BackColor = Color.FromArgb(240, 240, 240)

        txtMenitTeori.ReadOnly = True
        txtMenitTeori.Enabled = False
        txtMenitTeori.BackColor = Color.FromArgb(240, 240, 240)

        txtMenitPraktek.ReadOnly = True
        txtMenitPraktek.Enabled = False
        txtMenitPraktek.BackColor = Color.FromArgb(240, 240, 240)

        txtTotalMenit.ReadOnly = True
        txtTotalMenit.Enabled = False
        txtTotalMenit.BackColor = Color.FromArgb(240, 240, 240)

        txtKodeMataKuliah.ReadOnly = False
        txtKodeMataKuliah.MaxLength = 7

        CalculateSKS()
    End Sub

    ''' <summary>
    ''' Setup form setelah load data.
    ''' </summary>
    Protected Overrides Sub SetupForm()
        AddHandler nudSksTeori.ValueChanged, AddressOf SKS_ValueChanged
        AddHandler nudSksPraktek.ValueChanged, AddressOf SKS_ValueChanged

        AddHandler cmbTipeSemester.SelectedIndexChanged, AddressOf TipeSemester_Changed
    End Sub

    ''' <summary>
    ''' Event handler ketika Tipe Semester berubah - filter semester.
    ''' </summary>
    Private Sub TipeSemester_Changed(sender As Object, e As EventArgs)
        FilterSemesterByTipe()
    End Sub

    ''' <summary>
    ''' Filter ComboBox Semester berdasarkan Tipe Semester.
    ''' Ganjil: 1, 3, 5, 7
    ''' Genap: 2, 4, 6, 8
    ''' </summary>
    Private Sub FilterSemesterByTipe()
        cmbSemester.Items.Clear()
        cmbSemester.Items.Add("-- Pilih --")

        If cmbTipeSemester.SelectedIndex = 1 Then
            cmbSemester.Items.Add("1")
            cmbSemester.Items.Add("3")
            cmbSemester.Items.Add("5")
            cmbSemester.Items.Add("7")
        ElseIf cmbTipeSemester.SelectedIndex = 2 Then
            cmbSemester.Items.Add("2")
            cmbSemester.Items.Add("4")
            cmbSemester.Items.Add("6")
            cmbSemester.Items.Add("8")
        End If

        cmbSemester.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Load data ke form saat mode edit.
    ''' </summary>
    Protected Overrides Sub LoadFormData()
        Dim row As DataRow = LoadSingleRecord()
        If row IsNot Nothing Then
            txtKodeMataKuliah.Text = NullToString(row("kd_matkul"))
            txtNamaMataKuliah.Text = NullToString(row("nama_matkul"))

            SetComboBoxValue(cmbProdi, NullToString(row("kd_prodi")))

            nudSksTeori.Value = NullToInt(row("teori_matkul"), 0)
            nudSksPraktek.Value = NullToInt(row("praktek_matkul"), 0)

            Dim semester As Integer = NullToInt(row("semester_matkul"), 0)
            If semester >= 1 AndAlso semester <= 8 Then
                If semester Mod 2 = 1 Then
                    cmbTipeSemester.SelectedIndex = 1
                Else
                    cmbTipeSemester.SelectedIndex = 2
                End If

                FilterSemesterByTipe()

                For i As Integer = 0 To cmbSemester.Items.Count - 1
                    If cmbSemester.Items(i).ToString() = semester.ToString() Then
                        cmbSemester.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If

            txtKodeMataKuliah.ReadOnly = True
            txtKodeMataKuliah.BackColor = Color.FromArgb(240, 240, 240)

            CalculateSKS()
        End If
    End Sub

    ''' <summary>
    ''' Focus ke field kode saat form dibuka.
    ''' </summary>
    Protected Overrides Sub FocusFirstInput()
        txtKodeMataKuliah.Focus()
    End Sub
#End Region

#Region "SKS Calculation"
    Private Const MENIT_PER_SKS_TEORI As Integer = 50
    Private Const MENIT_PER_SKS_PRAKTEK As Integer = 170 ' User specified: 170 menit per SKS praktek

    ''' <summary>
    ''' Event handler untuk perubahan nilai SKS.
    ''' </summary>
    Private Sub SKS_ValueChanged(sender As Object, e As EventArgs)
        CalculateSKS()
    End Sub

    ''' <summary>
    ''' Hitung total SKS dan menit (untuk display saja).
    ''' </summary>
    Private Sub CalculateSKS()
        Dim sksTeori As Integer = CInt(nudSksTeori.Value)
        Dim sksPraktek As Integer = CInt(nudSksPraktek.Value)
        Dim totalSks As Integer = sksTeori + sksPraktek

        Dim menitTeori As Integer = sksTeori * MENIT_PER_SKS_TEORI
        Dim menitPraktek As Integer = sksPraktek * MENIT_PER_SKS_PRAKTEK
        Dim totalMenit As Integer = menitTeori + menitPraktek

        txtMenitTeori.Text = $"{menitTeori} menit"
        txtMenitPraktek.Text = $"{menitPraktek} menit"
        txtTotalMenit.Text = $"{totalMenit} menit"

        Dim maxSks As Integer = CInt(nudTotalSks.Maximum)
        If totalSks > maxSks Then
            nudTotalSks.Value = maxSks
            nudTotalSks.ForeColor = Color.Red
        Else
            nudTotalSks.Value = totalSks
            nudTotalSks.ForeColor = Color.Black
        End If
    End Sub
#End Region

#Region "Override Methods - Validation"
    ''' <summary>
    ''' Validasi input sebelum save.
    ''' Menggunakan MatakuliahEntity untuk validasi dasar (OOP),
    ''' lalu validasi database untuk cek duplikat.
    ''' </summary>
    Protected Overrides Function ValidateInput() As Boolean
        Dim matkul As New MatakuliahEntity()

        Try
            matkul.Kode = txtKodeMataKuliah.Text.Trim()
            matkul.NamaMatkul = txtNamaMataKuliah.Text.Trim()
            matkul.TeoriMatkul = CInt(nudSksTeori.Value)
            matkul.PraktekMatkul = CInt(nudSksPraktek.Value)

            If cmbSemester.SelectedIndex > 0 Then
                Dim semester As Integer = 0
                If Integer.TryParse(cmbSemester.SelectedItem.ToString(), semester) Then
                    matkul.SemesterMatkul = semester
                End If
            End If

            If IsComboBoxSelected(cmbProdi) Then
                matkul.KdProdi = cmbProdi.SelectedValue?.ToString()
            End If

        Catch ex As ArgumentException
            ShowError(ex.Message)
            Return False
        End Try

        If Not matkul.IsValid() Then
            ShowError(String.Join(vbCrLf, matkul.GetValidationErrors()))
            Return False
        End If

        If Not IsEditMode Then
            If Not ValidateNoDuplicate("kd_matkul", txtKodeMataKuliah.Text.Trim().ToUpper(), "Kode Mata Kuliah") Then
                txtKodeMataKuliah.Focus()
                Return False
            End If
        End If

        If Not ValidateNoDuplicate("nama_matkul", txtNamaMataKuliah.Text.Trim().ToUpper(), "Nama Mata Kuliah") Then
            txtNamaMataKuliah.Focus()
            Return False
        End If

        If cmbTipeSemester.SelectedIndex <= 0 Then
            ShowError("Tipe Semester wajib dipilih!")
            cmbTipeSemester.Focus()
            Return False
        End If

        If cmbSemester.SelectedIndex <= 0 Then
            ShowError("Semester wajib dipilih!")
            cmbSemester.Focus()
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Override Methods - Query"
    ''' <summary>
    ''' Query INSERT untuk Mata Kuliah.
    ''' </summary>
    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_matakuliah (kd_matkul, nama_matkul, sks_matkul, teori_matkul, praktek_matkul, semester_matkul, kd_prodi) " &
               "VALUES (@kd_matkul, @nama_matkul, @sks_matkul, @teori_matkul, @praktek_matkul, @semester_matkul, @kd_prodi)"
    End Function

    ''' <summary>
    ''' Query UPDATE untuk Mata Kuliah.
    ''' </summary>
    Protected Overrides Function GetUpdateQuery() As String
        Return "UPDATE tbl_matakuliah SET nama_matkul = @nama_matkul, sks_matkul = @sks_matkul, " &
               "teori_matkul = @teori_matkul, praktek_matkul = @praktek_matkul, semester_matkul = @semester_matkul, kd_prodi = @kd_prodi " &
               "WHERE kd_matkul = @kd_matkul"
    End Function

    ''' <summary>
    ''' Parameter untuk query INSERT/UPDATE.
    ''' </summary>
    Protected Overrides Function GetQueryParameters() As MySqlParameter()
        Dim sksTeori As Integer = CInt(nudSksTeori.Value)
        Dim sksPraktek As Integer = CInt(nudSksPraktek.Value)
        Dim totalSks As Integer = sksTeori + sksPraktek

        Dim semester As Integer = 0
        If cmbSemester.SelectedIndex > 0 Then
            Integer.TryParse(cmbSemester.SelectedItem.ToString(), semester)
        End If

        Return {
            New MySqlParameter("@kd_matkul", txtKodeMataKuliah.Text.Trim().ToUpper()),
            New MySqlParameter("@nama_matkul", txtNamaMataKuliah.Text.Trim().ToUpper()),
            New MySqlParameter("@sks_matkul", totalSks),
            New MySqlParameter("@teori_matkul", sksTeori),
            New MySqlParameter("@praktek_matkul", sksPraktek),
            New MySqlParameter("@semester_matkul", semester),
            New MySqlParameter("@kd_prodi", If(IsComboBoxSelected(cmbProdi), cmbProdi.SelectedValue, DBNull.Value))
        }
    End Function
#End Region

#Region "Override Methods - Form Reset"
    ''' <summary>
    ''' Clear form dan reset ke default.
    ''' </summary>
    Protected Overrides Sub ClearForm()
        txtKodeMataKuliah.Clear()
        txtNamaMataKuliah.Clear()
        cmbTipeSemester.SelectedIndex = 0
        cmbProdi.SelectedIndex = 0
        nudSksTeori.Value = 0
        nudSksPraktek.Value = 0
        cmbSemester.SelectedIndex = 0
        CalculateSKS()
    End Sub
#End Region

End Class
