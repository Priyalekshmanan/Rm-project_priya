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

        [HttpPost("Create")]
        public IActionResult Create([FromBody] ClassModel model)
        {
            if (ModelState.IsValid)
            {
                // Validate and save the class
                model.ClassId = classes.Count + 1;
                classes.Add(model);
                return RedirectToAction("Index");
            }

            return BadRequest(ModelState);
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
            model.Teacher = teacher;

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

        [HttpPost("Edit")]
        public IActionResult Edit([FromBody] ClassModel updatedModel)
        {
            if (ModelState.IsValid)
            {
                ClassModel model = classes.Find(c => c.ClassId == updatedModel.ClassId);
                if (model != null)
                {
                    // Update class details
                    model.ClassName = updatedModel.ClassName;
                    model.Schedule = updatedModel.Schedule;
                }
                return RedirectToAction("Details", new { id = updatedModel.ClassId });
            }

            return BadRequest(ModelState);
        }

        [HttpPost("RemoveStudent/{id}")]
        public IActionResult RemoveStudent(int id, [FromBody] string student)
        {
            ClassModel model = classes.Find(c => c.ClassId == id);
            if (model != null)
            {
                // Remove student
                model.Student.Remove(student);
            }
            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            ClassModel model = classes.Find(c => c.ClassId == id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult ConfirmDelete(int id)
        {
            ClassModel model = classes.Find(c => c.ClassId == id);
            if (model != null)
            {
                // Delete class
                classes.Remove(model);
            }
            return RedirectToAction("Index");
        }








    }
}
