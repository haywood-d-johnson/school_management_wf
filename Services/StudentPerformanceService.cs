using school_management_app.Models;
using school_management_app.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services
{
    public class StudentPerformanceService : IStudentPerformanceRepository
    {
        public StudentPerformanceModelList GetStudentsGradeByID(StudentModel student)
        {
            String query = $"SELECT * FROM SCHOOLMANAGEMENT.STUDENT_PERFORMANCE sp WHERE sp.STUDENT_ID = {student.STUDENT_ID}";

            List<StudentPerformanceModel> studentsPerformance = new List<StudentPerformanceModel>();

            if (studentsPerformance != null && studentsPerformance.Count > 0)
            {
                return new StudentPerformanceModelList()
                {
                    RESPONSE_STATUS = EnumService.StatusConstants.Found,
                    RESPONSE_MESSAGE = EnumService.StatusConstants.Found,
                    studentPerformanceList = studentsPerformance
                };
            }
            else 
            { 
                return new StudentPerformanceModelList() 
                {
                    RESPONSE_STATUS = EnumService.StatusConstants.NotFound,
                    RESPONSE_MESSAGE = "No grades found for the current student.",
                };
            }
        }
    }
}
