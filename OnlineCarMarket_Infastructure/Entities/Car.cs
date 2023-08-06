using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCarMarket_Infastructure.Entities
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public int ManifacturerId { get; set; }

        [ForeignKey(nameof(ManifacturerId))]
        public Manifacturer Manifacturer { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public int Milage { get; set; }

        [Required]
        public int BodyTypeId { get; set; }

        [ForeignKey(nameof(BodyTypeId))]
        public BodyType BodyType { get; set; } = null!;

        [Required]
        public int EngineId { get; set; }

        [ForeignKey(nameof(EngineId))]
        public Engine Engine { get; set; } = null!;

        public int NumberOfDoors { get; set; }

        public bool AciveVignette { get; set; }

        public bool RightHanded { get; set; }

        public bool IsRegistered { get; set; }
    }
}
