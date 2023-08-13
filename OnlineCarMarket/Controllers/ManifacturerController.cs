﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Manufactur;

namespace OnlineCarMarket.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class ManifacturerController : Controller
    {
        private readonly IManifacturer manifacturerService;

        public ManifacturerController(IManifacturer _manifacturerService)
        {
            manifacturerService = _manifacturerService;
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
                await manifacturerService.AddBrandAsync(model);
            }

            return RedirectToAction("Index", "Home");
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
            await manifacturerService.SaveChanges(model);
            return RedirectToAction(nameof(AllBrands));
        }

    }
}
