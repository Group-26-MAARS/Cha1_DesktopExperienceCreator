namespace MaarsExperienceCreator
{
    partial class MainExperienceCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainExperienceCreator));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.experienceTab = new System.Windows.Forms.RibbonTab();
            this.loadExperiencePanel = new System.Windows.Forms.RibbonPanel();
            this.loadAnimations = new System.Windows.Forms.RibbonTab();
            this.newAnimationPanel = new System.Windows.Forms.RibbonPanel();
            this.loadAnimationPanel = new System.Windows.Forms.RibbonPanel();
            this.RoutesTab = new System.Windows.Forms.RibbonTab();
            this.newRoutePanel = new System.Windows.Forms.RibbonPanel();
            this.saveRibbonBtn = new System.Windows.Forms.RibbonButton();
            this.delRouteRibbnBtn = new System.Windows.Forms.RibbonButton();
            this.updateRouteNotes = new System.Windows.Forms.RibbonButton();
            this.loadRoutePanel = new System.Windows.Forms.RibbonPanel();
            this.showHideRibbonBtn = new System.Windows.Forms.RibbonButton();
            this.sortRibbonBtn = new System.Windows.Forms.RibbonButton();
            this.filterRibbonBtn = new System.Windows.Forms.RibbonButton();
            this.viewActiveUsers = new System.Windows.Forms.RibbonTab();
            this.createNewUser = new System.Windows.Forms.RibbonPanel();
            this.viewUsers = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.newRouteTable = new System.Windows.Forms.DataGridView();
            this.routeAnchorsForRemovalChkboxesCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NavPointNameColumnFromNewRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anchorDataFromNewRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anchorLocationFromNewRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newRouteAnchorExpiration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anchorDescriptionFromNewRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availableNavPointsTable = new System.Windows.Forms.DataGridView();
            this.addBtns = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.availableNavPointsNavPointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anchorDataFromAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anchorLocationFromAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anchorExpirationFromAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anchorDescriptionFromAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newRouteTableLabel = new System.Windows.Forms.Label();
            this.availableNavPointsTableLabel = new System.Windows.Forms.Label();
            this.addAnchorToNewRouteBtn = new System.Windows.Forms.Button();
            this.removeAnchorFromNewRouteBtn = new System.Windows.Forms.Button();
            this.saveNewRouteBtn = new System.Windows.Forms.Button();
            this.updateAnchorBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.experienceTable = new System.Windows.Forms.DataGridView();
            this.newExpChkboxCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.newExpNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newExpTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newExpUserAccessCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceLabel = new System.Windows.Forms.Label();
            this.experienceLoadBtn = new System.Windows.Forms.Button();
            this.experienceSaveBtn = new System.Windows.Forms.Button();
            this.experienceRemoveBtn = new System.Windows.Forms.Button();
            this.availableExpItems = new System.Windows.Forms.DataGridView();
            this.availExpChkboxCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.availExpNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availExpTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availExpUserAccessCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addExpItemBtn = new System.Windows.Forms.Button();
            this.availableExpItemsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.newRouteTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableNavPointsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.experienceTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableExpItems)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(711, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 25);
            this.ribbon1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 160);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbText = "File";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(711, 148);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.experienceTab);
            this.ribbon1.Tabs.Add(this.loadAnimations);
            this.ribbon1.Tabs.Add(this.RoutesTab);
            this.ribbon1.Tabs.Add(this.viewActiveUsers);
            this.ribbon1.TabSpacing = 3;
            this.ribbon1.Text = "ribbon1";
            // 
            // experienceTab
            // 
            this.experienceTab.Name = "experienceTab";
            this.experienceTab.Panels.Add(this.loadExperiencePanel);
            this.experienceTab.Text = "Experience";
            this.experienceTab.ActiveChanged += new System.EventHandler(this.experienceTab_ActiveChanged);
            // 
            // loadExperiencePanel
            // 
            this.loadExperiencePanel.Name = "loadExperiencePanel";
            this.loadExperiencePanel.Text = "";
            // 
            // loadAnimations
            // 
            this.loadAnimations.Name = "loadAnimations";
            this.loadAnimations.Panels.Add(this.newAnimationPanel);
            this.loadAnimations.Panels.Add(this.loadAnimationPanel);
            this.loadAnimations.Text = "Load Animations";
            // 
            // newAnimationPanel
            // 
            this.newAnimationPanel.Name = "newAnimationPanel";
            this.newAnimationPanel.Text = "New Animation";
            // 
            // loadAnimationPanel
            // 
            this.loadAnimationPanel.Name = "loadAnimationPanel";
            this.loadAnimationPanel.Text = "Load Existing";
            this.loadAnimationPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.loadAnimationPanel_MouseUp);
            // 
            // RoutesTab
            // 
            this.RoutesTab.Name = "RoutesTab";
            this.RoutesTab.Panels.Add(this.newRoutePanel);
            this.RoutesTab.Panels.Add(this.loadRoutePanel);
            this.RoutesTab.Text = "Routes";
            this.RoutesTab.ActiveChanged += new System.EventHandler(this.RoutesTab_ActiveChanged);
            // 
            // newRoutePanel
            // 
            this.newRoutePanel.FlowsTo = System.Windows.Forms.RibbonPanelFlowDirection.Left;
            this.newRoutePanel.Items.Add(this.saveRibbonBtn);
            this.newRoutePanel.Items.Add(this.delRouteRibbnBtn);
            this.newRoutePanel.Items.Add(this.updateRouteNotes);
            this.newRoutePanel.Name = "newRoutePanel";
            this.newRoutePanel.Text = "Actions";
            this.newRoutePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.newRoutePanel_MouseUp);
            // 
            // saveRibbonBtn
            // 
            this.saveRibbonBtn.Image = global::MaarsExperienceCreator.Properties.Resources.saveBtnCompressed24;
            this.saveRibbonBtn.LargeImage = global::MaarsExperienceCreator.Properties.Resources.saveBtnCompressed24;
            this.saveRibbonBtn.Name = "saveRibbonBtn";
            this.saveRibbonBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("saveRibbonBtn.SmallImage")));
            this.saveRibbonBtn.Text = "";
            this.saveRibbonBtn.ToolTip = "Save Route";
            this.saveRibbonBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.saveRibbonBtn_MouseUp);
            // 
            // delRouteRibbnBtn
            // 
            this.delRouteRibbnBtn.Image = global::MaarsExperienceCreator.Properties.Resources.compressedX_24;
            this.delRouteRibbnBtn.LargeImage = global::MaarsExperienceCreator.Properties.Resources.compressedX_24;
            this.delRouteRibbnBtn.Name = "delRouteRibbnBtn";
            this.delRouteRibbnBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("delRouteRibbnBtn.SmallImage")));
            this.delRouteRibbnBtn.ToolTip = "Provides a List of Available Routes, which can be deleted from database";
            this.delRouteRibbnBtn.ToolTipTitle = "Delete Route";
            this.delRouteRibbnBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.delRouteRibbnBtn_MouseUp);
            // 
            // updateRouteNotes
            // 
            this.updateRouteNotes.Image = global::MaarsExperienceCreator.Properties.Resources.clipboardjpeg24;
            this.updateRouteNotes.LargeImage = global::MaarsExperienceCreator.Properties.Resources.clipboardjpeg24;
            this.updateRouteNotes.Name = "updateRouteNotes";
            this.updateRouteNotes.SmallImage = ((System.Drawing.Image)(resources.GetObject("updateRouteNotes.SmallImage")));
            this.updateRouteNotes.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            this.updateRouteNotes.ToolTip = "Launches Dialog to Update Notes for the provided route";
            this.updateRouteNotes.ToolTipTitle = "Update Route Notes";
            // 
            // loadRoutePanel
            // 
            this.loadRoutePanel.Items.Add(this.showHideRibbonBtn);
            this.loadRoutePanel.Items.Add(this.sortRibbonBtn);
            this.loadRoutePanel.Items.Add(this.filterRibbonBtn);
            this.loadRoutePanel.Name = "loadRoutePanel";
            this.loadRoutePanel.Text = "View";
            this.loadRoutePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.loadRoutePanel_MouseUp);
            // 
            // showHideRibbonBtn
            // 
            this.showHideRibbonBtn.Image = ((System.Drawing.Image)(resources.GetObject("showHideRibbonBtn.Image")));
            this.showHideRibbonBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("showHideRibbonBtn.LargeImage")));
            this.showHideRibbonBtn.Name = "showHideRibbonBtn";
            this.showHideRibbonBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("showHideRibbonBtn.SmallImage")));
            this.showHideRibbonBtn.ToolTip = "Show/Hide Columns";
            this.showHideRibbonBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showHideRibbonBtn_MouseUp);
            // 
            // sortRibbonBtn
            // 
            this.sortRibbonBtn.Image = ((System.Drawing.Image)(resources.GetObject("sortRibbonBtn.Image")));
            this.sortRibbonBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("sortRibbonBtn.LargeImage")));
            this.sortRibbonBtn.Name = "sortRibbonBtn";
            this.sortRibbonBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("sortRibbonBtn.SmallImage")));
            this.sortRibbonBtn.ToolTip = "Sort Anchors";
            // 
            // filterRibbonBtn
            // 
            this.filterRibbonBtn.Image = global::MaarsExperienceCreator.Properties.Resources.filterjpeg24;
            this.filterRibbonBtn.LargeImage = global::MaarsExperienceCreator.Properties.Resources.filterjpeg24;
            this.filterRibbonBtn.Name = "filterRibbonBtn";
            this.filterRibbonBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("filterRibbonBtn.SmallImage")));
            this.filterRibbonBtn.ToolTip = "Filter Anchors";
            // 
            // viewActiveUsers
            // 
            this.viewActiveUsers.Name = "viewActiveUsers";
            this.viewActiveUsers.Panels.Add(this.createNewUser);
            this.viewActiveUsers.Panels.Add(this.viewUsers);
            this.viewActiveUsers.Text = "Users";
            // 
            // createNewUser
            // 
            this.createNewUser.Name = "createNewUser";
            this.createNewUser.Text = "Create New";
            // 
            // viewUsers
            // 
            this.viewUsers.Name = "viewUsers";
            this.viewUsers.Text = "View List";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "ribbonPanel1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Text = "Experience";
            // 
            // newRouteTable
            // 
            this.newRouteTable.AllowUserToAddRows = false;
            this.newRouteTable.AllowUserToDeleteRows = false;
            this.newRouteTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newRouteTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.routeAnchorsForRemovalChkboxesCol,
            this.NavPointNameColumnFromNewRoute,
            this.anchorDataFromNewRoute,
            this.anchorLocationFromNewRoute,
            this.newRouteAnchorExpiration,
            this.anchorDescriptionFromNewRoute});
            this.newRouteTable.Location = new System.Drawing.Point(57, 221);
            this.newRouteTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newRouteTable.Name = "newRouteTable";
            this.newRouteTable.ReadOnly = true;
            this.newRouteTable.RowHeadersWidth = 51;
            this.newRouteTable.RowTemplate.Height = 24;
            this.newRouteTable.Size = new System.Drawing.Size(603, 256);
            this.newRouteTable.TabIndex = 3;
            this.newRouteTable.Visible = false;
            this.newRouteTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.newRouteTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.newRouteTable_CellValueChanged);
            // 
            // routeAnchorsForRemovalChkboxesCol
            // 
            this.routeAnchorsForRemovalChkboxesCol.FillWeight = 50F;
            this.routeAnchorsForRemovalChkboxesCol.HeaderText = "";
            this.routeAnchorsForRemovalChkboxesCol.MinimumWidth = 6;
            this.routeAnchorsForRemovalChkboxesCol.Name = "routeAnchorsForRemovalChkboxesCol";
            this.routeAnchorsForRemovalChkboxesCol.ReadOnly = true;
            this.routeAnchorsForRemovalChkboxesCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.routeAnchorsForRemovalChkboxesCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.routeAnchorsForRemovalChkboxesCol.Width = 50;
            // 
            // NavPointNameColumnFromNewRoute
            // 
            this.NavPointNameColumnFromNewRoute.HeaderText = "Nav Point";
            this.NavPointNameColumnFromNewRoute.MaxInputLength = 100;
            this.NavPointNameColumnFromNewRoute.MinimumWidth = 6;
            this.NavPointNameColumnFromNewRoute.Name = "NavPointNameColumnFromNewRoute";
            this.NavPointNameColumnFromNewRoute.ReadOnly = true;
            this.NavPointNameColumnFromNewRoute.Width = 125;
            // 
            // anchorDataFromNewRoute
            // 
            this.anchorDataFromNewRoute.FillWeight = 1F;
            this.anchorDataFromNewRoute.HeaderText = "";
            this.anchorDataFromNewRoute.MinimumWidth = 6;
            this.anchorDataFromNewRoute.Name = "anchorDataFromNewRoute";
            this.anchorDataFromNewRoute.ReadOnly = true;
            this.anchorDataFromNewRoute.Visible = false;
            this.anchorDataFromNewRoute.Width = 10;
            // 
            // anchorLocationFromNewRoute
            // 
            this.anchorLocationFromNewRoute.HeaderText = "Location";
            this.anchorLocationFromNewRoute.MinimumWidth = 6;
            this.anchorLocationFromNewRoute.Name = "anchorLocationFromNewRoute";
            this.anchorLocationFromNewRoute.ReadOnly = true;
            this.anchorLocationFromNewRoute.Width = 125;
            // 
            // newRouteAnchorExpiration
            // 
            this.newRouteAnchorExpiration.HeaderText = "Expiration";
            this.newRouteAnchorExpiration.MinimumWidth = 6;
            this.newRouteAnchorExpiration.Name = "newRouteAnchorExpiration";
            this.newRouteAnchorExpiration.ReadOnly = true;
            this.newRouteAnchorExpiration.Width = 125;
            // 
            // anchorDescriptionFromNewRoute
            // 
            this.anchorDescriptionFromNewRoute.HeaderText = "Description";
            this.anchorDescriptionFromNewRoute.MinimumWidth = 6;
            this.anchorDescriptionFromNewRoute.Name = "anchorDescriptionFromNewRoute";
            this.anchorDescriptionFromNewRoute.ReadOnly = true;
            this.anchorDescriptionFromNewRoute.Width = 125;
            // 
            // availableNavPointsTable
            // 
            this.availableNavPointsTable.AllowUserToAddRows = false;
            this.availableNavPointsTable.AllowUserToDeleteRows = false;
            this.availableNavPointsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availableNavPointsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addBtns,
            this.availableNavPointsNavPointName,
            this.anchorDataFromAvailable,
            this.anchorLocationFromAvailable,
            this.anchorExpirationFromAvailable,
            this.anchorDescriptionFromAvailable});
            this.availableNavPointsTable.Location = new System.Drawing.Point(57, 521);
            this.availableNavPointsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.availableNavPointsTable.Name = "availableNavPointsTable";
            this.availableNavPointsTable.ReadOnly = true;
            this.availableNavPointsTable.RowHeadersWidth = 51;
            this.availableNavPointsTable.RowTemplate.Height = 24;
            this.availableNavPointsTable.Size = new System.Drawing.Size(603, 258);
            this.availableNavPointsTable.TabIndex = 4;
            this.availableNavPointsTable.Visible = false;
            // 
            // addBtns
            // 
            this.addBtns.FillWeight = 50F;
            this.addBtns.HeaderText = "";
            this.addBtns.MinimumWidth = 6;
            this.addBtns.Name = "addBtns";
            this.addBtns.ReadOnly = true;
            this.addBtns.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.addBtns.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.addBtns.Width = 50;
            // 
            // availableNavPointsNavPointName
            // 
            this.availableNavPointsNavPointName.HeaderText = "Nav Point";
            this.availableNavPointsNavPointName.MaxInputLength = 100;
            this.availableNavPointsNavPointName.MinimumWidth = 6;
            this.availableNavPointsNavPointName.Name = "availableNavPointsNavPointName";
            this.availableNavPointsNavPointName.ReadOnly = true;
            this.availableNavPointsNavPointName.Width = 125;
            // 
            // anchorDataFromAvailable
            // 
            this.anchorDataFromAvailable.FillWeight = 1F;
            this.anchorDataFromAvailable.HeaderText = "";
            this.anchorDataFromAvailable.MinimumWidth = 6;
            this.anchorDataFromAvailable.Name = "anchorDataFromAvailable";
            this.anchorDataFromAvailable.ReadOnly = true;
            this.anchorDataFromAvailable.Visible = false;
            this.anchorDataFromAvailable.Width = 10;
            // 
            // anchorLocationFromAvailable
            // 
            this.anchorLocationFromAvailable.HeaderText = "Location";
            this.anchorLocationFromAvailable.MinimumWidth = 6;
            this.anchorLocationFromAvailable.Name = "anchorLocationFromAvailable";
            this.anchorLocationFromAvailable.ReadOnly = true;
            this.anchorLocationFromAvailable.Width = 125;
            // 
            // anchorExpirationFromAvailable
            // 
            this.anchorExpirationFromAvailable.HeaderText = "Expiration";
            this.anchorExpirationFromAvailable.MinimumWidth = 6;
            this.anchorExpirationFromAvailable.Name = "anchorExpirationFromAvailable";
            this.anchorExpirationFromAvailable.ReadOnly = true;
            this.anchorExpirationFromAvailable.Width = 125;
            // 
            // anchorDescriptionFromAvailable
            // 
            this.anchorDescriptionFromAvailable.HeaderText = "Description";
            this.anchorDescriptionFromAvailable.MinimumWidth = 6;
            this.anchorDescriptionFromAvailable.Name = "anchorDescriptionFromAvailable";
            this.anchorDescriptionFromAvailable.ReadOnly = true;
            this.anchorDescriptionFromAvailable.Width = 125;
            // 
            // newRouteTableLabel
            // 
            this.newRouteTableLabel.AutoSize = true;
            this.newRouteTableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newRouteTableLabel.Location = new System.Drawing.Point(52, 190);
            this.newRouteTableLabel.Name = "newRouteTableLabel";
            this.newRouteTableLabel.Size = new System.Drawing.Size(137, 29);
            this.newRouteTableLabel.TabIndex = 5;
            this.newRouteTableLabel.Text = "New Route";
            this.newRouteTableLabel.Visible = false;
            this.newRouteTableLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // availableNavPointsTableLabel
            // 
            this.availableNavPointsTableLabel.AutoSize = true;
            this.availableNavPointsTableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableNavPointsTableLabel.Location = new System.Drawing.Point(52, 490);
            this.availableNavPointsTableLabel.Name = "availableNavPointsTableLabel";
            this.availableNavPointsTableLabel.Size = new System.Drawing.Size(247, 29);
            this.availableNavPointsTableLabel.TabIndex = 6;
            this.availableNavPointsTableLabel.Text = "Available Nav Points";
            this.availableNavPointsTableLabel.Visible = false;
            // 
            // addAnchorToNewRouteBtn
            // 
            this.addAnchorToNewRouteBtn.Location = new System.Drawing.Point(585, 783);
            this.addAnchorToNewRouteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addAnchorToNewRouteBtn.Name = "addAnchorToNewRouteBtn";
            this.addAnchorToNewRouteBtn.Size = new System.Drawing.Size(75, 23);
            this.addAnchorToNewRouteBtn.TabIndex = 7;
            this.addAnchorToNewRouteBtn.Text = "Add";
            this.addAnchorToNewRouteBtn.UseVisualStyleBackColor = true;
            this.addAnchorToNewRouteBtn.Visible = false;
            this.addAnchorToNewRouteBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.addAnchorToNewRouteBtn_MouseUp);
            // 
            // removeAnchorFromNewRouteBtn
            // 
            this.removeAnchorFromNewRouteBtn.Location = new System.Drawing.Point(585, 481);
            this.removeAnchorFromNewRouteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeAnchorFromNewRouteBtn.Name = "removeAnchorFromNewRouteBtn";
            this.removeAnchorFromNewRouteBtn.Size = new System.Drawing.Size(75, 23);
            this.removeAnchorFromNewRouteBtn.TabIndex = 8;
            this.removeAnchorFromNewRouteBtn.Text = "Remove";
            this.removeAnchorFromNewRouteBtn.UseVisualStyleBackColor = true;
            this.removeAnchorFromNewRouteBtn.Visible = false;
            this.removeAnchorFromNewRouteBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.removeAnchorFromNewRouteBtn_MouseUp);
            // 
            // saveNewRouteBtn
            // 
            this.saveNewRouteBtn.Location = new System.Drawing.Point(504, 481);
            this.saveNewRouteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveNewRouteBtn.Name = "saveNewRouteBtn";
            this.saveNewRouteBtn.Size = new System.Drawing.Size(75, 23);
            this.saveNewRouteBtn.TabIndex = 9;
            this.saveNewRouteBtn.Text = "Save";
            this.saveNewRouteBtn.UseVisualStyleBackColor = true;
            this.saveNewRouteBtn.Visible = false;
            this.saveNewRouteBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.saveNewRouteBtn_MouseUp);
            // 
            // updateAnchorBtn
            // 
            this.updateAnchorBtn.Location = new System.Drawing.Point(504, 782);
            this.updateAnchorBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updateAnchorBtn.Name = "updateAnchorBtn";
            this.updateAnchorBtn.Size = new System.Drawing.Size(75, 23);
            this.updateAnchorBtn.TabIndex = 10;
            this.updateAnchorBtn.Text = "Update";
            this.updateAnchorBtn.UseVisualStyleBackColor = true;
            this.updateAnchorBtn.Visible = false;
            this.updateAnchorBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.updateAnchorBtn_MouseUp);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(423, 481);
            this.loadBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 11;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Visible = false;
            this.loadBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.loadBtn_MouseUp);
            // 
            // experienceTable
            // 
            this.experienceTable.AllowUserToAddRows = false;
            this.experienceTable.AllowUserToDeleteRows = false;
            this.experienceTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.experienceTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.experienceTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.newExpChkboxCol,
            this.newExpNameCol,
            this.newExpTypeCol,
            this.newExpUserAccessCol});
            this.experienceTable.Location = new System.Drawing.Point(57, 230);
            this.experienceTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.experienceTable.Name = "experienceTable";
            this.experienceTable.ReadOnly = true;
            this.experienceTable.RowHeadersWidth = 51;
            this.experienceTable.RowTemplate.Height = 24;
            this.experienceTable.Size = new System.Drawing.Size(615, 256);
            this.experienceTable.TabIndex = 12;
            this.experienceTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.experienceTable_CellValueChanged);
            // 
            // newExpChkboxCol
            // 
            this.newExpChkboxCol.FillWeight = 50F;
            this.newExpChkboxCol.HeaderText = "";
            this.newExpChkboxCol.MinimumWidth = 6;
            this.newExpChkboxCol.Name = "newExpChkboxCol";
            this.newExpChkboxCol.ReadOnly = true;
            this.newExpChkboxCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.newExpChkboxCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.newExpChkboxCol.Width = 50;
            // 
            // newExpNameCol
            // 
            this.newExpNameCol.HeaderText = "Name";
            this.newExpNameCol.MaxInputLength = 100;
            this.newExpNameCol.MinimumWidth = 6;
            this.newExpNameCol.Name = "newExpNameCol";
            this.newExpNameCol.ReadOnly = true;
            this.newExpNameCol.Width = 125;
            // 
            // newExpTypeCol
            // 
            this.newExpTypeCol.HeaderText = "Type";
            this.newExpTypeCol.MinimumWidth = 6;
            this.newExpTypeCol.Name = "newExpTypeCol";
            this.newExpTypeCol.ReadOnly = true;
            this.newExpTypeCol.Width = 125;
            // 
            // newExpUserAccessCol
            // 
            this.newExpUserAccessCol.HeaderText = "User Access";
            this.newExpUserAccessCol.MinimumWidth = 6;
            this.newExpUserAccessCol.Name = "newExpUserAccessCol";
            this.newExpUserAccessCol.ReadOnly = true;
            this.newExpUserAccessCol.Width = 125;
            // 
            // experienceLabel
            // 
            this.experienceLabel.AutoSize = true;
            this.experienceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.experienceLabel.Location = new System.Drawing.Point(52, 199);
            this.experienceLabel.Name = "experienceLabel";
            this.experienceLabel.Size = new System.Drawing.Size(196, 29);
            this.experienceLabel.TabIndex = 13;
            this.experienceLabel.Text = "New Experience";
            // 
            // experienceLoadBtn
            // 
            this.experienceLoadBtn.Location = new System.Drawing.Point(435, 490);
            this.experienceLoadBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.experienceLoadBtn.Name = "experienceLoadBtn";
            this.experienceLoadBtn.Size = new System.Drawing.Size(75, 23);
            this.experienceLoadBtn.TabIndex = 14;
            this.experienceLoadBtn.Text = "Load";
            this.experienceLoadBtn.UseVisualStyleBackColor = true;
            this.experienceLoadBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.experienceLoadBtn_MouseUp);
            // 
            // experienceSaveBtn
            // 
            this.experienceSaveBtn.Location = new System.Drawing.Point(516, 490);
            this.experienceSaveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.experienceSaveBtn.Name = "experienceSaveBtn";
            this.experienceSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.experienceSaveBtn.TabIndex = 15;
            this.experienceSaveBtn.Text = "Save";
            this.experienceSaveBtn.UseVisualStyleBackColor = true;
            this.experienceSaveBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.experienceSaveBtn_MouseUp);
            // 
            // experienceRemoveBtn
            // 
            this.experienceRemoveBtn.Location = new System.Drawing.Point(597, 490);
            this.experienceRemoveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.experienceRemoveBtn.Name = "experienceRemoveBtn";
            this.experienceRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.experienceRemoveBtn.TabIndex = 16;
            this.experienceRemoveBtn.Text = "Remove";
            this.experienceRemoveBtn.UseVisualStyleBackColor = true;
            this.experienceRemoveBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.experienceRemoveBtn_MouseUp);
            // 
            // availableExpItems
            // 
            this.availableExpItems.AllowUserToAddRows = false;
            this.availableExpItems.AllowUserToDeleteRows = false;
            this.availableExpItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availableExpItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.availExpChkboxCol,
            this.availExpNameCol,
            this.availExpTypeCol,
            this.availExpUserAccessCol});
            this.availableExpItems.Location = new System.Drawing.Point(57, 521);
            this.availableExpItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.availableExpItems.Name = "availableExpItems";
            this.availableExpItems.ReadOnly = true;
            this.availableExpItems.RowHeadersWidth = 51;
            this.availableExpItems.RowTemplate.Height = 24;
            this.availableExpItems.Size = new System.Drawing.Size(615, 258);
            this.availableExpItems.TabIndex = 17;
            // 
            // availExpChkboxCol
            // 
            this.availExpChkboxCol.FillWeight = 50F;
            this.availExpChkboxCol.HeaderText = "";
            this.availExpChkboxCol.MinimumWidth = 6;
            this.availExpChkboxCol.Name = "availExpChkboxCol";
            this.availExpChkboxCol.ReadOnly = true;
            this.availExpChkboxCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.availExpChkboxCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.availExpChkboxCol.Width = 50;
            // 
            // availExpNameCol
            // 
            this.availExpNameCol.HeaderText = "Name";
            this.availExpNameCol.MaxInputLength = 100;
            this.availExpNameCol.MinimumWidth = 6;
            this.availExpNameCol.Name = "availExpNameCol";
            this.availExpNameCol.ReadOnly = true;
            this.availExpNameCol.Width = 125;
            // 
            // availExpTypeCol
            // 
            this.availExpTypeCol.HeaderText = "Type";
            this.availExpTypeCol.MinimumWidth = 6;
            this.availExpTypeCol.Name = "availExpTypeCol";
            this.availExpTypeCol.ReadOnly = true;
            this.availExpTypeCol.Width = 125;
            // 
            // availExpUserAccessCol
            // 
            this.availExpUserAccessCol.HeaderText = "User Access";
            this.availExpUserAccessCol.MinimumWidth = 6;
            this.availExpUserAccessCol.Name = "availExpUserAccessCol";
            this.availExpUserAccessCol.ReadOnly = true;
            this.availExpUserAccessCol.Width = 125;
            // 
            // addExpItemBtn
            // 
            this.addExpItemBtn.Location = new System.Drawing.Point(597, 782);
            this.addExpItemBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addExpItemBtn.Name = "addExpItemBtn";
            this.addExpItemBtn.Size = new System.Drawing.Size(75, 23);
            this.addExpItemBtn.TabIndex = 19;
            this.addExpItemBtn.Text = "Add";
            this.addExpItemBtn.UseVisualStyleBackColor = true;
            this.addExpItemBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.addExpItemBtn_MouseUp);
            // 
            // availableExpItemsLabel
            // 
            this.availableExpItemsLabel.AutoSize = true;
            this.availableExpItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableExpItemsLabel.Location = new System.Drawing.Point(52, 490);
            this.availableExpItemsLabel.Name = "availableExpItemsLabel";
            this.availableExpItemsLabel.Size = new System.Drawing.Size(186, 29);
            this.availableExpItemsLabel.TabIndex = 20;
            this.availableExpItemsLabel.Text = "Available Items";
            // 
            // MainExperienceCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 955);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.experienceTable);
            this.Controls.Add(this.experienceSaveBtn);
            this.Controls.Add(this.addExpItemBtn);
            this.Controls.Add(this.availableExpItemsLabel);
            this.Controls.Add(this.experienceLabel);
            this.Controls.Add(this.newRouteTable);
            this.Controls.Add(this.saveNewRouteBtn);
            this.Controls.Add(this.availableExpItems);
            this.Controls.Add(this.availableNavPointsTableLabel);
            this.Controls.Add(this.newRouteTableLabel);
            this.Controls.Add(this.updateAnchorBtn);
            this.Controls.Add(this.addAnchorToNewRouteBtn);
            this.Controls.Add(this.availableNavPointsTable);
            this.Controls.Add(this.experienceRemoveBtn);
            this.Controls.Add(this.removeAnchorFromNewRouteBtn);
            this.Controls.Add(this.experienceLoadBtn);
            this.Controls.Add(this.loadBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainExperienceCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAARS Experience Creator";
            this.Load += new System.EventHandler(this.MainExperienceCreator_Load);
            this.Shown += new System.EventHandler(this.MainExperienceCreator_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.newRouteTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableNavPointsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.experienceTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableExpItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab experienceTab;
        private System.Windows.Forms.RibbonTab loadAnimations;
        private System.Windows.Forms.RibbonTab RoutesTab;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel newExperiencePanel;
        private System.Windows.Forms.RibbonTab viewActiveUsers;
        private System.Windows.Forms.RibbonPanel newAnimationPanel;
        private System.Windows.Forms.RibbonPanel newRoutePanel;
        private System.Windows.Forms.RibbonPanel loadRoutePanel;
        private System.Windows.Forms.RibbonPanel loadAnimationPanel;
        private System.Windows.Forms.RibbonPanel loadExperiencePanel;
        private System.Windows.Forms.RibbonPanel createNewUser;
        private System.Windows.Forms.RibbonPanel viewUsers;
        public System.Windows.Forms.DataGridView newRouteTable;
        public System.Windows.Forms.Label newRouteTableLabel;
        private System.Windows.Forms.Label availableNavPointsTableLabel;
        public System.Windows.Forms.DataGridView availableNavPointsTable;
        private System.Windows.Forms.Button addAnchorToNewRouteBtn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn addBtns;
        private System.Windows.Forms.DataGridViewTextBoxColumn availableNavPointsNavPointName;
        private System.Windows.Forms.DataGridViewTextBoxColumn anchorDataFromAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn anchorLocationFromAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn anchorExpirationFromAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn anchorDescriptionFromAvailable;
        private System.Windows.Forms.Button removeAnchorFromNewRouteBtn;
        private System.Windows.Forms.Button saveNewRouteBtn;
        private System.Windows.Forms.Button updateAnchorBtn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn routeAnchorsForRemovalChkboxesCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NavPointNameColumnFromNewRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn anchorDataFromNewRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn anchorLocationFromNewRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn newRouteAnchorExpiration;
        private System.Windows.Forms.DataGridViewTextBoxColumn anchorDescriptionFromNewRoute;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.RibbonButton saveRibbonBtn;
        private System.Windows.Forms.RibbonButton delRouteRibbnBtn;
        private System.Windows.Forms.RibbonButton updateRouteNotes;
        private System.Windows.Forms.RibbonButton showHideRibbonBtn;
        private System.Windows.Forms.RibbonButton sortRibbonBtn;
        private System.Windows.Forms.RibbonButton filterRibbonBtn;
        public System.Windows.Forms.DataGridView experienceTable;
        public System.Windows.Forms.Label experienceLabel;
        public System.Windows.Forms.Button experienceLoadBtn;
        private System.Windows.Forms.Button experienceSaveBtn;
        private System.Windows.Forms.Button experienceRemoveBtn;
        public System.Windows.Forms.DataGridView availableExpItems;
        private System.Windows.Forms.Button addExpItemBtn;
        private System.Windows.Forms.Label availableExpItemsLabel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn availExpChkboxCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn availExpNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn availExpTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn availExpUserAccessCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn newExpChkboxCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn newExpNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn newExpTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn newExpUserAccessCol;
    }
}

