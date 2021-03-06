﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant_Api.Models
{
    public class ResturantContext:DbContext
    {
        public ResturantContext(DbContextOptions options) : base(options)
        { }
        public ResturantContext()
        { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Menu> Menu  { get; set; }
        public virtual DbSet<Order> Orders{ get; set; }



    }
}
