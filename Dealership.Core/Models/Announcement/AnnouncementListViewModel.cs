using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Announcement
{
    public class AnnouncementListViewModel
    {
        public IEnumerable<AllAnnouncementViewModel> Announcements { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }

}
