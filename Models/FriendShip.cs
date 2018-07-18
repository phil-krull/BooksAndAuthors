using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAndAuthors.Models
{
    public class FriendShip
    {
        [Key]
        public int FriendshipId {get; set;}

        public int FrienderId {get; set;}
        public User Friender {get; set;}

        public int FriendeeId {get; set;}
        public User Friendee {get; set;}
    }
}