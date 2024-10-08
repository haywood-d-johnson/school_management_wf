﻿using school_management_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            String query = "SELECT * FROM SCHOOLMANAGEMENT.STUDENTS s";

            List<StudentModel> studentList = _dataSource.ExecuteQueryAndConvertToList<StudentModel>(query);

            return studentList;
        }

        public StudentModel FindOne(StudentModel student)
        {
            String query = $"SELECT * FROM SCHOOLMANAGEMENT.STUDENTS s WHERE s.STUDENT_ID = {student.STUDENT_ID}";

            List<StudentModel> StudentList = _dataSource.ExecuteQueryAndConvertToList<StudentModel>(query);

            return StudentList.FirstOrDefault();
        }

        public List<StudentInfo> ShowStudentInfo()
        {
            StudentModel studentModel = new StudentModel();

            String query = @"SELECT USERS.FIRST_NAME, USERS.LAST_NAME, STUDENTS.CLASS_YEAR, STUDENTS.ENROLLMENT_DATE, STUDENTS.ATTENDANCE_PERCENTAGE, STUDENTS.STATUS " +
                "FROM SCHOOLMANAGEMENT.STUDENTS LEFT JOIN SCHOOLMANAGEMENT.USERS ON SCHOOLMANAGEMENT.USERS.USER_ID = SCHOOLMANAGEMENT.STUDENTS.USER_ID";

            List<StudentInfo> StudentList = _dataSource.ExecuteQueryAndConvertToList<StudentInfo>(query);

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

            List<StudentModel> ResStudentList = _dataSource.ExecuteQueryAndConvertToList<StudentModel>(String.Format(queryString, user.USER_ID));
            
            return ResStudentList.FirstOrDefault();
        }

        public List<StudentClassInfo> GetStudentClassInfo(StudentModel student)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.Append("SELECT s.SUBJECT_NAME, u.LAST_NAME AS TEACHER, sp.GRADE, c.ROOM_NUMBER, ca.ALLOCATION_DATE ");
            queryString.Append("FROM SCHOOLMANAGEMENT.STUDENT_PERFORMANCE sp ");
            queryString.Append("JOIN SCHOOLMANAGEMENT.SUBJECTS s ON s.SUBJECT_ID = sp.SUBJECT_ID ");
            queryString.Append("JOIN SCHOOLMANAGEMENT.CLASSROOM_ALLOCATION ca ON ca.STUDENT_ID = sp.STUDENT_ID ");
            queryString.Append("JOIN SCHOOLMANAGEMENT.CLASSROOM c ON c.CLASSROOM_ID = ca.CLASSROOM_ID ");
            queryString.Append("JOIN SCHOOLMANAGEMENT.TEACHERS t ON t.TEACHER_ID = c.ASSIGNED_TEACHER_ID ");
            queryString.Append("JOIN SCHOOLMANAGEMENT.USERS u ON u.USER_ID = t.USER_ID ");
            queryString.Append($"WHERE sp.STUDENT_ID = {student.STUDENT_ID}");

            List<StudentClassInfo> ResClassInfo = _dataSource.ExecuteQueryAndConvertToList<StudentClassInfo>(queryString.ToString());

            return ResClassInfo;
        }

        public ActiveStudents GetActiveStudentsByTeacterID(int teacherID)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.Append("SELECT s.STUDENT_ID, u.FIRST_NAME, u.LAST_NAME FROM SCHOOLMANAGEMENT.CLASSROOM_ALLOCATION ca ");
            queryString.Append("JOIN SCHOOLMANAGEMENT.STUDENTS s ON s.STUDENT_ID = ca.STUDENT_ID JOIN SCHOOLMANAGEMENT.USERS u ON u.USER_ID = s.USER_ID ");
            queryString.Append($"JOIN SCHOOLMANAGEMENT.CLASSROOM c ON c.CLASSROOM_ID = ca.CLASSROOM_ID WHERE u.USTATUS = '{EnumService.UserStatusConstants.Active}' ");
            queryString.Append($"AND u.ROLES = '{EnumService.UserRolesConstants.Student}' AND c.ASSIGNED_TEACHER_ID = {teacherID}");

            List<ActiveStudent> activeStudents = _dataSource.ExecuteQueryAndConvertToList<ActiveStudent>(queryString.ToString());

            if (activeStudents != null && activeStudents.Count > 0) 
            { 
                return new ActiveStudents() 
                { 
                    RESPONSE_STATUS = EnumService.StatusConstants.Found,  
                    RESPONSE_MESSAGE = EnumService.StatusConstants.Found,
                    ActiveStudentsList = activeStudents
                };
            }
            else 
            { 
                return new ActiveStudents() { RESPONSE_STATUS = EnumService.StatusConstants.NotFound, RESPONSE_MESSAGE = "No students found for current teacher. Please contact administration if this is an error."};
            }
        }
    }
}
