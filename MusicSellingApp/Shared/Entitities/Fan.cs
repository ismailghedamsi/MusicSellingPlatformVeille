using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Fan : User
    {
        public Cart Cart { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }
        public List<Album> Library { get; set; }
        [Required]
        [Range(10, 120, ErrorMessage = "This website is restricted for 10 years old to 120 years old person")]
        public int Age { get; set; }

        public override string ToString()
        {
            return FirstName + "\n" + LastName;
        }

        public Fan() : base()
        {
            Descriminator = "Fan";
            Library = new List<Album>();
        }

        public Fan(string firstName, string lastName, List<Album> library,long id,int age) 
        {
            FirstName = firstName;
            LastName = lastName;
            Library = library;
        }

        public override bool Equals(object obj)
        {
            return obj is Fan fan &&
                   FirstName == fan.FirstName &&
                   LastName == fan.LastName &&
                   EqualityComparer<List<Album>>.Default.Equals(Library, fan.Library);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Library);
        }
    }
}
