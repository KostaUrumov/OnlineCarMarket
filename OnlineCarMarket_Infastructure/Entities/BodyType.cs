using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Infastructure.Entities
{
    public class BodyType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
