using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaarsExperienceCreator
{
    public partial class LoadExperienceDlg : Form
    {
        MainExperienceCreator parentForm;
        private Thread myThread;
        public LoadExperienceDlg(MainExperienceCreator parent)
        {
            // Display loading screen (create new thread for it)
            myThread = new Thread(new ThreadStart(parent.DisplayLoadingScreen));
            myThread.Start();

            InitializeComponent();
            this.parentForm = parent;
            fillComboboxWithExperienceItems();
            this.Show();
            this.parentForm.TopLevel = false;
            this.TopLevel = true;


        }
        public void fillComboboxWithExperienceItems()
        {

            HttpClient c = new HttpClient();
            Task<string> t = c.GetStringAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/experiences/all");

            var result = string.Join(",", t.Result);
            //"[\"14 : 24, 28, 11\",\"15 : 24, 28, 11\",\"YetAnotherRouteName : 24, 28, 33\",\"FirstRealRoute : 3\",\"stuff : 1\",\"something : 4, 5\",\"Something : 4\"]"

            Console.WriteLine(result);
            string[] stringArray = result.Split('\"');
            List<string> listForCombobox = new List<string>();
            foreach (string currStr in stringArray)
            {
                if (currStr.Contains(":"))
                    this.comboBox1.Items.Add(currStr.Split(':')[0].Substring(0, currStr.Split(':')[0].Length - 1));
            }
            if (this.comboBox1.Items.Count > 0)
                this.comboBox1.SelectedIndex = 0;
            // myThread.Abort();
            // myThread.Join();

            LoadingForm.setAbort();

        }

        private void cancelBtn_MouseUp(object sender, MouseEventArgs e)
        {
            this.parentForm.TopLevel = true;

            this.TopLevel = false;
            this.Close();
        }

        private async void loadBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.comboBox1.Items.Count == 0)
            {
                // If no routes exist, don't allow "delete"
                if (this.comboBox1.Items.Count == 0)
                {
                    MessageBox.Show("Cannot Load. No Routes Exist", "No Experiences Exist",
         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            myThread = new Thread(new ThreadStart(parentForm.DisplayLoadingScreen));
            myThread.Start();

            // Load Selected Route
            // Get Name of Route
            string experienceName = (string)this.comboBox1.SelectedItem;

            // Get All of the Anchors for that Route
            HttpClient c = new HttpClient();
            Task<string> experienceItems = c.GetStringAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/experiences/" + experienceName);

            // Populate the table
            Console.WriteLine(experienceItems.Result);
            string[] outStrArray = experienceItems.Result.Replace(" ","").Split(',');
            parentForm.clearAvailableExperienceItems();
            for (int i = 0; i < outStrArray.Length; i++)
            {
                List<string> outList = new List<string>();

                outList.Add(outStrArray[i]);
                if (outStrArray[i][0] == 'R')
                {
                    outList.Add("Route");
                }
                else if(outStrArray[i][0] == 'A')
                {
                    outList.Add("Assembly");
                }
                parentForm.addRowToCurrentExperienceTable(i, outList);
          }
            parentForm.experienceTable.Visible = true;
            parentForm.experienceTable.ReadOnly = true; // Don't allow edits
                                                      //    parentForm.newRouteTable.Rows[parentForm.newRouteTable.Rows.Count - 1].Cells["routeAnchorsForRemovalChkboxesCol"].Value = false;
            parentForm.experienceLabel.Text = "Loaded Experience";
            parentForm.experienceLoadBtn.Text = "New";

            LoadingForm.setAbort();

            this.parentForm.TopLevel = true;

            this.TopLevel = false;
            this.Close();
        }
    }
}
