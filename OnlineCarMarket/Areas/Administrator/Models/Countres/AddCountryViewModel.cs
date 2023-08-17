using OnlineCarMarket_Infastructure;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket.Areas.Administrator.Models.Countres
{
    public class AddCountryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.Country.MaxCountryNameLength)]
        [MinLength(DataConstraints.Country.MinCountryNameLength)]
        public string Name { get; set; } = null!;
    }
}
