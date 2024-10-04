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
        private readonly ITeacherRepository _teacherService;

        private readonly UserModel _userModel;
        private readonly TeacherModel _teacherModel;

        private DataTable _studentsDT;

        public StudentView(UserModel user, TeacherModel teacher)
        {
            InitializeComponent();

            _studentService = new StudentService();
            _commonService = new CommonService();
            _userService = new UserService();
            _teacherService = new TeacherService();

            _teacherModel = teacher;
            _userModel = user;
        }

        private void StudentView_Load(object sender, EventArgs e)
        {
            ActiveStudents studentList = _studentService.GetActiveStudentsByTeacterID(_teacherModel.TEACHER_ID);

            if (studentList.RESPONSE_STATUS == EnumService.StatusConstants.NotFound)
            {
                MessageBox.Show(studentList.RESPONSE_MESSAGE, EnumService.StatusConstants.NotFound, MessageBoxButtons.OK);
            }
            else
            {
                _studentsDT = _commonService.ConvertListToDataTable(studentList.ActiveStudentsList);

                StudentDGV.DataSource = _studentsDT;
                StudentDGV.Columns[0].HeaderCell.Value = "STUDENT ID";
                StudentDGV.Columns[1].HeaderCell.Value = "STUDENT FIRST NAME";
                StudentDGV.Columns[2].HeaderCell.Value = "STUDENT LAST NAME";
            }

            lblActive.Text = studentList.ActiveStudentsList.Count.ToString();
        }

        private void StudentDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentModel student; 
            UserModel user;

            if (e.RowIndex >= 0)
            {
                student = _studentService.FindOne(new StudentModel() { STUDENT_ID = (int)StudentDGV.Rows[e.RowIndex].Cells["STUDENT_ID"].Value });

                user = _userService.GetById(student.USER_ID);

                if (user != null) 
                { 
                    SingleStudentTeacherView singleStudent = new SingleStudentTeacherView(student, user);
                }
            }
        }
    }
}
