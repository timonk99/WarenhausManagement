using System.Windows.Forms.DataVisualization.Charting;

namespace WarenhausManagement.Statistik
{
    partial class StatsMain
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
            this.c_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.cb_auswahl = new System.Windows.Forms.ComboBox();
            this.dt_endDate = new System.Windows.Forms.DateTimePicker();
            this.l_titel = new System.Windows.Forms.Label();
            this.l_von = new System.Windows.Forms.Label();
            this.l_bis = new System.Windows.Forms.Label();
            this.dt_startDate = new System.Windows.Forms.DateTimePicker();
            this.l_auswahl = new System.Windows.Forms.Label();
            this.l_regal = new System.Windows.Forms.Label();
            this.cb_regal = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.c_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // c_chart
            // 
            this.c_chart.Location = new System.Drawing.Point(12, 25);
            this.c_chart.Name = "c_chart";
            this.c_chart.Size = new System.Drawing.Size(400, 400);
            this.c_chart.TabIndex = 0;
            this.c_chart.Text = "Chart";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(418, 402);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Schließen";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(418, 373);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 2;
            this.btn_load.Text = "Laden";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // cb_auswahl
            // 
            this.cb_auswahl.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_auswahl.FormattingEnabled = true;
            this.cb_auswahl.Items.AddRange(new object[] {
            "Auslastung",
            "Artikel"});
            this.cb_auswahl.Location = new System.Drawing.Point(418, 67);
            this.cb_auswahl.Name = "cb_auswahl";
            this.cb_auswahl.Size = new System.Drawing.Size(121, 27);
            this.cb_auswahl.TabIndex = 3;
            // 
            // dt_endDate
            // 
            this.dt_endDate.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_endDate.Location = new System.Drawing.Point(418, 235);
            this.dt_endDate.MaxDate = new System.DateTime(2020, 11, 27, 11, 10, 45, 462);
            this.dt_endDate.Name = "dt_endDate";
            this.dt_endDate.Size = new System.Drawing.Size(200, 27);
            this.dt_endDate.TabIndex = 4;
            this.dt_endDate.Value = new System.DateTime(2020, 11, 27, 11, 10, 45, 462);
            // 
            // l_titel
            // 
            this.l_titel.AutoSize = true;
            this.l_titel.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_titel.Location = new System.Drawing.Point(171, 4);
            this.l_titel.Name = "l_titel";
            this.l_titel.Size = new System.Drawing.Size(61, 19);
            this.l_titel.TabIndex = 5;
            this.l_titel.Text = "Statistik";
            // 
            // l_von
            // 
            this.l_von.AutoSize = true;
            this.l_von.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_von.Location = new System.Drawing.Point(418, 155);
            this.l_von.Name = "l_von";
            this.l_von.Size = new System.Drawing.Size(33, 19);
            this.l_von.TabIndex = 6;
            this.l_von.Text = "von";
            // 
            // l_bis
            // 
            this.l_bis.AutoSize = true;
            this.l_bis.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_bis.Location = new System.Drawing.Point(418, 211);
            this.l_bis.Name = "l_bis";
            this.l_bis.Size = new System.Drawing.Size(28, 19);
            this.l_bis.TabIndex = 8;
            this.l_bis.Text = "bis";
            // 
            // dt_startDate
            // 
            this.dt_startDate.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_startDate.Location = new System.Drawing.Point(418, 179);
            this.dt_startDate.MaxDate = new System.DateTime(2020, 11, 27, 11, 10, 45, 468);
            this.dt_startDate.Name = "dt_startDate";
            this.dt_startDate.Size = new System.Drawing.Size(200, 27);
            this.dt_startDate.TabIndex = 7;
            this.dt_startDate.Value = new System.DateTime(2020, 11, 27, 11, 10, 45, 468);
            // 
            // l_auswahl
            // 
            this.l_auswahl.AutoSize = true;
            this.l_auswahl.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_auswahl.Location = new System.Drawing.Point(418, 43);
            this.l_auswahl.Name = "l_auswahl";
            this.l_auswahl.Size = new System.Drawing.Size(80, 19);
            this.l_auswahl.TabIndex = 9;
            this.l_auswahl.Text = "Diagramm";
            // 
            // l_regal
            // 
            this.l_regal.AutoSize = true;
            this.l_regal.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_regal.Location = new System.Drawing.Point(418, 99);
            this.l_regal.Name = "l_regal";
            this.l_regal.Size = new System.Drawing.Size(47, 19);
            this.l_regal.TabIndex = 11;
            this.l_regal.Text = "Regal";
            // 
            // cb_regal
            // 
            this.cb_regal.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_regal.FormattingEnabled = true;
            this.cb_regal.Location = new System.Drawing.Point(418, 123);
            this.cb_regal.Name = "cb_regal";
            this.cb_regal.Size = new System.Drawing.Size(121, 27);
            this.cb_regal.TabIndex = 10;
            // 
            // StatsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 436);
            this.Controls.Add(this.l_regal);
            this.Controls.Add(this.cb_regal);
            this.Controls.Add(this.l_auswahl);
            this.Controls.Add(this.l_bis);
            this.Controls.Add(this.dt_startDate);
            this.Controls.Add(this.l_von);
            this.Controls.Add(this.l_titel);
            this.Controls.Add(this.dt_endDate);
            this.Controls.Add(this.cb_auswahl);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.c_chart);
            this.Name = "StatsMain";
            this.Text = "Statistik";
            ((System.ComponentModel.ISupportInitialize)(this.c_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart c_chart;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.ComboBox cb_auswahl;
        private System.Windows.Forms.DateTimePicker dt_endDate;
        private System.Windows.Forms.Label l_titel;
        private System.Windows.Forms.Label l_von;
        private System.Windows.Forms.Label l_bis;
        private System.Windows.Forms.DateTimePicker dt_startDate;
        private System.Windows.Forms.Label l_auswahl;
        private System.Windows.Forms.Label l_regal;
        private System.Windows.Forms.ComboBox cb_regal;
    }
}