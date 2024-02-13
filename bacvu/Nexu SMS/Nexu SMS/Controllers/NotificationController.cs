using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationRepository notificationRepository;

        public NotificationController(NotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }

        [HttpPost, Route("AddNotification")]
        public IActionResult Add([FromBody] Notification notification)
        {
            notificationRepository.Add(notification);
            return Ok(notification);
        }
        [HttpPut, Route("EditNotification")]
        public IActionResult Update([FromBody] Notification notification)
        {
            notificationRepository.Update(notification);
            return Ok(notification);
        }
        [HttpGet, Route("GetNotification")]
        public IActionResult GetAll()
        {
            return Ok(notificationRepository.GetAll());
        }
        [HttpDelete, Route("DeleteNotification")]
        public IActionResult Delete(string id)
        {
            notificationRepository.Delete(id);
            return Ok("Notification Deleted");
        }
    }
}
