using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using POS.Repository;
using POS.ViewModel;
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

        public CategoriesEntity GetCategoriesById(int? id)
        {
            var entity = _context.CategoriesEntities.Find(id);
            return entity;
        }


        public List<CategoriesEntity> SaveCategory([Bind("CategoryName, Description, Picture")] CategoriesEntity request) 
        {
               _context.CategoriesEntities.Add(request);
               _context.SaveChanges();
            return GetCategories();
        }



        public List<CategoriesEntity> UpdateCategories([Bind("Id, CategoryName, Description, Picture")] CategoriesEntity request)
        {
                _context.CategoriesEntities.Update(request);
                _context.SaveChanges();
            return GetCategories();
        }

        //public List<CategoriesEntity> DeleteCategory(int? id)
        //{
        //    var entity = _context.CategoriesEntities.Find(id);

        //    _context.CategoriesEntities.Remove(entity);
        //    _context.SaveChanges();
        //    return GetCategories();
        //}

        public void DeleteCategory(int? id)
        {
            var entity = _context.CategoriesEntities.Find(id);

            _context.CategoriesEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}