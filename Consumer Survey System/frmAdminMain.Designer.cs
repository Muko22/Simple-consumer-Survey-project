namespace Consumer_Survey_System
{
    partial class frmAdminMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminMain));
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlSurveys = new System.Windows.Forms.Panel();
            this.dgvSurveys = new System.Windows.Forms.DataGridView();
            this.btnSurveys = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteSurvey = new System.Windows.Forms.Button();
            this.btnNewSurvey = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pnlContainer.SuspendLayout();
            this.pnlSurveys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveys)).BeginInit();
            this.pnlSideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlSurveys);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(254, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(693, 550);
            this.pnlContainer.TabIndex = 3;
            // 
            // pnlSurveys
            // 
            this.pnlSurveys.AutoScroll = true;
            this.pnlSurveys.Controls.Add(this.btnResults);
            this.pnlSurveys.Controls.Add(this.btnRefresh);
            this.pnlSurveys.Controls.Add(this.dgvSurveys);
            this.pnlSurveys.Controls.Add(this.btnDeleteSurvey);
            this.pnlSurveys.Controls.Add(this.btnNewSurvey);
            this.pnlSurveys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSurveys.Location = new System.Drawing.Point(0, 0);
            this.pnlSurveys.Name = "pnlSurveys";
            this.pnlSurveys.Size = new System.Drawing.Size(693, 550);
            this.pnlSurveys.TabIndex = 0;
            // 
            // dgvSurveys
            // 
            this.dgvSurveys.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvSurveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurveys.Location = new System.Drawing.Point(13, 51);
            this.dgvSurveys.Name = "dgvSurveys";
            this.dgvSurveys.Size = new System.Drawing.Size(666, 487);
            this.dgvSurveys.TabIndex = 16;
            // 
            // btnSurveys
            // 
            this.btnSurveys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(9)))), ((int)(((byte)(61)))));
            this.btnSurveys.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSurveys.FlatAppearance.BorderSize = 0;
            this.btnSurveys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSurveys.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSurveys.ForeColor = System.Drawing.Color.White;
            this.btnSurveys.Location = new System.Drawing.Point(0, 96);
            this.btnSurveys.Name = "btnSurveys";
            this.btnSurveys.Size = new System.Drawing.Size(254, 48);
            this.btnSurveys.TabIndex = 1;
            this.btnSurveys.Text = "Surveys";
            this.btnSurveys.UseVisualStyleBackColor = false;
            this.btnSurveys.Click += new System.EventHandler(this.btnSurveys_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 145);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(254, 48);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(29)))), ((int)(((byte)(94)))));
            this.pnlSideMenu.Controls.Add(this.pictureBox3);
            this.pnlSideMenu.Controls.Add(this.btnLogout);
            this.pnlSideMenu.Controls.Add(this.btnSurveys);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(254, 550);
            this.pnlSideMenu.TabIndex = 1;
            // 
            // btnResults
            // 
            this.btnResults.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnResults.FlatAppearance.BorderSize = 0;
            this.btnResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResults.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResults.ForeColor = System.Drawing.Color.White;
            this.btnResults.Location = new System.Drawing.Point(284, 12);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(122, 27);
            this.btnResults.TabIndex = 18;
            this.btnResults.Text = "View Results";
            this.btnResults.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnResults.UseVisualStyleBackColor = false;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(557, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(122, 27);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteSurvey
            // 
            this.btnDeleteSurvey.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDeleteSurvey.FlatAppearance.BorderSize = 0;
            this.btnDeleteSurvey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSurvey.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSurvey.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSurvey.Location = new System.Drawing.Point(420, 12);
            this.btnDeleteSurvey.Name = "btnDeleteSurvey";
            this.btnDeleteSurvey.Size = new System.Drawing.Size(122, 27);
            this.btnDeleteSurvey.TabIndex = 14;
            this.btnDeleteSurvey.Text = "Delete Survey";
            this.btnDeleteSurvey.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDeleteSurvey.UseVisualStyleBackColor = false;
            this.btnDeleteSurvey.Click += new System.EventHandler(this.btnDeleteSurvey_Click);
            // 
            // btnNewSurvey
            // 
            this.btnNewSurvey.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnNewSurvey.FlatAppearance.BorderSize = 0;
            this.btnNewSurvey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSurvey.Font = new System.Drawing.Font("Raleway", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSurvey.ForeColor = System.Drawing.Color.White;
            this.btnNewSurvey.Location = new System.Drawing.Point(147, 12);
            this.btnNewSurvey.Name = "btnNewSurvey";
            this.btnNewSurvey.Size = new System.Drawing.Size(122, 27);
            this.btnNewSurvey.TabIndex = 13;
            this.btnNewSurvey.Text = "New Survey";
            this.btnNewSurvey.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNewSurvey.UseVisualStyleBackColor = false;
            this.btnNewSurvey.Click += new System.EventHandler(this.btnNewSurvey_Click);
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
            // frmAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 550);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlSideMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdminMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumer Survey System (Admin)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdminMain_FormClosing);
            this.Load += new System.EventHandler(this.frmAdminMain_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlSurveys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveys)).EndInit();
            this.pnlSideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlSurveys;
        private System.Windows.Forms.DataGridView dgvSurveys;
        private System.Windows.Forms.Button btnDeleteSurvey;
        private System.Windows.Forms.Button btnNewSurvey;
        private System.Windows.Forms.Button btnSurveys;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnResults;
    }
}