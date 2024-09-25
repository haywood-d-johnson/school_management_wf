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
    public partial class UpdateStudentInformationView : Form
    {
        private readonly UserModel _userModel;
        private readonly StudentModel _studentModel;

        public UpdateStudentInformationView(UserModel user, StudentModel studentModel)
        {
            InitializeComponent();

            _userModel = user;
            _studentModel = studentModel;
        }
    }
}
