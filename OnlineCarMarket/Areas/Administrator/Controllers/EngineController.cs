using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket.Areas.Administrator.Intefraces;
using OnlineCarMarket.Areas.Administrator.Models.Engine;
using OnlineCarMarket_Core.Interfaces;

namespace OnlineCarMarket.Areas.Administrator.Controllers
{

    [Authorize(Policy = "AdminsOnly")]
    public class EngineController : BaseController
    {

        private readonly IEngine engineService;
        private readonly ICarService carServices;

        public EngineController(
            IEngine _engineService,
            ICarService _carService)
        {
            engineService = _engineService;
            carServices = _carService;
        }

        [HttpGet]
        public async Task<IActionResult> AddNewEngine()
        {
            AddEngineViewModel engine = new AddEngineViewModel()
            {
                Manifacturers = await carServices.GetManifacturers(),
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

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> AllEngines()
        {
            return View(await engineService.GetAllEngines());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<EditEngineModel> model = await engineService.GetTheEngineToEdit(id);
            model[0].Manifacturers = await carServices.GetManifacturers();
            model[0].Types = await engineService.GetEngineType();
            return View(model[0]);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEngineModel model)
        {
            if (ModelState.IsValid)
            {
                await engineService.SaveChangesAsync(model);
            }

            return RedirectToAction("index", "home");

        }

        [HttpGet]
        public async Task<IActionResult> GetAllByManifacture()
        {
            SearchEngineByManifactureModel model = new SearchEngineByManifactureModel()
            {
                Manifacturers = await carServices.GetManifacturers()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllByManifacture(SearchEngineByManifactureModel model)
        {
            var filteredcars = await engineService.searchEngineByManifacture(model);
            return View(nameof(Result), filteredcars);

        }


        public IActionResult Result(List<ShowEngineModelView> filteredcars)
        {
            return View(filteredcars);
        }
    }

}
