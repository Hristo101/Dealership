using Dealership.Core.Models;
using Dealership.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Contracts
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<AllAnnouncementViewModel>> AllAnnouncementAsync();
        IEnumerable<AllAnnouncementViewModel> GetPagedAnnouncements(int page, int pageSize);
        Task<DetailsAnnouncementViewModel> DetailsAnnouncementAsync(int id);
        Task<IEnumerable<Announcement>> GetFilteredAnnouncements(string make, string year, string engine, string transmission, string color, string sortBy);
        Task<bool> ExistAsync(int id);
        int GetTotalAnnouncementCount();
    }
}
