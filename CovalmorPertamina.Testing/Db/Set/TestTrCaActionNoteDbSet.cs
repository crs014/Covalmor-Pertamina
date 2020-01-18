using CovalmorPertamina.Entity.Model;
using System.Linq;

namespace CovalmorPertamina.Testing.Db.Set
{
    class TestTrCaActionNoteDbSet : TestDbSet<TrCaActionNote>
    {
        public override TrCaActionNote Find(params object[] keyValues)
        {
            return this.SingleOrDefault(tr => tr.Id == (int)keyValues.Single());
        }
    }
}
