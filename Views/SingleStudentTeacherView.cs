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
    public partial class SingleStudentTeacherView : Form
    {
        private readonly ITeacherRepository _teacherService;
        private readonly IUserRepository _userService;
        private readonly IStudentRepository _studentService;
        private readonly IStudentPerformanceRepository _studentPerformanceService;
        private readonly ICommonRepository _commonService;
        private readonly ISubjectsRepository _subjectsService;

        private StudentModel _studentModel;
        private UserModel _userModel;
        private List<SubjectModel> _subjectModels;
        private DataTable _performanceDT;

        public SingleStudentTeacherView(StudentModel student, UserModel user)
        {
            InitializeComponent();
            
            _teacherService = new TeacherService();
            _userService = new UserService();
            _studentService = new StudentService();
            _commonService = new CommonService();
            _subjectsService = new SubjectService();
            _studentPerformanceService = new StudentPerformanceService();

            _userModel = user;
            _studentModel = student;
            _subjectModels = _subjectsService.GetNamesForReference();
        }

        private void SingleStudentTeacherView_Load(object sender, EventArgs e)
        {
            lblName.Text = $"{_userModel.FIRST_NAME} {_userModel.LAST_NAME}";
            lblID.Text = _studentModel.STUDENT_ID.ToString();
            lblStatus.Text = _studentModel.STATUS.ToString();

            StudentPerformanceModelList studentPerformanceModelList = _studentPerformanceService.GetStudentsGradeByID(_studentModel);

            if (studentPerformanceModelList.RESPONSE_STATUS == EnumService.StatusConstants.NotFound)
            {
                MessageBox.Show(studentPerformanceModelList.RESPONSE_MESSAGE, studentPerformanceModelList.RESPONSE_STATUS, MessageBoxButtons.OK);
            }
            else
            {
                _performanceDT = _commonService.ConvertListToDataTable(studentPerformanceModelList.studentPerformanceList);

                PerformanceDT.DataSource = _performanceDT;
                PerformanceDT.Columns[0].Visible = false;
                PerformanceDT.Columns[1].Visible = false;
                PerformanceDT.Columns[2].HeaderCell.Value = "STUDENT LAST NAME";
            }


            
        }
    }
}
