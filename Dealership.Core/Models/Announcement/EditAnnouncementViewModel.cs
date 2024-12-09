using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Announcement
{
    public class EditAnnouncementViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ExtrasForComfort { get; set; }
        public string SecurityExtras { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
