using Dealership.Core.Contracts;
using Dealership.Core.Models.Comments;
using Dealership.Infrastructure.Common;
using Dealership.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
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



        public async Task AddCommentAsync(AddCommentViewModel comment,string userId)
        {
            Comment comment1 = new Comment()
            {
                Id = comment.Id,
                Content = comment.Content,
                Grade = comment.Grade,
                UserId = userId,
                CreatedAt = DateTime.Now
            };
            await _repository.AddAsync(comment1);
            await _repository.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<CommentViewModel>> GetAllCommentsAsync()
        {
            return await _repository.AllAsReadOnly<Comment>()
                .Include(c => c.User) 
                .Select(c => new CommentViewModel() 
                {
                    Id = c.Id,
                    UserName = c.User.UserName ?? string.Empty,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    Grade = c.Grade,
                    CanDetails = true
                })

                .ToListAsync();
        }
        public async Task<ConfirmDeleteViewModel> GetConfirmDeleteViewModelAsync(int id)
        {
            var comment = await _repository.AllAsReadOnly<Comment>()
                        .Where(x => x.Id == id)
                        .FirstAsync(); 

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

        public async Task<EditCommentViewModel> GetCommentByIdAsync(int id)
        {
            var model = await _repository.AllAsReadOnly<Comment>()
                        .Where(x =>x.Id == id)
                        .Select(x => new EditCommentViewModel()
                        {
                            Id = id,
                            Content = x.Content,
                            Grade = x.Grade
                        })
                        .FirstAsync();
            return model;
        }



        public async Task UpdateCommentAsync(EditCommentViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Коментарът не може да бъде null.");
            }

            var existingComment = await _repository.All<Comment>().Where(x =>x.Id == model.Id).FirstAsync();
            if (existingComment == null)
            {
                throw new KeyNotFoundException("Коментарът за обновяване не беше намерен.");
            }

  
            existingComment.Content = model.Content;
            existingComment.Grade = model.Grade;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var comment = await _repository.All<Comment>().Where(x => x.Id == id).FirstAsync();

            if (comment == null)
            {
                return false;
            }

             _repository.Delete(comment);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
