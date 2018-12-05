using EcommerceApp.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models;
using EcommerceApp.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Services.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly DataContext.AppContext _db;

        public CategoryRepository(DataContext.AppContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Category.Count();
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category!=null)
            {
                _db.Category.Remove(category);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Category.Select(c => c);
        }

        public Category GetById(int id)
        {
            return _db.Category.FirstOrDefault(c => c.CategoryId == id);
        }

        public void Insert(Category cat)
        {
            _db.Category.Add(cat);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category cat)
        {
            _db.Category.Update(cat);
        }
    }
}
