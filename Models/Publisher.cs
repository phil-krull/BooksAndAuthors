using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksAndAuthors.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId {get; set;}

        [Required]
        public string Name {get; set;}

        public DateTime Created_At {get; set;}
        public DateTime Updated_At {get; set;}
        public List<Publication> Publications {get; set;}
        public Publisher()
        {
            Publications = new List<Publication>();
            Created_At = DateTime.Now;
            Updated_At = DateTime.Now;
        }
    }
}