using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket_Core.Models.Body;
using OnlineCarMarket_Core.Interfaces;
using System.Runtime.CompilerServices;

namespace OnlineCarMarket.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class BodyTypeController : Controller
    {
        private readonly IBody bodyService;

        public BodyTypeController(IBody _bodyService)
        {
            bodyService = _bodyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBody()
        {
            AddBodyTypeViewModel model = new AddBodyTypeViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBody(AddBodyTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await bodyService.AddBodyAsync(model);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AllBodyTypes()
        {
            return View (await bodyService.GetAllBodyTypes());
        }
    }
}
