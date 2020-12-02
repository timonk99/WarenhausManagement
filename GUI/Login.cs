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
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.AccountManagement;
using System.Security;

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

            if (user.GetUsername() != "" && user.GetPassword() != null)
            {
                //Login mit AD wenn ausführender Rechner in Domäne

                string AnmeldeName = txtbx_Username.Text;
                string AnmeldePw = txtbx_Password.Text;

                using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
                {
                    // find a user
                    UserPrincipal nutzer = UserPrincipal.FindByIdentity(ctx, AnmeldeName);

                    if (nutzer != null)
                    {
                        // get the user's groups
                        var groups = nutzer.GetAuthorizationGroups();

                        foreach (GroupPrincipal group in groups)
                        {
                            if (group.Name == "WHM_DB_Lager")
                            {
                                user.SetRolle("WHM_DB_Lager");
                            }
                            if (group.Name == "WHM_DB_Einkauf")
                            {
                                user.SetRolle("WHM_DB_Einkauf");
                            }
                            if (group.Name == "WHM_DB_Admin")
                            {
                                user.SetRolle("WHM_DB_Admin");
                            }
                        }
                    }

                }

                bool AnmeldungGültig = LDAPConnection(AnmeldeName, AnmeldePw);

                if (AnmeldungGültig == true)
                {
                    Mainmenu hmenu = new Mainmenu(user);
                    this.Hide();
                    hmenu.Show();
                }
                else
                {
                    lbl_Status.Text = "Eingaben nicht vollständig";
                }

                //User für Testzwecke
                /*user.SetUsername("SA");
                user.SetPassword("Ers1234Ers1234");
                Mainmenu hmenu = new Mainmenu(user);
                this.Hide();
                hmenu.Show();
                */
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
        public bool LDAPConnection(string username, string password)
        {

            //Variablen deklarieren
            SecureString pwd = new SecureString();
            bool bAuth = false;
            DirectoryEntry entry = null;

            //LDAP Verbindung aufbauen

            DirectoryEntry ldapConnection = new DirectoryEntry("WHM.local");
            ldapConnection.Path = "LDAP://CN=DBUser,DC=WHM,DC=local";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

            foreach (char c in password)
            {
                pwd.AppendChar(c);
            }

            //Passwort wird einem Pointer übergeben, damit dieser später "entschlüsselt" werden kann
            IntPtr pPwd = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(pwd);

            try
            {
                entry = new DirectoryEntry(string.Concat(@"LDAP://WHM.local"), username, System.Runtime.InteropServices.Marshal.PtrToStringBSTR(pPwd));
                object nativeObject = entry.NativeObject;
                bAuth = true;
            }
            catch (Exception)
            {
                bAuth = false;
            }
            finally
            {
                entry.Close();
                entry.Dispose();
            }

            return bAuth;
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
