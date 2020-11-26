using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WarenhausManagement.Statistik
{
    public partial class StatsMain : Form
    {
        int[] test = { 100, 50, 25 };
        public StatsMain()
        {
            InitializeComponent();
        }

        private void ClearChart()
        {
            this.c_chart.Titles.Clear();
            this.c_chart.ChartAreas.Clear();
            this.c_chart.Series.Clear();
        }
        private void Fill_cb_regal(string[] list)
        {
            cb_regal.Items.AddRange(list);
        }
        private void ArtikelLager(int[] values)
        {
            string testArtikel = "Test Artikel";
            ClearChart();

            DateTime startDate = dt_von.Value;
            TimeSpan timeSpan = dt_bis.Value.Subtract(dt_von.Value);
            int days = timeSpan.Days + 1;

            this.c_chart.Titles.Add("Bestand von " + testArtikel + " vom " + dt_von.Value.ToShortDateString() + " bis " + dt_bis.Value.ToShortDateString());
            this.c_chart.Titles[0].Font = new Font("Verdana", 12);
            this.c_chart.ChartAreas.Add(new ChartArea());
            this.c_chart.Series.Add(new Series());

            for (int i = 0; i < days; i++)
            {
                this.c_chart.Series[0].Points.AddXY(startDate.ToShortDateString(), values[i]);
                startDate = startDate.AddDays(1);
            }
        }
        private void PieAuslastung(int[] values)
        {
            string[] types = { "Leer", "Voll", "Reserviert" };

            ClearChart();
            
            this.c_chart.Titles.Add("Auslastung von " + cb_regal.Text + " vom " + dt_von.Value.ToShortDateString() + " bis " + dt_bis.Value.ToShortDateString());
            this.c_chart.Titles[0].Font = new Font("Verdana", 12);
            this.c_chart.ChartAreas.Add(new ChartArea());
            this.c_chart.Series.Add(new Series());
            this.c_chart.Series[0].ChartType = SeriesChartType.Pie;


            for(int i = 0; i < values.Length; i++)
            {
                this.c_chart.Legends.Add(types[i]);
                this.c_chart.Series[0].Points.AddY(values[i]);
                this.c_chart.Series[0].Points[i].LegendText = types[i];
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            if (cb_auswahl.SelectedIndex == 0) PieAuslastung(test);
            else if (cb_auswahl.SelectedIndex == 1) ArtikelLager(test);
        }
    }
}
