using RegistrationApi.Data;
using RegistrationApi.Models;
using RegistrationApi.Repositories;

namespace RegistrationApi.Services

{
    public class RegistrationService
    {
        public static string RegisterUser(string email, string password)
        {
            if (RegistrationDbContext.Users.First(u => u.email == email) != null) return "Пользователь с таким email уже есть";

            UsersRepository.AddUser(email, password);
            return "Успех";
        }
    }
}
