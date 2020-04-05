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

namespace MaarsExperienceCreator
{
    public partial class MainExperienceCreator : Form
    {
        public MainExperienceCreator()
        {
            InitializeComponent();
        }
        private bool newRouteTableModified;
        public bool NewRouteTableModified
        {
            get { return newRouteTableModified; }
            set { newRouteTableModified = value; }
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
        }

        private void newRoutePanel_MouseUp(object sender, MouseEventArgs e)
        {
            // Populate Available Anchor List with data from Cosmos:
            // Clear Table if not empty
            newRouteTableLabel.Text = "New Route";
            clearNewRouteTable();

            HttpClient c = new HttpClient();
            Task<string> t = c.GetStringAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/anchors/all");

            var result = string.Join(",", t.Result);

            Console.WriteLine(result);
            string[] stringArray = result.Split(',');
            string[] anchorsFromAPI = new string[stringArray.Length];
            // Remove the [ from the first element
            stringArray[0] = stringArray[0].Replace("[", "");
            // Remove the ] from the last element
            stringArray[stringArray.Length - 1] = stringArray[stringArray.Length - 1].Replace("]", "");

            int n = 0;

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
                //availableNavPointsTable.Rows[n].Cells["anchorLocationFromAvailable"].ReadOnly = true;
                availableNavPointsTable.Rows[n].Cells["anchorExpirationFromAvailable"].ReadOnly = true;
                //availableNavPointsTable.Rows[n].Cells["anchorDescriptionFromAvailable"].ReadOnly = true;

                newRouteTable.ReadOnly = false;

                // Default the checkboxes to false
                //    availableNavPointsTable.EditMode = DataGridViewEditMode.EditOnEnter;
                // Only should do this when adding the new row
                /*
                newRouteTable.Rows[n].Cells["NavPointNameColumnFromNewRoute"].ReadOnly = true;
                newRouteTable.Rows[n].Cells["anchorDataFromNewRoute"].ReadOnly = true;
                newRouteTable.Rows[n].Cells["anchorLocationFromNewRoute"].ReadOnly = true;
                newRouteTable.Rows[n].Cells["NavPointNameColumnFromNewRoute"].ReadOnly = true;
                newRouteTable.Rows[n].Cells["anchorDescriptionFromNewRoute"].ReadOnly = true;
                */


                n++;
            }

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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void viewActiveUsers_ActiveChanged(object sender, EventArgs e)
        {

        }

        private void RoutesTab_ActiveChanged(object sender, EventArgs e)
        {
            // When "Create New" loses focus (another tab is selected)
            // hid tables and labels
            newRouteTable.Visible = false;
            newRouteTableLabel.Visible = false;
            availableNavPointsTable.Visible = false;
            availableNavPointsTableLabel.Visible = false;
            addAnchorToNewRouteBtn.Visible = false;
            removeAnchorFromNewRouteBtn.Visible = false;
            saveNewRouteBtn.Visible = false;
            updateAnchorBtn.Visible = false;
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
                }
                else
                {

                }
            }
        }

        private void removeAnchorFromNewRouteBtn_MouseUp(object sender, MouseEventArgs e)
        {
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

        private async void saveNewRouteBtn_MouseUp(object sender, MouseEventArgs e)
        {
            // Add modal or message box prompting user for name to save
            SaveRouteDlg saveRouteDlg = new SaveRouteDlg(this);

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
                    var response = await client.PostAsync(BaseSharingUrl +"/api/anchors", new StringContent(testInsertionStr));
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

        private void loadRoutePanel_MouseUp(object sender, MouseEventArgs e)
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

        private void newRouteTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Set Modified Flag True
            this.NewRouteTableModified = true;

        }
    }
}
