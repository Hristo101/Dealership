using Dealership.Infrastructure.Common;
using Dealership.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Services
{
    public class QueryService
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
                IsAnswered = false 
            };

            await repository.AddAsync(query);
            await repository.SaveChangesAsync();
        }
    }
}
