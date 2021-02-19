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
using System.Configuration;

namespace WarenhausManagement
{
    public partial class Login : Form
    {
        private bool pwsichtbar = false;
        private bool pwfalsch = true;
        User user = new User();
        public Login()
        {
            InitializeComponent();
        }

        //Feld Speicherbedarf in DB
        
        public bool LDAPConnection(string username, string password)
        {

            //Variablen deklarieren
            SecureString pwd = new SecureString();
            bool bAuth = false;
            DirectoryEntry entry = null;

            //LDAP Verbindung aufbauen

            string ad = ConfigurationManager.AppSettings["ad"];
            string dcpre = ConfigurationManager.AppSettings["dcpre"];
            string dcsuf = ConfigurationManager.AppSettings["dcsuf"];
            DirectoryEntry ldapConnection = new DirectoryEntry(ad);
            ldapConnection.Path = "LDAP://CN=Users,DC="+dcpre+",DC="+dcsuf+"";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

            foreach (char c in password)
            {
                pwd.AppendChar(c);
            }

            //Passwort wird einem Pointer übergeben, damit dieser später "entschlüsselt" werden kann
            IntPtr pPwd = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(pwd);

            try
            {
                entry = new DirectoryEntry(string.Concat(@"LDAP://"+dcpre+"."+dcsuf+""), username, System.Runtime.InteropServices.Marshal.PtrToStringBSTR(pPwd));
                object nativeObject = entry.NativeObject;
                bAuth = true;
            }
            catch (Exception e)
            {
                lbl_Status.Text = e.Message;
                bAuth = false;
                if (e.Message == "Der Benutzername oder das Kennwort ist falsch.\r\n")
                {
                    pwfalsch = true;
                }
                else
                {
                    pwfalsch = false;
                }
            }
            finally
            {
                entry.Close();
                entry.Dispose();
            }
            if (pwfalsch == false)
            {
                //Testen ob Verbindung möglich
                try
                {
                    ldapConnection.RefreshCache();
                }
                catch (Exception e)
                {
                    lbl_Status.Text = "Domäne nicht vorhanden oder nicht verbunden";
                    MessageBox.Show(e.Message, "Achtung!");
                }
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
                    lbl_Status.Text = d.Message;
                }

                bool AnmeldungGültig = LDAPConnection(AnmeldeName, AnmeldePw);
                if (AnmeldungGültig == true)
                {
                    Mainmenu hmenu = new Mainmenu(user);
                    this.Hide();
                    hmenu.Show();
                }
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
