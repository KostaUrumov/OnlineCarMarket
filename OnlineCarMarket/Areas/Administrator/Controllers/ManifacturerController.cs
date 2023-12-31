﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket.Areas.Administrator.Intefraces;
using OnlineCarMarket.Areas.Administrator.Models.Manufactur;
using OnlineCarMarket_Core.Interfaces;

namespace OnlineCarMarket.Areas.Administrator.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class ManifacturerController : BaseController
    {
        private readonly IManifacturer manifacturerService;
        private readonly ICarService carServices;

        public ManifacturerController(
            IManifacturer _manifacturerService,
            ICarService _carService)
        {
            manifacturerService = _manifacturerService;
            carServices = _carService;
        }

        [HttpGet]
        public async Task<IActionResult> AddBrand()
        {

            NewManufacturerViewModel model = new NewManufacturerViewModel()
            {
                Countries = await manifacturerService.GetAllCountries()
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(NewManufacturerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isThere = manifacturerService.CheckIfBrandExists(model.Name);
                if (isThere == false)
                {
                    await manifacturerService.AddBrandAsync(model);
                    return RedirectToAction(nameof(AllBrands));
                };
                
            }

            return RedirectToAction("index", "home");
        }


        public async Task<IActionResult> AllBrands()
        {
            return View(await manifacturerService.GetAllBrands());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            List<EditManufacturerViewModel> toEdit = await manifacturerService.FindBrandToBeEdited(Id);
            toEdit[0].Countries = await manifacturerService.GetAllCountries();
            return View(toEdit[0]);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditManufacturerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isThere = manifacturerService.CheckIfBrandExists(model.Name);
                if (isThere == false)
                {
                    await manifacturerService.SaveChanges(model);
                    return RedirectToAction(nameof(AllBrands));
                }
               
            }

            return RedirectToAction("index", "home");
        }



    }
}
