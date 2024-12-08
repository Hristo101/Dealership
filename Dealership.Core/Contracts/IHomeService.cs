using Dealership.Core.Models;
using Dealership.Core.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Contracts
{
    public interface IHomeService
    {
        Task<IEnumerable<HomeCarViewModel>> GetCarsForHomePageAsync();
    }
}
