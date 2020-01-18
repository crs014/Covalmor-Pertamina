using CovalmorPertamina.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity
{
    public interface IDBCovalmor
    {
        DbSet<Product> Products { get; }
        DbSet<CreditApproval> CreditApprovals { get; }
        DbSet<Customer> Customers { get; }
        DbSet<StaticValue> StaticValues { get; }
        DbSet<TrCaActionNote> TrCaActionNotes { get; }
        DbSet<TrCaProduct> TrCaProducts { get; }
        DbSet<Signature> Signatures { get; }
        DbSet<User> Users { get; }
        DbSet<CaCustomerDetail> CaCustomerDetails { get; }
        DbSet<TrCaNote> TrCaNotes { get; }
        DbSet<CreditScoring> CreditScorings { get; }
        DbSet<QuantitativeAspect> QuantitativeAspects { get; }


        #region variable
        Database Database { get; }
        #endregion

        #region method
        int SaveChanges();
        #endregion
    }
}
