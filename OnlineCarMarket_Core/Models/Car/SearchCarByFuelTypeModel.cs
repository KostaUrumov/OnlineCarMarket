using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Models.Car
{
    public class SearchCarByFuelTypeModel
    {
        public int EngineTypeId { get; set; }
        public IEnumerable<EngineType> EngineType { get; set; } = new List<EngineType>();
    }
}
