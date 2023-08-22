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

        [Test]
        public void Test_FindCar()
        {
            Mock<ICarService> carServ = new Mock<ICarService>();

            RegisterCarViewModel model = new RegisterCarViewModel()
            {
                ManifacturerId = 1,
                Type = "SUV",
                Milage = 11111,
                BodyTypeId = 1,
                EngineId = 1,
                FirstRegistration = DateTime.Now,
                NumberOfDoors = 4,
                Price = 111

            };

            EditCarViewModel edit = new EditCarViewModel()
            {
                Id = 1,
                ManifacturerId = 1,
                BodyTypeId = 1,
                EngineId = 1,
                FirstRegistration = DateTime.Now,
                Milage = 11111,
                NumberOfDoors = 4,
                Price = 111
            };
            List<EditCarViewModel> editCar = new List<EditCarViewModel>();
            editCar.Add(edit);

            var serv = carServ.Object;

            serv.AddCarAsync(model);

            carServ.Setup(c => c.FindCar(1))
                   .Returns(Task.FromResult(editCar));


        }

        [Test]

        public void Test_SearchByFuel()
        {
            List<DisplayCarModel> display = new List<DisplayCarModel>();

            DisplayCarModel model = new DisplayCarModel()
            {
                Model = "E46",
                Manifacturer = "BMW",
                FirstRegistration = "11/02/2004",
                EngineVolume = 2000,
                EnginePower = 150,
                Price = "200"
            };

            DisplayCarModel model1 = new DisplayCarModel()
            {
                Model = "E46",
                Manifacturer = "BMW",
                FirstRegistration = "11/02/2004",
                EngineVolume = 2000,
                EnginePower = 150,
                Price = "200"
            };

            display.Add(model1);
            display.Add(model);

            SearchCarByFuelTypeModel fuel = new SearchCarByFuelTypeModel()
            {
                EngineTypeId = 1
            };

            Mock<ICarService> carServ = new Mock<ICarService>();
            carServ.Setup(s => s.searchByFuel(fuel))
                .Returns(display);

            var serv = carServ.Object;
            Assert.That(serv.searchByFuel(fuel), Is.EqualTo(display));



        }

        
    }
}

