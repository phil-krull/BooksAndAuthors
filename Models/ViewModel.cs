using System.Collections.Generic;

namespace BooksAndAuthors.Models
{
    public class ViewModel
    {
        public Author Author {get; set;}
        public Book Book {get; set;}
        public Publisher Publisher {get; set;}
        public Publication Publication {get; set;}
        public User User {get; set;}
        public FriendShip FriendShip {get; set;}
        public List<Author> AllAuthors {get; set;}
        public List<Book> AllBooks {get; set;}
        public List<Publisher> AllPublishers {get; set;}
        public List<User> AllUsers {get; set;}
        public List<FriendShip> AllFriendships {get; set;}
    }
}