using school_management_app.Models;
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
    public partial class StudentClassView : Form
    {
        private readonly UserModel _userModel;

        public StudentClassView(UserModel user)
        {
            InitializeComponent();

            _userModel = user;
        }
    }
}
