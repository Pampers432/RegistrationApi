using Microsoft.EntityFrameworkCore;
using RegistrationApi.Data;
using RegistrationApi.Models;
using RegistrationApi.Repositories;

namespace RegistrationApi.Services

{
    public class RegistrationService
    {
        public static string RegisterUser(string email, string password)
        {
            using (var db = new RegistrationDbContext(new DbContextOptions<RegistrationDbContext>()))
            {
                if (db.Users.Any(u => u.email == email)) return "Пользователь с таким email уже есть";

                UsersRepository.AddUser(email, password);
            }

            return "Успех";
        }
    }
}
