using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onlab.Shared;
using System.Threading.Tasks;

namespace Onlab.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public async Task<CurrentUser> CurrentUser()
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            return new CurrentUser()
            {
                Name = user?.Email,
                IsSignedIn = user != null
            };
        }
    }
}