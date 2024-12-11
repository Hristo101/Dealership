using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Infrastructure.Common.Constants;

namespace Dealership.Infrastructure.Data.Models
{
    public class Query
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstant.Query.MessageMaxLength, MinimumLength = DataConstant.Query.MessageMinLength)]
        public string Message { get; set; } = null!;

        [StringLength(DataConstant.Query.AdminResponseMaxLength)]
        public string AdminResponse { get; set; } = string.Empty;

        public bool IsAnswered { get; set; }

        [Required]
        public int AnnouncementId { get; set; }

        [ForeignKey(nameof(AnnouncementId))]
        public Announcement Announcement { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
