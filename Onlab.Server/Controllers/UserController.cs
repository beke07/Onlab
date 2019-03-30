using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onlab.Dal.Entities;
using Onlab.Shared;
using System.Threading.Tasks;

namespace Onlab.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public async Task<CurrentUser> CurrentUser()
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);

            return new CurrentUser()
            {
                FirstName = user?.FirstName,
                LastName = user?.LastName,
                IsSignedIn = user != null
            };
        }
    }
}