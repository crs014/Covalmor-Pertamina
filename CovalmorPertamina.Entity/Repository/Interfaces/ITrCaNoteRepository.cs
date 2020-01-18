using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface ITrCaNoteRepository : ILoadRepository<ITrCaNoteRepository>
    {
        IEnumerable<TrCaNote> GetAll();

        Task<TrCaNote> GetOne(int id);

        Task<TrCaNote> GetOneByCreditId(int id);

        Task<TrCaNote> Create(TrCaNote data);

        Task<TrCaNote> Delete(int id);

        Task<TrCaNote> Update(int id, TrCaNote data);

        Task<TrCaNote> UpdateByCreditId(int id, TrCaNote data);
    }
}
