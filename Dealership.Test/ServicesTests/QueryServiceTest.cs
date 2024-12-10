using Dealership.Core.Contracts;
using Dealership.Core.Models.Comments;
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
    public class QueryServiceTest
    {
        private IRepository repository;
        private IQueryService queryService;
        private CarDealershipContext carDealershipContext;

        [SetUp]
        public void Setup()
        {

            var contextOptions = new DbContextOptionsBuilder<CarDealershipContext>()
                .UseInMemoryDatabase("HouseDB")
                .Options;

            carDealershipContext = new CarDealershipContext(contextOptions);
            carDealershipContext.Database.EnsureDeleted();
            carDealershipContext.Database.EnsureCreated();
        }
        [Test]
        public async Task TestAddQueryAsync()
        {
            repository = new Repository(carDealershipContext);
            queryService = new QueryService(repository);
            var model = new Query()
            {
                Id = 1,
                Message = "this is the comment",
                UserId = "user123",
                AnnouncementId = 2,
            };

            await queryService.AddQueryAsync(model.Message, model.AnnouncementId, "user123");


            var dbQuery = await repository.GetByIdAsync<Query>(1);

            Assert.That(dbQuery.Id, Is.EqualTo(1));

            Assert.That(dbQuery.Message, Is.EqualTo("this is the comment"));
        }
        [Test]
        public async Task ExistQueryTestInMemory()
        {

            repository = new Repository(carDealershipContext);
            queryService = new QueryService(repository);

            await repository.AddRangeAsync(new List<Query>()
            {
                new Query() { Id = 2, Message="tova durvo li e?"},
                new Query() { Id = 3, ImageUrl = "", Title = "",Description = "",DietCategoryId = 1},

            });

            await repo.SaveChangesAsync();

            var diet = await dietService.ExistAsync(2);

            Assert.IsTrue(diet);
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
