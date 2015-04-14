namespace Proftaak_ICT4Events
{
    partial class UIMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIMainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpTijdlijn = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbPost = new System.Windows.Forms.GroupBox();
            this.tpRental = new System.Windows.Forms.TabPage();
            this.lblMaterialProductNameName = new System.Windows.Forms.Label();
            this.lblMaterialDescriptionValue = new System.Windows.Forms.Label();
            this.lblMaterialDepositAmount = new System.Windows.Forms.Label();
            this.lblMaterialDescription = new System.Windows.Forms.Label();
            this.lblMaterialDeposit = new System.Windows.Forms.Label();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.lblMaterialAvailable = new System.Windows.Forms.Label();
            this.pbProductList = new System.Windows.Forms.PictureBox();
            this.lblMaterialProduct = new System.Windows.Forms.Label();
            this.lblMaterialCategory = new System.Windows.Forms.Label();
            this.cbMaterialProduct = new System.Windows.Forms.ComboBox();
            this.cbMaterialCategory = new System.Windows.Forms.ComboBox();
            this.tpBestanden = new System.Windows.Forms.TabPage();
            this.tvFolders = new System.Windows.Forms.ListView();
            this.tvTree = new System.Windows.Forms.TreeView();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.dpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.tbSettingsUsername = new System.Windows.Forms.TextBox();
            this.tbSettingsEmail = new System.Windows.Forms.TextBox();
            this.tbSettingsName = new System.Windows.Forms.TextBox();
            this.lblSettingsUsername = new System.Windows.Forms.Label();
            this.lblSettingsGeboorte = new System.Windows.Forms.Label();
            this.lblSettingsEmail = new System.Windows.Forms.Label();
            this.btnSettingsEdit = new System.Windows.Forms.Button();
            this.lblSettingsName = new System.Windows.Forms.Label();
            this.pbSettingsPicture = new System.Windows.Forms.PictureBox();
            this.tpMap = new System.Windows.Forms.TabPage();
            this.pbMapMap = new System.Windows.Forms.PictureBox();
            this.lblMapPeople = new System.Windows.Forms.Label();
            this.lblMapType = new System.Windows.Forms.Label();
            this.nudMapSpot = new System.Windows.Forms.NumericUpDown();
            this.lblMapTypePlace = new System.Windows.Forms.Label();
            this.lblMapMax = new System.Windows.Forms.Label();
            this.lblMapNumber = new System.Windows.Forms.Label();
            this.lblMapInfo = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLike = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpTijdlijn.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbPost.SuspendLayout();
            this.tpRental.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductList)).BeginInit();
            this.tpBestanden.SuspendLayout();
            this.tpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettingsPicture)).BeginInit();
            this.tpMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapSpot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tpTijdlijn);
            this.tabControl1.Controls.Add(this.tpRental);
            this.tabControl1.Controls.Add(this.tpBestanden);
            this.tabControl1.Controls.Add(this.tpSettings);
            this.tabControl1.Controls.Add(this.tpMap);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(40, 150);
            this.tabControl1.Location = new System.Drawing.Point(12, 71);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1046, 556);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tpTijdlijn
            // 
            this.tpTijdlijn.Controls.Add(this.flowLayoutPanel1);
            this.tpTijdlijn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpTijdlijn.Location = new System.Drawing.Point(154, 4);
            this.tpTijdlijn.Name = "tpTijdlijn";
            this.tpTijdlijn.Padding = new System.Windows.Forms.Padding(3);
            this.tpTijdlijn.Size = new System.Drawing.Size(888, 548);
            this.tpTijdlijn.TabIndex = 0;
            this.tpTijdlijn.Text = "Tijdlijn";
            this.tpTijdlijn.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.gbPost);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(92, 49);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(750, 456);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // gbPost
            // 
            this.gbPost.Controls.Add(this.button1);
            this.gbPost.Controls.Add(this.btnLike);
            this.gbPost.Controls.Add(this.label2);
            this.gbPost.Controls.Add(this.pictureBox3);
            this.gbPost.Location = new System.Drawing.Point(3, 3);
            this.gbPost.Name = "gbPost";
            this.gbPost.Size = new System.Drawing.Size(531, 259);
            this.gbPost.TabIndex = 0;
            this.gbPost.TabStop = false;
            // 
            // tpRental
            // 
            this.tpRental.Controls.Add(this.lblMaterialProductNameName);
            this.tpRental.Controls.Add(this.lblMaterialDescriptionValue);
            this.tpRental.Controls.Add(this.lblMaterialDepositAmount);
            this.tpRental.Controls.Add(this.lblMaterialDescription);
            this.tpRental.Controls.Add(this.lblMaterialDeposit);
            this.tpRental.Controls.Add(this.lblMaterialName);
            this.tpRental.Controls.Add(this.lblMaterialAvailable);
            this.tpRental.Controls.Add(this.pbProductList);
            this.tpRental.Controls.Add(this.lblMaterialProduct);
            this.tpRental.Controls.Add(this.lblMaterialCategory);
            this.tpRental.Controls.Add(this.cbMaterialProduct);
            this.tpRental.Controls.Add(this.cbMaterialCategory);
            this.tpRental.Location = new System.Drawing.Point(154, 4);
            this.tpRental.Name = "tpRental";
            this.tpRental.Padding = new System.Windows.Forms.Padding(3);
            this.tpRental.Size = new System.Drawing.Size(888, 548);
            this.tpRental.TabIndex = 1;
            this.tpRental.Text = "Verhuur";
            this.tpRental.UseVisualStyleBackColor = true;
            // 
            // lblMaterialProductNameName
            // 
            this.lblMaterialProductNameName.AutoSize = true;
            this.lblMaterialProductNameName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialProductNameName.Location = new System.Drawing.Point(579, 34);
            this.lblMaterialProductNameName.Name = "lblMaterialProductNameName";
            this.lblMaterialProductNameName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaterialProductNameName.Size = new System.Drawing.Size(67, 22);
            this.lblMaterialProductNameName.TabIndex = 12;
            this.lblMaterialProductNameName.Text = "Naam";
            this.lblMaterialProductNameName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMaterialDescriptionValue
            // 
            this.lblMaterialDescriptionValue.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialDescriptionValue.Location = new System.Drawing.Point(579, 90);
            this.lblMaterialDescriptionValue.Name = "lblMaterialDescriptionValue";
            this.lblMaterialDescriptionValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaterialDescriptionValue.Size = new System.Drawing.Size(290, 269);
            this.lblMaterialDescriptionValue.TabIndex = 11;
            this.lblMaterialDescriptionValue.Text = resources.GetString("lblMaterialDescriptionValue.Text");
            // 
            // lblMaterialDepositAmount
            // 
            this.lblMaterialDepositAmount.AutoSize = true;
            this.lblMaterialDepositAmount.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialDepositAmount.Location = new System.Drawing.Point(579, 62);
            this.lblMaterialDepositAmount.Name = "lblMaterialDepositAmount";
            this.lblMaterialDepositAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaterialDepositAmount.Size = new System.Drawing.Size(43, 22);
            this.lblMaterialDepositAmount.TabIndex = 10;
            this.lblMaterialDepositAmount.Text = "120";
            this.lblMaterialDepositAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMaterialDescription
            // 
            this.lblMaterialDescription.AutoSize = true;
            this.lblMaterialDescription.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialDescription.Location = new System.Drawing.Point(410, 90);
            this.lblMaterialDescription.Name = "lblMaterialDescription";
            this.lblMaterialDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaterialDescription.Size = new System.Drawing.Size(128, 22);
            this.lblMaterialDescription.TabIndex = 9;
            this.lblMaterialDescription.Text = "Omschrijving";
            this.lblMaterialDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMaterialDeposit
            // 
            this.lblMaterialDeposit.AutoSize = true;
            this.lblMaterialDeposit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialDeposit.Location = new System.Drawing.Point(410, 62);
            this.lblMaterialDeposit.Name = "lblMaterialDeposit";
            this.lblMaterialDeposit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaterialDeposit.Size = new System.Drawing.Size(52, 22);
            this.lblMaterialDeposit.TabIndex = 8;
            this.lblMaterialDeposit.Text = "Borg";
            this.lblMaterialDeposit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialName.Location = new System.Drawing.Point(410, 34);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaterialName.Size = new System.Drawing.Size(67, 22);
            this.lblMaterialName.TabIndex = 7;
            this.lblMaterialName.Text = "Naam";
            this.lblMaterialName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMaterialAvailable
            // 
            this.lblMaterialAvailable.AutoSize = true;
            this.lblMaterialAvailable.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMaterialAvailable.Location = new System.Drawing.Point(732, 34);
            this.lblMaterialAvailable.Name = "lblMaterialAvailable";
            this.lblMaterialAvailable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaterialAvailable.Size = new System.Drawing.Size(122, 22);
            this.lblMaterialAvailable.TabIndex = 6;
            this.lblMaterialAvailable.Text = "Beschikbaar";
            this.lblMaterialAvailable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbProductList
            // 
            this.pbProductList.Location = new System.Drawing.Point(235, 34);
            this.pbProductList.Name = "pbProductList";
            this.pbProductList.Size = new System.Drawing.Size(169, 174);
            this.pbProductList.TabIndex = 5;
            this.pbProductList.TabStop = false;
            // 
            // lblMaterialProduct
            // 
            this.lblMaterialProduct.AutoSize = true;
            this.lblMaterialProduct.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialProduct.Location = new System.Drawing.Point(17, 100);
            this.lblMaterialProduct.Name = "lblMaterialProduct";
            this.lblMaterialProduct.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaterialProduct.Size = new System.Drawing.Size(83, 22);
            this.lblMaterialProduct.TabIndex = 4;
            this.lblMaterialProduct.Text = "Product";
            this.lblMaterialProduct.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMaterialCategory
            // 
            this.lblMaterialCategory.AutoSize = true;
            this.lblMaterialCategory.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialCategory.Location = new System.Drawing.Point(17, 34);
            this.lblMaterialCategory.Name = "lblMaterialCategory";
            this.lblMaterialCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaterialCategory.Size = new System.Drawing.Size(103, 22);
            this.lblMaterialCategory.TabIndex = 3;
            this.lblMaterialCategory.Text = "Categorie";
            this.lblMaterialCategory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbMaterialProduct
            // 
            this.cbMaterialProduct.FormattingEnabled = true;
            this.cbMaterialProduct.Location = new System.Drawing.Point(21, 125);
            this.cbMaterialProduct.Name = "cbMaterialProduct";
            this.cbMaterialProduct.Size = new System.Drawing.Size(181, 21);
            this.cbMaterialProduct.TabIndex = 2;
            // 
            // cbMaterialCategory
            // 
            this.cbMaterialCategory.FormattingEnabled = true;
            this.cbMaterialCategory.Location = new System.Drawing.Point(21, 59);
            this.cbMaterialCategory.Name = "cbMaterialCategory";
            this.cbMaterialCategory.Size = new System.Drawing.Size(181, 21);
            this.cbMaterialCategory.TabIndex = 1;
            // 
            // tpBestanden
            // 
            this.tpBestanden.Controls.Add(this.tvFolders);
            this.tpBestanden.Controls.Add(this.tvTree);
            this.tpBestanden.Location = new System.Drawing.Point(154, 4);
            this.tpBestanden.Name = "tpBestanden";
            this.tpBestanden.Size = new System.Drawing.Size(888, 548);
            this.tpBestanden.TabIndex = 2;
            this.tpBestanden.Text = "Bestanden";
            this.tpBestanden.UseVisualStyleBackColor = true;
            // 
            // tvFolders
            // 
            this.tvFolders.Location = new System.Drawing.Point(266, 3);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.Size = new System.Drawing.Size(619, 542);
            this.tvFolders.TabIndex = 1;
            this.tvFolders.UseCompatibleStateImageBehavior = false;
            // 
            // tvTree
            // 
            this.tvTree.Location = new System.Drawing.Point(3, 3);
            this.tvTree.Name = "tvTree";
            this.tvTree.Size = new System.Drawing.Size(257, 542);
            this.tvTree.TabIndex = 0;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.btnSettingsSave);
            this.tpSettings.Controls.Add(this.dpBirthDate);
            this.tpSettings.Controls.Add(this.tbSettingsUsername);
            this.tpSettings.Controls.Add(this.tbSettingsEmail);
            this.tpSettings.Controls.Add(this.tbSettingsName);
            this.tpSettings.Controls.Add(this.lblSettingsUsername);
            this.tpSettings.Controls.Add(this.lblSettingsGeboorte);
            this.tpSettings.Controls.Add(this.lblSettingsEmail);
            this.tpSettings.Controls.Add(this.btnSettingsEdit);
            this.tpSettings.Controls.Add(this.lblSettingsName);
            this.tpSettings.Controls.Add(this.pbSettingsPicture);
            this.tpSettings.Location = new System.Drawing.Point(154, 4);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(888, 548);
            this.tpSettings.TabIndex = 3;
            this.tpSettings.Text = "Instellingen";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.Enabled = false;
            this.btnSettingsSave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettingsSave.Location = new System.Drawing.Point(25, 274);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(200, 27);
            this.btnSettingsSave.TabIndex = 11;
            this.btnSettingsSave.Text = "Opslaan";
            this.btnSettingsSave.UseVisualStyleBackColor = true;
            // 
            // dpBirthDate
            // 
            this.dpBirthDate.Location = new System.Drawing.Point(251, 142);
            this.dpBirthDate.Name = "dpBirthDate";
            this.dpBirthDate.Size = new System.Drawing.Size(366, 20);
            this.dpBirthDate.TabIndex = 10;
            // 
            // tbSettingsUsername
            // 
            this.tbSettingsUsername.Location = new System.Drawing.Point(251, 190);
            this.tbSettingsUsername.Name = "tbSettingsUsername";
            this.tbSettingsUsername.Size = new System.Drawing.Size(366, 20);
            this.tbSettingsUsername.TabIndex = 9;
            // 
            // tbSettingsEmail
            // 
            this.tbSettingsEmail.Location = new System.Drawing.Point(251, 94);
            this.tbSettingsEmail.Name = "tbSettingsEmail";
            this.tbSettingsEmail.Size = new System.Drawing.Size(366, 20);
            this.tbSettingsEmail.TabIndex = 7;
            // 
            // tbSettingsName
            // 
            this.tbSettingsName.Location = new System.Drawing.Point(251, 49);
            this.tbSettingsName.Name = "tbSettingsName";
            this.tbSettingsName.Size = new System.Drawing.Size(366, 20);
            this.tbSettingsName.TabIndex = 6;
            // 
            // lblSettingsUsername
            // 
            this.lblSettingsUsername.AutoSize = true;
            this.lblSettingsUsername.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsUsername.Location = new System.Drawing.Point(247, 165);
            this.lblSettingsUsername.Name = "lblSettingsUsername";
            this.lblSettingsUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSettingsUsername.Size = new System.Drawing.Size(163, 22);
            this.lblSettingsUsername.TabIndex = 5;
            this.lblSettingsUsername.Text = "Gebruikersnaam";
            this.lblSettingsUsername.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSettingsGeboorte
            // 
            this.lblSettingsGeboorte.AutoSize = true;
            this.lblSettingsGeboorte.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsGeboorte.Location = new System.Drawing.Point(247, 117);
            this.lblSettingsGeboorte.Name = "lblSettingsGeboorte";
            this.lblSettingsGeboorte.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSettingsGeboorte.Size = new System.Drawing.Size(169, 22);
            this.lblSettingsGeboorte.TabIndex = 4;
            this.lblSettingsGeboorte.Text = "Geboorte Datum";
            this.lblSettingsGeboorte.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSettingsEmail
            // 
            this.lblSettingsEmail.AutoSize = true;
            this.lblSettingsEmail.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsEmail.Location = new System.Drawing.Point(247, 69);
            this.lblSettingsEmail.Name = "lblSettingsEmail";
            this.lblSettingsEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSettingsEmail.Size = new System.Drawing.Size(56, 22);
            this.lblSettingsEmail.TabIndex = 3;
            this.lblSettingsEmail.Text = "Email";
            this.lblSettingsEmail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSettingsEdit
            // 
            this.btnSettingsEdit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettingsEdit.Location = new System.Drawing.Point(25, 241);
            this.btnSettingsEdit.Name = "btnSettingsEdit";
            this.btnSettingsEdit.Size = new System.Drawing.Size(200, 27);
            this.btnSettingsEdit.TabIndex = 2;
            this.btnSettingsEdit.Text = "Profiel Bewerken";
            this.btnSettingsEdit.UseVisualStyleBackColor = true;
            // 
            // lblSettingsName
            // 
            this.lblSettingsName.AutoSize = true;
            this.lblSettingsName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsName.Location = new System.Drawing.Point(247, 23);
            this.lblSettingsName.Name = "lblSettingsName";
            this.lblSettingsName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSettingsName.Size = new System.Drawing.Size(67, 22);
            this.lblSettingsName.TabIndex = 1;
            this.lblSettingsName.Text = "Naam";
            this.lblSettingsName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbSettingsPicture
            // 
            this.pbSettingsPicture.Location = new System.Drawing.Point(25, 23);
            this.pbSettingsPicture.Name = "pbSettingsPicture";
            this.pbSettingsPicture.Size = new System.Drawing.Size(200, 200);
            this.pbSettingsPicture.TabIndex = 0;
            this.pbSettingsPicture.TabStop = false;
            // 
            // tpMap
            // 
            this.tpMap.Controls.Add(this.pbMapMap);
            this.tpMap.Controls.Add(this.lblMapPeople);
            this.tpMap.Controls.Add(this.lblMapType);
            this.tpMap.Controls.Add(this.nudMapSpot);
            this.tpMap.Controls.Add(this.lblMapTypePlace);
            this.tpMap.Controls.Add(this.lblMapMax);
            this.tpMap.Controls.Add(this.lblMapNumber);
            this.tpMap.Controls.Add(this.lblMapInfo);
            this.tpMap.Location = new System.Drawing.Point(154, 4);
            this.tpMap.Name = "tpMap";
            this.tpMap.Size = new System.Drawing.Size(888, 548);
            this.tpMap.TabIndex = 4;
            this.tpMap.Text = "Kaart";
            this.tpMap.UseVisualStyleBackColor = true;
            // 
            // pbMapMap
            // 
            this.pbMapMap.Image = ((System.Drawing.Image)(resources.GetObject("pbMapMap.Image")));
            this.pbMapMap.InitialImage = null;
            this.pbMapMap.Location = new System.Drawing.Point(361, 26);
            this.pbMapMap.Name = "pbMapMap";
            this.pbMapMap.Size = new System.Drawing.Size(500, 500);
            this.pbMapMap.TabIndex = 7;
            this.pbMapMap.TabStop = false;
            // 
            // lblMapPeople
            // 
            this.lblMapPeople.AutoSize = true;
            this.lblMapPeople.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapPeople.Location = new System.Drawing.Point(211, 117);
            this.lblMapPeople.Name = "lblMapPeople";
            this.lblMapPeople.Size = new System.Drawing.Size(19, 21);
            this.lblMapPeople.TabIndex = 6;
            this.lblMapPeople.Text = "6";
            // 
            // lblMapType
            // 
            this.lblMapType.AutoSize = true;
            this.lblMapType.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapType.Location = new System.Drawing.Point(210, 85);
            this.lblMapType.Name = "lblMapType";
            this.lblMapType.Size = new System.Drawing.Size(115, 21);
            this.lblMapType.TabIndex = 5;
            this.lblMapType.Text = "Bungolowww";
            // 
            // nudMapSpot
            // 
            this.nudMapSpot.Location = new System.Drawing.Point(214, 55);
            this.nudMapSpot.Maximum = new decimal(new int[] {
            679,
            0,
            0,
            0});
            this.nudMapSpot.Name = "nudMapSpot";
            this.nudMapSpot.Size = new System.Drawing.Size(68, 20);
            this.nudMapSpot.TabIndex = 4;
            // 
            // lblMapTypePlace
            // 
            this.lblMapTypePlace.AutoSize = true;
            this.lblMapTypePlace.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapTypePlace.Location = new System.Drawing.Point(28, 85);
            this.lblMapTypePlace.Name = "lblMapTypePlace";
            this.lblMapTypePlace.Size = new System.Drawing.Size(81, 21);
            this.lblMapTypePlace.TabIndex = 3;
            this.lblMapTypePlace.Text = "Type Plek";
            // 
            // lblMapMax
            // 
            this.lblMapMax.AutoSize = true;
            this.lblMapMax.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapMax.Location = new System.Drawing.Point(28, 117);
            this.lblMapMax.Name = "lblMapMax";
            this.lblMapMax.Size = new System.Drawing.Size(177, 21);
            this.lblMapMax.TabIndex = 2;
            this.lblMapMax.Text = "Max aantal personen";
            // 
            // lblMapNumber
            // 
            this.lblMapNumber.AutoSize = true;
            this.lblMapNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapNumber.Location = new System.Drawing.Point(28, 55);
            this.lblMapNumber.Name = "lblMapNumber";
            this.lblMapNumber.Size = new System.Drawing.Size(111, 21);
            this.lblMapNumber.TabIndex = 1;
            this.lblMapNumber.Text = "Plek Nummer";
            // 
            // lblMapInfo
            // 
            this.lblMapInfo.AutoSize = true;
            this.lblMapInfo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapInfo.Location = new System.Drawing.Point(26, 12);
            this.lblMapInfo.Name = "lblMapInfo";
            this.lblMapInfo.Size = new System.Drawing.Size(124, 33);
            this.lblMapInfo.TabIndex = 0;
            this.lblMapInfo.Text = "Plek Info";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Bebas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(43, 22);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(99, 46);
            this.lblMenu.TabIndex = 1;
            this.lblMenu.Text = "menu";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(17, 30);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(80, 80);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(104, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(411, 209);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(17, 116);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(80, 49);
            this.btnLike.TabIndex = 2;
            this.btnLike.Text = "Like";
            this.btnLike.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(17, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Comment";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 639);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tpTijdlijn.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbPost.ResumeLayout(false);
            this.tpRental.ResumeLayout(false);
            this.tpRental.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductList)).EndInit();
            this.tpBestanden.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettingsPicture)).EndInit();
            this.tpMap.ResumeLayout(false);
            this.tpMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapSpot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpTijdlijn;
        private System.Windows.Forms.TabPage tpRental;
        private System.Windows.Forms.TabPage tpBestanden;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.TabPage tpMap;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.TextBox tbSettingsUsername;
        private System.Windows.Forms.TextBox tbSettingsEmail;
        private System.Windows.Forms.TextBox tbSettingsName;
        private System.Windows.Forms.Label lblSettingsUsername;
        private System.Windows.Forms.Label lblSettingsGeboorte;
        private System.Windows.Forms.Label lblSettingsEmail;
        private System.Windows.Forms.Button btnSettingsEdit;
        private System.Windows.Forms.Label lblSettingsName;
        private System.Windows.Forms.PictureBox pbSettingsPicture;
        private System.Windows.Forms.DateTimePicker dpBirthDate;
        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.Label lblMapInfo;
        private System.Windows.Forms.Label lblMapNumber;
        private System.Windows.Forms.Label lblMapPeople;
        private System.Windows.Forms.Label lblMapType;
        private System.Windows.Forms.NumericUpDown nudMapSpot;
        private System.Windows.Forms.Label lblMapTypePlace;
        private System.Windows.Forms.Label lblMapMax;
        private System.Windows.Forms.PictureBox pbMapMap;
        private System.Windows.Forms.Label lblMaterialProductNameName;
        private System.Windows.Forms.Label lblMaterialDescriptionValue;
        private System.Windows.Forms.Label lblMaterialDepositAmount;
        private System.Windows.Forms.Label lblMaterialDescription;
        private System.Windows.Forms.Label lblMaterialDeposit;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Label lblMaterialAvailable;
        private System.Windows.Forms.PictureBox pbProductList;
        private System.Windows.Forms.Label lblMaterialProduct;
        private System.Windows.Forms.Label lblMaterialCategory;
        private System.Windows.Forms.ComboBox cbMaterialProduct;
        private System.Windows.Forms.ComboBox cbMaterialCategory;
        private System.Windows.Forms.ListView tvFolders;
        private System.Windows.Forms.TreeView tvTree;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gbPost;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

