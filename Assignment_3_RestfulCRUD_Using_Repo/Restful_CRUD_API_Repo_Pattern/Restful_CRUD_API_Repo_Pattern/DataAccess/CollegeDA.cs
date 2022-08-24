using Restful_CRUD_API_Repo_Pattern.Data;
using Restful_CRUD_API_Repo_Pattern.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.DataAccess
{
    public interface ICollegeDA
    {
        IEnumerable<College> Colleges();
        College Colleges(int id);
        Task<College> College(College collegeObj);
        College College(College college, int id);
        College Delete(int id);
    };
    public class CollegeDA : ICollegeDA
    {
        private readonly ApplicationDbContext _context;

        public CollegeDA(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<College> Colleges()
        {
            return _context.Colleges.ToList();
        }
        public College Colleges(int id)
        {
            return _context.Colleges.FirstOrDefault(s => s.Id == id);
        }
        public async Task<College> College(College collegeObj)
        {
            var add_college_obj = await _context.Colleges.AddAsync(collegeObj);
            _context.SaveChanges();
            //Error Occured: A possible object cycle was detected. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
            //Consider using ReferenceHandler.Preserve on JsonSerializerOptions to support cycles.

            //Solution: Removed await from _context.SaveChangesAsync()
            return add_college_obj.Entity;
        }

        public College College(College college, int id)
        {
            var update_college_obj = _context.Colleges.Where(s => s.Id == id).ToList();
            foreach(var element in update_college_obj)
            {
                if(element.Id == id)
                {
                    element.Name = college.Name;
                    element.Address = college.Address;
                    element.University = college.University;
                    var updated_data = _context.Colleges.Update(element);
                    _context.SaveChanges();
                    return updated_data.Entity;
                }
            }
            return college;
        }

        public College Delete(int id)
        {
            var delete_college_obj = _context.Colleges.Where(s => s.Id == id).FirstOrDefault();
            if( delete_college_obj.Id == id)
            {
                _context.Colleges.Remove(delete_college_obj);
                _context.SaveChanges();
                return delete_college_obj;
            }
            return null;
        }
    }
}
