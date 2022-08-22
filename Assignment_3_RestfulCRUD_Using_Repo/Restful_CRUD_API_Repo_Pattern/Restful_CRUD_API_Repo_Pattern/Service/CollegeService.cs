using Restful_CRUD_API_Repo_Pattern.DataAccess;
using Restful_CRUD_API_Repo_Pattern.Model;
using System.Collections.Generic;

namespace Restful_CRUD_API_Repo_Pattern.Service
{
    public interface ICollegeService
    {
        public IEnumerable<CollegeModel> GetCollege();
    }
    public class CollegeService : ICollegeService
    {
        private readonly ICollegeDA _collegeDA;
        public CollegeService(ICollegeDA collegeDA)
        {
            _collegeDA = collegeDA;
        }
        public IEnumerable<CollegeModel> GetCollege()
        {
            var all_colleges = _collegeDA.GetColleges();
            List<CollegeModel> college_list = new();
            foreach (var element in all_colleges)
            {
                college_list.Add(new CollegeModel
                {
                    Id = element.Id,
                    Name = element.Name,
                    University = element.University,
                    Address = element.Address,
                    District = element.District
                });
            }
            return college_list;
        }
    }
}