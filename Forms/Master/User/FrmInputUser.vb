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

#Region "Override Methods - Validation"
    ''' <summary>
    ''' Validasi input sebelum save.
    ''' Menggunakan UserEntity untuk validasi OOP.
    ''' </summary>
    Protected Overrides Function ValidateInput() As Boolean
        Dim user As New UserEntity()

        Try
            user.Kode = txtIdUser.Text.Trim()
            user.NamaUser = txtNamaUser.Text.Trim()

            If Not IsEditMode Then
                user.PassUser = txtPasswordUser.Text
            ElseIf Not String.IsNullOrEmpty(txtPasswordUser.Text) Then
                user.PassUser = txtPasswordUser.Text
            End If

            If cmbLevelUser.SelectedIndex > 0 Then
                user.LevelUser = cmbLevelUser.SelectedItem.ToString()
            Else
                user.LevelUser = ""
            End If

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

#Region "Override Methods - Query"
    ''' <summary>
    ''' Query INSERT untuk User.
    ''' Kolom: id_user, nama_user, pass_user, level_user
    ''' </summary>
    Protected Overrides Function GetInsertQuery() As String
        Return "INSERT INTO tbl_user (id_user, nama_user, pass_user, level_user) " &
               "VALUES (@id_user, @nama_user, @pass_user, @level_user)"
    End Function

    ''' <summary>
    ''' Query UPDATE untuk User.
    ''' Jika password kosong, jangan update password.
    ''' </summary>
    Protected Overrides Function GetUpdateQuery() As String
        If String.IsNullOrEmpty(txtPasswordUser.Text) Then
            Return "UPDATE tbl_user SET nama_user = @nama_user, level_user = @level_user " &
                   "WHERE id_user = @id_user"
        Else
            Return "UPDATE tbl_user SET nama_user = @nama_user, pass_user = @pass_user, level_user = @level_user " &
                   "WHERE id_user = @id_user"
        End If
    End Function

    ''' <summary>
    ''' Parameter untuk query INSERT/UPDATE.
    ''' </summary>
    Protected Overrides Function GetQueryParameters() As MySqlParameter()
        Dim level As String = ""
        If cmbLevelUser.SelectedIndex > 0 Then
            level = cmbLevelUser.SelectedItem.ToString()
        End If

        Dim params As New List(Of MySqlParameter)
        params.Add(New MySqlParameter("@id_user", txtIdUser.Text.Trim()))
        params.Add(New MySqlParameter("@nama_user", txtNamaUser.Text.Trim()))
        params.Add(New MySqlParameter("@level_user", level))

        If Not String.IsNullOrEmpty(txtPasswordUser.Text) OrElse Not IsEditMode Then
            params.Add(New MySqlParameter("@pass_user", txtPasswordUser.Text))
        End If

        Return params.ToArray()
    End Function
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
