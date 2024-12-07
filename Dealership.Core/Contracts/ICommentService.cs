using Dealership.Core.Models;
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
        Task AddCommentAsync(Comment comment);
        Task<Comment> GetCommentByIdAsync(int id);
        Task UpdateCommentAsync(EditCommentViewModel model);
        Task<ConfirmDeleteViewModel> GetConfirmDeleteViewModelAsync(int id);
        Task<bool> DeleteCommentAsync(int id);
    }
}
