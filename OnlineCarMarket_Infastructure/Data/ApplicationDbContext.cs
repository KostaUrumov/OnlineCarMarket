using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Infastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .Property(e => e.Price)
                .HasPrecision(38, 18);


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
                   new BodyType { Id = 2, Name = "SUV" },
                   new BodyType { Id = 3, Name = "Kombi" },
                   new BodyType { Id = 4, Name = "Limo" },
                   new BodyType { Id = 5, Name = "Van" },
                   new BodyType { Id = 6, Name = "Coupe" },
                   new BodyType { Id = 7, Name = "HatchBack" }
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


            builder.Entity<Engine>()
                .HasData
                (
                    new Engine { Id = 1, EngineTypeId = 1, FuelConsumption = 10.8, HorsePower = 150, ManifacturerId = 1, Volume = 2000 },
                    new Engine { Id = 2, EngineTypeId = 2, FuelConsumption = 7.4, HorsePower = 140, ManifacturerId = 8, Volume = 1800 },
                    new Engine { Id = 3, EngineTypeId = 1, FuelConsumption = 6.4, HorsePower = 90, ManifacturerId = 13, Volume = 1100 },
                    new Engine { Id = 4, EngineTypeId = 2, FuelConsumption = 2.2, HorsePower = 80, ManifacturerId = 4, Volume = 900 },
                    new Engine { Id = 5, EngineTypeId = 3, FuelConsumption = 1, HorsePower = 90, ManifacturerId = 7, Volume = 500 },
                    new Engine { Id = 6, EngineTypeId = 2, FuelConsumption = 5.3, HorsePower = 124, ManifacturerId = 1, Volume = 1600 },
                    new Engine { Id = 7, EngineTypeId = 4, FuelConsumption = 14.5, HorsePower = 184, ManifacturerId = 3, Volume = 2700 },
                    new Engine { Id = 8, EngineTypeId = 6, FuelConsumption = 2.6, HorsePower = 186, ManifacturerId = 4, Volume = 600 },
                    new Engine { Id = 9, EngineTypeId = 1, FuelConsumption = 6.7, HorsePower = 118, ManifacturerId = 9, Volume = 1500 }
            );


            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "ADMIN".ToUpper() },
                new IdentityRole { Id = "2c93174e-3b0e-446f-86af-883d56fr7210", Name = "User", NormalizedName = "USER".ToUpper() });

           

            base.OnModelCreating(builder);
        }


        public DbSet<BodyType> BoduTypes { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Engine> Engines { get; set; } = null!;
        public DbSet<EngineType> EngineTypes { get; set; } = null!;
        public DbSet<Manifacturer> Manifacturers { get; set; } = null!;
    }
}