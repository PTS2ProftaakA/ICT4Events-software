using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proftaak_ICT4Events
{
    public partial class Post: UserControl
    {
        
        public Post(MediaType type, string poster, string description ,string filePath)
        {
            InitializeComponent();
            if (type.Type == "Tekst")
            {
                pbPostPhoto.Visible = false;
                wmpPostPlayer.Visible = false;

                lblTextPostContent.Text = description;
                lblPostNaam.Text = poster;
                
            }
            if (type.Type == "Plaatje")
            {
                lblTextPostContent.Visible = true;
                wmpPostPlayer.Visible = false;
                pbPostPhoto.Visible = true;

                int postWidth = 400;
                int postHeight = 380;
                Size size = new Size(postWidth, postHeight);
                this.Size = size;
                Point likeLocation = new Point(postWidth - 272, postHeight - 40);
                btnPostLike.Location = likeLocation;
                Point commentLocation = new Point(postWidth - 136, postHeight - 40);
                btnPostReageer.Location = commentLocation;
                Point lbllikeLocation = new Point(postWidth - 191, postHeight - 40);
                lblPostLike.Location = lbllikeLocation;
                Point lblcommentLocation = new Point(postWidth - 55, postHeight - 40);
                lblPostReageer.Location = lblcommentLocation;
                Point lbldescription = new Point(postWidth - 300, postHeight - 160);
                lblTextPostContent.Location = lbldescription;
                
            }

            if (type.Type == "Video")
            {
                
                pbPostPhoto.Visible = true;
                wmpPostPlayer.Visible = true;
                pbPostPhoto.Image = null;
                lblTextPostContent.Visible = true;

                int postWidth = 400;
                int postHeight = 380;
                Size size = new Size(postWidth, postHeight);
                this.Size = size;
                Point likeLocation = new Point(postWidth - 272, postHeight - 40);
                btnPostLike.Location = likeLocation;
                Point commentLocation = new Point(postWidth - 136, postHeight - 40);
                btnPostReageer.Location = commentLocation;
                Point lbllikeLocation = new Point(postWidth - 191, postHeight - 40);
                lblPostLike.Location = lbllikeLocation;
                Point lblcommentLocation = new Point(postWidth - 55, postHeight - 40);
                lblPostReageer.Location = lblcommentLocation;
                Point lbldescription = new Point(postWidth - 300, postHeight - 150);
                lblTextPostContent.Location = lbldescription;
                lblTextPostContent.SendToBack();

                wmpPostPlayer.settings.autoStart = false;
                wmpPostPlayer.URL = "C:\\Example.mp4";
          
            }
        
        }

        private void btnPostLike_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPostReageer_Click(object sender, EventArgs e)
        {
            Form f = new Comments(giveMe());
            f.Show();
        }

        private Post giveMe()
        {
            return this;
        }
        public void hideCommentBtn()
        {
            this.btnPostReageer.Visible = false;
            this.lblPostReageer.Visible = false;
        }
        public void spaceRight()
        {
            pbPostPhoto.Visible = true;
            wmpPostPlayer.Visible = true;
            pbPostPhoto.Image = null;
            lblTextPostContent.Visible = true;

            int postWidth = 700;
            int postHeight = 550;
            Size size = new Size(postWidth, postHeight);
            this.Size = size;
            Point likeLocation = new Point(postWidth - 580, postHeight - 40);
            btnPostLike.Location = likeLocation;
            Point commentLocation = new Point(postWidth - 136, postHeight - 40);
            btnPostReageer.Location = commentLocation;
            Point lbllikeLocation = new Point(postWidth - 500, postHeight - 40);
            lblPostLike.Location = lbllikeLocation;
            Point lblcommentLocation = new Point(postWidth - 55, postHeight - 40);
            lblPostReageer.Location = lblcommentLocation;
            Point lbldescription = new Point(postWidth - 580, postHeight - 180);
            lblTextPostContent.Location = lbldescription;
            Point wmp = new Point(postWidth - 580, postHeight - 540);
            wmpPostPlayer.Location = wmp;
            lblTextPostContent.SendToBack();
        }

        
                
            
            
            // lblPostLike.Text
            // lblPostReageer.Text
        }
    }
