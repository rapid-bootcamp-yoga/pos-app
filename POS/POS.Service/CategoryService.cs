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

        private CategoryModel EntitytoModel(CategoriesEntity entity)
        {
            CategoryModel result = new CategoryModel();
            result.Id = entity.Id;
            result.CategoryName = entity.CategoryName;
            result.Description= entity.Description;
            result.Picture = entity.Picture;

            return result;
        }

        private void ModelToEntity(CategoryModel model, CategoriesEntity entity)
        {
            entity.CategoryName = model.CategoryName;
            entity.Description = model.Description;
            entity.Picture = model.Picture;
        }

        public CategoryService(ApplicationContext context)
        {
            _context = context;
        }

        public List<CategoriesEntity> GetCategories()
        {
            return _context.CategoriesEntities.ToList();
        }

        public CategoryModel GetCategoriesById(int? id)
        {
            var category = _context.CategoriesEntities.Find(id);
            return EntitytoModel(category);
        }


        public List<CategoriesEntity> SaveCategory([Bind("CategoryName, Description, Picture")] CategoriesEntity request) 
        {
               _context.CategoriesEntities.Add(request);
               _context.SaveChanges();
            return GetCategories();
        }



        public List<CategoriesEntity> UpdateCategories([Bind("Id, CategoryName, Description, Picture")] CategoryModel request)
        {
            var entity = _context.CategoriesEntities.Find(request.Id);
            ModelToEntity(request, entity);
                _context.CategoriesEntities.Update(entity);
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