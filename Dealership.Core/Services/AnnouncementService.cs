using Dealership.Core.Contracts;
using Dealership.Core.Models.Announcement;
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
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepository repository;

        public AnnouncementService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<AllAnnouncementViewModel>> AllAnnouncementAsync(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;

            var announcements = await repository.AllAsReadOnly<Announcement>()
                .Skip(skip)
                .Take(pageSize)
                .Select(x => new AllAnnouncementViewModel()
                {
                    Id = x.Id,
                    ImageUrl = x.Car.CarImages[0],
                    Model = x.Car.Model,
                    Make = x.Car.Make,
                    Price = x.Price,
                    HorsePower = x.Car.Horsepower
                })
                .ToListAsync();

            return announcements;
        }

        public async Task<bool> ExistAsync(int id)
        {
                return await repository.AllAsReadOnly<Announcement>()
                    .AnyAsync(x => x.Id == id);
        }

        public async Task<int> GetTotalAnnouncementCountAsync()
        {
            return await repository.AllAsReadOnly<Announcement>().CountAsync();
        }
        public async Task<DetailsAnnouncementViewModel> DetailsAnnouncementAsync(int id)
        {
            var recentAnnouncements = await repository.AllAsReadOnly<Announcement>()
           .Where(a => a.Id != id) 
           .OrderByDescending(a => a.CreatedDate) 
           .Take(3) 
           .Select(a => new AllAnnouncementViewModel
           {
               Id = a.Id,
               ImageUrl = a.Car.CarImages.FirstOrDefault() ?? "~/images/default.jpg",
               Make = a.Car.Make,
               Model = a.Car.Model,
               HorsePower = a.Car.Horsepower,
               Price = a.Price
           })
           .ToListAsync();

            var announcement = await repository.AllAsReadOnly<Announcement>()
              .Where(x => x.Id == id)
              .Select(x => new DetailsAnnouncementViewModel()
              {
                Id = x.Id,
                DataCreated = DateTime.Now,
                Model = x.Car.Model,
                Price = x.Price,
                Make = x.Car.Make,
                HorsePower = x.Car.Horsepower,
                Color = x.Car.Color,
                Speeds = x.Car.Speeds,
                Year = x.Car.Year,
                Mileage = x.Car.Mileage,
                EngineType = x.Car.EngineType,
                Description = x.Description,
                SecurityExtras = x.SecurityExtras,
                ExtrasForComfort = x.ExtrasForComfort,
                ImageUrls = x.Car.CarImages,
                RecentAnnouncements = recentAnnouncements
                
              }).FirstAsync();

            return announcement;
        }
        public async Task<IEnumerable<AllAnnouncementViewModel>> GetFilteredAnnouncements(
             string make,
             string year,
             string engine,
             string transmission,
             string color,
             string sortBy,
             int page,
             int pageSize
         )
        {
            var query = repository.AllAsReadOnly<Announcement>();

            // Филтри
            if (!string.IsNullOrWhiteSpace(make))
            {
                query = query.Where(x => x.Car.Make == make);
            }

            if (!string.IsNullOrWhiteSpace(year) && int.TryParse(year, out int parsedYear))
            {
                query = query.Where(x => x.Car.Year == parsedYear);
            }

            if (!string.IsNullOrWhiteSpace(engine))
            {
                query = query.Where(x => x.Car.EngineType == engine);
            }

            if (!string.IsNullOrWhiteSpace(transmission))
            {
                query = query.Where(x => x.Car.Speeds == transmission);
            }

            if (!string.IsNullOrWhiteSpace(color))
            {
                query = query.Where(x => x.Car.Color == color);
            }

 
            switch (sortBy)
            {
                case "year-asc":
                    query = query.OrderBy(x => x.Car.Year);
                    break;
                case "year-desc":
                    query = query.OrderByDescending(x => x.Car.Year);
                    break;
                case "price-asc":
                    query = query.OrderBy(x => x.Price);
                    break;
                case "price-desc":
                    query = query.OrderByDescending(x => x.Price);
                    break;
            }

            var skip = (page - 1) * pageSize;
            var announcements = await query
                .Skip(skip)
                .Take(pageSize)
                .Select(x => new AllAnnouncementViewModel()
                {
                    Id = x.Id,
                    ImageUrl = x.Car.CarImages[0],
                    Model = x.Car.Model,
                    Make = x.Car.Make,
                    Price = x.Price,
                    HorsePower = x.Car.Horsepower
                })
                .ToListAsync();

            return announcements;
        }

        public async Task<EditAnnouncementViewModel> GetAnnouncementForEditAsync(int id)
        {
            var announcement = await repository.AllAsReadOnly<Announcement>()
               .Where(x => x.Id == id)
               .Select(x => new EditAnnouncementViewModel()
               {
                 Id = x.Id,
                 ExtrasForComfort = x.ExtrasForComfort,
                 SecurityExtras = x.SecurityExtras,
                 CreatedDate = x.CreatedDate,
                  Description = x.Description,
                  Price = (int)x.Price,
               })
               .FirstAsync();

            return announcement;
        }

        public async Task EditAsync(int id, EditAnnouncementViewModel model)
        {
            var announcement = await repository.GetByIdAsync<Announcement>(id);

            if (announcement != null)
            {
                announcement.ExtrasForComfort = model.ExtrasForComfort;
                announcement.SecurityExtras = model.SecurityExtras;
                announcement.CreatedDate = model.CreatedDate;
                announcement.Description = model.Description;
                announcement.Price = model.Price;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<DeleteAnnouncementViewModel> GetAnnouncementForDeleteAsync(int id)
        {
            var announcement = await repository.AllAsReadOnly<Announcement>()
             .Where(x => x.Id == id)
             .Select(x => new DeleteAnnouncementViewModel()
             {
                 Id = x.Id,
                 Description = x.Description,
                 CreatedDate = x.CreatedDate,
                 Price= (int)x.Price,
                 ImageUrl = x.Car.CarImages[0]
             })
             .FirstAsync();

            return announcement;
        }
        public async Task RemoveAsync(int id)
        {
            var announcement = await repository.GetByIdAsync<Announcement>(id);
            var car = await repository.GetByIdAsync<Car>(announcement.CarId);
            if (announcement != null)
            {
                car.IsInAnnouncement = false;
                repository.Delete<Announcement>(announcement);
                await repository.SaveChangesAsync();
            }

        }

        public async Task AddAsync(AddAnnouncementViewModel model, string userId)
        {

            Announcement diet = new Announcement()
                {
                  Description = model.Description,
                  ExtrasForComfort = model.ExtrasForComfort,
                  CreatedDate = DateTime.Now,
                  CarId = model.CarId,
                  Price = model.Price,
                  Id = model.Id,
                  SecurityExtras = model.SecurityExtras,
                };

                await repository.AddAsync(diet);
                await repository.SaveChangesAsync();
         
        }
    }
}
