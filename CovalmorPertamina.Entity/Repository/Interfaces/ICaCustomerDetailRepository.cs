using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface ICaCustomerDetailRepository : ILoadRepository<ICaCustomerDetailRepository>
    {
        IEnumerable<CaCustomerDetail> GetAll();

        Task<CaCustomerDetail> GetOne(int id);

        Task<CaCustomerDetail> Create(CaCustomerDetail data);

        Task<CaCustomerDetail> Delete(int id);

        Task<CaCustomerDetail> Update(int id, CaCustomerDetail data);
    }
}
