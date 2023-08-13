using OnlineCarMarket_Infastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.Manufactur
{
    public class EditManufacturerViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int CountryId { get; set; }

        public IEnumerable<Country> Countries { get; set; } = new List<Country>();

    }
}
