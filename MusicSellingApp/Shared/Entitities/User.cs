using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public abstract  class User
    {
        public long Id  { get;set; }
        public int Age { get; set; }

        public Account Account { get; set; }

        public User()
        {

        }

        public User(long id, int age, Account account)
        {
            Id = id;
            Age = age;
            Account = account;
        }
    }
}
