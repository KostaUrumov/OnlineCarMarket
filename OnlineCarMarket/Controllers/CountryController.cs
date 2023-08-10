using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Countres;

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
        public  IActionResult AddCountry()
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

            return RedirectToAction("Index", "Home");
        }
    }
}
