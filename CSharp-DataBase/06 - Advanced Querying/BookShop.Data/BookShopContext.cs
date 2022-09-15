using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookShop.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext() 
        {
        }
        public BookShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BooksCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.CONNECTION);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>(e => 
            {
                e.HasKey(b => new {b.CategoryId,b.BookId }); // Composite PK
            });
        }

    }
}
