using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Artist : User
    {
        public string Name { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public string Description { get; set; }

        public List<Album> Discography { get; set; }

        public Artist()
        {

        }

        public Artist(string name, DateTime careerBeginDate, string description, List<Album> discography, long id, int age, Account account)  : base(id, age, account)
        {
          
            CareerBeginDate = careerBeginDate;
            Description = description;
            Discography = discography;
        }
    }
}
