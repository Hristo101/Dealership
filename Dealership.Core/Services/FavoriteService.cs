using Dealership.Infrastructure.Common;
using Dealership.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Services
{
    public class FavoriteService
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

    }
}
