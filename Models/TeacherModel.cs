using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Models
{
    public class TeacherModel
    {
        public int TEACHER_ID { get; set; }
        public int USER_ID { get; set; }
        public String QUALIFICATION { get; set; }
        public String STATUS { get; set; } = "ACTIVE";    
    }
}
