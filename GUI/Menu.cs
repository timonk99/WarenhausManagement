using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace WarenhausManagement.GUI
{
    public partial class Mainmenu : Form
    {
        private string _Username;
        private bool Einbuchen;
        User user = new User();
        //Rolle kontrollieren

        string ADGroupName = "Config-Office-Makros-aus";
        //bool Test123 = ADGroup(ADGroupName);

        public Mainmenu(User _user)
        {
            InitializeComponent();
            user = _user;
            lbl_User.Text = user.GetUsername();
        }

        private void btn_Einbuchen_Click(object sender, EventArgs e)
        {
            Einbuchen = true;
            Buchung buchung = new Buchung(Einbuchen, user) ;
            buchung.Show();
        }

        private void btn_Ausbuchen_Click(object sender, EventArgs e)
        {
            Einbuchen = false;
            Buchung buchung = new Buchung(Einbuchen, user);
            buchung.Show();
        }

        private void pictureBox_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }
        private bool ADGroup(string ingroup)
        {
            string username = Environment.UserName;

            PrincipalContext domainctx = new PrincipalContext(ContextType.Domain, "WHM", "DC=WHM,DC=local");

            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domainctx, IdentityType.SamAccountName, username);
            bool isMember = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, ingroup);
            return isMember;
        }

        private void btn_Statistik_Click(object sender, EventArgs e)
        {
            Statistik.StatsMain stat = new Statistik.StatsMain();
            stat.Show();
        }
    }
}
