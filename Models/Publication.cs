using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAndAuthors.Models
{
    [Table("publications")]
    public class Publication
    {
        [Key]
        public int PublicationId {get; set;}
        public int BookId {get; set;}
        public Book Book {get; set;}
        public int PublisherId {get; set;}
        public Publisher Publisher {get; set;}
        public DateTime PublishedDate {get; set;}

        public Publication()
        {
            PublishedDate = DateTime.Now;
        }
    }
}