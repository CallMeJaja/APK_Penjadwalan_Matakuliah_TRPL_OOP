Imports MySql.Data.MySqlClient

Public Class FrmLogin
    ''' <summary>
    ''' Event handler saat form login dimuat.
    ''' </summary>
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Clear()
        txtPassword.Clear()
        cmbLevel.SelectedIndex = 0
        txtUsername.Focus()
    End Sub

    ''' <summary>
    ''' Prosedur untuk melakukan login.
    ''' Memeriksa username, password, dan level di tbl_user.
    ''' </summary>
    Private Sub LoginAction()
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            ShowWarning("Username dan Password tidak boleh kosong!")
            Exit Sub
        End If

        Try
            Dim sql As String = "SELECT id_user, nama_user, level_user FROM tbl_user " &
                                "WHERE nama_user = @username AND pass_user = @password AND level_user = @level"

            BukaKoneksi()
            Using cmd As New MySqlCommand(sql, Conn)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
                cmd.Parameters.AddWithValue("@level", cmbLevel.Text)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        Dim userId As String = dr("id_user").ToString()
                        Dim userName As String = dr("nama_user").ToString()
                        Dim userLevel As String = dr("level_user").ToString()

                        SetSession(userId, userName, userLevel)

                        ShowSuccess("Selamat datang, " & userName & "!" & vbCrLf & "Anda login sebagai " & userLevel & ".")

                        FrmMenuUtama.ApplySecuritySettings()
                        FrmMenuUtama.Show()
                        Me.Hide()
                    Else
                        ShowError("Login Gagal! Username, Password, atau Level salah.")
                        txtPassword.Clear()
                        txtPassword.Focus()
                    End If
                End Using
            End Using
        Catch ex As Exception
            ShowError("Terjadi kesalahan saat login: " & ex.Message)
        Finally
            TutupKoneksi()
        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        LoginAction()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        If ShowConfirm("Yakin ingin keluar dari aplikasi?") Then
            Application.Exit()
        End If
    End Sub

    Private Sub chkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPass.CheckedChanged
        If chkShowPass.Checked Then
            txtPassword.UseSystemPasswordChar = False
            txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(0) 
        Else
            txtPassword.UseSystemPasswordChar = True
            txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        End If
    End Sub

    ''' <summary>
    ''' Memungkinkan login dengan menekan tombol Enter pada password field.
    ''' </summary>
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoginAction()
        End If
    End Sub

End Class