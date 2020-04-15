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
    public partial class SaveExpDlg : Form
    {
        MainExperienceCreator parentForm;
        public SaveExpDlg(MainExperienceCreator parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public async Task<bool> checkIfRouteExists(string experienceName)
        {
            try
            {
                string BaseSharingUrl = "https://sharingservice20200308094713.azurewebsites.net" + "/api/experiences/" + experienceName;


                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://sharingservice20200308094713.azurewebsites.net" + "/api/experiences/" + experienceName);

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
            bool exists = await checkIfRouteExists(this.newExperienceNameTxtbox.Text);
            // If Route Exists, prompt user to override
            if (exists == true)
            {
                // IF user OK's override,
                // Get Name from Textbox and save route to database
                DialogResult result = MessageBox.Show("Experience " + this.newExperienceNameTxtbox.Text + "Already Exists in Database. Override?", "Override?",
         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    this.parentForm.saveNewExperience(this.newExperienceNameTxtbox.Text);
                    DialogResult dialogRes = MessageBox.Show("Experience " + this.newExperienceNameTxtbox.Text + " has been saved", "Saved",
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
                this.parentForm.saveNewExperience(this.newExperienceNameTxtbox.Text);
                DialogResult result = MessageBox.Show("Route " + this.newExperienceNameTxtbox.Text + " has been saved", "Saved",
         MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    parentForm.clearNewRouteTable();
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
