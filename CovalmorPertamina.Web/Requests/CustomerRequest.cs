using CovalmorPertamina.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace CovalmorPertamina.Web.Requests
{
    public class CustomerRequest
    {
        private Customer _customer;

        public CustomerRequest()
        {
            _customer = new Customer();
        }

        [Required(ErrorMessage = "Kolom nomor kustomer tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom nomor kustomer")]
        public string CustomerNo 
        {
            get
            {
                return _customer.CustomerNo;
            }
            set
            {
                _customer.CustomerNo = value;
            }
        }

        [Required(ErrorMessage = "Kolom nama tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom nama")]
        public string Name 
        {
            get
            {
                return _customer.Name;
            }
            set
            {
                _customer.Name = value;
            }
        }

        [Required(ErrorMessage = "Kolom email tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom email")]
        [EmailAddress(ErrorMessage = "Format email salah atau tidak valid")]
        public string Email 
        {
            get
            {
                return _customer.Email;
            }
            set
            {
                _customer.Email = value;
            }
        }

        [Required(ErrorMessage = "Kolom alamat tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom alamat")]
        public string Address 
        {
            get
            {
                return _customer.Address;
            }
            set
            {
                _customer.Address = value;
            }
        }

        [Required(ErrorMessage = "Kolom NPWP tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom NPWP")]
        public string NPWP 
        {
            get
            {
                return _customer.NPWP;
            }
            set
            {
                _customer.NPWP = value;
            }
        }

        public Customer GetObject() => _customer;
    }
}