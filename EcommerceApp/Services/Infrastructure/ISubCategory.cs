using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Infrastructure
{
    interface ISubCategory
    {
        IEnumerable<SubCategory> GetAll();

        SubCategory GetById(int id);

        void Insert(SubCategory subCat);

        void Update(SubCategory subCat);

        void Delete(int id);

        int Count();

        void Save();
    }
}
