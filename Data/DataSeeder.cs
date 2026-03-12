using BlogApi.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogApi.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            
            string[] roles = { "Admin", "User", "Guest" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            //create if no admin
            if (await userManager.FindByNameAsync("admin") == null)
            {
                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@blog.com",
                    Role = Role.Admin
                };

                await userManager.CreateAsync(admin, "admin123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
