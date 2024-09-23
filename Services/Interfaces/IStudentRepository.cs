using school_management_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services
{
    public interface IStudentRepository
    {
        void Create(UserModel user, StudentModel student);
        List<StudentModel> FindAll();
        List<StudentInfo> ShowStudentInfo();
        StudentModel FindOne(StudentModel student);
        void Update(StudentModel student);
        void Delete(StudentModel student);
    }
}
