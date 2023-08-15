using OnlineCarMarket_Infastructure;
using OnlineCarMarket_Infastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCarMarket_Core.Models.Car
{
    public class EditCarViewModel
    {
        public int Id { get; set; }

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

        [Range(DataConstraints.Car.MinNumberDoors, DataConstraints.Car.MaximumNumberDoors)]
        public int NumberOfDoors { get; set; }

        [Required]
        [Range(DataConstraints.Car.MinPrice, DataConstraints.Car.MaxPrice)]
        public decimal Price { get; set; }


    }
}
