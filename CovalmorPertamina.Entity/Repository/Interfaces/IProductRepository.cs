using CovalmorPertamina.Entity.Model;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface IProductRepository : ILoadRepository<IProductRepository>
    {
        IQueryable<Product> GetAll();

        Task<Product> GetOne(int id);

        Task<Product> Create(Product data);

        Task<Product> Delete(int id);

        Task<Product> Update(int id, Product data);

        Task<IQueryable<Product>> CreateMany(IQueryable<Product> products);
    }
}
