using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Models
{
    public class ClassroomAllocationModel
    {
       public int STUDENT_ID { get; set; }
       public int CLASSROOM_ID { get; set; }
       public DateTime ALLOCATION_DATE { get; set; }
    }
}
