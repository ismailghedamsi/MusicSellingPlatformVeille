using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Artist 
    {
        public long Id { get; set; }
        [Required]
        [Range(10, 120, ErrorMessage = "This website is restricted for 10 years old to 120 years old person")]
        public int Age { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public DateTime? CareerBeginDate { get; set; }
        [Required]
        public string Description { get; set; }


        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public ICollection<Album> Discography { get; set; }


        public override string ToString()
        {
            return Name + "\n" + CareerBeginDate.ToString() + "\n" + Description;
        }

    

        public Artist()
        {

            Discography = new List<Album>() {
                new Album("test",DateTime.Now,Genre.Blues,"aaa",10.5,"desc")
            };
        }

        public Artist(string name, DateTime? careerBeginDate, string description)  
        {
          
            CareerBeginDate = careerBeginDate;
            Description = description;
            Name = name;

        }
    }
}
