using Dealership.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Infrastructure.Data.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(SeedCar());
        }
        private List<Car> SeedCar()
        {
            List<Car> cars = new List<Car>();

            Car car;

            car = new Car()
            {
                Id = 1,
                Make = "Audi",
                Model = "Rs7",
                Color = "Сив",
                EngineType = "Дизелов",
                Speeds = "Автоматик",
                Year = 2014,
                Mileage = 120000,
                Horsepower = 720,
                CarImages = new List<string> { "~/img/Cars/AudiRs7/Screenshot 2024-12-03 211138.png", "~/img/Cars/AudiRs7/Screenshot 2024-12-03 211219.png", "~/img/Cars/AudiRs7/Screenshot 2024-12-03 211310.png", "~/img/Cars/AudiRs7/Screenshot 2024-12-03 211403.png", "~/img/Cars/AudiRs7/Screenshot 2024-12-03 211429.png", "~/img/Cars/AudiRs7/Screenshot 2024-12-03 211504.png", "~/img/Cars/AudiRs7/Screenshot 2024-12-03 211528.png", "~/img/Cars/AudiRs7/Screenshot 2024-12-03 211604.png" }
            };
            cars.Add(car);



            return cars;
        }
    }
}
