using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Car
{
    public class AllCarsForEvaluation
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Model { get; set; }
        public string Make { get; set; }
        public int HorsePower { get; set; }
    }
}
