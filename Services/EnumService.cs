using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services
{
    public static class EnumService
    {
        public static class StatusConstants
        {
            public static String NotFound = "NOT FOUND";
            public static String Found = "FOUND";
            public static String Success = "SUCCESS";
            public static String Error = "ERROR";
        }

        public static class UserRolesConstants
        {
            public static String Student = "STUDENT";
            public static String Admin = "ADMINISTRATOR";
            public static String Teacher = "TEACHER";
        }

        public static class UserStatusConstants 
        {
            public static String Active = "ACTIVE";
            public static String Graduated = "GRADUATED";
            public static String Withdrawn = "WITHDRAWN";
            public static String Inactive = "INACTIVE";
            public static String Retired = "RETIRED";
        }
    }
}
