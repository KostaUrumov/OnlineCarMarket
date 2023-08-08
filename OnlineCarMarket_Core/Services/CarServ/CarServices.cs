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
        public async Task AddCarAsync(RegisterCarViewModel model)
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

        }

        public List<DisplayCarModel> GetAllCars()
        {
           List<DisplayCarModel> listedCars = data
                .Cars
                .Select(x => new DisplayCarModel()
                {
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



