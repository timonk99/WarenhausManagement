namespace WarenhausManagement.GUI
{
    partial class Mainmenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainmenu));
            this.lbl_User = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_Logout = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEinbuchen = new WarenhausManagement.Design.RoundedButton();
            this.btnAusbuchen = new WarenhausManagement.Design.RoundedButton();
            this.btnStatistik = new WarenhausManagement.Design.RoundedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_User
            // 
            this.lbl_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_User.AutoSize = true;
            this.lbl_User.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_User.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_User.Location = new System.Drawing.Point(235, 9);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(67, 19);
            this.lbl_User.TabIndex = 3;
            this.lbl_User.Text = "Benutzer";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Menü";
            // 
            // pictureBox_Logout
            // 
            this.pictureBox_Logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Logout.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_Logout.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Logout.Image")));
            this.pictureBox_Logout.Location = new System.Drawing.Point(334, 4);
            this.pictureBox_Logout.Name = "pictureBox_Logout";
            this.pictureBox_Logout.Size = new System.Drawing.Size(29, 27);
            this.pictureBox_Logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Logout.TabIndex = 4;
            this.pictureBox_Logout.TabStop = false;
            this.pictureBox_Logout.Click += new System.EventHandler(this.pictureBox_Logout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnEinbuchen
            // 
            this.btnEinbuchen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEinbuchen.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEinbuchen.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEinbuchen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEinbuchen.Location = new System.Drawing.Point(91, 97);
            this.btnEinbuchen.Name = "btnEinbuchen";
            this.btnEinbuchen.Size = new System.Drawing.Size(154, 48);
            this.btnEinbuchen.TabIndex = 13;
            this.btnEinbuchen.Text = "Einbuchung";
            this.btnEinbuchen.UseVisualStyleBackColor = false;
            this.btnEinbuchen.Click += new System.EventHandler(this.btnEinbuchen_Click);
            this.btnEinbuchen.MouseLeave += new System.EventHandler(this.btnEinbuchen_MouseLeave);
            this.btnEinbuchen.MouseHover += new System.EventHandler(this.btnEinbuchen_MouseHover);
            // 
            // btnAusbuchen
            // 
            this.btnAusbuchen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAusbuchen.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAusbuchen.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAusbuchen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAusbuchen.Location = new System.Drawing.Point(91, 150);
            this.btnAusbuchen.Name = "btnAusbuchen";
            this.btnAusbuchen.Size = new System.Drawing.Size(154, 48);
            this.btnAusbuchen.TabIndex = 14;
            this.btnAusbuchen.Text = "Ausbuchung";
            this.btnAusbuchen.UseVisualStyleBackColor = false;
            this.btnAusbuchen.Click += new System.EventHandler(this.btnAusbuchen_Click);
            this.btnAusbuchen.MouseLeave += new System.EventHandler(this.btnAusbuchen_MouseLeave);
            this.btnAusbuchen.MouseHover += new System.EventHandler(this.btnAusbuchen_MouseHover);
            // 
            // btnStatistik
            // 
            this.btnStatistik.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStatistik.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStatistik.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistik.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStatistik.Location = new System.Drawing.Point(91, 204);
            this.btnStatistik.Name = "btnStatistik";
            this.btnStatistik.Size = new System.Drawing.Size(154, 48);
            this.btnStatistik.TabIndex = 15;
            this.btnStatistik.Text = "Statistik";
            this.btnStatistik.UseVisualStyleBackColor = false;
            this.btnStatistik.Click += new System.EventHandler(this.btnStatistik_Click);
            this.btnStatistik.MouseLeave += new System.EventHandler(this.btnStatistik_MouseLeave);
            this.btnStatistik.MouseHover += new System.EventHandler(this.btnStatistik_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lbl_User);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 34);
            this.panel1.TabIndex = 16;
            // 
            // Mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(378, 285);
            this.Controls.Add(this.btnStatistik);
            this.Controls.Add(this.btnAusbuchen);
            this.Controls.Add(this.btnEinbuchen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_Logout);
            this.Controls.Add(this.panel1);
            this.Name = "Mainmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hauptmenu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.PictureBox pictureBox_Logout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Design.RoundedButton btnEinbuchen;
        private Design.RoundedButton btnAusbuchen;
        private Design.RoundedButton btnStatistik;
        private System.Windows.Forms.Panel panel1;
    }
}