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
    public class EmployeeService
    {
        private readonly ApplicationContext _context;

        private EmployeeModel EntityToModel(EmployeesEntity entity) 
        { 
            EmployeeModel result = new EmployeeModel();
            result.Id= entity.Id;
            result.LastName = entity.LastName;
            result.FirstName = entity.FirstName;
            result.Title = entity.Title;
            result.TitleOfCourtesy = entity.TitleOfCourtesy;
            result.BirthDate= entity.BirthDate;
            result.HireDate = entity.HireDate;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country= entity.Country;
            result.HomePhone = entity.HomePhone;
            result.Extension = entity.Extension;
            result.Photo = entity.Photo;
            result.Notes = entity.Notes;
            result.ReportsTo = entity.ReportsTo;
            result.PhotoPath = entity.PhotoPath;

            return result;
        }

        private void ModelToEntity(EmployeeModel model, EmployeesEntity entity)
        {
            entity.LastName = model.LastName;
            entity.FirstName = model.FirstName;
            entity.Title = model.Title;
            entity.TitleOfCourtesy = model.TitleOfCourtesy;
            entity.BirthDate = model.BirthDate;
            entity.HireDate = model.HireDate;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.HomePhone = model.HomePhone;
            entity.Extension = model.Extension;
            entity.Photo = model.Photo;
            entity.Notes = model.Notes;
            entity.ReportsTo = model.ReportsTo;
            entity.PhotoPath = model.PhotoPath;
        }

        public EmployeeService(ApplicationContext context)
        {
            _context = context;
        }

        public List<EmployeesEntity> GetEmployees()
        {
            return _context.EmployeesEntities.ToList();
        }

        public SupplierModel GetEmployeeById(int? id)
        {
            var employee = _context.EmployeesEntities.Find(id);
            return EntityToModel(employee);
        }

        public List<EmployeesEntity> SaveEmployee(EmployeesEntity request)
        {
            _context.EmployeesEntities.Add(request);
            _context.SaveChanges();
            return GetEmployees();
        }

        public void UpdateEmployee(EmployeeModel request)
        {
            var entity = _context.EmployeesEntities.Find(request.Id);
            ModelToEntity(request, entity);
            _context.EmployeesEntities.Update(entity);
            _context.SaveChanges();

        }

        public void DeleteEmployee(int? id)
        {
            var entity = _context.EmployeesEntities.Find(id);

            _context.EmployeesEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
