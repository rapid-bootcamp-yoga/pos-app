using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.ViewModel;
using POS.ViewModel.Response;
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

        private OrderModel EntityToModelOrder(OrdersEntity entity)
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
            //result.OrderDetails = new List<OrderDetailModel>();
            //foreach (var item in entity.OrderDetails)
            //{
            //    result.OrderDetails.Add(EntityToModelOrderDetail(item));
            //}

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

        private OrdersEntity ModelToEntityOrder(OrderModel model)
        {
            var entity = new OrdersEntity();
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
            entity.OrderDetails = new List<OrderDetailsEntity>();

            //foreach (var item in model.OrderDetails)
            //{
            //    model.OrderDetails.Add(ModelToEntityOrderDetail(item));
            //}
            return entity;

        }

        private OrderDetailModel EntityToModelOrderDetail(OrderDetailsEntity entity)
        {
            var model = new OrderDetailModel();
            model.Id = entity.Id;
            model.ProductId = entity.ProductId;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount = entity.Discount;

            return model;
        }

        private OrderDetailsEntity ModelToEntityOrderDetail(OrderDetailModel model)
        {
            var entity = new OrderDetailsEntity();
            entity.OrderId = model.OrderId;
            entity.ProductId = model.ProductId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;

            return entity;
        }


        //private DetailOfOrderResponse EntityToModelResponseDetail(OrdersEntity entity)
        //{
           
        //    var customer = _context.CustomersEntities.Find(entity.CustomerId);

        //    var response = new DetailOfOrderResponse();
        //    response.Id = entity.Id;
        //    response.CustomerId = customer.Id;
        //    response.CustomerName = customer.ContactName;
        //    response.OrderDate = entity.OrderDate;

        //    return response;
        //}

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
            return EntityToModelOrder(order);
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
