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
            this.btn_Einbuchen = new System.Windows.Forms.Button();
            this.btn_Ausbuchen = new System.Windows.Forms.Button();
            this.btn_Statistik = new System.Windows.Forms.Button();
            this.lbl_User = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_Logout = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logout)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Einbuchen
            // 
            this.btn_Einbuchen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Einbuchen.Location = new System.Drawing.Point(35, 73);
            this.btn_Einbuchen.Name = "btn_Einbuchen";
            this.btn_Einbuchen.Size = new System.Drawing.Size(158, 36);
            this.btn_Einbuchen.TabIndex = 0;
            this.btn_Einbuchen.Text = "Einbuchung";
            this.btn_Einbuchen.UseVisualStyleBackColor = true;
            this.btn_Einbuchen.Click += new System.EventHandler(this.btn_Einbuchen_Click);
            // 
            // btn_Ausbuchen
            // 
            this.btn_Ausbuchen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ausbuchen.Location = new System.Drawing.Point(35, 115);
            this.btn_Ausbuchen.Name = "btn_Ausbuchen";
            this.btn_Ausbuchen.Size = new System.Drawing.Size(158, 36);
            this.btn_Ausbuchen.TabIndex = 1;
            this.btn_Ausbuchen.Text = "Ausbuchung";
            this.btn_Ausbuchen.UseVisualStyleBackColor = true;
            this.btn_Ausbuchen.Click += new System.EventHandler(this.btn_Ausbuchen_Click);
            // 
            // btn_Statistik
            // 
            this.btn_Statistik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Statistik.Location = new System.Drawing.Point(35, 157);
            this.btn_Statistik.Name = "btn_Statistik";
            this.btn_Statistik.Size = new System.Drawing.Size(158, 36);
            this.btn_Statistik.TabIndex = 2;
            this.btn_Statistik.Text = "Statistik anzeigen";
            this.btn_Statistik.UseVisualStyleBackColor = true;
            // 
            // lbl_User
            // 
            this.lbl_User.AutoSize = true;
            this.lbl_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_User.Location = new System.Drawing.Point(310, 9);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(56, 15);
            this.lbl_User.TabIndex = 3;
            this.lbl_User.Text = "Benutzer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Menü";
            // 
            // pictureBox_Logout
            // 
            this.pictureBox_Logout.Image = global::WarenhausManagement.Properties.Resources.Logout;
            this.pictureBox_Logout.Location = new System.Drawing.Point(365, 3);
            this.pictureBox_Logout.Name = "pictureBox_Logout";
            this.pictureBox_Logout.Size = new System.Drawing.Size(29, 29);
            this.pictureBox_Logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Logout.TabIndex = 4;
            this.pictureBox_Logout.TabStop = false;
            this.pictureBox_Logout.Click += new System.EventHandler(this.pictureBox_Logout_Click);
            // 
            // Mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 229);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_Logout);
            this.Controls.Add(this.lbl_User);
            this.Controls.Add(this.btn_Statistik);
            this.Controls.Add(this.btn_Ausbuchen);
            this.Controls.Add(this.btn_Einbuchen);
            this.Name = "Mainmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hauptmenu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Einbuchen;
        private System.Windows.Forms.Button btn_Ausbuchen;
        private System.Windows.Forms.Button btn_Statistik;
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.PictureBox pictureBox_Logout;
        private System.Windows.Forms.Label label1;
    }
}