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
    public partial class UIMainForm : Form
    {  
        private DiscussionManager discussionManager;
        private EquipmentManager equipmentManager;
        private FeedManager feedManager;
        private LogInManager logInManager;
        private MapManager mapManager;
        private MediaFileManager mediaFileManager;
        private PersonalInfoManager personalInfoManager;
        private ProductTypeManager productTypeManager;

        private Database database;

        public UIMainForm()
        {
            InitializeComponent();

            database = new Database();

            discussionManager = new DiscussionManager(database);
            equipmentManager = new EquipmentManager(database);
            feedManager = new FeedManager(database);
            logInManager = new LogInManager(database);
            mapManager = new MapManager(database);
            mediaFileManager = new MediaFileManager(database);
            personalInfoManager = new PersonalInfoManager(database);
            productTypeManager = new ProductTypeManager(database);
        }   
        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Bebas", (float)20.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            string description = "Ik vind Matthijs echt een aardige knul.";
            string naam = "Martino";
            string derp = "derp";
            FileType aapje = FileType.Video;
            Post Post = new Post(aapje, naam, description, derp);
            
            
            flpPosts.Controls.Add(Post);        
        }

        private void btnMakePost_Click(object sender, EventArgs e)
        {
            Form f = new UI.makePost();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UI.UILogIn testLogIn = new UI.UILogIn();
            testLogIn.Show();
        }

    }
}
