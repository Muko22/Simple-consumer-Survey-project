namespace Consumer_Survey_System
{
    partial class frmForgotPassword
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
            System.Windows.Forms.LinkLabel linklblLogin;
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblRepeatPassword = new System.Windows.Forms.Label();
            this.txtRepeatPassword = new System.Windows.Forms.TextBox();
            this.lblLoginHeader = new System.Windows.Forms.Label();
            this.lblNRC = new System.Windows.Forms.Label();
            this.txtNRC = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.pbxViewPassword = new System.Windows.Forms.PictureBox();
            this.pbxHidePassword = new System.Windows.Forms.PictureBox();
            linklblLogin = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxViewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHidePassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(40, 144);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(111, 18);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.Location = new System.Drawing.Point(40, 176);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.Size = new System.Drawing.Size(243, 25);
            this.txtNewPassword.TabIndex = 16;
            // 
            // lblRepeatPassword
            // 
            this.lblRepeatPassword.AutoSize = true;
            this.lblRepeatPassword.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeatPassword.Location = new System.Drawing.Point(40, 224);
            this.lblRepeatPassword.Name = "lblRepeatPassword";
            this.lblRepeatPassword.Size = new System.Drawing.Size(128, 18);
            this.lblRepeatPassword.TabIndex = 48;
            this.lblRepeatPassword.Text = "Repeat Password";
            // 
            // txtRepeatPassword
            // 
            this.txtRepeatPassword.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepeatPassword.Location = new System.Drawing.Point(40, 256);
            this.txtRepeatPassword.Name = "txtRepeatPassword";
            this.txtRepeatPassword.PasswordChar = '•';
            this.txtRepeatPassword.Size = new System.Drawing.Size(243, 25);
            this.txtRepeatPassword.TabIndex = 49;
            // 
            // lblLoginHeader
            // 
            this.lblLoginHeader.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginHeader.Location = new System.Drawing.Point(40, 24);
            this.lblLoginHeader.Name = "lblLoginHeader";
            this.lblLoginHeader.Size = new System.Drawing.Size(240, 27);
            this.lblLoginHeader.TabIndex = 50;
            this.lblLoginHeader.Text = "PASSWORD RESET";
            this.lblLoginHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNRC
            // 
            this.lblNRC.AutoSize = true;
            this.lblNRC.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNRC.Location = new System.Drawing.Point(38, 69);
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Size = new System.Drawing.Size(102, 18);
            this.lblNRC.TabIndex = 59;
            this.lblNRC.Text = "NRC Number";
            // 
            // txtNRC
            // 
            this.txtNRC.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNRC.Location = new System.Drawing.Point(40, 96);
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(243, 25);
            this.txtNRC.TabIndex = 60;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(29)))), ((int)(((byte)(94)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(96, 328);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(115, 32);
            this.btnReset.TabIndex = 61;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // linklblLogin
            // 
            linklblLogin.AutoSize = true;
            linklblLogin.Font = new System.Drawing.Font("Raleway", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            linklblLogin.Location = new System.Drawing.Point(96, 408);
            linklblLogin.Name = "linklblLogin";
            linklblLogin.Size = new System.Drawing.Size(119, 13);
            linklblLogin.TabIndex = 62;
            linklblLogin.TabStop = true;
            linklblLogin.Text = "Return to login screen";
            linklblLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblLogin_LinkClicked);
            // 
            // pbxViewPassword
            // 
            this.pbxViewPassword.Image = global::Consumer_Survey_System.Properties.Resources.icons8_eye_24;
            this.pbxViewPassword.Location = new System.Drawing.Point(40, 288);
            this.pbxViewPassword.Name = "pbxViewPassword";
            this.pbxViewPassword.Size = new System.Drawing.Size(24, 24);
            this.pbxViewPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxViewPassword.TabIndex = 63;
            this.pbxViewPassword.TabStop = false;
            this.pbxViewPassword.Click += new System.EventHandler(this.pbxViewPassword_Click);
            // 
            // pbxHidePassword
            // 
            this.pbxHidePassword.Image = global::Consumer_Survey_System.Properties.Resources.icons8_hide_24;
            this.pbxHidePassword.Location = new System.Drawing.Point(40, 288);
            this.pbxHidePassword.Name = "pbxHidePassword";
            this.pbxHidePassword.Size = new System.Drawing.Size(24, 24);
            this.pbxHidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxHidePassword.TabIndex = 64;
            this.pbxHidePassword.TabStop = false;
            this.pbxHidePassword.Visible = false;
            this.pbxHidePassword.Click += new System.EventHandler(this.pbxHidePassword_Click);
            // 
            // frmForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 437);
            this.Controls.Add(this.pbxHidePassword);
            this.Controls.Add(linklblLogin);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblNRC);
            this.Controls.Add(this.txtNRC);
            this.Controls.Add(this.lblLoginHeader);
            this.Controls.Add(this.lblRepeatPassword);
            this.Controls.Add(this.txtRepeatPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.pbxViewPassword);
            this.Name = "frmForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumer Survey System";
            ((System.ComponentModel.ISupportInitialize)(this.pbxViewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHidePassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblRepeatPassword;
        private System.Windows.Forms.TextBox txtRepeatPassword;
        private System.Windows.Forms.Label lblLoginHeader;
        private System.Windows.Forms.Label lblNRC;
        private System.Windows.Forms.TextBox txtNRC;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox pbxViewPassword;
        private System.Windows.Forms.PictureBox pbxHidePassword;
    }
}