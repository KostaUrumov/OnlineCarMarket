using OnlineCarMarket_Infastructure;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.Countres
{
    public class EditCountryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.Country.MaxCountryNameLength)]
        [MinLength(DataConstraints.Country.MinCountryNameLength)]
        public string Name { get; set; } = null!;
    }
}
