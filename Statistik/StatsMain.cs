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

        public StatsMain()
        {
            InitializeComponent();
        }

        private void pieBestand()
        {
            // Zuerst den Chart clearen.
            this.c_chart.Titles.Clear();
            this.c_chart.ChartAreas.Clear();
            this.c_chart.Series.Clear();

            // Grundwerte festlegen
            this.c_chart.Titles.Add("Lagerbestand");
            this.c_chart.Titles[0].Font = new Font("Verdana", 12);
            this.c_chart.ChartAreas.Add(new ChartArea());
            this.c_chart.Series.Add(new Series());
            this.c_chart.Series[0].ChartType = SeriesChartType.Pie;

            // Legende zum testen
            this.c_chart.Legends.Add("Leer");
            this.c_chart.Legends.Add("Voll");
            this.c_chart.Legends.Add("Reserviert");

            // Werte zum testen
            this.c_chart.Series[0].Points.AddXY("Leer", 100);
            this.c_chart.Series[0].Points.AddXY("Voll", 50);
            this.c_chart.Series[0].Points.AddXY("Reserviert", 25);
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            pieBestand();
        }
    }
}
