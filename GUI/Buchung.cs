﻿using System;
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
                txtbx_Bezeichnung.ReadOnly = true;
                txtbx_Preis.ReadOnly = true;
                txtbx_Speicher.ReadOnly = true;
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
                //LagerPruefen();
            }
        }

        private void checkBoxNeuerArtikel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNeuerArtikel.Checked == true)
            {
                txtbx_ArtikelNr.ReadOnly = true;
                txtbx_Bezeichnung.ReadOnly = false;
                txtbx_Preis.ReadOnly = false;
                txtbx_Speicher.ReadOnly = false;
            }
            else if (checkBoxNeuerArtikel.Checked == false)
            {
                txtbx_ArtikelNr.ReadOnly = false;
                txtbx_Bezeichnung.ReadOnly = true;
                txtbx_Preis.ReadOnly = true;
                txtbx_Speicher.ReadOnly = true;
            }

        }

        private void btnEinbuchen_Click(object sender, EventArgs e)
        {
            lbl_Status.Text = "";
            //Textboxen auslesen
            ware.SetWareBezeichnung(txtbx_Bezeichnung.Text);
            bool neuerstellt = false;
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
                        bool erfolgreich1 = Datenbankanbindung.NeuerArtikel(user.GetUsername(), user.GetPassword(), ware.GetWareBezeichnung(), ware.GetPreis(), ware.GetSpeicherbedarf());
                        if (erfolgreich1 == true)
                        {
                            //erzeugte ID aus DB holen
                            ware.SetWareID(Datenbankanbindung.WareID(user.GetUsername(), user.GetPassword(), ware.GetWareBezeichnung()));
                            //Einbuchen
                            if (ware.GetWareID() != -1)
                            {
                                neuerstellt = true;
                                lbl_Status.Text = "Artikel erfolgreich angelegt ";
                                txtbx_ArtikelNr.Text = ware.GetWareID().ToString(); ;
                            }
                        }
                    }
                    catch
                    {
                        lbl_Status.Text = "Falsche Eingabe im Feld Speicherbedarf oder Preis. Eingabe muss Zahlenformat haben";
                    }
                }

                bool erfolgreich = false;
                byte bytegr = 0;
                try //Textboxen auf richtigen Inhalt prüfen -> Konvertieren
                {
                    ware.SetSpeicherbedarf(Convert.ToInt32(txtbx_Speicher.Text));
                    if (ware.GetSpeicherbedarf() == 1)
                        bytegr = 0;
                    if (ware.GetSpeicherbedarf() == 2)
                        bytegr = 1;
                    ware.SetPreis(float.Parse(txtbx_Preis.Text));
                    ware.SetWareID(Convert.ToInt32(txtbx_ArtikelNr.Text));
                    int checkslot = Datenbankanbindung.CheckSlot(user.GetUsername(), user.GetPassword(), _LagerID);
                    if (checkslot == 1)//wenn 1 dann ist Platz frei
                    {
                        if (bytegr == 1)//wenn 1 dann Übergröße
                        {
                            int checkslotgr = Datenbankanbindung.CheckSlotUebergrosse(user.GetUsername(), user.GetPassword(), _LagerID);
                            if (checkslotgr == 1)
                            {
                                erfolgreich = Datenbankanbindung.EinbuchenProzedur(user.GetUsername(), user.GetPassword(), ware.GetWareID(), _LagerID, bytegr);
                            }
                            else
                            {
                                if (neuerstellt == true)
                                    lbl_Status.Text = lbl_Status.Text + ". Lagerplatz nicht mehr frei für diese Größe.";
                                else
                                    lbl_Status.Text = "Lagerplatz nicht mehr frei.";
                            }
                        }
                        else
                        {
                            erfolgreich = Datenbankanbindung.EinbuchenProzedur(user.GetUsername(), user.GetPassword(), ware.GetWareID(), _LagerID, bytegr);
                        }
                    }
                    else
                    {
                        if (neuerstellt == true)
                            lbl_Status.Text = lbl_Status.Text + ". Lagerplatz nicht mehr frei.";
                        else
                            lbl_Status.Text = "Lagerplatz nicht mehr frei.";
                    }
                }
                catch
                {
                    lbl_Status.Text = "Fehlerhafte Eingabe: Artikelnummer, Größe oder Lagerplatz";
                }

                if (erfolgreich == true)
                {
                    if (neuerstellt == true)
                        lbl_Status.Text = lbl_Status.Text + " und eingebucht.";
                    else
                        lbl_Status.Text = "Einbuchung erfolgreich";

                }
                else
                {
                    if (neuerstellt == true)
                        lbl_Status.Text = lbl_Status.Text + ", aber Einbuchung fehlgeschlagen.";
                    else
                        lbl_Status.Text = lbl_Status.Text + "Einbuchung fehlgeschlagen";
                }
            }
        }

        private void btnAusbuchen_Click(object sender, EventArgs e)
        {
            int uebergrosse = 0;
            ware.SetSpeicherbedarf(Convert.ToInt32(txtbx_Speicher.Text));
            if (ware.GetSpeicherbedarf() == 2)
                uebergrosse = 1;
            bool lagererfolg = LagerPruefen();
            if (lagererfolg == true)
            {
                bool erfolgreich = false;
                //SQL Statement zum Ausbuchen
                erfolgreich = Datenbankanbindung.AusbuchenProzedur(user.GetUsername(), user.GetPassword(), ware.GetWareID(), _LagerID, uebergrosse);
                int i = Datenbankanbindung.CheckAusbuchen(user.GetUsername(), user.GetPassword(), _LagerID);
                if (erfolgreich == true && i == 1) //i == 1 -> Eintrag wurde gemacht
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
            lbl_Status.Text = "";
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
                txtbx_ArtikelNr.Text = ware.GetWareID().ToString();
            }
            catch
            {
                lbl_Status.Text = "Fehlerhaftte Eingabe im Feld Artikel Nummer!";
            }
        }
        private bool LagerPruefen()
        {
            bool error = true;
            bool erfolgreich = true;
            string strlagerID;
            strlagerID = txtbx_Lagerplatz.Text;
            if (strlagerID.Length == 12)
            {
                strlagerID = strlagerID.Substring(8);
                error = false;
            }
            if (strlagerID.Length == 5)
            {
                strlagerID = strlagerID.Substring(1);
            }
            if (strlagerID.Length == 4)
            {
                strlagerID = "1" + strlagerID;
                error = false;
            }
            try
            {
                _LagerID = Convert.ToInt32(strlagerID);
                txtbx_Lagerplatz.Text = _LagerID.ToString();
            }
            catch
            {
                erfolgreich = false;
                error = true;
            }
            if (error == true)
            {
                erfolgreich = false;
                lbl_Status.Text = "Fehlerhafte Eingabe im Feld Lagerplatz!";
            }
            return erfolgreich;
        }

        private void btnEinbuchen_MouseHover(object sender, EventArgs e)
        {
            btnEinbuchen.Font = new Font(btnEinbuchen.Font.Name, btnEinbuchen.Font.Size, FontStyle.Bold);
            btnEinbuchen.BackColor = Color.SteelBlue;
        }

        private void btnEinbuchen_MouseLeave(object sender, EventArgs e)
        {
            btnEinbuchen.Font = new Font(btnEinbuchen.Font.Name, btnEinbuchen.Font.Size, FontStyle.Regular);
            btnEinbuchen.BackColor = Color.LightSteelBlue;
        }

        private void btnAusbuchen_MouseHover(object sender, EventArgs e)
        {
            btnAusbuchen.Font = new Font(btnAusbuchen.Font.Name, btnAusbuchen.Font.Size, FontStyle.Bold);
            btnAusbuchen.BackColor = Color.SteelBlue;
        }

        private void btnAusbuchen_MouseLeave(object sender, EventArgs e)
        {
            btnAusbuchen.Font = new Font(btnAusbuchen.Font.Name, btnAusbuchen.Font.Size, FontStyle.Regular);
            btnAusbuchen.BackColor = Color.LightSteelBlue;
        }

        private void btnZuruck_MouseHover(object sender, EventArgs e)
        {
            btnZuruck.Font = new Font(btnZuruck.Font.Name, btnZuruck.Font.Size, FontStyle.Bold);
            btnZuruck.BackColor = Color.SteelBlue;
        }

        private void btnZuruck_MouseLeave(object sender, EventArgs e)
        {
            btnZuruck.Font = new Font(btnZuruck.Font.Name, btnZuruck.Font.Size, FontStyle.Regular);
            btnZuruck.BackColor = Color.White;
        }

        private void txtbx_Speicher_Leave(object sender, EventArgs e)
        {
            if (txtbx_Speicher.Text != "1" && txtbx_Speicher.Text != "2")
            {
                MessageBox.Show("Artikelgröße muss 1 oder 2 sein.", "Achtung!");
                btnEinbuchen.Enabled = false;
                txtbx_Speicher.BackColor = Color.Red;
            }
            else
            {
                btnEinbuchen.Enabled = true;
                txtbx_Speicher.BackColor = Color.White;
            }
        }
    }
}
