using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Car;
using OnlineCarMarket_Core.Services.CarServ;
using OnlineCarMarket_Infastructure.Data;

namespace OnlineCarMarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly ICarService carServices;

        public CarController(
            ApplicationDbContext _data,
            ICarService _carServices)
        {
            data = _data;
            carServices = _carServices;
        }

        [HttpGet]
        public async Task<IActionResult> AddCar()
        {
            RegisterCarViewModel viewModel = new RegisterCarViewModel()
            {
                BodyTypes = await carServices.GetBodyTypes(),
                Engine = await carServices.GetEngines(),
                Manifacturers = await carServices.GetManifacturers()
            };

            return View(viewModel);
        }


        [HttpPost]

        public async Task<IActionResult> AddCar(RegisterCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                await carServices.AddCarAsync(model);
            }


            return RedirectToAction(nameof(AllCars));
        }

        public  IActionResult AllCars()
        {

            return View();
        }
    }
}
