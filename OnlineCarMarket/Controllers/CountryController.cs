using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Countres;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class CountryController : Controller
    {
        private readonly ICountry countryService;

        public CountryController(ICountry _countryService)
        {
            countryService = _countryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCountry()
        {
            AddCountryViewModel model = new AddCountryViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(AddCountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await countryService.AddCountryAsync(model);
            }

            return RedirectToAction(nameof(AllCountries));
        }

        public async Task<IActionResult> AllCountries()
        {
            return View(await countryService.GetAllCountries());
        }

        [HttpPost]
        public async Task<IActionResult> EditTheGivenCountry(EditCountryViewModel model)
        {
            await countryService.SaveNewCountry(model);
            return RedirectToAction(nameof(AllCountries));

        }

        [HttpGet]
        public async Task<IActionResult> EditTheGivenCountry(int id)
        {

            List<EditCountryViewModel> models = await countryService.FindCountry(id);
            return View(models[0]);

        }

        public async Task<IActionResult> SaveNewCountry(EditCountryViewModel model, string oldname)
        {
            
            await countryService.SaveNewCountry(model);
            return RedirectToAction(nameof(AllCountries));
        }




    }
}
