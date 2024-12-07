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
    public class FavoriteService : IFavoriteService
    {
        private readonly IRepository _repository;

        public FavoriteService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task AddToFavoritesAsync(string userId, int announcementId)
        {
            var existingFavorite = _repository
                .All<UserFavoriteAnnouncement>()
                .FirstOrDefault(f => f.UserId == userId && f.AnnouncementId == announcementId);

            if (existingFavorite == null)
            {
                var newFavorite = new UserFavoriteAnnouncement
                {
                    UserId = userId,
                    AnnouncementId = announcementId
                };

                await _repository.AddAsync(newFavorite);
                await _repository.SaveChangesAsync();
            }
        }
        public async Task<List<Announcement>> GetFavoritesAsync(string userId)
        {
            var favorites = await _repository.All<UserFavoriteAnnouncement>()
                .Where(f => f.UserId == userId)
                .Select(f => f.Announcement)
                .ToListAsync(); 

            return favorites;
        }

        public async Task RemoveFromFavoritesAsync(string userId, int announcementId)
        {
            var favorite = await _repository.All<UserFavoriteAnnouncement>()
                .FirstOrDefaultAsync(f => f.UserId == userId && f.AnnouncementId == announcementId);

            if (favorite != null)
            {
                _repository.Delete(favorite);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
