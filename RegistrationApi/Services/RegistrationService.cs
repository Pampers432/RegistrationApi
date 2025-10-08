using RegistrationApi.Data;
using RegistrationApi.Models;

namespace RegistrationApi.Services

{
    public class RegistrationService
    {
        public static string RegisterUser(string email, string password)
        {
            if (RegistrationDbContext.Users.First(u => u.email == email) != null) return "Пользователь с таким email уже есть";

            User.CreateUser(0, email, password);
            return "Успех";
        }
    }
}
