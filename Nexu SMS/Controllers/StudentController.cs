using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;


namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepo studentRepo;

        public  StudentController(StudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        [HttpGet("Get_all_Student")]
        public IActionResult Get()
        {
            return Ok(studentRepo.GetAll());
        }

        [HttpGet("Get_student_by_id{id}")]
        public IActionResult GetStudentById(string id)
        {
            return Ok(studentRepo.Get(id));
        }

        [HttpPost("Add_Student")]
        public IActionResult AddStudent(Student student)
        {
            studentRepo.Add(student);
            return Ok("Student Added");
        }

        [HttpDelete("Delete_Student{id}")]
        public IActionResult DeleteStudent(string id) 
        {
            studentRepo.Delete(id);
            return Ok("Student Deleted");
        }
        [HttpPut("Edit_Student")]
        public IActionResult EditStudent(Student student)
        {
            studentRepo.Update(student);
            return Ok(student);
        }

        [HttpPost("Register_student")]
        public IActionResult RegisterStudent(Student student)
        {
            studentRepo.AddStudentVal(student);
            return /*Ok(student);*/ StatusCode(200);
        }


    }
}
