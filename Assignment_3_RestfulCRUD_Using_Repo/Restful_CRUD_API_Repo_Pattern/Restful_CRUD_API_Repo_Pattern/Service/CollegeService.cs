using Restful_CRUD_API_Repo_Pattern.DataAccess;
using Restful_CRUD_API_Repo_Pattern.Entity;
using Restful_CRUD_API_Repo_Pattern.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.Service
{
    public interface ICollegeService
    {
        public IEnumerable<CollegeModel> GetCollege();
        public CollegeModel GetCollegeById(int id);
        public Task<CollegeModel> AddCollege(CollegeModel collegeModel);
        public CollegeModel UpdateCollege(CollegeModel collegeModel, int id);
        public College DeleteCollege(int id);
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
            var all_colleges = _collegeDA.Colleges();
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
        public CollegeModel GetCollegeById(int id)
        {
            var college_by_id = _collegeDA.GetCollegeById(id);
            if (college_by_id == null)
                return null;
            else
            {
                return new CollegeModel
                {
                    Id = college_by_id.Id,
                    Name = college_by_id.Name,
                    University = college_by_id.University,
                    Address = college_by_id.Address,
                    District = college_by_id.District
                };
            }
        }

        public async Task<CollegeModel> AddCollege(CollegeModel collegeModel)
        {
            var new_college_entity = new College
            {
                Id = collegeModel.Id,
                Name = collegeModel.Name,
                Address = collegeModel.Address,
                District = collegeModel.District,
                University = collegeModel.University,
            };

            var add_college = await _collegeDA.AddCollege(new_college_entity);
            return new CollegeModel { Id = add_college.Id};
        }

        public CollegeModel UpdateCollege(CollegeModel collegeModel, int Id)
        {
            var update_college_entity = new College
            {
                Id = collegeModel.Id,
                Name = collegeModel.Name,
                Address = collegeModel.Address,
                District = collegeModel.District,
                University = collegeModel.University
            };
            var update_college = _collegeDA.UpdateCollege(update_college_entity, Id);
            return new CollegeModel { Id = update_college.Id };
        }
        public College DeleteCollege(int id)
        {
            var delete_data = _collegeDA.DeleteCollege(id);
            return new College
            {
                Id = delete_data.Id,
                Name = delete_data.Name,
                Address = delete_data.Address,
                District = delete_data.District,
                University = delete_data.University
            };
        }
    }
}