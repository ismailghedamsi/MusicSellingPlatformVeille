using System;

namespace MusicSellingApp.Shared.Entitities
{
    public class Account
    {

        private string Username { get; set; }
        private string Password { get; set; }

        private DateTime CreationDate { get; set; }

        private Boolean IsActive { get; set; }

        public Account(string username, string password, DateTime creationDate, bool isActive)
        {
            Username = username;
            Password = password;
            CreationDate = creationDate;
            IsActive = isActive;
        }
    }
}