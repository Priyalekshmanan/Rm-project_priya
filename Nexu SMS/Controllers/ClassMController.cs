using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassMController : ControllerBase
    {
        private readonly ClassManagementRepo classManagementrepo;

        public ClassMController(ClassManagementRepo classManagementrepo)
        {
            this.classManagementrepo = classManagementrepo;
        }
        [HttpPost("AssignClass")]
        [Authorize(Roles = "Admin")]

        public IActionResult AssignClass(ClassManagement classManagement)
        {

            try
            {
                classManagementrepo.Add(classManagement);
                return Ok(classManagement);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("id")]
        [Authorize(Roles = "Admin,Teacher")]

        public IActionResult GetClass(string id)
        {
            try
            {

                var classManagement = classManagementrepo.Get(id);
                if (classManagement == null)
                {
                    return NotFound();
                }
                return Ok(classManagement);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetAllClass")]
        [Authorize(Roles = "Admin,Teacher")]

        public IActionResult GetAllClass( )
        {

            try
            {
                var classManagement = classManagementrepo.GetAll();

                return Ok(classManagement);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("UpdateClass")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateClass(string id, [FromBody] ClassManagement classManagement)
        {
            if(id !=classManagement.ClassId)
            {
                return BadRequest("Class id mismatched");
            }
            try
            {
                classManagementrepo.Update(classManagement);
                return Ok(classManagement);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("DeleteClass")]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteClass(string id)
        {
            try
            {
                classManagementrepo.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
 
    
}
