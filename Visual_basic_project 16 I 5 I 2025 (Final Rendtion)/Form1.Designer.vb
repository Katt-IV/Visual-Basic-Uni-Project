<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        company_logo = New PictureBox()
        username_input = New TextBox()
        company_name = New PictureBox()
        password_input = New TextBox()
        user_icon = New PictureBox()
        password_icon = New PictureBox()
        btn_exit_form1 = New Button()
        login_button = New Button()
        Panel1 = New Panel()
        CType(company_logo, ComponentModel.ISupportInitialize).BeginInit()
        CType(company_name, ComponentModel.ISupportInitialize).BeginInit()
        CType(user_icon, ComponentModel.ISupportInitialize).BeginInit()
        CType(password_icon, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' company_logo
        ' 
        company_logo.BackgroundImageLayout = ImageLayout.Stretch
        company_logo.Image = My.Resources.Resources.Logo
        company_logo.Location = New Point(0, 8)
        company_logo.Margin = New Padding(2)
        company_logo.Name = "company_logo"
        company_logo.Size = New Size(600, 586)
        company_logo.SizeMode = PictureBoxSizeMode.StretchImage
        company_logo.TabIndex = 0
        company_logo.TabStop = False
        ' 
        ' username_input
        ' 
        username_input.Location = New Point(663, 176)
        username_input.Margin = New Padding(2)
        username_input.Name = "username_input"
        username_input.Size = New Size(265, 23)
        username_input.TabIndex = 1
        ' 
        ' company_name
        ' 
        company_name.Image = My.Resources.Resources.Company_Name
        company_name.Location = New Point(365, 8)
        company_name.Margin = New Padding(2)
        company_name.Name = "company_name"
        company_name.Size = New Size(646, 82)
        company_name.SizeMode = PictureBoxSizeMode.CenterImage
        company_name.TabIndex = 2
        company_name.TabStop = False
        ' 
        ' password_input
        ' 
        password_input.Location = New Point(663, 212)
        password_input.Margin = New Padding(2)
        password_input.Name = "password_input"
        password_input.Size = New Size(265, 23)
        password_input.TabIndex = 4
        password_input.UseSystemPasswordChar = True
        ' 
        ' user_icon
        ' 
        user_icon.Image = My.Resources.Resources.user
        user_icon.Location = New Point(628, 176)
        user_icon.Margin = New Padding(2)
        user_icon.Name = "user_icon"
        user_icon.Size = New Size(30, 18)
        user_icon.SizeMode = PictureBoxSizeMode.Zoom
        user_icon.TabIndex = 5
        user_icon.TabStop = False
        ' 
        ' password_icon
        ' 
        password_icon.Image = My.Resources.Resources.lock
        password_icon.Location = New Point(628, 212)
        password_icon.Margin = New Padding(2)
        password_icon.Name = "password_icon"
        password_icon.Size = New Size(30, 18)
        password_icon.SizeMode = PictureBoxSizeMode.Zoom
        password_icon.TabIndex = 6
        password_icon.TabStop = False
        ' 
        ' btn_exit_form1
        ' 
        btn_exit_form1.BackColor = Color.White
        btn_exit_form1.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_exit_form1.Location = New Point(663, 266)
        btn_exit_form1.Margin = New Padding(2)
        btn_exit_form1.Name = "btn_exit_form1"
        btn_exit_form1.Size = New Size(114, 28)
        btn_exit_form1.TabIndex = 7
        btn_exit_form1.Text = "Exit"
        btn_exit_form1.UseVisualStyleBackColor = False
        ' 
        ' login_button
        ' 
        login_button.Font = New Font("Microsoft Sans Serif", 11.1428566F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        login_button.Location = New Point(814, 266)
        login_button.Margin = New Padding(2)
        login_button.Name = "login_button"
        login_button.Size = New Size(111, 28)
        login_button.TabIndex = 8
        login_button.Text = "Log-IN"
        login_button.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Bottom
        Panel1.AutoSize = True
        Panel1.Controls.Add(company_name)
        Panel1.Controls.Add(company_logo)
        Panel1.Controls.Add(login_button)
        Panel1.Controls.Add(btn_exit_form1)
        Panel1.Controls.Add(username_input)
        Panel1.Controls.Add(password_icon)
        Panel1.Controls.Add(user_icon)
        Panel1.Controls.Add(password_input)
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1302, 712)
        Panel1.TabIndex = 9
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Turquoise
        ClientSize = New Size(1302, 712)
        Controls.Add(Panel1)
        Margin = New Padding(2)
        Name = "Form1"
        Text = "LOG-IN"
        CType(company_logo, ComponentModel.ISupportInitialize).EndInit()
        CType(company_name, ComponentModel.ISupportInitialize).EndInit()
        CType(user_icon, ComponentModel.ISupportInitialize).EndInit()
        CType(password_icon, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents company_logo As PictureBox
    Friend WithEvents username_input As TextBox
    Friend WithEvents company_name As PictureBox
    Friend WithEvents password_input As TextBox
    Friend WithEvents user_icon As PictureBox
    Friend WithEvents password_icon As PictureBox
    Friend WithEvents btn_exit_form1 As Button
    Friend WithEvents login_button As Button
    Friend WithEvents Panel1 As Panel

End Class
