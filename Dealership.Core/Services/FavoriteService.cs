using Dealership.Core.Contracts;
using Dealership.Core.Models;
using Dealership.Infrastructure.Common;
using Dealership.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Routing;
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
        public async Task<List<FavoriteViewModel>> GetFavoritesAsync(string userId)
        {
            var favorites = await _repository.All<UserFavoriteAnnouncement>()
                .Where(f => f.UserId == userId)
                .Include(f => f.Announcement)
                .ThenInclude(a => a.Car) 
                .ToListAsync();

            var favoriteViewModels = favorites.Select(f => new FavoriteViewModel
            {
                Id = f.Announcement.Id,
                CarMake = f.Announcement.Car?.Make,
                CarModel = f.Announcement.Car?.Model,
                CarImage = f.Announcement.Car?.CarImages[0], 
                Price = f.Announcement.Price,
                Description = f.Announcement.Description,
                CreatedDate = f.Announcement.CreatedDate
            }).ToList();

            return favoriteViewModels;
        }
        public async Task<bool> IsFavoriteAsync(string userId, int announcementId)
        { 
            var favorite = _repository.All<UserFavoriteAnnouncement>()
                .FirstOrDefault(f => f.UserId == userId && f.AnnouncementId == announcementId);

            return favorite != null;
        }
        public async Task<bool> RemoveFromFavoritesAsync(string userId, int announcementId)
        {
            var favorite = await _repository.All<UserFavoriteAnnouncement>()
                                            .FirstOrDefaultAsync(f => f.UserId == userId && f.AnnouncementId == announcementId);

            if (favorite == null) return false;

            _repository.Delete(favorite);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
