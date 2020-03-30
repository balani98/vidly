﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext()
        {

        }
        public DbSet<Customer> Customers { get; set; } // My domain models
        public DbSet<Movie> Movies { get; set; }// My domain models
        public DbSet<MembershipType> membershipTypes { get; set; }
       public DbSet<Genre> genres { get; set; }
    }
}
