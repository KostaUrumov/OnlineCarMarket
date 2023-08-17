using OnlineCarMarket_Infastructure;
using OnlineCarMarket_Infastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket.Areas.Administrator.Models.Manufactur
{
    public class EditManufacturerViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.Manufacturer.MaxManufacturerNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int CountryId { get; set; }

        public IEnumerable<Country> Countries { get; set; } = new List<Country>();

    }
}
