using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Linq;

namespace CovalmorPertamina.Web.Models
{
    public class UserModel
    {
        public UserModel() { }

        public UserModel(User user)
        {
            if (user != null)
            {
                Id = user.Id;
                Name = user.Name;
                Email = user.Email;
                Jabatan = user.Jabatan;
                if (user.Role == EUserRole.Admin)
                {
                    Role = "Admin";
                }
                else if (user.Role == EUserRole.AR)
                {
                    Role = "AR";
                }
                else if (user.Role == EUserRole.CashBank)
                {
                    Role = "Cash Bank";
                }
                else if (user.Role == EUserRole.FBS)
                {
                    Role = "FBS";
                }
                else if (user.Role == EUserRole.KomiteCredit)
                {
                    Role = "Komite Kredit";
                }
                else if (user.Role == EUserRole.ManagementRisk)
                {
                    Role = "Management Resiko";
                }
                else
                {
                    Role = "User";
                }
                UserRole = user.Role;
            }
        }

        public static IEnumerable<UserModel> GetAll(IEnumerable<User> users)
        {
            return users.Select(e => new UserModel(e));
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Jabatan { get; set; }

        public string Role { get; set; }

        public EUserRole UserRole { get; set; }
    }
}