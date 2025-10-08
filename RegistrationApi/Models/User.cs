using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationApi.Models
{
    [Table("Users")]
    public class User
    {
        public User() { }

        private User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        public string email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        public string password { get; set; }  

        public static User CreateUser(string email, string password)
        {
            if (!email.Contains("@"))
            {
                throw new Exception("Неверный email");
            }

            return new User(email, password);
        }
    }
}
