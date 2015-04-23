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
        public UIComment(User user, Comment comment, Database database)
        {
            InitializeComponent();

            this.database = database;
            this.user = user;
            this.comment = comment;
            lblCommentName.Text = user.Username;
            lblComment.Text = comment.Content;
            editLikeLabel();
            editCommentLabel();
        }

        //Not yet implemented
        private void btnCommentLike_Click(object sender, EventArgs e)
        {
            Rating like = new Rating(null, CurrentUser.currentUser.UserID, 1, comment.CommentID, true);
            like.Add(like, database);
            editLikeLabel();
        }

        //Creates a form where the user can react
        private void btnCommentReageer_Click(object sender, EventArgs e)
        {
            Form newForm = new Comments(comment, database);
            newForm.Show();
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
            List<Rating> likes = new List<Rating>();
            List<Rating> ratings = new List<Rating>();
            ratings = Rating.getAllFromComment(comment.CommentID, database);

            foreach (Rating r in ratings)
            {
                if (r.Positive)
                {
                    likes.Add(r);
                }
            }
            lblCommentLike.Text = Convert.ToString(likes.Count());
        }
        public void editCommentLabel()
        {
            List<Comment> comments = new List<Comment>();
            comments = Comment.GetAllFromComment(comment.CommentID, database);
            lblCommentComment.Text = Convert.ToString(comments.Count());

        }
    }
}
