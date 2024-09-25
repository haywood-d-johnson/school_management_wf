namespace school_management_app.Views
{
    partial class StudentClassView
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
            this.StudentClassesDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.StudentClassesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentClassesDGV
            // 
            this.StudentClassesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StudentClassesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentClassesDGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StudentClassesDGV.Location = new System.Drawing.Point(0, 139);
            this.StudentClassesDGV.Name = "StudentClassesDGV";
            this.StudentClassesDGV.RowHeadersVisible = false;
            this.StudentClassesDGV.Size = new System.Drawing.Size(626, 346);
            this.StudentClassesDGV.TabIndex = 1;
            // 
            // StudentClassView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 485);
            this.Controls.Add(this.StudentClassesDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentClassView";
            this.Load += new System.EventHandler(this.StudentClassView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentClassesDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView StudentClassesDGV;
    }
}