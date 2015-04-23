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
        private MediaFile mediaFile;
        private Database database;
        private bool post;
        private Comment Thiscomment;
        //Makes the post light up
        public Comments(MediaFile mediafile, Post post, Database database)
        {
            this.post = true;
            this.mediaFile = mediafile;
            this.database = database;
            InitializeComponent();
            flpReactionsPost.Controls.Add(post);
            
            post.hideCommentBtn();
            post.spaceRight();            
            flpReactionsPost.Refresh();
            foreach (Comment c in Comment.GetAllFromFile(mediafile.FilePath, database))
            {
                UIComment comment = new UIComment(User.StaticGetByUserID(c.UserID, database), c, database);
                flpReactionsPost.Controls.Add(comment);
            }
        }

        //Makes the comment light up
        public Comments(Comment comment, Database database)
        {
            this.database = database;
            post = false;
            Thiscomment = comment;
            InitializeComponent();

            UIComment subjectComment = new UIComment(User.StaticGetByUserID(comment.UserID, database), Thiscomment, database);
            flpReactionsPost.Controls.Add(subjectComment);
            subjectComment.hideComment();
            subjectComment.makeSubject();
            showComments();
        }

        //Posts a new comment
        private void btnCommentsPost_Click(object sender, EventArgs e)
        {
            if (post)
            {
                Comment comment = new Comment(mediaFile.FilePath, tbCommentsPost.Text, CurrentUser.currentUser.UserID, 1, 0);
                comment.Add(comment, database);
                UIComment newComment = new UIComment(CurrentUser.currentUser, comment, database);
                flpReactionsPost.Controls.Add(newComment);
            }
            else if(!post)
            {
                Comment comment = new Comment(null, tbCommentsPost.Text, CurrentUser.currentUser.UserID, 1, Thiscomment.CommentID);
                comment.Add(comment, database);
                showComments();
            }
            
        }
        private void showComments()
        {
            flpReactionsPost.Controls.Clear();
            UIComment subject = new UIComment(User.StaticGetByUserID(Thiscomment.UserID, database), Thiscomment, database);
            foreach (Comment c in Comment.GetAllFromComment(Thiscomment.CommentID, database))
            {
                
                UIComment comment = new UIComment(User.StaticGetByUserID(c.UserID, database), c, database);
                flpReactionsPost.Controls.Add(comment);
            }
            
        }
    }
}
