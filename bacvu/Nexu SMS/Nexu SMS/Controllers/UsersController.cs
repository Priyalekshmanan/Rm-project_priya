using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Nexu_SMS.DTO;
using Nexu_SMS.Entity;
using Nexu_SMS.Models;
using Nexu_SMS.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nexu_SMS.Controllers
{
    /*  [Authorize(Roles = "Admin")]*/
    [AllowAnonymous]

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepo usersRepo;
        private readonly IConfiguration configuration;
        //private readonly IMapper mapper;

        public UsersController(UsersRepo usersRepo, IConfiguration configuration)
        {
            this.usersRepo = usersRepo;
            this.configuration = configuration;
           //this.mapper = mapper;
        }
        [HttpPost("Adduser")]
        [AllowAnonymous]
       
            public IActionResult AddUser(Users user)
            {

            usersRepo.Add(user);
            return Ok(user);

        }



        [HttpGet("GetAllUsers")]
        [AllowAnonymous]
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
            try
            {

                usersRepo.Delete(uid);
                return Ok("User deleted");
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("Log_in")]
        [AllowAnonymous]
        public IActionResult ValidateUser(Login login)
        {
            Users user = usersRepo.Validate(login);
            AuthResponse authResponse = new AuthResponse();
            if (user != null)
            {
                authResponse.userName = user.userName;
                authResponse.userId = user.userId;  
               authResponse.role = user.role;
               

                authResponse.token = GetToken(user);
            }
            return Ok(authResponse);
        }
        
        private string GetToken(Users? user)
        {
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            //header part
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature
            );
            //payload part
            var subject = new ClaimsIdentity(new[]
            {
                        new Claim(ClaimTypes.Name,user.userName),
                        new Claim(ClaimTypes.Role, user.role),
              
                    });

            var expires = DateTime.UtcNow.AddMinutes(10);
            //signature part
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }
    }   
        
}
