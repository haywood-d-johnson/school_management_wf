namespace school_management_app.Views
{
    partial class StudentView
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
            this.components = new System.ComponentModel.Container();
            this.StudentDGV = new System.Windows.Forms.DataGridView();
            this.lblActive = new System.Windows.Forms.Label();
            this.lblActiveStudentsLabel = new System.Windows.Forms.Label();
            this.studentModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StudentDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentDGV
            // 
            this.StudentDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StudentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentDGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StudentDGV.Location = new System.Drawing.Point(0, 151);
            this.StudentDGV.Name = "StudentDGV";
            this.StudentDGV.ReadOnly = true;
            this.StudentDGV.RowHeadersVisible = false;
            this.StudentDGV.Size = new System.Drawing.Size(626, 334);
            this.StudentDGV.TabIndex = 2;
            this.StudentDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentDGV_CellClick);
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(137, 64);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(35, 13);
            this.lblActive.TabIndex = 4;
            this.lblActive.Text = "label1";
            // 
            // lblActiveStudentsLabel
            // 
            this.lblActiveStudentsLabel.AutoSize = true;
            this.lblActiveStudentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveStudentsLabel.Location = new System.Drawing.Point(12, 64);
            this.lblActiveStudentsLabel.Name = "lblActiveStudentsLabel";
            this.lblActiveStudentsLabel.Size = new System.Drawing.Size(119, 12);
            this.lblActiveStudentsLabel.TabIndex = 3;
            this.lblActiveStudentsLabel.Text = "Total Active Students:";
            // 
            // studentModelBindingSource
            // 
            this.studentModelBindingSource.DataSource = typeof(school_management_app.Models.StudentModel);
            // 
            // StudentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 485);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.lblActiveStudentsLabel);
            this.Controls.Add(this.StudentDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentView";
            this.Load += new System.EventHandler(this.StudentView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView StudentDGV;
        private System.Windows.Forms.BindingSource studentModelBindingSource;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblActiveStudentsLabel;
    }
}