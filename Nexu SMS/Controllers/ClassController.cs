using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private static List<ClassModel> classes = new List<ClassModel>();

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(classes);
        }

       

        [HttpGet("Details/{id}")]
        public IActionResult Details(int id)
        {
            ClassModel model = classes.Find(c => c.ClassId == id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("AssignTeacher/{id}")]
        public IActionResult AssignTeacher(int id, [FromBody] string teacher)
        {
            ClassModel model = classes.Find(c => c.ClassId == id);
            if (model == null)
            {
                return NotFound();
            }

            // Assign teacher
            model.Teacherid = teacher;

            return RedirectToAction("Details", new { id = id });
        }

       
        

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            ClassModel model = classes.Find(c => c.ClassId == id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }


       

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            ClassModel model = classes.Find(c => c.ClassId == id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

      








    }
}
