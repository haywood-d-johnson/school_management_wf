using System;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace school_management_app.Models
{
    public class StudentModel
    { 
        public int STUDENT_ID { get; set; }
        public int USER_ID { get; set; }
        public int CLASS_YEAR { get; set; }
        public DateTime ENROLLMENT_DATE { get; set; }
        public decimal ATTENDANCE_PERCENTAGE { get; set; }
        public string STATUS { get; set; } = "ACTIVE";
    }

    public class StudentInfo
    {
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public int CLASS_YEAR { get; set; }
        public DateTime ENROLLMENT_DATE { get; set; }
        public decimal ATTENDANCE_PERCENTAGE { get; set; }
        public string STATUS { get; set; }
    }

    public class StudentClassInfo
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
}