using Restful_CRUD_API_Repo_Pattern.Data;
using Restful_CRUD_API_Repo_Pattern.DataAccess;
using Restful_CRUD_API_Repo_Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.Service
{
    public interface ICollegeService
    {
        IEnumerable<CollegeModel> GetCollege();
    }
    public class CollegeService : ICollegeService
    {

        public CollegeService(CollegeDA collegeDA)
        {
            
        }

        public IEnumerable<CollegeModel> GetCollege()
        {
            throw new NotImplementedException();
        }
    }
}
