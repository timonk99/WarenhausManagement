using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarenhausManagement.GUI;
using System.DirectoryServices.ActiveDirectory;

namespace WarenhausManagement
{
    public partial class Login : Form
    {
        User user = new User();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            lbl_Status.Text = "";
            user.SetUsername(txtbx_Username.Text);
            user.SetPassword(CreateMD5Hash(txtbx_Password.Text));
            if (user.GetUsername()!= "" && user.GetPassword() != null)
            {
                //Login mit DB oder AD
                //nächste Form aufrufen nur wenn erfolgreich
                //user für Testzwecke
                user.SetUsername("SA");
                user.SetPassword("Ers1234Ers1234");
                Mainmenu hmenu = new Mainmenu(user);
                this.Hide();
                hmenu.Show();
            }
            else
            {
                lbl_Status.Text = "Eingaben nicht vollständig";
            }
        }
        //Feld Speicherbedarf in DB
        public string CreateMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private void pictureBoxPW_Click(object sender, EventArgs e)
        {
            txtbx_Password.PasswordChar = '\0';
        }

        private void pictureBoxPW_MouseLeave(object sender, EventArgs e)
        {
            txtbx_Password.PasswordChar = '*';
        }
    }
}
