using Microsoft.EntityFrameworkCore;
using RegistrationApi.Data;
using RegistrationApi.Models;

namespace RegistrationApi.Repositories
{
    public class UsersRepository
    {
        public static void AddUser(User user)
        {

            using (var db = new RegistrationDbContext(new DbContextOptions<RegistrationDbContext>()))
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
