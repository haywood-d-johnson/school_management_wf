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

        public LoginView()
        {
            InitializeComponent();

            _commonService = new CommonService();
            _userService = new UserService();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            DataSource.EstablishConnection();
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
            String password = _commonService.Encrypt(tbxLoginPassword.Text);

            UserModel user = new UserModel()
            {
                EMAIL = email,
                PASSWORD_HASH = password
            };

            var ReturnedUser = _userService.ValidateUserByEmailAndPassword(user);

            if (ReturnedUser.STATUS == EnumService.StatusConstants.NotFound)
            {
                MessageBox.Show(ReturnedUser.MESSAGE, ReturnedUser.STATUS, MessageBoxButtons.OK);

                tbxLoginEmail.Text = String.Empty;
                tbxLoginPassword.Text = String.Empty;
            }
            else 
            { 
                StudentView studentView = new StudentView(ReturnedUser);
                studentView.ShowDialog();
                this.Hide();
            }
        }
    }
}
