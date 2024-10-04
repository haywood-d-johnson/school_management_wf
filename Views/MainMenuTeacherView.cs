using school_management_app.Models;
using school_management_app.Services;
using school_management_app.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_app.Views
{
    public partial class MainMenuTeacherView : Form
    {
        private readonly IUserRepository _userService;
        private readonly ITeacherRepository _teacherService;

        private UserModel _userModel; 
        private TeacherModel _teacherModel;

        public MainMenuTeacherView(UserModel user)
        {
            InitializeComponent();

            _userService = new UserService();
            _teacherService = new TeacherService();

            _userModel = user;
            _teacherModel = _teacherService.GetTeacherModelFromUserID(_userModel);
        }

        private void MainMenuTeacherView_Load(object sender, EventArgs e)
        {
            lblUserName.Text = String.Empty;
            lblUStatus.Text = String.Empty;

            lblUserName.Text = _userService.GenerateUserGreeting(_userModel);
            lblUStatus.Text = _teacherModel.STATUS;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out? ", "Logout Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                LoginView loginView = new LoginView();

                this.Close();
                loginView.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            if (this.pnlFormView.Controls.Count > 0)
                this.pnlFormView.Controls.RemoveAt(0);

            StudentView studentsView = new StudentView(_userModel, _teacherModel);
            studentsView.TopLevel = false;
            studentsView.AutoScroll = true;
            this.pnlFormView.Controls.Add(studentsView);
            studentsView.Show();
        }

        private void btnTeacherInfo_Click(object sender, EventArgs e)
        {
            if (this.pnlFormView.Controls.Count > 0)
                this.pnlFormView.Controls.RemoveAt(0);

            UpdateInformationView updateTeacherInformationView = new UpdateInformationView(_userModel, null, _teacherModel);

            updateTeacherInformationView.TopLevel = false;
            updateTeacherInformationView.AutoScroll = true;
            this.pnlFormView.Controls.Add(updateTeacherInformationView);
            updateTeacherInformationView.Show();
        }
    }
}
