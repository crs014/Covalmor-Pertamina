using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace CovalmorPertamina.Web.Requests
{
    public class UserRequest
    {
        private User _user;

        public UserRequest()
        {
            _user = new User();
        }

        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom nama")]
        [Required(ErrorMessage = "Kolom nama tidak boleh kosong")]
        public string Name 
        {
            get
            {
                return _user.Name;
            }
            set
            {
                _user.Name = value;
            }
        }

        [EmailAddress(ErrorMessage = "Format email salah atau tidak valid")]
        [Required(ErrorMessage = "Kolom email tidak boleh kosong")]
        public string Email 
        {
            get
            {
                return _user.Email;
            }
            set
            {
                _user.Email = value;
            }
        }

        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom jabatan")]
        public string Jabatan 
        {
            get
            {
                return _user.Jabatan;
            }
            set
            {
                _user.Jabatan = value;
            }
        }

        [Required(ErrorMessage = "Kolom password tidak boleh kosong")]
        [MaxLength(12, ErrorMessage = "Maksimal karakter 191 pada kolom password")]
        public string Password 
        {
            get
            {
                return _user.Password;
            }
            set
            {
                _user.Password = value;
            }
        }

        [Required(ErrorMessage = "Kolom role tidak boleh kosong")]
        public EUserRole Role 
        {
            get
            {
                return _user.Role;
            }
            set
            {
                _user.Role = value;
            } 
        }

        public User GetObject() => _user;
    }
}