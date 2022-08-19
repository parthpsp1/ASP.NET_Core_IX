using Restful_CRUD_API_Repo_Pattern.DataAccess;
using Restful_CRUD_API_Repo_Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.Service
{
    public interface IStudentService
    {
        public IEnumerable<StudentModel> GetStudents();
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
            foreach (var student in all_students){
                list.Add( new StudentModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    DateOfBirth = student.DateOfBirth,
                    CollegeId = student.CollegeId,
                });
            }
            return list;
        }
    }
}
