using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Models.Car;
using OnlineCarMarket_Core.Services.CarServ;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;

namespace TestForMyApp
{
    [TestFixture]
    public class Tests
    {
        private ApplicationDbContext data;
        private ICarService carService;

        [SetUp]
        public void Setup()
        {
           
            carService = new CarServices(data);
        }
        

        [Test]
        public void AddCarAssync_Test()
        {
            RegisterCarViewModel model = new RegisterCarViewModel()
            {
                ManifacturerId = 1,
                Type = "Kombi",
                Milage = 12312,
                BodyTypeId = 1,
                EngineId = 1,
                FirstRegistration = DateTime.Now,
                NumberOfDoors = 4,
                Price = 1400

            };

            carService.AddCarAsync(model);


            Assert.That(data.Cars.Count(), Is.EqualTo(1)); 
        }
    }
}