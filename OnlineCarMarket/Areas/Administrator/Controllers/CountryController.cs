using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket.Areas.Administrator.Interfaces;
using OnlineCarMarket.Areas.Administrator.Models.Countres;

namespace OnlineCarMarket.Areas.Administrator.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class CountryController : BaseController
    {
        private readonly ICountry countryService;

        public CountryController(ICountry _countryService)
        {
            countryService = _countryService;
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
                var isThere = countryService.CheckIfCountryIsThere(model.Name);
                if (isThere == false)
                {
                    await countryService.AddCountryAsync(model);
                    return RedirectToAction(nameof(AllCountries));
                }
                
            }

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> AllCountries()
        {
            return View(await countryService.GetAllCountries());
        }

        [HttpPost]
        public async Task<IActionResult> EditTheGivenCountry(EditCountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isThere = countryService.CheckIfCountryIsThere(model.Name);
                if ( isThere == false)
                {
                    await countryService.SaveNewCountry(model);
                    return RedirectToAction(nameof(AllCountries));
                }
            }

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
            return RedirectToAction("index", "home");
        }

    }
}
