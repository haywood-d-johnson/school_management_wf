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
    public partial class MainMenuStudentView : Form
    {
        private readonly IUserRepository _userService;
        private readonly IStudentRepository _studentService;
        private readonly ICommonRepository _commonService;

        private readonly UserModel _userModel;
        private readonly StudentModel _studentModel;

        public MainMenuStudentView(UserModel user)
        {
            InitializeComponent();

            _userService = new UserService();
            _studentService = new StudentService();
            _commonService = new CommonService();

            _userModel = user;

            _studentModel = _studentService.GetStudentModelFromUserID(_userModel);
        }

        private void MainMenuStudentView_Load(object sender, EventArgs e)
        {
            lblUserName.Text = String.Empty;
            lblUStatus.Text = String.Empty;

            lblUserName.Text = _commonService.GenerateUserGreeting(_userModel);
            lblUStatus.Text = _userModel.ROLES;
        }

        private void btnViewClasses_Click(object sender, EventArgs e)
        {
            if (this.pnlFormView.Controls.Count > 0)
                this.pnlFormView.Controls.RemoveAt(0);

            StudentClassView studentClassView = new StudentClassView(_userModel, _studentModel);

            studentClassView.TopLevel = false;
            studentClassView.AutoScroll = true;
            this.pnlFormView.Controls.Add(studentClassView);
            studentClassView.Show();
        }

        private void btnViewStuInfo_Click(object sender, EventArgs e)
        {
            if (this.pnlFormView.Controls.Count > 0)
                this.pnlFormView.Controls.RemoveAt(0);

            UpdateStudentInformationView updateStudentInformationView = new UpdateStudentInformationView(_userModel, _studentModel);

            updateStudentInformationView.TopLevel = false;
            updateStudentInformationView.AutoScroll = true;
            this.pnlFormView.Controls.Add(updateStudentInformationView);
            updateStudentInformationView.Show();
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
    }
}
