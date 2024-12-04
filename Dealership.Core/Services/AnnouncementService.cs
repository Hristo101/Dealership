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
    public class AnnouncementService : IAnnouncementService
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
                       ImageUrl = x.Car.CarImages[0],
                       Model = x.Car.Model,
                       Make = x.Car.Make,
                       Price = x.Price,
                       HorsePower = x.Car.Horsepower
                   }).ToListAsync();

            return viewModels;
        }
    }
}
