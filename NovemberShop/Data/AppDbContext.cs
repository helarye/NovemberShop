namespace NovemberShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using NovemberShop.Models;
    
    using System.Collections.Generic;


    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> ShoppingCarts { get; set; }
        public DbSet<Item> CartItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
