using RegistrationApi.Data;
using RegistrationApi.Models;

namespace RegistrationApi.Repositories
{
    public class UsersRepository
    {
        public static void AddUser(string email, string password)
        {
            var user = User.CreateUser(email, password);

            RegistrationDbContext.Users.Add(user);
        }
    }
}
