using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Linq;

namespace CovalmorPertamina.Web.Models
{
    public class CustomerModel
    {
        private Customer _customer = new Customer();

        public CustomerModel() 
        {
            _customer = new Customer();
        }

        public CustomerModel(Customer customer)
        {
            if(customer != null)
            {
                _customer = customer;
            }
        }

        public static IEnumerable<CustomerModel> GetAll(IEnumerable<Customer> customers)
        {
            return customers.Select(e => new CustomerModel(e));
        }

        public int Id => _customer.Id;

        public string CustomerNo => _customer.CustomerNo;
     
        public string Name => _customer.Name;

        public string Email => _customer.Email;
        
        public string Address => _customer.Address;

        public string NPWP => _customer.NPWP;
    }
}