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
        public Comments(Post post)
        {
            InitializeComponent();
            flpReactionsPost.Controls.Add(post);
            post.hideCommentBtn();
            post.spaceRight();
           
            
        }

        public Comments(UIComment reactie)
        {
            InitializeComponent();
            flpReactionsPost.Controls.Add(reactie);
            reactie.hideComment();
            reactie.makeSubject();
        }

        private void btnCommentsPost_Click(object sender, EventArgs e)
        {
            UIComment r = new UIComment();
            flpReactionsPost.Controls.Add(r);
        }

       
    }
}
