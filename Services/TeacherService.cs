using school_management_app.Models;
using school_management_app.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services
{
    public class TeacherService : ITeacherRepository
    {
        private readonly DataSource _dataSource;

        public TeacherService()
        {
            _dataSource = new DataSource();
        }

        public TeacherModel GetTeacherModelFromUserID(UserModel user)
        {
            TeacherModel teacherModel = new TeacherModel();

            String queryString = "SELECT * FROM SCHOOLMANAGEMENT.TEACHERS t WHERE t.USER_ID = '{0}'";

            List<TeacherModel> ResTeacherList = _dataSource.ExecuteQueryAndConvertToList<TeacherModel>(String.Format(queryString, user.USER_ID));

            return ResTeacherList.FirstOrDefault();
        }
    }
}
