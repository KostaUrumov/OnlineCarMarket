using OnlineCarMarket.Areas.Administrator.Models.Engine;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket.Areas.Administrator.Intefraces
{
    public interface IEngine
    {
        Task AddEngineAsync(AddEngineViewModel model);
        Task<IEnumerable<Manifacturer>> GetAllmanifacturers();
        Task<IEnumerable<EngineType>> GetEngineType();
        Task<List<ShowEngineModelView>> GetAllEngines();
        Task<List<EditEngineModel>> GetTheEngineToEdit(int id);
        Task SaveChangesAsync(EditEngineModel model);

        Task<List<ShowEngineModelView>> searchEngineByManifacture(SearchEngineByManifactureModel model);
    }
}
