using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Infastructure.Entities
{
    public class EngineType
    {
        public int Id { get; set; }

        [Required]
        public string Fuel { get; set; } = null!;
    }
}
