using CovalmorPertamina.Entity.Model;
using System.Linq;

namespace CovalmorPertamina.Testing.Db.Set
{
    public class TestUserDbSet : TestDbSet<User>
    {
        public override User Find(params object[] keyValues)
        {
            return this.SingleOrDefault(user => user.Id == (int)keyValues.Single());
        }
    }
}
