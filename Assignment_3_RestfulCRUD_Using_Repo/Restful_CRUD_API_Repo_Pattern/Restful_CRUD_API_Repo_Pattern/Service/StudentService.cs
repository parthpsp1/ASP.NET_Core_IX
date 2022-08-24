using Restful_CRUD_API_Repo_Pattern.DataAccess;
using Restful_CRUD_API_Repo_Pattern.Entities;
using Restful_CRUD_API_Repo_Pattern.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.Service
{
    public interface IStudentService
    {
        public IEnumerable<StudentModel> Students();
        public StudentModel GetStudentById(int id);
        public Task<StudentModel> Student(StudentModel studentModel);
        public StudentModel Student(StudentModel studentModel, int Id);
        public Student Delete(int id);

    }
    public class StudentService : IStudentService
    {
        private readonly IStudentDA _studentDA;
        public StudentService(IStudentDA studentDA)
        {
            _studentDA = studentDA;
        }
        public IEnumerable<StudentModel> Students()
        {
            var all_students = _studentDA.Students();
            List<StudentModel> list = new();
            foreach (var student in all_students)
            {
                list.Add( new StudentModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    Phone = student.Phone,
                    DateOfBirth = student.DateOfBirth,
                    CollegeId = student.CollegeId,
                });
            }
            return list;
        }

        public async Task<StudentModel> Student(StudentModel studentModel)
        {
            var new_student_entity = new Student
            {
                Id = studentModel.Id,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Email = studentModel.Email,
                Phone = studentModel.Phone,
                DateOfBirth = studentModel.DateOfBirth,
                CollegeId = studentModel.CollegeId,
            };

            var add_student = await _studentDA.Student(new_student_entity);
            return new StudentModel { Id = add_student.Id };
        }

        public StudentModel Student(StudentModel studentModel, int Id)
        {
            var update_student_entity = new Student
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Email = studentModel.Email,
                Phone = studentModel.Phone,
                DateOfBirth = studentModel.DateOfBirth,
                CollegeId = studentModel.CollegeId,
            };
            var update_student = _studentDA.Student(update_student_entity, Id);
            return new StudentModel { Id = update_student.Id };
        }

        public Student Delete(int id)
        {
            var delete_data = _studentDA.Delete(id);
            return new Student
            {
                Id = delete_data.Id,
                FirstName = delete_data.FirstName,
                LastName = delete_data.LastName
            };
        }

        public StudentModel GetStudentById(int id)
        {
            var student_by_id = _studentDA.Students(id);
            if (student_by_id == null)
                return null;
            else
            {
                return new StudentModel
                {
                    Id = student_by_id.Id,
                    FirstName = student_by_id.FirstName,
                    LastName = student_by_id.LastName,
                    DateOfBirth = student_by_id.DateOfBirth,
                    Email = student_by_id.Email,
                    Phone = student_by_id.Phone,
                    CollegeId = student_by_id.CollegeId
                };
            }
        }
    }
}