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
            this.txtbx_ArtikelNr = new System.Windows.Forms.TextBox();
            this.txtbx_Lagerplatz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Einbuchen = new System.Windows.Forms.Button();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.btn_Ausbuchen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_Bezeichnung = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbx_Speicher = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbx_Preis = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbx_ArtikelNr
            // 
            this.txtbx_ArtikelNr.Location = new System.Drawing.Point(91, 75);
            this.txtbx_ArtikelNr.Name = "txtbx_ArtikelNr";
            this.txtbx_ArtikelNr.Size = new System.Drawing.Size(137, 20);
            this.txtbx_ArtikelNr.TabIndex = 0;
            this.txtbx_ArtikelNr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_ArtikelNr_KeyDown);
            // 
            // txtbx_Lagerplatz
            // 
            this.txtbx_Lagerplatz.Location = new System.Drawing.Point(91, 129);
            this.txtbx_Lagerplatz.Name = "txtbx_Lagerplatz";
            this.txtbx_Lagerplatz.Size = new System.Drawing.Size(137, 20);
            this.txtbx_Lagerplatz.TabIndex = 1;
            this.txtbx_Lagerplatz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_Lagerplatz_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(91, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Artikel-Nr.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(91, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lagerplatz-Nr.";
            // 
            // btn_Einbuchen
            // 
            this.btn_Einbuchen.Location = new System.Drawing.Point(91, 344);
            this.btn_Einbuchen.Name = "btn_Einbuchen";
            this.btn_Einbuchen.Size = new System.Drawing.Size(75, 23);
            this.btn_Einbuchen.TabIndex = 4;
            this.btn_Einbuchen.Text = "Einbuchen";
            this.btn_Einbuchen.UseVisualStyleBackColor = true;
            this.btn_Einbuchen.Click += new System.EventHandler(this.btn_Einbuchen_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Status.Location = new System.Drawing.Point(91, 374);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(0, 13);
            this.lbl_Status.TabIndex = 5;
            // 
            // btn_Ausbuchen
            // 
            this.btn_Ausbuchen.Location = new System.Drawing.Point(183, 344);
            this.btn_Ausbuchen.Name = "btn_Ausbuchen";
            this.btn_Ausbuchen.Size = new System.Drawing.Size(75, 23);
            this.btn_Ausbuchen.TabIndex = 6;
            this.btn_Ausbuchen.Text = "Ausbuchen";
            this.btn_Ausbuchen.UseVisualStyleBackColor = true;
            this.btn_Ausbuchen.Click += new System.EventHandler(this.btn_Ausbuchen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(91, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Artikelbezeichnung";
            // 
            // txtbx_Bezeichnung
            // 
            this.txtbx_Bezeichnung.Location = new System.Drawing.Point(91, 189);
            this.txtbx_Bezeichnung.Name = "txtbx_Bezeichnung";
            this.txtbx_Bezeichnung.Size = new System.Drawing.Size(137, 20);
            this.txtbx_Bezeichnung.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(91, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Speicherbedarf";
            // 
            // txtbx_Speicher
            // 
            this.txtbx_Speicher.Location = new System.Drawing.Point(91, 246);
            this.txtbx_Speicher.Name = "txtbx_Speicher";
            this.txtbx_Speicher.Size = new System.Drawing.Size(137, 20);
            this.txtbx_Speicher.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(89, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Buchung";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(91, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Preis";
            // 
            // txtbx_Preis
            // 
            this.txtbx_Preis.Location = new System.Drawing.Point(91, 295);
            this.txtbx_Preis.Name = "txtbx_Preis";
            this.txtbx_Preis.Size = new System.Drawing.Size(137, 20);
            this.txtbx_Preis.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 404);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Zurück";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Buchung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WarenhausManagement.Properties.Resources._90619730_farbverlauf_weiße_licht_weichen_blauen_farbe_hintergrund;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(767, 494);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbx_Preis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbx_Speicher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbx_Bezeichnung);
            this.Controls.Add(this.btn_Ausbuchen);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.btn_Einbuchen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbx_Lagerplatz);
            this.Controls.Add(this.txtbx_ArtikelNr);
            this.Name = "Buchung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einbuchung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbx_ArtikelNr;
        private System.Windows.Forms.TextBox txtbx_Lagerplatz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Einbuchen;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Button btn_Ausbuchen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbx_Bezeichnung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbx_Speicher;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbx_Preis;
        private System.Windows.Forms.Button button3;
    }
}