using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Dealership.Infrastructure.Common.Constants;

namespace Dealership.Infrastructure.Data.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstant.Announcement.DescriptionMaxLength, MinimumLength = DataConstant.Announcement.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime CreatedDate { get; set; }

        public string ExtrasForComfort { get; set; } = string.Empty;

        public string SecurityExtras { get; set; } = string.Empty;

        [Required]
        [Range(DataConstant.Announcement.PriceMinValue,DataConstant.Announcement.PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string Status { get; set; } = DataConstant.Announcement.DefaultStatus;

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        public ICollection<Query> Queries { get; set; } = new List<Query>();

        public ICollection<UserFavoriteAnnouncement> FavoriteUsers { get; set; } = new List<UserFavoriteAnnouncement>();
    }

}
