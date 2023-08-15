using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Infastructure.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.Country.MaxCountryNameLength)]
        public string Name { get; set; } = null!;
    }
}
