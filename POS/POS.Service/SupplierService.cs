using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class SupplierService
    {
        private readonly ApplicationContext _context;

        private SupplierModel EntityToModel(SuppliersEntity entity)
        {
            SupplierModel result = new SupplierModel();
            result.Id= entity.Id;
            result.CompanyName = entity.CompanyName;
            result.ContactName = entity.ContactName;
            result.ContactTitle = entity.ContactTitle;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region= entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.Phone = entity.Phone;
            result.Fax = entity.Fax;
            result.HomePage = entity.HomePage;
            return result;
        }

        private void ModelToEntity(SupplierModel model, SuppliersEntity entity)
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
            entity.HomePage = model.HomePage;
        }

        public SupplierService(ApplicationContext context)
        {
            _context = context;
        }

        public List<SuppliersEntity> GetSuppliers()
        {
            return _context.SuppliersEntities.ToList();
        }

        public SupplierModel GetSupplierById(int? id)
        {
            var supplier = _context.SuppliersEntities.Find(id);
            return EntityToModel(supplier);
        }

        public List<SuppliersEntity> SaveSupplier(SuppliersEntity request)
        {
            _context.SuppliersEntities.Add(request);
            _context.SaveChanges();
            return GetSuppliers();
        }

        public void UpdateSupplier(SupplierModel request)
        {
            var entity = _context.SuppliersEntities.Find(request.Id);
            ModelToEntity(request, entity);
            _context.SuppliersEntities.Update(entity);
            _context.SaveChanges();
        
        }

        public void DeleteSupplier(int? id)
        {
            var entity = _context.SuppliersEntities.Find(id);

            _context.SuppliersEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
