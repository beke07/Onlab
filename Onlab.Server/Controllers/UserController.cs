using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onlab.Client.ViewModels;

namespace Onlab.Server.Controllers
{
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
        public async Task<CurrentUserViewModel> CurrentUser()
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            return new CurrentUserViewModel()
            {
                Name = user?.Email,
                IsSignedIn = user != null
            };
        }
    }
}