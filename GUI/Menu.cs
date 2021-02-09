﻿using System;
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
        public User user = new User();
        //Rolle kontrollieren

        string ADGroupName = "Config-Office-Makros-aus";
        //bool Test123 = ADGroup(ADGroupName);

        public Mainmenu(User _user)
        {
            InitializeComponent();
            user = _user;
            lbl_User.Text = user.GetUsername();

            if(user.GetRolle()== "WHM_DB_Einkauf")
            {
                btnEinbuchen.Visible = false;
                btnAusbuchen.Visible = false; 
            }
            else if(user.GetRolle()== "WHM_DB_Lager")
            {
                btnStatistik.Visible = false;
            }
        }

        private void btn_Einbuchen_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Ausbuchen_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }
        //private bool ADGroup(string ingroup)
        //{
        //    string username = Environment.UserName;

        //    PrincipalContext domainctx = new PrincipalContext(ContextType.Domain, "WHM", "DC=WHM,DC=local");

        //    UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domainctx, IdentityType.SamAccountName, username);
        //    bool isMember = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, ingroup);
        //    return isMember;
        //}

        private void btnEinbuchen_Click(object sender, EventArgs e)
        {
            Einbuchen = true;
            Buchung buchung = new Buchung(Einbuchen, user);
            buchung.Show();
        }

        private void btnAusbuchen_Click(object sender, EventArgs e)
        {
            Einbuchen = false;
            Buchung buchung = new Buchung(Einbuchen, user);
            buchung.Show();
        }

        private void btnStatistik_Click(object sender, EventArgs e)
        {
            Statistik.StatsMain stat = new Statistik.StatsMain(user);
            stat.Show();
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

        private void btnStatistik_MouseHover(object sender, EventArgs e)
        {
            btnStatistik.Font = new Font(btnStatistik.Font.Name, btnStatistik.Font.Size, FontStyle.Bold);
            btnStatistik.BackColor = Color.SteelBlue;
        }

        private void btnStatistik_MouseLeave(object sender, EventArgs e)
        {
            btnStatistik.Font = new Font(btnStatistik.Font.Name, btnStatistik.Font.Size, FontStyle.Regular);
            btnStatistik.BackColor = Color.LightSteelBlue;
        }
    }
}
