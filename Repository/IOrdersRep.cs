using Resturant_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant_Api.Repository
{
    public interface IOrdersRep
    {
        public List<Order> GetDetails();
        public Order GetDetail(int id);
        public int AddDetail(Order order);
       
        public int Delete(int id);
    }
}
