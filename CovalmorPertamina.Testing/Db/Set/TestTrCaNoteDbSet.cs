using CovalmorPertamina.Entity.Model;
using System.Linq;

namespace CovalmorPertamina.Testing.Db.Set
{
    public class TestTrCaNoteDbSet : TestDbSet<TrCaNote>
    {
        public override TrCaNote Find(params object[] keyValues)
        {
            return this.SingleOrDefault(tr => tr.Id == (int)keyValues.Single());
        }
    }
}
