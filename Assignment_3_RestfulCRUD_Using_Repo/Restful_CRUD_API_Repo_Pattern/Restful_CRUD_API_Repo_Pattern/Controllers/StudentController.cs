using Microsoft.AspNetCore.Mvc;
using Restful_CRUD_API_Repo_Pattern.Model;
using Restful_CRUD_API_Repo_Pattern.Service;

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
            return Ok(_studentService.Students());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            return Ok(_studentService.GetStudentById(id));
        }

        [HttpPost]
        public IActionResult Student(StudentModel studentModel)
        {
            return Ok(_studentService.Student(studentModel));
        }

        [HttpPut]
        public IActionResult Student(StudentModel studentModel, int id)
        {
            return Ok(_studentService.Student(studentModel, id));
        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            return Ok(_studentService.Delete(id));
        }
    }
}
