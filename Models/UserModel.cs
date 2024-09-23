using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Documents;
using System.Xml;

namespace school_management_app.Models
{
    public class UserModel : ResponseModel
    {
        public int USER_ID { get; set; }
        public String FIRST_NAME {get; set;}
        public String LAST_NAME { get; set;}
        public String EMAIL { get; set;}
        public String PHONE_NUMBER { get; set;}    
        public DateTime DATE_OF_BIRTH { get; set;}
        public int ADDRESS_ID { get; set;}  
        public String ROLES { get; set;}
        public String PASSWORD_HASH { get; set;}
        public String USTATUS { get; set; } = "ACTIVE";
    }
}
