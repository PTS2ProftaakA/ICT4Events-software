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
    public partial class NewLocation : Form
    {
        private Database database;

        private EventManager eventManager;

        public NewLocation()
        {
            InitializeComponent();

            database = new Database();

            eventManager = new EventManager(database);
        }

        private void btnNewLocationOk_Click(object sender, EventArgs e)
        {
            if(!eventManager.newLocation(tbNewLocationName.Text, tbNewLocationAdres.Text, tbNewLocationPhone.Text, tbNewLocationEmail.Text, tbNewLocationCity.Text, tbNewLocationMax.Text))
            {
                MessageBox.Show("Niet alle velden zijn correct ingevuld");
            }
            
        }
    }
}
