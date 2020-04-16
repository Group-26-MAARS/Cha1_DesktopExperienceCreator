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
    public partial class MaarsExperienceLogin : Form
    {
        MainExperienceCreator parentForm;
        private Thread myThread;
        public MaarsExperienceLogin(MainExperienceCreator parent)
        {
            // Display loading screen (create new thread for it)

            InitializeComponent();
            this.parentForm = parent;
            this.parentForm.disableFormControls();
            this.Show();
        }

        private static string getSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public static string hashPW(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, getSalt());
        }

        public static bool validatePW(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }


        private void cancelBtn_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void loginBtn_MouseUp(object sender, MouseEventArgs e)
        {
            // Attempt to login to Desktop application
            //   string myHash = hashPW(maskedTextBox1.Text);
            this.parentForm.allowLogin();
        }
    }
}
