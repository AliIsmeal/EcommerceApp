using EcommerceApp.DataContext;
using EcommerceApp.Models;
using EcommerceApp.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.Repository
{
    public class OrderLineRepository:IOrderLine
    {
        private readonly DataContext.AppContext _db;

        public OrderLineRepository(DataContext.AppContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.OrderLine.Count();
        }

        public IEnumerable<OrderLine> GetAll()
        {
            return _db.OrderLine.Select(o => o);
        }

        public OrderLine GetById(int id)
        {
            return _db.OrderLine.FirstOrDefault(o => o.OrderLineId == id);
        }

        public void Insert(OrderLine orderLine)
        {
            _db.OrderLine.Add(orderLine);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(OrderLine orderLine)
        {
            _db.OrderLine.Update(orderLine);
        }
    }
}
