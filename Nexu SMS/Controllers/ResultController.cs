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

    public class ResultController : ControllerBase
    {
        private readonly ResultRepo resultrepo;
        private readonly IMapper mapper;

        public ResultController(ResultRepo resultrepo,IMapper mapper)
        {
            this.resultrepo = resultrepo;
            this.mapper = mapper;
        }
        [HttpPost("Add_Result")]
        [AllowAnonymous]

        public IActionResult Add(Resultdto resultdto)
        {
          
            Result result = mapper.Map<Result>(resultdto);
            if (ModelState.IsValid)
            {
                resultrepo.Add(result);

                return Ok(result);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
        [HttpDelete("DeleteStudentById/{id}")]
        [AllowAnonymous]

        public IActionResult DeleteStudent(string id)
        {
            try
            {
                resultrepo.Delete(id);
                return Ok("Mark Deleted");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("UpdateStudent")]
        [AllowAnonymous]
        public IActionResult EditStudent(Resultdto resultdto)
        {

            Result results = mapper.Map<Result>(resultdto);
            if (ModelState.IsValid)
            {
                resultrepo.Update(results);
                return Ok(results);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
        [HttpGet("GetAllResult")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            try
            {
                return Ok(resultrepo.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetResultById/{id}")]
        [AllowAnonymous]
        public IActionResult GetStudentById(string id)
        {
            try
            {
                return Ok(resultrepo.GetBYID(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
