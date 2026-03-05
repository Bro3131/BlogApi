using BlogApi.Models;

namespace BlogApi.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext db)
        {
            // if admin user already exists - skip 
            if (db.Users.Any(u => u.Role == Role.Admin))
                return;

            var admin = new User
            {
                Username = "admin",
                Email = "admin@blog.com",
                Password = "123",
                Role = Role.Admin
            };

            db.Users.Add(admin);
            db.SaveChanges();
        }
    }
}
