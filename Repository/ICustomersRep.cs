using Resturant_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant_Api.Repository
{
    public interface ICustomersRep
    {
        public List<Customer> GetDetails();
        public Customer GetDetail(string id);
        public string AddDetail(Customer user);
        public int UpdateDetail(string id, Customer user);
        public int Delete(string id);
    }
}
