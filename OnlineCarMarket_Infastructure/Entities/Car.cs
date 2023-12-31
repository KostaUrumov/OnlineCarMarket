﻿using System.ComponentModel.DataAnnotations;
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
        [MaxLength(DataConstraints.Car.MaxModelNameLength)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(DataConstraints.Car.MinMilage, DataConstraints.Car.MaxMilage)]
        public int Milage { get; set; }

        [Required]
        public int BodyTypeId { get; set; }

        [ForeignKey(nameof(BodyTypeId))]
        public BodyType BodyType { get; set; } = null!;

        [Required]
        public int EngineId { get; set; }

        [ForeignKey(nameof(EngineId))]
        public Engine Engine { get; set; } = null!;

        [Required]
        public DateTime FirstRegistration { get; set; }

        [Range(DataConstraints.Car.MinNumberDoors, DataConstraints.Car.MaximumNumberDoors)]
        public int NumberOfDoors { get; set; }

        [Required]
        [Range(DataConstraints.Car.MinPrice, DataConstraints.Car.MaxPrice)]
        public decimal Price { get; set; }

        public DateTime? DateOfRegistration { get; set; }

        public DateTime? ExpireDate { get; set; }

        public byte[]? Picture { get; set; }

    }
}
