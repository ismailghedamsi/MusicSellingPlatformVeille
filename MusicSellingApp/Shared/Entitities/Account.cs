using System;

namespace MusicSellingApp.Shared.Entitities
{
    public class Account
    {
        public  long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

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