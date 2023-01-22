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
            result.ShipperId = entity.ShipperId;
            result.OrderDate = entity.OrderDate;
            result.RequiredDate = entity.RequiredDate;
            result.ShippedDate = entity.ShippedDate;
            result.Freight = entity.Freight;
            result.ShipName= entity.ShipName;
            result.ShipAddress = entity.ShipAddress;
            result.ShipCity = entity.ShipCity;
            result.ShipRegion = entity.ShipRegion;
            result.ShipPostalCode = entity.ShipPostalCode;
            result.ShipCountry = entity.ShipCountry;
            result.OrderDetails = new List<OrderDetailModel>();
            foreach (var item in entity.OrderDetails)
            {
                result.OrderDetails.Add(EntityToModelOrderDetail(item));
            }

            return result;
        }


        private OrdersEntity ModelToEntityOrder(OrderModel model)
        {
            var entity = new OrdersEntity();
            entity.CustomerId = model.CustomerId;
            entity.EmployeesId = model.EmployeesId;
            entity.ShipperId = model.ShipperId;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
            entity.OrderDetails = new List<OrderDetailsEntity>();

            foreach (var item in model.OrderDetails)
            {
                model.OrderDetails.Add(ModelToEntityOrderDetail(item));
            }
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

        public OrderService(ApplicationContext context)
        {
            _context = context;
        }

        private DetailOfOrderResponse EntityToModelResponseDetail(OrdersEntity entity)
        {
            var shipper = _context.ShippersEntities.Find(entity.ShipperId);
            var customer = _context.CustomersEntities.Find(entity.CustomerId);

            var response = new DetailOfOrderResponse();
            response.Id = entity.Id;
            response.CustomerId = customer.Id;
            response.CustomerName = customer.CompanyName;
            response.OrderDate = entity.OrderDate;
            response.RequiredDate = entity.RequiredDate;
            response.ShippedDate = entity.ShippedDate;
            response.ShipperId = shipper.Id;
            response.ShipperName = shipper.CompanyName;
            response.ShipperPhone = shipper.Phone;
            response.Freight = entity.Freight;
            response.ShipName = entity.ShipName;
            response.ShipAddress = entity.ShipAddress;
            response.ShipCity = entity.ShipCity;
            response.ShipRegion = entity.ShipRegion;
            response.ShipPostalCode = entity.ShipPostalCode;
            response.ShipCountry = entity.ShipCountry;
            response.Details = new List<OrderDetailResponse>();

            foreach(var item in entity.OrderDetails)
            {
                response.Details.Add(EntityToModelDetailResponse(item));
                
            }
            var subtotal = 0.0;
            foreach (var item in response.Details)
            {
                item.Subtotal = item.Quantity * item.UnitPrice * (1 - item.Discount / 100);
            }
            response.Subtotal = subtotal;
            response.Tax = 0.05 * subtotal;
            response.Shipping = 0;
            response.Total = response.Subtotal + response.Tax + response.Shipping;

            return response;
        }

        private OrderDetailResponse EntityToModelDetailResponse(OrderDetailsEntity entity)
        {
            var model = new OrderDetailResponse();
            var product = _context.ProductsEntities.Find(entity.ProductId);

            model.Id = entity.Id;
            model.ProductId = product.Id;
            model.ProductName = product.ProductName;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount = entity.Discount;

            return model;


        }

        public List<OrdersEntity> GetOrders()
        {
            return _context.OrdersEntities.ToList();
        }

        public OrderModel GetOrderById(int? id)
        {
            var order = _context.OrdersEntities.Find(id);
            var detail = _context.OrderDetailsEntities.Where(x => x.OrderId == id);
            foreach (var item in detail) { }
            return EntityToModelOrder(order);
        }

        public DetailOfOrderResponse GetOrderInvoice(int? id)
        {
            var orderEntity = _context.OrdersEntities.Find(id);
            var detailEntity = _context.OrderDetailsEntities.Where(x => x.OrderId == id).ToList();
            orderEntity.OrderDetails = detailEntity;
            var orderResponse = EntityToModelResponseDetail(orderEntity);
            return orderResponse;
        }


        public void SaveOrder(OrderModel requestOrder)
        {
            var newItem = ModelToEntityOrder(requestOrder);
            _context.OrdersEntities.Add(newItem);
            foreach (var item in newItem.OrderDetails)
            {
                item.OrderId = requestOrder.Id;
                _context.OrderDetailsEntities.Add(item);
            }
            _context.SaveChanges();
           
        }

        public void UpdateOrder(OrderModel request)
        {
            //baca dari database
            var entityOrder = _context.OrdersEntities.Find(request.Id);
            var orderDetailList = _context.OrderDetailsEntities.Where(x => x.OrderId == request.Id).ToList();

            //ubah model dengan update data yg dimasukkan ke entity
            var updateEntity = ModelToEntityOrder(request);

            entityOrder.CustomerId = updateEntity.CustomerId;
            entityOrder.EmployeesId = updateEntity.EmployeesId;
            entityOrder.OrderDate = updateEntity.OrderDate;
            entityOrder.RequiredDate = updateEntity.RequiredDate;
            entityOrder.ShippedDate = updateEntity.ShippedDate;
            entityOrder.ShipperId = updateEntity.ShipperId;
            entityOrder.Freight = updateEntity.Freight;
            entityOrder.ShipName = updateEntity.ShipName;
            entityOrder.ShipAddress = updateEntity.ShipAddress;
            entityOrder.ShipCity = updateEntity.ShipCity;
            entityOrder.ShipRegion = updateEntity.ShipRegion;
            entityOrder.ShipPostalCode = updateEntity.ShipPostalCode;
            entityOrder.ShipCountry = updateEntity.ShipCountry;
            entityOrder.OrderDetails = updateEntity.OrderDetails;

            // update order entity-nya
            _context.OrdersEntities.Update(entityOrder);

            //looping order detail
            foreach (var newItem in entityOrder.OrderDetails)
            {
                newItem.OrderId = request.Id;
                foreach ( var item in orderDetailList)
                {
                    if (newItem.ProductId == item.ProductId)
                    {
                        item.ProductId = newItem.ProductId;
                        item.UnitPrice = newItem.UnitPrice;
                        item.Quantity = newItem.Quantity;
                        item.Discount = newItem.Discount;

                        // update order detail entity-nya
                        _context.OrderDetailsEntities.Update(item);
                    }
                }
            }
            // save perubahan yg dibuat diatas
            _context.SaveChanges();
        }

        public void DeleteOrder(int? id)
        {
            var entity = _context.OrdersEntities.Find(id);
            _context.OrdersEntities.Remove(entity);

            var detail = _context.OrderDetailsEntities.Where(x => x.Id == id);
            foreach (var item in detail)
            {
                _context.OrderDetailsEntities.Remove(item);
            }

            _context.SaveChanges();
        }
    }
}
