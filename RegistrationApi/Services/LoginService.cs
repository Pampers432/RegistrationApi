using RegistrationApi.Models;
using RegistrationApi.Data;

namespace RegistrationApi.Services
{
    public class LoginService
    {
        public static string LoginUser(string email, string password)
        {
            //var user = RegistrationDbContext.Users.First(u => u.email == email && u.password == password);
            if (RegistrationDbContext.Users.First(u => u.email == email && u.password == password) != null)
            {
                return "Успех";
            }
            return "Такого пользователя нет";
        }
    }
}
