using MySql.Data.MySqlClient;
using school_management_app.Models;
using school_management_app.Services;
using school_management_app.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_app.Views
{
    public partial class StudentView : Form
    {
        private readonly IStudentRepository _studentService;
        private readonly ICommonRepository _commonService;
        private readonly IUserRepository _userService;

        private DataTable _studentsDT;

        public StudentView(UserModel user)
        {
            InitializeComponent();

            _studentService = new StudentService();
            _commonService = new CommonService();
            _userService = new UserService();
        }

        private void StudentView_Load(object sender, EventArgs e)
        {
            // should conditionally render by user.role. Seacher can see students/students cannot see teachers.
            DataSource.EstablishConnection();

            List<StudentInfo> studentList = _studentService.ShowStudentInfo();
            _studentsDT = _commonService.ConvertListToDataTable(studentList);

            StudentDGV.DataSource = _studentsDT;

        }
    }
}
