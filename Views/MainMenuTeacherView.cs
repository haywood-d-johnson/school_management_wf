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

        public MainMenuTeacherView(UserModel user)
        {
            InitializeComponent();

            _userService = new UserService();
        }
    }
}
