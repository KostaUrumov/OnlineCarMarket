using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Engines;

namespace OnlineCarMarket.Controllers
{
    
    [Authorize(Policy = "AdminsOnly")]
    public class EngineController : Controller
    {

        private readonly IEngine engineService;
        private readonly ICarService carService;

        public EngineController(
            IEngine _engineService,
            ICarService _carService)
        {
            engineService = _engineService;
            carService = _carService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddNewEngine()
        {
            AddEngineViewModel engine = new AddEngineViewModel()
            {
                Manifacturers = await carService.GetManifacturers(),
                Types = await engineService.GetEngineType()
            };

            return View(engine);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEngine(AddEngineViewModel model)
        {
            if (ModelState.IsValid)
            {
               await engineService.AddEngineAsync(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }

}
