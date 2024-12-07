using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Contracts
{
    public interface IFavoriteService
    {
        Task AddToFavoritesAsync(string userId, int announcementId);
    }
}
