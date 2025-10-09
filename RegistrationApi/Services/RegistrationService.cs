using Microsoft.EntityFrameworkCore;
using RegistrationApi.Data;
using RegistrationApi.Models;
using RegistrationApi.Repositories;

namespace RegistrationApi.Services

{
    public class RegistrationService
    {
        public static string RegisterUser(User user)
        {
            using (var db = new RegistrationDbContext(new DbContextOptions<RegistrationDbContext>()))
            {
                if (db.Users.Any(u => u.email == user.email)) return "Пользователь с таким email уже есть";

                UsersRepository.AddUser(user);
            }

            return "Успех";
        }
    }
}
