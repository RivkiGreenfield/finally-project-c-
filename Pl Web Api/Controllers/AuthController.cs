using Bl.Api;
using Bl.Models;
using Bl.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pl_Web_Api.Controllers
{
    // Web/Controllers/AuthController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        IBl bl;
        public AuthController(IBl bl)
        {
            this.bl = bl;
        }

        [HttpPost("login")]
        public ActionResult<JwtToken> Login([FromBody] LoginDto loginDto)
        {
            var token = bl.AuthService.Authenticate(loginDto.UserName, loginDto.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);  // מחזיר את ה-token למשתמש
        }
    }
}
