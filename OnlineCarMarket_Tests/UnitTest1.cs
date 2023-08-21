using Moq;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Car;
using OnlineCarMarket_Infastructure.Entities;

namespace OnlineCarMarket_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public void Test_AddCarAsync()
        {
            Mock<ICarService> carServ = new Mock<ICarService>();

            RegisterCarViewModel model = new RegisterCarViewModel()
            {
                ManifacturerId = 1,
                Type = "SUV",
                Milage = 111,
                BodyTypeId = 1,
                EngineId = 1,
                FirstRegistration = DateTime.Now,
                NumberOfDoors = 4,
                Price = 111

            };
            Car car = new Car()
            {
                ManifacturerId = 1,
                Model = "SUV",
                Milage = 1111,
                BodyTypeId = 1,
                EngineId = 1,
                FirstRegistration = DateTime.Now,
                NumberOfDoors = 4,
                Price = 111,
                DateOfRegistration = DateTime.UtcNow,
                ExpireDate = DateTime.UtcNow.AddMinutes(10)

            };

            carServ.Setup(c => c.AddCarAsync(model))
                   .Returns(Task.FromResult(car));

            var serv = carServ.Object;
            Car auto = serv.AddCarAsync(model).Result;
            Assert.That(serv.AddCarAsync(model).Result, Is.EqualTo(auto));

        }

        
    }
}

