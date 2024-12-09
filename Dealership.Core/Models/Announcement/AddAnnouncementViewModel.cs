using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Core.Models.Car;
using Dealership.Infrastructure.Data.Models;
namespace Dealership.Core.Models.Announcement
{
    public class AddAnnouncementViewModel
    {
        public int Id { get; set; } 
        public string Description { get; set; } 
        public string ExtrasForComfort { get; set; }
        public string SecurityExtras { get; set; } 
        public decimal Price { get; set; } 
        public string Status { get; set; } = "Approved"; 

        public int CarId { get; set; } 
        public List<AddCarViewModel> Cars { get; set; } 

    }
}
