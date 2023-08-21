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
        public void Test_GetTheLastFiveCars()
        {
            List<DisplayCarModel> result = new List<DisplayCarModel>();

            RegisterCarViewModel model = new RegisterCarViewModel()
            {
                ManifacturerId = 1,
                Type = "SUV",
                Milage = 1111,
                BodyTypeId = 1,
                EngineId = 1,
                FirstRegistration = DateTime.Now,
                NumberOfDoors = 4,
                Price = 1111

            };

            RegisterCarViewModel model1 = new RegisterCarViewModel()
            {
                ManifacturerId = 1,
                Type = "SUV",
                Milage = 111,
                BodyTypeId = 1,
                EngineId = 1,
                FirstRegistration = new DateTime(2001, 1, 1),
                NumberOfDoors = 4,
                Price = 10000
            };

            RegisterCarViewModel model2 = new RegisterCarViewModel()
            {
                ManifacturerId = 1,
                Type = "SUV",
                Milage = 111,
                BodyTypeId = 1,
                EngineId = 1,
                FirstRegistration = new DateTime(2001, 1, 1),
                NumberOfDoors = 4,
                Price = 10000

            };

            RegisterCarViewModel model3 = new RegisterCarViewModel()
            {
                ManifacturerId = 1,
                Type = "SUV",
                Milage = 111,
                BodyTypeId = 1,
                EngineId = 1,
                FirstRegistration = new DateTime(2001, 1, 1),
                NumberOfDoors = 4,
                Price = 10000

            };

            RegisterCarViewModel model4 = new RegisterCarViewModel()
            {
                ManifacturerId = 1,
                Type = "SUV",
                Milage = 111,
                BodyTypeId = 1,
                EngineId = 1,
                FirstRegistration = new DateTime(2001, 1, 1),
                NumberOfDoors = 4,
                Price = 10000

            };


            Mock<ICarService> carServ = new Mock<ICarService>();
            var serv = carServ.Object;

            serv.AddCarAsync(model);
            serv.AddCarAsync(model1);
            serv.AddCarAsync(model2);
            serv.AddCarAsync(model3);
            serv.AddCarAsync(model4);

            carServ.Setup(c => c.LastFiveAddedCars())
                .Returns(new List<DisplayCarModel>()
                {
                    new DisplayCarModel()
                {
                EnginePower = 100,
                Id = 5,
                Model = "e46",
                Manifacturer = "BMW",
                FirstRegistration = "01.01.2001",
                EngineVolume = 2000,
                Price = "10000",
                isObserved = false

                },

                    new DisplayCarModel
            {
                EnginePower = 100,
                Id = 4,
                Model = "e46",
                Manifacturer = "BMW",
                FirstRegistration = "01.01.2001",
                EngineVolume = 2000,
                Price = "10000",
                isObserved = false

            },

                    new DisplayCarModel
            {
                EnginePower = 100,
                Id = 3,
                Model = "e46",
                Manifacturer = "BMW",
                FirstRegistration = "01.01.2001",
                EngineVolume = 2000,
                Price = "10000",
                isObserved = false

            },

                    new DisplayCarModel
            {
                EnginePower = 100,
                Id = 2,
                Model = "e46",
                Manifacturer = "BMW",
                FirstRegistration = "01.01.2001",
                EngineVolume = 2000,
                Price = "10000",
                isObserved = false

            },

                    new DisplayCarModel
            {
                EnginePower = 100,
                Id = 1,
                Model = "e46",
                Manifacturer = "BMW",
                FirstRegistration = "01.01.2001",
                EngineVolume = 2000,
                Price = "10000",
                isObserved = false

            },

                });

            Assert.That(serv.LastFiveAddedCars(), Is.EqualTo(result));



        }
    }
}

