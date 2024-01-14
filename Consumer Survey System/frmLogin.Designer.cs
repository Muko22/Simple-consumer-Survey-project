namespace Consumer_Survey_System
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.LinkLabel linklblRegister;
            System.Windows.Forms.LinkLabel lnklblForgotPassword;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblLoginHeader = new System.Windows.Forms.Label();
            this.lblRegister = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.tmrLogin = new System.Windows.Forms.Timer(this.components);
            this.pbxViewPassword = new System.Windows.Forms.PictureBox();
            this.pbxHidePassword = new System.Windows.Forms.PictureBox();
            linklblRegister = new System.Windows.Forms.LinkLabel();
            lnklblForgotPassword = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxViewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHidePassword)).BeginInit();
            this.SuspendLayout();
            // 
            // linklblRegister
            // 
            linklblRegister.AutoSize = true;
            linklblRegister.Font = new System.Drawing.Font("Raleway", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            linklblRegister.Location = new System.Drawing.Point(201, 312);
            linklblRegister.Name = "linklblRegister";
            linklblRegister.Size = new System.Drawing.Size(48, 13);
            linklblRegister.TabIndex = 4;
            linklblRegister.TabStop = true;
            linklblRegister.Text = "Register";
            linklblRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblRegister_LinkClicked);
            // 
            // lblLoginHeader
            // 
            this.lblLoginHeader.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginHeader.Location = new System.Drawing.Point(112, 16);
            this.lblLoginHeader.Name = "lblLoginHeader";
            this.lblLoginHeader.Size = new System.Drawing.Size(98, 27);
            this.lblLoginHeader.TabIndex = 19;
            this.lblLoginHeader.Text = "LOGIN";
            this.lblLoginHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Font = new System.Drawing.Font("Raleway", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegister.Location = new System.Drawing.Point(72, 312);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(126, 13);
            this.lblRegister.TabIndex = 18;
            this.lblRegister.Text = "Don\'t have an account?";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(29)))), ((int)(((byte)(94)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(104, 232);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(115, 32);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(38, 131);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(74, 18);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(41, 160);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(243, 25);
            this.txtPassword.TabIndex = 2;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(38, 61);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(46, 18);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(40, 88);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(242, 25);
            this.txtEmail.TabIndex = 1;
            // 
            // tmrLogin
            // 
            this.tmrLogin.Interval = 1000;
            this.tmrLogin.Tick += new System.EventHandler(this.tmrLogin_Tick);
            // 
            // pbxViewPassword
            // 
            this.pbxViewPassword.Image = global::Consumer_Survey_System.Properties.Resources.icons8_eye_24;
            this.pbxViewPassword.Location = new System.Drawing.Point(40, 192);
            this.pbxViewPassword.Name = "pbxViewPassword";
            this.pbxViewPassword.Size = new System.Drawing.Size(24, 24);
            this.pbxViewPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxViewPassword.TabIndex = 20;
            this.pbxViewPassword.TabStop = false;
            this.pbxViewPassword.Click += new System.EventHandler(this.pbxViewPassword_Click);
            // 
            // pbxHidePassword
            // 
            this.pbxHidePassword.Image = global::Consumer_Survey_System.Properties.Resources.icons8_hide_24;
            this.pbxHidePassword.Location = new System.Drawing.Point(40, 192);
            this.pbxHidePassword.Name = "pbxHidePassword";
            this.pbxHidePassword.Size = new System.Drawing.Size(24, 24);
            this.pbxHidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxHidePassword.TabIndex = 21;
            this.pbxHidePassword.TabStop = false;
            this.pbxHidePassword.Visible = false;
            this.pbxHidePassword.Click += new System.EventHandler(this.pbxHidePassword_Click);
            // 
            // lnklblForgotPassword
            // 
            lnklblForgotPassword.AutoSize = true;
            lnklblForgotPassword.Font = new System.Drawing.Font("Raleway", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lnklblForgotPassword.Location = new System.Drawing.Point(184, 192);
            lnklblForgotPassword.Name = "lnklblForgotPassword";
            lnklblForgotPassword.Size = new System.Drawing.Size(100, 13);
            lnklblForgotPassword.TabIndex = 22;
            lnklblForgotPassword.TabStop = true;
            lnklblForgotPassword.Text = "Forgot password?";
            lnklblForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblForgotPassword_LinkClicked);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(323, 339);
            this.Controls.Add(lnklblForgotPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.pbxViewPassword);
            this.Controls.Add(this.pbxHidePassword);
            this.Controls.Add(this.lblLoginHeader);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(linklblRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblUsername);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumer Survey System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxViewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHidePassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxHidePassword;
        private System.Windows.Forms.PictureBox pbxViewPassword;
        private System.Windows.Forms.Label lblLoginHeader;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Timer tmrLogin;
    }
}