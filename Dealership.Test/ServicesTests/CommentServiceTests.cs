using Dealership.Core.Contracts;
using Dealership.Core.Models.Comments;
using Dealership.Core.Services;
using Dealership.Infrastructure.Common;
using Dealership.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Test.ServicesTests
{
    [TestFixture]
    public class CommentServiceTests
    {
        private IRepository repository;
        private ICommentService commentService;
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
        public async Task TestCommentEdit()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);

            await repository.AddAsync(new Comment()
            {
                Id = 1,
                UserId = "user123", 
                Content = "Initial content",
                CreatedAt = DateTime.Now,
                Grade = 4
            });

            await repository.SaveChangesAsync();

            await commentService.UpdateCommentAsync(new EditCommentViewModel()
            {
                Id = 1,
                Content = "This comment is edited",
                Grade = 4
            });

            var dbComment = await repository.GetByIdAsync<Comment>(1);

            Assert.That(dbComment.Content, Is.EqualTo("This comment is edited"));
        }

        [Test]
        public async Task GetConfirmDeleteViewModelAsyncInTestMemory()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);

            await repository.AddRangeAsync(new List<Comment>()
            {
                new Comment() { Id = 2, CreatedAt = DateTime.Now, Grade=4, Content = "comment",UserId = "user123"},
                new Comment() { Id = 3, CreatedAt = DateTime.Now, Grade=5, Content = "comment1",UserId = "user234"},

            });

            await repository.SaveChangesAsync();

            var comment = await commentService.GetConfirmDeleteViewModelAsync(2);

            Assert.That(2, Is.EqualTo(comment.Id));
            Assert.AreEqual(comment.Content, "comment");
        }
        [Test]
        public async Task TestGetCommentByIdAsync()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);

            Comment comment = new Comment() { Id = 2,CreatedAt = DateTime.Now,Content="comment",Grade=5,UserId="user123"};

            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();

            var modelComment = await commentService.GetCommentByIdAsync(2);

            Assert.That(2,Is.EqualTo(modelComment.Id));
            Assert.AreEqual(comment.Content, modelComment.Content);
            Assert.AreEqual(comment.Grade, modelComment.Grade);
        }
        [Test]
        public async Task TestDeleteCommentAsync()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);

            Comment comment = new Comment()
            {
                Id = 1,
                UserId ="user123",
                Content="comment",
                CreatedAt = DateTime.Now,
                Grade = 5,
            };
            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();

            await commentService.DeleteCommentAsync(comment.Id);

            var dbComment = await repository.GetByIdAsync<Comment>(2);

            Assert.That(dbComment, Is.EqualTo(null));
        }
        [Test]
        public async Task TestAddCommentAsync()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);
            var model = new AddCommentViewModel()
            {
                Id = 1,
                Grade= 5,
                Content="comment",
                Username="Terry26"
            };

            await commentService.AddCommentAsync(model, "52ac7e14-f7c8-4fae-a013-3be138621461");


            var dbComment = await repository.GetByIdAsync<Comment>(1);

            Assert.That(dbComment.Id, Is.EqualTo(1));

            Assert.That(dbComment.Content, Is.EqualTo("comment"));
        }
        [Test]
        public async Task GetAllCommentsAsync_ShouldReturnComments()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);

            var user1 = new ApplicationUser { Id = "user1", UserName = "JohnDoe" };
            var user2 = new ApplicationUser { Id = "user2", UserName = "JaneDoe" };

            var comment1 = new Comment { Id = 1, User = user1, Content = "Great car!", CreatedAt = DateTime.Now, Grade = 5 };
            var comment2 = new Comment { Id = 2, User = user2, Content = "Not bad.", CreatedAt = DateTime.Now, Grade = 3 };

            await repository.AddAsync(user1);
            await repository.AddAsync(user2);
            await repository.AddAsync(comment1);
            await repository.AddAsync(comment2);

            await repository.SaveChangesAsync(); 

            var comments = await commentService.GetAllCommentsAsync();

            Assert.AreEqual(2, comments.Count());

            var commentViewModel1 = comments.First(c => c.Id == 1);
            Assert.AreEqual("JohnDoe", commentViewModel1.UserName);
            Assert.AreEqual("Great car!", commentViewModel1.Content);
            Assert.AreEqual(5, commentViewModel1.Grade);

            var commentViewModel2 = comments.First(c => c.Id == 2);
            Assert.AreEqual("JaneDoe", commentViewModel2.UserName);
            Assert.AreEqual("Not bad.", commentViewModel2.Content);
            Assert.AreEqual(3, commentViewModel2.Grade);
        }
        [Test]
        public async Task UserHasPermissionToEditOrDeleteComment_ShouldReturnTrue_WhenUserIsOwnerOfTheComment()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);

            var userId = "1";
            var comment = new Comment
            {
                Content = "Test comment",
                Grade = 4,
                UserId = userId,
                CreatedAt = DateTime.Now
            };

            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();


            var result = await commentService.UserHasPermissionToEditOrDeleteComment(userId, comment.Id);


            Assert.IsTrue(result);
        }

        [Test]
        public async Task UserHasPermissionToEditOrDeleteComment_ShouldReturnFalse_WhenUserIsNotOwnerOfTheComment()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);

            var userId = "1";
            var otherUserId = "2";
            var comment = new Comment
            {
                Content = "Test comment",
                Grade = 4,
                UserId = otherUserId,
                CreatedAt = DateTime.Now
            };

            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();


            var result = await commentService.UserHasPermissionToEditOrDeleteComment(userId, comment.Id);


            Assert.IsFalse(result);
        }
        [Test]
        public async Task UserHasPermissionToEditOrDeleteComment_ReturnsTrue_WhenUserIsCommentAuthor()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);


            var userId = "user123";
            var commentId = 1;

            var comment = new Comment
            {
                Id = commentId,
                UserId = userId,  
                Content = "Test comment",
                CreatedAt = DateTime.Now,
                Grade = 5
            };
            repository.AddAsync(comment);
            await repository.SaveChangesAsync(); 

            var result = await commentService.UserHasPermissionToEditOrDeleteComment(userId, commentId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task UserHasPermissionToEditOrDeleteComment_ReturnsFalse_WhenUserIsNotCommentAuthor()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);

            var userId = "user123";
            var commentId = 1;

            var comment = new Comment
            {
                Id = commentId,
                UserId = "user456", 
                Content = "Test comment",
                CreatedAt = DateTime.Now,
                Grade = 5
            };

            repository.AddAsync(comment);
            await repository.SaveChangesAsync();
            

            var result = await commentService.UserHasPermissionToEditOrDeleteComment(userId, commentId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task UserHasPermissionToEditOrDeleteComment_ReturnsFalse_WhenCommentDoesNotExist()
        {
            repository = new Repository(carDealershipContext);
            commentService = new CommentService(repository);

            var userId = "user123";
            var commentId = 1;  


            var result = await commentService.UserHasPermissionToEditOrDeleteComment(userId, commentId);

            Assert.IsFalse(result);
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
