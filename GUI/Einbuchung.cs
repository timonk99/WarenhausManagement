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
            if (checkBoxNeuerArtikel.Checked == true)
            {
                //Neuen Artikel anlegen
            }
            else //bereits existierenden Artikel einbuchen
            {
                //Textboxen auf richtigen Inhalt prüfen
                try
                {
                    ware.SetWareID(Convert.ToInt32(txtbx_ArtikelNr.Text));
                    _LagerID = Convert.ToInt32(txtbx_Lagerplatz.Text);
                }
                catch
                {
                    lbl_Status.Text = "Fehlerhafte Eingabe: Artikel Nummer oder Lagerplatz";
                }
                bool erfolgreich = Datenbankanbindung.EinbuchenProzedur(user.GetUsername(), user.GetPassword(), ware.GetWareID(), _LagerID);
                if (erfolgreich == true)
                {
                    lbl_Status.Text = "Einbuchung erfolgreich";
                }
                else
                {
                    lbl_Status.Text = "Einbuchung fehlgeschlagen";
                }
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
                if (wareID.Length == 12)
                {
                    wareID = wareID.Substring(8);
                }
                try
                {
                    ware.SetWareID(Convert.ToInt32(wareID));
                    List<List<string>> DatenArtikel = new List<List<string>>();
                    DatenArtikel = Datenbankanbindung.EinbuchenMethode(user.GetUsername(), user.GetPassword(), ware.GetWareID());

                    txtbx_Bezeichnung.Text = DatenArtikel[0][0];
                    txtbx_Speicher.Text = DatenArtikel[1][0];
                    txtbx_Preis.Text = DatenArtikel[2][0];
                }
                catch
                {
                    lbl_Status.Text = "Fehlerhaftte Eingabe im Feld Artikel Nummer!";
                }
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
                _LagerID = Convert.ToInt32(strlagerID);
            }
        }

        private void txtbx_ArtikelNr_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxNeuerArtikel_CheckedChanged(object sender, EventArgs e)
        {
            txtbx_ArtikelNr.ReadOnly = true;
        }
    }
}
