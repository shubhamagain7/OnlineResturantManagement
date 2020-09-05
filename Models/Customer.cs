using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant_Api.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string PhoneNo { get; set; }
        public string Password { get; set; }
    }
}
