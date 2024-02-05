using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexu_SMS.Entity;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepo usersRepo;

        public UsersController(UsersRepo usersRepo)
        {
            this.usersRepo = usersRepo;
        }
        [HttpPost("Adduser")]
        public IActionResult AddUser(Users user)
        {
            usersRepo.Add(user);
            return Ok(user);
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(usersRepo.GetAll());
        }
        [HttpPut("EditUser")]
        public IActionResult UpdateUser(Users user)
        {
            usersRepo.Update(user);
            return Ok(user);
        }
        [HttpDelete("DeleteUser/{uid}")]
        public IActionResult DeleteUser(string uid)
        {
            usersRepo.Delete(uid);
            return Ok("User deleted");
        }
    }
}
