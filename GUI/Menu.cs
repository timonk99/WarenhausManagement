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
        private bool Einbuchen;
        public Mainmenu()
        {
            InitializeComponent();
        }

        private void btn_Einbuchen_Click(object sender, EventArgs e)
        {
            Einbuchen = true;
            Buchung buchung = new Buchung(Einbuchen);
            this.Hide();
            buchung.Show();
        }

        private void btn_Ausbuchen_Click(object sender, EventArgs e)
        {
            Einbuchen = false;
            Buchung buchung = new Buchung(Einbuchen);
            this.Hide();
            buchung.Show();
        }
    }
}
