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
    public partial class SaveRouteDlg : Form
    {
        MainExperienceCreator parentForm;
        public SaveRouteDlg(MainExperienceCreator parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public async Task<bool> checkIfRouteExists(string routeName)
        {
            try
            {
                string BaseSharingUrl = "https://sharingservice20200308094713.azurewebsites.net" + "/api/routes/" + routeName;


                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/routes/" + routeName);

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

        public async void saveBtnClickedHelper()
        {
            bool exists = await checkIfRouteExists(this.newRouteNameTxtbox.Text);
            // If Route Exists, prompt user to override
            if (exists == true)
            {
                // IF user OK's override,
                // Get Name from Textbox and save route to database
                DialogResult result = MessageBox.Show("Route " + this.newRouteNameTxtbox.Text + "Already Exists in Database. Override?", "Override?",
         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    this.parentForm.saveNewRoute(this.newRouteNameTxtbox.Text);
                    DialogResult dialogRes = MessageBox.Show("Route " + this.newRouteNameTxtbox.Text + " has been saved", "Saved",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogRes == DialogResult.OK)
                    {
                        parentForm.clearNewRouteTable();
                        this.Close();
                        return;
                    }
                }
                return;
            }
            else
            {
                this.parentForm.saveNewRoute(this.newRouteNameTxtbox.Text);
                DialogResult result = MessageBox.Show("Route " + this.newRouteNameTxtbox.Text + " has been saved", "Saved",
         MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    parentForm.clearNewRouteTable();
                    //this.parentForm.TopLevel = true;
                    //this.TopLevel = false;
                    this.Close();
                    return;
                }
            }
        }

        private void saveNewRouteOkBtn_MouseUp(object sender, MouseEventArgs e)
        {
            saveBtnClickedHelper();
        }

        private void saveNewRouteCancelBtn_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
