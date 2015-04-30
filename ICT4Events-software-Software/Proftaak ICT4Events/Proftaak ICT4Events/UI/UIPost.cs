﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
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
        public User poster;
        Database database;
        public MediaFile mediafile;
        private FTPClient client;

        //A new post with certain specifications
        //This determines if the post is text or a picture
        public Post(MediaFile mediafile, User poster, Database database)
        {
            InitializeComponent();

            this.database = database;
            this.poster = poster;
            this.mediafile = mediafile;

            editLikelabel();
            editCommentLabel();

            client = new FTPClient(database);

            Rating rating = Rating.GetRatingByFilepathAndUserID(CurrentUser.currentUser.UserID, mediafile.FilePath, database);
            if (rating != null)
            {
                if (rating.Positive == true)
                    btnPostLike.Text = "Unlike";
                else
                {
                    btnPostLike.Text = "Gerapporteerd";
                    btnPostLike.Enabled = false;
                }
            }


            if (mediafile.MediaTypeName.Type == "Tekst")
            {
                pbPostPhoto.Visible = false;
                //wmpPostPlayer.Visible = false;

                lblTextPostContent.Text = mediafile.Description;
                lblPostNaam.Text = poster.Username;
                int postWidth = 400;
                int postHeight = 190;
                Size size = new Size(postWidth, postHeight);
                this.Size = size;
                Point likeLocation = new Point(postWidth - 272, postHeight - 40);
                btnPostLike.Location = likeLocation;
                Point commentLocation = new Point(postWidth - 136, postHeight - 40);
                btnPostReageer.Location = commentLocation;
                Point lbllikeLocation = new Point(postWidth - 170, postHeight - 40);
                lblPostLike.Location = lbllikeLocation;
                Point lblcommentLocation = new Point(postWidth - 55, postHeight - 40);
                lblPostReageer.Location = lblcommentLocation;
                Point lbldescription = new Point(postWidth - 300, postHeight - 160);
                //  pbPostProfPicture.ImageLocation = mediafile.FilePath;

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
                Point lbllikeLocation = new Point(postWidth - 170, postHeight - 40);
                lblPostLike.Location = lbllikeLocation;
                Point lblcommentLocation = new Point(postWidth - 55, postHeight - 40);
                lblPostReageer.Location = lblcommentLocation;
                Point lbldescription = new Point(postWidth - 300, postHeight - 160);
                lblTextPostContent.Location = lbldescription;

                lblTextPostContent.Text = mediafile.Description;
                lblPostNaam.Text = poster.Username;

                client.DownloadTempFile(mediafile.FilePath);
                pbPostPhoto.ImageLocation = Path.GetTempPath() + Path.GetFileName(mediafile.FilePath);
                // pbPostProfPicture.ImageLocation = mediafile.FilePath;
            }

            if (mediafile.MediaTypeName.Type == "Video")
            {
                /*
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

                lblTextPostContent.Text = mediafile.Description;
                lblPostNaam.Text = poster.Username;
                pbPostProfPicture.ImageLocation = mediafile.FilePath;

                wmpPostPlayer.settings.autoStart = false;
                wmpPostPlayer.URL = "C:\\Example.mp4";
                */

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
                Point lbllikeLocation = new Point(postWidth - 170, postHeight - 40);
                lblPostLike.Location = lbllikeLocation;
                Point lblcommentLocation = new Point(postWidth - 55, postHeight - 40);
                lblPostReageer.Location = lblcommentLocation;
                Point lbldescription = new Point(postWidth - 300, postHeight - 160);
                lblTextPostContent.Location = lbldescription;

                lblTextPostContent.Text = mediafile.Description;
                lblPostNaam.Text = poster.Username;
                //   pbPostProfPicture.ImageLocation = mediafile.FilePath;
            }

        }

        //Makes it possible like a post, and unlike after if needed
        private void btnPostLike_Click(object sender, EventArgs e)
        {
            //Tim edited this, make sure to put this through at the end of the day.
            try
            {
                Rating rating = Rating.GetRatingByFilepathAndUserID(CurrentUser.currentUser.UserID, mediafile.FilePath, database);
                if (rating == null)
                {
                    Rating newRating = new Rating(mediafile.FilePath, CurrentUser.currentUser.UserID, 1, 0, true);
                    newRating.FilePath = mediafile.FilePath;
                    newRating.Add(newRating, database);
                    btnPostLike.Text = "Unlike";
                }
                else
                {
                    rating.Remove(rating, database);
                    btnPostLike.Text = "Like";
                }
                editLikelabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Creates a form to react to the posted object
        private void btnPostReageer_Click(object sender, EventArgs e)
        {
            Comments newForm = new Comments(this, database);
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.Cancel)
            {

                editCommentLabel();
                editLikelabel();
            }
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

        //Edits the like label to display the correct amount of likes
        private void editLikelabel()
        {
            List<Rating> ratings = Rating.getAllFromFile(mediafile.FilePath, database);
            int likes = ratings.Where(rating => rating.Positive).Count();
            lblPostLike.Text = Convert.ToString(likes);
        }

        //Edits the comment label to display the correct amount of comments
        private void editCommentLabel()
        {
            List<Comment> comments = new List<Comment>();
            comments = Comment.GetAllFromFile(mediafile.FilePath, database);
            lblPostReageer.Text = Convert.ToString(comments.Count());

        }

        //Reports the post if it was not yet reported
        //If it was reported it will undo that decision
        private void btnPostReport_Click(object sender, EventArgs e)
        {
            Rating rating = Rating.GetRatingByFilepathAndUserID(CurrentUser.currentUser.UserID, mediafile.FilePath, database);
            if (rating != null)
            {
                if (rating.Positive == true)
                {
                    rating.Positive = false;
                    rating.Edit(rating, database);
                    btnPostLike.Enabled = false;
                    btnPostLike.Text = "Gerapporteerd";
                }
                else
                {
                    rating.Remove(rating, database);
                    btnPostLike.Enabled = true;
                    btnPostLike.Text = "Like";
                }
            }
            else
            {
                Rating report = new Rating(mediafile.FilePath, CurrentUser.currentUser.UserID, 1, 0, false);
                btnPostLike.Text = "Gerapporteerd";
                report.Add(report, database);
                btnPostLike.Enabled = false;
            }
            editLikelabel();
        }
    }
}
