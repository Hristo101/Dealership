using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Announcement
{
    public class AnnouncementEvaluationViewModel
    {
        public int CarId { get; set; }
        public string? Make { get; set; }

        public string? Model { get; set; }

        [Required(ErrorMessage = "Описание е задължително.")]
        [StringLength(1000, ErrorMessage = "Описанието трябва да бъде до 1000 символа.")]
        public string Description { get; set; }

        [StringLength(500, ErrorMessage = "Екстрите за комфорт трябва да бъдат до 500 символа.")]
        public string ExtrasForComfort { get; set; }

        [StringLength(500, ErrorMessage = "Системите за безопасност трябва да бъдат до 500 символа.")]
        public string SecurityExtras { get; set; }

        [Range(0, 1000000, ErrorMessage = "Цената трябва да бъде между 0 и 1,000,000.")]
        public decimal Price { get; set; }

        public string? CarImage { get; set; }
    }
}
