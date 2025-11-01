using RegistrationApi.Contracts;
using RegistrationApi.Data;
using RegistrationApi.Models;

namespace RegistrationApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly RegistrationDbContext _db;

        public LoginService(RegistrationDbContext db)
        {
            _db = db;
        }

        public UserResponse LoginUser(User user, string token)
        {
            if (_db.Users.Any(u => u.email == user.email && u.password == user.password))
            {
                return new UserResponse(user.email, user.password, token);
            }

            return null;
        }

        public User GetUser(UserRequest user)
        {
            return _db.Users.FirstOrDefault(u => u.email == user.email && u.password == user.password);
        }
    }
}