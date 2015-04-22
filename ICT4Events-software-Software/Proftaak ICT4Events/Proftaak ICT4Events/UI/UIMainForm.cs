﻿using System;
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
        //Introducing all the managers to the main form
        private DiscussionManager discussionManager;
        private FeedManager feedManager;
        private MapManager mapManager;
        private MediaFileManager mediaFileManager;
        private PersonalInfoManager personalInfoManager;
        private EventManager eventManager;
        private MaterialManager materialManager;

        //creating a database instance that is used in almost every class
        private Database database;

        //creating an FTPClient for the treeview
        private FTPClient client;

        private ListViewItem selectedSpot = null;
        public UIMainForm()
        {
            InitializeComponent();

            database = new Database();

            //initializing the managers
            discussionManager = new DiscussionManager(database);
            feedManager = new FeedManager(database);
            mapManager = new MapManager(database);
            mediaFileManager = new MediaFileManager(database);
            personalInfoManager = new PersonalInfoManager(database);
            eventManager = new EventManager(database);
            materialManager = new MaterialManager(database);

            //popping up the login screen
            UI.UILogIn logInScreen = new UI.UILogIn();

            client = new FTPClient();
            ReloadTreeView();

            lvAvailableSpots.CheckBoxes = true;
        }


        //Making  sure the form is clean and uses the same font
        private void tcMainForm_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            //Get the item from the collection.
            TabPage _tabPage = tcMainForm.TabPages[e.Index];

            //Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tcMainForm.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                //Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            //Use our own font
            Font _tabFont = new Font("Bebas", (float)20.0, FontStyle.Bold, GraphicsUnit.Pixel);

            //Draw string. Center the text
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private string DecodeException(string ex)
        {
            int start = ex.IndexOf('$') + 1;
            int end = ex.IndexOf('#');
            string error = ex.Substring(start, end - start);
            return error;
        }

        //Reacts to the changing of the tabs inside the application
        #region tab
        private void tcMainForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Checks if the user is an administrator
            //If not it disables some functions that only administrators should be handling
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

            //tab feed
            if (tcMainForm.SelectedIndex == 0)
            {
                FeedFill();
            }

            //tab rental
            if (tcMainForm.SelectedIndex == 1)
            {
                cbMaterialCategory.DataSource = materialManager.getAllCategories();
            }

            //tab files
            if (tcMainForm.SelectedIndex == 2)
            {
                ReloadTreeView();
            }

            //tab settings
            if (tcMainForm.SelectedIndex == 3)
            {
                SettingsFillControls(CurrentUser.currentUser);
            }

            //tab map
            if (tcMainForm.SelectedIndex == 4)
            {
                cbMapType.DataSource = mapManager.GetAllSpotTypes();
            }

            //event management
            if (tcMainForm.SelectedIndex == 5)
            {
                tcMainForm.TabIndex = 1;
                cbEManagementEvents.DataSource = eventManager.getAllEvents();
            }

            //material management
            if (tcMainForm.SelectedIndex == 6)
            {
                cbManagementCatergory.DataSource = MaterialCategory.GetAll(database);
                cbManagementProductAll.DataSource = materialManager.getAll();
                rbManagementProductEdit.Checked = true;
            }
            //Post beheer
            if (tcMainForm.SelectedIndex == 7)
            {
                //not yet implemented
            }

        }
        #endregion

        //feed
        #region feed
        //Creates a post using the feedmanager
        private void btnMakePost_Click_1(object sender, EventArgs e)
        {
            UI.makePost f = new UI.makePost(feedManager.getTypes(database));
            f.ShowDialog();

            if (f.DialogResult == DialogResult.OK)
            {

                feedManager.makePost(f.MediaType, f.Text, f.Path);
                FeedFill();
            }
        }

        //Fills the feed with the correct mediafile
        //This is determined by the user, the example here is latest posts
        private void FeedFill()
        {
            flpPosts.Controls.Clear();
            foreach (MediaFile m in feedManager.GetFiles("latest", database))
            {
                User user = personalInfoManager.GetSpecificUser(m.UserID);
                Post newpost = new Post(m.MediaTypeName, m.Description, m.FilePath, user.Username, user.PhotoPath);
                
                flpPosts.Controls.Add(newpost);
                flpPosts.Refresh();
            }
        }
        #endregion

        //rental
        #region rental
        //Whenever a different category is chosen all the materials of that category are loaded
        private void cbMaterialCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMaterialProduct.DataSource = materialManager.getAllMaterialFromCategory((MaterialCategory)cbMaterialCategory.SelectedItem);
        }

        //When a material is picked it will fill out all the datafields
        //The data used is stored in the object in the combobox
        private void cbMaterialProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Material selectedMaterial = (Material)cbMaterialProduct.SelectedItem;

            lblMaterialProductNameName.Text = selectedMaterial.Name;
            lblMaterialDepositAmount.Text = Convert.ToString(Math.Round(selectedMaterial.Deposit / 100, 2));
            lblMaterialDescriptionValue.Text = selectedMaterial.Description;

            if (selectedMaterial.Amount > 0)
            {
                lblMaterialAvailable.ForeColor = Color.Green;
            }
            else
            {
                lblMaterialAvailable.ForeColor = Color.Red;
            }
        }

        //When the user wants to rent something, a new reservation is added to the database
        //A function in Reservation called Add is used
        private void btnMaterialRent_Click_1(object sender, EventArgs e)
        {
            Material selectedMaterial = (Material)cbMaterialProduct.SelectedItem;

            Reservation newMaterialReservation = new Reservation(CurrentUser.currentUser.propertyRFID, 10, selectedMaterial.MaterialID, dtpRentalStart.Value, dtpRentalEnd.Value, false, selectedMaterial);
            newMaterialReservation.User = CurrentUser.currentUser;

            newMaterialReservation.Add(newMaterialReservation, database);
        }
        #endregion

        //files
        #region files
        //Reloading the treeview
        private void ReloadTreeView()
        {
            tvTree.Nodes.Clear();
            tvTree.Nodes.Add(client.GetTreeNode());
            tvTree.ExpandAll();
        }

        //Creating a folder using a function in the FTPClient class
        private void btnTreeAddFolder_Click(object sender, EventArgs e)
        {
            client.CreateDirectory(tvTree.SelectedNode, tbTreeMap.Text);
            ReloadTreeView();
        }

        //Upload a document using a function in the FTPClient class
        private void btnTreeUpload_Click(object sender, EventArgs e)
        {
            client.UploadFile(tvTree.SelectedNode);
            ReloadTreeView();
        }

        //Download a document using a function in the FTPClient class
        private void btnTreeDownload_Click(object sender, EventArgs e)
        {
            client.DownloadFile(tvTree.SelectedNode);
        }
        #endregion

        //settings
        #region settings
        //The personal data of the user is displayed in the gui
        private void SettingsFillControls(User user)
        {
            tbSettingsName.Text = user.Name;
            tbSettingsEmail.Text = user.EmailAddress;
            tbSettingsUsername.Text = user.Username;
            dpBirthDate.Value = user.DateOfBirth;
            pbSettingsPicture.ImageLocation = user.PhotoPath;
            lbPersonRentals.DataSource = materialManager.getAllMaterialFromUser(CurrentUser.currentUser);
        }

        //not yet implemented
        private void btnSettingsEdit_Click(object sender, EventArgs e)
        {
            btnSettingsSave.Enabled = true;
        }

        //not yet implemented
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
        #endregion

        //map
        #region map
        //Check if the type of spot is changed and update data accordingly
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

            //Creates an item in the listview with all nescessary information
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

        //When the reservation button is pressed a dialog pops up with textboxes
        //These textboxes need to be filled with the information of the people that go with the reservee
        //It uses UIReserve for the form
        private void btnReservation_Click_1(object sender, EventArgs e)
        {
            int temporaryValue = 1;

            Form newForm = new UI.UIReserve((int)nudMapPeople.Value, temporaryValue);
            Spot currentSpot = null;

            foreach (Spot spot in mapManager.GetAllspots())
            {
                if (spot.SpotNumber.ToString() == selectedSpot.Text)
                {
                    currentSpot = spot;
                }
            }

            Form secondNewForm = new UI.UIReserve((int)nudMapPeople.Value, currentSpot.SpotNumber);
            secondNewForm.ShowDialog();

            if (secondNewForm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Done");
            }
        }

        //Determines how many people can go on the trip
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
        #endregion

        //event management
        #region event management
        //When the dropdown is closed, the data from the selected event is put into the form
        //This way the data can be viewed or edited
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

        //The data of the event is saved using the Edit function from the Event class
        //The combobox containing the event is refreshed
        private void btnEManagementSave_Click(object sender, EventArgs e)
        {
            Event chosenEvent = (Event)cbEManagementEvents.SelectedItem;
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(DecodeException(ex.Message));   
            }
        }

        //The button switches between making a new event and editing an old one
        //This way 2 functionalities can be implemented in the same form.
        private void btnEManagementNew_Click(object sender, EventArgs e)
        {
            btnEManagementNewSave.Visible = !btnEManagementNewSave.Visible;
            btnEManagementNewSave.Enabled = !btnEManagementNewSave.Enabled;

            btnEManagementSave.Visible = !btnEManagementSave.Visible;
            btnEManagementSave.Enabled = !btnEManagementSave.Enabled;

            //All data has been reset to basic values
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
            //All data has been reset to values of the first event
            else
            {
                btnEManagementNew.Text = "Nieuw";
                cbEManagementEvents_SelectedIndexChanged(cbEManagementEvents.SelectedItem, EventArgs.Empty);
                cbEManagementEvents.DataSource = eventManager.getAllEvents();
            }
        }

        //This button makes it possible for locations to be added
        //It uses the eventmanager to create it and save it to the database
        //The location combobox will be reset
        private void btnEManagementNewLocation_Click(object sender, EventArgs e)
        {
            Form newForm = new NewLocation();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                
                List<Proftaak_ICT4Events.Location> locations = eventManager.getAllLocations();
                cbEManagementLocation.DataSource = locations;
                cbEManagementLocation.Refresh();
            }
        }

        //The eventmanager is used to try to create a new event
        //If the inputdata is not correct an error will be given
        //The event combobox will be reset
        private void btnEManagementNewSave_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(DecodeException(ex.Message));   
            }
        }

        //When a event is selected all the values will be shown on the form
        //It gives a great overview and makes it easily editable
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
        #endregion

        //material management
        #region material management
        //If the button to create a new category is clicked, the value from the combobox will make a new category
        //The category combobox will be reset
        private void btnManagementNewCategorie_Click(object sender, EventArgs e)
        {
            MaterialCategory newMaterialCategory  = new MaterialCategory(cbManagementCatergory.Text, 1);
            newMaterialCategory.Add(newMaterialCategory, database);

            cbManagementCatergory.DataSource = MaterialCategory.GetAll(database);
        }

        //If the selected material is changed, the form will be filled with the material data
        //This gives an overview of all variables and makes it editable
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

        //When the radiobutton "Verwijderen" is selected, the form gets ready to delete the selected material
        private void rbManagementProductDelete_CheckedChanged(object sender, EventArgs e)
        {
            cbManagementCatergory.DataSource = MaterialCategory.GetAll(database);
            cbManagementProductAll.DataSource = materialManager.getAll();

            btnManagementProductSelect.Text = "Verwijderen";
        }

        //When the radiobutton "Nieuw Product" is selected, the form gets ready to create a new material
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

        //When the radiobutton "Product aanpassen" is selected, the form gets ready to edit a selected material
        private void rbManagementProductEdit_CheckedChanged(object sender, EventArgs e)
        {
            cbManagementCatergory.DataSource = MaterialCategory.GetAll(database);
            cbManagementProductAll.DataSource = materialManager.getAll();

            btnManagementProductSelect.Text = "Aanpassen";
        }

        //The button has different functions depending on what radiobutton was selected
        private void btnManagementProductSelect_Click(object sender, EventArgs e)
        {
            if(rbManagementProductEdit.Checked)
            {
                //This will make the material update the database with it's current values using the Edit function in Material
                //All the materials will be refreshed
                Material editMaterial = new Material(tbManagementProductName.Text, tbManagementDescription.Text, tbManagementProductphotoPath.Text, ((Material)cbManagementProductAll.SelectedItem).MaterialID, Convert.ToInt32(nudManagementProductAmount.Value), Convert.ToDecimal(nudManagementProductDeposit.Value * 100), (MaterialCategory)cbManagementCatergory.SelectedItem);
                editMaterial.Edit(editMaterial, database);
                cbManagementProductAll.DataSource = materialManager.getAll();
                cbManagementProductAll_SelectedIndexChanged(cbManagementProductAll, EventArgs.Empty);
            }
            else if(rbManagementProductDelete.Checked)
            {
                //This will remove the selected material from the database using the Remove function in Material
                //All the materials will be refreshed
                Material removeMaterial = new Material(tbManagementProductName.Text, tbManagementDescription.Text, tbManagementProductphotoPath.Text, ((Material)cbManagementProductAll.SelectedItem).MaterialID, Convert.ToInt32(nudManagementProductAmount.Value), Convert.ToDecimal(nudManagementProductDeposit.Value), (MaterialCategory)cbManagementCatergory.SelectedItem);
                removeMaterial.Remove(removeMaterial, database);
                cbManagementProductAll.DataSource = materialManager.getAll();
                cbManagementProductAll_SelectedIndexChanged(cbManagementProductAll, EventArgs.Empty);
            }
            else
            {
                //This will add a new material to the database using the Add function in Material
                //All the materials will be refreshed
                Material newMaterial = new Material(tbManagementProductName.Text, tbManagementDescription.Text, tbManagementProductphotoPath.Text, ((Material)cbManagementProductAll.SelectedItem).MaterialID, Convert.ToInt32(nudManagementProductAmount.Value), Convert.ToDecimal(nudManagementProductDeposit.Value), (MaterialCategory)cbManagementCatergory.SelectedItem);
                newMaterial.Add(newMaterial, database);
                cbManagementProductAll.DataSource = materialManager.getAll();
                cbManagementProductAll_SelectedIndexChanged(cbManagementProductAll, EventArgs.Empty);
            }
        }
        #endregion
    }
}
