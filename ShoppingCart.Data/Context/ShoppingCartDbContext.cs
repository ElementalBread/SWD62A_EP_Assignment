
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Context
{
    public class ShoppingCartDbContext: DbContext
    {
        public ShoppingCartDbContext(DbContextOptions options)
            : base(options)
        { }

        //type Product accurately and then press ctrl+.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Order>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
