using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAndAuthors.Models
{
    public class Author
    {
        [Key]
        public int AuthorId {get; set;}
        
        [Required(ErrorMessage = "First Name is required!")]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters long!")]
        [MaxLength(10, ErrorMessage = "Wow, your First Name is long!")]

        public string First_Name {get; set;}
        [Required(ErrorMessage = "Last Name is required!")]        
        [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters long!")]
        [MaxLength(10, ErrorMessage = "Wow, your Last Name is long!")]
        public string Last_Name {get; set;}

        public List<Book> Books {get; set;}

        public DateTime Created_At {get; set;}
        public DateTime Updated_At {get; set;}

        public Author()
        {
            Books = new List<Book>();
            Created_At = DateTime.Now;
            Updated_At = DateTime.Now;
        }
    }
}