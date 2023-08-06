using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket_Core.Models.UserModels;
using OnlineCarMarket_Core.Services.UserServ;

namespace OnlineCarMarket.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices _userServ)
        {
            userServices = _userServ;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
            
        }

        [HttpPost]
        public async Task <IActionResult> Register(RegisterUserViewModel model) 
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
            
            return RedirectToAction( "Index","Home" );
        }
        

        [HttpGet]
        public IActionResult LogIn()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                await userServices.LogInAsync(model);
            }

            return View();

        }

    }
}
