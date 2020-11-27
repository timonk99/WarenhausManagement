using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarenhausManagement.GUI
{
    public partial class Buchung : Form
    {
        private int _LagerID;
        Ware ware = new Ware();
        User user = new User();
        private bool _Einbuchung;
        public Buchung(bool Einbuchung, User _user)
        {
            user = _user;
            InitializeComponent();
            _Einbuchung = Einbuchung;
            if (Einbuchung == true)
            {
                btn_Ausbuchen.Visible = false;
            }
            else
            {
                btn_Einbuchen.Visible = false;
                txtbx_Bezeichnung.ReadOnly = true;
                txtbx_Preis.ReadOnly = true;
                txtbx_Lagerplatz.ReadOnly = true;
                txtbx_Speicher.ReadOnly = true;
            }
        }

        private void btn_Einbuchen_Click(object sender, EventArgs e)
        {
            //SQL Statement zum Einbuchen
            bool erfolgreich = Datenbankanbindung.Eingabe(user.GetUsername(), user.GetPassword(), "Lagerprozess","Lagerplatznummer, WareID, WareneingangDatum", ""+txtbx_Lagerplatz.Text+", "+txtbx_ArtikelNr.Text+", "+DateTime.Now+"") ;
            if (erfolgreich == true)
            {
                lbl_Status.Text="Buchung erfolgreich";
            }
            else
            {
                lbl_Status.Text="Buchung fehlgeschlagen";
            }
        }

        private void btn_Ausbuchen_Click(object sender, EventArgs e)
        {
            //SQL Statement zum Aussbuchen
        }

        private void txtbx_ArtikelNr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string wareID;
                wareID = txtbx_ArtikelNr.Text;
                wareID = wareID.Substring(8);
                ware.SetWareID(Convert.ToInt32(wareID));
            }
        }

        private void txtbx_Lagerplatz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string strlagerID;
                strlagerID = txtbx_Lagerplatz.Text;
                strlagerID = strlagerID.Substring(8);
                strlagerID = "1" + strlagerID;
                _LagerID= Convert.ToInt32(strlagerID);
            }
        }
    }
}
