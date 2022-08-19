using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
