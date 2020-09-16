using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Artist 
    {

        public long Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public DateTime? CareerBeginDate { get; set; }
        [Required]
        public string Description { get; set; }

        //public List<Album> Discography { get; set; }

        public override string ToString()
        {
            return Name + "\n" + CareerBeginDate.ToString() + "\n" + Description;
        }

        public Artist()
        {

        }

        public Artist(string name, DateTime? careerBeginDate, string description)  
        {
          
            CareerBeginDate = careerBeginDate;
            Description = description;
            //Discography = discography;
            Name = name;

        }
    }
}
