using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant_Api.Models
{
    public class Order
    {
        public string PhoneNo { get; set; }
        public int FoodId { get; set; }
        [Key]
        public int OrderId { get; set; }
    }
}
