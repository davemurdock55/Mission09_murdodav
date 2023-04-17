using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Mission09_murdodav.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mission09_murdodav.Models
{
    public partial class BookstoreContext : DbContext
    {
        
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookPurchase> BookPurchases { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Book>().HasData(

                new Book
                {
                    Author = "Victor Hugo",
                    BookId = 1,
                    Category = "Classic",
                    Classification = "Fiction",
                    Isbn = "978-0451419439",
                    PageCount = 1488,
                    Price = 9.95,
                    Publisher = "Signet",
                    Title = "Les Miserables"
                },
                new Book
                {
                    Author = "Doris Kearns Goodwin",
                    BookId = 2,
                    Category = "Biography",
                    Classification = "Non-Fiction",
                    Isbn = "978-0743270755",
                    PageCount = 944,
                    Price = 14.58,
                    Publisher = "Simon & Schuster",
                    Title = "Team of Rivals"
                },
                new Book
                {
                    Author = "Alice Schroeder",
                    BookId = 3,
                    Category = "Biography",
                    Classification = "Non-Fiction",
                    Isbn = "978-0553384611",
                    PageCount = 832,
                    Price = 21.54,
                    Publisher = "Bantam",
                    Title = "The Snowball"
                },
                new Book
                {
                    Author = "Ronald C. White",
                    BookId = 4,
                    Category = "Biography",
                    Classification = "Non-Fiction",
                    Isbn = "978-0812981254",
                    PageCount = 864,
                    Price = 11.61,
                    Publisher = "Random House",
                    Title = "American Ulysses"
                }



                );
        }

    }
}
