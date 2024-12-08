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
    public class AnnouncementService :IAnnouncementService
    {
        private readonly IRepository repository;

        public AnnouncementService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<AllAnnouncementViewModel>> AllAnnouncementAsync()
        {
            var viewModels = await repository.AllAsReadOnly<Announcement>()
                   .Select(x => new AllAnnouncementViewModel()
                   {
                       Id = x.Id,
                       ImageUrl = x.Car.CarImages[0],
                       Model = x.Car.Model,
                       Make = x.Car.Make,
                       Price = x.Price,
                       HorsePower = x.Car.Horsepower
                   }).ToListAsync();

            return viewModels;
        }

        public async Task<bool> ExistAsync(int id)
        {
                return await repository.AllAsReadOnly<Announcement>()
                    .AnyAsync(x => x.Id == id);
        }

        public IEnumerable<AllAnnouncementViewModel> GetPagedAnnouncements(int page, int pageSize)
        {
            var announcementsQuery = repository.All<Announcement>() 
                .Select(a => new AllAnnouncementViewModel
                {
                    Id = a.Id,
                    Make = a.Car.Make,
                    Model = a.Car.Model,
                    Price = a.Price,
                    HorsePower = a.Car.Horsepower,
                    ImageUrl = a.Car.CarImages[0]
                });

            var pagedAnnouncements = announcementsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

        return pagedAnnouncements.ToList();
        }

        public int GetTotalAnnouncementCount()
        {
            return repository.All<Announcement>().Count();
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
       string sortBy
   )
        {
            var query = repository.AllAsReadOnly<Announcement>();

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

            var viewModels = await query
                .Select(x => new AllAnnouncementViewModel()
                {
                    Id = x.Id,
                    ImageUrl = x.Car.CarImages.FirstOrDefault() ?? "~/images/default.jpg",
                    Model = x.Car.Model,
                    Make = x.Car.Make,
                    Price = x.Price,
                    HorsePower = x.Car.Horsepower
                }).ToListAsync();

            return viewModels;
        }

    }
}
