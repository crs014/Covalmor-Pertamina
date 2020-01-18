using System.ComponentModel.DataAnnotations;

namespace CovalmorPertamina.Entity.Model.Auth
{
    public class RefreshData
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
