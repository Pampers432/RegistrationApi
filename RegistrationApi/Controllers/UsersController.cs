using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Contracts;
using RegistrationApi.Models;
using RegistrationApi.Repositories;
using RegistrationApi.Services;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JwtService jwtService;
        public UsersController(JwtService jwtService)
        {
            this.jwtService = jwtService;
        }

        [HttpPost("Register")]
        public string Register([FromBody] UserRequest userRequest)
        {
            User user = Models.User.CreateUser(userRequest.email, userRequest.password);
            return RegistrationService.RegisterUser(user);
        }

        [HttpPost("Login")]
        public UserResponse Login([FromBody] UserRequest userRequest)
        {
            User user = Models.User.CreateUser(userRequest.email, userRequest.password);
            var token = jwtService.GenerateToken(user);
            HttpContext.Response.Cookies.Append("TastyCoks", token);
            return LoginService.LoginUser(user, token);
        }

        [HttpPut("ChangePassword")]
        public string ChangePassword([FromBody] UserUpdateRequest userUpdateRequest)
        {
            return UsersRepository.UpdateUserPassword(userUpdateRequest);
        }

        [Authorize]
        [HttpGet]
        public List<User> GetUsers()
        {
            return UsersRepository.GetUsers();
        }


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
