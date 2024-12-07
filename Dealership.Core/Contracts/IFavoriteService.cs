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
        Task<List<Announcement>> GetFavoritesAsync(string userId);
        Task RemoveFromFavoritesAsync(string userId, int announcementId);
    }
}
