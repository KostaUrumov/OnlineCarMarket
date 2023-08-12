using Microsoft.EntityFrameworkCore;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Engines;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Services.EngServ
{
    public class EngineServices : IEngine
    {
        private readonly ApplicationDbContext data;

        public EngineServices(ApplicationDbContext _data)
        {
            data=_data;
        }

        public async Task AddEngineAsync(AddEngineViewModel model)
        {
            Engine engine = new Engine()
            {
                EngineTypeId = model.TypeId,
                ManifacturerId = model.ManifacturerId,
                HorsePower = model.Power,
                Volume = model.Volume,
                FuelConsumption = model.Consumption
            };

            data.Engines.Add(engine);
            await data.SaveChangesAsync();
        }

        public async Task<List<ShowEngineModelView>> GetAllEngines()
        {
            List<ShowEngineModelView> engines = await data
                .Engines
                .Select(e => new ShowEngineModelView
                {
                    Id = e.Id,
                    Manufacturer = e.Manifacturer.Name,
                    FuelType = e.Type.Fuel,
                    HorsePower = e.HorsePower,
                    Volume = e.Volume,
                    Consumption = e.FuelConsumption

                })
                .OrderBy(x => x.Manufacturer)
                .ToListAsync();
            return engines;
        }

        public Task<IEnumerable<Manifacturer>> GetAllmanifacturers()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EngineType>> GetEngineType()
        {
            return await data.EngineTypes.ToListAsync();
        }
    }
}
