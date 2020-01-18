using CovalmorPertamina.Entity.Model;
using System.Linq;

namespace CovalmorPertamina.Testing.Db.Set
{
    public class TestCreditApprovalDbSet : TestDbSet<CreditApproval>
    {
        public override CreditApproval Find(params object[] keyValues)
        {
            return this.SingleOrDefault(creditApproval => creditApproval.Id == (int)keyValues.Single());
        }
    }
}
