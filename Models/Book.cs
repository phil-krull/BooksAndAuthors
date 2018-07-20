using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAndAuthors.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        public int BookId {get; set;}

        [Required]
        public string Title {get; set;}
        //this must match the primary key in the joining table
        public int AuthorId {get; set;}
        public Author Author {get; set;}
        public List<Publication> Publications {get; set;}
        public DateTime Created_At {get; set;}
        public DateTime Updated_At {get; set;}

        public Book()
        {
            Publications = new List<Publication>();
            Created_At = DateTime.Now;
            Updated_At = DateTime.Now;
        }
    }
}