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
    }
}



