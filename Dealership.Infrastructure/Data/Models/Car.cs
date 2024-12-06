using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(50, MinimumLength = 2)]
        public string Make { get; set; } = null!;
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Color { get; set; } = null!;
        [Required]
        public int Mileage { get; set; }
        [Required]
        public int Horsepower { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Model { get; set; } = null!;
        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string EngineType { get; set; } = null!;
        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string Speeds { get; set; } = null!;
        [Required]
        [Range(1886, 9999)] 
        public int Year { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Трябва да има поне 4 снимки.")]
        public List<string> CarImages { get; set; } = new List<string>();

        public ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
    }

}
