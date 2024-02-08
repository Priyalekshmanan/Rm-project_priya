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
    public class StudentController : ControllerBase
    {
        private readonly StudentRepo studentRepo;
        private readonly IMapper mapper;

        public  StudentController(StudentRepo studentRepo,IMapper mapper)
        {
            this.studentRepo = studentRepo;
            this.mapper = mapper;   
        }

        [HttpGet("Get_all_Student")]
        //[Authorize(Roles = "Admin,Teacher")]
        [AllowAnonymous]

        public IActionResult Get()
        {
            return Ok(studentRepo.GetAll());
        }

        [HttpGet("GetStudentById/{id}")]
        // [Authorize(Roles = "Admin,Teacher")]
        [AllowAnonymous]

        public IActionResult GetStudentById(string id)
        {
            return Ok(studentRepo.Get(id));
        }

        [HttpPost("AddStudent")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public IActionResult AddStudent(Student student)
        {
            try
            {
                studentRepo.Add(student);
                return Ok(student);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("DeleteStudent/{id}")]
        [AllowAnonymous]
        public IActionResult DeleteStudent(string id) 
        {
            try
            {
                studentRepo.Delete(id);
                return Ok($"Deleted the student with studentid{id}");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("Edit_Student")]
        [AllowAnonymous]
        public IActionResult Update([FromBody] StudentUpdatedto studentupdatedto)
        {
            Student studentupdate = mapper.Map<Student>(studentupdatedto);
            if (ModelState.IsValid)
            {
                studentRepo.Update(studentupdate);
                return Ok(studentupdate);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };

        }

        [HttpPost("RegisterStudent")]
        //[Authorize(Roles = "Admin,Teacher,Student")]
        [AllowAnonymous]
        public IActionResult RegisterStudent(Student student)
        {
            studentRepo.AddStudentVal(student);
            return /*Ok(student);*/ StatusCode(200);
        }

        [HttpGet("GetStudentByClass/{cls}")]
        //[Authorize(Roles = "Admin,Teacher")]
        [AllowAnonymous]
        public IActionResult GetStdByClass(int cls)
        {
            try
            {
                List<Student> students = studentRepo.GetStdByClass(cls);
                List<Studentdto> studentdtos = mapper.Map<List<Studentdto>>(students);
                return Ok(studentdtos);
              
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetStudentBySection/{sec}")]
        // [Authorize(Roles = "Admin,Teacher")]
        [AllowAnonymous]
        public IActionResult GetStdBySection(string sec)
        {
            /*try
            {
                List<Studentdto> studentdtos = studentRepo.GetStdBySection(sec);
                if (studentdtos == null)
                {
                    return NotFound($"Student with section {sec} not found");
                }
                return Ok(studentdtos);
            }
            catch (Exception)
            {
                throw;
            }*/
            try
            {
                var students = studentRepo.GetStdBySection(sec);
                var studentdtos = mapper.Map<List<Studentdto>>(students);
                return Ok(studentdtos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetStudentByClass,Section/{sec},{cls}")]
        //[Authorize(Roles = "Admin,Teacher")]
        [AllowAnonymous]

        public IActionResult GetStdBySectionNclass(string sec,int cls)
        {/*
            try
            {
                List<Studentdto> studentdtos = studentRepo.GetStdBySectionNclass(sec, cls);
                if (studentdtos == null)
                {
                    return NotFound($"Student with class {cls} and section {sec} not found");
                }
                return Ok(studentdtos);
            }
            catch (Exception)
            {
                throw;
            }*/
            try
            {
                var students = studentRepo.GetStdBySectionNclass(sec, cls);
                var studentdtos = mapper.Map<List<Studentdto>>(students);
                return Ok(studentdtos);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
