using BookStore.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.MSSQL
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasData(new[]
                {
                    new Book
                    {
                        Id = 1,
                        Author = "Толстой",
                        Title = "Война и мир",
                        Date = DateTime.Now.ToString("yyyy-MM-dd")
                    },
                    new Book
                    {
                        Id = 2,
                        Author = "Достоевский",
                        Title = "Преступление и наказание",
                        Date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
                    },
                    new Book
                    {
                        Id = 3,
                        Author = "Булгаков",
                        Title = "Мастер и Маргарита",
                        Date = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd")
                    },
                    new Book
                    {
                        Id = 4,
                        Author = "Грибоедов",
                        Title = "Горе от ума",
                        Date = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")
                    },
                    new Book
                    {
                        Id = 5,
                        Author = "Горький",
                        Title = "На дне",
                        Date = DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd")
                    },
                    new Book
                    {
                        Id = 6,
                        Author = "Толстой",
                        Title = "Детство",
                        Date = DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd")
                    },
                    new Book
                    {
                        Id = 7,
                        Author = "Булгаков",
                        Title = "Мастер и Маргарита",
                        Date = DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd")
                    }
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
    }
}
