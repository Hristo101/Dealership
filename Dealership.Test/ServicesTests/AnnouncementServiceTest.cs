using Dealership.Core.Contracts;
using Dealership.Core.Models.Announcement;
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
    public class AnnouncementServiceTest
    {
        private IRepository repository;
        private IAnnouncementService announcementService;
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
            public async Task TestDetailsAnnouncementAsync()
            {

                repository = new Repository(carDealershipContext);
                announcementService = new AnnouncementService(repository);

                var car1 = new Car
                {
                    Id=10,
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
                    Id=11,
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

                var announcement1 = new Announcement
                {
                    Id=10,
                    CreatedDate = DateTime.Now.AddDays(-1),
                    Description = "Audi A4 for sale",
                    ExtrasForComfort = "Climate Control, Navigation",
                    SecurityExtras = "ABS, ESP",
                    Price = 15000,
                    Car = car1
                };

                var announcement2 = new Announcement
                {
                    Id = 11,
                    CreatedDate = DateTime.Now.AddDays(-3),
                    Description = "BMW 320d for sale",
                    ExtrasForComfort = "Leather Seats, Autopilot",
                    SecurityExtras = "Airbags, Lane Assist",
                    Price = 18000,
                    Car = car2
                };

                await repository.AddAsync(car1);
                await repository.AddAsync(car2);
                await repository.AddAsync(announcement1);
                await repository.AddAsync(announcement2);

                await repository.SaveChangesAsync();

                var result = await announcementService.DetailsAnnouncementAsync(10);

                Assert.IsNotNull(result);
                Assert.That(result.Id, Is.EqualTo(10));
                Assert.AreEqual("Audi", result.Make);
                Assert.AreEqual("A4", result.Model);
                Assert.AreEqual("Red", result.Color);
                Assert.AreEqual(150, result.HorsePower);
                Assert.AreEqual(15000, result.Price);
                Assert.IsTrue(result.ImageUrls.Contains("car1-image1.jpg"));
            }

        [Test]
        public async Task TestGetAnnouncementForEditAsync()
        {
            repository = new Repository(carDealershipContext);
            announcementService = new AnnouncementService(repository);

            var announcement = new Announcement()
            {
                Id = 9,
                Description = "this is a description",
                ExtrasForComfort = "This is comfort",
                SecurityExtras = "This is security",
                CreatedDate = DateTime.Now,
                Price = 1000
            };

            repository.AddAsync(announcement);
            repository.SaveChangesAsync();

            var model = await announcementService.GetAnnouncementForEditAsync(announcement.Id);

            Assert.IsNotNull(model);
            Assert.That(model.Id, Is.EqualTo(9));
            Assert.AreEqual("this is a description", model.Description);
            Assert.AreEqual("This is comfort", model.ExtrasForComfort);
            Assert.AreEqual("This is security", model.SecurityExtras);
            Assert.AreEqual(1000, model.Price);
        }
        [Test]
        public async Task TestGetTotalAnnouncementCountAsync()
        {

            repository = new Repository(carDealershipContext);
            announcementService = new AnnouncementService(repository);

            var announcement1 = new Announcement
            {
                Id = 10,
                CreatedDate = DateTime.Now.AddDays(-1),
                Description = "Audi A4 for sale",
                ExtrasForComfort = "Climate Control, Navigation",
                SecurityExtras = "ABS, ESP",
                Price = 15000,
            };

            var announcement2 = new Announcement
            {
                Id = 11,
                CreatedDate = DateTime.Now.AddDays(-3),
                Description = "BMW 320d for sale",
                ExtrasForComfort = "Leather Seats, Autopilot",
                SecurityExtras = "Airbags, Lane Assist",
                Price = 18000,
            };

            await repository.AddAsync(announcement1);
            await repository.SaveChangesAsync();
            await repository.AddAsync(announcement2);
            await repository.SaveChangesAsync();

            var count = await announcementService.GetTotalAnnouncementCountAsync();

            Assert.IsNotNull(count);
            Assert.AreEqual(9, count);
        }
        [Test]
        public async Task TestEditAsync()
        {
            repository = new Repository(carDealershipContext);
            announcementService = new AnnouncementService(repository);

            await repository.AddAsync(new Announcement()
            {
                Id = 10,
                Price = 1000,
                Description = "This is the description",
                ExtrasForComfort = "this is comfort",
                SecurityExtras = "this is extras",
                CreatedDate = DateTime.Now,
            });

            await repository.SaveChangesAsync();

            await announcementService.EditAsync(10, new EditAnnouncementViewModel()
            {
                Id = 10,
                Price = 100,
                ExtrasForComfort = "this is comfort",
                SecurityExtras = "this is extras",
                CreatedDate = DateTime.Now,
                Description = "This announcement is edited",

            });

            var dbAnnouncement = await repository.GetByIdAsync<Announcement>(10);

            Assert.That(dbAnnouncement.Description, Is.EqualTo("This announcement is edited"));
            Assert.That(dbAnnouncement.Price, Is.EqualTo(100));
        }
        [Test]
        public async Task TestGetAnnouncementForDeleteAsync()
        {
            repository = new Repository(carDealershipContext);
            announcementService = new AnnouncementService(repository);

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
            await repository.AddAsync(new Announcement()
            {
                Id = 10,
                Price = 1000,
                ExtrasForComfort = "this is comfort",
                SecurityExtras = "this is extras",
                Description = "This is the description",
                CreatedDate = DateTime.Now,
                Car = car1,
                CarId = car1.Id
            });

            await repository.SaveChangesAsync();

            var model = await announcementService.GetAnnouncementForDeleteAsync(10);

            Assert.That(model.Description, Is.EqualTo("This is the description"));
            Assert.That(model.Price, Is.EqualTo(1000));
            Assert.That(model.Id, Is.EqualTo(10));
        }
        [Test]
        public async Task TestRemoveAsync()
        {
            repository = new Repository(carDealershipContext);
            announcementService = new AnnouncementService(repository);
            var car1 = new Car
            {
                Id = 10,
                Make = "Audi",
                Model = "A4",
                Color = "Red",
                EngineType = "Diesel",
                Horsepower = 150,
                IsInAnnouncement = true,
                Mileage = 120000,
                Speeds = "Automatic",
                Year = 2015,
                CarImages = new List<string> { "car1-image1.jpg", "car1-image2.jpg" }
            };

            await repository.AddAsync(car1);
            await repository.AddAsync(new Announcement()
            {
                Id = 10,
                Price = 1000,
                ExtrasForComfort = "this is comfort",
                SecurityExtras = "this is extras",
                Description = "This is the description",
                CreatedDate = DateTime.Now,
                Car = car1,
                CarId = car1.Id
            });

            await repository.SaveChangesAsync();

            await announcementService.RemoveAsync(10);

            var dbAnnouncement = await repository.GetByIdAsync<Announcement>(10);
            var dbCar = await repository.GetByIdAsync<Car>(10);
            Assert.That(dbAnnouncement, Is.EqualTo(null));
            Assert.That(dbCar.IsInAnnouncement, Is.EqualTo(false));
        }
        [Test]
        public async Task TestAddAsync()
        {
            repository = new Repository(carDealershipContext);
            announcementService = new AnnouncementService(repository);

            var model = new AddAnnouncementViewModel()
            {
                Id = 10,
                Price = 1000,
                ExtrasForComfort = "this is comfort",
                SecurityExtras = "this is extras",
                Description = "This is the description",
                CarId = 10,
                Cars = new List<AddCarViewModel>() { new AddCarViewModel() { Id = 10, Make = "BMW", Model = "X6" }, new AddCarViewModel() {Id = 11, Make = "Mercedes", Model = "E 250" } }
            };

            await announcementService.AddAsync(model);

            var dbAnnouncement = await repository.GetByIdAsync<Announcement>(10);

            Assert.That(dbAnnouncement.Id, Is.EqualTo(10));
            Assert.That(dbAnnouncement.Description, Is.EqualTo("This is the description"));
        }

        [Test]
        public async Task TestGetModelForAnnouncment()
        {
            repository = new Repository(carDealershipContext);
            announcementService = new AnnouncementService(repository);

            var car1 = new Car
            {
                Id = 10,
                Make = "Audi",
                Model = "A4",
                Color = "Red",
                EngineType = "Diesel",
                Horsepower = 150,
                IsInAnnouncement = true,
                Mileage = 120000,
                Speeds = "Automatic",
                Year = 2015,
                CarImages = new List<string> { "car1-image1.jpg", "car1-image2.jpg" }
            };

            await repository.AddAsync(car1);
            await repository.SaveChangesAsync();

            var model = await announcementService.GetModelForAnnouncment(car1.Id);


            Assert.That(model.Make, Is.EqualTo("Audi"));
            Assert.That(model.Model, Is.EqualTo("A4"));
            Assert.That(model.CarImage, Is.EqualTo("car1-image1.jpg"));
        }
        [Test]
        public async Task TestEvaluationAsync()
        {
            repository = new Repository(carDealershipContext);
            announcementService = new AnnouncementService(repository);
            var car1 = new Car
            {
                Id = 10,
                Make = "Audi",
                Model = "A4",
                Color = "Red",
                EngineType = "Diesel",
                Horsepower = 150,
                IsInAnnouncement = true,
                Mileage = 120000,
                Speeds = "Automatic",
                Year = 2015,
                CarImages = new List<string> { "car1-image1.jpg", "car1-image2.jpg" }
            };

            await repository.AddAsync(car1);
            await repository.SaveChangesAsync();

            var model = new AnnouncementEvaluationViewModel()
            {
                Id = 9,
                CarId = car1.Id,
                CarImage = car1.CarImages[0],
                Description = "this is a description",
                SecurityExtras = "this is a securityExtras",
                ExtrasForComfort = "this is a comfortExtras",
                Make = car1.Make,
                Model = car1.Model,
                Price = 1000
            };

            await announcementService.EvaluationAsync(10, model);

            var dbAnnouncement = await repository.AllAsReadOnly<Announcement>().Where(x =>x.CarId == car1.Id).FirstAsync();

            Assert.That(dbAnnouncement.Price, Is.EqualTo(1000));
            Assert.That(dbAnnouncement.Description, Is.EqualTo("this is a description"));
            Assert.That(dbAnnouncement.SecurityExtras, Is.EqualTo("this is a securityExtras"));
            Assert.That(dbAnnouncement.ExtrasForComfort, Is.EqualTo("this is a comfortExtras"));
        }
        [Test]
        public async Task TestExistAsync()
        {
            repository = new Repository(carDealershipContext);
            announcementService = new AnnouncementService(repository);

            var announcement1 = new Announcement
            {
                Id = 10,
                CreatedDate = DateTime.Now.AddDays(-1),
                Description = "Audi A4 for sale",
                ExtrasForComfort = "Climate Control, Navigation",
                SecurityExtras = "ABS, ESP",
                Price = 15000,
            };

            await repository.AddAsync(announcement1);
            await repository.SaveChangesAsync();

            var result = await announcementService.ExistAsync(10);

            Assert.That(result, Is.True);
        }
            [TearDown]
        public void TearDown()
        {
        carDealershipContext.Dispose();
        }
            
    }


 }



