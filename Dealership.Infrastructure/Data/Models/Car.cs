using Dealership.Infrastructure.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstant.Car.MakeMaxLength, MinimumLength = DataConstant.Car.MakeMinLength)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(DataConstant.Car.ModelMaxLength, MinimumLength = DataConstant.Car.ModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(DataConstant.Car.ColorMaxLength, MinimumLength = DataConstant.Car.ColorMinLength)]
        public string Color { get; set; } = null!;

        [Required]
        public int Mileage { get; set; }

        [Required]
        public int Horsepower { get; set; }

        [Required]
        [StringLength(DataConstant.Car.EngineTypeMaxLength, MinimumLength = DataConstant.Car.EngineTypeMinLength)]
        public string EngineType { get; set; } = null!;

        [Required]
        [StringLength(DataConstant.Car.SpeedsMaxLength, MinimumLength = DataConstant.Car.SpeedsMinLength)]
        public string Speeds { get; set; } = null!;

        public bool IsInAnnouncement { get; set; } = false;

        [Required]
        [Range(DataConstant.Car.YearMinValue, DataConstant.Car.YearMaxValue)]
        public int Year { get; set; }

        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        [Required]
        [MinLength(DataConstant.Car.MinCarImagesCount, ErrorMessage = "Трябва да има поне 4 снимки.")]
        public List<string> CarImages { get; set; } = new List<string>();

        public ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
    }

}
