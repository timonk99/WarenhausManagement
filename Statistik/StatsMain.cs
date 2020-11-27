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
using System.Data.SqlClient;

namespace WarenhausManagement.Statistik
{
    public partial class StatsMain : Form
    {
        public StatsMain()
        {
            InitializeComponent();
            Fill_cb_regal();
        }

        private void ClearChart()
        {
            this.c_chart.Titles.Clear();
            this.c_chart.ChartAreas.Clear();
            this.c_chart.Series.Clear();
        }
        private void Fill_cb_regal()
        {
            int regale = Datenbankanbindung.Get_Regale();

            cb_regal.Items.Add("Alle");
            for( int i = 1; i == regale; i++)
            {
                cb_regal.Items.Add(i);
            }
        }
        private void ArtikelLager(List<List<string>> values)
        {
            ClearChart();

            this.c_chart.Titles.Add("Bestand vom " + dt_von.Value.ToShortDateString() + " bis " + dt_bis.Value.ToShortDateString());
            this.c_chart.Titles[0].Font = new Font("Verdana", 12);
            this.c_chart.ChartAreas.Add(new ChartArea());
            this.c_chart.Series.Add(new Series());

            for(int i = 0; i < values[0].Count; i++)
            {
                this.c_chart.Series[0].Points.AddXY(values[0][i].ToString(), values[1][i]);
            }
        }
        private void PieAuslastung(int value)
        {
            string[] types = { "Leer", "Voll"};

            ClearChart();
            
            this.c_chart.Titles.Add("Auslastung von " + cb_regal.Text + " vom " + dt_von.Value.ToShortDateString() + " bis " + dt_bis.Value.ToShortDateString());
            this.c_chart.Titles[0].Font = new Font("Verdana", 12);
            this.c_chart.ChartAreas.Add(new ChartArea());
            this.c_chart.Series.Add(new Series());
            this.c_chart.Series[0].ChartType = SeriesChartType.Pie;

            this.c_chart.Legends.Add(types[0]);
            this.c_chart.Series[0].Points.AddY( 10 - value);
            this.c_chart.Series[0].Points[0].LegendText = types[0];

            this.c_chart.Legends.Add(types[1]);
            this.c_chart.Series[0].Points.AddY(value);
            this.c_chart.Series[0].Points[1].LegendText = types[1];
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            if (cb_auswahl.SelectedIndex == 0) PieAuslastung(Datenbankanbindung.Get_Auslastung());
            else if (cb_auswahl.SelectedIndex == 1) ArtikelLager(Datenbankanbindung.Get_Warenmenge());
        }
    }
}
