using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Models
{
    public class ClassroomModel
    {
        public int CLASSROOM_ID { get; set; }
        public String ROOM_NUMBER { get; set; }
        public int CAPACITY { get; set; }
        public int ASSIGNED_TEACHER_ID { get; set; } 
    }
}
