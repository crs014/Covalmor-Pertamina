using CovalmorPertamina.Entity.Model;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface ICustomerRepository : ILoadRepository<ICustomerRepository>
    {
        IQueryable<Customer> GetAll();

        Task<Customer> GetOne(int id);

        Task<Customer> Create(Customer data);

        Task<Customer> Delete(int id);

        Task<Customer> Update(int id, Customer data);
    }
}
