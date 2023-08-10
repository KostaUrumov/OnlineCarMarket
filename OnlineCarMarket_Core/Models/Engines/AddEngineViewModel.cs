using OnlineCarMarket_Infastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.Engines
{
    public class AddEngineViewModel
    {
        [Required]
        public int ManifacturerId { get; set; }

        public IEnumerable<Manifacturer> Manifacturers { get; set; } = new List<Manifacturer>();


        [Required]
        public int TypeId { get; set; }

        public IEnumerable<EngineType> Types { get; set; } = new List<EngineType>();

        [Required]
        public int Power { get; set; }

        [Required]
        public int Volume { get; set; }

        [Required]
        public double Consumption { get; set; }

    }
}

