using CovalmorPertamina.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace CovalmorPertamina.Web.Requests
{
    public class ProductRequest
    {
        private Product _product;

        public ProductRequest()
        {
            _product = new Product();
        }

        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom nomor material")]
        public string MaterialNo 
        {
            get
            {
                return _product.MaterialNo;
            }
            set
            {
                _product.MaterialNo = value;
            } 
        }

        [Required(ErrorMessage = "Kolom nama material tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom nama material")]
        public string MaterialName 
        {
            get
            {
                return _product.MaterialName;
            }
            set
            {
                _product.MaterialName = value;
            } 
        }

        [Required(ErrorMessage = "Kolom material group tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom material group")]
        public string MaterialGroup 
        {
            get
            {
                return _product.MaterialGroup;
            }
            set
            {
                _product.MaterialGroup = value;
            } 
        }

        public Product GetObject() => _product;
    }
}