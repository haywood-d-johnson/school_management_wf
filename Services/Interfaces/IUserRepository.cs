using school_management_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services.Interfaces
{
    public interface IUserRepository
    {
        UserModel GetById(int id);
        UserModel ValidateUserByEmailAndPassword(UserModel user);
        String GenerateUserGreeting(UserModel user);
        String FormatDateToString(DateTime date);
        String FormatPhoneNumber(string phoneNumber);
        String UnformatPhoneNumber(string phoneNumber);
        bool IsValidEmail(string email);
        UserModel ValidateUpdateInfoForStudents(UserModel user);
        bool IsValidPhoneNumber(string phoneNumber);
    }
}
