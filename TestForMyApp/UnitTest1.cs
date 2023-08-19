using Moq;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;

namespace TestForMyApp
{

    public class Tests
    {
        [Test]
        public void TestAddToMyListAsync()
        {
            var data = new Mock<ApplicationDbContext>().Object;
            var carService = new Mock<ICarService>().Object;
            User bai = new User()
            {
                UserName = "pesho",
                Email = "Pesho@mail.bg",
                FirstName = "Pesho",
                LastName = "Peshev",
                PasswordHash = "pesho"
            };
            data.Add(bai);
            data.SaveChanges();

            Car car = new Car()
            {
                ManifacturerId = 2,
                Model = "Pesho",
                Milage = 11,
                BodyTypeId = 2,
                EngineId = 2,
                FirstRegistration = DateTime.UtcNow,
                NumberOfDoors = 4,
                Price = 2,
                DateOfRegistration = DateTime.UtcNow,
                ExpireDate = DateTime.UtcNow.AddMinutes(10)

            };
            data.Add(car);
            data.SaveChanges();

            carService.AddToMyListAsync(car, bai.Id);

            Assert.That(data.Cars.Count(), Is.EqualTo(1));
            Assert.That(data.UsersCars.Count(), Is.EqualTo(1));
           
        }
    }
}