using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Models;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController() { }

        [HttpGet]
        public User GetUser(string email, string password)
        {
            return Models.User.CreateUser(0, email, password);
        }


        [HttpGet("create-multiple")]
        public IEnumerable<User> GetUsers()
        {
            return new List<User> {
                Models.User.CreateUser(0, "alex123@1234", "1234"),
                Models.User.CreateUser(1, "max233@1234", "15434"),
                Models.User.CreateUser(2, "anton223433@1234", "15gfs4")
            };
        }
    }
}
