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
        Task AddAsync(AddAnnouncementViewModel model);
        Task<DeleteAnnouncementViewModel> GetAnnouncementForDeleteAsync(int id);
        Task RemoveAsync(int id);
        Task EditAsync(int id, EditAnnouncementViewModel model);
        Task EvaluationAsync(int id, AnnouncementEvaluationViewModel model);
        Task<AnnouncementEvaluationViewModel> GetModelForAnnouncment(int carId);
        Task<AnnouncementListViewModel> GetFilteredAnnouncements(
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
