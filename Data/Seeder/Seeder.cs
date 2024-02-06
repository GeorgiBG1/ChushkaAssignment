using Microsoft.AspNetCore.Identity;

namespace ChushkaAssignment.Data.Seeder
{
    public class Seeder : ISeeder
    {
        private readonly ApplicationDbContext db;

        public Seeder(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Seed()
        {
            if (!db.Roles.Any())
            {
                db.Roles.Add(new IdentityRole("User"));
                db.Roles.Add(new IdentityRole("Admin"));
            }
        }
    }
}
