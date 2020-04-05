namespace MaarsExperienceCreator
{
    partial class LoadRouteDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadRouteDlg));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.loadRouteLabel = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(92, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(281, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // loadRouteLabel
            // 
            this.loadRouteLabel.AutoSize = true;
            this.loadRouteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadRouteLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadRouteLabel.Location = new System.Drawing.Point(12, 34);
            this.loadRouteLabel.Name = "loadRouteLabel";
            this.loadRouteLabel.Size = new System.Drawing.Size(63, 25);
            this.loadRouteLabel.TabIndex = 1;
            this.loadRouteLabel.Text = "Route";
            this.loadRouteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadRouteLabel.UseWaitCursor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(298, 79);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cancelBtn_MouseUp);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(217, 79);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 3;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.loadBtn_MouseUp);
            // 
            // LoadRouteDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 114);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.loadRouteLabel);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadRouteDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Route";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label loadRouteLabel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button loadBtn;
    }
}