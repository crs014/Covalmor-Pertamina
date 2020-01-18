using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface ITrCaProductRepository : ILoadRepository<ITrCaProductRepository>
    {
        IEnumerable<TrCaProduct> GetAll();

        IEnumerable<TrCaProduct> GetFromCreditId(int id);

        Task<TrCaProduct> GetOne(int id);

        Task<TrCaProduct> Create(TrCaProduct data);

        Task MultipleCreate(IEnumerable<TrCaProduct> trCaProducts);

        Task<bool> DeleteByCreditId(int id);

        Task<TrCaProduct> Delete(int id);
    }
}
