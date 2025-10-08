using Microsoft.EntityFrameworkCore;
using RegistrationApi.Models;

namespace RegistrationApi.Data
{
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RegistrationDb;Trusted_Connection=True;");
            }
        }

        public DbSet<User> Users { get; set; }
    }
}
