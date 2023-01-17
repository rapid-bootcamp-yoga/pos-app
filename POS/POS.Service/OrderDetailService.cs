using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class OrderDetailService
    {
        private readonly ApplicationContext _context;  

        private OrderDetailModel EntityToModel(OrderDetailsEntity entity)
        {
            OrderDetailModel result = new OrderDetailModel();
            result.Id = entity.Id;
            result.OrderId = entity.OrderId;
            result.ProductId = entity.ProductId;
            result.UnitPrice = entity.UnitPrice;
            result.Quantity = entity.Quantity;
            result.Discount = entity.Discount;

            return result;
        }

        private void ModelToEntity(OrderDetailModel model, OrderDetailsEntity entity)
        {
            entity.OrderId = model.OrderId;
            entity.ProductId = model.ProductId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;
        }

        public OrderDetailService(ApplicationContext context)
        {
            _context = context;
        }

        public List<OrderDetailsEntity> GetOrderDetails()
        {
            return _context.OrderDetailsEntities.ToList();
        }

        public OrderDetailModel GetOrderDetailById(int? id)
        {
            var orderDetail = _context.OrderDetailsEntities.Find(id);
            return EntityToModel(orderDetail);
        }
      
        public List<OrderDetailsEntity> SaveOrderDetail(OrderDetailsEntity request)
        {
            _context.OrderDetailsEntities.Add(request);
            _context.SaveChanges();
            return GetOrderDetails();
        }

        public void UpdateOrderDetail(OrderDetailModel request)
        {
            var entity = _context.OrderDetailsEntities.Find(request.Id);
            ModelToEntity(request, entity);
            _context.OrderDetailsEntities.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteOrderDetail(int? id)
        {
            var entity = _context.OrderDetailsEntities.Find(id);
            _context.OrderDetailsEntities.Remove(entity);
            _context.SaveChanges();
        }

    }
}
