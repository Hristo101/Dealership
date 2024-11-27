using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Models
{
    public class CarDealership
    {
        [Required]
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        [ForeignKey("Dealership")]
        public int DealershipId { get; set; }
        public Dealership Dealership { get; set; }
    }

}
