using Dealership.Core.Contracts;
using Dealership.Core.Models;
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
    string make, string year, string engine, string transmission, string color, string sortBy)
        {
            // Строим запитването с филтрите
            var query = repository.All<Announcement>()
                .Include(a => a.Car) // Зареждаме свързаната кола
                .Where(a => a.Car != null); // Проверка за null стойности на Car

            // Филтрираме по марка, ако е зададена
            if (!string.IsNullOrEmpty(make))
            {
                query = query.Where(a => a.Car.Make == make);
            }

            // Филтрираме по година, ако е зададена
            if (!string.IsNullOrEmpty(year) && int.TryParse(year, out var parsedYear))
            {
                query = query.Where(a => a.Car.Year == parsedYear);
            }

            // Филтрираме по тип на двигателя, ако е зададен
            if (!string.IsNullOrEmpty(engine))
            {
                query = query.Where(a => a.Car.EngineType == engine);
            }

            // Филтрираме по тип на скоростите, ако е зададен
            if (!string.IsNullOrEmpty(transmission))
            {
                query = query.Where(a => a.Car.Speeds == transmission);
            }

            // Филтрираме по цвят, ако е зададен
            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(a => a.Car.Color == color);
            }

            // Приложение на сортирането
            switch (sortBy)
            {
                case "year-asc":
                    query = query.OrderBy(a => a.Car.Year);
                    break;
                case "year-desc":
                    query = query.OrderByDescending(a => a.Car.Year);
                    break;
                case "price-asc":
                    query = query.OrderBy(a => a.Price);
                    break;
                case "price-desc":
                    query = query.OrderByDescending(a => a.Price);
                    break;
                default:
                    break;
            }

            // Извличане на резултатите от базата данни
            var searchResults = await query.ToListAsync();

            // Връщаме резултатите като модели
            return searchResults.Select(a => new AllAnnouncementViewModel
            {
                Id = a.Id,
                ImageUrl = a.Car.CarImages[0], 
                Model = a.Car.Model,
                Make = a.Car.Make,
                HorsePower = a.Car.Horsepower,
                Price = a.Price
            }).ToList();
        }
    }
}
