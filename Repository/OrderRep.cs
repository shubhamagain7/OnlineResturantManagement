using Resturant_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant_Api.Repository
{
    public class OrderRep : IOrdersRep
    {
        private readonly ResturantContext db;
        public OrderRep(ResturantContext _db)
        {
            db = _db;
        }

        public int AddDetail(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();

            return order.OrderId;
                
        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)
            {
                var deletePost = db.Orders.FirstOrDefault(p => p.OrderId== id);

                if (deletePost != null)
                {
                    db.Orders.Remove(deletePost);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }

        public Order GetDetail(int id)
        {
            if (db != null)
            {
                return (db.Orders.Where(p => p.OrderId == id)).FirstOrDefault();
            }
            return null;
        }

        public List<Order> GetDetails()
        {
            return db.Orders.ToList();
        }
    }
}
