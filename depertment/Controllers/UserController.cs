using depertment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace depertment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly jwtsetting setting;
        private readonly User users;
        public UserController(IOptions<jwtsetting> option, User user)
        {
            users = user;
            setting = option.Value;

        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpUser(UserRegister userRegistration)
        {

            try
            {
                var _user = await users.AddUser(userRegistration);

                if (_user != null) return Ok("Registered Successfully!!");

                else return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(Userlogin loginModel)
        {

            var user = await users.Authenticate(loginModel);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { Status = "UnAuthorized", Message = "UserName or Password is incorrect" });
            }


            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(setting.Securitykey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.EmailAddress),

                }),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string FinalToken = tokenhandler.WriteToken(token);

            return Ok(new
            {
                Token = FinalToken,
                Email = user.EmailAddress,
                Password = user.Password,
                UserName = user.UserName,

            });
        }
    }
}
