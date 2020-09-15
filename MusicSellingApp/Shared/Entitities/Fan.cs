﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Fan : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Album> Library { get; set; }

        public override string ToString()
        {
            return FirstName + "\n" + LastName;
        }

        public Fan()
        {
            Library = new List<Album>();
        }

        public Fan(string firstName, string lastName, List<Album> library,long id,int age,Account account) : base(id, age, account)
        {
            FirstName = firstName;
            LastName = lastName;
            Library = library;
        }

        public override bool Equals(object obj)
        {
            return obj is Fan fan &&
                   Id == fan.Id &&
                   Age == fan.Age &&
                   EqualityComparer<Account>.Default.Equals(Account, fan.Account) &&
                   FirstName == fan.FirstName &&
                   LastName == fan.LastName &&
                   EqualityComparer<List<Album>>.Default.Equals(Library, fan.Library);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Age, Account, FirstName, LastName, Library);
        }
    }
}
