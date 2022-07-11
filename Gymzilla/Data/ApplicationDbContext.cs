using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gymzilla.Models;

namespace Gymzilla.Data
{
    public class ApplicationDbContext : IdentityDbContext //database
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Global DbSet objects for each Model class that can perform CRUD operations
        public DbSet<Brand> Brands { get; set; } // individual tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
