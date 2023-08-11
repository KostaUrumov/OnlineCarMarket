using OnlineCarMarket_Core.Models.Car;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Interfaces
{
    public interface ICarService
    {
        Task<Car> AddCarAsync(RegisterCarViewModel model);
        Task AddToMyListAsync(Car model, string userId);
        Task<List<DisplayCarModel>> GetMyCars(string userId);

        Task<IEnumerable<BodyType>> GetBodyTypes();
        Task<IEnumerable<Engine>> GetEngines();

        Task<IEnumerable<Manifacturer>> GetManifacturers();

        Task<IEnumerable<EngineType>> GetFuel();

        List<DisplayCarModel> GetAllCars();
        List<DisplayCarModel> LastFiveAddedCars();
        List<DisplayCarModel> searchCars(SearchCarViewModel model);

        List<DisplayCarModel> searchByManifacture(SearchCarByManifactureModel model);

        List<DisplayCarModel> searchByFuel(SearchCarByFuelTypeModel model);

        Task OserveCar(int carId, string userId);

        Task<List<DisplayCarModel>> GetMyObservingCars(string userId);



    }
}
