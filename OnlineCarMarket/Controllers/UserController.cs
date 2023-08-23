using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.UserModels;
using OnlineCarMarket_Infastructure.Entities;
using System.Net;

namespace OnlineCarMarket.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices userServices;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
       

        public UserController(
            IUserServices _userServ
            , SignInManager<User> _signInManager
            , UserManager<User> _userManager
            )
        {
            userServices = _userServ;
            signInManager = _signInManager;
            userManager = _userManager;
           
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {

            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            bool success = userServices.UserExists(model.Username);
            if (success == true)
            {
                return RedirectToAction(nameof(Register));
            }

            if (ModelState.IsValid)
            {
                await userServices.AddUserAsync(model);
            }

            await userServices.AddToRole(model);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> LogIn()
        {
            var model = new LogInUserViewModel();

            model.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return View(model);

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LogInUserViewModel model)
        {


            if (ModelState.IsValid)
            {
                var logged = await userServices.LogInAsync(model);
                if (logged is true)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Login", "User");

            }

            return RedirectToAction("Login", "User");

        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string? returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action("ExternalLoginCallback", "User", new { returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                TempData["ErrorMessage"] = $"Error from external provider: {remoteError}";

                return RedirectToAction("Login", new { ReturnUrl = returnUrl });
            }
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                TempData["ErrorMessage"] = "Error loading external login information.";
                return RedirectToAction("Login", new { ReturnUrl = returnUrl });
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                return RedirectToAction("Register");
            }

        }
    }
}
