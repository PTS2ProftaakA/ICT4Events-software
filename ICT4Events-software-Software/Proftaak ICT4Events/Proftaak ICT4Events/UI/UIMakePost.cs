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
        private FTPClient client;
        private MediaType mediaType;
        private string uploadString;

        public string UploadString
        {
            get { return uploadString; }
            set { uploadString = value; }
        }

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
        public makePost(List<MediaType> mediatype, Database database)
        {
            InitializeComponent();
            this.client = new FTPClient(database);
            cbPostMakeType.DataSource = mediatype;
        }

        //Opens a dialog where you can pick content
        private void btnMakePostBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog getFile = new OpenFileDialog();
            getFile.Multiselect = false;

            

            if (cbPostMakeType.SelectedIndex == 0)
            {
                
                getFile.Filter = "Video files (*.mp4, *.avi) | *.mp4; *.avi;";
            }

            if (cbPostMakeType.SelectedIndex == 1)
            {
                
                getFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png;";
            }

            if (cbPostMakeType.SelectedIndex == 2)
            {
                
                getFile.Filter = "text files (*.txt) | *.txt;";
                
            }


            if (getFile.ShowDialog() == DialogResult.OK)
            {
                uploadString = getFile.FileName.Replace("\\\\", "\\");
                tbMakePostPath.Text = uploadString;
            }
        }

        //Creates a new post
        private void btnMakePostPost_Click(object sender, EventArgs e)
        {
            if (text == "" && path == "")
            {
                MessageBox.Show("Vul het bericht en de bestandslocatie in");
                return;
            }
            else if (text == "")
            {
                MessageBox.Show("Vul het bericht in");
                return;
            }
            else if (path == "")
            {
                MessageBox.Show("Vul de bestandslocatie in");
                return;
            }


            if (cbPostMakeType.SelectedIndex != 2)
            {
                client.UploadPostFile(uploadString);
                uploadString = "/" + System.IO.Path.GetFileName(uploadString);
            }
            else
            {
                uploadString = CurrentUser.currentUser.UserID + (DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            }
            
            mediaType = (MediaType)cbPostMakeType.SelectedItem;
            text = tbPostMakeText.Text;
            userName = CurrentUser.currentUser.Username;
            profilePath = CurrentUser.currentUser.PhotoPath;
            
            Close();
        }

        //A post with textcontent doesnt need a filepath so it's disabled
        private void cbPostMakeType_DropDownClosed(object sender, EventArgs e)
        {
            if (cbPostMakeType.SelectedIndex == 0)
            {
                btnMakePostBrowse.Enabled = true;
                tbMakePostPath.Visible = true;
            }

            if (cbPostMakeType.SelectedIndex == 1)
            {
                btnMakePostBrowse.Enabled = true;
                tbMakePostPath.Visible = true;
            }

            if (cbPostMakeType.SelectedIndex == 2)
            {
                btnMakePostBrowse.Enabled = false;
                tbMakePostPath.Visible = false;
            }
        }
    }
}
