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

        private void txtbx_ArtikelNr_TextChanged(object sender, EventArgs e)
        {
            Ware ware = new Ware();
            if (_Einbuchung != true)
            {
                //Laden der Daten zum dem Artikel aus der DB in die Textfelder
                ware.SetWareID(Convert.ToInt32(txtbx_ArtikelNr.Text));
                ware = WareninformationenLaden(ware);
                txtbx_Bezeichnung.Text = ware.GetWareBezeichnung();
                txtbx_Preis.Text = ware.GetPreis().ToString();
            }
        }
        private Ware WareninformationenLaden(Ware ware)
        {
            string queryString = "SELECT *  FROM  Ware WHERE WareID = @WareID";
            string connectionString = "Server=172.16.112.25;Database=WHM;User Id=SA;Password=Ers1234Ers1234;";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(queryString, conn);
            command.Parameters.AddWithValue("@WareID", ware.GetWareID());
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    ware.SetWareBezeichnung(reader.GetString(1));
                    ware.SetPreis(reader.GetDouble(2));
                }
            }
            catch
            {

            }
            finally
            {
                reader.Close();
            }

            return ware;
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
    }
}
