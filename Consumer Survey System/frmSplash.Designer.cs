namespace Consumer_Survey_System
{
    partial class frmSplash
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
            this.tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.pnlProgressFore = new System.Windows.Forms.Panel();
            this.pnlProgressBack = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlProgressBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrProgress
            // 
            this.tmrProgress.Enabled = true;
            this.tmrProgress.Interval = 15;
            this.tmrProgress.Tick += new System.EventHandler(this.tmrProgress_Tick);
            // 
            // pnlProgressFore
            // 
            this.pnlProgressFore.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pnlProgressFore.Location = new System.Drawing.Point(0, 0);
            this.pnlProgressFore.Name = "pnlProgressFore";
            this.pnlProgressFore.Size = new System.Drawing.Size(33, 21);
            this.pnlProgressFore.TabIndex = 11;
            // 
            // pnlProgressBack
            // 
            this.pnlProgressBack.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlProgressBack.Controls.Add(this.pnlProgressFore);
            this.pnlProgressBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgressBack.Location = new System.Drawing.Point(0, 281);
            this.pnlProgressBack.Name = "pnlProgressBack";
            this.pnlProgressBack.Size = new System.Drawing.Size(529, 21);
            this.pnlProgressBack.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Consumer_Survey_System.Properties.Resources.splash_screen_banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(529, 281);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 302);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlProgressBack);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnlProgressBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmrProgress;
        private System.Windows.Forms.Panel pnlProgressFore;
        private System.Windows.Forms.Panel pnlProgressBack;
        private System.Windows.Forms.Label label1;
    }
}

