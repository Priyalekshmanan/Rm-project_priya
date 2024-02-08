using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ResultController(ResultRepo resultrepo)
        {
            this.resultrepo = resultrepo;
        }
        [HttpPost("Add_Result")]

        public IActionResult Add([FromBody] Result entity)
        {
            try
            {
                resultrepo.Add(entity);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("DeleteStudentById/{id}")]

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
        public IActionResult EditStudent(Result entity)
        {
            try
            {
                resultrepo.Update(entity);
                return Ok(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetAllResult")]
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
