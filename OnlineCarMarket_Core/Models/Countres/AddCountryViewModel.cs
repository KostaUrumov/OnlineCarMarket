using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.Countres
{
    public class AddCountryViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
