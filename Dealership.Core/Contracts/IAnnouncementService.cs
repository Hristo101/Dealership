using Dealership.Core.Models;
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
        Task<bool> ExistAsync(int id);
        int GetTotalAnnouncementCount();
    }
}
