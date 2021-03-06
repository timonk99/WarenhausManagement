﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;

namespace WarenhausManagement.Statistik
{
    public partial class StatsMain : Form
    {
        string dbuser = ConfigurationManager.AppSettings["dbuser"];
        string dbuserpw = ConfigurationManager.AppSettings["dbuserpw"];

        private User user;
        public StatsMain(User user)
        {
            InitializeComponent();
            Fill_cb_regal();
            this.user = user;
            lbl_User.Text = user.GetUsername();
        }

        private void ClearChart()
        {
            this.c_chart.Titles.Clear();
            this.c_chart.ChartAreas.Clear();
            this.c_chart.Series.Clear();
            this.c_chart.Legends.Clear();
        }
        private void Fill_cb_regal()
        {
            try
            {

                int regale = Datenbankanbindung.Get_Regale(dbuser, dbuserpw);

                cb_regal.Items.Add("Alle");
                for (int i = 1; i <= regale; i++)
                {
                    cb_regal.Items.Add(i);
                }
            } catch (Exception e)
            {
                new Message(e.Message);
            }
        }
        private void ArtikelLager(List<List<string>> values)
        {
            try
            {
                ClearChart();

                this.c_chart.Titles.Add("Bestand vom " + dt_startDate.Value.ToShortDateString() + " bis " + dt_endDate.Value.ToShortDateString());
                this.c_chart.Titles[0].Font = new Font("Verdana", 12);
                this.c_chart.ChartAreas.Add(new ChartArea());
                this.c_chart.Series.Add(new Series());

                for (int i = 0; i < values[0].Count; i++)
                {
                    this.c_chart.Series[0].Points.AddXY(values[0][i].ToString(), values[1][i]);
                }
            } catch (Exception e)
            {
                new Message(e.Message);
            }
        }
        private void PieAuslastung(int value)
        {
            try
            {
                string[] types = { "Leer", "Voll" };

                ClearChart();

                this.c_chart.Titles.Add("Auslastung von " + cb_regal.Text + " vom " + dt_startDate.Value.ToShortDateString() + " bis " + dt_endDate.Value.ToShortDateString());
                this.c_chart.Titles[0].Font = new Font("Verdana", 12);
                this.c_chart.ChartAreas.Add(new ChartArea());
                this.c_chart.Series.Add(new Series());
                this.c_chart.Series[0].ChartType = SeriesChartType.Pie;

                if (cb_regal.SelectedItem.ToString() == "Alle")
                {
                    this.c_chart.Legends.Add(types[0]);
                    this.c_chart.Series[0].Points.AddY((cb_regal.Items.Count - 1) * 10 - value);
                    this.c_chart.Series[0].Points[0].LegendText = types[0];
                    this.c_chart.Series[0].Points[0].AxisLabel = ((cb_regal.Items.Count - 1) * 10 - value).ToString();
                }
                else
                {
                    this.c_chart.Legends.Add(types[0]);
                    this.c_chart.Series[0].Points.AddY(10 - value);
                    this.c_chart.Series[0].Points[0].LegendText = types[0];
                    this.c_chart.Series[0].Points[0].AxisLabel = (10 - value).ToString();
                }

                this.c_chart.Legends.Add(types[1]);
                this.c_chart.Series[0].Points.AddY(value);
                this.c_chart.Series[0].Points[1].LegendText = types[1];
                this.c_chart.Series[0].Points[1].AxisLabel = (value).ToString();

            } catch(Exception e)
            {
                new Message(e.Message);
            }
        }

        private void btn_load_Click_1(object sender, EventArgs e)
        {
            if (cb_auswahl.SelectedIndex == 0) PieAuslastung(Datenbankanbindung.Get_Auslastung(user.GetUsername(), user.GetPassword(), dt_endDate.Value, dt_startDate.Value, cb_regal.Text));
            else if (cb_auswahl.SelectedIndex == 1) ArtikelLager(Datenbankanbindung.Get_Warenmenge(user.GetUsername(), user.GetPassword(), dt_endDate.Value, dt_startDate.Value));
            else new Message("Die Auswahl des Diagramms ist ungültig. Bitte ein anderes Diagramm wählen");
        }

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_load_MouseHover(object sender, EventArgs e)
        {
            btn_load.Font = new Font(btn_load.Font.Name, btn_load.Font.Size, FontStyle.Bold);
            btn_load.BackColor = Color.SteelBlue;
        }

        private void btn_load_MouseLeave(object sender, EventArgs e)
        {
            btn_load.Font = new Font(btn_load.Font.Name, btn_load.Font.Size, FontStyle.Regular);
            btn_load.BackColor = Color.LightSteelBlue;
        }

        private void btn_close_MouseHover(object sender, EventArgs e)
        {
            btn_close.Font = new Font(btn_close.Font.Name, btn_close.Font.Size, FontStyle.Bold);
            btn_close.BackColor = Color.SteelBlue;
        }

        private void btn_close_MouseLeave(object sender, EventArgs e)
        {
            btn_close.Font = new Font(btn_close.Font.Name, btn_close.Font.Size, FontStyle.Regular);
            btn_close.BackColor = Color.White;
        }
    }
}
