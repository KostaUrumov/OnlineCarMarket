using OnlineCarMarket_Core.Models.Car;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Interfaces
{
    public interface ICarService
    {
        Task AddCarAsync(RegisterCarViewModel model);

        Task<IEnumerable<BodyType>> GetBodyTypes();
        Task<IEnumerable<Engine>> GetEngines();

        Task<IEnumerable<Manifacturer>> GetManifacturers();

        Task<IEnumerable<EngineType>> GetFuel();

        List<DisplayCarModel> GetAllCars();
        List<DisplayCarModel> LastFiveAddedCars();
        List<DisplayCarModel> searchCars(SearchCarViewModel model);

        List<DisplayCarModel> searchByManifacture(SearchCarByManifactureModel model);

        List<DisplayCarModel> searchByFuel(SearchCarByFuelTypeModel model);



    }
}
