using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserRegisteration.DTO;
using UserRegisteration.Migrations;
using UserRegisteration.Modle;
using UserRegisteration.Service;

namespace UserRegisteration.Controllers
{
    [Route("api/Ahmad")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;


        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("UserRegister")]
        public async Task<IActionResult> UsreRegister(UserRegister userRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error");
            }


            var user = await _userService.registerUser(userRegister);

            if (user.IsAuth == false)
            {
                return BadRequest("user name or email is exist");
            }

            return Ok(user);
        }
        [HttpPost("LogIn")]
        public async Task<IActionResult> LoginUser( LogInRequest logInRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var user = await _userService.LogInUser(logInRequest);

            if (user is null)
            {
                return BadRequest("username or password is error");
            }

            string token = CreateToken(user);

            return Ok(token);
        }
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var user = await _userService.GetUser();

            return Ok(user);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById( int id)
        {
            var user =await _userService.GetUserById(id);

            return Ok(user);
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
               _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            user.TokenCreated = DateTime.Now;
            user.TokenExpires = DateTime.Now.AddDays(1);
            _userService.updateUser(user);

            return jwt;
        }
    }
}
