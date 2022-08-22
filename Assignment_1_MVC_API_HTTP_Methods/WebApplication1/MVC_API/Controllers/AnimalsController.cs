using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public string GetAnimals()
        {
            return "I am an animal via Get HTTP Method";
        }

        [HttpPost]
        public string PostAnimals()
        {
            return "I am an animal via Post HTTP Method";
        }

        [HttpPut]
        public string PutAnimals()
        {
            return "I am an animal via Put HTTP Method";
        }

        [HttpDelete]
        public string DeleteAnimals()
        {
            return "I am an animal via Delete HTTP Method";
        }

        [HttpPatch]
        public string PatchAnimals()
        {
            return "I am an animal via Patch HTTP Method";
        }
    }
}
