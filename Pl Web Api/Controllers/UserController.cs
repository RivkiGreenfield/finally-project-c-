using Bl.Api;
using Bl.Models;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pl_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IBl _bl;

        public UserController(IBl bl)
        {
            _bl = bl;
        }
        [HttpPost]
        public async Task<BlUser> GetByPassword([FromBody] int value)
        {
            return await _bl.Users.GetByPassword(value);
        }

    }
}
