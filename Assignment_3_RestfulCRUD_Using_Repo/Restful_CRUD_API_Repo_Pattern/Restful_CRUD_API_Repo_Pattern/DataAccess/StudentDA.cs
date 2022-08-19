using Restful_CRUD_API_Repo_Pattern.Data;
using Restful_CRUD_API_Repo_Pattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.DataAccess
{
    public interface IStudentDA {

        IEnumerable<Student> GetStudents();
    };
    public class StudentDA : IStudentDA
    {
        private readonly ApplicationDbContext _context;
        public StudentDA(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _context.Student_Table.ToList();
        }
    }
}
