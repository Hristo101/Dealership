using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Announcement
{
    public class DetailsAnnouncementViewModel
    {
        public int Id { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public string Model { get; set; }
        public string Make { get; set; }
        public int HorsePower { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string EngineType { get; set; }
        public string Speeds { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string ExtrasForComfort { get; set; }
        public string SecurityExtras { get; set; }
        public DateTime DataCreated { get; set; }
        public List<AllAnnouncementViewModel> RecentAnnouncements { get; set; } = new List<AllAnnouncementViewModel>();
    }
}
