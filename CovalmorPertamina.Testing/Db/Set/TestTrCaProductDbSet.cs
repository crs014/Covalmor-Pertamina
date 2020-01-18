using CovalmorPertamina.Entity.Model;
using System.Linq;

namespace CovalmorPertamina.Testing.Db.Set
{
    public class TestTrCaProductDbSet : TestDbSet<TrCaProduct>
    {
        public override TrCaProduct Find(params object[] keyValues)
        {
            return this.SingleOrDefault(tr => tr.Id == (int)keyValues.Single());
        }
    }
}
