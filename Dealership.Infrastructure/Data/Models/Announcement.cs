using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dealership.Infrastructure.Data.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public string ExtrasForComfort { get; set; }
        public string SecurityExtras { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Status { get; set; } = "Approved";


        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }

        public ICollection<Query> Queries { get; set; } = new List<Query>();
        public ICollection<UserFavoriteAnnouncement> FavoriteUsers { get; set; } = new List<UserFavoriteAnnouncement>();
    }

}
