using school_management_app.Models;
using school_management_app.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services
{
    public class SubjectService : ISubjectsRepository
    {
        private readonly DataSource _dataSource;
        private readonly ICommonRepository _commonService;

        public SubjectService()
        {
            _dataSource = new DataSource();
            _commonService = new CommonService();
        }

        public List<SubjectModel> GetNamesForReference()
        {
            String query = $"SELECT * FROM SCHOOLMANAGEMENT.SUBJECTS s";

            List<SubjectModel> subjectModels = _dataSource.ExecuteQueryAndConvertToList<SubjectModel>(query);

            return subjectModels;
        }
    }
}
