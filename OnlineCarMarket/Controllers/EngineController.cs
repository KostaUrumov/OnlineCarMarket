﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Car;
using OnlineCarMarket_Core.Models.Engines;
using OnlineCarMarket_Core.Services.CarServ;

namespace OnlineCarMarket.Controllers
{
    
    [Authorize(Policy = "AdminsOnly")]
    public class EngineController : Controller
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

            return RedirectToAction(nameof(AllEngines));
        }

        public async Task<IActionResult> AllEngines()
        {
            return View(await engineService.GetAllEngines());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<EditEngineModel> model =  await engineService.GetTheEngineToEdit(id);
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
            
            return RedirectToAction(nameof(AllEngines));

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
