using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IDBCovalmor _db;

        public ERepository repository => ERepository.Product;

        public ProductRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public Task<Product> Create(Product data)
        {
            return Task.Run(() =>
            {
                Product product = _db.Products.Add(data);
                _db.SaveChanges();
                return product;
            });
        }

        public Task<Product> Delete(int id)
        {
            return Task.Run(() =>
            {
                Product product = _db.Products.Find(id);
                if(product != null)
                {
                    _db.Products.Remove(product);
                    _db.SaveChanges();
                }
                return product;
            });
        }

        public IQueryable<Product> GetAll()
        {
            return _db.Products;
        }

        public Task<Product> GetOne(int id)
        {
            return Task.Run(() =>_db.Products.Find(id));
        }

        public Task<Product> Update(int id, Product data)
        {
            return Task.Run(() =>
            {
                Product product = _db.Products.Find(id);
                if (product != null)
                {
                    product.MaterialNo = data.MaterialNo;
                    product.MaterialName = data.MaterialName;
                    product.MaterialGroup = data.MaterialGroup;
                    product.UpdatedAt = DateTime.UtcNow;
                    _db.SaveChanges();
                }
                return product;
            });
        }
    }
}
