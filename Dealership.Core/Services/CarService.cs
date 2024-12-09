using Dealership.Core.Contracts;
using Dealership.Core.Models.Car;
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
    public class CarService : ICarService
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

        public async Task<IEnumerable<AddCarViewModel>> GetAllCarsAsync()
        {
           var cars =await repository.AllAsReadOnly<Car>()
                .Where(c => c.IsInAnnouncement == false)
                .Select(c => new AddCarViewModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    Id = c.Id,
                })
                .ToListAsync();

            return cars;
        }
    }
}


