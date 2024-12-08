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

            car = new Car()
            {
                Id = 2,
                Make = "Toyota",
                Model = "Tacoma 3.5 V6",
                Color = "Жълт",
                EngineType = "Бензинов",
                Speeds = "Автоматик",
                Year = 2018,
                Mileage = 61000,
                Horsepower =278,
                CarImages = new List<string> { "~/img/Cars/Toyota/Capture6.PNG", "~/img/Cars/Toyota/Capture.PNG", "~/img/Cars/Toyota/Capture3.PNG", "~/img/Cars/Toyota/Capture4.PNG", "~/img/Cars/Toyota/Capture5.PNG", "~/img/Cars/Toyota/Capture2.PNG", "~/img/Cars/Toyota/Capture7.PNG", "~/img/Cars/Toyota/Capture8.PNG" }
            };

            cars.Add(car);

            car = new Car()
            {
                Id = 3,
                Make = "Mercedes-Benz",
                Model = "S 350",
                Color = "Черен",
                EngineType = "Дизелов",
                Speeds = "Автоматик",
                Year = 2021,
                Mileage = 120000,
                Horsepower = 286,
                CarImages = new List<string> { "~/img/Cars/Mercedes/MercedesCapture3.PNG", "~/img/Cars/Mercedes/MercedesCapture4.PNG", "~/img/Cars/Mercedes/MercedesCapture5.PNG", "~/img/Cars/Mercedes/MercedesCapture6.PNG", "~/img/Cars/Mercedes/MercedesCapture7.PNG", "~/img/Cars/Mercedes/MercedesCapture8.PNG", "~/img/Cars/Mercedes/MercedesCapture1.PNG", "~/img/Cars/Mercedes/MercedesCapture2.PNG" }
            };

            cars.Add(car);

            car = new Car()
            {
                Id = 4,
                Make = "Mercedes-Benz",
                Model = "E 250",
                Color = "Бял",
                EngineType = "Дизелов",
                Speeds = "Автоматик",
                Year = 2017,
                Mileage = 115000,
                Horsepower = 204,
                CarImages = new List<string> { "~/img/Cars/MercedesEClass/MercedesEClassPicture1.png", "~/img/Cars/MercedesEClass/MercedesEClassPicture2.png", "~/img/Cars/MercedesEClass/MercedesEClassPicture3.png", "~/img/Cars/MercedesEClass/MercedesEClassPicture4.png", "~/img/Cars/MercedesEClass/MercedesEClassPicture5.png", "~/img/Cars/MercedesEClass/MercedesEClassPicture6.png", "~/img/Cars/MercedesEClass/MercedesEClassPicture7.png", "~/img/Cars/MercedesEClass/MercedesEClassPicture8.png", "~/img/Cars/MercedesEClass/MercedesEClassPicture9.png", "~/img/Cars/MercedesEClass/MercedesEClassPicture10.png" }
            };

            cars.Add(car);

            car = new Car()
            {
                Id = 5,
                Make = "Volkswagen",
                Model = "Passat",
                Color = "Сив",
                EngineType = "Дизелов",
                Speeds = "Ръчни",
                Year = 2012,
                Mileage = 224000,
                Horsepower = 140,
                CarImages = new List<string> { "~/img/Cars/Volkswagen/VKPicture1.png", "~/img/Cars/Volkswagen/VKPicture2.png", "~/img/Cars/Volkswagen/VKPicture3.png", "~/img/Cars/Volkswagen/VKPicture4.png", "~/img/Cars/Volkswagen/VKPicture5.png", "~/img/Cars/Volkswagen/VKPicture6.png", "~/img/Cars/Volkswagen/VKPicture7.png", "~/img/Cars/Volkswagen/VKPicture8.png" }
            };

            cars.Add(car);

            car = new Car()
            {
                Id = 6,
                Make = "BMW",
                Model = "X6 3.0d",
                Color = "Черен",
                EngineType = "Дизелов",
                Speeds = "Автоматик",
                Year = 2021,
                Mileage = 129000,
                Horsepower = 286,
                CarImages = new List<string> { "~/img/Cars/BMV/BMVPicture1.png", "~/img/Cars/BMV/BMWPicture2.png", "~/img/Cars/BMV/BMWPicture3.png", "~/img/Cars/BMV/BMVPicture4.png", "~/img/Cars/BMV/BMWPicture5.png", "~/img/Cars/BMV/BMWPicture6.png", "~/img/Cars/BMV/BMVPicture7.png", "~/img/Cars/BMV/BMWPicture8.png" }
            };

            cars.Add(car);

            car = new Car()
            {
                Id = 7,
                Make = "Audi",
                Model = "A7 50 TDI",
                Color = "Черен",
                EngineType = "Дизелов",
                Speeds = "Автоматик",
                Year = 2024,
                Mileage = 5000,
                Horsepower = 286,
                CarImages = new List<string> { "~/img/Cars/AudiA7/AudiA7Picture1.png", "~/img/Cars/AudiA7/AudiA7Picture2.png", "~/img/Cars/AudiA7/AudiA7Picture3.png", "~/img/Cars/AudiA7/AudiA7Picture4.png", "~/img/Cars/AudiA7/AudiA7Picture5.png"}
            };

            cars.Add(car);

            return cars;
        }
    }
}
