using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReultController : ControllerBase
    {
        private readonly ResultRepo resultrepo;

        public ReultController(ResultRepo resultrepo)
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
        [HttpDelete("Delete_Result{id}")]
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
        [HttpPut("Update_Student")]
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
        [HttpGet("Get_all_Mark")]
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
        [HttpGet("Get_studentmark_by_id{id}")]
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
