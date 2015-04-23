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
    public partial class Post : UserControl
    {
        //Creates a post with a certain type
        //The type decides the visuals of the post
        public User user;
        Database database;
        MediaFile postFile;
        public Post(MediaFile mediafile, User poster, Database Database)
        {
            InitializeComponent();
            database = Database;
            user = poster;
            postFile = mediafile;
            editLikelabel();
            editCommentLabel();
            
            
          
            
            
            
            if (mediafile.MediaTypeName.Type == "Tekst")
            {
                pbPostPhoto.Visible = false;
                //wmpPostPlayer.Visible = false;

                lblTextPostContent.Text = mediafile.Description;
                lblPostNaam.Text = poster.Username;
                pbPostProfPicture.ImageLocation = mediafile.FilePath;

            }
            if (mediafile.MediaTypeName.Type == "Afbeelding")
            {
                lblTextPostContent.Visible = true;
              //  wmpPostPlayer.Visible = false;
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

                lblTextPostContent.Text = mediafile.Description;
                lblPostNaam.Text = poster.Username;
                pbPostProfPicture.ImageLocation = mediafile.FilePath;
            }

            if (mediafile.MediaTypeName.Type == "Video")
            {

                pbPostPhoto.Visible = true;
             //   wmpPostPlayer.Visible = true;
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

                lblTextPostContent.Text = mediafile.Description;
                lblPostNaam.Text = poster.Username;
                pbPostProfPicture.ImageLocation = mediafile.FilePath;

             //   wmpPostPlayer.settings.autoStart = false;
            //    wmpPostPlayer.URL = "C:\\Example.mp4";

            }

        }

        //not implemented yet
        private void btnPostLike_Click(object sender, EventArgs e)
        {
            Rating newRating = new Rating(postFile.FilePath, user.UserID, 1, 0, true);
            newRating.FilePath = postFile.FilePath;
            newRating.Add(newRating, database);
            editLikelabel();
            
        }

        //Creates a form to react to the posted object
        private void btnPostReageer_Click(object sender, EventArgs e)
        {
            Form newForm = new Comments(postFile, this, database);
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.Cancel)
            {
               
                editCommentLabel();
                editLikelabel();
            }
        }
        private Post giveMe()
        {
            return this;
        }

        //Hides the ability to comment
        public void hideCommentBtn()
        {
            this.btnPostReageer.Visible = false;
            this.lblPostReageer.Visible = false;
        }

        //Makes sure the location of the post is correct
        public void spaceRight()
        {
            pbPostPhoto.Visible = true;
          //  wmpPostPlayer.Visible = true;
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
      //      wmpPostPlayer.Location = wmp;
            lblTextPostContent.SendToBack();
        }
        // lblPostLike.Text
        // lblPostReageer.Text
        private void editLikelabel()
        {
            List<Rating> likes = new List<Rating>();
            List<Rating> ratings = new List<Rating>();
            ratings = Rating.getAllFromFile(postFile.FilePath, database);
            
                foreach (Rating r in ratings)
                {
                    if (r.Positive)
                    {
                        likes.Add(r);
                    }
                }
                lblPostLike.Text = Convert.ToString(likes.Count());

            
        }
        private void editCommentLabel()
        {
            List<Comment> comments = new List<Comment>();
            comments = Comment.GetAllFromFile(postFile.FilePath, database);
           lblPostReageer.Text = Convert.ToString(comments.Count());
            
        }
    }
}
