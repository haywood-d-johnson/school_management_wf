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
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace school_management_app.Views
{
    public partial class StudentClassView : Form
    {
        private readonly UserModel _userModel;
        private readonly StudentModel _studentModel;

        private readonly IStudentRepository _studentService;
        private readonly ICommonRepository _commonService;

        private DataTable _studentsClassDT;

        public StudentClassView(UserModel user, StudentModel studentModel)
        {
            InitializeComponent();
            _userModel = user;
            _studentModel = studentModel;

            _studentService = new StudentService();
            _commonService = new CommonService();
        }

        private void StudentClassView_Load(object sender, EventArgs e)
        {
            List<StudentClassInfo> studentClasses = _studentService.GetStudentClassInfo(_studentModel);

            _studentsClassDT = _commonService.ConvertListToDataTable<StudentClassInfo>(studentClasses);
            StudentClassesDGV.DataSource = _studentsClassDT;

            StudentClassesDGV.Columns[0].HeaderCell.Value = "SUBJECT NAME";
            StudentClassesDGV.Columns[1].HeaderCell.Value = "TEACHER NAME";
            StudentClassesDGV.Columns[2].HeaderCell.Value = "GRADE";
            StudentClassesDGV.Columns[3].HeaderCell.Value = "ROOM NUMBER";
            StudentClassesDGV.Columns[4].HeaderCell.Value = "CLASS ALLOCATION DATE";

        }
    }
}
