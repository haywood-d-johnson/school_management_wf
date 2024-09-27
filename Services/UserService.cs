using school_management_app.Models;
using school_management_app.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace school_management_app.Services
{
    public class UserService : IUserRepository
    {
        private readonly DataSource _dataSource;

        public UserService() 
        { 
            _dataSource = new DataSource();
        }

        public UserModel ValidateUserByEmailAndPassword(UserModel user)
        {
            String queryString = "SELECT * FROM SCHOOLMANAGEMENT.USERS USR WHERE USR.EMAIL = '{0}' AND USR.PASSWORD_HASH = '{1}'";

            String query = String.Format(queryString, user.EMAIL, user.PASSWORD_HASH);

            List<UserModel> res = _dataSource.ExecuteQueryAndConvertToList<UserModel>(query.ToString());

            if (res.Count > 0) 
            { 
                UserModel UserResponse = res.FirstOrDefault();

                UserResponse.RESPONSE_STATUS = EnumService.StatusConstants.Found;
                UserResponse.RESPONSE_MESSAGE = "User data found";

                return UserResponse;    
            }
            else
            {
                return new UserModel() {RESPONSE_STATUS = EnumService.StatusConstants.NotFound, RESPONSE_MESSAGE = "Email/Password combination incorrect. Please Try again" };
            }
        }

        public String GenerateUserGreeting(UserModel user)
        {
            StringBuilder sb = new StringBuilder();

            int hour = DateTime.Now.Hour;

            string greeting;
            if (hour < 12)
            {
                greeting = "GOOD MORNING";
            }
            else if (hour < 17)
            {
                greeting = "GOOD AFTERNOON";
            }
            else
            {
                greeting = "GOOD EVENING";
            }

            return $"{greeting}, {user.FIRST_NAME} {user.LAST_NAME}!";
        }

        public String FormatDateToString(DateTime date)
        {
            return date.ToString("MMMM dd, yyyy");
        }

        public string FormatPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");

            if (phoneNumber.Length != 10)
            {
                throw new ArgumentException("Invalid phone number format.");
            }

            return string.Format("{0:###-###-####}", long.Parse(phoneNumber));
        }

        public string UnformatPhoneNumber(string phoneNumber)
        {
            string unformattedPhoneNumber = phoneNumber.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");

            return unformattedPhoneNumber;
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }

        public UserModel ValidateUpdateInfoForStudents(UserModel user)
        {
            bool validateEmail = IsValidEmail(user.EMAIL);
            if (!validateEmail && !IsValidPhoneNumber(user.PHONE_NUMBER))
            {
                return new UserModel() { RESPONSE_STATUS = EnumService.StatusConstants.Error, RESPONSE_MESSAGE = "Invalid email format" };
            }
            else 
            {
                user.RESPONSE_STATUS = EnumService.StatusConstants.Success;
                user.RESPONSE_MESSAGE = "Email Valid";

                return user;
            }
        }

        public UserModel GetById(int id)
        {
            String query = $"SELECT * FROM SCHOOLMANAGEMENT.USERS WHERE USER_ID = {id}";

            List<UserModel> returnUser = _dataSource.ExecuteQueryAndConvertToList<UserModel>(query);

            return returnUser.FirstOrDefault();
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return false;
            }

            // Regular expression patterns for various phone number formats
            string[] patterns = {
                @"^\d{10}$", // 10-digit US phone number
                @"^\+\d{11,12}$", // International phone number with country code
                @"^\(\d{3}\)\s?\d{3}-\d{4}$", // US phone number with parentheses and dashes
                @"^\d{3}-\d{3}-\d{4}$" // US phone number with dashes
            };

            foreach (string pattern in patterns)
            {
                if (Regex.IsMatch(phoneNumber, pattern))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
