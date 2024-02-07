using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;
namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class T_AttendanceController : ControllerBase
    {
        private readonly TAttandanceRepo tattendanceRepo;

        public T_AttendanceController(TAttandanceRepo tattendanceRepo)
        {
            this.tattendanceRepo = tattendanceRepo;
        }

        [HttpPost("Add_Teacher_Attadndace")]
        public IActionResult AddTAttendance(TAttendance attendance)
        {
            tattendanceRepo.Add(attendance);
            return Ok(attendance);
        }

        [HttpPut("UpdateTeacherAttendance")]
        public IActionResult UpdateTAttandance(TAttendance attendance)
        {
            tattendanceRepo.Update(attendance);
            return Ok(attendance);
        }

        [HttpGet("GetTeacherAttandance")]
        public IActionResult GetAllAttendance(string id)
        {
            return Ok(tattendanceRepo.Get(id));
        }

        [HttpGet("GetAllTeacherAttendance")]
        public IActionResult GetAttendance()
        {
            return Ok(tattendanceRepo.GetAll());
        }
    }
}
