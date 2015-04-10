using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak_ICT4Events
{
    public partial class UIMainForm : Form
    {
        private Database database;
        public UIMainForm()
        {
            InitializeComponent();
            database = new Database();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.Connect();
        }
    }
}
