using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restful_CRUD_API_Repo_Pattern.Model;
using Restful_CRUD_API_Repo_Pattern.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(_studentService.GetStudents());
        }
        [HttpPost]
        public IActionResult AddStudent(StudentModel studentModel)
        {
            return Ok(_studentService.AddStudent(studentModel));
        }

        [HttpPut]
        public IActionResult UpdateStudent(StudentModel studentModel, int id)
        {
            return Ok(_studentService.UpdateStudent(studentModel, id));
        }
    }
}
