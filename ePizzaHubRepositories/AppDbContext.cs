using ePizzaHubEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ePizzaHubRepositories
{
    public class AppDbContext : DbContext
    {
        // Add 2 constructors first one for Migration and 2nd one for the Connectionstring from presentation layer.
        // (ie., from ConfigureServices method of the startup class UseSqlserver()
        public AppDbContext()
        {
            // this is for Migration
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // this is for connection string from Presentation layer
        }
        //Add the DbSet fields
        public  DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

       // public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }        
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            //configuring many to many relationships
            // modelBuilder.Entity<UserRole>().ToTable("UserRoles").HasKey(u => new { u.UserId, u.RoleId });
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(r => r.Users).UsingEntity<Dictionary<string, object>>("UserRole",
                l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId"), //l for left table
                r => r.HasOne<User>().WithMany().HasForeignKey("UserId"), //r for right table 
                j =>                                             //j for join table 
                {
                    j.HasKey("UserId", "RoleId");
                    j.ToTable("UserRoles");
                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //This method is to Configure the Database to be used for this context 
           if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source = LAPTOP-JB85G4E6\SQLEXPRESS02; initial catalog = ePizzaHub;
                                        persist security info = True; user id = sa1; password = sa@1234;");
            }

        }

    }
}
