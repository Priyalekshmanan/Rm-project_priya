using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {

        private ResultRepo resultRepository;

        public ResultController(ResultRepo resultRepository)
        {
            this.resultRepository = resultRepository;
        }
        //Adding teachers
        [HttpPost]
        public IActionResult AddMark([FromBody] Result result)
        {
            try
            {
                resultRepository.Add(result);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("Deletebymarkid")]
        public IActionResult Delete(string id)
        {
            try
            {
                resultRepository.Delete(id);
                return Ok("result deleted");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("updatingMarkById")]
        public IActionResult Update([FromBody] Result result)
        {
            try
            {
                resultRepository.Update(result);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

