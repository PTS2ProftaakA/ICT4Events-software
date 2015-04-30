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

            client = new FTPClient(database);
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

        //This method is used to decode errors from the database
        private string DecodeException(string ex)
        {
            string error = ex;
            if (ex.Contains("$") && ex.Contains("#"))
            {
                int start = ex.IndexOf('$') + 1;
                int end = ex.IndexOf('#');
                error = ex.Substring(start, end - start);
            }
            else if (ex.StartsWith("Object"))
            {
                error = "Er is iets niet goed ingevult.";
            }
            else if (ex.StartsWith("ORA-02290"))
            {
                error = "Als administator kunt u geen plaats reserveren.";
            }
            else if (ex.StartsWith("ORA-00001"))
            {
                error = "Deze gebruikersnaam is al in gebruik. \nProbeer een andere gebruikersnaam.";
            }
            return error;
        }

        //Makes sure the user logs out when the form is closed
        private void UIMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CurrentUser.currentUser.SetLogIn("N", CurrentUser.currentUser.UserID, database);
        }

        //Makes the user delete his account if he has not paid for the event
        private void btnSettingsUnsubscribe_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Weet je zeker dat je je wilt afmelden voor dit event? \nAl de mensen waarvoor je gereserveerd hebt zullen ook hun account verliezen.", "Important Question", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes && (lblSettingPaid.ForeColor == Color.Red || !lblSettingPaid.Visible))
            {
                try
                {
                    CurrentUser.currentUser.Remove(CurrentUser.currentUser, database);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (result == DialogResult.Yes)
            {
                MessageBox.Show("Je hebt al betaald voor dit event, je kan je niet meer op deze manier afmelden");
            }
        }

        //Reacts to the changing of the tabs inside the application
        #region tab
        private void tcMainForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Checks if the user is an administrator
            //If not it disables some functions that only administrators should be handling
            if (!CurrentUser.currentUser.Administrator)
            {
                ((Control)tcMainForm.TabPages[5]).Enabled = false;
                ((Control)tcMainForm.TabPages[6]).Enabled = false;
                ((Control)tcMainForm.TabPages[7]).Enabled = false;
                ((Control)tcMainForm.TabPages[4]).Enabled = true;
            }
            else
            {
                ((Control)tcMainForm.TabPages[5]).Enabled = true;
                ((Control)tcMainForm.TabPages[6]).Enabled = true;
                ((Control)tcMainForm.TabPages[7]).Enabled = true;
                ((Control)tcMainForm.TabPages[4]).Enabled = false;
            }

            //tab feed
            if (tcMainForm.SelectedIndex == 0)
            {
                FeedFill();
            }

            //tab rental
            else if (tcMainForm.SelectedIndex == 1)
            {
                cbMaterialCategory.DataSource = materialManager.getAllCategories();
            }

            //tab files
            else if (tcMainForm.SelectedIndex == 2)
            {
                ReloadTreeView();
            }

            //tab settings
            else if (tcMainForm.SelectedIndex == 3)
            {
                SettingsFillControls(CurrentUser.currentUser);
            }

            //tab map
            else if (tcMainForm.SelectedIndex == 4)
            {
                cbMapType.DataSource = mapManager.GetAllSpotTypes();
            }

            //event management
            else if (tcMainForm.SelectedIndex == 5)
            {
                tcMainForm.TabIndex = 1;
                cbEManagementEvents.DataSource = eventManager.getAllEvents();
            }

            //material management
            else if (tcMainForm.SelectedIndex == 6)
            {
                cbManagementCatergory.DataSource = MaterialCategory.GetAll(database);
                cbManagementProductAll.DataSource = materialManager.getAll();
                rbManagementProductEdit.Checked = true;
            }
            //Post beheer
            else if (tcMainForm.SelectedIndex == 7)
            {
                if (CurrentUser.currentUser.Administrator)
                {
                    FillReportedFeed();
                }
            }

        }
        #endregion

        //feed
        #region feed
        //Creates a post using the feedmanager
        private void btnMakePost_Click_1(object sender, EventArgs e)
        {
            try
            {
                UI.makePost f = new UI.makePost(feedManager.getTypes(database), database);
                f.ShowDialog();

                if (f.DialogResult == DialogResult.OK)
                {

                    feedManager.makePost(f.MediaType, f.Text, f.UploadString);
                    FeedFill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(DecodeException(ex.Message));
            }
        }

        //Fills the feed with the correct mediafile
        //This is determined by the user, the example here is latest posts
        private void FeedFill()
        {
            flpPosts.Controls.Clear();

            string query;

            if (rbtnTenMostPopulair.Checked)
            {
                query = "SELECT * FROM (SELECT M1.MEDIABESTANDID, M1.BESTANDLOCATIE, M1.EVENEMENTID, M1.GEBRUIKERID, M1.BESTANDTYPE, M1.OPMERKING, M1.UPLOADDATUM FROM MEDIABESTAND M1, (SELECT M2.BESTANDLOCATIE, COUNT(O.OORDEELID) LIKES FROM MEDIABESTAND M2, OORDEEL O WHERE  O.POSITIEF = 'Y' AND O.BESTANDLOCATIE = M2.BESTANDLOCATIE GROUP BY M2.BESTANDLOCATIE) L WHERE L.BESTANDLOCATIE = M1.BESTANDLOCATIE ORDER BY L.LIKES DESC,M1.BESTANDLOCATIE DESC) TOP10 WHERE ROWNUM <= 10";

                if (cbFeedFileTypes.SelectedIndex != 0)
                {
                    switch (cbFeedFileTypes.Text.ToUpper())
                    {
                        case "VIDEO":
                            query += " AND TOP10.BESTANDTYPE = (SELECT MEDIATYPEID FROM MEDIATYPE WHERE TYPE = 'Video')";
                            break;
                        case "FOTO":
                            query += " AND TOP10.BESTANDTYPE = (SELECT MEDIATYPEID FROM MEDIATYPE WHERE TYPE = 'Afbeelding')";
                            break;
                        case "TEKST":
                            query += " AND TOP10.BESTANDTYPE = (SELECT MEDIATYPEID FROM MEDIATYPE WHERE TYPE = 'Tekst')";
                            break;
                    }
                }

                if (!tbFeedSearch.Text.Equals(String.Empty))
                {
                    query += " AND TOP10.OPMERKING LIKE '%" + tbFeedSearch.Text + "%'";
                }
            }
            else
            {
                query = "SELECT * FROM (SELECT * FROM MEDIABESTAND ORDER BY UPLOADDATUM DESC) WHERE ROWNUM <= 10";

                if (cbFeedFileTypes.SelectedIndex != 0)
                {
                    switch (cbFeedFileTypes.Text.ToUpper())
                    {
                        case "VIDEO":
                            query += " AND BESTANDTYPE = (SELECT MEDIATYPEID FROM MEDIATYPE WHERE TYPE = 'Video')";
                            break;
                        case "FOTO":
                            query += " AND BESTANDTYPE = (SELECT MEDIATYPEID FROM MEDIATYPE WHERE TYPE = 'Afbeelding')";
                            break;
                        case "TEKST":
                            query += " AND BESTANDTYPE = (SELECT MEDIATYPEID FROM MEDIATYPE WHERE TYPE = 'Tekst')";
                            break;
                    }
                }

                if (!tbFeedSearch.Text.Equals(String.Empty))
                {
                    query += " AND OPMERKING LIKE '%" + tbFeedSearch.Text + "%'";
                }
            }

            foreach (MediaFile m in feedManager.GetFiles(query, database))
            {
                User user = personalInfoManager.GetSpecificUser(m.UserID);
                Post newpost = new Post(m, user, database);

                flpPosts.Controls.Add(newpost);
                flpPosts.Refresh();
            }
        }

        private void btnFeedZoek_Click_1(object sender, EventArgs e)
        {
            try
            {
                FeedFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(DecodeException(ex.Message));
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
        private void btnMaterialRent_Click(object sender, EventArgs e)
        {
            Material selectedMaterial = (Material)cbMaterialProduct.SelectedItem;

            try
            {
                if (selectedMaterial.Amount > 0)
                {
                    Reservation newMaterialReservation = new Reservation(CurrentUser.currentUser.UserID, 10, selectedMaterial.MaterialID, dtpRentalStart.Value, dtpRentalEnd.Value, false, selectedMaterial);
                    newMaterialReservation.User = CurrentUser.currentUser;

                    newMaterialReservation.Add(newMaterialReservation, database);

                    selectedMaterial.Amount--;
                    selectedMaterial.Edit(selectedMaterial, database);

                    MessageBox.Show("Het geselecteerde product is voor je gereserveerd");
                }
                else
                {
                    MessageBox.Show("Dit product is helaas niet meer beschikbaar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(DecodeException(ex.Message));
            }
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
            tbSettingsPhoneNumber.Text = user.PhoneNumber;
            tbSettingsPhotoPath.Text = user.PhotoPath;
            dpBirthDate.Value = user.DateOfBirth;
            pbSettingsPicture.ImageLocation = user.PhotoPath;

            Reservation userReservation = new Reservation();
            userReservation = userReservation.GetSpotReservation(user.UserID, database);

            if (userReservation != null)
            {
                lblSettingPaid.Visible = true;

                if (userReservation.IsPayed)
                {
                    lblSettingPaid.Text = "Betaald";
                    lblSettingPaid.ForeColor = Color.Green;
                }
                else
                {
                    lblSettingPaid.Text = "Niet betaald";
                    lblSettingPaid.ForeColor = Color.Red;
                }
            }

            List<Reservation> rentedMaterials = materialManager.getAllMaterialFromUser(CurrentUser.currentUser);

            lvPersonalRental.Columns.Clear();
            lvPersonalRental.Items.Clear();
            lvPersonalRental.View = View.Details;

            lvPersonalRental.Columns.Add("Materiaal");
            lvPersonalRental.Columns.Add("Startdatum");
            lvPersonalRental.Columns.Add("Einddatum");

            lvPersonalRental.Columns[0].Width = 180;
            lvPersonalRental.Columns[1].Width = 90;
            lvPersonalRental.Columns[2].Width = 90;

            List<ListViewItem> listviewitems = new List<ListViewItem>();

            foreach (Reservation reservation in rentedMaterials)
            {
                ListViewItem item = new ListViewItem(reservation.Material.Name);
                item.SubItems.Add(Convert.ToString(reservation.StartDate.ToString("dd/MM/yyyy")));
                item.SubItems.Add(Convert.ToString(reservation.EndDate.ToString("dd/MM/yyyy")));

                lvPersonalRental.Items.Add(item);
            }
        }


        //Saves the setting updated by the user in the database
        private void btnSettingsSave_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbSettingsEmail.Text;
                string name = tbSettingsName.Text;
                string userName = tbSettingsUsername.Text;
                string phoneNumber = tbSettingsPhoneNumber.Text;
                string photoPath = tbSettingsPhotoPath.Text;
                DateTime birth = dpBirthDate.Value;

                int outInt;


                if (name != null && email.Contains("@") && email.Contains(".") && userName != null && birth < DateTime.Now && int.TryParse(phoneNumber, out outInt) && phoneNumber.Length >= 8)
                {
                    DialogResult result = MessageBox.Show("Weet je zeker dat je je peroonlijke gegevens aan wilt passen? \n De volgende keer zal je met je eventueel aangepaste username moeten inloggen.", "Important Question", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        CurrentUser.currentUser.Name = name;
                        CurrentUser.currentUser.EmailAddress = email;
                        CurrentUser.currentUser.DateOfBirth = birth;
                        CurrentUser.currentUser.PhoneNumber = phoneNumber;
                        CurrentUser.currentUser.Username = userName;
                        CurrentUser.currentUser.PhotoPath = photoPath;

                        CurrentUser.currentUser.Edit(CurrentUser.currentUser, database);

                        SettingsFillControls(CurrentUser.currentUser);
                    }
                }
                else
                {
                    MessageBox.Show("Gegevens zijn niet correct ingevuld");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("ORA-00001"))
                {
                    MessageBox.Show(DecodeException(ex.Message));
                }
            }
        }

        //This button is used for changing the photo of the user
        private void btnSettingsChangePhotoPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            tbSettingsPhotoPath.Text = fileDialog.FileName;
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

            Reservation userReservation = new Reservation();
            userReservation = userReservation.GetSpotReservation(CurrentUser.currentUser.UserID, database);

            if (userReservation == null)
            {
                lvAvailableSpots.Columns.Add("Plaatsnummer");
                lvAvailableSpots.Columns.Add("Plaatstype");
                lvAvailableSpots.Columns.Add("Aantal personen");
                lvAvailableSpots.Columns.Add("Prijs");

                List<ListViewItem> listviewitems = new List<ListViewItem>();

                SpotType spotType = (SpotType)cbMapType.SelectedValue;

                //Creates an item in the listview with all nescessary information
                foreach (Spot spot in mapManager.SearchAllAvailableSpots(spotType))
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

                lvAvailableSpots.Items[0].Checked = true;
            }
            else
            {
                lblMapInfo.Visible = false;
                lblMapMax.Visible = false;
                lblMapTypePlace.Visible = false;

                cbMapType.Visible = false;
                nudMapPeople.Visible = false;
                btnReservation.Visible = false;

                lvAvailableSpots.CheckBoxes = false;

                lvAvailableSpots.Columns.Add("Plaatsnummer");
                lvAvailableSpots.Columns.Add("Naam");

                lvAvailableSpots.Columns[0].Width = 90;
                lvAvailableSpots.Columns[1].Width = 195;

                List<ListViewItem> listviewitems = new List<ListViewItem>();

                ListViewItem item = new ListViewItem(Convert.ToString(CurrentUser.currentUser.SpotNumber));
                item.SubItems.Add(CurrentUser.currentUser.Name);

                lvAvailableSpots.Items.Add(item);

                foreach (User user in User.getAllFromReservee(CurrentUser.currentUser, database))
                {
                    item = new ListViewItem(Convert.ToString(user.SpotNumber));
                    item.SubItems.Add(user.Name);

                    lvAvailableSpots.Items.Add(item);
                }
            }
        }

        //When the reservation button is pressed a dialog pops up with textboxes
        //These textboxes need to be filled with the information of the people that go with the reservee
        //It uses UIReserve for the form
        private void btnReservation_Click(object sender, EventArgs e)
        {
            Spot currentSpot = null;

            foreach (Spot spot in mapManager.GetAllspots())
            {
                if (spot.SpotNumber.ToString() == selectedSpot.Text)
                {
                    currentSpot = spot;
                }
            }

            CurrentUser.currentUser.SpotNumber = currentSpot.SpotNumber;
            CurrentUser.currentUser.Edit(CurrentUser.currentUser, database);
            Form secondNewForm = new UI.UIReserve((int)nudMapPeople.Value + 1, currentSpot);

            secondNewForm.ShowDialog();

            cbMapType_SelectedIndexChanged(lvAvailableSpots, EventArgs.Empty);
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
                        nudMapPeople.Minimum = 0;
                        nudMapPeople.Maximum = spot.SpotSpotType.AmountOfPersons - 1;
                        nudMapPeople.Value = spot.SpotSpotType.AmountOfPersons - 1;
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
            if (btnEManagementNew.Text == "Nieuw")
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(DecodeException(ex.Message));
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

        private void btnEManagementLoggedUsers_Click(object sender, EventArgs e)
        {
            try
            {
                lbEManagementLoggedUsers.DataSource = eventManager.loggedInUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(DecodeException(ex.Message));
            }
        }
        //Button for the deletion of an event
        private void btnEManagerDelete_Click(object sender, EventArgs e)
        {
            Event chosenEvent = (Event)cbEManagementEvents.SelectedItem;

            DialogResult result = MessageBox.Show("Weet je zeker dat je dit evenement wilt verwijderen? \nAlle gebruikers op dit evenement zullen verwijderd worden", "Important Question", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    chosenEvent.Remove(chosenEvent, database);
                    cbEManagementEvents.DataSource = eventManager.getAllEvents();
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(DecodeException(ex.Message));
                }
            }
        }

        //Button for the deletion of a location
        private void btnEManagementDeleteLocation_Click(object sender, EventArgs e)
        {
            Location chosenLocation = (Location)cbEManagementLocation.SelectedItem;

            DialogResult result = MessageBox.Show("Weet je zeker dat je deze locatie wilt verwijderen? \nAlle evenementen op deze locatie zullen verwijderd worden", "Important Question", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    chosenLocation.Remove(chosenLocation, database);
                    cbEManagementLocation.DataSource = eventManager.getAllLocations();
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(DecodeException(ex.Message));
                }
            }
        }
        #endregion

        //material management
        #region material management
        //If the button to create a new category is clicked, the value from the combobox will make a new category
        //The category combobox will be reset
        private void btnManagementNewCategorie_Click(object sender, EventArgs e)
        {
            try
            {
                MaterialCategory newMaterialCategory = new MaterialCategory(cbManagementCatergory.Text, 1);
                newMaterialCategory.Add(newMaterialCategory, database);

                cbManagementCatergory.DataSource = MaterialCategory.GetAll(database);
            }
            catch (Exception ex)
            {
                MessageBox.Show(DecodeException(ex.Message));
            }
        }

        //If the selected material is changed, the form will be filled with the material data
        //This gives an overview of all variables and makes it editable
        private void cbManagementProductAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            Material selectedMaterial = (Material)cbManagementProductAll.SelectedItem;

            tbManagementProductName.Text = selectedMaterial.Name;
            nudManagementProductAmount.Value = selectedMaterial.Amount;
            nudManagementProductDeposit.Value = Math.Round(selectedMaterial.Deposit / 100, 2);
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
            try
            {
                if (rbManagementProductEdit.Checked)
                {
                    //This will make the material update the database with it's current values using the Edit function in Material
                    //All the materials will be refreshed
                    Material editMaterial = new Material(tbManagementProductName.Text, tbManagementDescription.Text, tbManagementProductphotoPath.Text, ((Material)cbManagementProductAll.SelectedItem).MaterialID, Convert.ToInt32(nudManagementProductAmount.Value), Convert.ToDecimal(nudManagementProductDeposit.Value * 100), (MaterialCategory)cbManagementCatergory.SelectedItem);
                    editMaterial.Edit(editMaterial, database);
                    cbManagementProductAll.DataSource = materialManager.getAll();
                    cbManagementProductAll_SelectedIndexChanged(cbManagementProductAll, EventArgs.Empty);
                }
                else if (rbManagementProductDelete.Checked)
                {
                    DialogResult result = MessageBox.Show("Alle reserveringen van dit materiaal zullen ook worden verwijderd, wilt u doorgaan?", "Important Question", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        //This will remove the selected material from the database using the Remove function in Material
                        //All the materials will be refreshed
                        Material removeMaterial = new Material(tbManagementProductName.Text, tbManagementDescription.Text, tbManagementProductphotoPath.Text, ((Material)cbManagementProductAll.SelectedItem).MaterialID, Convert.ToInt32(nudManagementProductAmount.Value), Convert.ToDecimal(nudManagementProductDeposit.Value), (MaterialCategory)cbManagementCatergory.SelectedItem);
                        removeMaterial.Remove(removeMaterial, database);
                        cbManagementProductAll.DataSource = materialManager.getAll();
                        cbManagementProductAll_SelectedIndexChanged(cbManagementProductAll, EventArgs.Empty);
                    }
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
            catch (Exception ex)
            {
                MessageBox.Show(DecodeException(ex.Message));
            }
        }
        #endregion

        //mediafile management
        #region mediafile management

        private void FillReportedFeed()
        {
            cbReportedPostsEvents.DataSource = eventManager.getAllEvents();

            cbReportedPostsEvents_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void cbReportedPostsEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Event selectedEvent = (Event)cbReportedPostsEvents.SelectedItem;

            lvReportedPosts.Columns.Clear();
            lvReportedPosts.Items.Clear();
            lvReportedPosts.View = View.Details;

            lvReportedPosts.Columns.Add("Mediabestand ID");
            lvReportedPosts.Columns.Add("MediaType");
            lvReportedPosts.Columns.Add("Beschrijving");
            lvReportedPosts.Columns.Add("Percentage");

            lvReportedPosts.Columns[0].Width = 110;
            lvReportedPosts.Columns[1].Width = 70;
            lvReportedPosts.Columns[2].Width = 145;
            lvReportedPosts.Columns[3].Width = 70;

            List<ListViewItem> listviewitems = new List<ListViewItem>();


            foreach (MediaFile mediaFile in feedManager.GetReportedFiles(selectedEvent.ReportPercentage, selectedEvent.EventID, database))
            {
                List<Rating> allRatings = feedManager.getRatingsFromFile(mediaFile.FilePath, database);

                int negativeCount = 0;

                foreach (Rating rating in allRatings)
                {
                    if (!rating.Positive)
                    {
                        negativeCount++;
                    }
                }

                ListViewItem item = new ListViewItem(Convert.ToString(mediaFile.MediaFileID));
                item.SubItems.Add(mediaFile.MediaTypeName.Type);
                item.SubItems.Add(mediaFile.Description);
                item.SubItems.Add(Convert.ToString(((decimal)negativeCount / (decimal)allRatings.Count()) * 100));

                lvReportedPosts.Items.Add(item);
            }

            lvReportedComments.Columns.Clear();
            lvReportedComments.Items.Clear();
            lvReportedComments.View = View.Details;

            lvReportedComments.Columns.Add("reactieID");
            lvReportedComments.Columns.Add("Inhoud");
            lvReportedComments.Columns.Add("Percentage");

            lvReportedComments.Columns[0].Width = 110;
            lvReportedComments.Columns[1].Width = 215;
            lvReportedComments.Columns[2].Width = 70;

            foreach (Comment comment in feedManager.GetReportedComments(selectedEvent.ReportPercentage, selectedEvent.EventID, database))
            {
                List<Rating> allRatings = feedManager.getRatingsFromComment(comment.CommentID, database);

                int negativeCount = 0;

                foreach (Rating rating in allRatings)
                {
                    if (!rating.Positive)
                    {
                        negativeCount++;
                    }
                }

                ListViewItem item = new ListViewItem(Convert.ToString(comment.CommentID));
                item.SubItems.Add(comment.Content);
                item.SubItems.Add(Convert.ToString(((decimal)negativeCount / (decimal)allRatings.Count()) * 100));

                lvReportedComments.Items.Add(item);
            }
        }

        private void btnReportedPostsRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Alle reacties op dit mediabestand en alle oordelen op de hiervoor genoemde reacties en het mediabestand zullen verwijderd worden, wilt u doorgaan?", "Important Question", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ListView.CheckedListViewItemCollection checkedItems = lvReportedPosts.CheckedItems;

                    foreach (ListViewItem item in checkedItems)
                    {
                        MediaFile currentMediafile = MediaFile.GetStatic(Convert.ToInt32(item.SubItems[0].Text), database);
                        currentMediafile.Remove(currentMediafile, database);
                    }

                    cbReportedPostsEvents_SelectedIndexChanged(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(DecodeException(ex.Message));
                }
            }
        }


        private void btnReportedReactionsRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Alle reacties op deze reactie en alle oordelen op de hiervoor genoemde reacties zullen verwijderd worden, wilt u doorgaan?", "Important Question", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ListView.CheckedListViewItemCollection checkedItems = lvReportedComments.CheckedItems;

                    foreach (ListViewItem item in checkedItems)
                    {
                        Comment currentComment = Comment.GetStatic(Convert.ToInt32(item.SubItems[0].Text), database);

                        currentComment.Remove(currentComment, database);
                    }

                    cbReportedPostsEvents_SelectedIndexChanged(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(DecodeException(ex.Message));
                }
            }
        }
        #endregion
    }
}
