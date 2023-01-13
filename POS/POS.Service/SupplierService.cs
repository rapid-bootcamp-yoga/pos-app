using POS.Repository;
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

        public SupplierService(ApplicationContext context)
        {
            _context = context;
        }

        public List<SuppliersEntity> GetSuppliers()
        {
            return _context.SuppliersEntities.ToList();
        }

        public SuppliersEntity GetSupplierById(int? id)
        {
            return _context.SuppliersEntities.Find(id);
        }

        public List<SuppliersEntity> SaveSupplier(SuppliersEntity request)
        {
            _context.SuppliersEntities.Add(request);
            _context.SaveChanges();
            return GetSuppliers();
        }

        public List<SuppliersEntity> UpdateSupplier(SuppliersEntity request)
        {
            _context.SuppliersEntities.Update(request);
            _context.SaveChanges();
            return GetSuppliers();
        }

        public void DeleteSupplier(int? id)
        {
            var entity = GetSupplierById(id);

            _context.SuppliersEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
