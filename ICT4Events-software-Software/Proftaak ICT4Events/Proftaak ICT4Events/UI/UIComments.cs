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
        //Makes the post light up
        public Comments(Post post)
        {
            InitializeComponent();
            flpReactionsPost.Controls.Add(post);
            post.hideCommentBtn();
            post.spaceRight();            
        }

        //Makes the comment light up
        public Comments(UIComment comment)
        {
            InitializeComponent();
            flpReactionsPost.Controls.Add(comment);
            comment.hideComment();
            comment.makeSubject();
        }

        //Posts a new comment
        private void btnCommentsPost_Click(object sender, EventArgs e)
        {
            UIComment newComment = new UIComment();
            flpReactionsPost.Controls.Add(newComment);
        }
    }
}
