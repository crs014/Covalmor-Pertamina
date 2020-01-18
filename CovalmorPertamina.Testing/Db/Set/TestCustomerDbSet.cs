using CovalmorPertamina.Entity.Model;
using System.Linq;

namespace CovalmorPertamina.Testing.Db.Set
{
    public class TestCustomerDbSet : TestDbSet<Customer>
    {
        public override Customer Find(params object[] keyValues)
        {
            return this.SingleOrDefault(customer => customer.Id == (int)keyValues.Single());
        }
    }
}
