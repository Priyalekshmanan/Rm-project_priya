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
    public class ClassMController : ControllerBase
    {
        private readonly ClassManagementRepo classManagementrepo;
        private readonly IMapper mapper;

        public ClassMController(ClassManagementRepo classManagementrepo, IMapper mapper)
        {
            this.classManagementrepo = classManagementrepo;
            this.mapper = mapper;
        }
        [HttpPost("AssignClass")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]

        public IActionResult AssignClass(Classdto classdto)
        {
            /*
                        try
                        {
                            classManagementrepo.Add(classManagement);
                            return Ok(classManagement);
                        }
                        catch (Exception)
                        {

                            throw;
                        }*/

            ClassManagement Class = mapper.Map<ClassManagement>(classdto);
            if (ModelState.IsValid)
            {
                classManagementrepo.Add(Class);

                return Ok(Class);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
        [HttpGet("id")]
        // [Authorize(Roles = "Admin,Teacher")]
        [AllowAnonymous]

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
        //[Authorize(Roles = "Admin,Teacher")]
        [AllowAnonymous]

        public IActionResult GetAllClass()
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
        // [Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public IActionResult UpdateClass(Classdto classdto)
        {
            ClassManagement classs = mapper.Map<ClassManagement>(classdto);
            if (ModelState.IsValid)
            {
                classManagementrepo.Update(classs);
                return Ok(classs);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };

        }
        [HttpDelete("DeleteClass")]
        // [Authorize(Roles = "Admin")]
        [AllowAnonymous]

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
