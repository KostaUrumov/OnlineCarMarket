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
            RegisterCarViewModel model = new RegisterCarViewModel()
            {
                BodyTypes = await carServices.GetBodyTypes(),
                Engine = await carServices.GetEngines(),
                Manifacturers = await carServices.GetManifacturers(),
                FirstRegistration = new DateTime(2010, 1, 1)
        };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddCar(RegisterCarViewModel model)
        {

            await carServices.AddCarAsync(model);

            return RedirectToAction(nameof(AllCars));
        }

        public IActionResult AllCars()
        {

            return View(carServices.GetAllCars());
        }

        [HttpGet]
        public async Task <IActionResult> FilterCar()
        {
            SearchCarViewModel model = new SearchCarViewModel()
            {
                Manifacturers = await carServices.GetManifacturers(),
                EngineType = await carServices.GetFuel()
            };
            return View(model);

        }

        [HttpPost]
        public  IActionResult FilterCar(SearchCarViewModel model)
        {
            var filteredcars = carServices.searchCars(model);
            return View(nameof(Result), filteredcars);
        }

        public IActionResult Result(List<DisplayCarModel> models)
        {
            return View(models);
        }

    }
}
