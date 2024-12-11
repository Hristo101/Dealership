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
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstant.Comment.ContentMaxLength, MinimumLength = DataConstant.Comment.ContentMinLength)]
        public string Content { get; set; } = null!;

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Range(DataConstant.Comment.GradeMinValue, DataConstant.Comment.GradeMaxValue)]
        public int Grade { get; set; }
    }

}
