using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface IQuantitativeAspectRepository : ILoadRepository<IQuantitativeAspectRepository>
    {
        IEnumerable<QuantitativeAspect> GetAll();

        Task<QuantitativeAspect> GetOne(int id);

        Task<QuantitativeAspect> Create(QuantitativeAspect data);

        Task<QuantitativeAspect> Delete(int id);

        Task<QuantitativeAspect> Update(int id, QuantitativeAspect data);
    }
}
