using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using Nexu_SMS.Repository;
 
namespace Nexu_SMS.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class DisplayAttendanceRepoController : ControllerBase

    {

        private readonly DisplayAttendanceRepo DisplayAttendanceRepo;

        public DisplayAttendanceRepoController(DisplayAttendanceRepo DisplayAttendanceRepo)

        {

            this.DisplayAttendanceRepo = DisplayAttendanceRepo;

        }

        [HttpGet("DisplayTeacherAttendence")]

        public IActionResult TDisplay(string id, DateTime startdt, DateTime enddt)

        {

            return Ok(DisplayAttendanceRepo.TDisplay(id, startdt, enddt));

        }

        [HttpGet("DisplayStudentAttendence")]

        public IActionResult SDisplay(string id, DateTime startdt, DateTime enddt)

        {

            return Ok(DisplayAttendanceRepo.SDisplay(id, startdt, enddt));

        }

    }

}
