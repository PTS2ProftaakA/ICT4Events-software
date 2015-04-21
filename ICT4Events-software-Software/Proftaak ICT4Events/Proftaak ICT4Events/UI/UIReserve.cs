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
    public partial class UIReserve : Form
    {
        //Fields
        private List<TextBox>[] textboxes;
        private MapManager mapmanager;
        private Database database;
        private int spotNumber;
        
        //Creates a popup screen where the names and emailaddresses can be added
        //The names and emailaddresses are for the people coming with the reservee
        public UIReserve(int count, int spotNumber)
        {
            InitializeComponent();

            this.spotNumber = spotNumber;
            database = new Database();
            mapmanager = new MapManager(database);

            textboxes = new List<TextBox>[2];
            textboxes[0] = new List<TextBox>();
            textboxes[1] = new List<TextBox>();

            for (int i = 0; i < count; i++)
            {
                TextBox name = new TextBox();
                name.Name = "txtName" + Convert.ToString(i + 1);
                flpDinges.Controls.Add(name);
                textboxes[0].Add(name);

                TextBox email = new TextBox();
                email.Name = "txtEmail" + Convert.ToString(i + 1);
                flpDinges.Controls.Add(email);
                textboxes[1].Add(email);
            }
        }

        //Creates users for the names and emailaddresses
        //These people get usernames, passwords and RFIDs
        private void btnOK_Click(object sender, EventArgs e)
        {
            List<string>[] insertvalues = new List<string>[2];

            insertvalues[0] = new List<string>();
            insertvalues[1] = new List<string>();

            for (int i = 0; i < textboxes[1].Count();i++ )
            {
                if (textboxes[0][i].Text != "" && textboxes[1][i].Text != "")
                {
                    insertvalues[0].Add(textboxes[0][i].Text);
                    insertvalues[1].Add(textboxes[1][i].Text);

                    mapmanager.AddBasicUser(
                        Guid.NewGuid().ToString("N").Substring(0, 10),
                        CurrentUser.currentUser.UserID.ToString(),
                        insertvalues[0][i],
                        insertvalues[1][i],
                        Guid.NewGuid().ToString("N").Substring(0, 10),
                        Guid.NewGuid().ToString("N").Substring(0, 15),
                        false,
                        false,
                        1,
                        spotNumber);
                }
            }
            Close();
        }
    }
}
