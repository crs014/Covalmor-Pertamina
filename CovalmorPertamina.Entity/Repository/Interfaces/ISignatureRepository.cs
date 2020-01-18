using CovalmorPertamina.Entity.Model;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface ISignatureRepository : ILoadRepository<ISignatureRepository>
    {
        IQueryable<Signature> GetAll();

        Task<Signature> GetOne(int id);

        Task<Signature> Create(Signature data);

        Task<Signature> Delete(int id);

        Task<Signature> Update(int id, Signature data);
    }
}
