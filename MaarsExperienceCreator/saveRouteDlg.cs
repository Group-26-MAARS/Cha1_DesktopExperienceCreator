using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void saveNewRouteOkBtn_MouseUp(object sender, MouseEventArgs e)
        {
            // Get Name from Textbox and save route to database
            this.parentForm.saveNewRoute(this.newRouteNameTxtbox.Text);
            this.Close();

        }

        private void saveNewRouteCancelBtn_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
