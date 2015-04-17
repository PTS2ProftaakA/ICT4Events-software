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
        public UIComment()
        {
            InitializeComponent();
        }

        private void btnCommentLike_Click(object sender, EventArgs e)
        {

        }

        private void btnCommentReageer_Click(object sender, EventArgs e)
        {
            Form f = new Comments(giveMe());
            f.Show();
        }
        private UIComment giveMe()
        {
            return this;
        }
        public void hideComment()
        {
            btnCommentReageer.Visible = false;
            lblCommentComment.Visible = false;
        }
        public void makeSubject()
        {
            BackColor = Color.Gray;
        }
    }
}
