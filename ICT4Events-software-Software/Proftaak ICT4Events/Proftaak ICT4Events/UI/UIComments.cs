using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak_ICT4Events
{
    public partial class Comments : Form
    {
        private Database database;
        private bool fromPost;
        private Post parentPost;

        private Comment parentComment;

        //Fills the panel with al the comments from a mediafile
        public Comments(Post post, Database database)
        {
            this.fromPost = true;
            this.database = database;
            parentPost = post;
            InitializeComponent();

            flpReactionsPost.Controls.Add(post);
            post.hideCommentBtn();
            
            foreach (Comment c in Comment.GetAllFromFile(post.mediafile.FilePath, database))
            {
                UIComment comment = new UIComment(c, database);
                flpReactionsPost.Controls.Add(comment);
            }
            flpReactionsPost.Refresh();

        }

        //Fills the panel with al the comments from a comment
        public Comments(Comment comment, Database database)
        {
            this.database = database;
            fromPost = false;
            parentComment = comment;

            InitializeComponent();

            UIComment subject = new UIComment(comment, database);
            subject.BackColor = Color.LightGray;
            flpReactionsPost.Controls.Add(subject);

            foreach (Comment c in Comment.GetAllFromComment(comment.CommentID, database))
            {
                UIComment comm = new UIComment(c, database);
                flpReactionsPost.Controls.Add(comm);
            }

            flpReactionsPost.Refresh();

        }

        //Posts a new comment
        private void btnCommentsPost_Click(object sender, EventArgs e)
        {
            int x = Comment.GetHighestCommentID(database) + 1;

            if (fromPost)
            {
                Comment comment = new Comment(parentPost.mediafile.FilePath, tbCommentsPost.Text, CurrentUser.currentUser.UserID, x, 0);
                comment.Add(comment, database);
                UIComment newComment = new UIComment(comment, database);
                flpReactionsPost.Controls.Add(newComment);
            }
            else if (!fromPost)
            {
                flpReactionsPost.Controls.Clear();
                Comment comment = new Comment(null, tbCommentsPost.Text, CurrentUser.currentUser.UserID, x, parentComment.CommentID);
                comment.Add(comment, database);

                foreach (Comment c in Comment.GetAllFromComment(parentComment.CommentID, database))
                {
                    UIComment comm = new UIComment(c, database);
                    flpReactionsPost.Controls.Add(comm);
                }

            }
            flpReactionsPost.Refresh();

        }

    }
}
