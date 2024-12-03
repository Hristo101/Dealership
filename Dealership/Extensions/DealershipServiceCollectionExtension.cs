using Dealership.Infrastructure.Common;
using Dealership.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dealership.Extensions
{
    public static class DealershipServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IFitnessCardService, FitnessCardService>();
            //services.AddScoped<IDietService, DietService>();
            //services.AddScoped<IWorkoutPlanService, WorkoutPlanService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<CarDealershipContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IRepository, Repository>();

            return services;
        }


        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {

            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CarDealershipContext>();

            return services;

        }
    }
}
