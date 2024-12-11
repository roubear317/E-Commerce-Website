using E_commerce.EF.Model;
using E_Commerce.Core.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.Context
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options ):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<User> users { get; set; }



    }
}
