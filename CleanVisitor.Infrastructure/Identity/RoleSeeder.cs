using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public class RoleSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        string[] roles = ["Admin", "Manager", "Receptionist", "Security"];

        foreach (var role in roles)
        {
            if(!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}