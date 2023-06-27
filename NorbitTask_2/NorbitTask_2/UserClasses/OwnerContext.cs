using Microsoft.EntityFrameworkCore;
namespace NorbitTask_2.UserClasses
{
    public class OwnerContext : DbContext
    {
        public DbSet<Owner> Owners => Set<Owner>();
        public OwnerContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=user_db;User Id=postgres;Password=password;");
        }
    }
}
