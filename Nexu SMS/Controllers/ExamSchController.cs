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
        [HttpPost("AddExam")]
        public IActionResult Add(ExamSchdule examSchdule)
        {

        }
    }
}
