using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Infrastructure
{
    interface IOrderLine
    {
        IEnumerable<OrderLine> GetAll();

        OrderLine GetById(int id);

        void Insert(OrderLine orderLine);

        void Update(OrderLine orderLine);

        int Count();

        void Save();
    }
}
