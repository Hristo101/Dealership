﻿
using Microsoft.AspNetCore.Identity;

namespace Dealership.Extensions
{
    //public class ApplicationBuilderExtension
    //{
    //    public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
    //    {
    //        using var scope = app.ApplicationServices.CreateScope();
    //        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    //        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    //        if (roleManager != null && userManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
    //        {
    //            var role = new IdentityRole(AdminRole);

    //            await roleManager.CreateAsync(role);

    //            var admin = await userManager.FindByEmailAsync("stanislav@abv.bg");

    //            if (admin != null)
    //            {
    //                await userManager.AddToRoleAsync(admin, role.Name);
    //            }
    //        }

    //    }
    //}
}
