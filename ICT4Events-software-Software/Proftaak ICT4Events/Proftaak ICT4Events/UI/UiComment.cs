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
    public partial class UIComment : UserControl
    {
        private User user;
        private Comment comment;
        private Database database;

        public UIComment(Comment comment, Database database)
        {
            InitializeComponent();

            this.database = database;
            user = User.StaticGetByUserID(comment.UserID, database);
            this.comment = comment;
            lblCommentName.Text = user.Username;
            lblComment.Text = comment.Content;
            editLikeLabel();
            editCommentLabel();
        }

        //This button is used to like a post or comment
        private void btnCommentLike_Click(object sender, EventArgs e)
        {
            try
            {
                Rating rating = Rating.GetRatingByCommentIDAndUserID(CurrentUser.currentUser.UserID, comment.CommentID, database);
                if (rating == null)
                {
                    Rating like = new Rating(null, CurrentUser.currentUser.UserID, 1, comment.CommentID, true);
                    like.Add(like, database);
                    btnCommentLike.Text = "Unlike";
                }
                else
                {
                    rating.Remove(rating, database);
                    btnCommentLike.Text = "Like";
                }
                editLikeLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Creates a form where the user can react
        private void btnCommentReageer_Click(object sender, EventArgs e)
        {
            Comments newForm = new Comments(comment, database);
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.Cancel)
            {
                editCommentLabel();
            }
        }

        //returns this form
        private UIComment giveMe()
        {
            return this;
        }

        //Removes the possibility to react to an object
        public void hideComment()
        {
            btnCommentReageer.Visible = false;
            lblCommentComment.Visible = false;
        }

        //Gives the comment a gray background
        public void makeSubject()
        {
            BackColor = Color.Gray;
        }

        //Edits label to display correct amount of likes
        public void editLikeLabel()
        {
            List<Rating> ratings = new List<Rating>();
            ratings = Rating.getAllFromComment(comment.CommentID, database);
            int likes = ratings.Where(rating => rating.Positive).Count();
            lblCommentLike.Text = Convert.ToString(likes);
        }

        //Edits label to display correct amount of comments
        public void editCommentLabel()
        {
            List<Comment> comments = new List<Comment>();
            comments = Comment.GetAllFromComment(comment.CommentID, database);
            lblCommentComment.Text = Convert.ToString(comments.Count());
        }

        //Button used to report a post
        private void btnCommentReport_Click(object sender, EventArgs e)
        {
            try
            {
                Rating rating = Rating.GetRatingByCommentIDAndUserID(CurrentUser.currentUser.UserID, comment.CommentID, database);
                if (rating != null)
                {
                    if (rating.Positive)
                    {
                        rating.Positive = false;
                        rating.Edit(rating, database);
                        btnCommentLike.Enabled = false;
                        btnCommentLike.Text = "Gerapporteerd";
                    }
                    else
                    {
                        rating.Remove(rating, database);
                        btnCommentLike.Enabled = true;
                        btnCommentLike.Text = "Like";
                    }
                }
                else
                {
                    Rating report = new Rating(null, CurrentUser.currentUser.UserID, 1, comment.CommentID, false);
                    report.Add(report, database);
                    btnCommentLike.Text = "Gerapporteerd";
                    btnCommentLike.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            editLikeLabel();
        }
    }
}
