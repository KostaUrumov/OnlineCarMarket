using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Infastructure.Entities
{
    public class EngineType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.EngyneType.MaxFuelLength)]
        public string Fuel { get; set; } = null!;
    }
}
