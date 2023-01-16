
using POS.Repository;
using POS.ViewModel;
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

        private CustomerModel EntityToModel(CustomersEntity entity)
        {
            CustomerModel result = new CustomerModel();
            result.Id = entity.Id;
            result.CompanyName = entity.CompanyName;
            result.ContactName= entity.ContactName;
            result.ContactTitle = entity.ContactTitle;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.Phone = entity.Phone;
            result.Fax = entity.Fax;

            return result;
        }

        private void ModelToEntity(CustomerModel model, CustomersEntity entity)
        {
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
        }

        public CustomerService(ApplicationContext context)
        {
            _context = context;
        }

        public List<CustomersEntity> GetCustomers()
        {
            return _context.CustomersEntities.ToList();
        }

        public CustomerModel GetCustomersById(int? id) 
        {
            var customers = _context.CustomersEntities.Find(id);
            return EntityToModel(customers);
        }

        public void SaveCustomer(CustomersEntity request)
        {
            _context.CustomersEntities.Add(request);
            _context.SaveChanges();   
        }

        public void UpdateCustomer(CustomerModel request)
        {
            var entity = _context.CustomersEntities.Find(request.Id);
            ModelToEntity(request, entity);
            _context.CustomersEntities.Update(entity);
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
