namespace school_management_app.Views
{
    partial class MainMenuTeacherView
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
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlFormView = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUStatus = new System.Windows.Forms.Label();
            this.btnViewStudents = new System.Windows.Forms.Button();
            this.btnClaassInfo = new System.Windows.Forms.Button();
            this.btnTeacherInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(814, 25);
            this.pnlTopBar.TabIndex = 8;
            // 
            // pnlFormView
            // 
            this.pnlFormView.BackColor = System.Drawing.Color.White;
            this.pnlFormView.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFormView.Location = new System.Drawing.Point(188, 25);
            this.pnlFormView.Name = "pnlFormView";
            this.pnlFormView.Size = new System.Drawing.Size(626, 460);
            this.pnlFormView.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.btnClose.Location = new System.Drawing.Point(93, 450);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.btnLogOut.Location = new System.Drawing.Point(12, 450);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 10;
            this.btnLogOut.Text = "&Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUserName.Location = new System.Drawing.Point(12, 56);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(29, 12);
            this.lblUserName.TabIndex = 12;
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
            this.lblUStatus.TabIndex = 13;
            this.lblUStatus.Text = "label1";
            this.lblUStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewStudents
            // 
            this.btnViewStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnViewStudents.FlatAppearance.BorderSize = 0;
            this.btnViewStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewStudents.Location = new System.Drawing.Point(0, 165);
            this.btnViewStudents.Name = "btnViewStudents";
            this.btnViewStudents.Size = new System.Drawing.Size(188, 48);
            this.btnViewStudents.TabIndex = 14;
            this.btnViewStudents.Text = "VIEW STUDENTS";
            this.btnViewStudents.UseVisualStyleBackColor = false;
            this.btnViewStudents.Click += new System.EventHandler(this.btnViewStudents_Click);
            // 
            // btnClaassInfo
            // 
            this.btnClaassInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnClaassInfo.FlatAppearance.BorderSize = 0;
            this.btnClaassInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClaassInfo.Location = new System.Drawing.Point(0, 219);
            this.btnClaassInfo.Name = "btnClaassInfo";
            this.btnClaassInfo.Size = new System.Drawing.Size(188, 48);
            this.btnClaassInfo.TabIndex = 15;
            this.btnClaassInfo.Text = "CLASSROOM INFORMATION";
            this.btnClaassInfo.UseVisualStyleBackColor = false;
            // 
            // btnTeacherInfo
            // 
            this.btnTeacherInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnTeacherInfo.FlatAppearance.BorderSize = 0;
            this.btnTeacherInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeacherInfo.Location = new System.Drawing.Point(0, 273);
            this.btnTeacherInfo.Name = "btnTeacherInfo";
            this.btnTeacherInfo.Size = new System.Drawing.Size(188, 48);
            this.btnTeacherInfo.TabIndex = 16;
            this.btnTeacherInfo.Text = "VIEW TEACHER INFORMATION";
            this.btnTeacherInfo.UseVisualStyleBackColor = false;
            this.btnTeacherInfo.Click += new System.EventHandler(this.btnTeacherInfo_Click);
            // 
            // MainMenuTeacherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(814, 485);
            this.Controls.Add(this.btnTeacherInfo);
            this.Controls.Add(this.btnClaassInfo);
            this.Controls.Add(this.btnViewStudents);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.pnlFormView);
            this.Controls.Add(this.pnlTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenuTeacherView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenuTeacherView";
            this.Load += new System.EventHandler(this.MainMenuTeacherView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlFormView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUStatus;
        private System.Windows.Forms.Button btnViewStudents;
        private System.Windows.Forms.Button btnClaassInfo;
        private System.Windows.Forms.Button btnTeacherInfo;
    }
}