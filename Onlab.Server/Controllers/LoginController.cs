using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Onlab.Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IEnumerable<SigninProviderViewModel>> LoginProviders()
        {
            return (await _signInManager.GetExternalAuthenticationSchemesAsync())
                  .Select(s => new SigninProviderViewModel()
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
        public async Task<ExternalLoginConfirmationCommand> ExternalLoginDetails()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            ExternalLoginConfirmationCommand command = new ExternalLoginConfirmationCommand();

            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                command.Provider = info.LoginProvider;
                command.Email = info.Principal.FindFirstValue(ClaimTypes.Email);
            }

            return command;
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

            return Redirect("/login/externalLogin");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ExternalLoginConfirmation([FromBody] ExternalLoginConfirmationCommand command)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                throw new ApplicationException("Error loading external login information during confirmation.");
            }
            var user = new IdentityUser { UserName = command.Email, Email = command.Email, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public async Task<CurrentUserViewModel> Logout()
        {
            await _signInManager.SignOutAsync();

            return new CurrentUserViewModel()
            {
                IsSignedIn = false
            };
        }
    }
}