using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket.Areas.Administrator.Models.Body;
using OnlineCarMarket.Areas.Administrator.Interfaces;

namespace OnlineCarMarket.Areas.Administrator.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class BodyTypeController : BaseController
    {
        private readonly IBody bodyService;

        public BodyTypeController(IBody _bodyService)
        {
            bodyService = _bodyService;
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
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> AllBodyTypes()
        {
            return View(await bodyService.GetAllBodyTypes());
        }
    }
}
