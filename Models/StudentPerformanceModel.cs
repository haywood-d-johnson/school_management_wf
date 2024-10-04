using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Models
{
    public class StudentPerformanceModel
    {
        public int PERFORMANCE_ID { get; set; }
        public int STUDENT_ID { get; set; }
        public int SUBJECT_ID { get; set; }
        public Char GRADE { get; set; }
        public int EXAM_DATE { get; set; }
    }

    public class StudentPerformanceModelList : ResponseModel
    {
        public List<StudentPerformanceModel> studentPerformanceList;
    }
}
