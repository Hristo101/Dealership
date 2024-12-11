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

        // Добавяне на филтри в модела
        public string Make { get; set; }
        public string Year { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public string SortBy { get; set; }
    }

}
