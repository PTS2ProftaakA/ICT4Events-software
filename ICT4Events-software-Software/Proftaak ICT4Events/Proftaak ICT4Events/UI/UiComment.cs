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

        //Not yet implemented
        private void btnCommentLike_Click(object sender, EventArgs e)
        {

        }

        //Creates a form where the user can react
        private void btnCommentReageer_Click(object sender, EventArgs e)
        {
            Form newForm = new Comments(giveMe());
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
    }
}
