using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Core.Models.Car;
using Dealership.Infrastructure.Data.Models;
using static Dealership.Infrastructure.Common.Constants.DataConstant.Announcement;
namespace Dealership.Core.Models.Announcement
{
    public class AddAnnouncementViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Описание е задължително.")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Описанието трябва да бъде между 1 и 1000 символа.")]
        public string Description { get; set; }

        [StringLength(DescriptionMaxLength, ErrorMessage = "Екстрите за комфорт не трябва да надвишават 1000 символа.")]
        public string ExtrasForComfort { get; set; }

        [StringLength(DescriptionMaxLength, ErrorMessage = "Екстрите за сигурност не трябва да надвишават 1000 символа.")]
        public string SecurityExtras { get; set; }

        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = "Цената трябва да бъде между 0.01 и 1,000,000.")]
        public decimal Price { get; set; }
        public string Status { get; set; } = "Approved"; 

        public int CarId { get; set; } 
        public List<AddCarViewModel>? Cars { get; set; } 

    }
}
