using OnlineCarMarket_Infastructure.Entities;
namespace OnlineCarMarket_Core.Models.Car
{
    public class SearchCarViewModel
    {
        
        public int ManifacturerId { get; set; }
        public IEnumerable<Manifacturer> Manifacturers { get; set; } = new List<Manifacturer>();

        public int EngineTypeId { get; set; }
        public IEnumerable<EngineType> EngineType { get; set; } = new List<EngineType>();
     
        public decimal MinimumPrice { get; set; }

        public decimal MaximumPrice { get; set; }

        public int MinimumPower { get; set; }

        public string? RegisteredAfter { get; set; }

    }
}
