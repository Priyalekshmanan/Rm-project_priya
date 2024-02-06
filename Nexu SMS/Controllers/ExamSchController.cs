using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamSchController : ControllerBase
    {
        private readonly ExamSchRepo _examSchRepo;

        public ExamSchController(ExamSchRepo _examSchRepo)
        {
            this._examSchRepo = _examSchRepo;
        }
        [HttpPost]
        public IActionResult Add([FromBody] Exam exam)
        {

            _examSchRepo.Add(exam);
            return Ok(exam);
        }
        [HttpGet("getAllExam")]
        public IActionResult Get()
        {
            return Ok(_examSchRepo.GetAll());
        }
        [HttpPut("Update")]
        public IActionResult Update(Exam exam)
        {
            _examSchRepo.Update(exam);
            return Ok(exam);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(string id)
        {
            _examSchRepo.Delete(id);
            return Ok("Deleted");
        }
        [HttpGet("GetStudentById")]
        public IActionResult GetStudentById(string id)
        {
            return Ok(_examSchRepo.Get(id));
        }

    }
}
