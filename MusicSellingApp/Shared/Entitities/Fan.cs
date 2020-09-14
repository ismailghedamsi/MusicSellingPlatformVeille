using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Fan : User
    {
        private string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Album> Library { get; set; }

        public Fan()
        {

        }

        public Fan(string firstName, string lastName, List<Album> library,long id,int age,Account account) : base(id, age, account)
        {
            FirstName = firstName;
            LastName = lastName;
            Library = library;
        }
    }
}
