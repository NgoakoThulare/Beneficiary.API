using Beneficiary.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beneficiary.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _userRepo;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepo"></param>
        public UsersController(IUsersRepository userRepo) => this._userRepo = userRepo;

        /// <summary>
        /// API Users authentication
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(string Username, string Password)
        {
            var user = _userRepo.Authenticate(Username, Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(user);
        }
    }
}
