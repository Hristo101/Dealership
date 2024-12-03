using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Data.Models
{
    public class Comment
    {

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Content { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey("Dealership")]
        public int DealershipId { get; set; }
        public Dealership Dealership { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int Grade { get; set; }
    }

}
