using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class OrderService
    {
        private readonly ApplicationContext _context;

        private OrderModel EntityToModel(OrdersEntity entity)
        {
            OrderModel result = new OrderModel();
            result.Id = entity.Id;
            result.CustomerId = entity.CustomerId;
            result.EmployeesId = entity.EmployeesId;
            result.OrderDate = entity.OrderDate;
            result.RequiredDate = entity.RequiredDate;
            result.ShippedDate = entity.ShippedDate;
            result.ShipVia = entity.ShipVia;
            result.Freight = entity.Freight;
            result.ShipName= entity.ShipName;
            result.ShipAddress = entity.ShipAddress;
            result.ShipCity = entity.ShipCity;
            result.ShipRegion = entity.ShipRegion;
            result.ShipPostalCode = entity.ShipPostalCode;
            result.ShipCountry = entity.ShipCountry;

            return result;
        }

        private void ModelToEntity(OrderModel model, OrdersEntity entity)
        {
            entity.CustomerId = model.CustomerId;
            entity.EmployeesId = model.EmployeesId;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipVia = model.ShipVia;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
        }

        public OrderService(ApplicationContext context)
        {
            _context = context;
        }

        public List<OrdersEntity> GetOrders()
        {
            return _context.OrdersEntities.ToList();
        }

        public OrderModel GetOrderById(int? id)
        {
            var order = _context.OrdersEntities.Find(id);
            return EntityToModel(order);
        }

        public List<OrdersEntity> SaveOrder(OrdersEntity request)
        {
            _context.OrdersEntities.Add(request);
            _context.SaveChanges();
            return GetOrders();
        }

        public void UpdateOrder(OrderModel request)
        {
            var entity = _context.OrdersEntities.Find(request.Id);
            ModelToEntity(request, entity);
            _context.OrdersEntities.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteOrder(int? id)
        {
            var entity = _context.OrdersEntities.Find(id);
            _context.OrdersEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
