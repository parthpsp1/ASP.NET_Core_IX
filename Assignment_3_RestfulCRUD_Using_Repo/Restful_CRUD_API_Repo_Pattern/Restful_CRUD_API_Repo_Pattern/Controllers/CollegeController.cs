using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restful_CRUD_API_Repo_Pattern.Entity;
using Restful_CRUD_API_Repo_Pattern.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        //private readonly CollegeService _collegeService;
        //public CollegeController(CollegeService collegeService)
        //{
        //    _collegeService = collegeService;
        //}

        //[HttpGet]
        //public async Task<IEnumerable<College>> GetEmployees()
        //{
        //    return await CollegeService.GetCollege();
        //}
    }
}
