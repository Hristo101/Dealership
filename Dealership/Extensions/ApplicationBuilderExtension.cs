
using Dealership.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static Dealership.Core.Constants.RoleConstants;
namespace Dealership.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (roleManager != null && userManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
            {
                var role = new IdentityRole(AdminRole);

                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync("hserev789@gmail.com");

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, role.Name);
                }
            }

        }
    }
}
