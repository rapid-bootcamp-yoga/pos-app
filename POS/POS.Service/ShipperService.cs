using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class ShipperService
    {
        private readonly ApplicationContext _context;

        private ShipperModel EntityToModel(ShippersEntity entity)
        {
            ShipperModel result = new ShipperModel();
            result.Id = entity.Id;
            result.CompanyName= entity.CompanyName;
            result.Phone = entity.Phone;

            return result;
        }

        private void ModelToEntity(ShipperModel model, ShippersEntity entity)
        {
            entity.CompanyName = model.CompanyName;
            entity.Phone = model.Phone;
        }

        public ShipperService(ApplicationContext context)
        {
            _context = context; 
        }

        public List<ShippersEntity> GetShippers()
        {
            return _context.ShippersEntities.ToList();
        }

        public ShipperModel GetShipperById(int? id)
        {
            var shipper = _context.ShippersEntities.Find(id);
            return EntityToModel(shipper);
        }

        public List<ShippersEntity> SaveShipper([Bind("CompanyName, Phone")] ShippersEntity request)
        {
            _context.ShippersEntities.Add(request);
            _context.SaveChanges();
            return GetShippers();
        }

        public List<ShippersEntity> UpdateShipper([Bind("Id, CompanyName, Phone")] ShipperModel request)
        {
            var entity = _context.ShippersEntities.Find(request.Id);
            ModelToEntity(request, entity);
            _context.ShippersEntities.Update(entity);
            _context.SaveChanges();
            return GetShippers();
        }

        public void DeleteShipper(int? id)
        {
            var entity = _context.ShippersEntities.Find(id);
            _context.ShippersEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
