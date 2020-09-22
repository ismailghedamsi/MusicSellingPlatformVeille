using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Artist  : User
    {

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

  


        public ICollection<Album> Discography { get; set; }


        public override string ToString()
        {
            return Username + "\n" + Password + "\n" + Email + "\n" + Name + "\n" + CareerBeginDate.ToString() + "\n" + Description;
        }

    

        public Artist() : base()
        {
            Descriminator = "Artist";
            Discography = new List<Album>();
        }

        public Artist(string name, DateTime? careerBeginDate, string description)  
        {
          
            CareerBeginDate = careerBeginDate;
            Description = description;
            Name = name;

        }
    }
}
