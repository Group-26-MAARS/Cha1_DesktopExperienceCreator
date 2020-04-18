using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
            // Try to add username and hashed PW into the config
            //addDataToConfig("some stuff");

            if (validateWithConfig(this.textBox1.Text, this.maskedTextBox1.Text))
            {
                this.parentForm.allowLogin();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password", "Credentials Invalid",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }
        }

        public bool validateWithConfig(string userName, string usersPW)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Get the hashed PW from the config for the selected user
            // Go through each node of admins, if the value for the user's key matches userName, get the hashedPW from value field
            foreach (XmlNode xmlNode in xmlDoc.SelectSingleNode("//admins").ChildNodes)
            {
               
                if (xmlNode.Attributes[0].Value.Equals(userName))
                {
                    Console.WriteLine(xmlNode.Attributes[1].Value);
                    if (validatePW((usersPW), xmlNode.Attributes[1].Value))
                        return true;
                    else
                        return false;
                }
                
            }
            
            return false;
        }

        public void addDataToConfig(string inData)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            // create new node <add key="Region" value="Canterbury" />
            var nodeRegion = xmlDoc.CreateElement("add");
            nodeRegion.SetAttribute("key", "adminData");
            nodeRegion.SetAttribute("value", "Canterbury");

            xmlDoc.SelectSingleNode("//admins").AppendChild(nodeRegion);
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

        }
    }
}
