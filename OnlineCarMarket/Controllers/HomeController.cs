using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket.Models;
using OnlineCarMarket_Core.Interfaces;
using System.Diagnostics;

namespace OnlineCarMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService carService;

        public HomeController(
            ILogger<HomeController> logger,
            ICarService _carService)
        {
            _logger = logger;
            carService = _carService;
        }

        public IActionResult Index()
        {
            return View(carService.LastFiveAddedCars());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}