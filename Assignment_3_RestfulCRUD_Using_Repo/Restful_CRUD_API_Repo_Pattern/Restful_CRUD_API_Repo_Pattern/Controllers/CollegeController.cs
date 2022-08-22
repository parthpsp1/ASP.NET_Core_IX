﻿using Microsoft.AspNetCore.Mvc;
using Restful_CRUD_API_Repo_Pattern.Model;
using Restful_CRUD_API_Repo_Pattern.Service;

namespace Restful_CRUD_API_Repo_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeService _collegeService;

        public CollegeController(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }

        [HttpGet]
        public IActionResult GetCollege()
        {
            return Ok(_collegeService.GetCollege());
        }

        [HttpGet("{id}")]
        public IActionResult GetCollege(int id)
        {
            return Ok(_collegeService.GetCollegeById(id));
        }

        [HttpPost]
        public IActionResult AddCollege(CollegeModel collegeModel)
        {
            return Ok(_collegeService.AddCollege(collegeModel));
        }

        [HttpPut]
        public IActionResult UpdateCollege(CollegeModel collegeModel, int id)
        {
            return Ok(_collegeService.UpdateCollege(collegeModel, id));
        }

        [HttpDelete]
        public IActionResult DeleteCollege(int id)
        {
            return Ok(_collegeService.DeleteCollege(id));
        }
    }
}
