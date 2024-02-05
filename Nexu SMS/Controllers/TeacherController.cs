using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private TeacherRepo teacherRepository;

        public TeacherController(TeacherRepo teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }
        //Adding teachers
        [HttpPost]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            try
            {
                teacherRepository.AddTeacher(teacher);
                return Ok(teacher);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //retrieving existing teachers details
        [HttpGet, Route("getAllExistingTeachers")]
        public IActionResult GetTeachers()
        {
            try
            {
                var teachers = teacherRepository.GetTeachers();
                return Ok(teachers);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //retrieving teachers by their Id
        [HttpGet, Route("getTeachersByTheirId/{teacherId}")]
        public IActionResult GetTeacherById(string teacherId)
        {
            try
            {
                var teacher = teacherRepository.GetTeacherById(teacherId);
                if (teacher == null)
                {
                    return NotFound($"Teacher with ID {teacherId} not found.");
                }
                return Ok(teacher);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Updating teachers on their Id basis
        [HttpPut("updatingTeachersById")]
        public IActionResult UpdateTeacher([FromBody] Teacher teacher)
        {
            try
            {
                teacherRepository.UpdateTeacher(teacher);
                return Ok($"teacher {teacher.teacherId} is Updated ");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("deleteTeacherById/{teacherId}")]
        public IActionResult DeleteTeacher(string teacherId)
        {
            try
            {
                teacherRepository.DeleteTeacher(teacherId);
                return Ok($"Deleted the teacher with teacherId{teacherId}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("byClass/{teacherClass}")]
        public IActionResult GetTeachersByClass(string teacherClass)
        {
            try
            {
                var teachers = teacherRepository.GetTeachersByClass(teacherClass);
                if (teachers == null)
                {
                    return NotFound($"Teacher with class {teacherClass} not found.");
                }
                return Ok(teachers);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("bySubject/{teacherSubject}")]
        public IActionResult GetTeachersBySubject(string teacherSubject)
        {
            try
            {
                var teachers = teacherRepository.GetTeachersBySubject(teacherSubject);
                if (teachers == null)
                {
                    return NotFound($"Teacher with subject {teacherSubject} not found.");
                }
                return Ok(teachers);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
