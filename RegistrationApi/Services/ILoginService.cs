using RegistrationApi.Contracts;
using RegistrationApi.Models;

namespace RegistrationApi.Services
{
    public interface ILoginService
    {
        UserResponse LoginUser(User user, string token);
        User GetUser(UserRequest user);
    }
}