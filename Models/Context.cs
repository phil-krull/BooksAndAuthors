using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
 
namespace BooksAndAuthors.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Author> Authors {get; set;}
        public DbSet<Book> Books {get; set;}
        public DbSet<Publisher> Publishers {get; set;}
        public DbSet<Publication> Publications {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<FriendShip> FriendShips {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendShip>()
                .HasOne(friendee => friendee.Friender)
                .WithMany(friender => friender.FriendeeList);

            modelBuilder.Entity<FriendShip>()
                .HasOne(friender => friender.Friendee)
                .WithMany(friendee => friendee.FrienderList);
        }
    }
}