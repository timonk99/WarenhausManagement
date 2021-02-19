using System.Windows.Forms.DataVisualization.Charting;

namespace WarenhausManagement.Statistik
{
    partial class StatsMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.DateTime now = new System.DateTime();
        

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
            now = System.DateTime.Now;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsMain));
            this.c_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cb_auswahl = new System.Windows.Forms.ComboBox();
            this.dt_endDate = new System.Windows.Forms.DateTimePicker();
            this.l_titel = new System.Windows.Forms.Label();
            this.l_von = new System.Windows.Forms.Label();
            this.l_bis = new System.Windows.Forms.Label();
            this.dt_startDate = new System.Windows.Forms.DateTimePicker();
            this.l_auswahl = new System.Windows.Forms.Label();
            this.l_regal = new System.Windows.Forms.Label();
            this.cb_regal = new System.Windows.Forms.ComboBox();
            this.btn_close = new WarenhausManagement.Design.RoundedButton();
            this.btn_load = new WarenhausManagement.Design.RoundedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_User = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_chart
            // 
            this.c_chart.Location = new System.Drawing.Point(12, 79);
            this.c_chart.Name = "c_chart";
            this.c_chart.Size = new System.Drawing.Size(400, 400);
            this.c_chart.TabIndex = 0;
            this.c_chart.Text = "Chart";
            // 
            // cb_auswahl
            // 
            this.cb_auswahl.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_auswahl.FormattingEnabled = true;
            this.cb_auswahl.Items.AddRange(new object[] {
            "Auslastung",
            "Artikel"});
            this.cb_auswahl.Location = new System.Drawing.Point(418, 121);
            this.cb_auswahl.Name = "cb_auswahl";
            this.cb_auswahl.Size = new System.Drawing.Size(121, 27);
            this.cb_auswahl.TabIndex = 3;
            // 
            // dt_endDate
            // 
            this.dt_endDate.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_endDate.Location = new System.Drawing.Point(418, 289);
            this.dt_endDate.MaxDate = now;
            this.dt_endDate.Name = "dt_endDate";
            this.dt_endDate.Size = new System.Drawing.Size(200, 27);
            this.dt_endDate.TabIndex = 4;
            this.dt_endDate.Value = now;
            // 
            // l_titel
            // 
            this.l_titel.AutoSize = true;
            this.l_titel.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_titel.Location = new System.Drawing.Point(171, 58);
            this.l_titel.Name = "l_titel";
            this.l_titel.Size = new System.Drawing.Size(61, 19);
            this.l_titel.TabIndex = 5;
            this.l_titel.Text = "Statistik";
            // 
            // l_von
            // 
            this.l_von.AutoSize = true;
            this.l_von.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_von.Location = new System.Drawing.Point(418, 209);
            this.l_von.Name = "l_von";
            this.l_von.Size = new System.Drawing.Size(33, 19);
            this.l_von.TabIndex = 6;
            this.l_von.Text = "von";
            // 
            // l_bis
            // 
            this.l_bis.AutoSize = true;
            this.l_bis.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_bis.Location = new System.Drawing.Point(418, 265);
            this.l_bis.Name = "l_bis";
            this.l_bis.Size = new System.Drawing.Size(28, 19);
            this.l_bis.TabIndex = 8;
            this.l_bis.Text = "bis";
            // 
            // dt_startDate
            // 
            this.dt_startDate.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_startDate.Location = new System.Drawing.Point(418, 233);
            this.dt_startDate.MaxDate = now;
            this.dt_startDate.Name = "dt_startDate";
            this.dt_startDate.Size = new System.Drawing.Size(200, 27);
            this.dt_startDate.TabIndex = 7;
            this.dt_startDate.Value = now;
            // 
            // l_auswahl
            // 
            this.l_auswahl.AutoSize = true;
            this.l_auswahl.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_auswahl.Location = new System.Drawing.Point(418, 97);
            this.l_auswahl.Name = "l_auswahl";
            this.l_auswahl.Size = new System.Drawing.Size(80, 19);
            this.l_auswahl.TabIndex = 9;
            this.l_auswahl.Text = "Diagramm";
            // 
            // l_regal
            // 
            this.l_regal.AutoSize = true;
            this.l_regal.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_regal.Location = new System.Drawing.Point(418, 153);
            this.l_regal.Name = "l_regal";
            this.l_regal.Size = new System.Drawing.Size(47, 19);
            this.l_regal.TabIndex = 11;
            this.l_regal.Text = "Regal";
            // 
            // cb_regal
            // 
            this.cb_regal.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_regal.FormattingEnabled = true;
            this.cb_regal.Location = new System.Drawing.Point(418, 177);
            this.cb_regal.Name = "cb_regal";
            this.cb_regal.Size = new System.Drawing.Size(121, 27);
            this.cb_regal.TabIndex = 10;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.White;
            this.btn_close.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_close.Location = new System.Drawing.Point(440, 406);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(154, 48);
            this.btn_close.TabIndex = 20;
            this.btn_close.Text = "Zurück";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click_1);
            this.btn_close.MouseLeave += new System.EventHandler(this.btn_close_MouseLeave);
            this.btn_close.MouseHover += new System.EventHandler(this.btn_close_MouseHover);
            // 
            // btn_load
            // 
            this.btn_load.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_load.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_load.Location = new System.Drawing.Point(440, 352);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(154, 48);
            this.btn_load.TabIndex = 19;
            this.btn_load.Text = "Anzeigen";
            this.btn_load.UseVisualStyleBackColor = false;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click_1);
            this.btn_load.MouseLeave += new System.EventHandler(this.btn_load_MouseLeave);
            this.btn_load.MouseHover += new System.EventHandler(this.btn_load_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbl_User);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 45);
            this.panel1.TabIndex = 22;
            // 
            // lbl_User
            // 
            this.lbl_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_User.AutoSize = true;
            this.lbl_User.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_User.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_User.Location = new System.Drawing.Point(498, 13);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(67, 19);
            this.lbl_User.TabIndex = 3;
            this.lbl_User.Text = "Benutzer";
            // 
            // StatsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.l_regal);
            this.Controls.Add(this.cb_regal);
            this.Controls.Add(this.l_auswahl);
            this.Controls.Add(this.l_bis);
            this.Controls.Add(this.dt_startDate);
            this.Controls.Add(this.l_von);
            this.Controls.Add(this.l_titel);
            this.Controls.Add(this.dt_endDate);
            this.Controls.Add(this.cb_auswahl);
            this.Controls.Add(this.c_chart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "StatsMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistik";
            ((System.ComponentModel.ISupportInitialize)(this.c_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart c_chart;
        private System.Windows.Forms.ComboBox cb_auswahl;
        private System.Windows.Forms.DateTimePicker dt_endDate;
        private System.Windows.Forms.Label l_titel;
        private System.Windows.Forms.Label l_von;
        private System.Windows.Forms.Label l_bis;
        private System.Windows.Forms.DateTimePicker dt_startDate;
        private System.Windows.Forms.Label l_auswahl;
        private System.Windows.Forms.Label l_regal;
        private System.Windows.Forms.ComboBox cb_regal;
        private Design.RoundedButton btn_close;
        private Design.RoundedButton btn_load;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_User;
    }
}