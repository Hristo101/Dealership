using Dealership.Core.Contracts;
using Dealership.Core.Models.Comments;
using Dealership.Core.Models.Query;
using Dealership.Core.Services;
using Dealership.Infrastructure.Common;
using Dealership.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            var model = new Infrastructure.Data.Models.Query()
            {
                Id = 1,
                Message = "this is the comment",
                UserId = "user123",
                AnnouncementId = 2,
            };

            await queryService.AddQueryAsync(model.Message, model.AnnouncementId, "user123");


            var dbQuery = await repository.GetByIdAsync<Infrastructure.Data.Models.Query>(1);

            Assert.That(dbQuery.Id, Is.EqualTo(1));

            Assert.That(dbQuery.Message, Is.EqualTo("this is the comment"));
        } 
        [Test]
        public async Task TestAddAnswer()
        {
            var repo = new Repository(carDealershipContext);
            var queryService = new QueryService(repo);

            Infrastructure.Data.Models.Query query = new Infrastructure.Data.Models.Query()
            {
                Id = 1,
                AnnouncementId = 1,
                UserId = "user123",
                Message = "this is message",
            };

            await repo.AddAsync(query);
            await repo.SaveChangesAsync();

            var queryDb = queryService.AddAnswer(query.Id);

            Assert.That(queryDb.Id, Is.EqualTo(1));
        }
        [Test]
        public async Task Test_ShowAllQueriesWithoutAnswer_ReturnsCorrectResults()
        {
            repository = new Repository(carDealershipContext);
            queryService = new QueryService(repository);
            var user1 = new ApplicationUser { Id = "user1", UserName = "JohnDoe" };
 
            await repository.AddRangeAsync(new List<Infrastructure.Data.Models.Query>()
    {
        new Infrastructure.Data.Models.Query()
        {
            Id = 2,
            Message = "tova durvo li e?",
            AnnouncementId = 1,
            CreatedAt = DateTime.Now,
            AdminResponse = string.Empty,
            IsAnswered = false,
            UserId = user1.Id,
        },
        new Infrastructure.Data.Models.Query()
        {
            Id = 3,
            Message = "tova kaktus li e?",
            AnnouncementId = 2,
            CreatedAt = DateTime.Now,
            AdminResponse = "this is AdminResponse",
            IsAnswered = true,
              UserId = user1.Id,
        },
        new Infrastructure.Data.Models.Query()
        {
            Id = 4,
            Message = "tova chovek li e?",
            AnnouncementId = 3,
            CreatedAt = DateTime.Now,
            AdminResponse = string.Empty,
            IsAnswered = false,
            UserId = user1.Id,
        }
    });
            await repository.AddAsync(user1);
            await repository.SaveChangesAsync();

            var queriesDb = await queryService.ShowAllQueriesWithoutAnswer();

            Assert.That(queriesDb.Count, Is.EqualTo(2), "The count of queries without answer is incorrect.");
            Assert.That(queriesDb.Any(q => q.Description == "tova durvo li e?"), Is.True, "Query 1 should be in the result.");
            Assert.That(queriesDb.Any(q => q.Description == "tova chovek li e?"), Is.True, "Query 3 should be in the result.");
            Assert.That(queriesDb.Any(q => q.Description == "tova kaktus li e?"), Is.False, "Query 2 should not be in the result.");
        }
        [Test]
        public async Task TestExistAsync()
        {
            repository = new Repository(carDealershipContext);
            queryService = new QueryService(repository);

            var user1 = new ApplicationUser { Id = "user1", UserName = "JohnDoe" };

            var query = new Infrastructure.Data.Models.Query()
            {
              Id = 2,
              CreatedAt = DateTime.Now,
              Message = "this is a message",
              AdminResponse = string.Empty,
              IsAnswered = false,
              UserId = user1.Id,
            };

            await repository.AddAsync(query);
            await repository.AddAsync(user1);
            await repository.SaveChangesAsync();

            var result = await queryService.ExistAsync(2);

            Assert.That(result, Is.True);
        }
        [Test]
        public async Task TestAddAnswerAsync()
        {
            repository = new Repository(carDealershipContext);
            queryService = new QueryService(repository);

            var user1 = new ApplicationUser { Id = "user1", UserName = "JohnDoe" };

            var query = new Infrastructure.Data.Models.Query()
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                Message = "this is a message",
                AdminResponse = string.Empty,
                IsAnswered = false,
                UserId = user1.Id,
            };

            await repository.AddAsync(query);
            await repository.SaveChangesAsync();

            var model = new QueryAnswerViewModel()
            {
                Answer = "This is a admin answer",
                Id = 2,
            };

            await queryService.AddAnswerAsync(2,model);

            var dbQuery = await repository.GetByIdAsync<Infrastructure.Data.Models.Query>(2);

            Assert.That(dbQuery.IsAnswered, Is.True);
            Assert.That(dbQuery.AdminResponse, Is.EqualTo("This is a admin answer"));
        }

        [TearDown]
        public void TearDown()
        {
            carDealershipContext.Dispose();
        }
    }
}
