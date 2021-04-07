using BookStoreModelLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.UserContext
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<CustomerDetails> Address { get; set; }
        public DbSet<OrderSummary> OrderSummary { get; set; }
    }
}
