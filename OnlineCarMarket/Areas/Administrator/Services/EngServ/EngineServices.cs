using Microsoft.EntityFrameworkCore;
using OnlineCarMarket.Areas.Administrator.Intefraces;
using OnlineCarMarket.Areas.Administrator.Models.Engine;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket.Areas.Administrator.Services.EngServ
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

        public bool CheckIfEngineIsIn(AddEngineViewModel model)
        {
            var engine = data.Engines.FirstOrDefaultAsync(x=> x.ManifacturerId == model.ManifacturerId
            && x.EngineTypeId == model.TypeId
            && x.HorsePower == model.Power
            && x.Volume == model.Volume);
            if (engine.Result != null)
            {
                return true;
            }

            return false;
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

        public async Task<List<EditEngineModel>> GetTheEngineToEdit(int id)
        {
            List<EditEngineModel> correctEngine = await data
                .Engines
                .Where(e => e.Id == id)
                .Select(e=> new EditEngineModel()
                {
                    Id = e.Id,
                    Power = e.HorsePower,
                    Volume= e.Volume,
                    Consumption= e.FuelConsumption
                    
                }) 
                .ToListAsync();

            return correctEngine;
                
        }

        public async Task SaveChangesAsync(EditEngineModel model)
        {
            var editIt = await data.Engines.FirstAsync(x => x.Id == model.Id);
            editIt.EngineTypeId = model.TypeId;
            editIt.ManifacturerId = model.ManifacturerId;
            editIt.HorsePower = model.Power;
            editIt.Volume = model.Volume;
            editIt.FuelConsumption = model.Consumption;

            await data.SaveChangesAsync();
            
        }

        public async Task<List<ShowEngineModelView>> searchEngineByManifacture(SearchEngineByManifactureModel model)
        {
            List<ShowEngineModelView> engines = await data
                .Engines
                .Where(x=>x.ManifacturerId == model.ManifacturerId)
                .Select(e => new ShowEngineModelView
                {
                    Id = e.Id,
                    Manufacturer = e.Manifacturer.Name,
                    FuelType = e.Type.Fuel,
                    HorsePower = e.HorsePower,
                    Volume = e.Volume,
                    Consumption = e.FuelConsumption

                })
                .OrderBy(x => x.Volume)
                .ToListAsync();
            return engines;

        }
    }
}
