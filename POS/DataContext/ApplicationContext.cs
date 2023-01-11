using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)  : base(options)
        { 
        }

        public DbSet<ProductsEntity> ProductsEntities => Set<ProductsEntity>();
        public DbSet<CategoriesEntity> CategoriesEntities => Set<CategoriesEntity>();
        public DbSet<CustomersEntity> CustomersEntities => Set<CustomersEntity>();
        public DbSet<EmployeesEntity> EmployeesEntities => Set<EmployeesEntity>();

        public DbSet<OrderDetailsEntity> OrderDetailsEntities => Set<OrderDetailsEntity>();
        public DbSet<OrdersEntity> OrdersEntities => Set<OrdersEntity>();
        public DbSet<ShippersEntity> ShippersEntities => Set<ShippersEntity>();
        public DbSet<SuppliersEntity> SuppliersEntities => Set<SuppliersEntity>();
    }
}
