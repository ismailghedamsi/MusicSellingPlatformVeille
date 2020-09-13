using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Admin : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Admin(string firstName, string lastName, long id, int age, Account account) : base(id,age,account)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
