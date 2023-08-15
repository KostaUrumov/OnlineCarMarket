using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCarMarket_Infastructure.Entities
{
    public class Engine
    {
        public int Id { get; set; }

        [Required]
        public int ManifacturerId { get; set; }

        [ForeignKey(nameof(ManifacturerId))]
        public Manifacturer Manifacturer { get; set; } = null!;

        [Required]
        public int EngineTypeId { get; set; }

        [ForeignKey(nameof(EngineTypeId))]
        public EngineType Type { get; set; } = null!;

        [Required]
        [Range(DataConstraints.Engine.MinHorsePower, DataConstraints.Engine.MaxHorsePower)]
        public int HorsePower { get; set; }

        [Required]
        [Range(DataConstraints.Engine.MinVolume, DataConstraints.Engine.MaxVolume)]
        public int Volume { get; set; }

        [Required]
        [Range(DataConstraints.Engine.MinConsumption, DataConstraints.Engine.MaxConsumption)]
        public double FuelConsumption { get; set; }

    }
}
