using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Admin 
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Admin()
        {

        }

    
        public Admin(string firstName, string lastName,long Id,int age) 
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
