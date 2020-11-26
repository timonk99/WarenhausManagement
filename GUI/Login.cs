﻿using System;
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

namespace WarenhausManagement
{
    public partial class Login : Form
    {
        public string _Username;
        public string _Password;
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            User user = new User();
            lbl_Status.Text = "";
            _Username = txtbx_Username.Text;
            _Password = CreateMD5Hash(txtbx_Password.Text);
            if (_Username!= "" && _Password != null)
            {
                //Login mit DB oder AD
                //nächste Form aufrufen nur wenn erfolgreich
                //user füllen
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
