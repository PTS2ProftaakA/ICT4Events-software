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
        private FeedManager feedManager;
        private LogInManager logInManager;
        private MapManager mapManager;
        private MediaFileManager mediaFileManager;
        private PersonalInfoManager personalInfoManager;
        private ProductTypeManager productTypeManager;
        private EventManager eventManager;
        private MaterialManager materialManager;

        private Database database;

        public UIMainForm()
        {
            InitializeComponent();

            database = new Database();

            discussionManager = new DiscussionManager(database);
            feedManager = new FeedManager(database);
            logInManager = new LogInManager(database);
            mapManager = new MapManager(database);
            mediaFileManager = new MediaFileManager(database);
            personalInfoManager = new PersonalInfoManager(database);
            productTypeManager = new ProductTypeManager(database);
            eventManager = new EventManager(database);
            materialManager = new MaterialManager(database);

            UI.UILogIn logInScreen = new UI.UILogIn();
            logInScreen.Show();
            logInScreen.TopMost = true;
        }   
        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tcMainForm.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tcMainForm.GetTabRect(e.Index);

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
            MediaType aapje = new MediaType("VIDEOO", 5);
            Post Post = new Post(aapje, naam, description, derp);

            flpPosts.Controls.Add(Post);        
        }

        private void btnMakePost_Click(object sender, EventArgs e)
        {
            Form f = new UI.makePost();
            f.Show();
        }

        //TAB INDEX CHANGER//
        private void tcMainForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!CurrentUser.currentUser.Administrator)
            {
                ((Control)tcMainForm.TabPages[5]).Enabled = false;
                ((Control)tcMainForm.TabPages[6]).Enabled = false;
                ((Control)tcMainForm.TabPages[7]).Enabled = false;
            }
            else
            {
                ((Control)tcMainForm.TabPages[5]).Enabled = true;
                ((Control)tcMainForm.TabPages[6]).Enabled = true;
                ((Control)tcMainForm.TabPages[7]).Enabled = true;
            }

            if (tcMainForm.SelectedIndex == 0)
            {
                
            }
            //verhuur
            if (tcMainForm.SelectedIndex == 1)
            {
                cbMaterialCategory.DataSource = materialManager.getAllMaterial();
            }
            //bestanden
            if (tcMainForm.SelectedIndex == 2)
            {

            }
            //instellingen
            if (tcMainForm.SelectedIndex == 3)
            {
                //  SettingsFillControls(LogInManager.INGELODGE USER)
            }
            //kaart
            if (tcMainForm.SelectedIndex == 4)
            {

            }
            //event beheer//
            if (tcMainForm.SelectedIndex == 5)
            {
                tcMainForm.TabIndex = 1;
                cbEManagementEvents.DataSource = eventManager.getAllEvents();
            }
            //Materiaal beheer
            if (tcMainForm.SelectedIndex == 6)
            {
                
            }
            //Post beheer
            if (tcMainForm.SelectedIndex == 7)
            {
                MessageBox.Show("aapje");
            }

        }

        // FEED //

        //
        private void FeedFill(string search, MediaType type, bool tenMostPopuliar, bool tenNewest)
        {
           // foreach (MediaFile m in feedManager.GivePosts(search, type, tenMostPopuliar, tenNewest))
            {
                // PersonalInfoManager. //GET USER BY RFID m.RFID
                // Post post = new Post()
                // flpPosts.Controls.Add(post);
            }

        }

        //RENTAL STUFF//

        private void FillCategories()
        {
            /* foreach (Category c in //////) 
             {
                 cbMaterialCategory.Items.Add(c);
             }
             * */
        }

        private void cbMaterialCategory_DropDownClosed(object sender, EventArgs e)
        {
            /*  foreach (Material m in equipmentManager.GetMaterialByCategory)
             {
                 cbMaterialProduct.Items.Add(m);
             }
             * */
        }

        private void cbMaterialProduct_DropDownClosed(object sender, EventArgs e)
        {
            /*
            string choosenProduct = cbMaterialProduct.SelectedItem.ToString();
            equipmentManager.Get(choosenProduct)
            ///////LABELS GOED MAKEN
             * */
        }

        private void btnMaterialRent_Click(object sender, EventArgs e)
        {
            // GEEF date 1 en  date 2 mee, evenals ingolgde user, product en alles aan de rental manager ofzo

        }




        // PERSONAL INFO SCREEN //
        //
        //
        /*
        private void SettingsFillControls(User user)
        {
            tbSettingsName.Text = user.Name;
            tbSettingsEmail.Text = user.EmailAdres;
            tbSettingsUsername.Text = user.Username;
            dpBirthDate.Value = user.DateOfBirth;
            lbPersonRentals.Items.Clear();
            pbSettingsPicture.ImageLocation = user.Photo;
            foreach (Equipment e in equipmentManager.getEquipmentFromUser(user))
            {
                lbPersonRentals.Items.Add(e.Material.Name);
            }
        }
        */

        private void btnSettingsEdit_Click(object sender, EventArgs e)
        {
            btnSettingsSave.Enabled = true;
        }

        private void btnSettingsSave_Click(object sender, EventArgs e)
        {
            string email = tbSettingsEmail.Text;
            string name = tbSettingsName.Text;
            string username = tbSettingsUsername.Text;
            DateTime birth = dpBirthDate.Value;

            if (name != null && email.Contains("@") == true && email.Contains(".") == true && username != null && birth < DateTime.Now)
            {
                // PersonalInfoManager.INGELOGDE USER.alle nieuwe values heir 
                // PersonalInfoManager.INGELOGDE USER.alle nieuwe values heir 
                // PersonalInfoManager.INGELOGDE USER.alle nieuwe values heir 
                // 

                btnSettingsSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Gegevens zijn niet geldig");
            }
        }

        // MAP MAP MAP MAP MAP MAP //

        private void searchForPlace(string type, int persons)
        {
            /*
             foreach Location l in MapManager.SearchFor(type,persons)
             {
                 lbMapPlaces.Items.Add(l);
             }
            
             */
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            // lbMapPlaces.SelectedItem. PASS NAAR SpotRental reservation manager
            //check of het mogelijk is en maak reserveer scherm open
            //

         //   Form f = new UI.UIReserve(Convert.ToInt32(nudMapPeople.Value));
         //   f.ShowDialog();

        }

        private void btnMapSearch_Click(object sender, EventArgs e)
        {

        }

        // EVENT BEHEER EVENT BEHEER EVENT BEHEER//
        
    

        private void cbEManagementEvents_DropDownClosed(object sender, EventArgs e)
        {
            Event chosenEvent = (Event)cbEManagementEvents.SelectedItem;
            List<Proftaak_ICT4Events.Location> locations = eventManager.getAllLocations();


            cbEManagementLocation.DataSource = locations;
            int index = locations.FindIndex(l => l.LocationName == chosenEvent.EventLocation.LocationName);
            cbEManagementLocation.SelectedIndex = index;

            tbEManagementNaam.Text = chosenEvent.EventName;
            nudEManagementAantal.Value = Convert.ToDecimal(chosenEvent.AmountParticipants);
            dtpEManagementStart.Value = chosenEvent.StartDate;
            dtpEManagementEnd.Value = chosenEvent.EndDate;
            nudEManagentPercentage.Value = Convert.ToDecimal(chosenEvent.ReportPercentage);

        }

        private void btnEManagementSave_Click(object sender, EventArgs e)
        {
            Event chosenEvent = (Event)cbEManagementEvents.SelectedItem;
            if (!eventManager.editEvent(chosenEvent, 
                                  (Location)cbEManagementLocation.SelectedItem, 
                                  tbEManagementNaam.Text, 
                                  dtpEManagementStart.Value, 
                                  dtpEManagementEnd.Value, 
                                  Convert.ToInt32(nudEManagementAantal.Value), 
                                  Convert.ToInt32(nudEManagentPercentage.Value)))
            {
                MessageBox.Show("Er zijn gegevens niet goed ingevuld.");
            }
           
        }

        private void btnEManagementNew_Click(object sender, EventArgs e)
        {
            btnEManagementNew.Visible = true;
            btnEManagementNew.Enabled = true;
            
            btnEManagementSave.Visible = false;
            btnEManagementSave.Enabled = false;
        }

        private void btnEManagementNewLocation_Click(object sender, EventArgs e)
        {
            Form f = new NewLocation();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                
                List<Proftaak_ICT4Events.Location> locations = eventManager.getAllLocations();
                cbEManagementLocation.DataSource = locations;
                cbEManagementLocation.Refresh();
            }
        }

        private void btnEManagementNewSave_Click(object sender, EventArgs e)
        {
            if (!eventManager.makeEvent((Location)cbEManagementLocation.SelectedItem,
                                  tbEManagementNaam.Text,
                                  dtpEManagementStart.Value,
                                  dtpEManagementEnd.Value,
                                  Convert.ToInt32(nudEManagementAantal.Value),
                                  Convert.ToInt32(nudEManagentPercentage.Value)))
            {
                MessageBox.Show("Er zijn gegevens niet goed ingevuld.");
            }
        }

        private void cbEManagementEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Event chosenEvent = (Event)cbEManagementEvents.SelectedItem;
            List<Location> locations = eventManager.getAllLocations();


            cbEManagementLocation.DataSource = locations;
            int index = locations.FindIndex(l => l.LocationName == chosenEvent.EventLocation.LocationName);
            cbEManagementLocation.SelectedIndex = index;

            tbEManagementNaam.Text = chosenEvent.EventName;
            nudEManagementAantal.Value = Convert.ToDecimal(chosenEvent.AmountParticipants);
            dtpEManagementStart.Value = chosenEvent.StartDate;
            dtpEManagementEnd.Value = chosenEvent.EndDate;
            nudEManagentPercentage.Value = Convert.ToDecimal(chosenEvent.ReportPercentage);
        }
    }
}
