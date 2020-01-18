using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface ICreditScoringRepository : ILoadRepository<ICreditScoringRepository>
    {
        IEnumerable<CreditScoring> GetAll();

        Task<CreditScoring> GetOne(int id);

        Task<CreditScoring> Create(CreditScoring data);

        Task<CreditScoring> Delete(int id);

        Task<CreditScoring> Update(int id, CreditScoring data);
    }
}
