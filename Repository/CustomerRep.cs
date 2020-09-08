using Resturant_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant_Api.Repository
{
    public class CustomerRep : ICustomersRep
    {
        private readonly ResturantContext db;
        public CustomerRep(ResturantContext _db)
        {
            db = _db;
        }
        public string AddDetail(Customer user)
        {
            db.Customers.Add(user);
            db.SaveChanges();

            return user.PhoneNo;
        }

        public int Delete(string id)
        {
            int result = 0;

            if (db != null)
            {
                var deletePost = db.Customers.FirstOrDefault(p => p.PhoneNo == id);

                if (deletePost != null)
                {
                    db.Customers.Remove(deletePost);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }
    

        public Customer GetDetail(string id)
        {
        if (db != null)
        {
            return (db.Customers.Where(p => p.PhoneNo == id)).FirstOrDefault();
        }
        return null;
    }

        public List<Customer> GetDetails()
        {
            return db.Customers.ToList();
        }

        public int UpdateDetail(string id, Customer user)
        {
            if (db != null)
            {
                var myVar = (db.Customers.Where(p => p.PhoneNo == id)).FirstOrDefault();
                if (myVar != null)
                {
                    myVar.FirstName = user.FirstName;
                    myVar.LastName = user.LastName;
                    myVar.Password = user.Password;
                    db.SaveChanges();
                    return 1;

                }
                return 0;
            }
            return 0;
        }
    }
}
