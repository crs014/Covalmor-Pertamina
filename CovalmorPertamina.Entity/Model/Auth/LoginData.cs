using System.ComponentModel.DataAnnotations;

namespace CovalmorPertamina.Entity.Model.Auth
{
    public class LoginData
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
