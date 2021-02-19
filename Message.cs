using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarenhausManagement
{
    public partial class Message : Form
    {
        public Message(string message)
        {
            InitializeComponent();
            this.l_message.Text = message;
            this.TopLevel = true;
            this.Show();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
