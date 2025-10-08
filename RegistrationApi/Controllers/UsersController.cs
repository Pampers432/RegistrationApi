using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Models;
using RegistrationApi.Services;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController() { }

        [HttpGet("Register")]
        public string Register(string email, string password)
        {
            return RegistrationService.RegisterUser(email, password);
        }

        [HttpGet("Login")]
        public string Login(string email, string password)
        {
            return LoginService.LoginUser(email, password);
        }

        //[HttpGet]
        //public User GetUser(string email, string password)
        //{
        //    return Models.User.CreateUser(email, password);
        //}


        //[HttpGet("create-multiple")]
        //public IEnumerable<User> GetUsers()
        //{
        //    return new List<User> {
        //        Models.User.CreateUser("alex123@1234", "1234"),
        //        Models.User.CreateUser("max233@1234", "15434"),
        //        Models.User.CreateUser("anton223433@1234", "15gfs4")
        //    };
        //}
    }
}
