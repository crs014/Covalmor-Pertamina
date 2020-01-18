using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class TrCaProductRepository : ITrCaProductRepository
    {
        private IDBCovalmor _db;

        public ERepository repository => ERepository.TrCaProduct;

        public TrCaProductRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public Task MultipleCreate(IEnumerable<TrCaProduct> trCaProducts)
        {
            return Task.Run(() =>
            {
                foreach(TrCaProduct trCaProduct in trCaProducts)
                {
                    _db.TrCaProducts.Add(trCaProduct);
                }
                _db.SaveChanges();
            });
        }

        public Task<TrCaProduct> Create(TrCaProduct data)
        {
            return Task.Run(() =>
            {
                TrCaProduct trCaProduct = _db.TrCaProducts.Add(data);
                _db.SaveChanges();
                return trCaProduct;
            });
        }

        public Task<TrCaProduct> Delete(int id)
        {
            return Task.Run(() =>
            {
                TrCaProduct trCaProduct = _db.TrCaProducts.Find(id);
                if(trCaProduct != null)
                {
                    _db.TrCaProducts.Remove(trCaProduct);
                    _db.SaveChanges();
                }
                return trCaProduct;
            });
        }

        public Task<bool> DeleteByCreditId(int id)
        {
            return Task.Run(() =>
            {
                IQueryable<TrCaProduct> trCaProducts = _db.TrCaProducts.Where(e => e.CreditApprovalId == id);
                if (trCaProducts.Count() != 0)
                {
                    _db.TrCaProducts.RemoveRange(trCaProducts);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            });
        }

        public IEnumerable<TrCaProduct> GetAll()
        {
            return _db.TrCaProducts;
        }

        public IEnumerable<TrCaProduct> GetFromCreditId(int id)
        {
            return _db.TrCaProducts.Where(e => e.CreditApprovalId == id);
        }

        public Task<TrCaProduct> GetOne(int id)
        {
            return Task.Run(() => _db.TrCaProducts.Find(id));
        }
    }
}
