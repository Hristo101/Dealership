using Dealership.Core.Models.Announcement;
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
        Task<IEnumerable<AllAnnouncementViewModel>> AllAnnouncementAsync(int page, int pageSize);
        Task<int> GetTotalAnnouncementCountAsync();
        Task<DetailsAnnouncementViewModel> DetailsAnnouncementAsync(int id);
        Task<bool> ExistAsync(int id);
        Task<EditAnnouncementViewModel> GetAnnouncementForEditAsync(int id);
        Task<DeleteAnnouncementViewModel> GetAnnouncementForDeleteAsync(int id);
        Task RemoveAsync(int id);
        Task EditAsync(int id, EditAnnouncementViewModel model);
        Task<IEnumerable<AllAnnouncementViewModel>> GetFilteredAnnouncements(
          string make,
          string year,
          string engine,
          string transmission,
          string color,
          string sortBy,
          int page,
          int pageSize
      );
    }

}
