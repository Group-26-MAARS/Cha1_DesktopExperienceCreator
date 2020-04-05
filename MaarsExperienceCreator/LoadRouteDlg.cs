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
    public partial class LoadRouteDlg : Form
    {
        MainExperienceCreator parentForm;
        public LoadRouteDlg(MainExperienceCreator parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            fillComboboxWithRoutes();
            this.Show();

        }
        public void fillComboboxWithRoutes()
        {

            HttpClient c = new HttpClient();
            Task<string> t = c.GetStringAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/routes/all");

            var result = string.Join(",", t.Result);
            //"[\"14 : 24, 28, 11\",\"15 : 24, 28, 11\",\"YetAnotherRouteName : 24, 28, 33\",\"FirstRealRoute : 3\",\"stuff : 1\",\"something : 4, 5\",\"Something : 4\"]"

            Console.WriteLine(result);
            string[] stringArray = result.Split('\"');
            List<string> listForCombobox = new List<string>();
            foreach (string currStr in stringArray)
            {
                if (currStr.Contains(":"))
                    this.comboBox1.Items.Add(currStr.Split(':')[0]);
            }
            this.comboBox1.SelectedIndex = 0;
        }

        private void cancelBtn_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private async void loadBtn_MouseUp(object sender, MouseEventArgs e)
        {
       // ["4:b8bd3801-4863-4123-8c75-5f1276f7e751:44435::Some Description","7:7c005465-f89d-4342-92af-7bcbc7c2ce33:lastlocfor58::","test0:40kjl3kht:AtUCF:12-20-20:this is the first anchor in the newerer form"]

        // Load Selected Route
        // Get Name of Route
        string routeName = (string)this.comboBox1.SelectedItem;

            // Get All of the Anchors for that Route
            HttpClient c = new HttpClient();
            Task<string> allAnchorsAndInfo = c.GetStringAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/anchors/allForRoute/" +routeName);

            // Populate the table
            Console.WriteLine(allAnchorsAndInfo.Result);
            string[] outStrArray = allAnchorsAndInfo.Result.Replace("\"","").Replace("[", "").Replace("]", "").Split(',');
            parentForm.clearNewRouteTable();
            for (int i = 0; i < outStrArray.Length; i++)
            {
                List<string> outList = new List<string>();

                outList.Add(outStrArray[i].Split(':')[0]);
                outList.Add(outStrArray[i].Split(':')[1]);
                outList.Add(outStrArray[i].Split(':')[2]);
                outList.Add(outStrArray[i].Split(':')[3]);
                outList.Add(outStrArray[i].Split(':')[4]);
                parentForm.addRowToCurrentRouteTable(i, outList);
          }
            parentForm.newRouteTable.Visible = true;
            //    parentForm.newRouteTable.Rows[parentForm.newRouteTable.Rows.Count - 1].Cells["routeAnchorsForRemovalChkboxesCol"].Value = false;

            this.Close();
        }
    }
}
