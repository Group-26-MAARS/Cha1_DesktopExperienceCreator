using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MaarsExperienceCreator
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            circularProgressBar1.ForeColor = Color.Black;
            this.Show();
            this.Visible = true;
            UpdateTicks();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void UpdateTicks()
        {
            int i = 0;
            while (true)
            {
                if (i == 100)
                    i = 0;
                // If not in the process of being aborted
                if (Thread.CurrentThread.ThreadState != ThreadState.StopRequested)
                {
                    circularProgressBar1.Value = i++;
                    try
                    {
                        Thread.Sleep(30);

                        circularProgressBar1.Update();
                    }
                    catch (System.Threading.ThreadAbortException e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
            }
        }

        private void loadingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
