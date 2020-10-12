using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicSellingApp.Shared.Entitities
{
    [JsonObject(IsReference = true)]
    public class Fan : User
    {
        public virtual Cart Cart { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }
        public ICollection<FanAlbums> FanAlbums { get; set; }

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
        }

        public Fan(string firstName, string lastName, List<Album> library)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            return obj is Fan fan &&
                   FirstName == fan.FirstName &&
                   LastName == fan.LastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}
