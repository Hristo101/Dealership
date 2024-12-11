using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dealership.Infrastructure.Common.Constants.DataConstant.Car;

namespace Dealership.Core.Models.Car
{
    public class CarViewModel
    {
            public int Id { get; set; }

            [Required(ErrorMessage = "Марка е задължителна.")]
            [StringLength(MakeMaxLength, MinimumLength = MakeMinLength, ErrorMessage = "Марка трябва да е между 2 и 50 символа.")]
            public string Make { get; set; }

            [Required(ErrorMessage = "Модел е задължителен.")]
            [StringLength(ModelMaxLength, MinimumLength = ModelMinLength, ErrorMessage = "Модел трябва да е между 2 и 50 символа.")]
            public string Model { get; set; }

            [Required(ErrorMessage = "Цвят е задължителен.")]
            [StringLength(ColorMaxLength, MinimumLength = ColorMinLength, ErrorMessage = "Цвят трябва да е между 2 и 50 символа.")]
            public string Color { get; set; }

            [Required(ErrorMessage = "Тип на двигателя е задължителен.")]
            [StringLength(EngineTypeMaxLength, MinimumLength = EngineTypeMinLength, ErrorMessage = "Тип на двигателя трябва да е между 1 и 250 символа.")]
            public string EngineType { get; set; }

            [Required(ErrorMessage = "Тип на скоростите е задължителен.")]
            [StringLength(SpeedsMaxLength, MinimumLength = SpeedsMinLength, ErrorMessage = "Тип на скоростите трябва да е между 1 и 250 символа.")]
            public string Speeds { get; set; }

            [Required(ErrorMessage = "Годината е задължителна.")]
            [Range(YearMinValue, YearMaxValue, ErrorMessage = "Годината трябва да бъде между 1886 и 9999.")]
            public int Year { get; set; }

            [Required(ErrorMessage = "Пробегът е задължителен.")]
            [Range(0, int.MaxValue, ErrorMessage = "Пробегът трябва да е положително число.")]
            public int Mileage { get; set; }

            [Required(ErrorMessage = "Мощността е задължителна.")]
            [Range(0, int.MaxValue, ErrorMessage = "Мощността трябва да е положително число.")]
            public int Horsepower { get; set; }

            public string CarImages { get; set; } 
            public string UserId { get; set; }
    }
    
}

