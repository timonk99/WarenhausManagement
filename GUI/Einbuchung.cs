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
            lbl_User.Text = user.GetUsername();
            _Einbuchung = Einbuchung;
            if (Einbuchung == true)
            {
                btnAusbuchen.Visible = false;
            }
            else
            {
                btnEinbuchen.Visible = false;
                txtbx_Bezeichnung.ReadOnly = true;
                txtbx_Preis.ReadOnly = true;
                txtbx_Speicher.ReadOnly = true;
                checkBoxNeuerArtikel.Visible = false;
            }
        }

        private void txtbx_ArtikelNr_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                WarePruefen();
            }
        }

        private void txtbx_Lagerplatz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LagerPruefen();
            }
        }

        private void checkBoxNeuerArtikel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNeuerArtikel.Checked == true)
            {
                txtbx_ArtikelNr.ReadOnly = true;
            }
            else if(checkBoxNeuerArtikel.Checked ==false)
            {
                txtbx_ArtikelNr.ReadOnly = false;
            }
            
        }

        private void btnEinbuchen_Click(object sender, EventArgs e)
        {
            //Textboxen auslesen
            ware.SetWareBezeichnung(txtbx_Bezeichnung.Text);
            bool Lagererfolg = LagerPruefen();
            if (Lagererfolg == true)
            {
                if (checkBoxNeuerArtikel.Checked == true)
                {
                    try
                    {
                        ware.SetSpeicherbedarf(Convert.ToInt32(txtbx_Speicher.Text));
                        ware.SetPreis(float.Parse(txtbx_Preis.Text));
                        //Neuen Artikel anlegen
                        bool erfolgreich = false;
                        erfolgreich = Datenbankanbindung.NauerArtikel(user.GetUsername(), user.GetPassword(), ware.GetWareBezeichnung(), ware.GetPreis(), ware.GetSpeicherbedarf());
                        if (erfolgreich == true)
                        {
                            //erzeugte ID aus DB holen
                            ware.SetWareID(Datenbankanbindung.WareID(user.GetUsername(), user.GetPassword(), ware.GetWareBezeichnung()));
                            //Einbuchen
                            if (ware.GetWareID() != -1)
                            {   
                                //Artikel einbuchen
                                bool ok = Datenbankanbindung.EinbuchenProzedur(user.GetUsername(), user.GetPassword(), ware.GetWareID(), _LagerID);
                                //Verarbeitung auf Returnwert
                                if (ok == true)
                                {
                                    lbl_Status.Text = "Artikel erfolgreich angelegt und eingebucht";
                                    txtbx_ArtikelNr.Text = ware.GetWareID().ToString();
                                }
                            }
                        }
                    }
                    catch
                    {
                        lbl_Status.Text = "Falsche Eingabe im Feld Speicherbedarf oder Preis. Eingabe muss Zahlenformat haben";
                    }

                }
                else //bereits existierenden Artikel einbuchen
                {
                    bool erfolgreich = false;
                    try //Textboxen auf richtigen Inhalt prüfen -> Konvertieren
                    {
                        ware.SetWareID(Convert.ToInt32(txtbx_ArtikelNr.Text));
                        _LagerID = Convert.ToInt32(txtbx_Lagerplatz.Text = "1" + txtbx_Lagerplatz.Text);
                        erfolgreich = Datenbankanbindung.EinbuchenProzedur(user.GetUsername(), user.GetPassword(), ware.GetWareID(), _LagerID);
                    }
                    catch
                    {
                        lbl_Status.Text = "Fehlerhafte Eingabe: Artikelnummer oder Lagerplatz";
                    }

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
        }

        private void btnAusbuchen_Click(object sender, EventArgs e)
        {
            bool lagererfolg = LagerPruefen();
            if (lagererfolg == true)
            {
                bool erfolgreich = false;
                //SQL Statement zum Ausbuchen
                erfolgreich = Datenbankanbindung.AusbuchenProzedur(user.GetUsername(), user.GetPassword(), ware.GetWareID(), _LagerID);
                if (erfolgreich == true)
                {
                    lbl_Status.Text = "Ausbuchung erfolgreich";
                }
                else
                {
                    lbl_Status.Text = "Ausbuchung fehlgeschlagen";
                }
            }
        }

        private void btnZuruck_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbx_ArtikelNr_Leave(object sender, EventArgs e)
        {
            WarePruefen();
        }
        private void WarePruefen()
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
        private bool LagerPruefen()
        {
            bool erfolgreich = true;
            string strlagerID;
            strlagerID = txtbx_Lagerplatz.Text;
            if (strlagerID.Length == 12)
            {
                strlagerID = strlagerID.Substring(8);
            }
            if (strlagerID.Length == 4)
            {
                strlagerID = "1" + strlagerID;
            }
            try
            {
                _LagerID = Convert.ToInt32(strlagerID);

            }
            catch
            {
                erfolgreich = false;
                lbl_Status.Text = "Fehlerhaftte Eingabe im Feld Lagerplatz!";
            }
            return erfolgreich;
            
        }
    }
}
