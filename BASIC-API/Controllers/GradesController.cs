using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BASIC_API.Controllers
{
    [ApiController]
    [Route("api/grades")]
    public class GradesController : ControllerBase
    {
        private readonly GradeService gradeService;

        public GradesController(GradeService gradeService)
        {
            this.gradeService = gradeService;
        }
    }
}
