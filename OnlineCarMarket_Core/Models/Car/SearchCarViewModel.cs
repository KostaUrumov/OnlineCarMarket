using OnlineCarMarket_Infastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.Car
{
    public class SearchCarViewModel
    {
        [Required]

        public int ManifacturerId { get; set; }
        public IEnumerable<Manifacturer> Manifacturers { get; set; } = new List<Manifacturer>();

        [Required]
        public int EngineTypeId { get; set; }
        public IEnumerable<EngineType> EngineType { get; set; } = new List<EngineType>();

     
        public decimal MinimumPrice { get; set; }

        public decimal MaximumPrice { get; set; }

    }
}
