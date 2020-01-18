using CovalmorPertamina.Entity.Model;
using System.Linq;

namespace CovalmorPertamina.Testing.Db.Set
{
    public class TestSignatureDbSet : TestDbSet<Signature>
    {
        public override Signature Find(params object[] keyValues)
        {
            return this.SingleOrDefault(signature => signature.Id == (int)keyValues.Single());
        }
    }
}
