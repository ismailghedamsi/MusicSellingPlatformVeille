using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Admin : User
    {
 
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Admin()
        {

        }

    
        public Admin(string firstName, string lastName,long Id,int age,Account account) : base(Id,age, account)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
