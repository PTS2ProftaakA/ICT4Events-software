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
        private MapManager mapManager;
        private MediaFileManager mediaFileManager;
        private PersonalInfoManager personalInfoManager;
        private ProductTypeManager productTypeManager;
        private EventManager eventManager;
        private MaterialManager materialManager;

        private Database database;

        private FTPClient client;

        private ListViewItem selectedSpot = null;
        public UIMainForm()
        {
            InitializeComponent();

            database = new Database();

            discussionManager = new DiscussionManager(database);
            feedManager = new FeedManager(database);
            mapManager = new MapManager(database);
            mediaFileManager = new MediaFileManager(database);
            personalInfoManager = new PersonalInfoManager(database);
            productTypeManager = new ProductTypeManager(database);
            eventManager = new EventManager(database);
            materialManager = new MaterialManager(database);

            UI.UILogIn logInScreen = new UI.UILogIn();

            client = new FTPClient();
            ReloadTreeView();

            lvAvailableSpots.CheckBoxes = true;
        }

        private void ReloadTreeView()
        {
            tvTree.Nodes.Clear();
            tvTree.Nodes.Add(client.GetTreeNode());
            tvTree.ExpandAll();
        }

        private void btnTreeAddFolder_Click(object sender, EventArgs e)
        {
            client.CreateDirectory(tvTree.SelectedNode, tbTreeMap.Text);
            ReloadTreeView();
        }

        private void btnTreeUpload_Click(object sender, EventArgs e)
        {
            client.UploadFile(tvTree.SelectedNode);
            ReloadTreeView();
        }

        private void btnTreeDownload_Click(object sender, EventArgs e)
        {
            client.DownloadFile(tvTree.SelectedNode);
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
                cbMaterialCategory.DataSource = materialManager.getAllCategories();
            }
            //bestanden
            if (tcMainForm.SelectedIndex == 2)
            {

            }
            //instellingen
            if (tcMainForm.SelectedIndex == 3)
            {
                SettingsFillControls(CurrentUser.currentUser);
            }
            //kaart
            if (tcMainForm.SelectedIndex == 4)
            {
                cbMapType.DataSource = mapManager.GetAllSpotTypes();
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
                cbManagementCatergory.DataSource = MaterialCategory.GetAll(database);
                cbManagementProductAll.DataSource = materialManager.getAll();
                rbManagementProductEdit.Checked = true;
            }
            //Post beheer
            if (tcMainForm.SelectedIndex == 7)
            {
                MessageBox.Show("aapje");
            }

        }

        // FEED //

        //
        private void btnMakePost_Click_1(object sender, EventArgs e)
        {
            UI.makePost f = new UI.makePost(feedManager.getTypes(database));
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                feedManager.makePost(f.MediaType, f.Text, f.Path);


            }
        }
        private void FeedFill(string search, MediaType type, bool tenMostPopuliar, bool tenNewest)
        {
            foreach (MediaFile m in feedManager.GetFiles("latest", database))
            {
                User user = personalInfoManager.GetSpecificUser(m.PropertyRFID);
                Post newpost = new Post(m.MediaTypeName, m.Description, m.FilePath, user.Username, user.PhotoPath);
            }

        }

        private void btnMakePost_Click(object sender, EventArgs e)
        {
            
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

        private void SettingsFillControls(User user)
        {
            tbSettingsName.Text = user.Name;
            tbSettingsEmail.Text = user.EmailAddress;
            tbSettingsUsername.Text = user.Username;
            dpBirthDate.Value = user.DateOfBirth;
            pbSettingsPicture.ImageLocation = user.PhotoPath;
            lbPersonRentals.DataSource = materialManager.getAllMaterialFromUser(CurrentUser.currentUser);
        }
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
                //personalInfoManager.SaveUser(CurrentUser.currentUser, name, email, username, birth);
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

            cbEManagementEvents.DataSource = eventManager.getAllEvents();
        }

        private void btnEManagementNew_Click(object sender, EventArgs e)
        {
            btnEManagementNewSave.Visible = !btnEManagementNewSave.Visible;
            btnEManagementNewSave.Enabled = !btnEManagementNewSave.Enabled;

            btnEManagementSave.Visible = !btnEManagementSave.Visible;
            btnEManagementSave.Enabled = !btnEManagementSave.Enabled;

            if(btnEManagementNew.Text == "Nieuw")
            {
                btnEManagementNew.Text = "Annuleer";
                tbEManagementNaam.Text = "";
                cbEManagementLocation.Text = "";
                nudEManagementAantal.Value = 0;
                dtpEManagementStart.Value = DateTime.Now;
                dtpEManagementEnd.Value = DateTime.Now;
                nudEManagentPercentage.Value = 0;
            }
            else
            {
                btnEManagementNew.Text = "Nieuw";
                cbEManagementEvents_SelectedIndexChanged(cbEManagementEvents.SelectedItem, EventArgs.Empty);
                cbEManagementEvents.DataSource = eventManager.getAllEvents();
            }
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

            btnEManagementNew_Click(btnEManagementNew, EventArgs.Empty);
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

        private void cbMaterialCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMaterialProduct.DataSource = materialManager.getAllMaterialFromCategory((MaterialCategory)cbMaterialCategory.SelectedItem);
        }

        private void cbMaterialProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Material selectedMaterial = (Material)cbMaterialProduct.SelectedItem;

            lblMaterialProductNameName.Text = selectedMaterial.Name;
            lblMaterialDepositAmount.Text = Convert.ToString(Math.Round(selectedMaterial.Deposit/100, 2));
            lblMaterialDescriptionValue.Text = selectedMaterial.Description;

            if(selectedMaterial.Amount > 0)
            {
                lblMaterialAvailable.ForeColor = Color.Green;
            }
            else
            {
                lblMaterialAvailable.ForeColor = Color.Red;
            }
        }

        private void btnMaterialRent_Click_1(object sender, EventArgs e)
        {
            Material selectedMaterial = (Material)cbMaterialProduct.SelectedItem;

            Reservation newMaterialReservation = new Reservation(CurrentUser.currentUser.propertyRFID, 10, selectedMaterial.MaterialID, dtpRentalStart.Value, dtpRentalEnd.Value, false, selectedMaterial);

            newMaterialReservation.Add(newMaterialReservation, database);
        }

        private void cbMapType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvAvailableSpots.Columns.Clear();
            lvAvailableSpots.Items.Clear();
            lvAvailableSpots.View = View.Details;

            lvAvailableSpots.Columns.Add("Plaatsnummer");
            lvAvailableSpots.Columns.Add("Plaatstype");
            lvAvailableSpots.Columns.Add("Aantal personen");
            lvAvailableSpots.Columns.Add("Prijs");

            List<ListViewItem> listviewitems = new List<ListViewItem>();

            SpotType spotType = (SpotType)cbMapType.SelectedValue;

            foreach (Spot spot in mapManager.SearchAllSpots(spotType))
            {
                ListViewItem item = new ListViewItem(spot.SpotNumber.ToString());
                item.SubItems.Add(spot.SpotSpotType.SpotTypeName);
                item.SubItems.Add(spot.SpotSpotType.AmountOfPersons.ToString());
                item.SubItems.Add(Convert.ToDouble(spot.Price / 100).ToString());
                listviewitems.Add(item);
            }
            foreach (ListViewItem item in listviewitems)
            {
                lvAvailableSpots.Items.Add(item);
            }
        }

        private void btnReservation_Click_1(object sender, EventArgs e)
        {
            Spot s = null;
            foreach (Spot spot in mapManager.GetAllspots())
            {
                if (spot.SpotNumber.ToString() == selectedSpot.Text)
                {
                    s = spot;
                }
            }
            Form f = new UI.UIReserve((int)nudMapPeople.Value, s.SpotNumber);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Done");
            }
        }

        private void lvAvailableSpots_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            {
                if (selectedSpot != null)
                {
                    selectedSpot.Checked = false;
                }
                selectedSpot = e.Item;


                foreach (Spot spot in mapManager.GetAllspots())
                {
                    if (spot.SpotNumber.ToString() == selectedSpot.Text)
                    {
                        nudMapPeople.Minimum = 1;
                        nudMapPeople.Maximum = spot.SpotSpotType.AmountOfPersons;
                        nudMapPeople.Value = spot.SpotSpotType.AmountOfPersons;
                    }
                }
            }
        }

        private void btnManagementNewCategorie_Click(object sender, EventArgs e)
        {
            MaterialCategory newMaterialCategory  = new MaterialCategory(cbManagementCatergory.Text, 1);
            newMaterialCategory.Add(newMaterialCategory, database);

            cbManagementCatergory.DataSource = MaterialCategory.GetAll(database);
        }

        private void cbManagementProductAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            Material selectedMaterial = (Material)cbManagementProductAll.SelectedItem;

            tbManagementProductName.Text = selectedMaterial.Name;
            nudManagementProductAmount.Value = selectedMaterial.Amount;
            nudManagementProductDeposit.Value = Math.Round(selectedMaterial.Deposit/100, 2);
            cbManagementCatergory.SelectedIndex = selectedMaterial.MaterialCategoryName.MaterialCategoryID - 1;
            tbManagementDescription.Text = selectedMaterial.Description;
            tbManagementProductphotoPath.Text = selectedMaterial.PhotoPath;

            pbProductList.ImageLocation = selectedMaterial.PhotoPath;
        }

        private void rbManagementProductDelete_CheckedChanged(object sender, EventArgs e)
        {
            cbManagementCatergory.DataSource = MaterialCategory.GetAll(database);
            cbManagementProductAll.DataSource = materialManager.getAll();

            btnManagementProductSelect.Text = "Verwijderen";
        }

        private void rbManagementProductNew_CheckedChanged(object sender, EventArgs e)
        {
            tbManagementProductName.Text = "";
            tbManagementDescription.Text = "";
            tbManagementProductphotoPath.Text = "";
            cbManagementProductAll.Text = "";
            nudManagementProductAmount.Value = 0;
            nudManagementProductDeposit.Value = 0;
            

            pbProductList.ImageLocation = "";

            btnManagementProductSelect.Text = "Opslaan";
        }

        private void rbManagementProductEdit_CheckedChanged(object sender, EventArgs e)
        {
            cbManagementCatergory.DataSource = MaterialCategory.GetAll(database);
            cbManagementProductAll.DataSource = materialManager.getAll();

            btnManagementProductSelect.Text = "Aanpassen";
        }

        private void btnManagementProductSelect_Click(object sender, EventArgs e)
        {
            if(rbManagementProductEdit.Checked)
            {
                Material editMaterial = new Material(tbManagementProductName.Text, tbManagementDescription.Text, tbManagementProductphotoPath.Text, ((Material)cbManagementProductAll.SelectedItem).MaterialID, Convert.ToInt32(nudManagementProductAmount.Value), Convert.ToDecimal(nudManagementProductDeposit.Value * 100), (MaterialCategory)cbManagementCatergory.SelectedItem);
                editMaterial.Edit(editMaterial, database);
                cbManagementProductAll.DataSource = materialManager.getAll();
                cbManagementProductAll_SelectedIndexChanged(cbManagementProductAll, EventArgs.Empty);
            }
            else if(rbManagementProductDelete.Checked)
            { 
                Material removeMaterial = new Material(tbManagementProductName.Text, tbManagementDescription.Text, tbManagementProductphotoPath.Text, ((Material)cbManagementProductAll.SelectedItem).MaterialID, Convert.ToInt32(nudManagementProductAmount.Value), Convert.ToDecimal(nudManagementProductDeposit.Value), (MaterialCategory)cbManagementCatergory.SelectedItem);
                removeMaterial.Remove(removeMaterial, database);
                cbManagementProductAll.DataSource = materialManager.getAll();
                cbManagementProductAll_SelectedIndexChanged(cbManagementProductAll, EventArgs.Empty);
            }
            else
            {
                Material newMaterial = new Material(tbManagementProductName.Text, tbManagementDescription.Text, tbManagementProductphotoPath.Text, ((Material)cbManagementProductAll.SelectedItem).MaterialID, Convert.ToInt32(nudManagementProductAmount.Value), Convert.ToDecimal(nudManagementProductDeposit.Value), (MaterialCategory)cbManagementCatergory.SelectedItem);
                newMaterial.Add(newMaterial, database);
                cbManagementProductAll.DataSource = materialManager.getAll();
                cbManagementProductAll_SelectedIndexChanged(cbManagementProductAll, EventArgs.Empty);
            }
        }
    }
}
