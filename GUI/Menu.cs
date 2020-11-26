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
    public partial class Mainmenu : Form
    {
        private string _Username;
        private bool Einbuchen;
        User user = new User();
        //Rolle kontrollieren

        public Mainmenu(User _user)
        {
            InitializeComponent();
            user = _user;
            lbl_User.Text = user.GetUsername();
        }

        private void btn_Einbuchen_Click(object sender, EventArgs e)
        {
            Einbuchen = true;
            Buchung buchung = new Buchung(Einbuchen);
            buchung.Show();
        }

        private void btn_Ausbuchen_Click(object sender, EventArgs e)
        {
            Einbuchen = false;
            Buchung buchung = new Buchung(Einbuchen);
            buchung.Show();
        }

        private void pictureBox_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }
    }
}
