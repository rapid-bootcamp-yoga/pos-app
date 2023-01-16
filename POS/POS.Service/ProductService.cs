using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class ProductService
    {
        private readonly ApplicationContext _context;

        private ProductModel EntityToModel(ProductsEntity entity)
        {
            ProductModel result = new ProductModel();
            result.Id = entity.Id;
            result.ProductName = entity.ProductName;
            result.SupplierId = entity.SupplierId;
            result.CategoryId = entity.CategoryId;
            result.Quantity_per_unit = entity.Quantity_per_unit;
            result.UnitPrice = entity.UnitPrice;
            result.UnitsInStock = entity.UnitsInStock;
            result.UnitsOnOrder = entity.UnitsOnOrder;
            result.ReorderLevel = entity.ReorderLevel;
            result.Discontinued = entity.Discontinued;

            return result;
        }

        private void ModelToEntity(ProductModel model, ProductsEntity entity)
        {
            entity.ProductName = model.ProductName;
            entity.SupplierId = model.SupplierId;
            entity.CategoryId = model.CategoryId;
            entity.Quantity_per_unit = model.Quantity_per_unit;
            entity.UnitPrice = model.UnitPrice;
            entity.UnitsInStock = model.UnitsInStock;
            entity.UnitsOnOrder = model.UnitsOnOrder;
            entity.ReorderLevel =model.ReorderLevel;
            entity.Discontinued = model.Discontinued;
        }

        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public List<ProductsEntity> GetProducts()
        {
            return _context.ProductsEntities.ToList();
        }

        public ProductModel GetProductById(int? id) 
        {
            var product = _context.ProductsEntities.Find(id);
            return EntityToModel(product);
        }

        public List<ProductsEntity> SaveProduct(ProductsEntity request)
        {
            _context.ProductsEntities.Add(request);
            _context.SaveChanges();
            return GetProducts();
        }

        public void UpdateProduct(ProductModel request)
        {
            var entity = _context.ProductsEntities.Find(request.Id);
            ModelToEntity(request, entity);
            _context.ProductsEntities.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteProduct(int? id) 
        {
            var entity = _context.ProductsEntities.Find(id);

            _context.ProductsEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
