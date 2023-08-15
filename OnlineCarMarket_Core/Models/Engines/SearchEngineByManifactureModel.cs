using OnlineCarMarket_Infastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.Engines
{
    public class SearchEngineByManifactureModel
    {
        [Required]
        public int ManifacturerId { get; set; }
        public IEnumerable<Manifacturer> Manifacturers { get; set; } = new List<Manifacturer>();
    }
}
