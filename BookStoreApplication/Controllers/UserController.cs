using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IUserManager manager;
        public UserController(IConfiguration configuration, IUserManager manager)
        {
            this.configuration = configuration;
            this.manager = manager;
        }
        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            try
            {
                var result = await this.manager.Register(user);
                if (result == 1)
                {
                    return this.Ok(new { Status = true, Message = "User Registration Sucssesfull", Data = user });
                }
                return this.BadRequest(new { Status = false, Message = "User Registration Un-Sucssesfull" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(Login loginModel)
        {
            try
            {
                var result = this.manager.Login(loginModel);
                if (result != null)
                {
                    var token = GenrateJWTToken(result.UserId);
                    return this.Ok(new { Status = true, Message = "User Loged In Sucssesfull", Token = token, Data=result });
                }
                return this.BadRequest(new { Status = false, Message = "User Login Failed" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        private string GenrateJWTToken(int userId)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"]));
            var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, "User"),
                            new Claim("userId",userId.ToString())
                        };
            var tokenOptionOne = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signinCredentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptionOne);
            return token;
        }
    }
}