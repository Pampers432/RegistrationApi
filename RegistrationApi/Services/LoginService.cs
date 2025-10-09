using Microsoft.EntityFrameworkCore;
using RegistrationApi.Contracts;
using RegistrationApi.Data;
using RegistrationApi.Models;

namespace RegistrationApi.Services
{
    public class LoginService
    {
        public static UserResponse LoginUser(User user)
        {
            using (var db = new RegistrationDbContext(new DbContextOptions<RegistrationDbContext>()))
            {
                if (db.Users.Any(u => u.email == user.email && u.password == user.password))
                {
                    UserResponse userResponse = new UserResponse (user.email, user.password, "JWT");
                    return userResponse;
                }
            }
            throw new Exception("Такого пользователя нет"); // Возможно выкидывать exception
        }
    }
}
