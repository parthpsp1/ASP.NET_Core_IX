using Restful_CRUD_API_Repo_Pattern.Data;
using Restful_CRUD_API_Repo_Pattern.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.DataAccess
{
    public interface IStudentDA {

        IEnumerable<Student> Students();
        Student Students(int id);
        Task<Student> Student(Student studentObj);
        Student Student(Student student, int Id);
        bool Delete(int id);

    };
    public class StudentDA : IStudentDA
    {
        private readonly ApplicationDbContext _context;
        public StudentDA(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> Students()
        {
            return _context.Students.ToList();
        }
        public Student Students(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }
        public async Task<Student> Student(Student studentObj)
        {
            var add_student_obj =  await _context.Students.AddAsync(studentObj);
            _context.SaveChanges();
            return add_student_obj.Entity;
        }

        public Student Student(Student student, int Id)
        {
            var update_student_obj =  _context.Students.Where(s => s.Id == Id).ToList();
            foreach(var element in update_student_obj)
            {
                if(Id == element.Id)
                {
                    element.FirstName = student.FirstName;
                    element.LastName = student.LastName;
                    element.Phone = student.Phone;
                    element.Email = student.Email;
                    element.DateOfBirth = student.DateOfBirth;
                    element.CollegeId = student.CollegeId;
                    var updated_data = _context.Students.Update(element);
                    _context.SaveChanges();
                    return updated_data.Entity;
                }
            }
            return student;
        }

        public bool Delete(int id)
        {
            var delete_student_obj = _context.Students.Where(s => s.Id == id).FirstOrDefault();
            if (delete_student_obj.Id == id)
            {
                _context.Students.Remove(delete_student_obj);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
