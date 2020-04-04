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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void newRoutePanel_MouseUp(object sender, MouseEventArgs e)
        {
            // Populate Available Anchor List with data from Cosmos:

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
                availableNavPointsTable.Rows[n].Cells["anchorLocationFromAvailable"].ReadOnly = true;
                availableNavPointsTable.Rows[n].Cells["anchorExpirationFromAvailable"].ReadOnly = true;
                availableNavPointsTable.Rows[n].Cells["anchorDescriptionFromAvailable"].ReadOnly = true;

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
        }

        private void addAnchorToNewRouteBtn_MouseUp(object sender, MouseEventArgs e)
        {
            // Add all selected rows to the new route table.
            for (int i = 0; i < this.availableNavPointsTable.Rows.Count; i++)
            {
                if (Convert.ToBoolean(availableNavPointsTable.Rows[i].Cells["addBtns"].Value) == true)
                {
                    this.newRouteTable.Rows.Add(i + 1, availableNavPointsTable.Rows[i].Cells["availableNavPointsNavPointName"].Value, "", "", "", "");
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
                string BaseSharingUrl = "https://sharingservice20200308094713.azurewebsites.net" + "/api/routes";


                HttpClient client = new HttpClient();
                var response = await client.PostAsync(BaseSharingUrl, new StringContent(routeName + ":" + testInsertionStr));
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    long ret;
                    if (long.TryParse(responseBody, out ret))
                    {
                        Console.WriteLine("Key " + ret.ToString());
                        MessageBox.Show(routeName + " has been saved to database", "Route Created",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                        return;
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


        // Clear "New Route" table
    }
}
