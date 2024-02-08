using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.DTO;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;


namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher")]

    public class S_AttendanceController : ControllerBase
    {
        private readonly SAttendanceRepo sattendanceRepo;
        private readonly IMapper mapper;

        public S_AttendanceController(SAttendanceRepo sattendanceRepo, IMapper mapper)
        {
            this.sattendanceRepo = sattendanceRepo;
            this.mapper = mapper;
        }

        [HttpPost("AddStudentAttadndace")]
        [AllowAnonymous]
        public IActionResult AddSAttendance(SAttendancedto attendance)
        {

            SAttendance sAttendance = mapper.Map<SAttendance>(attendance);
            if (ModelState.IsValid)
            {
                sattendanceRepo.Add(sAttendance);

                return Ok(sAttendance);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpPut("UpdateStudentAttendance")]
        [AllowAnonymous]
        public IActionResult UpdateSAttandance(SAttendancedto attendance)
        {
            SAttendance sAttendance = mapper.Map<SAttendance>(attendance);
            if (ModelState.IsValid)
            {
                sattendanceRepo.Update(sAttendance);
                return Ok(sAttendance);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet("GetStudentAttandanceById/{id}")]
        //[Authorize(Roles = "Admin,Teacher,Student")]
        [AllowAnonymous]

        public IActionResult GetAllAttendance(string id)
        {
            return Ok(sattendanceRepo.Get(id));
        }

        [HttpGet("GetAllStudentAttendance")]
        [AllowAnonymous]
        public IActionResult GeSAttendance()
        {
            return Ok(sattendanceRepo.GetAll());
        }
    }
}
