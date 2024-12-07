using Dealership.Core.Contracts;
using Dealership.Core.Models;
using Dealership.Infrastructure.Common;
using Dealership.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ConfirmDeleteViewModel> GetConfirmDeleteViewModelAsync(int id)
        {
            var comment = await _repository.GetByIdAsync<Comment>(id);

            if (comment == null)
            {
                return null;
            }

            var model = new ConfirmDeleteViewModel
            {
                Id = comment.Id,
                Content = comment.Content,
                Grade = comment.Grade
            };

            return model;
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            var comment = await _repository.GetByIdAsync<Comment>(id);
            if (comment == null)
            {
                throw new KeyNotFoundException("Коментарът не беше намерен.");
            }
            return comment;
        }



        public async Task UpdateCommentAsync(EditCommentViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Коментарът не може да бъде null.");
            }

            var existingComment = await _repository.GetByIdAsync<Comment>(model.Id);
            if (existingComment == null)
            {
                throw new KeyNotFoundException("Коментарът за обновяване не беше намерен.");
            }

            // Обновяваме съдържанието на коментара
            existingComment.Content = model.Content;
            existingComment.Grade = model.Grade;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var comment = await _repository.GetByIdAsync<Comment>(id);

            if (comment == null)
            {
                return false;
            }

             _repository.Delete(comment);
            return true;
        }
    }
}
