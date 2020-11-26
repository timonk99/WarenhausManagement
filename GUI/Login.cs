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

namespace WarenhausManagement
{
    public partial class Login : Form
    {
        private string _Username;
        private string _Password;
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            lbl_Status.Text = "";
            _Username = txtbx_Username.Text;
            _Password = CreateMD5Hash(txtbx_Password.Text);
            if (_Username!= "" && _Password != null)
            {
                //Login mit DB oder AD
                //nächste Form aufrufen wenn erfolgreich
                Mainmenu hmenu = new Mainmenu(_Username);
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

        private void pictureBoxPWclear_Click(object sender, EventArgs e)
        {
            txtbx_Password.PasswordChar = '\0';
        }

        private void pictureBoxPWclear_MouseLeave(object sender, EventArgs e)
        {
            txtbx_Password.PasswordChar = '*';
        }

        /*
   string queryString = "SELECT tPatCulIntPatIDPk, tPatSFirstname, tPatSName, tPatDBirthday  FROM  [dbo].[TPatientRaw] WHERE tPatSName = @tPatSName";
   string connectionString = "Server=172.16.112.25;Database=;WHM Id=SA;Password=Ers1234Ers1234;";

   using (SqlConnection connection = new SqlConnection(connectionString))
   {
       SqlCommand command = new SqlCommand(queryString, connection);
       command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
       connection.Open();
       SqlDataReader reader = command.ExecuteReader();
       try
       {
           while (reader.Read())
           {
               Console.WriteLine(String.Format("{0}, {1}",
               reader["tPatCulIntPatIDPk"], reader["tPatSFirstname"]));// etc
           }
       }
       finally
       {
           // Always call Close when done reading.
           reader.Close();
       }
   }
*/
    }
}
