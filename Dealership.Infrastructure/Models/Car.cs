using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Make { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Model { get; set; }

        [Required]
        [Range(1886, 9999)] // Автомобили след 1886
        public int Year { get; set; }

        [Required]
        [Range(0, 1_000_000)]
        public decimal Price { get; set; }

        // Релации
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public ICollection<UserCar> UserCars { get; set; } = new List<UserCar>();
        public ICollection<CarDealership> CarDealerships { get; set; } = new List<CarDealership>();
    }

}
