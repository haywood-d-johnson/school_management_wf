using school_management_app.Models;
using school_management_app.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                UserResponse.STATUS = EnumService.StatusConstants.Found;
                UserResponse.MESSAGE = "User data found";

                return UserResponse;    
            }
            else
            {
                return new UserModel() { STATUS = EnumService.StatusConstants.NotFound, MESSAGE = "Email/Password combination incorrect. Please Try again" };
            }
        }
    }
}
