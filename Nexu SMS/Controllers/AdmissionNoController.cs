using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionNoController : ControllerBase
    {
        private readonly AdmissionRepo addNoObj;
        public AdmissionNoController(AdmissionRepo addNoObj)
        {
            this.addNoObj = addNoObj;
        }

        [HttpPost("Add admission no")]
        public IActionResult Add(AdmissionNo admissionNo)
        {

            addNoObj.AddNO(admissionNo);
            return Ok(admissionNo);
        }
    }
}
