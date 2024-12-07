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
    public class CarService :ICarService
    {
        private readonly IRepository repository;

        public CarService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddCarAsync(CarViewModel carViewModel)
        {
            if (string.IsNullOrWhiteSpace(carViewModel.CarImages))
            {
                throw new InvalidOperationException("Трябва да има поне една снимка.");
            }

            var carImagesList = carViewModel.CarImages
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(imageUrl => imageUrl.Trim())
                .ToList();

            var car = new Car
            {
                Make = carViewModel.Make,
                Model = carViewModel.Model,
                Color = carViewModel.Color,
                EngineType = carViewModel.EngineType,
                Speeds = carViewModel.Speeds,
                Year = carViewModel.Year,
                Mileage = carViewModel.Mileage,
                Horsepower = carViewModel.Horsepower,
                CarImages = carImagesList,
                UserId = carViewModel.UserId
            };


            await repository.AddAsync(car);
            await repository.SaveChangesAsync();
        }
        public async Task<IEnumerable<Car>> GetFilteredCars(string make, string year, string engine, string transmission, string color, string sortBy)
        {
            var query = repository.All<Car>().AsQueryable();

            // Приложение на филтрите
            if (!string.IsNullOrEmpty(make))
            {
                query = query.Where(c => c.Make == make);
            }

            if (!string.IsNullOrEmpty(year))
            {
                if (int.TryParse(year, out var parsedYear))
                {
                    query = query.Where(c => c.Year == parsedYear);
                }
            }

            if (!string.IsNullOrEmpty(engine))
            {
                query = query.Where(c => c.Engine == engine);
            }

            if (!string.IsNullOrEmpty(transmission))
            {
                query = query.Where(c => c.Transmission == transmission);
            }

            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(c => c.Color == color);
            }

            switch (sortBy)
            {
                case "year-asc":
                    query = query.OrderBy(c => c.Year);
                    break;
                case "year-desc":
                    query = query.OrderByDescending(c => c.Year);
                    break;
                case "price-asc":
                    query = query.OrderBy(c => c.);
                    break;
                case "price-desc":
                    query = query.OrderByDescending(c => c.Price);
                    break;
                default:
                    break;
            }

            return await query.ToListAsync();
        }
    }
}
}

