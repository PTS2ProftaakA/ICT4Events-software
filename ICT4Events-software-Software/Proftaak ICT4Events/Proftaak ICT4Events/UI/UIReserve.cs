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
        private List<TextBox>[] textboxes;
        
        public UIReserve(int count)
        {
            InitializeComponent();

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<string>[] insertvalues = new List<string>[2];

            insertvalues[0] = new List<string>();
            insertvalues[1] = new List<string>();
            string s = "";

            for (int i = 0; i < textboxes[1].Count();i++ )
            {
                insertvalues[0].Add(textboxes[0][i].Text);
                insertvalues[1].Add(textboxes[1][i].Text);
                s += insertvalues[0][i] + " - " + insertvalues[1][i] + "\r";
            }
            
            Close();
        }

        
    }
}
