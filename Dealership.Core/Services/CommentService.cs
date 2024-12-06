using Dealership.Core.Contracts;
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
    public class CommentService : ICommentService
    {
        private readonly IRepository _repository;

        public CommentService(IRepository repository)
        {
            _repository = repository;
        }



        public async Task AddCommentAsync(Comment comment)
        {
            await _repository.AddAsync(comment);
            await _repository.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            // Връщаме всички коментари и включваме потребителите чрез repository
            return await _repository.All<Comment>()
                .Include(c => c.User)  // Включваме User
                .ToListAsync();
        }
    }
}
