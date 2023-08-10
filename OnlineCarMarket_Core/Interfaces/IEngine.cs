using OnlineCarMarket_Core.Models.Engines;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Interfaces
{
    public interface IEngine
    {
        Task AddEngineAsync(AddEngineViewModel model);
        Task<IEnumerable<Manifacturer>> GetAllmanifacturers();
        Task<IEnumerable<EngineType>> GetEngineType();
    }
}
