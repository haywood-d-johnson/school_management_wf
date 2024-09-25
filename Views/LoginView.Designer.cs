namespace school_management_app.Views
{
    partial class LoginView
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
            this.btnLoginOk = new System.Windows.Forms.Button();
            this.btnLoginClose = new System.Windows.Forms.Button();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.tbxLoginEmail = new System.Windows.Forms.TextBox();
            this.tbxLoginPassword = new System.Windows.Forms.TextBox();
            this.lblLoginEmail = new System.Windows.Forms.Label();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoginOk
            // 
            this.btnLoginOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnLoginOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnLoginOk.FlatAppearance.BorderSize = 0;
            this.btnLoginOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginOk.Location = new System.Drawing.Point(699, 469);
            this.btnLoginOk.Name = "btnLoginOk";
            this.btnLoginOk.Size = new System.Drawing.Size(119, 43);
            this.btnLoginOk.TabIndex = 0;
            this.btnLoginOk.Text = "&OK";
            this.btnLoginOk.UseVisualStyleBackColor = false;
            this.btnLoginOk.Click += new System.EventHandler(this.btnLoginOk_Click);
            // 
            // btnLoginClose
            // 
            this.btnLoginClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnLoginClose.FlatAppearance.BorderSize = 0;
            this.btnLoginClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLoginClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginClose.Location = new System.Drawing.Point(564, 469);
            this.btnLoginClose.Name = "btnLoginClose";
            this.btnLoginClose.Size = new System.Drawing.Size(119, 43);
            this.btnLoginClose.TabIndex = 1;
            this.btnLoginClose.Text = "&CANCEL";
            this.btnLoginClose.UseVisualStyleBackColor = false;
            this.btnLoginClose.Click += new System.EventHandler(this.btnLoginClose_Click);
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAppTitle.Location = new System.Drawing.Point(142, 81);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(556, 37);
            this.lblAppTitle.TabIndex = 2;
            this.lblAppTitle.Text = "SCHOOL MANAGEMENT SYSTEM";
            // 
            // tbxLoginEmail
            // 
            this.tbxLoginEmail.Location = new System.Drawing.Point(372, 205);
            this.tbxLoginEmail.Name = "tbxLoginEmail";
            this.tbxLoginEmail.Size = new System.Drawing.Size(150, 20);
            this.tbxLoginEmail.TabIndex = 3;
            // 
            // tbxLoginPassword
            // 
            this.tbxLoginPassword.Location = new System.Drawing.Point(372, 246);
            this.tbxLoginPassword.Name = "tbxLoginPassword";
            this.tbxLoginPassword.PasswordChar = '*';
            this.tbxLoginPassword.Size = new System.Drawing.Size(150, 20);
            this.tbxLoginPassword.TabIndex = 4;
            // 
            // lblLoginEmail
            // 
            this.lblLoginEmail.AutoSize = true;
            this.lblLoginEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginEmail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLoginEmail.Location = new System.Drawing.Point(318, 208);
            this.lblLoginEmail.Name = "lblLoginEmail";
            this.lblLoginEmail.Size = new System.Drawing.Size(48, 13);
            this.lblLoginEmail.TabIndex = 5;
            this.lblLoginEmail.Text = "EMAIL:";
            // 
            // lblLoginPassword
            // 
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLoginPassword.Location = new System.Drawing.Point(284, 249);
            this.lblLoginPassword.Name = "lblLoginPassword";
            this.lblLoginPassword.Size = new System.Drawing.Size(82, 13);
            this.lblLoginPassword.TabIndex = 6;
            this.lblLoginPassword.Text = "PASSWORD:";
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(830, 524);
            this.Controls.Add(this.lblLoginPassword);
            this.Controls.Add(this.lblLoginEmail);
            this.Controls.Add(this.tbxLoginPassword);
            this.Controls.Add(this.tbxLoginEmail);
            this.Controls.Add(this.lblAppTitle);
            this.Controls.Add(this.btnLoginClose);
            this.Controls.Add(this.btnLoginOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Management";
            this.Load += new System.EventHandler(this.LoginView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoginOk;
        private System.Windows.Forms.Button btnLoginClose;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.TextBox tbxLoginEmail;
        private System.Windows.Forms.TextBox tbxLoginPassword;
        private System.Windows.Forms.Label lblLoginEmail;
        private System.Windows.Forms.Label lblLoginPassword;
    }
}