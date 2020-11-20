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
            ((System.ComponentModel.ISupportInitialize)(this.c_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // c_chart
            // 
            this.c_chart.Location = new System.Drawing.Point(100, 100);
            this.c_chart.Name = "c_chart";
            this.c_chart.Size = new System.Drawing.Size(400, 400);
            this.c_chart.TabIndex = 0;
            this.c_chart.Text = "Chart";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(697, 526);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Schließen";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(697, 497);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 2;
            this.btn_load.Text = "Laden";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // StatsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.c_chart);
            this.Name = "StatsMain";
            this.Text = "StatsMain";
            ((System.ComponentModel.ISupportInitialize)(this.c_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart c_chart;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_load;
    }
}