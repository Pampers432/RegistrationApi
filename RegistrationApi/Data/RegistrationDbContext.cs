using Microsoft.EntityFrameworkCore;
using RegistrationApi.Models;

namespace RegistrationApi.Data
{
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options)
        { }

        public static DbSet<User> Users { get; set; }
    }
}
