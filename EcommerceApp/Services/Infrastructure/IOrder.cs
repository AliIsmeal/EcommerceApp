using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Infrastructure
{
    interface IOrder
    {
        IEnumerable<Order> GetAll();

        Order GetById(int id);

        void Delete(int id);

        int Count();

        void Save();
    }
}
