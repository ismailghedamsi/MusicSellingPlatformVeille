using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Artist : User
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public DateTime? CareerBeginDate { get; set; }
        [Required]
        public string Description { get; set; }

        public List<Album> Discography { get; set; }

        public override string ToString()
        {
            return Name + "\n" + CareerBeginDate.ToString() + "\n" + Description;
        }

        public Artist()
        {

        }

        public Artist(string name, DateTime? careerBeginDate, string description, List<Album> discography, long id, int age, Account account)  : base(id, age, account)
        {
          
            CareerBeginDate = careerBeginDate;
            Description = description;
            Discography = discography;
            Name = name;

        }
    }
}
