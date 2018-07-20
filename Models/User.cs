using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAndAuthors.Models
{
    [Table("users")]
    public class User
    {
        public User()
        {
            FriendeeList = new List<FriendShip>();
            FrienderList = new List<FriendShip>();
            Created_at = DateTime.Now;
            Updated_at = DateTime.Now;
        }

        [Key]
        public int UserId {get; set;}

        [Required]
        public string Name {get; set;}

        [InverseProperty("Friendee")]
        public List<FriendShip> FrienderList {get; set;}

        [InverseProperty("Friender")]
        public List<FriendShip> FriendeeList {get; set;}

        public DateTime Created_at {get; set;}
        public DateTime Updated_at {get; set;}

    }
}