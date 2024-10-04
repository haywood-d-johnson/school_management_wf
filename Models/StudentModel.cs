using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace school_management_app.Models
{
    public class StudentModel : ResponseModel
    {
        public int STUDENT_ID { get; set; }
        public int USER_ID { get; set; }
        public int CLASS_YEAR { get; set; }
        public DateTime ENROLLMENT_DATE { get; set; }
        public decimal ATTENDANCE_PERCENTAGE { get; set; }
        public string STATUS { get; set; } = "ACTIVE";
    }

    public class StudentInfo : ResponseModel
    {
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public int CLASS_YEAR { get; set; }
        public DateTime ENROLLMENT_DATE { get; set; }
        public decimal ATTENDANCE_PERCENTAGE { get; set; }
        public string STATUS { get; set; }
    }

    public class StudentClassInfo : ResponseModel
    {
        [Display(Name = "SUBJECT NAME")]
        public String SUBJECT_NAME { get; set; }
        [Display(Name = "TEACHER")]
        public String TEACHER { get; set; }
        [Display(Name = "GRADE")]
        public String GRADE { get; set; }
        [Display(Name = "ROOM NUMBER")]
        public String ROOM_NUMBER { get; set; }
        [Display(Name = "CLASS ALLOCATION DATE")]
        public DateTime ALLOCATION_DATE { get; set; }
    }

    #region GET LIST OF ACTIVE STUDENTS

    public class ActiveStudent
    {
        public int STUDENT_ID { get; set; }
        public String FIRST_NAME { get; set; }
        public String LAST_NAME { get; set; }
    }

    public class ActiveStudents : ResponseModel
    {
        public List<ActiveStudent> ActiveStudentsList;
    }

    #endregion
}