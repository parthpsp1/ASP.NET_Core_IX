using Restful_CRUD_API_Repo_Pattern.Data;
using Restful_CRUD_API_Repo_Pattern.Entities;
using Restful_CRUD_API_Repo_Pattern.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.DataAccess
{
    public interface IStudentDA {

        public IEnumerable<Student> GetStudents();
        public Student GetStudenyById(int id);
        public Task<Student> AddStudent(Student studentObj);
        public Student UpdateStudent(Student student, int Id);
        public Student DeletStudent(int id);

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
        public async Task<Student> AddStudent(Student studentObj)
        {
            var add_student_obj = await _context.Student_Table.AddAsync(studentObj);
            _context.SaveChanges();
            return add_student_obj.Entity;
        }

        public Student UpdateStudent(Student student, int Id)
        {
            var update_student_obj =  _context.Student_Table.Where(s => s.Id == Id).ToList();
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
                    var updated_data = _context.Student_Table.Update(element);
                    _context.SaveChanges();
                    return updated_data.Entity;
                }
            }
            return student;
        }

        public Student DeletStudent(int id)
        {
            var delete_student_obj = _context.Student_Table.Where(s => s.Id == id).FirstOrDefault();
            if (delete_student_obj.Id == id)
            {
                _context.Student_Table.Remove(delete_student_obj);
                _context.SaveChanges();
                return delete_student_obj;
            }
            return null;
        }

        public Student GetStudenyById(int id)
        {
            return _context.Student_Table.FirstOrDefault(s => s.Id == id);
        }
    }
}
