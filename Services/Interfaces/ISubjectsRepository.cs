using school_management_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services.Interfaces
{
    public interface ISubjectsRepository
    {
        List<SubjectModel> GetNamesForReference();
    }
}
