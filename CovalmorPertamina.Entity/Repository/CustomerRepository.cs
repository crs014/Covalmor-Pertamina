using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDBCovalmor _db;

        public ERepository repository => ERepository.Customer;

        public CustomerRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public Task<Customer> Create(Customer data)
        {
            return Task.Run(() =>
            {
                Customer customer = _db.Customers.Add(data);
                _db.SaveChanges();
                return customer;
            });
        }

        public Task<Customer> Delete(int id)
        {
            return Task.Run(() =>
            {
                Customer customer = _db.Customers.Find(id);
                if(customer != null)
                {
                    _db.Customers.Remove(customer);
                    _db.SaveChanges();
                }
                return customer;
            });
        }

        public IQueryable<Customer> GetAll()
        {
            return _db.Customers;
        }

        public Task<Customer> GetOne(int id)
        {
            return Task.Run(() => _db.Customers.Find(id));
        }

        public Task<Customer> Update(int id, Customer data)
        {
            return Task.Run(() =>
            {
                Customer customer = _db.Customers.Find(id);
                if(customer != null)
                {
                    customer.CustomerNo = data.CustomerNo;
                    customer.Name = data.Name;
                    customer.Email = data.Email;
                    customer.Address = data.Address;
                    customer.NPWP = data.NPWP;
                    customer.UpdatedAt = DateTime.UtcNow;
                    _db.SaveChanges();
                }
                return customer;
            });
        }

        public Task<IQueryable<Customer>> CreateMany(IQueryable<Customer> customers)
        {
            return Task.Run(() =>
            {
                foreach (Customer customer in customers)
                {
                    _db.Customers.Add(customer);
                }
                _db.SaveChanges();
                return customers;
            });
        }
    }
}
