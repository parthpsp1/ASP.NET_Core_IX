using Restful_CRUD_API_Repo_Pattern.Data;
using Restful_CRUD_API_Repo_Pattern.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.DataAccess
{
    public interface ICollegeDA
    {

        IEnumerable<College> GetColleges();
    };
    public class CollegeDA : ICollegeDA
    {
        private readonly ApplicationDbContext _context;

        public CollegeDA(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<College> GetColleges()
        {
            return _context.College_Table.ToList();

        }
    }
}
