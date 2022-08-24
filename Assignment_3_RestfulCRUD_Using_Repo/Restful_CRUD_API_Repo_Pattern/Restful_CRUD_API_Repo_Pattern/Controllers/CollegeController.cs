using Microsoft.AspNetCore.Mvc;
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
            return Ok(_collegeService.Colleges(id));
        }

        [HttpPost]
        public IActionResult College(CollegeModel collegeModel)
        {
            return Ok(_collegeService.College(collegeModel));
        }

        [HttpPut]
        public IActionResult College(CollegeModel collegeModel, int id)
        {
            return Ok(_collegeService.College(collegeModel, id));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_collegeService.Delete(id));
        }
    }
}
