using MVCAuthenticationTekrar.Models.CustomTools;
using MVCAuthenticationTekrar.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAuthenticationTekrar.Models.Context
{
    public class MyContext : DbContext
    {
        public MyContext():base("MyConnection")
        {
            Database.SetInitializer(new MyInit());

            

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().Ignore(x => x.ID);

            modelBuilder.Entity<OrderDetail>().HasKey(x => new { x.OrderID, x.ProductID });

            modelBuilder.Entity<AppUser>().HasOptional(x => x.Profile).WithRequired(x => x.AppUser);

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<AppUserProfile> Profiles { get; set; }


    }
}