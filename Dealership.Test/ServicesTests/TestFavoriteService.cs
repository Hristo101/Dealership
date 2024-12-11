using Dealership.Core.Contracts;
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
    public class TestFavoriteService
    {
        private IRepository repository;
        private IFavoriteService favouriteService;
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
        public async Task AddToFavoritesAsync_ShouldAddFavorite_WhenNotAlreadyAdded()
        {
            repository = new Repository(carDealershipContext);
            favouriteService = new FavoriteService(repository);

            var userId = "user123";
            var announcementId = 1;


            await favouriteService.AddToFavoritesAsync(userId, announcementId);


            var favorite = await repository.All<UserFavoriteAnnouncement>()
                .FirstOrDefaultAsync(f => f.UserId == userId && f.AnnouncementId == announcementId);

            Assert.IsNotNull(favorite); 
            Assert.AreEqual(userId, favorite.UserId);
            Assert.AreEqual(announcementId, favorite.AnnouncementId);
        }

        [Test]
        public async Task AddToFavoritesAsync_ShouldNotAddFavorite_WhenAlreadyAdded()
        {
            repository = new Repository(carDealershipContext);
            favouriteService = new FavoriteService(repository);

            var userId = "user123";
            var announcementId = 1;

            var existingFavorite = new UserFavoriteAnnouncement
            {
                UserId = userId,
                AnnouncementId = announcementId
            };
            await repository.AddAsync(existingFavorite);
            await repository.SaveChangesAsync(); 


            await favouriteService.AddToFavoritesAsync(userId, announcementId);

            var favoritesCount = await repository.All<UserFavoriteAnnouncement>()
                .CountAsync(f => f.UserId == userId && f.AnnouncementId == announcementId);

            Assert.AreEqual(1, favoritesCount);
        }
        [Test]
        public async Task GetFavoritesAsync_ShouldReturnFavorites_ForGivenUserId()
        {
            repository = new Repository(carDealershipContext);
            favouriteService = new FavoriteService(repository);

            var userId = "user123";
            var car1 = new Car
            {
                Id = 10,
                Make = "Audi",
                Model = "A4",
                UserId = userId,
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
                UserId = userId,
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
                Id = 10,
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

            var favorite1 = new UserFavoriteAnnouncement
            {
                UserId = userId,
                AnnouncementId = announcement1.Id
            };

            var favorite2 = new UserFavoriteAnnouncement
            {
                UserId = userId,
                AnnouncementId = announcement2.Id
            };

            await repository.AddAsync(car1);
            await repository.AddAsync(car2);
            await repository.AddAsync(announcement1);
            await repository.AddAsync(announcement2);
            await repository.AddAsync(favorite1);
            await repository.AddAsync(favorite2);

            await repository.SaveChangesAsync();

            var result = await favouriteService.GetFavoritesAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);

            var favorite = result.First();
            Assert.AreEqual(announcement1.Id, favorite.Id);
            Assert.AreEqual("Audi", favorite.CarMake);
            Assert.AreEqual("A4", favorite.CarModel);
            Assert.AreEqual(15000, favorite.Price);
            Assert.AreEqual("Audi A4 for sale", favorite.Description);


            var secondFavorite = result.Last();
            Assert.AreEqual(announcement2.Id, secondFavorite.Id);
            Assert.AreEqual("BMW", secondFavorite.CarMake);
            Assert.AreEqual("320d", secondFavorite.CarModel);
            Assert.AreEqual(18000, secondFavorite.Price);
            Assert.AreEqual("BMW 320d for sale", secondFavorite.Description);
        }
        [Test]
        public async Task RemoveFromFavoritesAsync_ShouldRemoveFavorite_WhenFavoriteExists()
        {
            repository = new Repository(carDealershipContext);
            favouriteService = new FavoriteService(repository);

            var userId = "user123";
            var announcementId = 1;

            var favorite = new UserFavoriteAnnouncement
            {
                UserId = userId,
                AnnouncementId = announcementId
            };

            await repository.AddAsync(favorite);
            await repository.SaveChangesAsync();


            var result = await favouriteService.RemoveFromFavoritesAsync(userId, announcementId);

            Assert.IsTrue(result, "Методът трябва да върне true, когато любимото е успешно премахнато.");
            var remainingFavorites = await repository.All<UserFavoriteAnnouncement>()
                                                      .Where(f => f.UserId == userId && f.AnnouncementId == announcementId)
                                                      .ToListAsync();
            Assert.IsEmpty(remainingFavorites, "Записът не е бил успешно премахнат.");
        }

        [Test]
        public async Task RemoveFromFavoritesAsync_ShouldReturnFalse_WhenFavoriteDoesNotExist()
        {
            repository = new Repository(carDealershipContext);
            favouriteService = new FavoriteService(repository);

            var userId = "user123";
            var announcementId = 1;

            var result = await favouriteService.RemoveFromFavoritesAsync(userId, announcementId);

            Assert.IsFalse(result, "Методът трябва да върне false, когато любимото не съществува.");
        }

        [TearDown]
        public void TearDown()
        {
            if (carDealershipContext != null)
            {
                carDealershipContext.Dispose();
            }
        }
    }
}
