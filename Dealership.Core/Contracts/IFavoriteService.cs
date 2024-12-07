using Dealership.Core.Models;
using Dealership.Infrastructure.Data.Models;
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
        Task<List<FavoriteViewModel>> GetFavoritesAsync(string userId);
        Task<bool> RemoveFromFavoritesAsync(string userId, int announcementId);
    }
}
