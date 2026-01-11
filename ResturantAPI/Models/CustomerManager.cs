using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models
{
    public class CustomerManager : IDataRepository<Customer>
    {
        readonly ResturantDbContext _resturantDb;
        public CustomerManager(ResturantDbContext context)
        {
            _resturantDb = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _resturantDb.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return _resturantDb.Customers
                  .FirstOrDefault(e => e.ID == id);
        }

        public void Add(Customer customer)
        {
            _resturantDb.Customers.Add(customer);
            _resturantDb.SaveChanges();
        }

        public void Change(Customer customer, Customer entity)
        {

            customer.Name = entity.Name;
            customer.Email = entity.Email;
            customer.Mobile = entity.Mobile;

            _resturantDb.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _resturantDb.Customers.Remove(customer);
            _resturantDb.SaveChanges();
        }
    }
}
