namespace SellingTickets
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLogin = new Label();
            username = new TextBox();
            password = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            btnUserLogin = new Button();
            btnAdminLogin = new Button();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Showcard Gothic", 29.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblLogin.Location = new Point(194, 26);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(286, 49);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Please Log In";
            // 
            // username
            // 
            username.Location = new Point(295, 108);
            username.Margin = new Padding(3, 2, 3, 2);
            username.Name = "username";
            username.Size = new Size(158, 23);
            username.TabIndex = 1;
            // 
            // password
            // 
            password.Location = new Point(295, 169);
            password.Margin = new Padding(3, 2, 3, 2);
            password.Name = "password";
            password.PasswordChar = '*';
            password.Size = new Size(158, 23);
            password.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.Location = new Point(172, 101);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(106, 30);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.Location = new Point(172, 169);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 30);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // btnUserLogin
            // 
            btnUserLogin.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnUserLogin.Location = new Point(141, 244);
            btnUserLogin.Margin = new Padding(3, 2, 3, 2);
            btnUserLogin.Name = "btnUserLogin";
            btnUserLogin.Size = new Size(172, 52);
            btnUserLogin.TabIndex = 5;
            btnUserLogin.Text = "USER LOG IN";
            btnUserLogin.UseVisualStyleBackColor = true;
            btnUserLogin.Click += btnLogin_Click;
            // 
            // btnAdminLogin
            // 
            btnAdminLogin.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdminLogin.Location = new Point(378, 244);
            btnAdminLogin.Margin = new Padding(3, 2, 3, 2);
            btnAdminLogin.Name = "btnAdminLogin";
            btnAdminLogin.Size = new Size(172, 52);
            btnAdminLogin.TabIndex = 6;
            btnAdminLogin.Text = "ADMIN LOG IN";
            btnAdminLogin.UseVisualStyleBackColor = true;
            btnAdminLogin.Click += btnAdminLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnAdminLogin);
            Controls.Add(btnUserLogin);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(lblLogin);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            Text = "Tickets Sales";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private TextBox username;
        private TextBox password;
        private Label lblUsername;
        private Label lblPassword;
        private Button login;
        private Button btnUserLogin;
        private Button btnAdminLogin;
    }
}