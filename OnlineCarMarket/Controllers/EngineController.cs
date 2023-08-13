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

        public async Task<IActionResult> AllEngines()
        {
            return View(await engineService.GetAllEngines());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<EditEngineModel> model =  await engineService.GetTheEngineToEdit(id);
            model[0].Manifacturers = await carService.GetManifacturers();
            model[0].Types = await engineService.GetEngineType();
            return View(model[0]);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEngineModel model)
        {
            await engineService.SaveChangesAsync(model);
            return RedirectToAction(nameof(AllEngines));

        }
    }

}
