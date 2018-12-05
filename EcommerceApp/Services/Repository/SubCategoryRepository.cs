using EcommerceApp.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Models;
using EcommerceApp.DataContext;

namespace EcommerceApp.Services.Repository
{
    public class SubCategoryRepository : ISubCategory
    {
        private readonly DataContext.AppContext _db;

        public SubCategoryRepository(DataContext.AppContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.SubCategory.Count();
        }

        public void Delete(int id)
        {
            var subCategory = GetById(id);
            if (subCategory != null)
            {
                _db.SubCategory.Remove(subCategory);
            }
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return _db.SubCategory.Select(s => s);
        }

        public SubCategory GetById(int id)
        {
            return _db.SubCategory.FirstOrDefault(s => s.SubCategoryId == id);
        }

        public void Insert(SubCategory subCat)
        {
            _db.SubCategory.Add(subCat);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(SubCategory subCat)
        {
            _db.SubCategory.Update(subCat);
        }
    }
}
