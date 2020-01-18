using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Linq;

namespace CovalmorPertamina.Web.Models
{
    public class ProductModel
    {
        private Product _product;

        public ProductModel() 
        {
            _product = new Product();
        }

        public ProductModel(Product product)
        {
            _product = product;
        }

        public static IEnumerable<ProductModel> GetAll(IEnumerable<Product> products)
        {
            return products.Select(e => new ProductModel(e));
        }

        public int Id  => _product.Id;

        public string MaterialNo => _product.MaterialNo;

        public string MaterialName => _product.MaterialName;

        public string MaterialGroup  => _product.MaterialGroup;
    }
}