using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Car
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string EngineType { get; set; }
        public string Speeds { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int Horsepower { get; set; }
        public List<string> CarImages { get; set; }
    }
}
