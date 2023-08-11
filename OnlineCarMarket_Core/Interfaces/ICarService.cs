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

        Task<List<DisplayCarModel>> GetAllCars(string userId);
        List<DisplayCarModel> LastFiveAddedCars();
        List<DisplayCarModel> searchCars(SearchCarViewModel model);

        List<DisplayCarModel> searchByManifacture(SearchCarByManifactureModel model);

        List<DisplayCarModel> searchByFuel(SearchCarByFuelTypeModel model);

        Task ObserveCar(int carId, string userId);
        Task RemoveOberveCar(int carId, string userId);

        Task<List<DisplayCarModel>> GetMyObservingCars(string userId);

        Task<List<DisplayCarModel>> CheckIfCarAreObservedByUser(string userId, List<DisplayCarModel> list);



    }
}
