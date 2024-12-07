using Dealership.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models
{
    public class FavoriteViewModel
    {
        public int Id { get; set; } // Идентификатор на обявата
        public string CarMake { get; set; } // Марка на колата
        public string CarModel { get; set; } // Модел на колата
        public string CarImage { get; set; } // Първо изображение на колата
        public string Description { get; set; } // Описание на обявата
        public decimal Price { get; set; } // Цена на обявата
        public DateTime CreatedDate { get; set; } // Дата на публикуване
    }

}
