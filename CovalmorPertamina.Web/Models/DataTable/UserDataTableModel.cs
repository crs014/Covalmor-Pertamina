using CovalmorPertamina.Common.Statics;

namespace CovalmorPertamina.Web.Models.DataTable
{
    public class UserDataTableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        private string _role;
        public string Role 
        {
            get
            {
                return StringService.AddSpacesToBeforeCapital(_role);
            }
            set
            {
                _role = value;
            }
        }
    }
}