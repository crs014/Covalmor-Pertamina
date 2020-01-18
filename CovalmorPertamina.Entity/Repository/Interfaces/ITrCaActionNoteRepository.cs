using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface ITrCaActionNoteRepository : ILoadRepository<ITrCaActionNoteRepository>
    {
        IEnumerable<TrCaActionNote> GetAll();

        Task<TrCaActionNote> GetOne(int id);

        Task<TrCaActionNote> Create(TrCaActionNote data);

        Task<TrCaActionNote> Delete(int id);

        IEnumerable<TrCaActionNote> DeleteByCreatedBy(int id);

        Task<TrCaActionNote> Update(int id, TrCaActionNote data);
    }
}
