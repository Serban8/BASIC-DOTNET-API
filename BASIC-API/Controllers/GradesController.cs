using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace BASIC_API.Controllers
{
    [ApiController]
    [Route("api/grades")]
    [Authorize]
    public class GradesController : ControllerBase
    {
        private readonly GradeService gradeService;

        public GradesController(GradeService gradeService)
        {
            this.gradeService = gradeService;
        }

        [HttpGet("get-all")]
        //[AllowAnonymous]
        //[Authorize(Roles = "Teacher,Student")]
        public ActionResult<List<StudentWithGradesDto>> GetAll() 
        {
            //get access token and remove "Bearer " from it
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString()[7..];
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);
            var userRole = token.Claims.First(c => c.Type == "role").Value;
            var userId = int.Parse(token.Claims.First(c => c.Type == "userId").Value);

            if (userRole == "Teacher") //TODO: Make use of the roles enum
            {
                var result = gradeService.GetAll();
                return Ok(result);
            }
            else if (userRole == "Student")
            {
                var result = gradeService.GetByStudentId(userId);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
