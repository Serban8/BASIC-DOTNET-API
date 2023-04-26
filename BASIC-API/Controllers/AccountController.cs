using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BASIC_API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserService userService;

        public AccountController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register/student")]
        public IActionResult RegisterStudent(RegisterDto registerData)
        {
            var result = userService.RegisterStudent(registerData);
            return Ok();
        }

        [HttpPost("register/teacher")]
        public IActionResult RegisterTeacher(RegisterDto registerData)
        {
            var result = userService.RegisterTeacher(registerData);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto payload)
        {
            var jwtToken = userService.Validate(payload);

            return Ok(new { token = jwtToken });
        }
    }
}
