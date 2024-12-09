using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Car
{
    public class CarViewModel
    {
        [Required(ErrorMessage = "Марка е задължителна.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Марка трябва да е между 2 и 50 символа.")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Модел е задължителен.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Модел трябва да е между 2 и 50 символа.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Цвят е задължителен.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Цвят трябва да е между 2 и 50 символа.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Тип на двигателя е задължителен.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Тип на двигателя трябва да е между 1 и 50 символа.")]
        public string EngineType { get; set; }

        [Required(ErrorMessage = "Тип на скоростите е задължителен.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Тип на скоростите трябва да е между 1 и 50 символа.")]
        public string Speeds { get; set; }

        [Required(ErrorMessage = "Годината е задължителна.")]
        [Range(2002, 9999, ErrorMessage = "Годината трябва да бъде между 1886 и 9999.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Пробегът е задължителен.")]
        [Range(0, int.MaxValue, ErrorMessage = "Пробегът трябва да е положително число.")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Мощността е задължителна.")]
        [Range(0, int.MaxValue, ErrorMessage = "Мощността трябва да е положително число.")]
        public int Horsepower { get; set; }

        [Required(ErrorMessage = "Снимките са задължителни.")]
        [MinLength(4, ErrorMessage = "Трябва да има поне 4 снимки.")]
        public string CarImages { get; set; }


        public string UserId { get; set; }
    }
}

