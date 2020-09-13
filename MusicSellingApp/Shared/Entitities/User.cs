using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public abstract  class User
    {
        public long Id  { get;set; }
        public int Age { get; set; }

        public Account account { get; set; }

        protected User(long id, int age, Account account)
        {
            Id = id;
            Age = age;
            this.account = account;
        }
    }
}
