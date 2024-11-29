using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dealership.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        // Релации
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<UserCar> UserCars { get; set; } = new List<UserCar>();
    }

}
