using Dealership.Core.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Contracts
{
    public interface IQueryService
    {
        Task AddQueryAsync(string message, int announcementId, string userId);
        Task<IEnumerable<AllQueriesViewModel>> ShowAllQueriesWithoutAnswer();
        Task<QueryAnswerViewModel> AddAnswer(int id);
        Task<bool> ExistAsync(int id);
        Task AddAnswerAsync(int id, QueryAnswerViewModel model);
    }
}
