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
    public partial class makePost : Form
    {
        public MediaType MediaType { get; set; }
        public string Text { get; set; }

        public string Path { get; set; }

        public string Username { get; set; }

        public string ProfilePath { get; set; }

        public makePost(List<MediaType> mediatype)
        {
            InitializeComponent();
            cbPostMakeType.DataSource = mediatype;
        }

        private void btnMakePostBrowse_Click(object sender, EventArgs e)
        {

        }

        private void btnMakePostPost_Click(object sender, EventArgs e)
        {
            MediaType = (MediaType)cbPostMakeType.SelectedItem;
            Text = tbMakePostPath.Text;
            Path = tbMakePostPath.Text;
            Username = CurrentUser.currentUser.Username;
            ProfilePath = CurrentUser.currentUser.PhotoPath;
            Close();
        }
    }
}
