namespace MaarsExperienceCreator
{
    partial class SaveRouteDlg
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
            this.label1 = new System.Windows.Forms.Label();
            this.newRouteNameTxtbox = new System.Windows.Forms.TextBox();
            this.saveNewRouteOkBtn = new System.Windows.Forms.Button();
            this.saveNewRouteCancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Name for Route";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // newRouteNameTxtbox
            // 
            this.newRouteNameTxtbox.Location = new System.Drawing.Point(31, 45);
            this.newRouteNameTxtbox.Name = "newRouteNameTxtbox";
            this.newRouteNameTxtbox.Size = new System.Drawing.Size(290, 22);
            this.newRouteNameTxtbox.TabIndex = 1;
            // 
            // saveNewRouteOkBtn
            // 
            this.saveNewRouteOkBtn.Location = new System.Drawing.Point(168, 82);
            this.saveNewRouteOkBtn.Name = "saveNewRouteOkBtn";
            this.saveNewRouteOkBtn.Size = new System.Drawing.Size(75, 23);
            this.saveNewRouteOkBtn.TabIndex = 2;
            this.saveNewRouteOkBtn.Text = "Ok";
            this.saveNewRouteOkBtn.UseVisualStyleBackColor = true;
            this.saveNewRouteOkBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.saveNewRouteOkBtn_MouseUp);
            // 
            // saveNewRouteCancelBtn
            // 
            this.saveNewRouteCancelBtn.Location = new System.Drawing.Point(249, 82);
            this.saveNewRouteCancelBtn.Name = "saveNewRouteCancelBtn";
            this.saveNewRouteCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.saveNewRouteCancelBtn.TabIndex = 3;
            this.saveNewRouteCancelBtn.Text = "Cancel";
            this.saveNewRouteCancelBtn.UseVisualStyleBackColor = true;
            this.saveNewRouteCancelBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.saveNewRouteCancelBtn_MouseUp);
            // 
            // SaveRouteDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 113);
            this.Controls.Add(this.saveNewRouteCancelBtn);
            this.Controls.Add(this.saveNewRouteOkBtn);
            this.Controls.Add(this.newRouteNameTxtbox);
            this.Controls.Add(this.label1);
            this.Name = "SaveRouteDlg";
            this.Text = "Save New Route";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newRouteNameTxtbox;
        private System.Windows.Forms.Button saveNewRouteOkBtn;
        private System.Windows.Forms.Button saveNewRouteCancelBtn;
    }
}