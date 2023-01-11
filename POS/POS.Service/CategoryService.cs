using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using POS.Repository;
using System.ComponentModel;

namespace POS.Service
{
    public class CategoryService
    {
        private readonly ApplicationContext _context;

        public CategoryService(ApplicationContext context)
        {
            _context = context;
        }

        public List<CategoriesEntity> GetCategories()
        {
            return _context.CategoriesEntities.ToList();
        }

        public CategoriesEntity CategoriesEntityGetCategoriesById(int id)
        {
            return _context.CategoriesEntities.Find(id);
        }

        public List<CategoriesEntity> SaveCategory([Bind("CategoryName, Description, Picture")] CategoriesEntity request) 
        {
               _context.CategoriesEntities.Add(request);
               _context.SaveChanges();
            return GetCategories();
        }
    }
}