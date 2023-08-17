using OnlineCarMarket_Infastructure;
using OnlineCarMarket_Infastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket.Areas.Administrator.Models.Engine
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
        [Range(DataConstraints.Engine.MinHorsePower, DataConstraints.Engine.MaxHorsePower)]
        public int Power { get; set; }

        [Required]
        [Range(DataConstraints.Engine.MinVolume, DataConstraints.Engine.MaxVolume)]
        public int Volume { get; set; }

        [Required]
        [Range(DataConstraints.Engine.MinConsumption, DataConstraints.Engine.MaxConsumption)]
        public double Consumption { get; set; }

    }
}

