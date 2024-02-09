using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.DTO;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;
using Nexu_SMS.Profiles;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class ExamController : ControllerBase
    {
        private readonly ExamRepo examRepo;
        private readonly IMapper mapper;

        public ExamController(ExamRepo examRepo, IMapper mapper)
        {
            this.examRepo = examRepo;
            this.mapper = mapper;
        }

        [HttpPost, Route("AddExam")]
        [AllowAnonymous]
        public IActionResult Add(Examdto examdto)
        {
           
           Exam exams = mapper.Map<Exam>(examdto);
            if (ModelState.IsValid)
            {
                examRepo.Add(exams);

                return Ok(exams);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }


      
    
        [HttpGet("GetExamById/{id}")]
        [AllowAnonymous]
        public IActionResult Get(string id)
        {
            var exam = examRepo.Get(id);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);

        }
        [HttpGet("GetAllExam")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            try
            {
                var exam = examRepo.GetAll();
                return Ok(exam);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("UpdateXamDetails")]
        [AllowAnonymous]
        public IActionResult Update(Examdto examdto)
        {

            Exam examss = mapper.Map<Exam>(examdto);
            if (ModelState.IsValid)
            {
                examRepo.Update(examss);
                return Ok(examss);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };

        }
        [HttpDelete("DeleteExam/{id}")]
        [AllowAnonymous]
        public IActionResult DeleteExams(string id)
        {
            try
            {
                examRepo.Delete(id);
                return Ok("deleted");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
