using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public abstract  class User
    {
        public long Id  { get;set; }
        [Required]
        [Range(10, 120, ErrorMessage = "This website is restricted for 10 years old to 120 years old person")]
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
