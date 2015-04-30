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

            //Rating r = Rating.GetRatingByCommentIDAndUserID(CurrentUser.currentUser.UserID, comment.CommentID, database);
            //if (r != null)
            //{
            //    if (r.Positive)
            //        btnCommentLike.Text = "Unlike";
            //    else if (!r.Positive)
            //    {
            //        btnCommentLike.Text = "Gerapporteerd";
            //        btnCommentLike.Enabled = false;
            //    }
            //}

        }

        //Not yet implemented
        private void btnCommentLike_Click(object sender, EventArgs e)
        {
            try
            {
                Rating r = Rating.GetRatingByCommentIDAndUserID(CurrentUser.currentUser.UserID, comment.CommentID, database);
                if (r == null)
                {
                    Rating like = new Rating(null, CurrentUser.currentUser.UserID, 1, comment.CommentID, true);
                    like.Add(like, database);
                    btnCommentLike.Text = "Unlike";
                }
                else
                {
                    r.Remove(r, database);
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
        public void editLikeLabel()
        {
            List<Rating> ratings = new List<Rating>();
            ratings = Rating.getAllFromComment(comment.CommentID, database);
            int likes = ratings.Where(r => r.Positive).Count();
            lblCommentLike.Text = Convert.ToString(likes);
        }
        public void editCommentLabel()
        {
            List<Comment> comments = new List<Comment>();
            comments = Comment.GetAllFromComment(comment.CommentID, database);
            lblCommentComment.Text = Convert.ToString(comments.Count());

        }

        private void btnCommentReport_Click(object sender, EventArgs e)
        {
            try
            {
                Rating r = Rating.GetRatingByCommentIDAndUserID(CurrentUser.currentUser.UserID, comment.CommentID, database);
                if (r != null)
                {
                    if (r.Positive)
                    {
                        r.Positive = false;
                        r.Edit(r, database);
                        btnCommentLike.Enabled = false;
                        btnCommentLike.Text = "Gerapporteerd";
                    }
                    else
                    {
                        r.Remove(r, database);
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
