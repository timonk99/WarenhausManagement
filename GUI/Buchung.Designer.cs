namespace WarenhausManagement.GUI
{
    partial class Buchung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buchung));
            this.txtbx_ArtikelNr = new System.Windows.Forms.TextBox();
            this.txtbx_Lagerplatz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_Bezeichnung = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbx_Speicher = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbx_Preis = new System.Windows.Forms.TextBox();
            this.checkBoxNeuerArtikel = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_User = new System.Windows.Forms.Label();
            this.btnZuruck = new WarenhausManagement.Design.RoundedButton();
            this.btnAusbuchen = new WarenhausManagement.Design.RoundedButton();
            this.btnEinbuchen = new WarenhausManagement.Design.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbx_ArtikelNr
            // 
            this.txtbx_ArtikelNr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbx_ArtikelNr.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_ArtikelNr.Location = new System.Drawing.Point(91, 120);
            this.txtbx_ArtikelNr.Name = "txtbx_ArtikelNr";
            this.txtbx_ArtikelNr.Size = new System.Drawing.Size(137, 27);
            this.txtbx_ArtikelNr.TabIndex = 0;
            this.txtbx_ArtikelNr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_ArtikelNr_KeyDown);
            this.txtbx_ArtikelNr.Leave += new System.EventHandler(this.txtbx_ArtikelNr_Leave);
            // 
            // txtbx_Lagerplatz
            // 
            this.txtbx_Lagerplatz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbx_Lagerplatz.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_Lagerplatz.Location = new System.Drawing.Point(91, 340);
            this.txtbx_Lagerplatz.Name = "txtbx_Lagerplatz";
            this.txtbx_Lagerplatz.Size = new System.Drawing.Size(137, 27);
            this.txtbx_Lagerplatz.TabIndex = 4;
            this.txtbx_Lagerplatz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_Lagerplatz_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Artikel-Nr.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lagerplatz-Nr.";
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Status.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.Location = new System.Drawing.Point(272, 468);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(0, 16);
            this.lbl_Status.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Artikelbezeichnung";
            // 
            // txtbx_Bezeichnung
            // 
            this.txtbx_Bezeichnung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbx_Bezeichnung.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_Bezeichnung.Location = new System.Drawing.Point(91, 175);
            this.txtbx_Bezeichnung.Name = "txtbx_Bezeichnung";
            this.txtbx_Bezeichnung.Size = new System.Drawing.Size(137, 27);
            this.txtbx_Bezeichnung.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Speicherbedarf";
            // 
            // txtbx_Speicher
            // 
            this.txtbx_Speicher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbx_Speicher.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_Speicher.Location = new System.Drawing.Point(91, 230);
            this.txtbx_Speicher.Name = "txtbx_Speicher";
            this.txtbx_Speicher.Size = new System.Drawing.Size(137, 27);
            this.txtbx_Speicher.TabIndex = 2;
            this.txtbx_Speicher.Leave += new System.EventHandler(this.txtbx_Speicher_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(89, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Buchung";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Preis";
            // 
            // txtbx_Preis
            // 
            this.txtbx_Preis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbx_Preis.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_Preis.Location = new System.Drawing.Point(91, 285);
            this.txtbx_Preis.Name = "txtbx_Preis";
            this.txtbx_Preis.Size = new System.Drawing.Size(137, 27);
            this.txtbx_Preis.TabIndex = 3;
            // 
            // checkBoxNeuerArtikel
            // 
            this.checkBoxNeuerArtikel.AutoSize = true;
            this.checkBoxNeuerArtikel.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxNeuerArtikel.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNeuerArtikel.Location = new System.Drawing.Point(258, 117);
            this.checkBoxNeuerArtikel.Name = "checkBoxNeuerArtikel";
            this.checkBoxNeuerArtikel.Size = new System.Drawing.Size(172, 23);
            this.checkBoxNeuerArtikel.TabIndex = 20;
            this.checkBoxNeuerArtikel.Text = "neuen Artikel anlegen";
            this.checkBoxNeuerArtikel.UseVisualStyleBackColor = false;
            this.checkBoxNeuerArtikel.CheckedChanged += new System.EventHandler(this.checkBoxNeuerArtikel_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lbl_User);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 45);
            this.panel1.TabIndex = 20;
            // 
            // lbl_User
            // 
            this.lbl_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_User.AutoSize = true;
            this.lbl_User.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_User.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_User.Location = new System.Drawing.Point(595, 13);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(67, 19);
            this.lbl_User.TabIndex = 3;
            this.lbl_User.Text = "Benutzer";
            // 
            // btnZuruck
            // 
            this.btnZuruck.BackColor = System.Drawing.Color.White;
            this.btnZuruck.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZuruck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnZuruck.Location = new System.Drawing.Point(38, 451);
            this.btnZuruck.Name = "btnZuruck";
            this.btnZuruck.Size = new System.Drawing.Size(154, 48);
            this.btnZuruck.TabIndex = 18;
            this.btnZuruck.Text = "Zurück";
            this.btnZuruck.UseVisualStyleBackColor = false;
            this.btnZuruck.Click += new System.EventHandler(this.btnZuruck_Click);
            this.btnZuruck.MouseLeave += new System.EventHandler(this.btnZuruck_MouseLeave);
            this.btnZuruck.MouseHover += new System.EventHandler(this.btnZuruck_MouseHover);
            // 
            // btnAusbuchen
            // 
            this.btnAusbuchen.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAusbuchen.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAusbuchen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAusbuchen.Location = new System.Drawing.Point(208, 397);
            this.btnAusbuchen.Name = "btnAusbuchen";
            this.btnAusbuchen.Size = new System.Drawing.Size(154, 48);
            this.btnAusbuchen.TabIndex = 17;
            this.btnAusbuchen.Text = "Ausbuchen";
            this.btnAusbuchen.UseVisualStyleBackColor = false;
            this.btnAusbuchen.Click += new System.EventHandler(this.btnAusbuchen_Click);
            this.btnAusbuchen.MouseLeave += new System.EventHandler(this.btnAusbuchen_MouseLeave);
            this.btnAusbuchen.MouseHover += new System.EventHandler(this.btnAusbuchen_MouseHover);
            // 
            // btnEinbuchen
            // 
            this.btnEinbuchen.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEinbuchen.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEinbuchen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEinbuchen.Location = new System.Drawing.Point(38, 397);
            this.btnEinbuchen.Name = "btnEinbuchen";
            this.btnEinbuchen.Size = new System.Drawing.Size(154, 48);
            this.btnEinbuchen.TabIndex = 16;
            this.btnEinbuchen.Text = "Einbuchen";
            this.btnEinbuchen.UseVisualStyleBackColor = false;
            this.btnEinbuchen.Click += new System.EventHandler(this.btnEinbuchen_Click);
            this.btnEinbuchen.MouseLeave += new System.EventHandler(this.btnEinbuchen_MouseLeave);
            this.btnEinbuchen.MouseHover += new System.EventHandler(this.btnEinbuchen_MouseHover);
            // 
            // Buchung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(731, 512);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnZuruck);
            this.Controls.Add(this.btnAusbuchen);
            this.Controls.Add(this.btnEinbuchen);
            this.Controls.Add(this.checkBoxNeuerArtikel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbx_Preis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbx_Speicher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbx_Bezeichnung);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbx_Lagerplatz);
            this.Controls.Add(this.txtbx_ArtikelNr);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "Buchung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buchung";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbx_ArtikelNr;
        private System.Windows.Forms.TextBox txtbx_Lagerplatz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbx_Bezeichnung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbx_Speicher;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbx_Preis;
        private System.Windows.Forms.CheckBox checkBoxNeuerArtikel;
        private Design.RoundedButton btnEinbuchen;
        private Design.RoundedButton btnAusbuchen;
        private Design.RoundedButton btnZuruck;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_User;
    }
}