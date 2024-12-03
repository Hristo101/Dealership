using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Data.Models
{
    public class Query
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public string AdminResponse { get; set; }

        public bool IsAnswered { get; set; }


        [Required]
        public int AnnouncementId { get; set; }
        [ForeignKey(nameof(AnnouncementId))]
        public Announcement Announcement { get; set; }


        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public DateTime CreatedAt { get; set; }  // Дата на създаване на запитването
    }

}
