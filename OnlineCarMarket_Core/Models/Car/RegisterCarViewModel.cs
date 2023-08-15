using Microsoft.AspNetCore.Identity.UI.Services;
using OnlineCarMarket_Infastructure;
using OnlineCarMarket_Infastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace OnlineCarMarket_Core.Models.Car
{
    public class RegisterCarViewModel
    {
        [Required]
        public string Type { get; set; } = null!;

        [Required]
        [Display(Name = "Kilometers stand")]
        [Range(DataConstraints.Car.MinMilage, DataConstraints.Car.MaxMilage)]
        public int Milage { get; set; }

        [Required]

        public int ManifacturerId { get; set; }
        public IEnumerable<Manifacturer> Manifacturers { get; set; } = new List<Manifacturer>();

        [Required]
        public int BodyTypeId { get; set; }
        public IEnumerable<BodyType> BodyTypes { get; set; } = new List<BodyType>();

        [Required]
        public int EngineId { get; set; }
        public IEnumerable<Engine> Engine { get; set; } = new List<Engine>();

        [Required]
        public DateTime FirstRegistration { get; set; }

        public int NumberOfDoors { get; set; }

        [Range(DataConstraints.Car.MinPrice, DataConstraints.Car.MaxPrice)]
        
        public decimal Price { get; set; }


    }
}
