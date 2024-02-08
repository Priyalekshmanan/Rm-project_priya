using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;

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
        [HttpPost("Add_Exam")]

        public IActionResult Add([FromBody] Exam entity)
        {
            try
            {
                examRepo.Add(entity);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetExamById/{id}")]
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
        public IActionResult UpdateExam(string id, [FromBody] Exam entity)
        {

            if (id != entity.examId)
            {
                return BadRequest("Mismatched");
            }
            try
            {
                examRepo.Update(entity);
                return Ok(entity);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpDelete("DeleteExam/{id}")]
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
