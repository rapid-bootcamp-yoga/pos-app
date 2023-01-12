using POS.Repository;
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

        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public List<ProductsEntity> GetProducts()
        {
            return _context.ProductsEntities.ToList();
        }

        public ProductsEntity GetProductById(int? id) 
        {
            return _context.ProductsEntities.Find(id);
        }

        public List<ProductsEntity> SaveProduct(ProductsEntity request)
        {
            _context.ProductsEntities.Add(request);
            _context.SaveChanges();
            return GetProducts();
        }

        public List<ProductsEntity> UpdateProduct(ProductsEntity request)
        {
            _context.ProductsEntities.Update(request);
            return GetProducts();
        }

        public void DeleteProduct(int? id) 
        {
            var entity = GetProductById(id);

            _context.ProductsEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
