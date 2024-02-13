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
    [Authorize(Roles = "Admin,Teacher")]

    public class T_AttendanceController : ControllerBase
    {
        private readonly TAttandanceRepo tattendanceRepo;
        private readonly IMapper mapper;

        public T_AttendanceController(TAttandanceRepo tattendanceRepo, IMapper mapper)
        {
            this.tattendanceRepo = tattendanceRepo;
            this.mapper = mapper;   
        }

        [HttpPost("AddTeacherAttadndace")]
        [AllowAnonymous]
        public IActionResult AddTAttendance(TAttendancedto attendance)
        {
            TAttendance tAttendance = mapper.Map<TAttendance>(attendance);
            if (ModelState.IsValid)
            {

                tattendanceRepo.Add(tAttendance);

                return Ok(tAttendance);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpPut("UpdateTeacherAttendance")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]

        public IActionResult UpdateTAttandance(TAttendancedto attendance)
        {

            TAttendance tAttendance = mapper.Map<TAttendance>(attendance);
            if (ModelState.IsValid)
            {
                tattendanceRepo.Update(tAttendance);
                return Ok(tAttendance);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet("GetTeacherAttandance")]
        [AllowAnonymous]
        public IActionResult GetAllAttendance(string id)
        {
            return Ok(tattendanceRepo.Get(id));
        }

        [HttpGet("GetAllTeacherAttendance")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]

        public IActionResult GetAttendance()
        {
            return Ok(tattendanceRepo.GetAll());
        }
    }
}
