using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Infastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>()
                .HasData
                (
                new Country { Id = 1, Name = "Spain" },
                new Country { Id = 2, Name = "Japan" },
                new Country { Id = 3, Name = "Germany" },
                new Country { Id = 4, Name = "Sweden" },
                new Country { Id = 5, Name = "Italy" },
                new Country { Id = 6, Name = "USA" },
                new Country { Id = 7, Name = "Romania" },
                new Country { Id = 8, Name = "Czech Republic" },
                new Country { Id = 9, Name = "France" },
                new Country { Id = 10, Name = "Russia" },
                new Country { Id = 11, Name = "Great Britain" }
                );

            builder.Entity<Manifacturer>()
                .HasData
                (
                new Manifacturer { Id = 1, Name = "BMW", CountryId = 3 },
                new Manifacturer { Id = 2, Name = "Mercedes", CountryId = 3 },
                new Manifacturer { Id = 3, Name = "Opel", CountryId = 3 },
                new Manifacturer { Id = 4, Name = "Honda", CountryId = 2 },
                new Manifacturer { Id = 5, Name = "Ford", CountryId = 3 },
                new Manifacturer { Id = 6, Name = "Fiat", CountryId = 5 },
                new Manifacturer { Id = 7, Name = "Skoda", CountryId = 8 },
                new Manifacturer { Id = 8, Name = "Chevrolet", CountryId = 6 },
                new Manifacturer { Id = 9, Name = "Lada", CountryId = 10 },
                new Manifacturer { Id = 10, Name = "Renault", CountryId = 9 },
                new Manifacturer { Id = 11, Name = "Peugeot", CountryId = 9 },
                new Manifacturer { Id = 12, Name = "Rover", CountryId = 11 },
                new Manifacturer { Id = 13, Name = "Seat", CountryId = 1 }
                );

            builder.Entity<BodyType>()
                .HasData
                (
                   new BodyType { Id = 1, Name = "Sedan" },
                   new BodyType { Id = 1, Name = "SUV" },
                   new BodyType { Id = 1, Name = "Kombi" },
                   new BodyType { Id = 1, Name = "Limo" },
                   new BodyType { Id = 1, Name = "Van" },
                   new BodyType { Id = 1, Name = "Coupe" },
                   new BodyType { Id = 1, Name = "HatchBack" }
                );

            builder.Entity<EngineType>()
                .HasData
                (
                    new EngineType { Id = 1, Fuel = "Petrol" },
                    new EngineType { Id = 2, Fuel = "Diesel" },
                    new EngineType { Id = 3, Fuel = "Electricity" },
                    new EngineType { Id = 4, Fuel = "Petrol/LPG" },
                    new EngineType { Id = 5, Fuel = "Diesel/BioDiesel" },
                    new EngineType { Id = 6, Fuel = "Hybrid" }

                );


            base.OnModelCreating(builder);
        }
    }
}