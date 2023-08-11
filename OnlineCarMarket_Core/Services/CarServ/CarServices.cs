using Microsoft.EntityFrameworkCore;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Car;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Services.CarServ
{
    public class CarServices : ICarService
    {
        private readonly ApplicationDbContext data;
        public CarServices(ApplicationDbContext _data)
        {
            data = _data;
        }
        public async Task<Car> AddCarAsync(RegisterCarViewModel model)
        {
            
            Car auto = new Car()
            {
                ManifacturerId = model.ManifacturerId,
                Model = model.Type,
                Milage = model.Milage,
                BodyTypeId = model.BodyTypeId,
                EngineId = model.EngineId,
                FirstRegistration = model.FirstRegistration,
                NumberOfDoors = model.NumberOfDoors,
                Price = model.Price
                
            };
            data.Cars.Add(auto);
            await data.SaveChangesAsync();
            return auto;

        }

        public async Task AddToMyListAsync(Car car, string userId)
        {
            User user = data.Users.First(u => u.Id == userId);
            UserCar usCar = new UserCar()
            {
                CarId = car.Id,
                UserId = user.Id
            };

            data.UsersCars.Add(usCar);
            await data.SaveChangesAsync();
        }

        public List<DisplayCarModel> GetAllCars()
        {
           List<DisplayCarModel> listedCars = data
                .Cars
                .Select(x => new DisplayCarModel()
                {
                    Id = x.Id,
                    Model = x.Model,
                    Manifacturer = x.Manifacturer.Name,
                    FirstRegistration = x.FirstRegistration.ToString("dd/MM/yyyy"),
                    EnginePower = x.Engine.HorsePower,
                    EngineVolume = x.Engine.Volume,
                    Price = x.Price.ToString("#.##")

                })
                .ToList();
            return listedCars;
        }

        public async Task<IEnumerable<BodyType>> GetBodyTypes()
        {
            return await data.BoduTypes.ToListAsync();
        }

        public async Task<IEnumerable<Engine>> GetEngines()
        {
            return await data.Engines.ToListAsync();
        }

        public async Task<IEnumerable<EngineType>> GetFuel()
        {
            return await data.EngineTypes.ToListAsync();
        }

        public async Task<IEnumerable<Manifacturer>> GetManifacturers()
        {
            return await data.Manifacturers.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<DisplayCarModel>> GetMyCars(string userId)
        {
            List<DisplayCarModel> listedCars = await data
                .UsersCars
                .Where(u => u.UserId == userId)
                .Select(u => new DisplayCarModel()
                {
                    Model = u.Car.Model,
                    Manifacturer = u.Car.Manifacturer.Name,
                    FirstRegistration = u.Car.FirstRegistration.ToString("dd/MM/yyyy"),
                    EnginePower = u.Car.Engine.HorsePower,
                    EngineVolume = u.Car.Engine.Volume,
                    Price = u.Car.Price.ToString("#.##")

                })
                .ToListAsync();

            return listedCars;
            
        }

        public async Task<List<DisplayCarModel>> GetMyObservingCars(string userId)
        {
            List<DisplayCarModel> listedCars = await data
                .ObservingCars
                .Where(u => u.UserId == userId)
                .Select(u => new DisplayCarModel()
                {
                    Model = u.Car.Model,
                    Manifacturer = u.Car.Manifacturer.Name,
                    FirstRegistration = u.Car.FirstRegistration.ToString("dd/MM/yyyy"),
                    EnginePower = u.Car.Engine.HorsePower,
                    EngineVolume = u.Car.Engine.Volume,
                    Price = u.Car.Price.ToString("#.##")

                })
                .ToListAsync();

            return listedCars;


        }

        public List<DisplayCarModel> LastFiveAddedCars()
        {
            List<DisplayCarModel> listedCars = data
                .Cars
                .OrderByDescending(x => x.Id)
                .Select(x => new DisplayCarModel()
                {
                    Model = x.Model,
                    Manifacturer = x.Manifacturer.Name,
                    FirstRegistration = x.FirstRegistration.ToString("dd/MM/yyyy"),
                    EnginePower = x.Engine.HorsePower,
                    EngineVolume = x.Engine.Volume,
                    Price = x.Price.ToString("#.##")
                })
                .Take(5)
                .ToList();

            return listedCars;
        }

        public async Task OserveCar(int carId, string userId)
        {
            User user = data.Users.First(u => u.Id == userId);
            Car car = data.Cars.First(c => c.Id == carId);
            ObserveCars observeNewCar = new ObserveCars()
            {
                CarId = car.Id,
                UserId = user.Id
            };
            data.ObservingCars.Add(observeNewCar);
            await data.SaveChangesAsync();

        }

        public List<DisplayCarModel> searchByFuel(SearchCarByFuelTypeModel model)
        {
            List<DisplayCarModel> displayCarModels = data
               .Cars
               .Where(m => m.Engine.EngineTypeId == model.EngineTypeId)
               .Select(m => new DisplayCarModel()
               {
                   Model = m.Model,
                   Manifacturer = m.Manifacturer.Name,
                   FirstRegistration = m.FirstRegistration.ToString("dd/MM/yyyy"),
                   EngineVolume = m.Engine.Volume,
                   EnginePower = m.Engine.HorsePower,
                   Price = m.Price.ToString("#.##")
               })
               .ToList();

            return displayCarModels;

        }

        public List<DisplayCarModel> searchByManifacture(SearchCarByManifactureModel model)
        {
            List<DisplayCarModel> displayCarModels = data
                .Cars
                .Where(m => m.ManifacturerId == model.ManifacturerId)
                .Select(m => new DisplayCarModel()
                {
                    Model = m.Model,
                    Manifacturer = m.Manifacturer.Name,
                    FirstRegistration = m.FirstRegistration.ToString("dd/MM/yyyy"),
                    EngineVolume = m.Engine.Volume,
                    EnginePower = m.Engine.HorsePower,
                    Price = m.Price.ToString("#.##")
                })
                .ToList();

            return displayCarModels;


        }

        public List<DisplayCarModel> searchCars(SearchCarViewModel model)
        {
            List<DisplayCarModel> displayCarModels;

            decimal minPrice = 0;
            decimal maxPrice = 0;
            int minimumDate = 0;
            if (model.RegisteredAfter != null)
            {
                minimumDate = int.Parse(model.RegisteredAfter);
            }

            if (model.MaximumPrice != 0)
            {
                maxPrice = model.MaximumPrice;
            }

            if (model.MinimumPrice != 0)
            {
                minPrice = model.MinimumPrice;
            }

            if (minPrice == 0)
            {
                displayCarModels = data
                .Cars
                .Where(m => m.ManifacturerId == model.ManifacturerId
                && m.Engine.EngineTypeId == model.EngineTypeId)
                .Where(m => m.Price <= maxPrice)
                .Where(m => m.FirstRegistration.Year >= minimumDate)
                .Where(m => m.Engine.HorsePower >= model.MinimumPower)
                .Select(m => new DisplayCarModel()
                {
                    Model = m.Model,
                    Manifacturer = m.Manifacturer.Name,
                    FirstRegistration = m.FirstRegistration.ToString("dd/MM/yyyy"),
                    EngineVolume = m.Engine.Volume,
                    EnginePower = m.Engine.HorsePower,
                    Price = m.Price.ToString("#.##")
                })
                .ToList();

                return displayCarModels;
            }


            if (maxPrice == 0)
            {
                displayCarModels = data
                .Cars
                .Where(m => m.ManifacturerId == model.ManifacturerId
                && m.Engine.EngineTypeId == model.EngineTypeId)
                .Where(m => m.Price >= minPrice)
                .Where(m => m.FirstRegistration.Year >= minimumDate)
                .Where(m => m.Engine.HorsePower >= model.MinimumPower)
                .Select(m => new DisplayCarModel()
                {
                    Model = m.Model,
                    Manifacturer = m.Manifacturer.Name,
                    FirstRegistration = m.FirstRegistration.ToString("dd/MM/yyyy"),
                    EngineVolume = m.Engine.Volume,
                    EnginePower = m.Engine.HorsePower,
                    Price = m.Price.ToString("#.##")
                })
                .ToList();

                return displayCarModels;
            }

            if (maxPrice == 0 && minPrice == 0)
            {
                displayCarModels = data
                .Cars
                .Where(m => m.ManifacturerId == model.ManifacturerId
                && m.Engine.EngineTypeId == model.EngineTypeId)
                .Where(m => m.FirstRegistration.Year >= minimumDate)
                .Where(m => m.Engine.HorsePower >= model.MinimumPower)
                .Select(m => new DisplayCarModel()
                {
                    Model = m.Model,
                    Manifacturer = m.Manifacturer.Name,
                    FirstRegistration = m.FirstRegistration.ToString("dd/MM/yyyy"),
                    EngineVolume = m.Engine.Volume,
                    EnginePower = m.Engine.HorsePower,
                    Price = m.Price.ToString("#.##")
                })
                .ToList();

                return displayCarModels;
           }
            
          

            displayCarModels = data
                .Cars
                .Where(m => m.ManifacturerId == model.ManifacturerId 
                && m.Engine.EngineTypeId == model.EngineTypeId)
                .Where(m=> m.Price<= maxPrice && m.Price >=minPrice)
                .Where(m=> m.FirstRegistration.Year>= minimumDate)
                .Where(m => m.Engine.HorsePower >= model.MinimumPower)
                .Select(m => new DisplayCarModel()
                {
                    Model = m.Model,
                    Manifacturer = m.Manifacturer.Name,
                    FirstRegistration = m.FirstRegistration.ToString("dd/MM/yyyy"),
                    EngineVolume = m.Engine.Volume,
                    EnginePower = m.Engine.HorsePower,
                    Price= m.Price.ToString("#.##")
                })
                .ToList();

            return displayCarModels;
           
        }
    }
}



