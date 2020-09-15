using System;
using System.ComponentModel.DataAnnotations;

namespace MusicSellingApp.Shared.Entitities
{
    public class Account
    {
        public  long Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Username { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(15)]

        public string Password { get; set; }


        [EmailAddress]
        public string Email { get; set; }

        public DateTime CreationDate { get; set; }

        public Boolean IsActive { get; set; }

        public Account()
        {

        }

        public Account(string username, string password, DateTime creationDate, bool isActive)
        {
            Username = username;
            Password = password;
            CreationDate = creationDate;
            IsActive = isActive;
        }
    }
}