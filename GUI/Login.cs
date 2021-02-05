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
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.AccountManagement;
using System.Security;

namespace WarenhausManagement
{
    public partial class Login : Form
    {
        private bool pwsichtbar = false;
        User user = new User();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            lbl_Status.Text = "";
            user.SetUsername(txtbx_Username.Text);
            user.SetPassword(txtbx_Password.Text);

            if (user.GetUsername() != "" && user.GetPassword() != null)
            {
                //Login mit AD wenn ausführender Rechner in Domäne

                string AnmeldeName = txtbx_Username.Text;
                string AnmeldePw = txtbx_Password.Text;
                try
                {
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
                }
                catch (Exception d)
                {
                    lbl_Status.Text = "Verbindung zu Domäne fehlgeschlagen: " + d;
                }

                bool AnmeldungGültig = LDAPConnection(AnmeldeName, AnmeldePw);
                //nur für Testzwecke
                //AnmeldungGültig = true;
                if (AnmeldungGültig == true)
                {
                    Mainmenu hmenu = new Mainmenu(user);
                    this.Hide();
                    hmenu.Show();
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
            catch (Exception e)
            {
                bAuth = false;
                lbl_Status.Text = "Benutzername oder Passwort falsch.";
            }
            finally
            {
                entry.Close();
                entry.Dispose();
            }
            //Testen ob Verbindung möglich
            try
            {
                ldapConnection.RefreshCache();
            }
            catch
            {
                lbl_Status.Text = "Verbindung zu Domänen-Controller nicht möglich.";
            }
            return bAuth;
        }

        private void pictureBoxPW_Click(object sender, EventArgs e)
        {
            if (pwsichtbar == false)
            {
                txtbx_Password.PasswordChar = '\0';
                pwsichtbar = true;
            }
            else
            {
                txtbx_Password.PasswordChar = '*';
                pwsichtbar = false;
            }
        }

        private void txtbx_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnlogin.PerformClick();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            lbl_Status.Text = "";
            user.SetUsername(txtbx_Username.Text);
            user.SetPassword(txtbx_Password.Text);

            if (user.GetUsername() != "" && user.GetPassword() != null)
            {
                //Login mit AD wenn ausführender Rechner in Domäne

                string AnmeldeName = txtbx_Username.Text;
                string AnmeldePw = txtbx_Password.Text;
                try
                {
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
                }
                catch (Exception d)
                {
                    lbl_Status.Text = "Verbindung zu Domäne fehlgeschlagen: " + d;
                }

                bool AnmeldungGültig = LDAPConnection(AnmeldeName, AnmeldePw);
                //testzwecke
                AnmeldungGültig = true;
                if (AnmeldungGültig == true)
                {
                    Mainmenu hmenu = new Mainmenu(user);
                    this.Hide();
                    hmenu.Show();
                }
            }
            else
            {
                lbl_Status.Text = "Eingaben nicht vollständig";
            }
        }

        private void txtbx_Username_MouseClick(object sender, MouseEventArgs e)
        {
            txtbx_Username.Text = "";
        }

        private void txtbx_Password_MouseClick(object sender, MouseEventArgs e)
        {
            txtbx_Password.Text = "";
        }

        private void btnlogin_MouseHover(object sender, EventArgs e)
        {
            btnlogin.Font = new Font(btnlogin.Font.Name, btnlogin.Font.Size, FontStyle.Bold);
            btnlogin.BackColor = Color.SteelBlue;
        }

        private void btnlogin_MouseLeave(object sender, EventArgs e)
        {
            btnlogin.Font = new Font(btnlogin.Font.Name, btnlogin.Font.Size, FontStyle.Regular);
            btnlogin.BackColor = Color.LightSteelBlue;
        }
    }
}
