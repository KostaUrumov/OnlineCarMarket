using OnlineCarMarket_Infastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket.Areas.Administrator.Models.Engine
{
    public class SearchEngineByManifactureModel
    {
        [Required]
        public int ManifacturerId { get; set; }
        public IEnumerable<Manifacturer> Manifacturers { get; set; } = new List<Manifacturer>();
    }
}
