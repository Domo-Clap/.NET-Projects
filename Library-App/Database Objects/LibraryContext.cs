using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


/*
 * ----------------------------------------------------------------------------------------------------
 * Class that represents the connection/mapping between the MSSQL DB and the Book class.
 * Uses the Entity Framework to achieve this mapping.
 * Is used in all other class files that need access to the list of the book objects
 * ----------------------------------------------------------------------------------------------------
 */

namespace Library_App
{
    class LibraryContext : DbContext
    {

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"sqlserverstring");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {

                entity.ToTable("BOOKS");

                entity.HasKey(e => e.Book_ID);
                entity.Property(e => e.Book_Title).HasColumnName("book_title");
                entity.Property(e => e.Book_Author).HasColumnName("book_author");
                entity.Property(e => e.Book_Genre).HasColumnName("book_genre");
                entity.Property(e => e.Book_Year_Published).HasColumnName("year_published");
                entity.Property(e => e.Book_copies_available).HasColumnName("copies_available");
                

            });
        }

    }
}
