using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarenhausManagement.GUI
{
    public partial class Buchung : Form
    {
        private bool _Einbuchung;
        public Buchung(bool Einbuchung)
        {
            InitializeComponent();
            _Einbuchung = Einbuchung;
            if (Einbuchung==true)
            {
                btn_Ausbuchen.Visible = false;
            }
            else
            {
                btn_Einbuchen.Visible = false;
                txtbx_Bezeichnung.ReadOnly = true;
                txtbx_Hersteller.ReadOnly = true;
                txtbx_Lagerplatz.ReadOnly = true;
                txtbx_Speicher.ReadOnly = true;
            }
        }

        private void txtbx_ArtikelNr_TextChanged(object sender, EventArgs e)
        {
            if (_Einbuchung!=true)
            {
                //Laden der Daten zum dem Artikel aus der DB in die Textfelder
            }
        }
    }
}
