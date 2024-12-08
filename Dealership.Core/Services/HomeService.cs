using Dealership.Core.Contracts;
using Dealership.Core.Models;
using Dealership.Core.Models.Home;
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
    public class HomeService : IHomeService
    {
        private readonly IRepository _repository;

        public HomeService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HomeCarViewModel>> GetCarsForHomePageAsync()
        {
            var cars = await _repository.AllAsReadOnly<Car>()
                                         .Take(5)
                                         .Select(c => new HomeCarViewModel
                                         {
                                             Make = c.Make,
                                             Model = c.Model,
                                             CarImage = c.CarImages[0],
                                         })
                                         .ToListAsync();

            return cars;
        }
    }
}
