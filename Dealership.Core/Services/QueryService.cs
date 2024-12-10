using Dealership.Core.Contracts;
using Dealership.Core.Models.Query;
using Dealership.Infrastructure.Common;
using Dealership.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Services
{
    public class QueryService : IQueryService
    {
        private readonly IRepository repository;

        public QueryService(IRepository _repository)
        {
            this.repository = _repository;
        }


        public async Task AddQueryAsync(string message, int announcementId, string userId)
        {
            var query = new Query
            {
                Message = message,
                AnnouncementId = announcementId,
                UserId = userId,
                CreatedAt = DateTime.Now,
                AdminResponse = string.Empty,
                IsAnswered = false 
            };

            await repository.AddAsync(query);
            await repository.SaveChangesAsync();
        }
        public async Task<QueryAnswerViewModel> AddAnswer(int id)
        {
            var model = await repository.AllAsReadOnly<Query>()
                .Where(x => x.Id == id)
                 .Select(x => new QueryAnswerViewModel()
                 {
                     Id = id,
                 })
                .FirstAsync();

            return model;
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllAsReadOnly<Announcement>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AllQueriesViewModel>> ShowAllQueriesWithoutAnswer()
        {
            var models = await repository.AllAsReadOnly<Query>()
                 .Where(x => x.IsAnswered == false && x.AdminResponse == string.Empty)
                 .Select(x => new AllQueriesViewModel()
                 {
                     Id = x.Id,
                     CarImage = x.Announcement.Car.CarImages[0],
                     Make = x.Announcement.Car.Make,
                     Model = x.Announcement.Car.Model,
                     Email = x.User.Email,
                     Description = x.Message,
                 })
                 .ToListAsync();

            return models;
        }

        public async Task AddAnswerAsync(int id, QueryAnswerViewModel model)
        {
            var query = await repository.All<Query>().Where(x => x.Id == id).FirstAsync();

            query.AdminResponse = model.Answer;
            query.IsAnswered = true;

            await repository.SaveChangesAsync();
        }
    }
}
