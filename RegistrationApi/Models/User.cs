using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RegistrationApi.Models
{
    public class User
    {
        public User() { }

        private User(int id, string email, string password)
        {
            this.id = id;
            this.email = email;
            this.password = password;
        }

        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }  

        public static User CreateUser(int id, string email, string password)
        {
            if (!email.Contains("@"))
            {
                throw new Exception("Неверный email");
            }

            return new User(id, email, password);
        }
    }
}
