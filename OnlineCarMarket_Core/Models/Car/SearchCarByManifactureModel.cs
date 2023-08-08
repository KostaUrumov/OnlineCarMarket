using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Core.Models.Car
{
    public class SearchCarByManifactureModel
    {
        public int ManifacturerId { get; set; }
        public IEnumerable<Manifacturer> Manifacturers { get; set; } = new List<Manifacturer>();

    }
}
