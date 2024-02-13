using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.DTO;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;


namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class TeacherController : ControllerBase
    {
        private TeacherRepo teacherRepository;
        private readonly IMapper mapper;

        public TeacherController(TeacherRepo teacherRepository,IMapper mapper)
        {
            this.teacherRepository = teacherRepository;
            this.mapper = mapper;
        }
        //Adding teachers
        [HttpPost("AddTeacher")]
        [AllowAnonymous]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            try
            {
         /*       if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var teacher=mapper.Map<Teacher> (teacherdto);*/
                teacherRepository.Add (teacher);
                return Ok(teacher);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //retrieving existing teachers details
        [HttpGet, Route("getAllExistingTeachers")]
        [AllowAnonymous]
        public IActionResult GetTeachers()
        {
            try
            {
                /* List<Teacher> teachers = teacherRepository.GetAll();*/
                /*  if (teachers == null)
                  {
                      return NotFound("No teachers found.");
                  }*/

                /* List<Teacherdto> teacherdto = mapper.Map<List<Teacherdto>>(teachers);*/
                return Ok(teacherRepository.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
        }
        //retrieving teachers by their Id
        [HttpGet, Route("getTeachersByTheirId/{teacherId}")]
        //[Authorize(Roles = "Admin,Teacher")]
        [AllowAnonymous]

        public IActionResult GetTeacherById(string teacherId)
        {
            try
            {
                /* List<Teacher> teachers = teacherRepository.GetTeachersByClass(teacherId);
                 List<Teacherdto> teacherdtos = mapper.Map<List<Teacherdto>>(teachers);
                 return Ok(teacherdtos);*/
                /*var teacher = teacherRepository.GetTeacherById(teacherId);
                if (teacher == null)
                {
                    return NotFound($"Teacher with ID {teacherId} not found.");
                }
                var teacherdto = mapper.Map<Teacherdto>(teacher);*/
                //Teacher t1 = teacherRepository.Get(teacherId);
                //Teacherdto teacherDTO = mapper.Map<Teacherdto>(t1);
                return Ok(teacherRepository.Get(teacherId));

            }
            catch (Exception)
            {

                throw;
            }
        }
        //Updating teachers on their Id basis
        //[HttpPut("updatingTeachersById")]
       /* [Authorize(Roles = "Admin,Teacher")]*/
        [AllowAnonymous]

       /* public IActionResult UpdateTeacher([FromBody] Teacher teacher)
        {
            try
            {
                //var teacher = mapper.Map<Teacher>(teacherdto);
                teacherRepository.UpdateTeacher(teacher);
                return Ok(teacher);
            }
            catch (Exception)
            {

                throw;
            }
        }*/
        [HttpPut, Route("updatingTeachersById")]
        public IActionResult UpdateTeacher([FromBody] TeacherUpdatedto teacher)
        {
            Teacher teacherupdate = mapper.Map<Teacher>(teacher);
            if (ModelState.IsValid)
            {
                teacherRepository.Update(teacherupdate);
                return Ok(teacherupdate);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpDelete("deleteTeacherById/{teacherId}")]
        [AllowAnonymous]
        public IActionResult DeleteTeacher(string teacherId)
        {
            try
            {
                teacherRepository.Delete(teacherId);
                return Ok($"Deleted the teacher with teacherId{teacherId}");
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("TeacherbySubject/{teacherSubject}")]
        [AllowAnonymous]
        public IActionResult GetTeachersBySubject(string teacherSubject)
        {
            try
            {
                List<Teacher> teachers = teacherRepository.GetTeachersBySubject(teacherSubject);
                List<Teacherdto> teacherdtos = mapper.Map<List<Teacherdto>>(teachers);
                /* var teachers = teacherRepository.GetTeachersBySubject(teacherSubject);
                 if (teachers == null)
                 {
                     return NotFound($"Teacher with subject {teacherSubject} not found.");
                 }
                 var teacherdto = mapper.Map<List<Teacherdto>>(teachers);*/
                return Ok(teacherdtos);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
