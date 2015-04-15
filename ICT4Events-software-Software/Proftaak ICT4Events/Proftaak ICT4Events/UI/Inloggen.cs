using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak_ICT4Events.UI
{
    public partial class Inloggen : Form
    {
        public Inloggen()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string logInName = tbInlogName.Text;
            string password = tbPassword.Text;

        }
    }
}
