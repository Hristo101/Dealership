using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Models
{
    public class Dealership
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        // Релации
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<CarDealership> CarDealerships { get; set; } = new List<CarDealership>();
    }

}
