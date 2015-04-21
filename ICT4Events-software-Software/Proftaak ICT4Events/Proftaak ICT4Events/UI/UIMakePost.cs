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
        //Fields
        private string text;
        private string path;
        private string userName;
        private string profilePath;

        private MediaType mediaType;

        //Properties
        #region properties
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string ProfilePath
        {
            get { return profilePath; }
            set { profilePath = value; }
        }
        public MediaType MediaType
        {
          get { return mediaType; }
          set { mediaType = value; }
        }
        #endregion

        //Creates a new instance and fills the type combobox with all the mediatypes
        //Is uses a function from the feedmanager
        public makePost(List<MediaType> mediatype)
        {
            InitializeComponent();
            cbPostMakeType.DataSource = mediatype;
        }

        //not implemented yet
        private void btnMakePostBrowse_Click(object sender, EventArgs e)
        {

        }

        //Creates a new post
        private void btnMakePostPost_Click(object sender, EventArgs e)
        {
            mediaType = (MediaType)cbPostMakeType.SelectedItem;
            text = tbPostMakeText.Text;
            path = tbMakePostPath.Text;
            userName = CurrentUser.currentUser.Username;
            profilePath = CurrentUser.currentUser.PhotoPath;
            Close();
        }
    }
}
