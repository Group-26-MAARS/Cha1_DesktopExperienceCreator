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
    public partial class DeleteRouteDlg : Form
    {
        MainExperienceCreator parentForm;
        public DeleteRouteDlg(MainExperienceCreator parent)
        {
            InitializeComponent();
            fillComboboxWithRoutes();
            this.parentForm = parent;
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
            if (this.comboBox1.Items.Count > 0)
                this.comboBox1.SelectedIndex = 0;
            // myThread.Abort();
            // myThread.Join();

            LoadingForm.setAbort();

        }

        public async Task<bool> delRoute(string routeName)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/routes/remove/" + routeName);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return true;
        }

        private async void saveNewRouteOkBtn_MouseUp(object sender, MouseEventArgs e)
        {
            // If no routes exist, don't allow "delete"
            if (this.comboBox1.Items.Count == 0)
            {
                MessageBox.Show("Cannot Delete. No Routes Exist", "Deleted",
     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedRouteNameForDeletion = this.comboBox1.SelectedItem.ToString().Replace(" ", "");
            delRoute(selectedRouteNameForDeletion);
            DialogResult result = MessageBox.Show("Route " + selectedRouteNameForDeletion +
            " has been deleted", "Deleted",
     MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Close();
                return;
            }
        }

        private void saveNewRouteCancelBtn_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
