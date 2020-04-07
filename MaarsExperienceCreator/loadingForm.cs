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
        static bool abortRequested;
        public LoadingForm()
        {
            InitializeComponent();
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            circularProgressBar1.ForeColor = Color.Black;
            this.Show();
            this.Visible = true;
            abortRequested = false;
            UpdateTicks();


        }
        public static void setAbort()
        {
            abortRequested = true;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {

        }

       /* private void TransformPointsPoint(PaintEventArgs e)
        {

            // Create array of two points.
            Point[] points = { new Point(0, 0), new Point(100, 50) };

            // Draw line connecting two untransformed points.
            e.Graphics.DrawLine(new Pen(Color.Blue, 3), points[0], points[1]);

            // Set world transformation of Graphics object to translate.
            e.Graphics.TranslateTransform(40, 30);

            // Transform points in array from world to page coordinates.
            e.Graphics.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.Page, System.Drawing.Drawing2D.CoordinateSpace.World, points);

            // Reset world transformation.
            e.Graphics.ResetTransform();

            // Draw line that connects transformed points.
            e.Graphics.DrawLine(new Pen(Color.Red, 3), points[0], points[1]);
        }
        */
        private void UpdateTicks()
        {
            int i = 0;
            while (true)
            {
                if (i == 100)
                    i = 0;
                // If not in the process of being aborted
                Thread.Sleep(30);
                if (abortRequested == false)
                {
                    circularProgressBar1.Value = i++;
                    circularProgressBar1.Update();
                    
                }
                else
                {
                    Thread.CurrentThread.Abort();
                    Thread.CurrentThread.Join();

                }


            }
        }

        private void loadingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
