namespace Consumer_Survey_System
{
    partial class frmConsumerMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumerMain));
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSurveys = new System.Windows.Forms.Button();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.dgvSurveys = new System.Windows.Forms.DataGridView();
            this.btnAnswerSurvey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pnlSideMenu.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(29)))), ((int)(((byte)(94)))));
            this.pnlSideMenu.Controls.Add(this.lblUsername);
            this.pnlSideMenu.Controls.Add(this.label2);
            this.pnlSideMenu.Controls.Add(this.pictureBox3);
            this.pnlSideMenu.Controls.Add(this.btnLogout);
            this.pnlSideMenu.Controls.Add(this.btnSurveys);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(254, 550);
            this.pnlSideMenu.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(29)))), ((int)(((byte)(94)))));
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 146);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(254, 48);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSurveys
            // 
            this.btnSurveys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(9)))), ((int)(((byte)(61)))));
            this.btnSurveys.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSurveys.FlatAppearance.BorderSize = 0;
            this.btnSurveys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSurveys.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSurveys.ForeColor = System.Drawing.Color.White;
            this.btnSurveys.Location = new System.Drawing.Point(0, 96);
            this.btnSurveys.Name = "btnSurveys";
            this.btnSurveys.Size = new System.Drawing.Size(254, 48);
            this.btnSurveys.TabIndex = 1;
            this.btnSurveys.Text = "Surveys";
            this.btnSurveys.UseVisualStyleBackColor = false;
            this.btnSurveys.Click += new System.EventHandler(this.btnSurveys_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Controls.Add(this.btnAnswerSurvey);
            this.pnlContainer.Controls.Add(this.dgvSurveys);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(254, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(693, 550);
            this.pnlContainer.TabIndex = 3;
            // 
            // dgvSurveys
            // 
            this.dgvSurveys.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvSurveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurveys.Location = new System.Drawing.Point(15, 53);
            this.dgvSurveys.Name = "dgvSurveys";
            this.dgvSurveys.Size = new System.Drawing.Size(666, 485);
            this.dgvSurveys.TabIndex = 7;
            // 
            // btnAnswerSurvey
            // 
            this.btnAnswerSurvey.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAnswerSurvey.FlatAppearance.BorderSize = 0;
            this.btnAnswerSurvey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswerSurvey.Font = new System.Drawing.Font("Raleway", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswerSurvey.ForeColor = System.Drawing.Color.White;
            this.btnAnswerSurvey.Location = new System.Drawing.Point(544, 16);
            this.btnAnswerSurvey.Name = "btnAnswerSurvey";
            this.btnAnswerSurvey.Size = new System.Drawing.Size(134, 27);
            this.btnAnswerSurvey.TabIndex = 8;
            this.btnAnswerSurvey.Text = "Answer Survey";
            this.btnAnswerSurvey.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAnswerSurvey.UseVisualStyleBackColor = false;
            this.btnAnswerSurvey.Click += new System.EventHandler(this.btnAnswerSurvey_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Raleway", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select one of the surveys below and click the \'Answer Survey\' button to answer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Raleway", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Logged in as:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Raleway", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(8, 528);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(94, 14);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "Taizya Mwanza";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Image = global::Consumer_Survey_System.Properties.Resources.My_Post__3_1;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(254, 96);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // frmConsumerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 550);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlSideMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsumerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumer Survey System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConsumerMain_FormClosing);
            this.Load += new System.EventHandler(this.frmConsumerMain_Load);
            this.pnlSideMenu.ResumeLayout(false);
            this.pnlSideMenu.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSurveys;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnAnswerSurvey;
        private System.Windows.Forms.DataGridView dgvSurveys;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}