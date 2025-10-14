using Microsoft.EntityFrameworkCore;
using RegistrationApi.Contracts;
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

        public static List<User> GetUsers()
        {
            using var db = new RegistrationDbContext(new DbContextOptions<RegistrationDbContext>());
            return db.Users.ToList();
        }

        public static string UpdateUserPassword(UserUpdateRequest user)
        {

            using (var db = new RegistrationDbContext(new DbContextOptions<RegistrationDbContext>()))
            {
                var existingUser = db.Users.FirstOrDefault(u => u.email == user.email);

                if (existingUser == null)
                    return "Пользователь не найден";

                if (existingUser.password != user.password)
                    return "Неверный пароль";

                existingUser.password = user.newPassword;
                db.SaveChanges();

                return "Пароль успешно обновлён";
            }
        }
    }
}
