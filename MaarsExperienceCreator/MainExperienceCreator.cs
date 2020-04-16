using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace MaarsExperienceCreator
{
    public partial class MainExperienceCreator : Form
    {
        delegate void MyDelegate();
        public MainExperienceCreator()
        {
            InitializeComponent();
            this.BringToFront();

            createNewRouteHeaderCheckbox();
        }
        public void createNewRouteHeaderCheckbox()
        {
            // Creating checkbox without panel
            newRouteHeaderCheckbox = new CheckBox();
            newRouteHeaderCheckbox.Size = new System.Drawing.Size(15, 15);
            newRouteHeaderCheckbox.BackColor = Color.Transparent;

            // Reset properties
            newRouteHeaderCheckbox.Padding = new Padding(0);
            newRouteHeaderCheckbox.Margin = new Padding(0);
            newRouteHeaderCheckbox.Text = "";

            // Add checkbox to datagrid cell
            this.newRouteTable.Controls.Add(newRouteHeaderCheckbox);
            DataGridViewHeaderCell header = newRouteTable.Columns[0].HeaderCell;
            newRouteHeaderCheckbox.Location = new Point(
                70,
                5
            );
            newRouteHeaderCheckbox.CheckStateChanged += new System.EventHandler(this.newRouteHeaderCheckbox_CheckStateChanged);
        }
        private CheckBox myHeaderChkbox;
        private CheckBox newRouteHeaderCheckbox;

        enum RouteUIState
        {
            newRoute,
            loadRoute,
            notActive
        }
        enum ExperienceUIState
        {
            newExperience,
            loadExperience,
            notActive
        }

        private RouteUIState uiState;
        private ExperienceUIState experienceUIState;

        private bool newRouteTableModified;
        public bool NewRouteTableModified
        {
            get { return newRouteTableModified; }
            set { newRouteTableModified = value; }
        }

        private bool newExperienceTableModified;
        public bool NewExperienceTableModified
        {
            get { return newExperienceTableModified; }
            set { newExperienceTableModified = value; }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void clearNewRouteTable()
        {
            this.NewRouteTableModified = false;
            this.getNewTableView().Rows.Clear();
        }

        public void addRowToCurrentRouteTable(int rowNbr, List<string> currentStr)
        {
            this.newRouteTable.Rows.Add(rowNbr + 1, currentStr[0], currentStr[1], currentStr[2], currentStr[3], currentStr[4]);
            newRouteTable.Rows[rowNbr].Cells["NavPointNameColumnFromNewRoute"].ReadOnly = true;
            newRouteTable.Rows[rowNbr].Cells["anchorDataFromNewRoute"].ReadOnly = true;
            newRouteTable.Rows[rowNbr].Cells["anchorLocationFromNewRoute"].ReadOnly = true;
            newRouteTable.Rows[rowNbr].Cells["NavPointNameColumnFromNewRoute"].ReadOnly = true;
            newRouteTable.Rows[rowNbr].Cells["anchorDescriptionFromNewRoute"].ReadOnly = true;
        }
        public void addRowToCurrentExperienceTable(int rowNbr, List<string> currentStr)
        {
            this.experienceTable.Rows.Add(false, currentStr[0], currentStr[1], "");
            experienceTable.Rows[rowNbr].Cells["newExpChkboxCol"].ReadOnly = false;
            experienceTable.Rows[rowNbr].Cells["newExpNameCol"].ReadOnly = true;
            experienceTable.Rows[rowNbr].Cells["newExpTypeCol"].ReadOnly = true;
            experienceTable.Rows[rowNbr].Cells["newExpUserAccessCol"].ReadOnly = true;
        }

        private void newRoutePanel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        public void DisplayLoadingScreen()
        {
            LoadingForm loadingForm = new LoadingForm();
        }
        public void clearAvailableExperienceItems()
        {
            this.NewExperienceTableModified = false;
            this.experienceTable.Rows.Clear();
        }
        public void setupForNewExperience()
        {
            Thread myThread = new Thread(new ThreadStart(DisplayLoadingScreen));
            myThread.Start();
            clearAvailableExperienceItems();

            HttpClient c = new HttpClient();
            Task<string> t = c.GetStringAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/routes/all");

            var result = string.Join(",", t.Result);
            Console.WriteLine(result);
            string[] routesKeyVal = result.Replace(", ", "*").Replace("[\"", "").Replace("\"]", "").Replace("\"", "").Split(',');
            availableExpItems.Visible = false;
            availableExpItems.ReadOnly = false;
            int i = 0;
            foreach (string routeStr in routesKeyVal)
            {
                string routeName = routeStr.Split(':')[0];

                this.availableExpItems.Rows.Add(false, routeName, "Route", "");
                availableExpItems.Rows[i].Cells["availExpChkboxCol"].ReadOnly = false;
                availableExpItems.Rows[i].Cells["availExpNameCol"].ReadOnly = true;
                availableExpItems.Rows[i].Cells["availExpTypeCol"].ReadOnly = true;
                availableExpItems.Rows[i].Cells["availExpUserAccessCol"].ReadOnly = true;

                i++;
            }

            Task<string> x = c.GetStringAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/animations/all");

            abortLoadingForm();

            result = string.Join(",", x.Result.Replace(":\\", "_"));

            string[] animationsKeyVal = result.Replace("[\"", "").Replace("\"]", "").Replace("\"", "").Replace(",\\", "").Split(',');
            this.availableExpItems.Visible = false;

            foreach (string animationStr in animationsKeyVal)
            {
                string animationName = animationStr.Split(':')[0].Substring(2, animationStr.Split(':')[0].Length - 2).Replace(" ", "");
                this.availableExpItems.Rows.Add(false, animationName, "Assembly", "");

            }

            availableExpItems.Visible = true;


        }
        public void abortLoadingForm()
        {
            LoadingForm.setAbort();

        }

        public void setupForNewRoute()
        {
            // Display loading screen (create new thread for it)
            Thread myThread = new Thread(new ThreadStart(DisplayLoadingScreen));
            myThread.Start();


            // Populate Available Anchor List with data from Cosmos:
            // Clear Table if not empty
            newRouteTableLabel.Text = "New Route";
            clearNewRouteTable();

            HttpClient c = new HttpClient();
            Task<string> t = c.GetStringAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/anchors/all");

            try
            {
                var result = string.Join(",", t.Result);
                Console.WriteLine(result);
                string[] stringArray = result.Split(',');
                string[] anchorsFromAPI = new string[stringArray.Length];
                // Remove the [ from the first element
                stringArray[0] = stringArray[0].Replace("[", "");
                // Remove the ] from the last element
                stringArray[stringArray.Length - 1] = stringArray[stringArray.Length - 1].Replace("]", "");
                int n = 0;
                newRouteTable.ReadOnly = false;
                if (uiState == RouteUIState.notActive)
                {


                    foreach (string currStr in stringArray)
                    {

                        anchorsFromAPI[n] = currStr.Replace("\"", "");
                        // Add to the Dattatable                
                        this.availableNavPointsTable.Rows.Add(n + 1, anchorsFromAPI[n].Split(':')[0].Trim(), anchorsFromAPI[n].Split(':')[1].Trim(), anchorsFromAPI[n].Split(':')[2].Trim(), anchorsFromAPI[n].Split(':')[3].Trim(), anchorsFromAPI[n].Split(':')[4].Trim());

                        // For Avail Navpoint Table, Set all but checkboxes to read only
                        availableNavPointsTable.ReadOnly = false;
                        availableNavPointsTable.Rows[n].Cells["addBtns"].Value = false;
                        availableNavPointsTable.Rows[n].Cells["addBtns"].ToolTipText = "Select for Addition to New Route";
                        availableNavPointsTable.Rows[n].Cells["availableNavPointsNavPointName"].ReadOnly = true;
                        availableNavPointsTable.Rows[n].Cells["anchorDataFromAvailable"].ReadOnly = true;
                        availableNavPointsTable.Rows[n].Cells["anchorExpirationFromAvailable"].ReadOnly = true;

                        // Default the checkboxes to false
                        //    availableNavPointsTable.EditMode = DataGridViewEditMode.EditOnEnter;
                        // Only should do this when adding the new row

                        n++;
                    }
                    // Creating checkbox without panel
                    myHeaderChkbox = new CheckBox();
                    myHeaderChkbox.Size = new System.Drawing.Size(15, 15);
                    myHeaderChkbox.BackColor = Color.Transparent;

                    // Reset properties
                    myHeaderChkbox.Padding = new Padding(0);
                    myHeaderChkbox.Margin = new Padding(0);
                    myHeaderChkbox.Text = "";

                    // Add checkbox to datagrid cell
                    this.availableNavPointsTable.Controls.Add(myHeaderChkbox);
                    DataGridViewHeaderCell header = availableNavPointsTable.Rows[0].Cells["addBtns"].OwningColumn.HeaderCell;
                    myHeaderChkbox.Location = new Point(
                        70,
                        5
                    );
                    myHeaderChkbox.CheckStateChanged += new System.EventHandler(this.myHeaderChkbox_CheckStateChanged);

                }
            }
            catch (AggregateException e)
            {
                abortLoadingForm();

                MessageBox.Show("Unable to Connect to Database. Check Internet Connection", "No Connection",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                return;
            }

            abortLoadingForm();

            // When "Create New" is clicked under routes,
            // display the new route table and availableAnchorTable
            newRouteTable.Visible = true;
            newRouteTableLabel.Visible = true;
            availableNavPointsTableLabel.Visible = true;
            availableNavPointsTable.Visible = true;
            addAnchorToNewRouteBtn.Visible = true;
            removeAnchorFromNewRouteBtn.Visible = true;
            saveNewRouteBtn.Visible = true;
            updateAnchorBtn.Visible = true;
            loadBtn.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void newRouteHeaderCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            if (newRouteHeaderCheckbox.Checked)
            {
                // Deselect selected Rows
                // Go through Each checkbox and check them
                for (int i = 0; i < newRouteTable.Rows.Count; i++)
                {
                    if (newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].Selected == true)
                    {
                        newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].ReadOnly = true;
                        newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].Value = true;
                    }
                    newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].Value = true;
                    newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].ReadOnly = false;

                }

            }
            else
            {
                // Go through each checkbox and uncheck them
                for (int i = 0; i < newRouteTable.Rows.Count; i++)
                {
                    if (newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].Selected == true)
                    {
                        newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].ReadOnly = true;
                        newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].Value = false;


                    }
                    newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].Value = false;
                    newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].ReadOnly = false;

                }
            }
        }


        public void myHeaderChkbox_CheckStateChanged(object sender, EventArgs e)
        {
            if (myHeaderChkbox.Checked)
            {
                // Deselect selected Rows
                // Go through Each checkbox and check them
                for (int i = 0; i < availableNavPointsTable.Rows.Count; i++)
                {
                    if (availableNavPointsTable.Rows[i].Cells["addBtns"].Selected == true)
                    {
                        availableNavPointsTable.Rows[i].Cells["addBtns"].ReadOnly = true;
                        availableNavPointsTable.Rows[i].Cells["addBtns"].Value = true;
                    }
                    availableNavPointsTable.Rows[i].Cells["addBtns"].Value = true;
                    availableNavPointsTable.Rows[i].Cells["addBtns"].ReadOnly = false;

                }

            }
            else
            {
                // Go through each checkbox and uncheck them
                for (int i = 0; i < availableNavPointsTable.Rows.Count; i++)
                {
                    if (availableNavPointsTable.Rows[i].Cells["addBtns"].Selected == true)
                    {
                        availableNavPointsTable.Rows[i].Cells["addBtns"].ReadOnly = true;
                        availableNavPointsTable.Rows[i].Cells["addBtns"].Value = false;


                    }
                    availableNavPointsTable.Rows[i].Cells["addBtns"].Value = false;
                    availableNavPointsTable.Rows[i].Cells["addBtns"].ReadOnly = false;

                }
            }
        }

        private void RoutesTab_ActiveChanged(object sender, EventArgs e)
        {
            // When "Create New" loses focus (another tab is selected)
            // hid tables and labels
            if (RoutesTab.Active == true)
            {
                setupForNewRoute();
                LoadingForm.setAbort();

                uiState = RouteUIState.newRoute;

            }
            else
            {
                newRouteTable.Visible = false;
                newRouteTableLabel.Visible = false;
                availableNavPointsTable.Visible = false;
                availableNavPointsTableLabel.Visible = false;
                addAnchorToNewRouteBtn.Visible = false;
                removeAnchorFromNewRouteBtn.Visible = false;
                saveNewRouteBtn.Visible = false;
                updateAnchorBtn.Visible = false;
                loadBtn.Visible = false;
            }

        }

        public void setNewRouteTableToReadonly(int currentRow)
        {
            newRouteTable.Rows[currentRow].Cells["NavPointNameColumnFromNewRoute"].ReadOnly = true;
            newRouteTable.Rows[currentRow].Cells["anchorDataFromNewRoute"].ReadOnly = true;
            newRouteTable.Rows[currentRow].Cells["anchorLocationFromNewRoute"].ReadOnly = true;
            newRouteTable.Rows[currentRow].Cells["NavPointNameColumnFromNewRoute"].ReadOnly = true;
            newRouteTable.Rows[currentRow].Cells["anchorDescriptionFromNewRoute"].ReadOnly = true;
        }

        private void addAnchorToNewRouteBtn_MouseUp(object sender, MouseEventArgs e)
        {
            // Add all selected rows to the new route table.
            for (int i = 0; i < this.availableNavPointsTable.Rows.Count; i++)
            {
                if (Convert.ToBoolean(availableNavPointsTable.Rows[i].Cells["addBtns"].Value) == true)
                {
                    this.newRouteTable.Rows.Add(i + 1, availableNavPointsTable.Rows[i].Cells["availableNavPointsNavPointName"].Value,
                        availableNavPointsTable.Rows[i].Cells["anchorDataFromAvailable"].Value,
                        availableNavPointsTable.Rows[i].Cells["anchorLocationFromAvailable"].Value,
                        availableNavPointsTable.Rows[i].Cells["anchorExpirationFromAvailable"].Value,
                        availableNavPointsTable.Rows[i].Cells["anchorDescriptionFromAvailable"].Value);
                    newRouteTable.Rows[newRouteTable.Rows.Count - 1].Cells["routeAnchorsForRemovalChkboxesCol"].Value = false;
                    availableNavPointsTable.Rows[i].Cells["addBtns"].Value = false;
                    availableNavPointsTable.Rows[i].Cells["addBtns"].ToolTipText = "Select for Removal";

                    setNewRouteTableToReadonly(newRouteTable.Rows.Count - 1);
                }
            }
        }

        private void removeAnchorFromNewRouteBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.newRouteTable.Rows.Count == 0)
            {
                MessageBox.Show("No Anchors Exist For Removal", "No Anchors",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Information);
                return;
            }

            /* Remove the selected anchors from the "New Route" list starting from the items
            at the end */
            for (int i = this.newRouteTable.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(newRouteTable.Rows[i].Cells["routeAnchorsForRemovalChkboxesCol"].Value) == true)
                {
                    newRouteTable.Rows.RemoveAt(i);
                }
            }
        }
        public DataGridView getNewTableView()
        {
            return this.newRouteTable;
        }
        public DataGridView getNewExperienceView()
        {
            return this.experienceTable;
        }

        public async void saveNewExperience(string experienceName)
        {
            // Save Routes to the Cloud
            string testInsertionStr = "";
            // Get the list of selected items
            for (int i = 0; i < this.experienceTable.Rows.Count; i++)
            {
                if (experienceTable.Rows[i].Cells["newExpTypeCol"].Value.Equals("Route"))
                    testInsertionStr += "R_";
                else if (experienceTable.Rows[i].Cells["newExpTypeCol"].Value.Equals("Assembly"))
                    testInsertionStr += "A_";
                testInsertionStr += experienceTable.Rows[i].Cells["newExpNameCol"].Value + ", ";
            }
            if (testInsertionStr.Length - 2 >= 0)
                testInsertionStr = testInsertionStr.Substring(0, testInsertionStr.Length - 2);
            try
            {
                string BaseSharingUrl = "https://sharingservice20200308094713.azurewebsites.net";


                HttpClient client = new HttpClient();
                var response = await client.PostAsync(BaseSharingUrl + "/api/experiences", new StringContent(experienceName + ":" + testInsertionStr));
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    long ret;
                    if (long.TryParse(responseBody, out ret))
                    {
                        Console.WriteLine("Key " + ret.ToString());
                        DialogResult result = MessageBox.Show(experienceName + " has been saved to database", "Route Created",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to store the route key. Failed to parse the response body to a long: {responseBody}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to store the route key: {response.StatusCode} {response.ReasonPhrase}.");
                }

                Console.WriteLine($"Failed to store the route key: {testInsertionStr}.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($"Failed to store the route key: {testInsertionStr}.");
                return;
            }
        }

        public async void saveNewRoute(string routeName)
        {
            // Save Routes to the Cloud
            string testInsertionStr = "";
            // Get the list of selected items
            for (int i = 0; i < this.newRouteTable.Rows.Count; i++)
            {
                testInsertionStr += newRouteTable.Rows[i].Cells["NavPointNameColumnFromNewRoute"].Value + ", ";
            }
            if (testInsertionStr.Length - 2 >= 0)
                testInsertionStr = testInsertionStr.Substring(0, testInsertionStr.Length - 2);
            try
            {
                string BaseSharingUrl = "https://sharingservice20200308094713.azurewebsites.net";


                HttpClient client = new HttpClient();
                var response = await client.PostAsync(BaseSharingUrl + "/api/routes", new StringContent(routeName + ":" + testInsertionStr));
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    long ret;
                    if (long.TryParse(responseBody, out ret))
                    {
                        Console.WriteLine("Key " + ret.ToString());
                        DialogResult result = MessageBox.Show(routeName + " has been saved to database", "Route Created",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to store the route key. Failed to parse the response body to a long: {responseBody}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to store the route key: {response.StatusCode} {response.ReasonPhrase}.");
                }

                Console.WriteLine($"Failed to store the route key: {testInsertionStr}.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($"Failed to store the route key: {testInsertionStr}.");
                return;
            }
        }

        public async void saveBtnHelper()
        {
            if (this.newRouteTable.Rows.Count == 0)
            {
                MessageBox.Show("No Anchors Exist For This Route. Please Add anchors.", "No Anchors",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Information);
                return;
            }
            // Add modal or message box prompting user for name to save
            SaveRouteDlg saveRouteDlg = new SaveRouteDlg(this);
        }

        private void saveNewRouteBtn_MouseUp(object sender, MouseEventArgs e)
        {
            saveBtnHelper();
        }

        private void ribbon2_Click(object sender, EventArgs e)
        {

        }

        public async Task<bool> updateAnchors(List<DataGridViewRow> rowList)
        {
            bool status = true;
            foreach (DataGridViewRow gridRow in rowList)
            {
                // Save Routes to the Cloud
                string testInsertionStr = "";
                // Get the list of selected items

                testInsertionStr += gridRow.Cells["anchorDataFromAvailable"].Value + ":" +
                    gridRow.Cells["availableNavPointsNavPointName"].Value + ":" +
                    gridRow.Cells["anchorLocationFromAvailable"].Value + ":" +
                    gridRow.Cells["anchorExpirationFromAvailable"].Value + ":" +
                    gridRow.Cells["anchorDescriptionFromAvailable"].Value;
                //tempStr = "40kjl3kht:test0:AtUCF:12-20-20:this is the first anchor in the newerer form";
                try
                {
                    string BaseSharingUrl = "https://sharingservice20200308094713.azurewebsites.net";


                    HttpClient client = new HttpClient();
                    var response = await client.PostAsync(BaseSharingUrl + "/api/anchors", new StringContent(testInsertionStr));
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        long ret;
                        if (long.TryParse(responseBody, out ret))
                        {
                        }
                        else
                        {
                            Console.WriteLine($"Failed to store the route key. Failed to parse the response body to a long: {responseBody}.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to store the route key: {response.StatusCode} {response.ReasonPhrase}.");
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine($"Failed to store the route key: {testInsertionStr}.");
                    return false;
                }
            }
            return true;
        }

        private async void updateAnchorBtn_MouseUp(object sender, MouseEventArgs e)
        {
            // Go through list of selected rows
            // Prompt user that the following anchors will be updated
            // If they confirm, update all items of the list
            List<DataGridViewRow> rowList = new List<DataGridViewRow>();
            string selectedAnchorNames = "";
            for (int i = 0; i < this.availableNavPointsTable.Rows.Count; i++)
            {
                if (Convert.ToBoolean(availableNavPointsTable.Rows[i].Cells[0].Selected == true) || Convert.ToBoolean(availableNavPointsTable.Rows[i].Cells[1].Selected == true)
                    || Convert.ToBoolean(availableNavPointsTable.Rows[i].Cells[2].Selected == true) || Convert.ToBoolean(availableNavPointsTable.Rows[i].Cells[3].Selected == true) ||
                    Convert.ToBoolean(availableNavPointsTable.Rows[i].Cells[4].Selected == true))
                {
                    rowList.Add(availableNavPointsTable.Rows[i]);
                    selectedAnchorNames += availableNavPointsTable.Rows[i].Cells["availableNavPointsNavPointName"].Value.ToString() + ", ";
                }
                // Clear "New Route" table
            }
            if (rowList.Count > 0)
            {
                selectedAnchorNames = selectedAnchorNames.Substring(0, selectedAnchorNames.Length - 2);
                // Get Name from Textbox and save route to database
                DialogResult result = MessageBox.Show("You have Selected the following Anchors for Update:\n" + selectedAnchorNames + "\nIs this correct?", "Verify Update",
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    // Update the selected Anchors
                    bool updateStatus = await updateAnchors(rowList);
                    if (updateStatus)
                    {
                        MessageBox.Show(selectedAnchorNames + (rowList.Count > 1 ? " have" : " has") + " been updated", (rowList.Count > 1 ? "Anchors" : "Anchor") + " Updated",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Anchors Selected", "Invalid Selection",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void loadRoute()
        {
            if (getNewTableView().Rows.Count > 0)
            {
                // Prompt user (ask if they want to save ()
                if (this.NewRouteTableModified)
                {
                    DialogResult result = MessageBox.Show("New Route been modified. Would you like to save?", "Save Results",
                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Save Before Entering the Loading Panel
                        SaveRouteDlg saveRouteDlg = new SaveRouteDlg(this);
                    }
                    // Clear New Route Table
                    clearNewRouteTable();
                }
            }
            else
                this.clearNewRouteTable();
            // Replace the "New Route" Text with "Load Route" Text
            // Add a child window for loading a route from the DB
            newRouteTableLabel.Text = "Load Route";

            LoadRouteDlg loadRtDlg = new LoadRouteDlg(this);
        }

        private void loadRoutePanel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void newRouteTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Set Modified Flag True
            this.NewRouteTableModified = true;

        }

        private void loadBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (uiState == RouteUIState.newRoute)
            {
                loadRoute();
                loadBtn.Text = "New Route";
                uiState = RouteUIState.loadRoute;
            }
            else if (uiState == RouteUIState.loadRoute)
            {
                setupForNewRoute();
                loadBtn.Text = "Load Route";
                newRouteTableLabel.Text = "New Route";
                uiState = RouteUIState.newRoute;

            }
        }

        private void saveRibbonBtn_MouseUp(object sender, MouseEventArgs e)
        {
            saveBtnHelper();
        }

        private void MainExperienceCreator_Load(object sender, EventArgs e)
        {

        }


        private void delRouteRibbnBtn_MouseUp(object sender, MouseEventArgs e)
        {
            // Bring up dialog to delete specified route
            DeleteRouteDlg deleteRouteDlg = new DeleteRouteDlg(this);

        }

        private void showHideRibbonBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ShowHideColumns showHideColumns = new ShowHideColumns();

        }

        private void loadAnimationPanel_MouseUp(object sender, MouseEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.InitialDirectory = $"C:\\Users\\{System.Environment.GetEnvironmentVariable("UserName")}\\Documents"; //\\VuforiaStudio\\Projects";

                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }

        public void hideExperienceUI()
        {
            experienceTable.Visible = false;
            experienceLoadBtn.Visible = false;
            experienceSaveBtn.Visible = false;
            experienceRemoveBtn.Visible = false;
            experienceLabel.Visible = false;


            availableExpItems.Visible = false;
            availableExpItemsLabel.Visible = false;
            addExpItemBtn.Visible = false;
        }
        public void showExperienceUI()
        {

            experienceTable.Visible = true;
            experienceLoadBtn.Visible = true;
            experienceSaveBtn.Visible = true;
            experienceRemoveBtn.Visible = true;
            experienceLabel.Visible = true;

            availableExpItems.Visible = true;
            availableExpItemsLabel.Visible = true;
            addExpItemBtn.Visible = true;


        }

        private void experienceTab_ActiveChanged(object sender, EventArgs e)
        {
            if (experienceTab.Active == true)
            {
                // Make Experience Tables and buttons hidden
                setupForNewExperience();
                /*
                var md = new MyDelegate(abortLoadingForm);
                md();
                */
                showExperienceUI();
            }
            else
            {
                hideExperienceUI();
            }
        }

        public void setNewExperienceTableToReadOnly(int currentRow)
        {
            // Do not want the entire table set to read only (checkbox column)
            experienceTable.Rows[currentRow].Cells["newExpNameCol"].ReadOnly = true;
            experienceTable.Rows[currentRow].Cells["newExpTypeCol"].ReadOnly = true;
            experienceTable.Rows[currentRow].Cells["newExpUserAccessCol"].ReadOnly = true;
        }

        private void addExpItemBtn_MouseUp(object sender, MouseEventArgs e)
        {
            // Add items to "New Experience" table
            // Add all selected rows to the new route table.
            experienceTable.ReadOnly = false;

            for (int i = 0; i < this.availableExpItems.Rows.Count; i++)
            {
                if (Convert.ToBoolean(availableExpItems.Rows[i].Cells["availExpChkboxCol"].Value) == true)
                {
                    this.NewExperienceTableModified = true;

                    this.experienceTable.Rows.Add(false,
                        availableExpItems.Rows[i].Cells["availExpNameCol"].Value,
                        availableExpItems.Rows[i].Cells["availExpTypeCol"].Value,
                        availableExpItems.Rows[i].Cells["availExpUserAccessCol"].Value);

                    experienceTable.Rows[experienceTable.Rows.Count - 1].Cells["newExpChkboxCol"].Value = false;
                    availableExpItems.Rows[i].Cells["availExpChkboxCol"].Value = false;
                    availableExpItems.Rows[i].Cells["availExpChkboxCol"].ToolTipText = "Select for Removal";

                    setNewExperienceTableToReadOnly(experienceTable.Rows.Count - 1);
                    experienceTable.Rows[experienceTable.Rows.Count - 1].Cells["newExpChkboxCol"].ReadOnly = false;
                }
            }
        }

        private void experienceSaveBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.experienceTable.Rows.Count == 0)
            {
                MessageBox.Show("No Experience Items Exist For This Route. Please Add items.", "No Items Exist",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Information);
                return;
            }
            // Add modal or message box prompting user for name to save
            SaveExpDlg saveExpDlg = new SaveExpDlg(this, false);
        }

        private void experienceRemoveBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.experienceTable.Rows.Count == 0)
            {
                MessageBox.Show("No Experience Items Exist For Removal", "No Items Exist",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Information);
                return;
            }

            /* Remove the selected anchors from the "New Route" list starting from the items
            at the end */
            for (int i = this.experienceTable.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(experienceTable.Rows[i].Cells["newExpChkboxCol"].Value) == true)
                {
                    experienceTable.Rows.RemoveAt(i);
                }
            }
        }

        public void loadExperience()
        {
            if (getNewExperienceView().Rows.Count > 0)
            {
                // Prompt user (ask if they want to save ()
                if (this.NewExperienceTableModified)
                {
                    DialogResult result = MessageBox.Show("New Experience been modified. Would you like to save?", "Save Results",
                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Save Before Entering the Loading Panel
                        SaveExpDlg saveExpDlg = new SaveExpDlg(this, true);
                    }
                }
            }
            else
            {
                clearAvailableExperienceItems();
                // Replace the "New Route" Text with "Load Route" Text
                // Add a child window for loading a route from the DB
                experienceLabel.Text = "Load Experience";

                LoadExperienceDlg loadExpDlg = new LoadExperienceDlg(this);
            }
        }

        private void experienceLoadBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (experienceUIState == ExperienceUIState.newExperience)
            {
                loadExperience(); // fix this
                experienceUIState = ExperienceUIState.loadExperience;
            }
            else if (experienceUIState == ExperienceUIState.loadExperience)
            {
                setupForNewExperience();
                experienceLoadBtn.Text = "Load";
                experienceLabel.Text = "New Experience";
                experienceUIState = ExperienceUIState.newExperience;

            }
        }

        private void experienceTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.NewExperienceTableModified = true;
        }

        public void disableFormControls()
        {
            this.BackColor = Color.Gray;

            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }
        }

        public void enableFormControls()
        {
            this.BackColor = Color.White;

            foreach (Control control in this.Controls)
            {
                control.Enabled = true;
            }
        }

        public void allowLogin()
        {
            enableFormControls();
            uiState = RouteUIState.notActive;
            this.SendToBack();
            setupForNewExperience();
            this.BringToFront();
        }

        private void MainExperienceCreator_Shown(object sender, EventArgs e)
        {
            // change opacity
            // showl ogin screen
            MaarsExperienceLogin loginScreen = new MaarsExperienceLogin(this);


        }
    }
}
