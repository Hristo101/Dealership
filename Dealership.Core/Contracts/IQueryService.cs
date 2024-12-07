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

    }
}
