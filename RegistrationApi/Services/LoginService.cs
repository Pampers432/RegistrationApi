using Microsoft.EntityFrameworkCore;
using RegistrationApi.Data;
using RegistrationApi.Models;

namespace RegistrationApi.Services
{
    public class LoginService
    {
        public static string LoginUser(string email, string password)
        {
            using (var db = new RegistrationDbContext(new DbContextOptions<RegistrationDbContext>()))
            {
                if (db.Users.Any(u => u.email == email && u.password == password))
                {
                    return "Успех";
                }
            }
            return "Такого пользователя нет";
        }
    }
}
