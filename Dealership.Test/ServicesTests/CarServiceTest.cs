using Dealership.Core.Contracts;
using Dealership.Core.Models.Car;
using Dealership.Core.Services;
using Dealership.Infrastructure.Common;
using Dealership.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Test.ServicesTests
{
    [TestFixture]
    public class CarServiceTest
    {
        private IRepository repository;
        private ICarService carService;
        private CarDealershipContext carDealershipContext;

        [SetUp]
        public void Setup()
        {

            var contextOptions = new DbContextOptionsBuilder<CarDealershipContext>()
         .UseInMemoryDatabase("HouseDB_" + Guid.NewGuid())  
         .Options;


            carDealershipContext = new CarDealershipContext(contextOptions);

            carDealershipContext.Database.EnsureDeleted();
            carDealershipContext.Database.EnsureCreated();
        }
        [Test]
        public async Task TestGetAllCarsAsync()
        {
            repository = new Repository(carDealershipContext);
            carService = new CarService(repository);

            var car1 = new Car
            {
                Id = 10,
                Make = "Audi",
                Model = "A4",
                Color = "Red",
                EngineType = "Diesel",
                Horsepower = 150,
                Mileage = 120000,
                Speeds = "Automatic",
                Year = 2015,
                CarImages = new List<string> { "car1-image1.jpg", "car1-image2.jpg" }
            };

            var car2 = new Car
            {
                Id = 11,
                Make = "BMW",
                Model = "320d",
                Color = "Blue",
                EngineType = "Diesel",
                Horsepower = 180,
                Mileage = 90000,
                Speeds = "Manual",
                Year = 2017,
                CarImages = new List<string> { "car2-image1.jpg" }
            };
            
            await repository.AddAsync(car1);
           await  repository.AddAsync(car2);
            await repository.SaveChangesAsync();

            var models =await carService.GetAllCarsAsync();

            Assert.That(models.Count(),Is.EqualTo(2));
        }
        [Test]
        public async Task TestDetailsCarAsync()

        {
            repository = new Repository(carDealershipContext);
            carService = new CarService(repository);

            var car1 = new Car
            {
                Id = 10,
                Make = "Audi",
                Model = "A4",
                Color = "Red",
                EngineType = "Diesel",
                Horsepower = 150,
                Mileage = 120000,
                Speeds = "Automatic",
                Year = 2015,
                CarImages = new List<string> { "car1-image1.jpg", "car1-image2.jpg" }
            };
            await repository.AddAsync(car1);
            await repository.SaveChangesAsync();

            var model = await carService.DetailsCarAsync(10);

            Assert.That(model.Id, Is.EqualTo(10));
            Assert.That(model.Make, Is.EqualTo("Audi"));
            Assert.That(model.Model, Is.EqualTo("A4"));
            Assert.That(model.Color, Is.EqualTo("Red"));
        }
        [Test]
        public async Task TestExistAsync()
        {
            repository = new Repository(carDealershipContext);
            carService = new CarService(repository);

            var car1 = new Car
            {
                Id = 10,
                Make = "Audi",
                Model = "A4",
                Color = "Red",
                EngineType = "Diesel",
                Horsepower = 150,
                Mileage = 120000,
                Speeds = "Automatic",
                Year = 2015,
                CarImages = new List<string> { "car1-image1.jpg", "car1-image2.jpg" }
            };

            await repository.AddAsync(car1);
            await repository.SaveChangesAsync();

            var result = await carService.ExistAsync(10);

            Assert.That(result, Is.True);
        }
        [Test]
        public async Task TestAddCarAsync()
        {
            repository = new Repository(carDealershipContext);
            carService = new CarService(repository);

            var user1 = new ApplicationUser { Id = "user1", UserName = "JohnDoe" };

            var car1 = new CarViewModel
            {
                Id = 10,
                Make = "Audi",
                UserId = user1.Id,
                Model = "A4",
                Color = "Red",
                EngineType = "Diesel",
                Horsepower = 150,
                Mileage = 120000,
                Speeds = "Automatic",
                Year = 2015,
                CarImages = "car1-image1.jpg,car1-image2.jpg"
            };

            await repository.AddAsync(user1);
            await repository.SaveChangesAsync();

           await carService.AddCarAsync(car1);

            var model = await repository.GetByIdAsync<Car>(10);

            Assert.That(model.Make, Is.EqualTo("Audi"));
            Assert.That(model.Model, Is.EqualTo("A4"));
            Assert.That(model.Color, Is.EqualTo("Red"));
        }

        [TearDown]
        public void TearDown()
        {
            carDealershipContext.Dispose();
        }
    }
}
