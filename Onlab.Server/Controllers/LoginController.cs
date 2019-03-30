using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onlab.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Onlab.Server.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUrlHelper _urlHelper;

        public LoginController(
            IUrlHelper urlHelper,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _urlHelper = urlHelper;
        }
        
        [HttpGet("[action]")]
        public async Task<IEnumerable<SignInProvider>> LoginProviders()
        {
            return (await _signInManager.GetExternalAuthenticationSchemesAsync())
                  .Select(s => new SignInProvider()
                  {
                      Name = s.Name,
                      DisplayName = s.DisplayName
                  });
        }

        [HttpPost("[action]")]
        public IActionResult ExternalLogin([FromForm] string provider)
        {
            var redirectUrl = _urlHelper.Action("ExternalLoginCallback", "Login");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                return Redirect("/login");
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            
            if (info == null)
            {
                return null;
            }
            
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: false);

            if (result == null || result.IsNotAllowed)
            {
                return Redirect("/login");
            }

            if (result.Succeeded)
            {
                return Redirect("/");
            }
            else
            {
                var user = new IdentityUser();

                if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    user.UserName = info.Principal.FindFirstValue(ClaimTypes.Email);
                    user.Email = info.Principal.FindFirstValue(ClaimTypes.Email);
                    user.EmailConfirmed = true;
                }

                var createResult = await _userManager.CreateAsync(user);

                if (createResult.Succeeded)
                {
                    createResult = await _userManager.AddLoginAsync(user, info);

                    if (createResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return Redirect("/");
                    }
                }
            }

            return Redirect("/login");
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<CurrentUser> Logout()
        {
            await _signInManager.SignOutAsync();

            return new CurrentUser()
            {
                IsSignedIn = false
            };
        }
    }
}