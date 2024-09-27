using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace school_management_app.Models
{
    public class AddressModel : ResponseModel
    {
        public int ADDRESS_ID { get; set; }
        public String STREET { get; set; }
        public String CITY { get; set; }
        public String STATE { get; set; }
        public String COUNTRY {  get; set; }
    }
}
