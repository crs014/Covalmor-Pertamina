using CovalmorPertamina.Entity.Model;
using System.Data.Entity;

namespace CovalmorPertamina.Entity
{
    public class DBCovalmor : DbContext, IDBCovalmor
    {
        public DBCovalmor() : base("CovalmorContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<CreditApproval> CreditApprovals { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<StaticValue> StaticValues { get; set; }
        public virtual DbSet<TrCaActionNote> TrCaActionNotes { get; set; }
        public virtual DbSet<TrCaProduct> TrCaProducts { get; set; }
        public virtual DbSet<Signature> Signatures { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CaCustomerDetail> CaCustomerDetails { get; set; }
        public virtual DbSet<TrCaNote> TrCaNotes { get; set; }
        public virtual DbSet<CreditScoring> CreditScorings { get; set; }
        public virtual DbSet<QuantitativeAspect> QuantitativeAspects { get; set; }

    }
}
