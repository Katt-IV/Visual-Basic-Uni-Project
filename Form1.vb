Imports System.Drawing.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        Placeholdername()
        Placeholderpassword()
    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles username_input.MouseClick
        If username_input.Text = "Username" Then
            username_input.ForeColor = Color.Black
            username_input.Text = ""
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles username_input.Leave
        Placeholdername()
    End Sub

    Private Sub TextBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles password_input.MouseClick
        If password_input.Text = "password" Then
            password_input.ForeColor = Color.Black
            password_input.Text = ""
        End If
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles password_input.Leave
        Placeholderpassword()
    End Sub





    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles login_button.Click
        con.Open()
        Try

            Dim com As New SqlCommand("select account_lvl from employee_records where account_passcode ='" & password_input.Text & "' and account_name ='" & username_input.Text & "'", con)
            Dim s As Integer = com.ExecuteScalar
            Dim form2 As New Form2()

            Select Case (s)
                Case -1
                    MessageBox.Show("This account is frozen. For more info, contact the manager.", "Account Frozen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Case 3
                    form2.n_1 = s
                    form2.Show()
                    Me.Hide()


                Case 2
                    form2.n_1 = s
                    form2.Show()
                    Me.Hide()

                Case 1
                    form2.n_1 = s
                    form2.Show()
                    Me.Hide()
                Case Else
                    MessageBox.Show("Wrong Password or Username.")

            End Select


        Catch ex As Exception
            MsgBox(ex.Message & "")
        Finally
            con.Close()
        End Try
    End Sub



    Public Sub password_input_TextChanged(sender As Object, e As EventArgs) Handles password_input.TextChanged

        Dim font As New Font("Arial", 14, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)
        Dim position As New Point(10, 10)
        password_input.UseSystemPasswordChar = True
    End Sub

    Public Sub username_input_TextChanged(sender As Object, e As EventArgs) Handles username_input.TextChanged

    End Sub

    Private Sub btn_exit_form1_Click(sender As Object, e As EventArgs) Handles btn_exit_form1.Click
        If con.State = ConnectionState.Open Then con.Close()
        Application.Exit()
    End Sub

    Private Sub Placeholdername()
        If username_input.Text = "" Then
            username_input.Text = "Username"
            username_input.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub Placeholderpassword()
        If password_input.Text = "" Then
            password_input.Text = "password"
            password_input.ForeColor = Color.Gray
        End If
    End Sub

End Class