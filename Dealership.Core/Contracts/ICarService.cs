﻿using Dealership.Core.Models.Car;
using Dealership.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Contracts
{
    public interface ICarService
    {
        Task AddCarAsync(CarViewModel carViewModel);
        Task <IEnumerable<AddCarViewModel>> GetAllCarsAsync();
    }
}
