using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayAttendanceController : ControllerBase
    {
        private readonly DisplayAttendance displayAttendance;

        public DisplayAttendanceController(DisplayAttendance displayAttendance)
        {
            this.displayAttendance = displayAttendance;
        }
       
        [HttpGet("TAttendance")]
        public IActionResult TDis(string id, DateTime startdt, DateTime enddt)
        {
            return Ok(displayAttendance.DisplayTeacherAttendances(id, startdt, enddt));
        }
        [HttpGet("SAttendance/{id}/{startdt}/{enddt}")]
        public IActionResult SDis(string id, DateTime startdt, DateTime enddt)
        {
            return Ok(displayAttendance.DisplayStudentAttendances(id, startdt, enddt));
        }
        [HttpGet("AllTeacherAttendence")]
        public IActionResult ViewAllTeacherAttendance(DateTime startdt, DateTime enddt)
        {
            return Ok(displayAttendance.DisplayAllTeacherAttendances(startdt, enddt));
        }
        [HttpGet("AllStudentAttendence/{startdt}/{enddt}")]
        public IActionResult ViewAllStudentAttendance(DateTime startdt, DateTime enddt)
        {
            return Ok(displayAttendance.DisplayAllStudentAttendances(startdt, enddt));
        }
    }
}
