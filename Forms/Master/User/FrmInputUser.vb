Imports MySql.Data.MySqlClient

''' <summary>
''' Form input/edit User.
''' Kolom database: id_user, nama_user, pass_user (CHAR(6)), level_user
''' </summary>
Public Class FrmInputUser

#Region "Override Properties"
    Protected Overrides ReadOnly Property TableName As String
        Get
            Return "tbl_user"
        End Get
    End Property

    Protected Overrides ReadOnly Property PrimaryKey As String
        Get
            Return "id_user"
        End Get
    End Property

    Protected Overrides ReadOnly Property ModuleName As String
        Get
            Return "User"
        End Get
    End Property
#End Region

#Region "Override Methods - Initialization"
    ''' <summary>
    ''' Inisialisasi form: generate ID, isi combo, set default.
    ''' </summary>
    Protected Overrides Sub InitializeForm()
        IsiComboBoxManual(cmbLevelUser, {"Administrator", "Dosen"}, "-- Pilih Level --")

        txtPasswordUser.PasswordChar = "*"c
        txtPasswordUser.MaxLength = 6

        If Not IsEditMode Then
            txtIdUser.Text = GenerateIdUser()
        End If

        txtIdUser.ReadOnly = True
        txtIdUser.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

    ''' <summary>
    ''' Load data ke form saat mode edit.
    ''' </summary>
    Protected Overrides Sub LoadFormData()
        Dim row As DataRow = LoadSingleRecord()
        If row IsNot Nothing Then
            txtIdUser.Text = NullToString(row("id_user"))
            txtNamaUser.Text = NullToString(row("nama_user"))
            txtPasswordUser.Text = ""

            Dim level As String = NullToString(row("level_user"))
            For i As Integer = 0 To cmbLevelUser.Items.Count - 1
                If cmbLevelUser.Items(i).ToString().Equals(level, StringComparison.OrdinalIgnoreCase) Then
                    cmbLevelUser.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Focus ke field nama saat form dibuka.
    ''' </summary>
    Protected Overrides Sub FocusFirstInput()
        txtNamaUser.Focus()
    End Sub
#End Region

#Region "Override Methods - Save Execution (Repository Pattern)"
    ''' <summary>
    ''' Eksekusi simpan menggunakan UserRepository.
    ''' </summary>
    Protected Overrides Function ExecuteSave() As Boolean
        Dim repo As New UserRepository()
        Dim user As UserEntity = MapUItoEntity()

        ' Khusus User: Tangani logika password (jangan update jika kosong pada mode Edit)
        If IsEditMode Then
            Return repo.Update(user)
        Else
            Return repo.Insert(user)
        End If
    End Function

    ''' <summary>
    ''' Helper untuk memetakan nilai dari UI ke objek Entity.
    ''' </summary>
    Private Function MapUItoEntity() As UserEntity
        Dim user As New UserEntity()
        user.Kode = txtIdUser.Text.Trim()
        user.NamaUser = txtNamaUser.Text.Trim()

        ' Password hanya diisi jika tidak kosong (terutama untuk mode Edit)
        If Not String.IsNullOrEmpty(txtPasswordUser.Text) OrElse Not IsEditMode Then
            user.PassUser = txtPasswordUser.Text
        End If

        If cmbLevelUser.SelectedIndex > 0 Then
            user.LevelUser = cmbLevelUser.SelectedItem.ToString()
        End If

        Return user
    End Function
#End Region

#Region "Override Methods - Validation"
    ''' <summary>
    ''' Validasi input sebelum save.
    ''' Menggunakan UserEntity untuk validasi OOP.
    ''' </summary>
    Protected Overrides Function ValidateInput() As Boolean
        Dim user As UserEntity

        Try
            user = MapUItoEntity()
        Catch ex As ArgumentException
            ShowError(ex.Message)
            Return False
        End Try

        If Not user.IsValid() Then
            ShowError(String.Join(vbCrLf, user.GetValidationErrors()))
            Return False
        End If

        If Not ValidateNoDuplicate("nama_user", txtNamaUser.Text.Trim(), "Nama User") Then
            txtNamaUser.Focus()
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Override Methods - Query (Removed in favor of Repository)"
    ' Logika SQL dipindahkan ke UserRepository.vb
#End Region

#Region "Override Methods - Form Reset"
    ''' <summary>
    ''' Clear form dan reset ke default.
    ''' </summary>
    Protected Overrides Sub ClearForm()
        txtIdUser.Text = GenerateIdUser()
        txtNamaUser.Clear()
        txtPasswordUser.Clear()
        cmbLevelUser.SelectedIndex = 0
    End Sub
#End Region

End Class
