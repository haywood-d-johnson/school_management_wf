using school_management_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly DataSource _dataSource;

        public StudentService()
        {
            _dataSource = new DataSource();
        }

        public void Create(UserModel user, StudentModel student)
        {
            String query = @"INSERT INTO SCHOOLMANAGEMENT.STUDENTS STU (STU.)";
        }

        public void Delete(StudentModel student)
        {
            throw new NotImplementedException();
        }

        public List<StudentModel> FindAll()
        {
            throw new NotImplementedException();

        }

        public StudentModel FindOne(StudentModel student)
        {
            throw new NotImplementedException();
        }

        public List<StudentInfo> ShowStudentInfo()
        {
            StudentModel studentModel = new StudentModel();

            String query = @"SELECT USERS.FIRST_NAME, USERS.LAST_NAME, STUDENTS.CLASS_YEAR, STUDENTS.ENROLLMENT_DATE, STUDENTS.ATTENDANCE_PERCENTAGE, STUDENTS.STATUS " +
                "FROM SCHOOLMANAGEMENT.STUDENTS LEFT JOIN SCHOOLMANAGEMENT.USERS ON SCHOOLMANAGEMENT.USERS.USER_ID = SCHOOLMANAGEMENT.STUDENTS.USER_ID";

            List<StudentInfo> StudentList = _dataSource.ExecuteQueryAndConvertToList<StudentInfo>(query);
            Console.WriteLine(StudentList);

            return StudentList;
        }

        public void Update(StudentModel student)
        {
            throw new NotImplementedException();
        }

        public StudentModel GetStudentModelFromUserID(UserModel user)
        {
            StudentModel studentModel = new StudentModel();

            String queryString = "SELECT * FROM SCHOOLMANAGEMENT.STUDENTS STU WHERE STU.USER_ID = '{0}'";

            String query = String.Format(queryString, user.USER_ID);

            List<StudentModel> ResStudentList = _dataSource.ExecuteQueryAndConvertToList<StudentModel>(query);
            
            return ResStudentList.FirstOrDefault();
        }
    }
}
