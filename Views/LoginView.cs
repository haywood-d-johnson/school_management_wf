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
    public partial class LoginView : Form
    {
        private readonly ICommonRepository _commonService;
        private readonly IUserRepository _userService;
        private DataSource _dataSource;

        public LoginView()
        {
            InitializeComponent();

            _commonService = new CommonService();
            _userService = new UserService();

            _dataSource = new DataSource();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            DataSource.EstablishConnection();

            String updatePwdForStudents = "UPDATE SCHOOLMANAGEMENT.USERS u SET u.PASSWORD_HASH = '{0}' WHERE u.USER_ID = {1}";
            _dataSource.ExecuteQuery<UserModel>(String.Format(updatePwdForStudents, _commonService.HashPassword("HASHEDPASSWORD1"), 1));
        }

        private void btnLoginClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit ? ", "Exit Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnLoginOk_Click(object sender, EventArgs e)
        {
            String email = tbxLoginEmail.Text;
            String password = tbxLoginPassword.Text;

            UserModel user = new UserModel()
            {
                EMAIL = email,
                PASSWORD_HASH = password
            };

            var ReturnedUser = _userService.ValidateUserByEmailAndPassword(user);

            if (ReturnedUser.RESPONSE_STATUS == EnumService.StatusConstants.NotFound)
            {
                MessageBox.Show(ReturnedUser.RESPONSE_MESSAGE, ReturnedUser.RESPONSE_STATUS, MessageBoxButtons.OK);

                tbxLoginEmail.Text = String.Empty;
                tbxLoginPassword.Text = String.Empty;
            }
            else 
            {
                this.Hide();

                if (ReturnedUser.ROLES == EnumService.UserRolesConstants.Student) 
                {
                    MainMenuStudentView mainMenuStudentView = new MainMenuStudentView(ReturnedUser);
                    mainMenuStudentView.ShowDialog();
                }
                if (ReturnedUser.ROLES == EnumService.UserRolesConstants.Teacher)
                {
                    MainMenuTeacherView mainMenuTeacherView = new MainMenuTeacherView(ReturnedUser);
                    mainMenuTeacherView.ShowDialog();
                }
                if (ReturnedUser.ROLES == EnumService.UserRolesConstants.Admin)
                {
                    MainMenuAdminView mainMenuAdminView = new MainMenuAdminView(ReturnedUser);
                    mainMenuAdminView.ShowDialog();
                }
            }
        }
    }
}
