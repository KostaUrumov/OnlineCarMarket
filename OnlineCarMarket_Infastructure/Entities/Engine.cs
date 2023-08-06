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
        public int HorsePower { get; set; }

        [Required]
        public int Volume { get; set; }

        [Required]
        public double FuelConsumption { get; set; }

    }
}
