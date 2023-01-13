
using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class CustomerService
    {
        private readonly ApplicationContext _context;
        public CustomerService(ApplicationContext context)
        {
            _context = context;
        }

        public List<CustomersEntity> GetCustomers()
        {
            return _context.CustomersEntities.ToList();
        }

        public CustomersEntity GetCustomersById(int? id) 
        {
            var entity = _context.CustomersEntities.Find(id);
            return entity;
        }

        public void SaveCustomer(CustomersEntity request)
        {
            _context.CustomersEntities.Add(request);
            _context.SaveChanges();   
        }

        public void UpdateCustomer(CustomersEntity request)
        {
            _context.CustomersEntities.Update(request);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int? id)
        {
            var entity = _context.CustomersEntities.Find(id);

            _context.CustomersEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
