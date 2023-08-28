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
                Price = model.Price,
                DateOfRegistration = DateTime.UtcNow,
                ExpireDate = DateTime.UtcNow.AddMinutes(10)
            };
            data.Cars.Add(auto);
            await data.SaveChangesAsync();
            return auto;

        }

        public async Task AddPictureToCar(byte[] pictureData, int id)
        {
          
           Car car = data.Cars.First(x => x.Id == id);
           car.Picture = pictureData;

            await data.SaveChangesAsync();


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

        public async Task<List<DisplayCarModel>> CheckIfCarAreObservedByUser(string userId, List<DisplayCarModel> list)
        {
            List<ObserveCars> allObservedCars = await data.ObservingCars.ToListAsync();

            foreach (var car in allObservedCars)
            {
                foreach (var observed in list)
                {
                    if (car.CarId == observed.Id && car.UserId == userId)
                    {
                        observed.isObserved = true;
                    }
                }
            }

            return list;
            
        }

        public async Task<List<DisplayCarModel>> CheckIfExpired(List<DisplayCarModel> list)
        {
            List<DisplayCarModel> listedCars = new List<DisplayCarModel>();
            foreach (var car in list)
            {
                if (car.Expire > DateTime.UtcNow)
                {
                    listedCars.Add(car);
                }
            }

            return listedCars;
        }


        public async Task<List<EditCarViewModel>> FindCar(int id)
        {
            List<EditCarViewModel> carToReturn = await data
                .Cars
                .Where(x=>x.Id == id)
                .Select(x=> new EditCarViewModel()
                {
                    Id = x.Id,
                    ManifacturerId = x.ManifacturerId,
                    BodyTypeId = x.BodyTypeId,
                    EngineId = x.EngineId,
                    FirstRegistration = x.FirstRegistration,
                    Milage = x.Milage,
                    NumberOfDoors = x.NumberOfDoors,
                    Price = x.Price
                })
                .ToListAsync();
            return carToReturn;
        }

        public async Task<List<DisplayCarModel>> GetAllCars(string userId)
        {
            List<DisplayCarModel> listedCars = await data
                 .UsersCars
                 .Where(x => x.UserId != userId)
                 .Select(x => new DisplayCarModel()
                 {
                     Id = x.Car.Id,
                     Model = x.Car.Model,
                     Manifacturer = x.Car.Manifacturer.Name,
                     FirstRegistration = x.Car.FirstRegistration.ToString("dd/MM/yyyy"),
                     EnginePower = x.Car.Engine.HorsePower,
                     EngineVolume = x.Car.Engine.Volume,
                     Price = x.Car.Price.ToString("#.##"),
                     Expire = (DateTime)x.Car.ExpireDate
                     
                 })
                .ToListAsync();
            return listedCars;
        }

        public async Task<IEnumerable<BodyType>> GetBodyTypes()
        {
            return await data.BoduTypes.ToListAsync();
        }

        public async Task<IEnumerable<Engine>> GetEngines(int id)
        {

            return await data.Engines
                .Where(x=>x.ManifacturerId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<EngineType>> GetFuel()
        {
            return await data.EngineTypes.ToListAsync();
        }

        public async Task<IEnumerable<Manifacturer>> GetManifacturers()
        {
            return await data.Manifacturers.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<IEnumerable<Manifacturer>> GetManifacturers(int Id)
        {
            return await data.Manifacturers
                .Where(x=>x.Id == Id)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }


        public async Task<List<DisplayCarModel>> GetMyCars(string userId)
        {
            List<DisplayCarModel> listedCars = await data
                .UsersCars
                .Where(u => u.UserId == userId)
                .Select(u => new DisplayCarModel()
                {
                    Id = u.CarId,
                    Model = u.Car.Model,
                    Manifacturer = u.Car.Manifacturer.Name,
                    FirstRegistration = u.Car.FirstRegistration.ToString("dd/MM/yyyy"),
                    EnginePower = u.Car.Engine.HorsePower,
                    EngineVolume = u.Car.Engine.Volume,
                    Price = u.Car.Price.ToString("#.##"),
                    Expire = (DateTime)u.Car.ExpireDate
                    

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
                    Id= u.CarId,
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
                .Where(x=> x.ExpireDate > DateTime.UtcNow)
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

        public async Task ObserveCar(int carId, string userId)
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

        public async Task RemoveOberveCar(int carId, string userId)
        {
            List<ObserveCars> toRemove = await data
                .ObservingCars
                .Where(x => x.CarId == carId)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            data.ObservingCars.RemoveRange(toRemove);
            await data.SaveChangesAsync();
           
        }

        public async Task RenewCarOffer(int id)
        {
            Car car = data.Cars.First(x => x.Id == id);
            car.ExpireDate = DateTime.UtcNow.AddMonths(1);

            await data.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(EditCarViewModel model)
        {
            Car carToEdit = await data.Cars.FirstAsync(x => x.Id == model.Id);
            carToEdit.ManifacturerId = model.ManifacturerId;
            carToEdit.Model = model.Type;
            carToEdit.EngineId = model.EngineId;
            carToEdit.BodyTypeId = model.BodyTypeId;
            carToEdit.FirstRegistration = model.FirstRegistration;
            carToEdit.NumberOfDoors = model.NumberOfDoors;
            carToEdit.Price = model.Price;

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



