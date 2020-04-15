namespace MaarsExperienceCreator
{
    partial class SaveExpDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveExpDlg));
            this.label1 = new System.Windows.Forms.Label();
            this.newExperienceNameTxtbox = new System.Windows.Forms.TextBox();
            this.saveNewRouteOkBtn = new System.Windows.Forms.Button();
            this.saveNewRouteCancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Name for Route";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // newExperienceNameTxtbox
            // 
            this.newExperienceNameTxtbox.Location = new System.Drawing.Point(92, 45);
            this.newExperienceNameTxtbox.Name = "newExperienceNameTxtbox";
            this.newExperienceNameTxtbox.Size = new System.Drawing.Size(290, 22);
            this.newExperienceNameTxtbox.TabIndex = 1;
            // 
            // saveNewRouteOkBtn
            // 
            this.saveNewRouteOkBtn.Location = new System.Drawing.Point(226, 82);
            this.saveNewRouteOkBtn.Name = "saveNewRouteOkBtn";
            this.saveNewRouteOkBtn.Size = new System.Drawing.Size(75, 23);
            this.saveNewRouteOkBtn.TabIndex = 2;
            this.saveNewRouteOkBtn.Text = "Ok";
            this.saveNewRouteOkBtn.UseVisualStyleBackColor = true;
            this.saveNewRouteOkBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.saveNewRouteOkBtn_MouseUp);
            // 
            // saveNewRouteCancelBtn
            // 
            this.saveNewRouteCancelBtn.Location = new System.Drawing.Point(307, 82);
            this.saveNewRouteCancelBtn.Name = "saveNewRouteCancelBtn";
            this.saveNewRouteCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.saveNewRouteCancelBtn.TabIndex = 3;
            this.saveNewRouteCancelBtn.Text = "Cancel";
            this.saveNewRouteCancelBtn.UseVisualStyleBackColor = true;
            this.saveNewRouteCancelBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.saveNewRouteCancelBtn_MouseUp);
            // 
            // SaveExpDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 114);
            this.Controls.Add(this.saveNewRouteCancelBtn);
            this.Controls.Add(this.saveNewRouteOkBtn);
            this.Controls.Add(this.newExperienceNameTxtbox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaveExpDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save New Experience";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newExperienceNameTxtbox;
        private System.Windows.Forms.Button saveNewRouteOkBtn;
        private System.Windows.Forms.Button saveNewRouteCancelBtn;
    }
}