using Dealership.Core.Models.Comments;
using Dealership.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Contracts
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task AddCommentAsync(AddCommentViewModel comment, string userId);
        Task<EditCommentViewModel> GetCommentByIdAsync(int id);
        Task UpdateCommentAsync(EditCommentViewModel model);
        Task<ConfirmDeleteViewModel> GetConfirmDeleteViewModelAsync(int id);
        Task<bool> DeleteCommentAsync(int id);
    }
}
