using Restful_CRUD_API_Repo_Pattern.Data;
using Restful_CRUD_API_Repo_Pattern.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.DataAccess
{
    public interface ICollegeDA
    {
        IEnumerable<CollegeEntity> GetColleges();
        CollegeEntity GetCollegeById(int id);
        Task<CollegeEntity> AddCollege(CollegeEntity collegeObj);
        CollegeEntity UpdateCollege(CollegeEntity college, int id);
        CollegeEntity DeleteCollege(int id);
    };
    public class CollegeDA : ICollegeDA
    {
        private readonly ApplicationDbContext _context;

        public CollegeDA(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<CollegeEntity> GetColleges()
        {
            return _context.College_Table.ToList();
        }
        public CollegeEntity GetCollegeById(int id)
        {
            return _context.College_Table.FirstOrDefault(s => s.Id == id);
        }
        public async Task<CollegeEntity> AddCollege(CollegeEntity collegeObj)
        {
            var add_college_obj = await _context.College_Table.AddAsync(collegeObj);
            _context.SaveChanges();
            //Error Occured: A possible object cycle was detected. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
            //Consider using ReferenceHandler.Preserve on JsonSerializerOptions to support cycles.

            //Solution: Removed await from _context.SaveChangesAsync()
            return add_college_obj.Entity;
        }

        //public  Task<College> AddCollege(College collegeObj)
        //{
        //    var add_college_obj =  _context.College_Table.Add(collegeObj);
        //    await _context.SaveChanges();
        //    return add_college_obj.Entity;
        //}
        public CollegeEntity UpdateCollege(CollegeEntity college, int id)
        {
            var update_college_obj = _context.College_Table.Where(s => s.Id == id).ToList();
            foreach(var element in update_college_obj)
            {
                if(element.Id == id)
                {
                    element.Name = college.Name;
                    element.Address = college.Address;
                    element.University = college.University;
                    var updated_data = _context.College_Table.Update(element);
                    _context.SaveChanges();
                    return updated_data.Entity;
                }
            }
            return college;
        }

        public CollegeEntity DeleteCollege(int id)
        {
            var delete_college_obj = _context.College_Table.Where(s => s.Id == id).FirstOrDefault();
            if( delete_college_obj.Id == id)
            {
                _context.College_Table.Remove(delete_college_obj);
                _context.SaveChanges();
                return delete_college_obj;
            }
            return null;
        }
    }
}
