using Restful_CRUD_API_Repo_Pattern.DataAccess;
using Restful_CRUD_API_Repo_Pattern.Entities;
using Restful_CRUD_API_Repo_Pattern.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.Service
{
    public interface IStudentService
    {
        public IEnumerable<StudentModel> GetStudents();
        Task<StudentModel> AddStudent(StudentModel studentModel);
        StudentModel UpdateStudent(StudentModel studentModel, int Id);
        Student DeletStudent(int id);

    }
    public class StudentService : IStudentService
    {
        private readonly IStudentDA _studentDA;
        public StudentService(IStudentDA studentDA)
        {
            _studentDA = studentDA;
        }
        public IEnumerable<StudentModel> GetStudents()
        {
            var all_students = _studentDA.GetStudents();
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

        public async Task<StudentModel> AddStudent(StudentModel studentModel)
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

            var add_student = await _studentDA.AddStudent(new_student_entity);
            return new StudentModel { Id = add_student.Id };
        }

        public StudentModel UpdateStudent(StudentModel studentModel, int Id)
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
            var update_student = _studentDA.UpdateStudent(update_student_entity, Id);
            return new StudentModel { Id = update_student.Id };
        }

        public Student DeletStudent(int id)
        {
            var delete_data = _studentDA.DeletStudent(id);
            return new Student
            {
                Id = delete_data.Id,
                FirstName = delete_data.FirstName,
                LastName = delete_data.LastName
            };
        }
    }
}