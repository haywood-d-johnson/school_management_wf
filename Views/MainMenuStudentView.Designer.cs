namespace school_management_app.Views
{
    partial class MainMenuStudentView
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
            this.lblDsgnBar = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUStatus = new System.Windows.Forms.Label();
            this.btnViewClasses = new System.Windows.Forms.Button();
            this.btnViewStuInfo = new System.Windows.Forms.Button();
            this.pnlFormView = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblDsgnBar
            // 
            this.lblDsgnBar.AutoSize = true;
            this.lblDsgnBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.lblDsgnBar.Location = new System.Drawing.Point(2, 2);
            this.lblDsgnBar.Name = "lblDsgnBar";
            this.lblDsgnBar.Size = new System.Drawing.Size(0, 13);
            this.lblDsgnBar.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUserName.Location = new System.Drawing.Point(12, 56);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(29, 12);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "label1";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUStatus
            // 
            this.lblUStatus.AutoSize = true;
            this.lblUStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblUStatus.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUStatus.Location = new System.Drawing.Point(12, 84);
            this.lblUStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblUStatus.Name = "lblUStatus";
            this.lblUStatus.Size = new System.Drawing.Size(29, 12);
            this.lblUStatus.TabIndex = 3;
            this.lblUStatus.Text = "label1";
            this.lblUStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewClasses
            // 
            this.btnViewClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnViewClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewClasses.Location = new System.Drawing.Point(0, 177);
            this.btnViewClasses.Name = "btnViewClasses";
            this.btnViewClasses.Size = new System.Drawing.Size(192, 48);
            this.btnViewClasses.TabIndex = 0;
            this.btnViewClasses.Text = "VIEW CLASSES";
            this.btnViewClasses.UseVisualStyleBackColor = false;
            this.btnViewClasses.Click += new System.EventHandler(this.btnViewClasses_Click);
            // 
            // btnViewStuInfo
            // 
            this.btnViewStuInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnViewStuInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewStuInfo.Location = new System.Drawing.Point(0, 241);
            this.btnViewStuInfo.Name = "btnViewStuInfo";
            this.btnViewStuInfo.Size = new System.Drawing.Size(192, 48);
            this.btnViewStuInfo.TabIndex = 4;
            this.btnViewStuInfo.Text = "VIEW STUDENT INFORMATION";
            this.btnViewStuInfo.UseVisualStyleBackColor = false;
            this.btnViewStuInfo.Click += new System.EventHandler(this.btnViewStuInfo_Click);
            // 
            // pnlFormView
            // 
            this.pnlFormView.BackColor = System.Drawing.Color.White;
            this.pnlFormView.Location = new System.Drawing.Point(192, -4);
            this.pnlFormView.Name = "pnlFormView";
            this.pnlFormView.Size = new System.Drawing.Size(626, 492);
            this.pnlFormView.TabIndex = 5;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(814, 25);
            this.pnlTopBar.TabIndex = 7;
            // 
            // MainMenuStudentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(814, 485);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUStatus);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.btnViewStuInfo);
            this.Controls.Add(this.btnViewClasses);
            this.Controls.Add(this.pnlFormView);
            this.Controls.Add(this.lblDsgnBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenuStudentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Management";
            this.Load += new System.EventHandler(this.MainMenuStudentView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDsgnBar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUStatus;
        private System.Windows.Forms.Button btnViewClasses;
        private System.Windows.Forms.Button btnViewStuInfo;
        private System.Windows.Forms.Panel pnlFormView;
        private System.Windows.Forms.Panel pnlTopBar;
    }
}