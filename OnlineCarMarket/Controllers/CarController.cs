using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Car;
using OnlineCarMarket_Infastructure.Data;
using System.Security.Claims;

namespace OnlineCarMarket.Controllers
{
    [Authorize(Policy = "UsersOnly")]
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
        [Authorize]
        public async Task<IActionResult> SelectBrand()
        {
            
            AddCarManufacturerModel model = new AddCarManufacturerModel()
            {
                Manifacturers =  await carServices.GetManifacturers()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public  IActionResult SelectBrand(AddCarManufacturerModel model)
        {
            return RedirectToAction(nameof(AddCar), model);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddCar(AddCarManufacturerModel model)
        {
            RegisterCarViewModel register = new RegisterCarViewModel()
            {
                BodyTypes = await carServices.GetBodyTypes(),
                Engine = await carServices.GetEngines(model.ManifacturerId),
                FirstRegistration = new DateTime(2010, 1, 1),
                Manifacturers = await carServices.GetManifacturers(model.ManifacturerId)
                
            };


            return View(register);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCar(RegisterCarViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (userId != null)
                {
                    var car = await carServices.AddCarAsync(model);
                    await carServices.AddToMyListAsync(car, userId);
                }
            }

            return RedirectToAction(nameof(MyCars));
        }

        public async Task<IActionResult> AllCars()
        {

            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            List<DisplayCarModel> listedCars = await carServices.GetAllCars(userId);
            List<DisplayCarModel> returnCars =  await carServices.CheckIfExpired(listedCars);
            return View(await carServices.CheckIfCarAreObservedByUser(userId, returnCars));
        }

        [HttpGet]
        public async Task<IActionResult> FilterCar()
        {
            SearchCarViewModel model = new SearchCarViewModel()
            {
                Manifacturers = await carServices.GetManifacturers(),
                EngineType = await carServices.GetFuel(),
                MaximumPrice = 100
            };
            return View(model);

        }

        [HttpPost]
        public IActionResult FilterCar(SearchCarViewModel model)
        {
            var filteredcars = carServices.searchCars(model);
            return View(nameof(Result), filteredcars);
        }

        public IActionResult Result(List<DisplayCarModel> models)
        {
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByManifacture()
        {
            SearchCarByManifactureModel model = new SearchCarByManifactureModel()
            {
                Manifacturers = await carServices.GetManifacturers()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult GetAllByManifacture(SearchCarByManifactureModel model)
        {
            var filteredcars = carServices.searchByManifacture(model);
            return View(nameof(Result), filteredcars);
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByFuelType()
        {
            SearchCarByFuelTypeModel model = new SearchCarByFuelTypeModel()
            {
                EngineType = await carServices.GetFuel()
            };

            return View(model);
        }


        public IActionResult GetAllByFuelType(SearchCarByFuelTypeModel model)
        {
            var filteredcars = carServices.searchByFuel(model);
            return View(nameof(Result), filteredcars);

        }


        public async Task<IActionResult> MyCars()
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return View(await carServices.GetMyCars(userId));
        }

        public async Task<IActionResult> ObserveCar(int carId)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await carServices.ObserveCar(carId, userId);
            return RedirectToAction(nameof(MyObservCars));
        }

        public async Task<IActionResult> MyObservCars()
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return View(await carServices.GetMyObservingCars(userId));
        }

        public async Task<IActionResult> RemoveFromObserved(int carId)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await carServices.RemoveOberveCar(carId, userId);
            return RedirectToAction(nameof(MyObservCars));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<EditCarViewModel> carToEdit = await carServices.FindCar(id);
            carToEdit[0].Manifacturers = await carServices.GetManifacturers();
            carToEdit[0].BodyTypes = await carServices.GetBodyTypes();
            carToEdit[0].Engine = await carServices.GetEngines(carToEdit[0].ManifacturerId);

            return View(carToEdit[0]);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                await carServices.SaveChangesAsync(model);
            }

            return RedirectToAction(nameof(MyCars));
        }

        public async Task<IActionResult> Renew(int id)
        {
            await carServices.RenewCarOffer(id);
            return RedirectToAction(nameof(MyCars));
        }

        public IActionResult UploadPicture()
        {
            return View();   
        }

    }
}
