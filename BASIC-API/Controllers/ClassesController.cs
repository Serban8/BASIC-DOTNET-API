using Core.Dtos;
using Core.Services;
using DataLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BASIC_API.Controllers
{

    [ApiController]
    [Route("api/classes")]
    [Authorize]
    public class ClassesController : ControllerBase
    {
        private readonly ClassService classService;

        public ClassesController(ClassService classService)
        {
            this.classService = classService;
        }

        [HttpPost("add")]
        [Authorize(Roles = "Teacher")]
        public IActionResult Add(ClassAddDto payload)
        {
            var result = classService.Add(payload);

            if (result == null)
            {
                return BadRequest("Class cannot be added");
            }

            return Ok(result);
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public ActionResult<List<ClassViewDto>> GetAll()
        {
            var result = classService.GetAll();

            return Ok(result);
        }
    }
}
